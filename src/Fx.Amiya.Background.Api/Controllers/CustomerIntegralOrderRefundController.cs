using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.CustomerIntegralOrderRefund;
using Fx.Amiya.Background.Api.Vo.ExpressInfo;
using Fx.Amiya.Core.Dto.Integration;
using Fx.Amiya.Core.Interfaces.Integration;
using Fx.Amiya.Dto.CustomerIntegralOrderRefunds;
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
    /// 小程序积分退款板块数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class CustomerIntegralOrderRefundController : ControllerBase
    {
        private ICustomerIntegralOrderRefundService customerIntegralOrderRefundService;
        private IHttpContextAccessor httpContextAccessor;
        private IIntegrationAccount _integrationAccountService;
        private IOrderService _orderService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="customerIntegralOrderRefundService"></param>
        public CustomerIntegralOrderRefundController(ICustomerIntegralOrderRefundService customerIntegralOrderRefundService,
            IOrderService orderService,
            IIntegrationAccount integrationAccountService,
            IHttpContextAccessor httpContextAccessor)
        {
            this.customerIntegralOrderRefundService = customerIntegralOrderRefundService;
            _orderService = orderService;
            this.httpContextAccessor = httpContextAccessor;
            _integrationAccountService = integrationAccountService;
        }


        /// <summary>
        /// 获取小程序积分退款信息列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="checkState">审核状态，空查询全部</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<CustomerIntegralOrderRefundsVo>>> GetListWithPageAsync(string keyword, int? checkState, int pageNum, int pageSize)
        {
            try
            {
                var q = await customerIntegralOrderRefundService.GetListWithPageAsync(keyword, checkState, pageNum, pageSize);

                var customerIntegralOrderRefund = from d in q.List
                                                  select new CustomerIntegralOrderRefundsVo
                                                  {
                                                      Id = d.Id,
                                                      OrderId = d.OrderId,
                                                      CustomerId = d.CustomerId,
                                                      RefundReasong = d.RefundReasong,
                                                      CreateDate = d.CreateDate,
                                                      CheckStateText = d.CheckStateText,
                                                      CheckDate = d.CheckDate,
                                                      CheckByEmpName = d.CheckByEmpName,
                                                      CheckReason = d.CheckReason
                                                  };

                FxPageInfo<CustomerIntegralOrderRefundsVo> customerIntegralOrderRefundPageInfo = new FxPageInfo<CustomerIntegralOrderRefundsVo>();
                customerIntegralOrderRefundPageInfo.TotalCount = q.TotalCount;
                customerIntegralOrderRefundPageInfo.List = customerIntegralOrderRefund;

                return ResultData<FxPageInfo<CustomerIntegralOrderRefundsVo>>.Success().AddData("customerIntegralOrderRefundInfo", customerIntegralOrderRefundPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<CustomerIntegralOrderRefundsVo>>.Fail(ex.Message);
            }
        }





        /// <summary>
        /// 根据小程序积分退款编号获取小程序积分退款信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<CustomerIntegralOrderRefundsVo>> GetByIdAsync(string id)
        {
            try
            {
                var customerIntegralOrderRefund = await customerIntegralOrderRefundService.GetByIdAsync(id);
                CustomerIntegralOrderRefundsVo customerIntegralOrderRefundVo = new CustomerIntegralOrderRefundsVo();
                customerIntegralOrderRefundVo.Id = customerIntegralOrderRefund.Id;
                customerIntegralOrderRefundVo.OrderId = customerIntegralOrderRefund.OrderId;
                customerIntegralOrderRefundVo.CustomerId = customerIntegralOrderRefund.CustomerId;
                customerIntegralOrderRefundVo.RefundReasong = customerIntegralOrderRefund.RefundReasong;
                customerIntegralOrderRefundVo.CreateDate = customerIntegralOrderRefund.CreateDate;
                customerIntegralOrderRefundVo.CheckState = customerIntegralOrderRefund.CheckState;
                customerIntegralOrderRefundVo.CheckStateText = customerIntegralOrderRefund.CheckStateText;
                customerIntegralOrderRefundVo.CheckDate = customerIntegralOrderRefund.CheckDate;
                customerIntegralOrderRefundVo.CheckBy = customerIntegralOrderRefund.CheckBy;
                customerIntegralOrderRefundVo.CheckReason = customerIntegralOrderRefund.CheckReason;

                return ResultData<CustomerIntegralOrderRefundsVo>.Success().AddData("customerIntegralOrderRefundInfo", customerIntegralOrderRefundVo);
            }
            catch (Exception ex)
            {
                return ResultData<CustomerIntegralOrderRefundsVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 客户积分订单退款审核
        /// </summary>
        /// <param name="checkDto">输入参数</param>
        /// <returns></returns>
        [HttpPost("Refund")]
        public async Task<ResultData> IntegrationPayRefundAsync(CustomerIntegralOrderRefundCheckVo checkDto)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);

            CustomerIntegralOrderRefundCheckDto consumptionIntegrationCheck = new CustomerIntegralOrderRefundCheckDto();
            consumptionIntegrationCheck.CheckBy = employeeId;
            consumptionIntegrationCheck.Id = checkDto.Id;
            consumptionIntegrationCheck.CheckReason = checkDto.CheckReason;
            consumptionIntegrationCheck.CheckState = checkDto.CheckState;
            await customerIntegralOrderRefundService.CheckAsync(consumptionIntegrationCheck);
            return ResultData.Success();
        }

        /// <summary>
        /// 删除小程序积分退款信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await customerIntegralOrderRefundService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 所有客户积分过期
        /// </summary>
        /// <returns></returns>
        [HttpGet("expiredCustomerIntergration")]
        public async Task<ResultData> ExpiredCustomerIntegration()
        {
            await _integrationAccountService.ExpiredGoodsConsumption();
            return ResultData.Success();
        }

    }
}
