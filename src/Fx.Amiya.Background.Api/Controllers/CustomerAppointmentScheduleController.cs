using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.CustomerAppointmentSchedule;
using Fx.Amiya.Background.Api.Vo.CustomerAppointmentSchedule.Input;
using Fx.Amiya.Background.Api.Vo.CustomerAppointmentSchedule.Result;
using Fx.Amiya.Dto.CustomerAppointmentSchedule;
using Fx.Amiya.Dto.CustomerAppointmentSchedule.Input;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using jos_sdk_net.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 客户预约日程板块数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class CustomerAppointmentScheduleController : ControllerBase
    {
        private ICustomerAppointmentScheduleService customerAppointmentScheduleService;
        private IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="customerAppointmentScheduleService"></param>
        public CustomerAppointmentScheduleController(ICustomerAppointmentScheduleService customerAppointmentScheduleService, IHttpContextAccessor httpContextAccessor)
        {
            this.customerAppointmentScheduleService = customerAppointmentScheduleService;
            _httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// 获取客户预约日程信息列表（分页）
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<CustomerAppointmentScheduleVo>>> GetListWithPageAsync([FromQuery] QueryCustomerAppointSchedulePageListVo query)
        {
            try
            {
                var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                QueryCustomerAppointSchedulePageListDto queryCustomerAppointSchedulePageListDto = new QueryCustomerAppointSchedulePageListDto();
                queryCustomerAppointSchedulePageListDto.ImportantType = query.ImportantType;
                queryCustomerAppointSchedulePageListDto.IsFinish = query.IsFinish;
                queryCustomerAppointSchedulePageListDto.KeyWord = query.KeyWord;
                queryCustomerAppointSchedulePageListDto.CreateBy = employeeId;
                queryCustomerAppointSchedulePageListDto.AppointmentType = query.AppointmentType;
                queryCustomerAppointSchedulePageListDto.StartDate = query.StartDate;
                queryCustomerAppointSchedulePageListDto.EndDate = query.EndDate;
                queryCustomerAppointSchedulePageListDto.PageNum = query.PageNum;
                queryCustomerAppointSchedulePageListDto.PageSize = query.PageSize;
                queryCustomerAppointSchedulePageListDto.AssignLiveanchorId = query.AssignLiveanchorId;
                var q = await customerAppointmentScheduleService.GetListWithPageAsync(queryCustomerAppointSchedulePageListDto);

                var customerAppointmentSchedule = from d in q.List
                                                  select new CustomerAppointmentScheduleVo
                                                  {
                                                      Id = d.Id,
                                                      CreateBy = d.CreateBy,
                                                      CreateDate = d.CreateDate,
                                                      UpdateDate = d.UpdateDate,
                                                      DeleteDate = d.DeleteDate,
                                                      Valid = d.Valid,
                                                      CustomerName = d.CustomerName,
                                                      Phone = d.Phone,
                                                      AppointmentType = d.AppointmentType,
                                                      AppointmentTypeText = d.AppointmentTypeText,
                                                      AppointmentDate = d.AppointmentDate,
                                                      IsFinish = d.IsFinish,
                                                      ImportantType = d.ImportantType,
                                                      ImportantTypeText = d.ImportantTypeText,
                                                      Remark = d.Remark,
                                                      CreateByEmpName = d.CreateByEmpName,
                                                      AppointmentHospitalId=d.AppointmentHospitalId,
                                                      AppointmentHospitalName=d.AppointmentHospitalName,
                                                      Consultation=d.Consultation,
                                                      AssignLiveanchorId=d.AssignLiveanchorId,
                                                      CustomerPic1 = d.CustomerPic1,
                                                      CustomerPic2 = d.CustomerPic2,
                                                      CustomerPic3 = d.CustomerPic3,
                                                      AssignLiveanchorName =d.AssignLiveanchorName
                                                  };

                FxPageInfo<CustomerAppointmentScheduleVo> customerAppointmentSchedulePageInfo = new FxPageInfo<CustomerAppointmentScheduleVo>();
                customerAppointmentSchedulePageInfo.TotalCount = q.TotalCount;
                customerAppointmentSchedulePageInfo.List = customerAppointmentSchedule;

                return ResultData<FxPageInfo<CustomerAppointmentScheduleVo>>.Success().AddData("customerAppointmentScheduleInfo", customerAppointmentSchedulePageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<CustomerAppointmentScheduleVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取客户预约日历
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("listByCalendar")]
        public async Task<ResultData<List<CustomerAppointmentScheduleByCalendarVo>>> GetListByCalendarAsync([FromQuery] BaseQueryVo query)
        {
            try
            {
                var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                QueryCustomerAppointSchedulePageListDto queryCustomerAppointSchedulePageListDto = new QueryCustomerAppointSchedulePageListDto();
                queryCustomerAppointSchedulePageListDto.StartDate = query.StartDate;
                queryCustomerAppointSchedulePageListDto.EndDate = query.EndDate;
                queryCustomerAppointSchedulePageListDto.CreateBy = employeeId;
                var q = await customerAppointmentScheduleService.GetListByCalendarAsync(queryCustomerAppointSchedulePageListDto);

                var customerAppointmentSchedule = from d in q
                                                  select new CustomerAppointmentScheduleVo
                                                  {
                                                      Id = d.Id,
                                                      CreateBy = d.CreateBy,
                                                      CreateDate = d.CreateDate,
                                                      UpdateDate = d.UpdateDate,
                                                      DeleteDate = d.DeleteDate,
                                                      Valid = d.Valid,
                                                      CustomerName = d.CustomerName,
                                                      Phone = d.Phone,
                                                      AppointmentType = d.AppointmentType,
                                                      AppointmentTypeText = d.AppointmentTypeText,
                                                      AppointmentDate = d.AppointmentDate,
                                                      Date = d.AppointmentDate.Day,
                                                      Week = d.AppointmentDate.DayOfWeek,
                                                      IsFinish = d.IsFinish,
                                                      ImportantType = d.ImportantType,
                                                      ImportantTypeText = d.ImportantTypeText,
                                                      Remark = d.Remark,
                                                      CreateByEmpName = d.CreateByEmpName,
                                                      AppointmentHospitalId=d.AppointmentHospitalId,
                                                      AppointmentHospitalName=d.AppointmentHospitalName,
                                                      Consultation=d.Consultation,
                                                      AssignLiveanchorId=d.AssignLiveanchorId,
                                                      AssignLiveanchorName=d.AssignLiveanchorName
                                                  };

                List<CustomerAppointmentScheduleVo> customerAppointmentSchedulePageInfo = new List<CustomerAppointmentScheduleVo>();
                customerAppointmentSchedulePageInfo = customerAppointmentSchedule.ToList();
                var messageDate = customerAppointmentSchedulePageInfo.GroupBy(x => x.Date).Select(x => x.Key);

                List<CustomerAppointmentScheduleByCalendarVo> customerAppointmentScheduleVos = new List<CustomerAppointmentScheduleByCalendarVo>();
                foreach (var x in messageDate)
                {
                    CustomerAppointmentScheduleByCalendarVo customerAppointmentScheduleVo = new CustomerAppointmentScheduleByCalendarVo();
                    customerAppointmentScheduleVo.Date = x;
                    customerAppointmentScheduleVo.ccstomerAppointmentScheduleDetailsVos = customerAppointmentSchedulePageInfo.Where(z => z.Date == x).ToList();
                    customerAppointmentScheduleVos.Add(customerAppointmentScheduleVo);
                }
                return ResultData<List<CustomerAppointmentScheduleByCalendarVo>>.Success().AddData("customerAppointmentScheduleInfo", customerAppointmentScheduleVos);
            }
            catch (Exception ex)
            {
                return ResultData<List<CustomerAppointmentScheduleByCalendarVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 添加客户预约日程信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddCustomerAppointmentScheduleVo addVo)
        {
            try
            {
                var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                AddCustomerAppointmentScheduleDto addDto = new AddCustomerAppointmentScheduleDto();
                addDto.CreateBy = employeeId;
                addDto.CustomerName = addVo.CustomerName;
                addDto.Phone = addVo.Phone;
                addDto.AppointmentType = addVo.AppointmentType;
                addDto.AppointmentDate = addVo.AppointmentDate;
                addDto.IsFinish = addVo.IsFinish;
                addDto.ImportantType = addVo.ImportantType;
                addDto.Remark = addVo.Remark;
                addDto.AppointmentHospitalId = addVo.AppointmentHospitalId;
                addDto.Consultation = addVo.Consultation;
                addDto.AssignLiveanchorId = addVo.AssignLiveanchorId;
                addDto.CustomerPic1 = addVo.CustomerPic1;
                addDto.CustomerPic2 = addVo.CustomerPic2;
                addDto.CustomerPic3 = addVo.CustomerPic3;
                await customerAppointmentScheduleService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据客户预约日程编号获取客户预约日程信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<CustomerAppointmentScheduleVo>> GetByIdAsync(string id)
        {
            try
            {
                var customerAppointmentSchedule = await customerAppointmentScheduleService.GetByIdAsync(id);
                CustomerAppointmentScheduleVo customerAppointmentScheduleVo = new CustomerAppointmentScheduleVo();
                customerAppointmentScheduleVo.Id = customerAppointmentSchedule.Id;
                customerAppointmentScheduleVo.CustomerName = customerAppointmentSchedule.CustomerName;
                customerAppointmentScheduleVo.Phone = customerAppointmentSchedule.Phone;
                customerAppointmentScheduleVo.AppointmentType = customerAppointmentSchedule.AppointmentType;
                customerAppointmentScheduleVo.AppointmentDate = customerAppointmentSchedule.AppointmentDate;
                customerAppointmentScheduleVo.IsFinish = customerAppointmentSchedule.IsFinish;
                customerAppointmentScheduleVo.ImportantType = customerAppointmentSchedule.ImportantType;
                customerAppointmentScheduleVo.Remark = customerAppointmentSchedule.Remark;
                customerAppointmentScheduleVo.Valid = customerAppointmentSchedule.Valid;
                customerAppointmentScheduleVo.CreateDate = customerAppointmentSchedule.CreateDate;
                customerAppointmentScheduleVo.AppointmentHospitalId = customerAppointmentSchedule.AppointmentHospitalId;
                customerAppointmentScheduleVo.AppointmentHospitalName = customerAppointmentSchedule.AppointmentHospitalName;
                customerAppointmentScheduleVo.Consultation = customerAppointmentSchedule.Consultation;
                customerAppointmentScheduleVo.AssignLiveanchorId = customerAppointmentSchedule.AssignLiveanchorId;
                customerAppointmentScheduleVo.AssignLiveanchorName = customerAppointmentSchedule.AssignLiveanchorName;
                customerAppointmentScheduleVo.CustomerPic1 = customerAppointmentSchedule.CustomerPic1;
                customerAppointmentScheduleVo.CustomerPic2 = customerAppointmentSchedule.CustomerPic2;
                customerAppointmentScheduleVo.CustomerPic3 = customerAppointmentSchedule.CustomerPic3;
                return ResultData<CustomerAppointmentScheduleVo>.Success().AddData("customerAppointmentScheduleInfo", customerAppointmentScheduleVo);
            }
            catch (Exception ex)
            {
                return ResultData<CustomerAppointmentScheduleVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 根据客户手机号获取客户预约日程信息（单条）
        /// </summary>
        /// <param name="encryptPhone"></param>
        /// <returns></returns>
        [HttpGet("byEncryptPhone")]
        public async Task<ResultData<CustomerAppointmentScheduleVo>> GetByEncryptPhoneAsync(string encryptPhone)
        {
            try
            {
                var customerAppointmentSchedule = await customerAppointmentScheduleService.GetByEncryptPhoneAsync(encryptPhone);
                CustomerAppointmentScheduleVo customerAppointmentScheduleVo = new CustomerAppointmentScheduleVo();
                customerAppointmentScheduleVo.Id = customerAppointmentSchedule.Id;
                customerAppointmentScheduleVo.CustomerName = customerAppointmentSchedule.CustomerName;
                customerAppointmentScheduleVo.Phone = customerAppointmentSchedule.Phone;
                customerAppointmentScheduleVo.AppointmentType = customerAppointmentSchedule.AppointmentType;
                customerAppointmentScheduleVo.AppointmentDate = customerAppointmentSchedule.AppointmentDate;
                customerAppointmentScheduleVo.IsFinish = customerAppointmentSchedule.IsFinish;
                customerAppointmentScheduleVo.ImportantType = customerAppointmentSchedule.ImportantType;
                customerAppointmentScheduleVo.Remark = customerAppointmentSchedule.Remark;
                customerAppointmentScheduleVo.Valid = customerAppointmentSchedule.Valid;
                customerAppointmentScheduleVo.CreateDate = customerAppointmentSchedule.CreateDate;
                customerAppointmentScheduleVo.AppointmentHospitalId = customerAppointmentSchedule.AppointmentHospitalId;
                customerAppointmentScheduleVo.AppointmentHospitalName = customerAppointmentSchedule.AppointmentHospitalName;
                customerAppointmentScheduleVo.Consultation = customerAppointmentSchedule.Consultation;
                customerAppointmentScheduleVo.CustomerPic1 = customerAppointmentSchedule.CustomerPic1;
                customerAppointmentScheduleVo.CustomerPic2 = customerAppointmentSchedule.CustomerPic2;
                customerAppointmentScheduleVo.CustomerPic3 = customerAppointmentSchedule.CustomerPic3;
                return ResultData<CustomerAppointmentScheduleVo>.Success().AddData("customerAppointmentScheduleInfo", customerAppointmentScheduleVo);
            }
            catch (Exception ex)
            {
                return ResultData<CustomerAppointmentScheduleVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改客户预约日程信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateCustomerAppointmentScheduleVo updateVo)
        {
            try
            {
                UpdateCustomerAppointmentScheduleDto updateDto = new UpdateCustomerAppointmentScheduleDto();
                updateDto.Id = updateVo.Id;
                updateDto.CustomerName = updateVo.CustomerName;
                updateDto.Phone = updateVo.Phone;
                updateDto.AppointmentType = updateVo.AppointmentType;
                updateDto.AppointmentDate = updateVo.AppointmentDate;
                updateDto.IsFinish = updateVo.IsFinish;
                updateDto.ImportantType = updateVo.ImportantType;
                updateDto.Remark = updateVo.Remark;
                updateDto.AppointmentHospitalId = updateVo.AppointmentHospitalId;
                updateDto.Consultation = updateVo.Consultation;
                updateDto.AssignLiveanchorId = updateVo.AssignLiveanchorId;
                updateDto.CustomerPic1 = updateVo.CustomerPic1;
                updateDto.CustomerPic2 = updateVo.CustomerPic2;
                updateDto.CustomerPic3 = updateVo.CustomerPic3;
                await customerAppointmentScheduleService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除客户预约日程信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await customerAppointmentScheduleService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 指派主播
        /// </summary>
        /// <param name="assignVo"></param>
        /// <returns></returns>
        [HttpPut("assign")]
        public async Task<ResultData> AssignAsync(AssignLiveAnchorVo assignVo)
        {
            try
            {
                await customerAppointmentScheduleService.AssignAsync(assignVo.Id, assignVo.AssignBy);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 批量指派主播
        /// </summary>
        /// <param name="assignVo"></param>
        /// <returns></returns>
        [HttpPut("assignList")]
        public async Task<ResultData> AssignListAsync(AssignLiveAnchorListVo assignVo)
        {
            try
            {
                foreach (var x in assignVo.IdList)
                {
                    await customerAppointmentScheduleService.AssignAsync(x, assignVo.AssignBy);
                }
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
        
        

        #region 枚举下拉框

        /// <summary>
        /// 获取预约类型
        /// </summary>
        /// <returns></returns>
        [HttpGet("getAppointmentTypeList")]
        [FxInternalAuthorize]
        public ResultData<List<BaseIdAndNameVo>> GetOrderConsultationTypeList()
        {
            var orderTypes = from d in customerAppointmentScheduleService.GetAppointmentTypeList()
                             select new BaseIdAndNameVo
                             {
                                 Id = d.Id,
                                 Name = d.Name
                             };
            return ResultData<List<BaseIdAndNameVo>>.Success().AddData("appointmentTypeList", orderTypes.ToList());
        }
        #endregion

    }
}
