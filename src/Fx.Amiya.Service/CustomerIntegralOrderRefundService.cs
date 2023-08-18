using Fx.Amiya.Core.Dto.Integration;
using Fx.Amiya.Core.Interfaces.Goods;
using Fx.Amiya.Core.Interfaces.Integration;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.CustomerIntegralOrderRefunds;
using Fx.Amiya.Dto.TmallOrder;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Fx.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class CustomerIntegralOrderRefundService : ICustomerIntegralOrderRefundService
    {
        private IDalCustomerIntegralOrderRefund dalCustomerIntegralOrderRefund;
        private IDalAmiyaEmployee dalAmiyaEmployee;
        private IUnitOfWork unitOfWork;
        private IIntegrationAccount _interGrationAccountService;
        private IOrderService _orderService;
        private IDalOrderTrade _orderTrade;
        private IGoodsInfo goodsInfoService;

        public CustomerIntegralOrderRefundService(IDalCustomerIntegralOrderRefund dalCustomerIntegralOrderRefunds,
               IUnitOfWork unitOfWork,
            IDalAmiyaEmployee dalAmiyaEmployee,
            IIntegrationAccount interGrationAccountService,
            IOrderService orderService, IDalOrderTrade orderTrade, IGoodsInfo goodsInfoService)
        {
            this.dalCustomerIntegralOrderRefund = dalCustomerIntegralOrderRefunds;
            this.dalAmiyaEmployee = dalAmiyaEmployee;
            this.unitOfWork = unitOfWork;
            _interGrationAccountService = interGrationAccountService;
            _orderService = orderService;
            _orderTrade = orderTrade;
            this.goodsInfoService = goodsInfoService;
        }



        public async Task<FxPageInfo<CustomerIntegralOrderRefundsDto>> GetListWithPageAsync(string keyword, int? checkState, int pageNum, int pageSize)
        {
            try
            {
                var customerIntegralOrderRefund = from d in dalCustomerIntegralOrderRefund.GetAll()
                                                  where (keyword == null || d.OrderId.Contains(keyword))
                                                  && (checkState == null || d.CheckState == checkState)
                                                  select new CustomerIntegralOrderRefundsDto
                                                  {
                                                      Id = d.Id,
                                                      OrderId = d.OrderId,
                                                      CustomerId = d.CustomerId,
                                                      RefundReasong = d.RefundReasong,
                                                      CreateDate = d.CreateDate,
                                                      CheckState = d.CheckState,
                                                      CheckStateText = ServiceClass.GetCheckTypeText(d.CheckState),
                                                      CheckDate = d.CheckDate,
                                                      CheckBy = d.CheckBy,
                                                      CheckReason = d.CheckReason
                                                  };

                FxPageInfo<CustomerIntegralOrderRefundsDto> customerIntegralOrderRefundPageInfo = new FxPageInfo<CustomerIntegralOrderRefundsDto>();
                customerIntegralOrderRefundPageInfo.TotalCount = await customerIntegralOrderRefund.CountAsync();
                customerIntegralOrderRefundPageInfo.List = await customerIntegralOrderRefund.OrderByDescending(x=>x.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
                foreach (var x in customerIntegralOrderRefundPageInfo.List)
                {
                    if (x.CheckBy != 0)
                    {
                        var employeeInfo = dalAmiyaEmployee.GetAll().FirstOrDefaultAsync(z => z.Id == x.CheckBy);
                        if (employeeInfo.Result != null)
                        {
                            x.CheckByEmpName = employeeInfo.Result.Name;
                        }
                        else
                        {
                            x.CheckByEmpName = "";
                        }
                    }
                }
                return customerIntegralOrderRefundPageInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        public async Task AddAsync(AddCustomerIntegralOrderRefundsDto addDto)
        {
            try
            {
                var customerIntegralOrderRefundResult = await this.GetByOrderIdAsync(addDto.OrderId);
                if (!string.IsNullOrEmpty(customerIntegralOrderRefundResult.OrderId))
                { 
                    throw new Exception("该订单已提交过退款申请，无法重复提交！");
                }
                CustomerIntegralOrderRefund customerIntegralOrderRefund = new CustomerIntegralOrderRefund();
                customerIntegralOrderRefund.Id = Guid.NewGuid().ToString();
                customerIntegralOrderRefund.OrderId = addDto.OrderId;
                customerIntegralOrderRefund.CustomerId = addDto.CustomerId;
                customerIntegralOrderRefund.RefundReasong = addDto.RefundReasong;
                customerIntegralOrderRefund.CreateDate = DateTime.Now;
                customerIntegralOrderRefund.CheckState = (int)CheckType.NotChecked;
                customerIntegralOrderRefund.CheckBy = 0;
                customerIntegralOrderRefund.CheckReason = "";
                await dalCustomerIntegralOrderRefund.AddAsync(customerIntegralOrderRefund, true);
                //修改订单状态
                var orderInfo = await _orderService.GetByIdAsync(addDto.OrderId);
                List<UpdateOrderDto> updateOrderList = new List<UpdateOrderDto>();
                UpdateOrderDto updateOrderDto = new UpdateOrderDto();
                updateOrderDto.OrderId = customerIntegralOrderRefund.OrderId;
                updateOrderDto.AppType = orderInfo.AppType;
                updateOrderDto.StatusCode = OrderStatusCode.REFUNDING;
                updateOrderDto.IntergrationQuantity = orderInfo.IntegrationQuantity;
                updateOrderList.Add(updateOrderDto);
                await _orderService.UpdateAsync(updateOrderList);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task AddByTradeAsync(AddCustomerIntegralOrderRefundsDto addDto)
        {
            try {
                var orderTradeResult = _orderTrade.GetAll().Where(o => o.TradeId == addDto.TradeId).Include(e=>e.OrderInfoList).SingleOrDefault();
                if (orderTradeResult == null) {
                    throw new Exception("交易不存在");
                }
                if (orderTradeResult.OrderInfoList.Count<=0) {
                    throw new Exception("订单不存在");
                }
                List<UpdateOrderDto> updateOrderList = new List<UpdateOrderDto>();
                foreach (var item in orderTradeResult.OrderInfoList) {
                    if (item.StatusCode==OrderStatusCode.REFUNDING) {
                        throw new Exception("该订单已提交过退款申请，无法重复提交！");
                    }
                    CustomerIntegralOrderRefund customerIntegralOrderRefund = new CustomerIntegralOrderRefund();
                    customerIntegralOrderRefund.Id = Guid.NewGuid().ToString();
                    customerIntegralOrderRefund.OrderId = item.Id;
                    customerIntegralOrderRefund.CustomerId = addDto.CustomerId;
                    customerIntegralOrderRefund.RefundReasong = addDto.RefundReasong;
                    customerIntegralOrderRefund.CreateDate = DateTime.Now;
                    customerIntegralOrderRefund.CheckState = (int)CheckType.NotChecked;
                    customerIntegralOrderRefund.CheckBy = 0;
                    customerIntegralOrderRefund.CheckReason = "";
                    await dalCustomerIntegralOrderRefund.AddAsync(customerIntegralOrderRefund, true);
                    //修改订单状态
                    UpdateOrderDto updateOrderDto = new UpdateOrderDto();
                    updateOrderDto.OrderId = customerIntegralOrderRefund.OrderId;
                    updateOrderDto.AppType = item.AppType;
                    updateOrderDto.StatusCode = OrderStatusCode.REFUNDING;
                    updateOrderDto.IntergrationQuantity = item.IntegrationQuantity;
                    updateOrderList.Add(updateOrderDto);
                }
                await _orderService.UpdateAsync(updateOrderList);
            } catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<CustomerIntegralOrderRefundsDto> GetByIdAsync(string id)
        {
            try
            {
                var customerIntegralOrderRefund = await dalCustomerIntegralOrderRefund.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (customerIntegralOrderRefund == null)
                {
                    throw new Exception("退款编号错误，请核对后重试！");
                }

                CustomerIntegralOrderRefundsDto customerIntegralOrderRefundDto = new CustomerIntegralOrderRefundsDto();
                customerIntegralOrderRefundDto.Id = customerIntegralOrderRefund.Id;
                customerIntegralOrderRefundDto.OrderId = customerIntegralOrderRefund.OrderId;
                customerIntegralOrderRefundDto.CustomerId = customerIntegralOrderRefund.CustomerId;
                customerIntegralOrderRefundDto.RefundReasong = customerIntegralOrderRefund.RefundReasong;
                customerIntegralOrderRefundDto.CreateDate = customerIntegralOrderRefund.CreateDate;
                customerIntegralOrderRefundDto.CheckState = customerIntegralOrderRefund.CheckState;
                customerIntegralOrderRefundDto.CheckStateText = ServiceClass.GetCheckTypeText(customerIntegralOrderRefund.CheckState);
                customerIntegralOrderRefundDto.CheckDate = customerIntegralOrderRefund.CheckDate;
                customerIntegralOrderRefundDto.CheckBy = customerIntegralOrderRefund.CheckBy;
                customerIntegralOrderRefundDto.CheckReason = customerIntegralOrderRefund.CheckReason;

                return customerIntegralOrderRefundDto;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<CustomerIntegralOrderRefundsDto> GetByOrderIdAsync(string orderId)
        {
            try
            {
                var customerIntegralOrderRefund = await dalCustomerIntegralOrderRefund.GetAll().SingleOrDefaultAsync(e => e.OrderId == orderId);
                CustomerIntegralOrderRefundsDto customerIntegralOrderRefundDto = new CustomerIntegralOrderRefundsDto();
                if (customerIntegralOrderRefund == null)
                {
                    customerIntegralOrderRefundDto.Id = "";
                    customerIntegralOrderRefundDto.OrderId = "";
                    customerIntegralOrderRefundDto.CustomerId = "";
                    customerIntegralOrderRefundDto.RefundReasong = "";
                    customerIntegralOrderRefundDto.CreateDate = DateTime.Now;
                    customerIntegralOrderRefundDto.CheckState =0;
                    customerIntegralOrderRefundDto.CheckStateText = "";
                    customerIntegralOrderRefundDto.CheckDate =DateTime.Now;
                    customerIntegralOrderRefundDto.CheckBy = 0;
                    customerIntegralOrderRefundDto.CheckReason = "";
                    return customerIntegralOrderRefundDto;
                }

                customerIntegralOrderRefundDto.Id = customerIntegralOrderRefund.Id;
                customerIntegralOrderRefundDto.OrderId = customerIntegralOrderRefund.OrderId;
                customerIntegralOrderRefundDto.CustomerId = customerIntegralOrderRefund.CustomerId;
                customerIntegralOrderRefundDto.RefundReasong = customerIntegralOrderRefund.RefundReasong;
                customerIntegralOrderRefundDto.CreateDate = customerIntegralOrderRefund.CreateDate;
                customerIntegralOrderRefundDto.CheckState = customerIntegralOrderRefund.CheckState;
                customerIntegralOrderRefundDto.CheckStateText = ServiceClass.GetCheckTypeText(customerIntegralOrderRefund.CheckState);
                customerIntegralOrderRefundDto.CheckDate = customerIntegralOrderRefund.CheckDate;
                customerIntegralOrderRefundDto.CheckBy = customerIntegralOrderRefund.CheckBy;
                customerIntegralOrderRefundDto.CheckReason = customerIntegralOrderRefund.CheckReason;

                return customerIntegralOrderRefundDto;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task UpdateAsync(string id, string refundReason)
        {
            try
            {
                var customerIntegralOrderRefund = await dalCustomerIntegralOrderRefund.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (customerIntegralOrderRefund == null)
                    throw new Exception("退款编号错误，请联系管理员！");

                customerIntegralOrderRefund.RefundReasong = refundReason;
                await dalCustomerIntegralOrderRefund.UpdateAsync(customerIntegralOrderRefund, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task CheckAsync(CustomerIntegralOrderRefundCheckDto updateDto)
        {

            try
            {
                //退款审核功能更新状态
                var customerIntegralOrderRefund = await dalCustomerIntegralOrderRefund.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (customerIntegralOrderRefund == null)
                    throw new Exception("退款编号错误，请联系管理员！");

                customerIntegralOrderRefund.CheckState = updateDto.CheckState;
                customerIntegralOrderRefund.CheckBy = updateDto.CheckBy;
                customerIntegralOrderRefund.CheckReason = updateDto.CheckReason;
                customerIntegralOrderRefund.CheckDate = DateTime.Now;
                await dalCustomerIntegralOrderRefund.UpdateAsync(customerIntegralOrderRefund, true);
                ConsumptionIntegrationDto updateIntegrationDto = new ConsumptionIntegrationDto();

                var orderInfo = await _orderService.GetByIdAsync(customerIntegralOrderRefund.OrderId);
                await goodsInfoService.AddGoodsInventoryQuantityAsync(orderInfo.GoodsId, (int)orderInfo.Quantity);
                if (updateDto.CheckState == (int)CheckType.CheckedSuccess)
                {
                    //积分返还，新增积分情况
                    updateIntegrationDto.Quantity = orderInfo.IntegrationQuantity.Value;
                    updateIntegrationDto.Percent = 0.00M;
                    updateIntegrationDto.AmountOfConsumption = 0.00M;
                    updateIntegrationDto.OrderId = customerIntegralOrderRefund.OrderId;
                    updateIntegrationDto.Date = DateTime.Now;
                    updateIntegrationDto.CustomerId = customerIntegralOrderRefund.CustomerId;
                    updateIntegrationDto.HandleBy = updateDto.CheckBy;
                    await _interGrationAccountService.ReturnByConsumptionAsync(updateIntegrationDto);

                    //修改订单
                    List<UpdateOrderDto> updateOrderList = new List<UpdateOrderDto>();
                    UpdateOrderDto updateOrderDto = new UpdateOrderDto();
                    updateOrderDto.OrderId = customerIntegralOrderRefund.OrderId;
                    updateOrderDto.AppType = orderInfo.AppType;
                    updateOrderDto.StatusCode = OrderStatusCode.TRADE_CLOSED;
                    updateOrderDto.IntergrationQuantity = orderInfo.IntegrationQuantity;
                    updateOrderList.Add(updateOrderDto);
                    await _orderService.UpdateAsync(updateOrderList);
                }
                else if (updateDto.CheckState == (int)CheckType.CheckNotPassed)
                {
                    //修改订单
                    List<UpdateOrderDto> updateOrderList = new List<UpdateOrderDto>();
                    UpdateOrderDto updateOrderDto = new UpdateOrderDto();
                    updateOrderDto.OrderId = customerIntegralOrderRefund.OrderId;
                    updateOrderDto.AppType = orderInfo.AppType;
                    updateOrderDto.StatusCode = OrderStatusCode.WAIT_BUYER_CONFIRM_GOODS;
                    updateOrderDto.IntergrationQuantity = orderInfo.IntegrationQuantity;
                    updateOrderList.Add(updateOrderDto);
                    await _orderService.UpdateAsync(updateOrderList);
                }
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                var customerIntegralOrderRefund = await dalCustomerIntegralOrderRefund.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (customerIntegralOrderRefund == null)
                    throw new Exception("退款编号错误，请联系管理员！");

                await dalCustomerIntegralOrderRefund.DeleteAsync(customerIntegralOrderRefund, true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        
    }
}
