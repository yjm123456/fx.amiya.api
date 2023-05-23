using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.CustomerHospitalDealInfo;
using Fx.Amiya.Background.Api.Vo.CustomerHospitalDealInfo.Input;
using Fx.Amiya.Background.Api.Vo.CustomerHospitalDealInfo.Result;
using Fx.Amiya.Dto.CustomerHospitalDealInfo;
using Fx.Amiya.Dto.CustomerHospitalDealInfo.Input;
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
    /// 客户在院消费板块数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class CustomerHospitalDealInfoController : ControllerBase
    {
        private ICustomerHospitalDealInfoService customerHospitalDealInfoService;
        private IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="customerHospitalDealInfoService"></param>
        public CustomerHospitalDealInfoController(ICustomerHospitalDealInfoService customerHospitalDealInfoService, IHttpContextAccessor httpContextAccessor)
        {
            this.customerHospitalDealInfoService = customerHospitalDealInfoService;
            _httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// 获取客户在院消费信息列表（分页）
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<CustomerHospitalDealInfoVo>>> GetListWithPageAsync([FromQuery] QueryCustomerHospitalDealInfoPageListVo query)
        {
            try
            {
                var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                QueryCustomerHospitalDealInfoPageListDto queryCustomerAppointSchedulePageListDto = new QueryCustomerHospitalDealInfoPageListDto();
                queryCustomerAppointSchedulePageListDto.Type = query.Type;
                queryCustomerAppointSchedulePageListDto.ConsumptionType = query.ConsumptionType;
                queryCustomerAppointSchedulePageListDto.KeyWord = query.KeyWord;
                queryCustomerAppointSchedulePageListDto.CreateBy = employeeId;
                queryCustomerAppointSchedulePageListDto.RefundType = query.RefundType;
                queryCustomerAppointSchedulePageListDto.StartDate = query.StartDate;
                queryCustomerAppointSchedulePageListDto.EndDate = query.EndDate;
                queryCustomerAppointSchedulePageListDto.PageNum = query.PageNum;
                queryCustomerAppointSchedulePageListDto.PageSize = query.PageSize;
                queryCustomerAppointSchedulePageListDto.HospitalId = query.HospitalId;
                var q = await customerHospitalDealInfoService.GetListWithPageAsync(queryCustomerAppointSchedulePageListDto);

                var customerHospitalDealInfo = from d in q.List
                                                  select new CustomerHospitalDealInfoVo
                                                  {
                                                      Id = d.Id,
                                                      HospitalId = d.HospitalId,
                                                      HospitalName = d.HospitalName,
                                                      Type = d.Type,
                                                      TypeText = d.TypeText,
                                                      CustomerName = d.CustomerName,
                                                      CustomerPhone = d.CustomerPhone,
                                                      Date = d.Date,
                                                      TotalCashAmount = d.TotalCashAmount,
                                                      ConsumptionType = d.ConsumptionType,
                                                      ConsumptionTypeText = d.ConsumptionTypeText,
                                                      RefundType = d.RefundType,
                                                      RefundTypeText = d.RefundTypeText,
                                                      MsgId = d.MsgId,
                                                      CreateDate = d.CreateDate,
                                                  };

                FxPageInfo<CustomerHospitalDealInfoVo> customerHospitalDealInfoPageInfo = new FxPageInfo<CustomerHospitalDealInfoVo>();
                customerHospitalDealInfoPageInfo.TotalCount = q.TotalCount;
                customerHospitalDealInfoPageInfo.List = customerHospitalDealInfo;

                return ResultData<FxPageInfo<CustomerHospitalDealInfoVo>>.Success().AddData("customerHospitalDealInfoInfo", customerHospitalDealInfoPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<CustomerHospitalDealInfoVo>>.Fail(ex.Message);
            }
        }

        #region 枚举下拉框

        /// <summary>
        /// 获取医院成交类型
        /// </summary>
        /// <returns></returns>
        [HttpGet("getHospitalDealTypeList")]
        [FxInternalAuthorize]
        public ResultData<List<BaseIdAndNameVo>> GetHospitalDealTypeList()
        {
            var orderTypes = from d in customerHospitalDealInfoService.GetHospitalDealTypeList()
                             select new BaseIdAndNameVo
                             {
                                 Id = d.Id,
                                 Name = d.Name
                             };
            return ResultData<List<BaseIdAndNameVo>>.Success().AddData("hospitalDealTypeList", orderTypes.ToList());
        }


        /// <summary>
        /// 获取医院消费类型
        /// </summary>
        /// <returns></returns>
        [HttpGet("getHospitalConsumptionTypeList")]
        [FxInternalAuthorize]
        public ResultData<List<BaseIdAndNameVo>> GetHospitalConsumptionTypeList()
        {
            var orderTypes = from d in customerHospitalDealInfoService.GetHospitalConsumptionTypeList()
                             select new BaseIdAndNameVo
                             {
                                 Id = d.Id,
                                 Name = d.Name
                             };
            return ResultData<List<BaseIdAndNameVo>>.Success().AddData("hospitalConsumptionTypeList", orderTypes.ToList());
        }



        /// <summary>
        /// 获取医院退款类型
        /// </summary>
        /// <returns></returns>
        [HttpGet("getHospitalRefundTypeList")]
        [FxInternalAuthorize]
        public ResultData<List<BaseIdAndNameVo>> GetHospitalRefundTypeList()
        {
            var orderTypes = from d in customerHospitalDealInfoService.GetHospitalRefundTypeList()
                             select new BaseIdAndNameVo
                             {
                                 Id = d.Id,
                                 Name = d.Name
                             };
            return ResultData<List<BaseIdAndNameVo>>.Success().AddData("hospitalRefundTypeList", orderTypes.ToList());
        }

        #endregion

    }
}
