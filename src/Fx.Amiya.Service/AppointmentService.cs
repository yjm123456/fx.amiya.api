using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.Appointment;
using Fx.Amiya.Dto.OrderReport;
using Fx.Amiya.Dto.WxAppConfig;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Fx.Infrastructure;
using Fx.Infrastructure.DataAccess;
using Fx.Infrastructure.Utils;
using jos_sdk_net.Util;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class AppointmentService : IAppointmentService
    {
        public IDalAppointmentInfo dalAppointmentInfo;
        private IDalHospitalAppointmentNumer dalHospitalAppointmentNumer;
        private IDalCustomerInfo dalCustomerInfo;
        private IUnitOfWork unitOfWork;
        private IDalItemInfo dalItemInfo;
        private IHospitalInfoService _hospitalInfoService;
        private IDalAmiyaEmployee dalAmiyaEmployee;
        private IDalOrderInfo dalOrderInfo;
        private IDalBindCustomerService dalBindCustomerService;
        private IDalHospitalSurplusAppointment dalHospitalSurplusAppointment;
        private IDalHospitalPartakeItem dalHospitalQuotedPriceItemInfo;
        private IDalConfig dalConfig;
        public AppointmentService(
            IDalAppointmentInfo dalAppointmentInfo,
            IDalHospitalAppointmentNumer dalHospitalAppointmentNumer,
            IDalBindCustomerService dalBindCustomerService,
            IHospitalInfoService hospitalInfoService,
            IDalCustomerInfo dalCustomerInfo,
            IUnitOfWork unitOfWork,
            IDalItemInfo dalItemInfo,
            IDalAmiyaEmployee dalAmiyaEmployee,
            IDalOrderInfo dalOrderInfo,
            IDalHospitalSurplusAppointment dalHospitalSurplusAppointment,
            IDalHospitalPartakeItem dalHospitalQuotedPriceItemInfo,
            IDalConfig dalConfig)
        {
            this.dalAppointmentInfo = dalAppointmentInfo;
            this.dalHospitalAppointmentNumer = dalHospitalAppointmentNumer;
            this.dalCustomerInfo = dalCustomerInfo;
            this.dalBindCustomerService = dalBindCustomerService;
            this.unitOfWork = unitOfWork;
            this.dalItemInfo = dalItemInfo;
            this.dalAmiyaEmployee = dalAmiyaEmployee;
            this.dalOrderInfo = dalOrderInfo;
            this.dalHospitalSurplusAppointment = dalHospitalSurplusAppointment;
            this.dalHospitalQuotedPriceItemInfo = dalHospitalQuotedPriceItemInfo;
            this.dalConfig = dalConfig;
            _hospitalInfoService = hospitalInfoService;
        }


        public async Task<FxPageInfo<AppointmentInfoDto>> GetListWithPageAsync(int? hospitalId, int? employeeId, DateTime? startDate, DateTime? endDate, int pageNum, int pageSize)
        {
            try
            {
                IQueryable<AppointmentInfo> appointment;

                if (startDate == null || endDate == null)
                {
                    appointment = from d in dalAppointmentInfo.GetAll() where d.Status!=(byte)AppointmentStatusType.Cancel
                                  select d;
                    if (hospitalId.HasValue)
                    {
                        appointment = from d in appointment
                                      where d.HospitalId == hospitalId                                     
                                      select d;
                    }
                    if (employeeId.HasValue)
                    {
                        var employee = await dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).SingleOrDefaultAsync(e => e.Id == employeeId);
                        if (employee.IsCustomerService && !employee.AmiyaPositionInfo.IsDirector)
                        {
                            appointment = from d in appointment
                                          where dalBindCustomerService.GetAll().Count(e => e.CustomerServiceId == employeeId && e.BuyerPhone == d.Phone) > 0
                                          select d;
                        }
                    }
                }
                else
                {
                    DateTime startrq = ((DateTime)startDate).Date;
                    DateTime endrq = ((DateTime)endDate).Date.AddDays(1);

                    appointment = from d in dalAppointmentInfo.GetAll()
                                  where d.AppointmentDate.Date >= startrq && d.AppointmentDate.Date < endrq && d.Status != (byte)AppointmentStatusType.Cancel
                                  select d;
                    if (hospitalId.HasValue)
                    {
                        appointment = from d in appointment
                                      where d.HospitalId == hospitalId
                                     
                                      select d;
                    }
                    if (employeeId.HasValue)
                    {
                        var employee = await dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).SingleOrDefaultAsync(e => e.Id == employeeId);
                        if (employee.IsCustomerService && !employee.AmiyaPositionInfo.IsDirector)
                        {
                            appointment = from d in appointment
                                          where dalBindCustomerService.GetAll().Count(e => e.CustomerServiceId == employeeId && e.BuyerPhone == d.Phone) > 0
                                          select d;
                        }
                    }
                }
                var config = await GetCallCenterConfig();
                var appointmentInfo = from d in appointment
                                      select new AppointmentInfoDto
                                      {
                                          Id = d.Id,
                                          AppointmentDate = d.AppointmentDate,
                                          Week = d.Week,
                                          Time = d.Time,
                                          Status = d.Status,
                                          StatusText = GetAppointmentStatusText(d.Status),
                                          ItemName = d.ItemInfoName,
                                          Phone = config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                                          PhoneRes = d.Phone,
                                          EncryptPhone = ServiceClass.Encrypt(d.Phone, config.PhoneEncryptKey),
                                          CreateDate = d.CreateDate,
                                          SubmitDate = d.SubmitDate,
                                          HospitalId = d.HospitalId,
                                          HospitalName = d.HospitalInfo.Name,
                                          Remark = d.Remark,
                                      };

                FxPageInfo<AppointmentInfoDto> appointmentPageInfo = new FxPageInfo<AppointmentInfoDto>(); ;
                appointmentPageInfo.TotalCount = await appointmentInfo.CountAsync();
                appointmentPageInfo.List = await appointmentInfo.OrderBy(z => z.Status).ThenByDescending(z => z.AppointmentDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
                foreach (var x in appointmentPageInfo.List)
                {
                    int customerServiceId = 0;
                    var bindResult = dalBindCustomerService.GetAll().FirstOrDefaultAsync(z => z.BuyerPhone == x.PhoneRes);
                    if (bindResult.Result != null)
                    {
                        customerServiceId = bindResult.Result.CustomerServiceId;
                        var res = await dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).SingleOrDefaultAsync(e => e.Id == customerServiceId);
                        x.EmpolyeeName = res.Name.ToString();
                    }
                    else {
                        x.EmpolyeeName = "";
                    }
                }
                return appointmentPageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        /// <summary>
        /// 获取预约状态文本
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        private static string GetAppointmentStatusText(byte status)
        {
            try
            {
                string text = "";
                switch (status)
                {
                    case 0:
                        text = "预约处理";
                        break;
                    case 1:
                        text = "预约取消";
                        break;
                    case 3:
                        text = "预约成功";
                        break;
                    default:
                        text = "未知";
                        break;
                }
                return text;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        ///// <summary>
        ///// 获取预约已满日期集合
        ///// </summary>
        ///// <param name="hospitalId"></param>
        ///// <param name="itemInfoId"></param>
        ///// <param name="year"></param>
        ///// <param name="month"></param>
        ///// <returns></returns>
        //public async Task<List<int>> GetAppointmentFullDateAsync(int hospitalId, int itemInfoId, int year, int month)
        //{
        //    try
        //    {
        //        var quantity = await dalHospitalQuotedPriceItemInfo.GetAll().SingleOrDefaultAsync(e => e.HospitalId == hospitalId&&e.ItemId==itemInfoId);

        //        var q = from d in dalAppointmentInfo.GetAll()
        //                where d.AppointmentDate.Year == year
        //                && d.AppointmentDate.Month == month
        //                && d.HospitalId == hospitalId
        //                && d.ItemInfoName == itemInfoId
        //                && d.Status != (byte)AppointmentStatus.Cancel
        //                group d by new { d.AppointmentDate, d.Time } into g
        //                select new
        //                {
        //                    g.Key.AppointmentDate,
        //                    g.Key.Time,
        //                    Count = g.Count()
        //                };

        //        var t = from d in await q.ToListAsync()
        //                group d by d.AppointmentDate into g
        //                select new
        //                {
        //                    AppointmentDate = g.Key,
        //                    amCount = g.SingleOrDefault(e => e.Time == "上午" && e.AppointmentDate == g.Key)?.Count,
        //                    pmCount = g.SingleOrDefault(e => e.Time == "下午" && e.AppointmentDate == g.Key)?.Count,
        //                };

        //        var res = from d in t.ToList()
        //                  where (d.amCount ?? 0) >= quantity.ForenoonCanAppointmentQuantity
        //                  && (d.pmCount ?? 0) >= quantity.AfternoonCanAppointmentQuantity
        //                  select d.AppointmentDate.Day;

        //        return res.ToList();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        public async Task<AppointmentSurplusQuantityDto> GetSurplusQuantityAsync(int hospitalId, int itemId, DateTime date)
        {
            try
            {

                AppointmentSurplusQuantityDto surplusQuantityDto = new AppointmentSurplusQuantityDto();
                var surplusQuantity = await dalHospitalSurplusAppointment.GetAll().SingleOrDefaultAsync(e => e.HospitalId == hospitalId && e.ItemId == itemId && e.Date.Date == date.Date);
                if (surplusQuantity == null)
                {
                    var appointmentQuantity = await dalHospitalQuotedPriceItemInfo.GetAll().SingleOrDefaultAsync(e => e.HospitalId == hospitalId && e.ItemId == itemId);
                    surplusQuantityDto.AmSurplusQuantity = appointmentQuantity != null ? appointmentQuantity.ForenoonCanAppointmentQuantity : 0;
                    surplusQuantityDto.PmSurplusQuantity = appointmentQuantity != null ? appointmentQuantity.AfternoonCanAppointmentQuantity : 0;
                }
                else
                {
                    surplusQuantityDto.AmSurplusQuantity = surplusQuantity.ForenoonSurplusQuantity;
                    surplusQuantityDto.PmSurplusQuantity = surplusQuantity.AfternoonSurplusQuantity;
                }

                return surplusQuantityDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }





        /// <summary>
        /// 判断客户是否有订单信息
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="itemInfoId"></param>
        /// <returns></returns>
        public async Task CheckOrderAsync(string customerId, int itemInfoId)
        {
            try
            {
                var customer = await dalCustomerInfo.GetAll().SingleOrDefaultAsync(e => e.Id == customerId);


                var item = await dalItemInfo.GetAll().SingleOrDefaultAsync(e => e.Id == itemInfoId);
                if (item == null)
                    throw new Exception("项目编号错误");

                var order = from d in dalOrderInfo.GetAll()
                            where d.GoodsId == item.OtherAppItemId
                            && d.IsAppointment == false
                            && d.Phone == customer.Phone
                            && (d.StatusCode == OrderStatusCode.WAIT_BUYER_CONFIRM_GOODS || d.StatusCode == OrderStatusCode.WAIT_SELLER_SEND_GOODS)
                            select d;


                if (await order.CountAsync() == 0)
                    throw new Exception("无该项目的订单信息");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        ///// <summary>
        ///// 修改剩余可预约数量
        ///// </summary>
        ///// <param name="hospitalId"></param>
        ///// <param name="appointmentDate"></param>
        ///// <param name="time">上午/下午</param>
        ///// <returns></returns>
        //private async Task UpdateSurplusQuantityAsync(int hospitalId,int itemId, DateTime appointmentDate, string time)
        //{

        //    var surplusQuantity = await dalHospitalSurplusAppointment.GetAll()
        //        .SingleOrDefaultAsync(e => e.HospitalId == hospitalId&&e.ItemId==itemId && e.Date.Date == appointmentDate.Date);
        //    if (surplusQuantity == null)
        //    {
        //        var appointmentQuantitys = await dalHospitalQuotedPriceItemInfo.GetAll().SingleOrDefaultAsync(e => e.HospitalId == hospitalId&&e.ItemId==itemId);
        //        HospitalSurplusAppointment hospitalSurplusAppointment = new HospitalSurplusAppointment();
        //        hospitalSurplusAppointment.HospitalId = hospitalId;
        //        hospitalSurplusAppointment.ItemId = itemId;
        //        hospitalSurplusAppointment.ForenoonSurplusQuantity = appointmentQuantitys.ForenoonCanAppointmentQuantity;
        //        hospitalSurplusAppointment.AfternoonSurplusQuantity = appointmentQuantitys.AfternoonCanAppointmentQuantity;
        //        hospitalSurplusAppointment.Date = appointmentDate;
        //        hospitalSurplusAppointment.Version = 0;
        //        await dalHospitalSurplusAppointment.AddAsync(hospitalSurplusAppointment, true);
        //        await UpdateSurplusQuantityAsync(hospitalId,itemId, appointmentDate, time);
        //    }
        //    else
        //    {
        //        if (time == "上午")
        //        {
        //            if (surplusQuantity.ForenoonSurplusQuantity == 0)
        //                throw new Exception("预约人数已满，请重新选择预约日期");
        //            surplusQuantity.ForenoonSurplusQuantity = surplusQuantity.ForenoonSurplusQuantity - 1;
        //        }
        //        else
        //        {
        //            if (surplusQuantity.AfternoonSurplusQuantity == 0)
        //                throw new Exception("预约人数已满，请重新选择预约日期");
        //            surplusQuantity.AfternoonSurplusQuantity = surplusQuantity.AfternoonSurplusQuantity - 1;
        //        }
        //        surplusQuantity.Version = surplusQuantity.Version + 1;
        //        await dalHospitalSurplusAppointment.UpdateAsync(surplusQuantity, true);
        //    }
        //}



        /// <summary>
        /// 添加预约
        /// </summary>
        /// <param name="addDto"></param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<int> AddAsync(AddAppointmentDto addDto, string customerId)
        {
            try
            {
                unitOfWork.BeginTransaction();
                if (addDto.AppointmentDate.Date < DateTime.Now.AddDays(1).Date)
                    throw new Exception("预约日期不能早于明天");
                //修改剩余可预数量
                //await UpdateSurplusQuantityAsync(addDto.HospitalId,addDto.ItemInfoName, addDto.AppointmentDate, addDto.Time);


                var customer = await dalCustomerInfo.GetAll().SingleOrDefaultAsync(e => e.Id == customerId);

                AppointmentInfo appointmentInfo = new AppointmentInfo();
                appointmentInfo.AppointmentDate = addDto.AppointmentDate.Date;
                appointmentInfo.Week = addDto.Week;
                appointmentInfo.Time = addDto.Time;
                appointmentInfo.CreateDate = addDto.CreateDate;
                appointmentInfo.CustomerName = addDto.CustomerName;
                appointmentInfo.SubmitDate = DateTime.Now;
                appointmentInfo.CustomerId = customerId;
                appointmentInfo.Phone = addDto.Phone;
                appointmentInfo.Remark = addDto.Remark;
                appointmentInfo.Status = (byte)AppointmentStatusType.Process;
                appointmentInfo.HospitalId = addDto.HospitalId;
                appointmentInfo.ItemInfoName = addDto.ItemInfoName;

                await dalAppointmentInfo.AddAsync(appointmentInfo, true);

                unitOfWork.Commit();

                //组织邮件信息
                SendMails sendMails = new SendMails();
                var hospitalInfo = await _hospitalInfoService.GetBaseByIdAsync(addDto.HospitalId);
                var sub = "有新的顾客在“到店预约”中预约了“" + addDto.AppointmentDate.ToString("yyyy-MM-dd") + "”去往“" + hospitalInfo.Name.ToString() + "”，请及时跟进哦！";

                //向管理员发送邮箱通知
                var bindCustmerInfo = await dalBindCustomerService.GetAll().SingleOrDefaultAsync(e => e.BuyerPhone == addDto.Phone);
                if (bindCustmerInfo != null)
                {
                    var empId = bindCustmerInfo.CustomerServiceId;
                    var empInfo = await dalAmiyaEmployee.GetAll().SingleOrDefaultAsync(e => e.Id == empId);
                    if (empInfo != null)
                    {
                        var email = empInfo.Email;
                        /*if (email != "0")
                            sendMails.sendMail("smtp.qq.com", "3023330386@qq.com", "kivbmbikthsmdejf", "阿美雅", "3023330386@qq.com", email, "客户下单提示", sub);*/
                    }
                }
                else
                {
                    var employee = await dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).Where(e => e.AmiyaPositionInfo.Name == "客服主管" && e.Valid == true).ToListAsync();
                    foreach (var k in employee)
                    {
                        var email = k.Email;
                        if (email == "0")
                            continue;
                        sendMails.sendMail("smtp.qq.com", "3023330386@qq.com", "kivbmbikthsmdejf", "阿美雅", "3023330386@qq.com", email, "客户下单提示", sub);
                    }
                }
                return appointmentInfo.Id;
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }



        /// <summary>
        ///获取预约列表（小程序）
        /// </summary>
        /// <param name="status"> 1:计划中,2:已取消</param>
        /// <returns></returns>
        public async Task<FxPageInfo<WxAppointmentInfoDto>> GetListOfWxAsync(int pageNum, int pageSize, int status, string itemName, string customerId)
        {
            try
            {
                var appointmentInfos = from d in dalAppointmentInfo.GetAll()
                                        .Include(e => e.HospitalInfo)
                                       where d.CustomerId == customerId
                                       && (itemName == null || d.ItemInfoName.Contains(itemName))
                                       select d;

                if (status == 1)
                {
                    appointmentInfos = from d in appointmentInfos
                                       where d.Status == (byte)AppointmentStatusType.Process
                                       select d;
                }
                if (status == 2)
                {
                    appointmentInfos = from d in appointmentInfos
                                       where d.Status == (byte)AppointmentStatusType.Cancel
                                       select d;
                }
                

                var q = from d in appointmentInfos.OrderBy(x => x.AppointmentDate)
                        select new WxAppointmentInfoDto
                        {
                            Id = d.Id,
                            AppointmentDate = d.AppointmentDate,
                            Week = d.Week,
                            Time = d.Time,
                            Status = d.Status,
                            CreateDate = d.CreateDate,
                            SubmitDate = d.SubmitDate,
                            Phone = d.Phone,
                            Remark = d.Remark,
                            ItemInfoName = d.ItemInfoName,

                            HospitalInfo = new AppointmentHospitalDto
                            {
                                HospitalId = d.HospitalId,
                                HospitalName = d.HospitalInfo.Name,
                                Longitude = d.HospitalInfo.Longitude,
                                Latitude = d.HospitalInfo.Latitude,
                                HospitalPhone = d.HospitalInfo.Phone,
                                ThumbPicture = d.HospitalInfo.ThumbPicUrl
                            }
                        };
                FxPageInfo<WxAppointmentInfoDto> appointmentPageInfo = new FxPageInfo<WxAppointmentInfoDto>();
                appointmentPageInfo.TotalCount = await q.CountAsync();
                appointmentPageInfo.List = await q.OrderByDescending(z => z.AppointmentDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
                return appointmentPageInfo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }




        /// <summary>
        /// 根据预约编号获取预约信息（小程序）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<WxAppointmentInfoDto> GetByIdOfWxAsync(int id)
        {
            try
            {
                var appointment = await dalAppointmentInfo.GetAll()
                    .Include(e => e.HospitalInfo)
                    .SingleOrDefaultAsync(e => e.Id == id);

                if (appointment == null)
                    throw new Exception("预约编号错误");

                WxAppointmentInfoDto appointmentInfo = new WxAppointmentInfoDto()
                {
                    Id = appointment.Id,
                    AppointmentDate = appointment.AppointmentDate,
                    Week = appointment.Week,
                    Time = appointment.Time,
                    Status = appointment.Status,
                    CreateDate = appointment.CreateDate,
                    SubmitDate = appointment.SubmitDate,
                    Phone = appointment.Phone,
                    Remark = appointment.Remark,
                    ItemInfoName = appointment.ItemInfoName,

                    HospitalInfo = new AppointmentHospitalDto
                    {
                        HospitalId = appointment.HospitalId,
                        HospitalName = appointment.HospitalInfo.Name,
                        ThumbPicture = appointment.HospitalInfo.ThumbPicUrl,
                        Longitude = appointment.HospitalInfo.Longitude,
                        Latitude = appointment.HospitalInfo.Latitude,
                        HospitalPhone = appointment.HospitalInfo.Phone,
                        Address = appointment.HospitalInfo.Address
                    }
                };

                return appointmentInfo;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        /// <summary>
        /// 取消预约
        /// </summary>
        /// <param name="id">预约编号</param>
        /// <returns></returns>
        public async Task CancelAsync(int id)
        {
            try
            {
                var appointment = await dalAppointmentInfo.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (appointment == null)
                    throw new Exception("预约编号错误");

                if (appointment.Status == (byte)AppointmentStatusType.Success)
                    throw new Exception("预约已完成，不可取消");

                appointment.Status = (byte)AppointmentStatusType.Cancel;
                await dalAppointmentInfo.UpdateAsync(appointment, false);


                //var surplusQuantity = await dalHospitalSurplusAppointment.GetAll()
                //    .SingleOrDefaultAsync(e=>e.HospitalId==appointment.HospitalId&&e.Date.Date==appointment.AppointmentDate.Date);

                //if (appointment.Time == "上午")
                //    surplusQuantity.ForenoonSurplusQuantity = surplusQuantity.ForenoonSurplusQuantity + 1;
                //if(appointment.Time == "下午")
                //    surplusQuantity.AfternoonSurplusQuantity = surplusQuantity.AfternoonSurplusQuantity + 1;
                //await dalHospitalSurplusAppointment.UpdateAsync(surplusQuantity,true);
                await unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获取预约状态列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<BaseKeyValueDto>> GetAppointmentStatusListAsync()
        {
            var consumptionVoucherTypes = Enum.GetValues(typeof(AppointmentStatusType));

            List<BaseKeyValueDto> consumptionVoucherTypeList = new List<BaseKeyValueDto>();
            foreach (var item in consumptionVoucherTypes)
            {
                BaseKeyValueDto baseKeyValueDto = new BaseKeyValueDto();
                baseKeyValueDto.Key = Convert.ToInt32(item).ToString();
                baseKeyValueDto.Value = ServiceClass.GetAppointmentStatusTypeText(Convert.ToInt32(item));
                consumptionVoucherTypeList.Add(baseKeyValueDto);
            }
            return consumptionVoucherTypeList;
        }
        /// <summary>
        /// 派单至对应医院
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task UpdateHospitalId(int id, int hospitalId)
        {
            try
            {
                var appointment = await dalAppointmentInfo.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (appointment == null)
                    throw new Exception("预约编号错误");
                if (appointment.Status == (byte)AppointmentStatus.SendToHospital)
                    throw new Exception("预约已派单至医院，不可继续派单");
                if (appointment.Status == (byte)AppointmentStatus.Finish)
                    throw new Exception("预约已完成，不可继续派单");

                appointment.Status = (byte)AppointmentStatus.SendToHospital;
                appointment.HospitalId = hospitalId;
                await dalAppointmentInfo.UpdateAsync(appointment, false);

                await unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 确认完成
        /// </summary>
        /// <param name="id">预约编号</param>
        /// <returns></returns>
        public async Task ConfirmFinishAsync(int id)
        {
            try
            {
                var appointment = await dalAppointmentInfo.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (appointment == null)
                    throw new Exception("预约编号错误");
                if (appointment.Status == (byte)AppointmentStatus.WaitAccomplish)
                    throw new Exception("请耐心等待阿美雅和机构确认");
                if (appointment.Status == (byte)AppointmentStatus.Finish)
                    throw new Exception("预约已完成，不可继续点击");
                if (appointment.Status == (byte)AppointmentStatus.Cancel)
                    throw new Exception("预约已取消，不可继续完成");
                if (appointment.AppointmentDate.Date > DateTime.Now.Date)
                    throw new Exception(appointment.AppointmentDate.ToString("yyy-MM-dd") + "到院后方可确认完成");

                appointment.Status = (byte)AppointmentStatus.Finish;
                await dalAppointmentInfo.UpdateAsync(appointment, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 修改预约信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task UpdateAppointmentInfo(UpdateAppointmentInfoDto input)
        {
            var appointment = await dalAppointmentInfo.GetAll().SingleOrDefaultAsync(e => e.Id == input.Id);
            if (appointment == null)
                throw new Exception("预约编号错误");
            if (appointment.Status == (byte)AppointmentStatus.SendToHospital)
                throw new Exception("预约已派单至医院，不可继续修改");

            if (appointment.Status == (byte)AppointmentStatus.Finish)
                throw new Exception("预约已完成，不可继续修改");

            appointment.AppointmentDate = input.AppointmentDate;
            appointment.Week = input.Week;
            appointment.Time = input.Time;
            appointment.ItemInfoName = input.ItemName;
            appointment.Phone = input.Phone;
            await dalAppointmentInfo.UpdateAsync(appointment, false);

            await unitOfWork.SaveChangesAsync();
        }


        public async Task CancelOverTimeAsync()
        {
            DateTime date = DateTime.Now.Date;
            var appointment = await dalAppointmentInfo.GetAll()
                .Where(e => e.Status == (byte)AppointmentStatus.WaitAccomplish && e.AppointmentDate.Date < date)
                .ToListAsync();

            foreach (var item in appointment)
            {
                item.Status = (byte)AppointmentStatus.Cancel;
                await dalAppointmentInfo.UpdateAsync(item, true);
            }


        }
        private async Task<CallCenterConfigDto> GetCallCenterConfig()
        {
            var config = await dalConfig.GetAll().SingleOrDefaultAsync();
            return JsonConvert.DeserializeObject<WxAppConfigDto>(config.ConfigJson).CallCenterConfig;
        }



        /// <summary>
        /// 根据加密手机号获取预约列表
        /// </summary>
        /// <param name="encryptPhone"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<AppointmentInfoDto>> GetListByEncryptPhoneAsync(string encryptPhone, int pageNum, int pageSize)
        {
            try
            {
                var config = await GetCallCenterConfig();
                string phone = ServiceClass.Decrypto(encryptPhone, config.PhoneEncryptKey);

                var appointment = from d in dalAppointmentInfo.GetAll()
                                  where d.Phone == phone
                                  select new AppointmentInfoDto
                                  {
                                      Id = d.Id,
                                      AppointmentDate = d.AppointmentDate,
                                      Week = d.Week,
                                      Time = d.Time,
                                      Status = d.Status,
                                      StatusText = GetAppointmentStatusText(d.Status),
                                      ItemName = d.ItemInfoName,
                                      EncryptPhone = ServiceClass.Encrypt(d.Phone, config.PhoneEncryptKey),
                                      Phone = config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                                      CreateDate = d.CreateDate,
                                      SubmitDate = d.SubmitDate,
                                      HospitalId = d.HospitalId,
                                      HospitalName = d.HospitalInfo.Name,
                                      Remark = d.Remark,
                                  };

                FxPageInfo<AppointmentInfoDto> appointmentPageInfo = new FxPageInfo<AppointmentInfoDto>();
                appointmentPageInfo.TotalCount = await appointment.CountAsync();
                appointmentPageInfo.List = await appointment.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
                return appointmentPageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 修改预约备注
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task UpdateAppointmentRemarkInfo(UpdateAppointmentRemarkDto input)
        {
            var appointment = await dalAppointmentInfo.GetAll().SingleOrDefaultAsync(e => e.Id == input.Id);
            if (appointment == null)
                throw new Exception("预约编号错误");

            appointment.Remark = input.Remark;
            await dalAppointmentInfo.UpdateAsync(appointment, false);

            await unitOfWork.SaveChangesAsync();
        }
        /// <summary>
        /// 修改预约状态
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        public async Task UpdateAppointmentStatusAsync(UpdateAppointmentStatus update)
        {
            var appointment = dalAppointmentInfo.GetAll().Where(e => e.Id == update.Id).FirstOrDefault();
            if (appointment == null) throw new Exception("预约编号错误");
            appointment.Status = (byte)update.Status;
            await dalAppointmentInfo.UpdateAsync(appointment,true);
        }
        /// <summary>
        /// 获取最近一次的预约医院
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<AppointmentSimpleInfoDto> GetMostRecentlyAppointmentAsync(string customerId) {
            return await dalAppointmentInfo.GetAll().Where(e => e.CustomerId == customerId).Include(e => e.HospitalInfo).OrderByDescending(e=>e.CreateDate).Select(e => new AppointmentSimpleInfoDto
            {
                HospitalName=e.HospitalInfo.Name
            }).FirstOrDefaultAsync();
        }

        #region 报表相关

        public async Task<List<AppointmentOperationConditionDto>> GetAppointmentOperationConditionAsync(DateTime? startDate, DateTime? endDate)
        {
            var orders = from d in dalAppointmentInfo.GetAll()
                         select d;

            if (startDate != null && endDate != null)
            {
                DateTime startrq = ((DateTime)startDate);
                DateTime endrq = ((DateTime)endDate).Date.AddDays(1);
                orders = from d in orders
                         where d.CreateDate >= startrq && d.CreateDate < endrq
                         select d;
            }
            var orderList = orders.ToList();
            return orderList.GroupBy(x => x.CreateDate.Date).Select(x => new AppointmentOperationConditionDto { Date = x.Key.ToString("yyyy-MM-dd"), AppointmentNum = x.ToList().Count }).ToList();
        }

        public async Task<List<AppointmentReportDto>> GetAppointmentReportAsync(DateTime? startDate, DateTime? endDate, int status, bool isHidePhone)
        {
            try
            {

                DateTime startrq = ((DateTime)startDate).Date;
                DateTime endrq = ((DateTime)endDate).Date.AddDays(1);

                var appointment = from d in dalAppointmentInfo.GetAll()
                                  where d.AppointmentDate.Date >= startrq && d.AppointmentDate.Date < endrq
                                  select d;
                if (status != 0)
                {
                    appointment = from d in appointment
                                  where d.Status == status
                                  select d;
                }

                var appointmentInfo = from d in appointment
                                      select new AppointmentReportDto
                                      {
                                          AppointmentDate = d.AppointmentDate,
                                          Week = d.Week,
                                          Time = d.Time,
                                          StatusText = GetAppointmentStatusText(d.Status),
                                          ItemName = d.ItemInfoName,
                                          Phone =isHidePhone == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                                          HospitalName = d.HospitalInfo.Name,
                                          Remark = d.Remark
                                      };

                return appointmentInfo.OrderByDescending(z => z.AppointmentDate).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<List<AppointmentReportDto>> GetHospitalAppointmentReportAsync(DateTime? startDate, DateTime? endDate, string hosiptalName, bool isHidePhone)
        {
            try
            {

                DateTime startrq = ((DateTime)startDate).Date;
                DateTime endrq = ((DateTime)endDate).Date.AddDays(1);

                var appointment = from d in dalAppointmentInfo.GetAll()
                                  where d.AppointmentDate.Date >= startrq && d.AppointmentDate.Date < endrq
                                  select d;
                if (!string.IsNullOrEmpty(hosiptalName))
                {
                    appointment = from d in appointment
                                  where d.HospitalInfo.Name.Contains(hosiptalName)
                                  select d;
                }

                var config = await GetCallCenterConfig();
                var appointmentInfo = from d in appointment
                                      select new AppointmentReportDto
                                      {
                                          AppointmentDate = d.AppointmentDate,
                                          Week = d.Week,
                                          Time = d.Time,
                                          StatusText = GetAppointmentStatusText(d.Status),
                                          ItemName = d.ItemInfoName,
                                          Phone = config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                                          HospitalName = d.HospitalInfo.Name,
                                          Remark = d.Remark
                                      };

                return appointmentInfo.OrderBy(x => x.HospitalName).ThenBy(z => z.AppointmentDate).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        
        #endregion
    }
}
