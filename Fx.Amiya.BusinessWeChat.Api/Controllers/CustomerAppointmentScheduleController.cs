using Fx.Amiya.BusinessWeChat.Api.Vo.CustomerAppointmentSchedule;
using Fx.Amiya.BusinessWeChat.Api.Vo.CustomerAppointmentSchedule.Input;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWeChat.Api.Controllers
{
    /// <summary>
    /// 预约日程
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class CustomerAppointmentScheduleController : ControllerBase
    {
        private readonly ICustomerAppointmentScheduleService customerAppointmentScheduleService;

        public CustomerAppointmentScheduleController(ICustomerAppointmentScheduleService customerAppointmentScheduleService)
        {
            this.customerAppointmentScheduleService = customerAppointmentScheduleService;
        }

        /// <summary>
        /// 主播获取客户预约日程信息列表（分页）
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<CustomerAppointmentScheduleVo>>> GetListWithPageAsync([FromQuery]QueryLiveAnchorToHospitalLiveAnchorVo query)
        {
            try
            {
                var q = await customerAppointmentScheduleService.GetListWithPageByBaseLiveAnchorAsync(query.LiveAnchorId,query.PageSize,query.PageNum,query.AppointmentType);
                var customerAppointmentSchedule = from d in q.List
                                                  select new CustomerAppointmentScheduleVo
                                                  {
                                                      Id = d.Id,
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
                                                      AppointmentHospitalId = d.AppointmentHospitalId,
                                                      AppointmentHospitalName = d.AppointmentHospitalName,
                                                      Consultation = d.Consultation,                
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
    }
}
