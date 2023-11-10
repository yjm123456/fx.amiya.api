using Fx.Amiya.Dto.SendOrderInfo;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Fx.Amiya.DbModels.Model;
using Fx.Infrastructure.DataAccess;
using Fx.Amiya.Dto.WxAppConfig;
using Newtonsoft.Json;
using Fx.Infrastructure.Utils;
using Fx.Common;
using Fx.Amiya.Dto.OrderReport;
using Fx.Amiya.Dto.HospitalCustomerInfo;

namespace Fx.Amiya.Service
{
    public class SendOrderInfoService : ISendOrderInfoService
    {
        private IDalSendOrderInfo dalSendOrderInfo;
        private IDalBindCustomerService dalBindCustomerService;
        private IDalOrderInfo dalOrderInfo;
        private IHospitalCustomerInfoService hospitalCustomerInfoService;
        private IDalItemInfo dalItemInfo;
        private IDalHospitalSurplusAppointment dalHospitalSurplusAppointment;
        private IDalHospitalPartakeItem dalHospitalPartakeItem;
        private IUnitOfWork unitOfWork;
        private IAmiyaEmployeeService _AmiyaEmployee;
        private IDalConfig dalConfig;
        private IDalSendOrderUpdateRecord dalSendOrderUpdateRecord;
        private IDalHospitalCheckPhoneRecord dalHospitalCheckPhoneRecord;
        private IDalSendOrderMessageBoard dalSendOrderMessageBoard;
        private IDalHospitalInfo _dalHospitalInfo;
        public SendOrderInfoService(IDalSendOrderInfo dalSendOrderInfo,
            IDalBindCustomerService dalBindCustomerService,
            IDalOrderInfo dalOrderInfo,
            IDalItemInfo dalItemInfo,
            IHospitalCustomerInfoService hospitalCustomerInfoService,
            IDalHospitalSurplusAppointment dalHospitalSurplusAppointment,
            IDalHospitalPartakeItem dalHospitalPartakeItem,
            IUnitOfWork unitOfWork,
            IAmiyaEmployeeService AmiyaEmployee,
            IDalConfig dalConfig,
            IDalSendOrderUpdateRecord dalSendOrderUpdateRecord,
            IDalHospitalCheckPhoneRecord dalHospitalCheckPhoneRecord,
            IDalSendOrderMessageBoard dalSendOrderMessageBoard, IDalHospitalInfo dalHospitalInfo)
        {
            this.dalSendOrderInfo = dalSendOrderInfo;
            this.dalBindCustomerService = dalBindCustomerService;
            this.dalOrderInfo = dalOrderInfo;
            this.dalItemInfo = dalItemInfo;
            this.dalHospitalSurplusAppointment = dalHospitalSurplusAppointment;
            this.dalHospitalPartakeItem = dalHospitalPartakeItem;
            this.unitOfWork = unitOfWork;
            _AmiyaEmployee = AmiyaEmployee;
            this.dalConfig = dalConfig;
            this.dalSendOrderUpdateRecord = dalSendOrderUpdateRecord;
            this.hospitalCustomerInfoService = hospitalCustomerInfoService;
            this.dalHospitalCheckPhoneRecord = dalHospitalCheckPhoneRecord;
            this.dalSendOrderMessageBoard = dalSendOrderMessageBoard;
            _dalHospitalInfo = dalHospitalInfo;
        }

        private async Task<CallCenterConfigDto> GetCallCenterConfig()
        {
            var config = await dalConfig.GetAll().SingleOrDefaultAsync();
            return JsonConvert.DeserializeObject<WxAppConfigDto>(config.ConfigJson).CallCenterConfig;
        }




        /// <summary>
        /// 获取派单信息列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="employeeId">-1查全部</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns> 
        public async Task<FxPageInfo<SendOrderInfoDto>> GetListWithPageAsync(string keyword, int employeeId, DateTime? startDate, DateTime? endDate, byte? appType, string statusCode, int? hospitalId, int pageNum, int pageSize)
        {
            //var employee = await _AmiyaEmployee.GetByIdAsync(employeeId);
            //if (employee.Id == 0)
            //{
            //    throw new Exception("未找到派单人员信息！");
            //}
            var q = from d in dalSendOrderInfo.GetAll()
                    where (string.IsNullOrWhiteSpace(keyword) || d.OrderId == keyword || d.OrderInfo.Phone.Contains(keyword))
                    && (appType == null || d.OrderInfo.AppType == appType)
                    && (hospitalId == 0 || d.HospitalId == hospitalId)
                    && (employeeId == -1 || d.SendBy == employeeId)
                    && (string.IsNullOrWhiteSpace(statusCode) || d.OrderInfo.StatusCode == statusCode)
                    select d;

            if (startDate != null && endDate != null)
            {
                DateTime startrq = (DateTime)startDate;
                DateTime endrq = ((DateTime)endDate).AddDays(1);

                q = from d in q
                    where (d.SendDate >= startrq && d.SendDate < endrq)
                    || (d.AppointmentDate >= startrq && d.AppointmentDate < endrq)
                    select d;
            }




            var config = await GetCallCenterConfig();
            var sendOrder = from d in q
                            join p in dalHospitalCheckPhoneRecord.GetAll().Where(e => e.OrderPlatformType == (byte)CheckPhoneRecordOrderType.TradeOrder)
                            on d.OrderId equals p.OrderId into pd
                            from p in pd.DefaultIfEmpty()
                            select new SendOrderInfoDto
                            {
                                Id = d.Id,
                                OrderId = d.OrderId,
                                ThumbPicUrl = d.OrderInfo.ThumbPicUrl,
                                HospitalId = d.HospitalId,
                                HospitalName = d.HospitalInfo.Name,
                                SendBy = d.SendBy,
                                SendName = d.AmiyaEmployee.Name,
                                SendDate = d.SendDate,
                                IsUncertainDate = d.IsUncertainDate,
                                AppointmentDate = d.AppointmentDate,
                                Time = d.IsUncertainDate == false ? timeTypeDictionary[(byte)d.TimeType] : "未明确时间",
                                TimeType = d.TimeType,
                                PurchaseSinglePrice = d.PurchaseSinglePrice,
                                PurchaseNum = d.PurchaseNum,
                                GoodsId = d.OrderInfo.GoodsId,
                                GoodsName = d.OrderInfo.GoodsName,
                                ActualPayment = d.OrderInfo.ActualPayment,
                                EncryptPhone = ServiceClass.Encrypt(d.OrderInfo.Phone, config.PhoneEncryptKey),
                                Phone = config.EnablePhoneEncrypt == true ? ServiceClass.GetIncompletePhone(d.OrderInfo.Phone) : d.OrderInfo.Phone,
                                IsHospitalCheckPhone = p.HospitalId == d.HospitalId,
                                StatusCode = d.OrderInfo.StatusCode,
                                StatusText = ServiceClass.GetOrderStatusText(d.OrderInfo.StatusCode),
                                AppType = d.OrderInfo.AppType,
                                AppTypeText = ServiceClass.GetAppTypeText(d.OrderInfo.AppType),
                                FirstMessageContent = d.SendOrderMessageBoardList.OrderBy(e => e.Date).FirstOrDefault().Content,
                                Description = d.OrderInfo.Description,
                                Standard = d.OrderInfo.Standard,
                                Parts = d.OrderInfo.Parts
                            };

            FxPageInfo<SendOrderInfoDto> sendOrderPageInfo = new FxPageInfo<SendOrderInfoDto>();
            sendOrderPageInfo.TotalCount = await sendOrder.CountAsync();
            sendOrderPageInfo.List = await sendOrder.OrderByDescending(e => e.SendDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            //foreach (var item in sendOrderPageInfo.List)
            //{
            //    var order = await dalOrderInfo.GetAll().SingleOrDefaultAsync(e => e.Id == item.OrderId);
            //    var itemInfo = await dalItemInfo.GetAll().SingleOrDefaultAsync(e => e.OtherAppItemId == order.GoodsId);
            //    if (itemInfo != null)
            //    {
            //        item.Description = itemInfo.Description;
            //        item.Standard = itemInfo.Standard;
            //        item.Parts = itemInfo.Parts;
            //    }

            //}
            return sendOrderPageInfo;
        }


        /// <summary>
        /// 获取未派单订单列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="employeeId">-1查全部</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<UnSendOrderInfoDto>> GetUnSendOrderListWithPageAsync(string keyword, int employeeId, byte? appType, string statusCode, int pageNum, int pageSize)
        {
            var config = await GetCallCenterConfig();

            var orders = from o in dalOrderInfo.GetAll()
                         where o.IsAppointment == false && o.OrderType == (byte)OrderType.VirtualOrder
                         select o;


            if (string.IsNullOrWhiteSpace(statusCode))
            {
                orders = from o in orders
                         where o.StatusCode == OrderStatusCode.WAIT_SELLER_SEND_GOODS || o.StatusCode == OrderStatusCode.WAIT_BUYER_CONFIRM_GOODS || o.StatusCode == OrderStatusCode.TRADE_BUYER_PAID || o.StatusCode == OrderStatusCode.SEEK_ADVICE || o.StatusCode == OrderStatusCode.BARGAIN_MONEY
                         select o;
            }
            else
            {
                orders = from o in orders
                         where o.StatusCode == statusCode
                         select o;
            }
            var unSendOrder = from o in orders
                              join b in dalBindCustomerService.GetAll() on o.Phone equals b.BuyerPhone
                              //join i in dalItemInfo.GetAll() on o.GoodsId equals i.OtherAppItemId into oi
                              //from i in oi.DefaultIfEmpty()
                              where o.SendOrderInfoList.Count(e => e.OrderId == o.Id) == 0
                              && (keyword == null || o.Id == keyword || o.Phone.Contains(keyword) || o.GoodsName.Contains(keyword) || o.AppointmentHospital.Contains(keyword))
                              && (appType == null || o.AppType == appType)
                              && (employeeId == -1 || b.CustomerServiceId == employeeId)
                              orderby b.CreateDate descending
                              select new UnSendOrderInfoDto
                              {
                                  OrderId = o.Id,
                                  GoodsId = o.GoodsId,
                                  GoodsName = o.GoodsName,
                                  ThumbPicUrl = o.ThumbPicUrl,
                                  Phone = config.EnablePhoneEncrypt == true ? ServiceClass.GetIncompletePhone(o.Phone) : o.Phone,
                                  EncryptPhone = ServiceClass.Encrypt(o.Phone, config.PhoneEncryptKey),
                                  ActualPayment = o.ActualPayment,
                                  CreateDate = o.CreateDate,
                                  AppointmentHospital = o.AppointmentHospital,
                                  StatusCode = o.StatusCode,
                                  StatusText = ServiceClass.GetOrderStatusText(o.StatusCode),
                                  AppType = o.AppType,
                                  AppTypeText = ServiceClass.GetAppTypeText(o.AppType),
                                  Description = o.Description,
                                  Standard = o.Standard,
                                  Parts = o.Parts
                              };

            FxPageInfo<UnSendOrderInfoDto> pageInfo = new FxPageInfo<UnSendOrderInfoDto>();
            pageInfo.TotalCount = await unSendOrder.CountAsync();
            pageInfo.List = await unSendOrder.OrderByDescending(x => x.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();

            return pageInfo;
        }



        /// <summary>
        /// 添加派单信息
        /// </summary>
        /// <param name="addDto"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task AddAsync(AddSendOrderInfoDto addDto, int employeeId)
        {
            try
            {
                Dictionary<int, bool> SendHospitalId = new Dictionary<int, bool>();
                SendHospitalId.Add(addDto.HospitalId, true);
                //主医院派单
                await this.SendOrderListAsync(addDto, SendHospitalId, employeeId);
                if (addDto.OtherHospitalId.Count > 0)
                {
                    //次医院派单
                    Dictionary<int, bool> OtherSendHospitalId = new Dictionary<int, bool>();
                    foreach (var x in addDto.OtherHospitalId)
                    {
                        OtherSendHospitalId.Add(x, false);
                    }
                    await this.SendOrderListAsync(addDto, OtherSendHospitalId, employeeId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        private async Task SendOrderListAsync(AddSendOrderInfoDto addDto, Dictionary<int, bool> HospitalIdList, int employeeId)
        {
            try
            {
                unitOfWork.BeginTransaction();
                foreach (var x in HospitalIdList)
                {
                    DateTime date = DateTime.Now;

                    SendOrderInfo sendOrderInfo = new SendOrderInfo();
                    sendOrderInfo.OrderId = addDto.OrderId;
                    sendOrderInfo.HospitalId = x.Key;
                    sendOrderInfo.SendBy = employeeId;
                    sendOrderInfo.PurchaseNum = addDto.PurchaseNum;
                    sendOrderInfo.PurchaseSinglePrice = addDto.PurchaseSinglePrice;
                    sendOrderInfo.SendDate = date;
                    sendOrderInfo.IsUncertainDate = addDto.IsUncertainDate;
                    sendOrderInfo.IsMainHospital = x.Value;
                    sendOrderInfo.TimeType = addDto.TimeType;
                    if (!addDto.IsUncertainDate)
                    {
                        sendOrderInfo.AppointmentDate = addDto.AppointmentDate;
                    }

                    await dalSendOrderInfo.AddAsync(sendOrderInfo, true);

                    if (!string.IsNullOrWhiteSpace(addDto.Content))
                    {
                        SendOrderMessageBoard sendOrderMessageBoard = new SendOrderMessageBoard();
                        sendOrderMessageBoard.Date = DateTime.Now;
                        sendOrderMessageBoard.Type = (byte)SendOrderMessageBoardType.Amiya;
                        sendOrderMessageBoard.SendOrderInfoId = sendOrderInfo.Id;
                        sendOrderMessageBoard.HospitalId = sendOrderInfo.HospitalId;
                        sendOrderMessageBoard.AmiyaEmployeeId = employeeId;
                        sendOrderMessageBoard.Content = addDto.Content;
                        await dalSendOrderMessageBoard.AddAsync(sendOrderMessageBoard, true);
                    }

                    //获取医院客户列表
                    var q = from d in dalSendOrderInfo.GetAll().Include(x => x.OrderInfo)
                            where (d.OrderId == addDto.OrderId)
                            select d;
                    var order = await q.FirstOrDefaultAsync();
                    var customer = await hospitalCustomerInfoService.GetByHospitalIdAndPhoneAsync(x.Key, order.OrderInfo.Phone);
                    //操作医院客户表
                    if (!string.IsNullOrEmpty(customer.Id))
                    {
                        UpdateSendHospitalCustomerInfoDto updateSendHospitalCustomerInfoDto = new UpdateSendHospitalCustomerInfoDto();
                        updateSendHospitalCustomerInfoDto.Id = customer.Id;
                        updateSendHospitalCustomerInfoDto.NewGoodsDemand = order.OrderInfo.GoodsName;
                        updateSendHospitalCustomerInfoDto.SendAmount += 1;
                        await hospitalCustomerInfoService.InsertSendAmountAsync(updateSendHospitalCustomerInfoDto);
                    }
                    else
                    {
                        AddSendHospitalCustomerInfoDto addSendHospitalCustomerInfoDto = new AddSendHospitalCustomerInfoDto();
                        addSendHospitalCustomerInfoDto.NewGoodsDemand = order.OrderInfo.GoodsName;
                        addSendHospitalCustomerInfoDto.SendAmount = 1;
                        addSendHospitalCustomerInfoDto.CustomerPhone = order.OrderInfo.Phone;
                        addSendHospitalCustomerInfoDto.hospitalId = x.Key;
                        addSendHospitalCustomerInfoDto.DealAmount = 0;
                        await hospitalCustomerInfoService.AddAsync(addSendHospitalCustomerInfoDto);

                    }
                }
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message.ToString());
            }
        }


        /// <summary>
        /// 修改剩余可预约数量
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="appointmentDate"></param>
        /// <param name="time">上午/下午</param>
        /// <returns></returns>
        private async Task UpdateSurplusQuantityAsync(int hospitalId, int itemId, DateTime appointmentDate, string time)
        {

            var surplusQuantity = await dalHospitalSurplusAppointment.GetAll()
                .SingleOrDefaultAsync(e => e.HospitalId == hospitalId && e.ItemId == itemId && e.Date.Date == appointmentDate.Date);
            if (surplusQuantity == null)
            {
                var appointmentQuantitys = await dalHospitalPartakeItem.GetAll().SingleOrDefaultAsync(e => e.HospitalId == hospitalId && e.ItemId == itemId);
                HospitalSurplusAppointment hospitalSurplusAppointment = new HospitalSurplusAppointment();
                hospitalSurplusAppointment.HospitalId = hospitalId;
                hospitalSurplusAppointment.ItemId = itemId;
                hospitalSurplusAppointment.ForenoonSurplusQuantity = appointmentQuantitys.ForenoonCanAppointmentQuantity;
                hospitalSurplusAppointment.AfternoonSurplusQuantity = appointmentQuantitys.AfternoonCanAppointmentQuantity;
                hospitalSurplusAppointment.Date = appointmentDate;
                hospitalSurplusAppointment.Version = 0;
                await dalHospitalSurplusAppointment.AddAsync(hospitalSurplusAppointment, true);
                await UpdateSurplusQuantityAsync(hospitalId, itemId, appointmentDate, time);
            }
            else
            {
                if (time == "上午")
                {
                    if (surplusQuantity.ForenoonSurplusQuantity == 0)
                        throw new Exception("预约人数已满，请重新选择预约日期");
                    surplusQuantity.ForenoonSurplusQuantity = surplusQuantity.ForenoonSurplusQuantity - 1;
                }
                else
                {
                    if (surplusQuantity.AfternoonSurplusQuantity == 0)
                        throw new Exception("预约人数已满，请重新选择预约日期");
                    surplusQuantity.AfternoonSurplusQuantity = surplusQuantity.AfternoonSurplusQuantity - 1;
                }
                surplusQuantity.Version = surplusQuantity.Version + 1;
                await dalHospitalSurplusAppointment.UpdateAsync(surplusQuantity, true);
            }
        }




        /// <summary>
        /// 根据编号获取简单的派单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SendOrderInfoSimpleDto> GetSimpleByIdAsync(int id)
        {
            var sendOrderInfo = await dalSendOrderInfo.GetAll()
                .Include(e => e.OrderInfo)
                .Include(e => e.HospitalInfo).SingleOrDefaultAsync(e => e.Id == id);
            if (sendOrderInfo == null)
                throw new Exception();
            SendOrderInfoSimpleDto sendOrderInfoDto = new SendOrderInfoSimpleDto();
            sendOrderInfoDto.Id = sendOrderInfo.Id;
            sendOrderInfoDto.PurchaseSiglePrice = sendOrderInfo.PurchaseSinglePrice;
            sendOrderInfoDto.PurchaseNum = sendOrderInfo.PurchaseNum;
            sendOrderInfoDto.OrderId = sendOrderInfo.OrderId;
            sendOrderInfoDto.HospitalId = sendOrderInfo.HospitalId;
            sendOrderInfoDto.HospitalName = sendOrderInfo.HospitalInfo.Name;
            sendOrderInfoDto.IsUncertainDate = sendOrderInfo.IsUncertainDate;
            sendOrderInfoDto.AppointmentDate = sendOrderInfo.AppointmentDate;
            sendOrderInfoDto.Time = sendOrderInfo.IsUncertainDate == false ? timeTypeDictionary[(byte)sendOrderInfo.TimeType] : "未明确时间";
            sendOrderInfoDto.TimeType = sendOrderInfo.TimeType;
            sendOrderInfoDto.GoodsId = sendOrderInfo.OrderInfo.GoodsId;
            sendOrderInfoDto.GoodsName = sendOrderInfo.OrderInfo.GoodsName;
            sendOrderInfoDto.AppType = sendOrderInfo.OrderInfo.AppType;
            sendOrderInfoDto.AppTypeText = ServiceClass.GetAppTypeText(sendOrderInfo.OrderInfo.AppType);
            return sendOrderInfoDto;
        }


        /// <summary>
        /// 预约到院时间类型
        /// </summary>
        Dictionary<byte, string> timeTypeDictionary = new Dictionary<byte, string>()
        {
            { 1,"上午"},
            { 2,"下午"}
        };

        /// <summary>
        /// 修改派单
        /// </summary>
        /// <param name="updateDto"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateSendOrderInfoDto updateDto, int employeeId)
        {
            try
            {
                unitOfWork.BeginTransaction();

                var sendOrderInfo = await dalSendOrderInfo.GetAll().Include(e => e.OrderInfo).SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (sendOrderInfo == null)
                    throw new Exception("派单编号错误");

                if (sendOrderInfo.OrderInfo.AppType == (byte)AppType.Tmall && sendOrderInfo.OrderInfo.StatusCode == OrderStatusCode.TRADE_FINISHED)
                    throw new Exception("该订单已交易完成，无法改派医院");

                if (sendOrderInfo.HospitalId != updateDto.HospitalId)
                {
                    SendOrderUpdateRecord sendOrderUpdateRecord = new SendOrderUpdateRecord();
                    sendOrderUpdateRecord.OrderId = sendOrderInfo.OrderId;
                    sendOrderUpdateRecord.OldHospitalId = sendOrderInfo.HospitalId;
                    sendOrderUpdateRecord.NewHospitalId = updateDto.HospitalId;
                    sendOrderUpdateRecord.UpdateBy = employeeId;
                    sendOrderUpdateRecord.UpdateDate = DateTime.Now;
                    await dalSendOrderUpdateRecord.AddAsync(sendOrderUpdateRecord, true);
                }


                sendOrderInfo.HospitalId = updateDto.HospitalId;
                sendOrderInfo.SendBy = employeeId;
                sendOrderInfo.SendDate = DateTime.Now;
                sendOrderInfo.PurchaseNum = updateDto.PurchaseNum;
                sendOrderInfo.PurchaseSinglePrice = updateDto.PurchaseSinglePrice;
                sendOrderInfo.IsUncertainDate = updateDto.IsUncertainDate;
                if (updateDto.IsUncertainDate == true)
                {
                    sendOrderInfo.AppointmentDate = null;
                    sendOrderInfo.TimeType = null;
                }
                else
                {
                    sendOrderInfo.AppointmentDate = updateDto.AppointmentDate;
                    sendOrderInfo.TimeType = updateDto.TimeType;
                }

                await dalSendOrderInfo.UpdateAsync(sendOrderInfo, true);


                if (!string.IsNullOrWhiteSpace(updateDto.Content))
                {
                    //添加留言内容
                    SendOrderMessageBoard sendOrderMessageBoard = new SendOrderMessageBoard();
                    sendOrderMessageBoard.Date = DateTime.Now;
                    sendOrderMessageBoard.Type = (byte)SendOrderMessageBoardType.Amiya;
                    sendOrderMessageBoard.SendOrderInfoId = sendOrderInfo.Id;
                    sendOrderMessageBoard.HospitalId = sendOrderInfo.HospitalId;
                    sendOrderMessageBoard.AmiyaEmployeeId = employeeId;
                    sendOrderMessageBoard.Content = updateDto.Content;
                    await dalSendOrderMessageBoard.AddAsync(sendOrderMessageBoard, true);
                }

                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message.ToString());
            }
        }





        /// <summary>
        /// 根据医院编号获取派单列表
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="keyword"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<SendOrderInfoDto>> GetListByHospitalIdAsync(int hospitalId, string keyword, DateTime? startDate, DateTime? endDate, int pageNum, int pageSize, bool IsHidePhone)
        {
            var q = from d in dalSendOrderInfo.GetAll()
                    where d.HospitalId == hospitalId
                     && (keyword == null || d.OrderId == keyword || d.OrderInfo.GoodsName.Contains(keyword) || d.OrderInfo.Phone.Contains(keyword))
                    select d;

            if (startDate != null && endDate != null)
            {
                DateTime startrq = ((DateTime)startDate);
                DateTime endrq = ((DateTime)endDate).AddDays(1);

                q = from d in q
                    where (d.SendDate >= startrq.Date && d.SendDate < endrq.Date)
                    select d;
            }
            var config = await GetCallCenterConfig();
            if (IsHidePhone == true)
            {
                config.HidePhoneNumber = false;
            }
            var sendOrder = from d in q
                            join p in dalHospitalCheckPhoneRecord.GetAll().Where(e => e.HospitalId == hospitalId && e.OrderPlatformType == (byte)CheckPhoneRecordOrderType.TradeOrder)
                            on d.OrderId equals p.OrderId into pd
                            from p in pd.DefaultIfEmpty()
                            select new SendOrderInfoDto
                            {
                                Id = d.Id,
                                OrderId = d.OrderId,
                                HospitalId = d.HospitalId,
                                HospitalName = d.HospitalInfo.Name,
                                SendBy = d.SendBy,
                                SendName = d.AmiyaEmployee.Name,
                                SendDate = d.SendDate,
                                AppointmentDate = d.AppointmentDate,
                                IsUncertainDate = d.IsUncertainDate,
                                Time = d.IsUncertainDate == false ? timeTypeDictionary[(byte)d.TimeType] : "未明确时间",
                                TimeType = d.TimeType,
                                GoodsId = d.OrderInfo.GoodsId,
                                GoodsName = d.OrderInfo.GoodsName,
                                ThumbPicUrl = d.OrderInfo.ThumbPicUrl,
                                ActualPayment = d.OrderInfo.ActualPayment,
                                PurchaseNum = d.PurchaseNum,
                                PurchaseSinglePrice = d.PurchaseSinglePrice,
                                Phone = p != null ? d.OrderInfo.Phone : config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(d.OrderInfo.Phone) : d.OrderInfo.Phone,
                                EncryptPhone = ServiceClass.Encrypt(d.OrderInfo.Phone, config.PhoneEncryptKey),
                                StatusCode = d.OrderInfo.StatusCode,
                                StatusText = ServiceClass.GetOrderStatusText(d.OrderInfo.StatusCode),
                                AppType = d.OrderInfo.AppType,
                                AppTypeText = ServiceClass.GetAppTypeText(d.OrderInfo.AppType),
                                FirstMessageContent = d.SendOrderMessageBoardList.OrderBy(e => e.Date).FirstOrDefault().Content,
                                Description = d.OrderInfo.Description,
                                Standard = d.OrderInfo.Standard,
                                Parts = d.OrderInfo.Parts
                            };

            FxPageInfo<SendOrderInfoDto> sendOrderPageInfo = new FxPageInfo<SendOrderInfoDto>();
            sendOrderPageInfo.TotalCount = await sendOrder.CountAsync();
            sendOrderPageInfo.List = await sendOrder.OrderByDescending(e => e.AppointmentDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            //foreach (var item in sendOrderPageInfo.List)
            //{
            //    var order = await dalOrderInfo.GetAll().SingleOrDefaultAsync(e => e.Id == item.OrderId);
            //    var itemInfo = await dalItemInfo.GetAll().SingleOrDefaultAsync(e => e.OtherAppItemId == order.GoodsId);
            //    if (itemInfo != null)
            //    {
            //        item.Description = itemInfo.Description;
            //        item.Standard = itemInfo.Standard;
            //        item.Parts = itemInfo.Parts;
            //    }

            //}
            return sendOrderPageInfo;
        }




        /// <summary>
        /// 获取今日派单列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<TodaySendOrderInfoDto>> GetTodaySendOrderAsync()
        {
            var q = from d in dalSendOrderInfo.GetAll()
                    select d;

            DateTime startrq = DateTime.Now.Date;
            DateTime endrq = DateTime.Now.Date.AddDays(1);

            q = from d in q
                where d.SendDate >= startrq.Date && d.SendDate < endrq.Date
                select d;
            var sendOrder = from d in q
                            select new TodaySendOrderInfoDto
                            {
                                OrderId = d.OrderId,
                                SendHospital = d.HospitalInfo.Name,
                                GoodsName = d.OrderInfo.GoodsName,
                                ActualPayment = d.OrderInfo.ActualPayment,
                            };
            return sendOrder.ToList();
        }

        /// <summary>
        /// 获取各个医院的订单量
        /// </summary>
        /// <returns></returns>
        public async Task<List<TodayHospitalOrderNumDto>> GetTodayHospitalOrderNumAsync()
        {
            var q = from d in dalSendOrderInfo.GetAll()
                    select d;

            DateTime startrq = DateTime.Now.Date;
            DateTime endrq = DateTime.Now.Date.AddDays(1);

            q = from d in q
                where (d.SendDate >= startrq.Date && d.SendDate < endrq.Date)
                select d;
            var config = await GetCallCenterConfig();
            var sendOrder = from d in q
                            select new TodaySendOrderInfoDto
                            {
                                OrderId = d.OrderId,
                                SendHospital = d.HospitalInfo.Name,
                            };
            var result = sendOrder.ToList().GroupBy(x => x.SendHospital).Select(x => new TodayHospitalOrderNumDto { HospitalName = x.Key.ToString(), OrderNum = x.ToList().Count }).ToList();
            return result.OrderByDescending(x => x.OrderNum).ToList();
        }


        /// <summary>
        /// 根据医院编号和加密电话获取派单信息
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="encryptPhone"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<SendOrderInfoDto>> GetCustomerHospitalOrdersAsync(int hospitalId, string encryptPhone, int pageNum, int pageSize)
        {
            var config = await GetCallCenterConfig();
            var phone = ServiceClass.Decrypto(encryptPhone, config.PhoneEncryptKey);

            var orders = from d in dalSendOrderInfo.GetAll()
                         where d.HospitalId == hospitalId
                         && d.OrderInfo.Phone == phone
                         select new SendOrderInfoDto
                         {
                             Id = d.Id,
                             OrderId = d.OrderId,
                             HospitalId = d.HospitalId,
                             HospitalName = d.HospitalInfo.Name,
                             SendBy = d.SendBy,
                             SendName = d.AmiyaEmployee.Name,
                             SendDate = d.SendDate,
                             IsUncertainDate = d.IsUncertainDate,
                             AppointmentDate = d.AppointmentDate,
                             Time = d.IsUncertainDate == false ? timeTypeDictionary[(byte)d.TimeType] : "未明确时间",
                             TimeType = d.TimeType,
                             GoodsId = d.OrderInfo.GoodsId,
                             GoodsName = d.OrderInfo.GoodsName,
                             ThumbPicUrl = d.OrderInfo.ThumbPicUrl,
                             ActualPayment = d.OrderInfo.ActualPayment,
                             Phone = config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(d.OrderInfo.Phone) : d.OrderInfo.Phone,
                             EncryptPhone = ServiceClass.Encrypt(d.OrderInfo.Phone, config.PhoneEncryptKey),
                             StatusCode = d.OrderInfo.StatusCode,
                             StatusText = ServiceClass.GetOrderStatusText(d.OrderInfo.StatusCode),
                             AppType = d.OrderInfo.AppType,
                             AppTypeText = ServiceClass.GetAppTypeText(d.OrderInfo.AppType),
                             FirstMessageContent = d.SendOrderMessageBoardList.OrderBy(e => e.Date).FirstOrDefault().Content
                         };
            FxPageInfo<SendOrderInfoDto> sendOrderPageInfo = new FxPageInfo<SendOrderInfoDto>();
            sendOrderPageInfo.TotalCount = await orders.CountAsync();
            sendOrderPageInfo.List = await orders.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return sendOrderPageInfo;
        }



        /// <summary>
        /// 添加派单留言板
        /// </summary>
        /// <param name="addSendOrderMessageBoard"></param>
        /// <returns></returns>
        public async Task AddSendOrderMessageBoardAsync(AddSendOrderMessageBoardDto addSendOrderMessageBoard)
        {
            SendOrderMessageBoard sendOrderMessageBoard = new SendOrderMessageBoard();
            sendOrderMessageBoard.Date = DateTime.Now;
            sendOrderMessageBoard.Type = addSendOrderMessageBoard.Type;
            sendOrderMessageBoard.SendOrderInfoId = addSendOrderMessageBoard.SendOrderInfoId;
            sendOrderMessageBoard.HospitalId = addSendOrderMessageBoard.HospitalId;
            sendOrderMessageBoard.AmiyaEmployeeId = addSendOrderMessageBoard.AmiyaEmployeeId;
            sendOrderMessageBoard.HospitalEmployeeId = addSendOrderMessageBoard.HospitalEmployeeId;
            sendOrderMessageBoard.Content = addSendOrderMessageBoard.Content;
            await dalSendOrderMessageBoard.AddAsync(sendOrderMessageBoard, true);

        }



        /// <summary>
        /// 获取派单留言板列表
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="id">派单信息编号</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<SendOrderMessageBoardDto>> GetSendOrderMessageBoardListByIdAsync(int? hospitalId, int id, int pageNum, int pageSize)
        {
            var sendOrderMessageBoards = dalSendOrderMessageBoard.GetAll().Where(e => e.SendOrderInfoId == id);
            if (hospitalId != null)
            {
                sendOrderMessageBoards = sendOrderMessageBoards.Where(e => e.HospitalId == hospitalId);
            }
            var messageBoards = from d in sendOrderMessageBoards
                                select new SendOrderMessageBoardDto
                                {
                                    Id = d.Id,
                                    Date = d.Date,
                                    Type = d.Type,
                                    TypeName = d.Type == (byte)SendOrderMessageBoardType.Amiya ? "啊美雅" : d.HospitalInfo.Name,
                                    SendOrderInfoId = d.SendOrderInfoId,
                                    AmiyaEmployeeId = d.AmiyaEmployeeId,
                                    AmiyaEmployeeName = d.AmiyaEmployee.Name,
                                    HospitalEmployeeId = d.HospitalEmployeeId,
                                    HospitalEmployeeName = d.HospitalEmployee.Name,
                                    HospitalId = d.HospitalId,
                                    HospitalLogo = d.HospitalEmployee.HospitalInfo.ThumbPicUrl,
                                    Content = d.Content
                                };


            FxPageInfo<SendOrderMessageBoardDto> pageInfo = new FxPageInfo<SendOrderMessageBoardDto>();
            pageInfo.TotalCount = await messageBoards.CountAsync();
            pageInfo.List = await messageBoards.OrderBy(e => e.Date).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return pageInfo;
        }

        public async Task<List<SendOrderInfoDto>> GetSendOrderInfoByOrderId(string orderId)
        {
            var config = await GetCallCenterConfig();
            var orders = from d in dalSendOrderInfo.GetAll()
                         where d.OrderId == orderId
                         select new SendOrderInfoDto
                         {
                             Id = d.Id,
                             OrderId = d.OrderId,
                             HospitalId = d.HospitalId,
                             HospitalName = d.HospitalInfo.Name,
                             SendBy = d.SendBy,
                             SendName = d.AmiyaEmployee.Name,
                             SendDate = d.SendDate,
                             IsUncertainDate = d.IsUncertainDate,
                             AppointmentDate = d.AppointmentDate,
                             Time = d.IsUncertainDate == false ? timeTypeDictionary[(byte)d.TimeType] : "未明确时间",
                             PurchaseNum = d.PurchaseNum,
                             PurchaseSinglePrice = d.PurchaseSinglePrice,
                             TimeType = d.TimeType,
                             GoodsId = d.OrderInfo.GoodsId,
                             GoodsName = d.OrderInfo.GoodsName,
                             ThumbPicUrl = d.OrderInfo.ThumbPicUrl,
                             ActualPayment = d.OrderInfo.ActualPayment,
                             Phone = config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(d.OrderInfo.Phone) : d.OrderInfo.Phone,
                             EncryptPhone = ServiceClass.Encrypt(d.OrderInfo.Phone, config.PhoneEncryptKey),
                             StatusCode = d.OrderInfo.StatusCode,
                             StatusText = ServiceClass.GetOrderStatusText(d.OrderInfo.StatusCode),
                             AppType = d.OrderInfo.AppType,
                             AppTypeText = ServiceClass.GetAppTypeText(d.OrderInfo.AppType),
                             FirstMessageContent = d.SendOrderMessageBoardList.OrderBy(e => e.Date).FirstOrDefault().Content
                         };
            return orders.ToList();
        }

        public async Task<List<SendOrderReportDto>> GetSendOrderReportAsync(DateTime? startDate, DateTime? endDate, string state, bool isHidePhone)
        {

            var q = from d in dalSendOrderInfo.GetAll()
                    select d;

            if (startDate != null && endDate != null)
            {
                DateTime startrq = (DateTime)startDate;
                DateTime endrq = ((DateTime)endDate).Date.AddDays(1);

                q = from d in q
                    where (d.SendDate >= startrq && d.SendDate < endrq)
                    select d;
            }
            if (!string.IsNullOrEmpty(state))
            {
                q = from d in q
                    where d.OrderInfo.StatusCode == state
                    select d;
            }
            var sendOrder = from d in q
                            select new SendOrderReportDto
                            {
                                OrderId = d.OrderId,
                                HospitalName = d.HospitalInfo.Name,
                                SendName = d.AmiyaEmployee.Name,
                                SendDate = d.SendDate,
                                Time = d.IsUncertainDate == false ? timeTypeDictionary[(byte)d.TimeType] : "未明确时间",
                                GoodsName = d.OrderInfo.GoodsName,
                                PurchaseSinglePrice = d.PurchaseSinglePrice,
                                PurchaseNum = d.PurchaseNum,
                                PurchasePrice = d.PurchaseNum * d.PurchaseSinglePrice,
                                ActualPayment = d.OrderInfo.ActualPayment,
                                EncryptPhone = isHidePhone == true ? ServiceClass.GetIncompletePhone(d.OrderInfo.Phone) : d.OrderInfo.Phone,
                                StatusText = ServiceClass.GetOrderStatusText(d.OrderInfo.StatusCode),
                                AppTypeText = ServiceClass.GetAppTypeText(d.OrderInfo.AppType),
                            };

            return sendOrder.OrderByDescending(z => z.SendDate).ToList();
        }

        /// <summary>
        /// 获医院订单报表
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="hospitalName">医院名称</param>
        /// <returns></returns>
        public async Task<List<SendOrderReportDto>> GetHospitalOrderReportAsync(DateTime? startDate, DateTime? endDate, string hospitalName, bool isHidePhone)
        {

            var q = from d in dalSendOrderInfo.GetAll()
                    select d;

            if (startDate != null && endDate != null)
            {
                DateTime startrq = (DateTime)startDate;
                DateTime endrq = ((DateTime)endDate).Date.AddDays(1);

                q = from d in q
                    where (d.SendDate >= startrq && d.SendDate < endrq)
                    select d;
            }

            var sendOrder = from d in q
                            select new SendOrderReportDto
                            {
                                OrderId = d.OrderId,
                                HospitalName = d.HospitalInfo.Name,
                                SendName = d.AmiyaEmployee.Name,
                                SendDate = d.SendDate,
                                Time = d.IsUncertainDate == false ? d.AppointmentDate.Value.ToString("yyyy-MM-dd") + timeTypeDictionary[(byte)d.TimeType] : "未明确时间",
                                GoodsName = d.OrderInfo.GoodsName,
                                PurchaseSinglePrice = d.PurchaseSinglePrice,
                                PurchaseNum = d.PurchaseNum,
                                PurchasePrice = d.PurchaseSinglePrice * d.PurchaseNum,
                                ActualPayment = d.OrderInfo.ActualPayment,
                                Description = d.OrderInfo.Description,
                                Standard = d.OrderInfo.Standard,
                                EncryptPhone = isHidePhone == true ? ServiceClass.GetIncompletePhone(d.OrderInfo.Phone) : d.OrderInfo.Phone,
                                StatusText = ServiceClass.GetOrderStatusText(d.OrderInfo.StatusCode),
                                AppTypeText = ServiceClass.GetAppTypeText(d.OrderInfo.AppType),
                            };

            var result = sendOrder.ToList();
            if (!string.IsNullOrEmpty(hospitalName))
            {
                result = result.Where(z => z.HospitalName.Contains(hospitalName)).ToList();
            }
            return result.OrderByDescending(z => z.HospitalName).ThenByDescending(z => z.SendDate).ToList();
        }
        public async Task<List<SendOrderReportDto>> GetCustomerSendOrderReportAsync(DateTime? startDate, DateTime? endDate, int employeeId, int belongEmpId, string orderStatus, bool isHidePhone)
        {

            var q = from d in dalSendOrderInfo.GetAll()
                    select d;

            if (startDate != null && endDate != null)
            {
                DateTime startrq = (DateTime)startDate;
                DateTime endrq = ((DateTime)endDate).Date.AddDays(1);

                q = from d in q
                    where (d.SendDate >= startrq && d.SendDate < endrq)
                    select d;
            }
            if (employeeId > 0)
            {
                q = from d in q
                    where d.AmiyaEmployee.Id == employeeId
                    select d;
            }
            if (belongEmpId > 0)
            {
                q = from d in q
                    where d.OrderInfo.BelongEmpId == belongEmpId
                    select d;
            }
            if (!string.IsNullOrEmpty(orderStatus))
            {
                q = from d in q
                    where d.OrderInfo.StatusCode == orderStatus
                    select d;
            }
            var sendOrder = from d in q
                            select new SendOrderReportDto
                            {
                                OrderId = d.OrderId,
                                HospitalName = d.HospitalInfo.Name,
                                SendName = d.AmiyaEmployee.Name,
                                SendDate = d.SendDate,
                                Time = d.IsUncertainDate == false ? timeTypeDictionary[(byte)d.TimeType] : "未明确时间",
                                GoodsName = d.OrderInfo.GoodsName,
                                PurchaseSinglePrice = d.PurchaseSinglePrice,
                                PurchaseNum = d.PurchaseNum,
                                PurchasePrice = d.PurchaseNum * d.PurchaseSinglePrice,
                                ActualPayment = d.OrderInfo.ActualPayment,
                                EncryptPhone = isHidePhone == true ? ServiceClass.GetIncompletePhone(d.OrderInfo.Phone) : d.OrderInfo.Phone,
                                StatusText = ServiceClass.GetOrderStatusText(d.OrderInfo.StatusCode),
                                AppTypeText = ServiceClass.GetAppTypeText(d.OrderInfo.AppType),
                                BelongEmpId = d.OrderInfo.BelongEmpId
                            };

            var result = sendOrder.OrderByDescending(z => z.SendName).ToList();
            foreach (var x in result)
            {
                if (x.BelongEmpId != 0)
                {
                    var empInfo = await _AmiyaEmployee.GetByIdAsync(x.BelongEmpId);
                    if (empInfo.Id != 0)
                    {
                        x.BelongEmpName = empInfo.Name;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 获取未派单订单报表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="employeeId">-1查全部</param>
        /// <returns></returns>
        public async Task<List<UnSendOrderInfoReportDto>> GetUnSendOrderReportWithPageAsync(DateTime? startDate, DateTime? endDate, int employeeId, bool isHidePhone)
        {

            var orders = from o in dalOrderInfo.GetAll()
                         where o.IsAppointment == false && o.OrderType == (byte)OrderType.VirtualOrder
                         select o;

            orders = from o in orders
                     where o.StatusCode == OrderStatusCode.WAIT_SELLER_SEND_GOODS || o.StatusCode == OrderStatusCode.WAIT_BUYER_CONFIRM_GOODS || o.StatusCode == OrderStatusCode.SEEK_ADVICE || o.StatusCode == OrderStatusCode.BARGAIN_MONEY
                     select o;

            if (startDate != null && endDate != null)
            {
                DateTime startrq = (DateTime)startDate;
                DateTime endrq = ((DateTime)endDate).Date.AddDays(1);

                orders = from d in orders
                         where (d.CreateDate >= startrq && d.CreateDate < endrq)
                         select d;
            }
            var unSendOrder = from o in orders
                              where o.SendOrderInfoList.Count(e => e.OrderId == o.Id) == 0
                              && (employeeId == -1 || o.BelongEmpId == employeeId)
                              select new UnSendOrderInfoReportDto
                              {
                                  OrderId = o.Id,
                                  GoodsName = o.GoodsName,
                                  EncryptPhone = isHidePhone == true ? ServiceClass.GetIncompletePhone(o.Phone) : o.Phone,
                                  ActualPayment = o.ActualPayment,
                                  CreateDate = o.CreateDate,
                                  BelongEmpId = o.BelongEmpId,
                                  AppointmentHospital = o.AppointmentHospital,
                                  StatusText = ServiceClass.GetOrderStatusText(o.StatusCode),
                                  AppTypeText = ServiceClass.GetAppTypeText(o.AppType),
                              };

            var result = await unSendOrder.OrderByDescending(x => x.CreateDate).ToListAsync();
            foreach (var x in result)
            {
                if (x.BelongEmpId.HasValue)
                {
                    var customerServiceInfo = await _AmiyaEmployee.GetByIdAsync(x.BelongEmpId.Value);
                    if (customerServiceInfo.Id != 0)
                    {
                        x.BindCustomerServiceName = customerServiceInfo.Name;
                    }
                }
            }
            return result;
        }

        #region 【数据中心板块】

        /// <summary>
        /// 获取时间段内已派单数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<List<OrderOperationConditionDto>> GetOrderSendDataAsync(DateTime startDate, DateTime endDate)
        {
            DateTime startrq = ((DateTime)startDate);
            DateTime endrq = ((DateTime)endDate).Date.AddDays(1);
            var orders = from d in dalSendOrderInfo.GetAll()
                         where d.SendDate >= startrq && d.SendDate < endrq
                         select d;
            var orderList = orders.ToList();
            return orderList.GroupBy(x => x.SendDate.Date).Select(x => new OrderOperationConditionDto { Date = x.Key.ToString("yyyy-MM-dd"), OrderNum = x.ToList().Count }).ToList();
        }

        /// <summary>
        /// 获取时间段内未派单数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<List<OrderOperationConditionDto>> GetOrderUnSendDataAsync(DateTime startDate, DateTime endDate)
        {
            DateTime startrq = ((DateTime)startDate);
            DateTime endrq = ((DateTime)endDate).Date.AddDays(1);

            var orders = from o in dalOrderInfo.GetAll()
                         where o.IsAppointment == false
                         && o.OrderType == (byte)OrderType.VirtualOrder
                         && o.SendOrderInfoList.Count(e => e.OrderId == o.Id) == 0
                         && o.CreateDate >= startrq && o.CreateDate < endrq
                         select o;
            var orderList = orders.ToList();
            return orderList.GroupBy(x => x.CreateDate.Value.Date).Select(x => new OrderOperationConditionDto { Date = x.Key.ToString("yyyy-MM-dd"), OrderNum = x.ToList().Count }).ToList();
        }

        /// <summary>
        /// 获取时间段内各个医院的订单量
        /// </summary>
        /// <returns></returns>
        public async Task<List<HospitalOrderNumAndPriceDto>> GetHospitalOrderNumAsync(DateTime startDate, DateTime endDate)
        {
            var q = from o in dalOrderInfo.GetAll()
                    where o.StatusCode == "TRADE_FINISHED"
                    && o.SendOrderInfoList.Count > 0
                    && o.OrderType == (byte)OrderType.VirtualOrder
                    select o;

            DateTime startrq = DateTime.Now.Date;
            DateTime endrq = DateTime.Now.Date.AddDays(1);

            q = from d in q
                where (d.WriteOffDate >= startrq.Date && d.WriteOffDate < endrq.Date)
                select d;
            var sendOrder = from d in q
                            select new HospitalOrderNumAndPriceDto
                            {
                                Price = d.ActualPayment.Value,
                                HospitalName = d.SendOrderInfoList.OrderByDescending(k => k.SendDate).First().HospitalInfo.Name,
                                OrderNum = d.Quantity.Value
                            };
            return sendOrder.ToList();
        }




        #endregion


    }
}
