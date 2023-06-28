using Fx.Amiya.Background.Api.Vo.CustomerHospitalDealInfo.Input;
using Fx.Amiya.Background.Api.Vo.CustomerHospitalDealInfo.Result;
using Fx.Amiya.Dto.CustomerHospitalDealDetails;
using Fx.Amiya.Dto.CustomerHospitalDealDetails.Input;
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
    /// 客户在院消费详情板块数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class CustomerHospitalDealDetailsController : ControllerBase
    {
        private ICustomerHospitalDealDetailsService customerHospitalDealDetailsService;
        private IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="customerHospitalDealDetailsService"></param>
        public CustomerHospitalDealDetailsController(ICustomerHospitalDealDetailsService customerHospitalDealDetailsService, IHttpContextAccessor httpContextAccessor)
        {
            this.customerHospitalDealDetailsService = customerHospitalDealDetailsService;
            _httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// 获取客户在院消费详情信息列表（分页）
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<CustomerHospitalDealDetailsVo>>> GetListWithPageAsync([FromQuery] QueryCustomerHospitalDealDetailsPageListVo query)
        {
            try
            {
                var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                QueryCustomerHospitalDealDetailsPageListDto queryCustomerAppointSchedulePageListDto = new QueryCustomerHospitalDealDetailsPageListDto();
                queryCustomerAppointSchedulePageListDto.CustomerHospitalDealId = query.CustomerHospitalDealId;
                queryCustomerAppointSchedulePageListDto.KeyWord = query.KeyWord;
                queryCustomerAppointSchedulePageListDto.CreateBy = employeeId;
                queryCustomerAppointSchedulePageListDto.StartDate = query.StartDate;
                queryCustomerAppointSchedulePageListDto.EndDate = query.EndDate;
                queryCustomerAppointSchedulePageListDto.PageNum = query.PageNum;
                queryCustomerAppointSchedulePageListDto.PageSize = query.PageSize;
                var q = await customerHospitalDealDetailsService.GetListWithPageAsync(queryCustomerAppointSchedulePageListDto);

                var customerHospitalDealDetails = from d in q.List
                                                  select new CustomerHospitalDealDetailsVo
                                                  {
                                                      Id = d.Id,
                                                      CustomerHospitalDealId = d.CustomerHospitalDealId,
                                                      ItemName = d.ItemName,
                                                      ItemStandard = d.ItemStandard,
                                                      Quantity = d.Quantity,
                                                      CashAmount = d.CashAmount,
                                                      CreateDate = d.CreateDate,
                                                  };

                FxPageInfo<CustomerHospitalDealDetailsVo> customerHospitalDealDetailsPageDetails = new FxPageInfo<CustomerHospitalDealDetailsVo>();
                customerHospitalDealDetailsPageDetails.TotalCount = q.TotalCount;
                customerHospitalDealDetailsPageDetails.List = customerHospitalDealDetails;

                return ResultData<FxPageInfo<CustomerHospitalDealDetailsVo>>.Success().AddData("customerHospitalDealDetailsDetails", customerHospitalDealDetailsPageDetails);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<CustomerHospitalDealDetailsVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 根据客户在院消费id集合获取客户在院消费详情信息列表（分页）
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("listByIdsWithPage")]
        public async Task<ResultData<FxPageInfo<CustomerHospitalDealDetailsVo>>> GetListByIdsWithPageAsync([FromQuery] QueryCustomerHospitalDealDetailsByIdsPageListVo query)
        {
            try
            {
                var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                QueryCustomerHospitalDealDetailsByIdsPageListDto queryCustomerAppointSchedulePageListDto = new QueryCustomerHospitalDealDetailsByIdsPageListDto();
                queryCustomerAppointSchedulePageListDto.CustomerHospitalDealIds = query.CustomerHospitalDealIds.Split(",").ToList();
                queryCustomerAppointSchedulePageListDto.KeyWord = query.KeyWord;
                queryCustomerAppointSchedulePageListDto.CreateBy = employeeId;
                queryCustomerAppointSchedulePageListDto.StartDate = query.StartDate;
                queryCustomerAppointSchedulePageListDto.EndDate = query.EndDate;
                queryCustomerAppointSchedulePageListDto.PageNum = query.PageNum;
                queryCustomerAppointSchedulePageListDto.PageSize = query.PageSize;
                var q = await customerHospitalDealDetailsService.GetListByIdsWithPageAsync(queryCustomerAppointSchedulePageListDto);

                var customerHospitalDealDetails = from d in q.List
                                                  select new CustomerHospitalDealDetailsVo
                                                  {
                                                      Id = d.Id,
                                                      CustomerHospitalDealId = d.CustomerHospitalDealId,
                                                      ItemName = d.ItemName,
                                                      ItemStandard = d.ItemStandard,
                                                      Quantity = d.Quantity,
                                                      CashAmount = d.CashAmount,
                                                      CreateDate = d.CreateDate,
                                                  };

                FxPageInfo<CustomerHospitalDealDetailsVo> customerHospitalDealDetailsPageDetails = new FxPageInfo<CustomerHospitalDealDetailsVo>();
                customerHospitalDealDetailsPageDetails.TotalCount = q.TotalCount;
                customerHospitalDealDetailsPageDetails.List = customerHospitalDealDetails;

                return ResultData<FxPageInfo<CustomerHospitalDealDetailsVo>>.Success().AddData("customerHospitalDealDetailsDetails", customerHospitalDealDetailsPageDetails);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<CustomerHospitalDealDetailsVo>>.Fail(ex.Message);
            }
        }


    }
}
