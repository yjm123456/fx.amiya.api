using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo.ContentPlateFormOrder;
using Fx.Amiya.Background.Api.Vo.Order;
using Fx.Amiya.Background.Api.Vo.OrderCheck;
using Fx.Amiya.Core.Dto.Integration;
using Fx.Amiya.Core.Interfaces.Goods;
using Fx.Amiya.Core.Interfaces.Integration;
using Fx.Amiya.Core.Interfaces.MemberCard;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.ContentPlateFormOrder;
using Fx.Amiya.Dto.TmallOrder;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Amiya.Service;
using Fx.Amiya.SyncOrder.Core;
using Fx.Amiya.SyncOrder.Tmall;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Infrastructure;
using Fx.Infrastructure.Utils;
using Fx.Open.Infrastructure.Web;
using Jd.Api.Util;
using jos_sdk_net.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 订单 API
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class OrderController : ControllerBase
    {
        private IOrderService orderService;
        private IHttpContextAccessor httpContextAccessor;
        private IGoodsInfo goodsInfoService;
        private IDalBindCustomerService _dalBindCustomerService;
        private IMemberCard memberCardService;
        private ISyncOrder syncOrder;
        private ICustomerService customerService;
        private IIntegrationAccount integrationAccountService;
        private IExpressManageService _expressManageService;
        private IAmiyaGoodsDemandService _amiyaGoodsDemandService;
        private IMemberRankInfo memberRankInfoService;
        public OrderController(IOrderService orderService,
            ISyncOrder syncOrder,
            ICustomerService customerService,
            IHttpContextAccessor httpContextAccessor,
             IMemberCard memberCardService,
            IGoodsInfo goodsInfoService,
            IIntegrationAccount integrationAccountService,
            IDalBindCustomerService dalBindCustomerService,
            IExpressManageService expressManageService,
            IAmiyaGoodsDemandService amiyaGoodsDemandService,
             IMemberRankInfo memberRankInfoService)
        {
            this.orderService = orderService;
            this.syncOrder = syncOrder;
            this.memberCardService = memberCardService;
            this.customerService = customerService;
            this.httpContextAccessor = httpContextAccessor;
            this.goodsInfoService = goodsInfoService;
            this.integrationAccountService = integrationAccountService;
            _dalBindCustomerService = dalBindCustomerService;
            _expressManageService = expressManageService;
            this.memberRankInfoService = memberRankInfoService;
            _amiyaGoodsDemandService = amiyaGoodsDemandService;
        }

        /// <summary>
        /// 录单
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("EntryOrder")]
        public async Task<ResultData> EntryOrderAsync(OrderInfoAddVo addVo)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            //验证手机号是否有归属
            if (string.IsNullOrEmpty(addVo.Phone))
            {
                throw new Exception("该订单没有手机号，不能绑定客服");
            }
            //if (employee.PositionName == "客服" || employee.PositionName == "客服管理员" || employee.PositionName == "客服主管" || employee.PositionName == "财务")
            //{
            var bind = await _dalBindCustomerService.GetAll()
          .Include(e => e.CustomerServiceAmiyaEmployee)
          .SingleOrDefaultAsync(e => e.BuyerPhone == addVo.Phone);
            if (bind != null)
            {
                if (bind.CustomerServiceId != employeeId)
                {
                    throw new Exception("该客户已绑定给" + bind.CustomerServiceAmiyaEmployee.Name + ",请联系对应客人员进行录单！");
                }
                else
                {
                    bind.NewConsumptionDate = DateTime.Now;
                    bind.NewConsumptionContentPlatform = (int)OrderFrom.ThirdPartyOrder;
                    bind.NewContentPlatForm = ServiceClass.GetAppTypeText(addVo.AppType);
                    await _dalBindCustomerService.UpdateAsync(bind, true);
                }

            }
            else
            {
                //添加绑定客服
                BindCustomerService bindCustomerService = new BindCustomerService();
                bindCustomerService.CustomerServiceId = employeeId;
                bindCustomerService.BuyerPhone = addVo.Phone;
                bindCustomerService.UserId = null;
                bindCustomerService.CreateBy = employeeId;
                bindCustomerService.CreateDate = DateTime.Now;
                var goodsInfo = await _amiyaGoodsDemandService.GetByIdAsync(addVo.GoodsId);
                bindCustomerService.FirstProjectDemand = "(" + goodsInfo.HospitalDepartmentName + ")" + goodsInfo.ProjectNname;
                bindCustomerService.FirstConsumptionDate = DateTime.Now;
                bindCustomerService.NewConsumptionDate = DateTime.Now;
                bindCustomerService.NewConsumptionContentPlatform = (int)OrderFrom.ThirdPartyOrder;
                bindCustomerService.NewContentPlatForm = ServiceClass.GetAppTypeText(addVo.AppType);
                await _dalBindCustomerService.AddAsync(bindCustomerService, true);
            }
            //}

            //添加订单
            List<OrderInfoAddDto> amiyaOrderList = new List<OrderInfoAddDto>();
            OrderInfoAddDto addDto = new OrderInfoAddDto();
            addDto.Id = CreateOrderIdHelper.GetNextNumber();
            addDto.GoodsName = addVo.GoodsName;
            addDto.GoodsId = addVo.GoodsId;
            addDto.Phone = addVo.Phone;
            addDto.IsAppointment = addVo.IsAppointment;
            addDto.AppointmentCity = addVo.AppointmentCity;
            addDto.AppointmentDate = addVo.AppointmentDate;
            addDto.AppointmentHospital = addVo.AppointmentHospital;
            addDto.StatusCode = addVo.StatusCode;
            addDto.ActualPayment = addVo.ActualPayment;
            addDto.OrderNature = addVo.OrderNature;
            addDto.CreateDate = DateTime.Now;
            var demand = await _amiyaGoodsDemandService.GetByIdAsync(addVo.GoodsId);
            addDto.ThumbPicUrl = demand.ThumbPictureUrl;
            addDto.BuyerNick = addVo.BuyerNick;
            addDto.AppType = addVo.AppType;
            addDto.BuyerNick = addVo.BuyerNick;
            addDto.OrderType = (addVo.OrderType.HasValue) ? addVo.OrderType.Value : (byte)0;
            addDto.Quantity = (addVo.Quantity.HasValue) ? addVo.Quantity : 0;
            addDto.IntegrationQuantity = 0;
            addDto.ExchangeType = addVo.ExchangeType;
            addDto.BelongEmpId = employeeId;
            addDto.Description = addVo.Remark;
            amiyaOrderList.Add(addDto);
            OrderTradeAddDto orderTradeAdd = new OrderTradeAddDto();
            orderTradeAdd.CustomerId = "客服-" + employee.ToString();
            orderTradeAdd.CreateDate = DateTime.Now;
            orderTradeAdd.AddressId = 0;
            //orderTradeAdd.Remark = addVo.Remark;
            orderTradeAdd.OrderInfoAddList = amiyaOrderList;
            orderTradeAdd.IsAdminAdd = true;
            await orderService.AddAmiyaOrderAsync(orderTradeAdd);
            return ResultData.Success();
        }

        /// <summary>
        /// 根据订单号查询要补单的信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("repairOrder")]
        public async Task<ResultData<OrderInfoVo>> RepairOrder(RepairOrderVo input)
        {
            OrderInfoVo result = new OrderInfoVo();
            if (input.OrderAppType == (byte)AppType.Tmall)
            {
                var amiyaOrder = await syncOrder.TranslateTradesSoldOrdersByOrderId(Convert.ToInt64(input.OrderId));
                var FirstOrder = amiyaOrder.FirstOrDefault();
                if (FirstOrder == null)
                {
                    throw new Exception("未找到对应的订单，请核对订单号后重试");
                }
                result.Id = FirstOrder.Id;
                result.GoodsName = FirstOrder.GoodsName;
                result.GoodsId = FirstOrder.GoodsId;
                result.Phone = FirstOrder.Phone;
                result.AppointmentHospital = FirstOrder.AppointmentHospital;
                result.StatusCode = FirstOrder.StatusCode;
                result.ActualPayment = FirstOrder.ActualPayment;
                result.AccountReceivable = FirstOrder.AccountReceivable;
                result.NickName = FirstOrder.BuyerNick;
                result.AppType = input.OrderAppType;
                result.IsAppointment = FirstOrder.IsAppointment;
                result.OrderType = FirstOrder.OrderType;
                result.OrderNature = 0;
                result.Quantity = FirstOrder.Quantity;
                result.ThumbPicUrl = FirstOrder.ThumbPicUrl;
                result.CreateDate = FirstOrder.CreateDate;
            }
            else
            {
                throw new Exception("暂未开放天猫以外补单接口，敬请期待！");
            }
            return ResultData<OrderInfoVo>.Success().AddData("orderData", result);
        }

        /// <summary>
        /// 补单
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("AddOrder")]
        public async Task<ResultData> AddOrderAsync(OrderInfoAddVo addVo)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            //验证手机号是否有归属
            if (string.IsNullOrEmpty(addVo.Phone))
            {
                throw new Exception("该订单没有手机号，不能绑定客服");
            }

            var bind = await _dalBindCustomerService.GetAll()
              .Include(e => e.CustomerServiceAmiyaEmployee)
              .SingleOrDefaultAsync(e => e.BuyerPhone == addVo.Phone);
            if (bind != null)
            {
                if (bind.CustomerServiceId != employeeId)
                    throw new Exception("该客户已绑定给" + bind.CustomerServiceAmiyaEmployee.Name + ",请联系对应人员进行补单！");
            }
            else
            {
                //添加绑定客服
                BindCustomerService bindCustomerService = new BindCustomerService();
                bindCustomerService.CustomerServiceId = employeeId;
                bindCustomerService.BuyerPhone = addVo.Phone;
                bindCustomerService.UserId = null;
                bindCustomerService.CreateBy = employeeId;
                bindCustomerService.CreateDate = DateTime.Now;
                await _dalBindCustomerService.AddAsync(bindCustomerService, true);
            }
            //添加订单
            List<OrderInfoAddDto> amiyaOrderList = new List<OrderInfoAddDto>();
            OrderInfoAddDto addDto = new OrderInfoAddDto();
            addDto.Id = addVo.OrderId;
            addDto.GoodsName = addVo.GoodsName;
            addDto.GoodsId = addVo.GoodsId;
            addDto.Phone = addVo.Phone;
            addDto.AppointmentHospital = addVo.AppointmentHospital;
            addDto.StatusCode = addVo.StatusCode;
            addDto.ActualPayment = addVo.ActualPayment;
            addDto.AccountReceivable = addVo.AccountReceivable;
            addDto.CreateDate = DateTime.Now;
            addDto.ThumbPicUrl = addVo.ThumbPictureUrl;
            addDto.BuyerNick = addVo.BuyerNick;
            addDto.AppType = addVo.AppType;
            addDto.BuyerNick = addVo.BuyerNick;
            addDto.IsAppointment = addVo.IsAppointment;
            addDto.BelongEmpId = employeeId;
            addDto.OrderType = (addVo.OrderType.HasValue) ? addVo.OrderType.Value : (byte)0;
            addDto.OrderNature = (addVo.OrderNature.HasValue) ? addVo.OrderNature.Value : (byte)0;
            addDto.Quantity = (addVo.Quantity.HasValue) ? addVo.Quantity : 0;
            addDto.IntegrationQuantity = 0;
            addDto.ExchangeType = addVo.ExchangeType;
            amiyaOrderList.Add(addDto);
            OrderTradeAddDto orderTradeAdd = new OrderTradeAddDto();
            orderTradeAdd.CustomerId = "客服-" + employee.Name.ToString();
            orderTradeAdd.CreateDate = addVo.CreateDate.Value;
            orderTradeAdd.AddressId = 0;
            orderTradeAdd.Remark = addVo.Remark;
            orderTradeAdd.OrderInfoAddList = amiyaOrderList;
            orderTradeAdd.IsAdminAdd = true;
            await orderService.AddAmiyaOrderAsync(orderTradeAdd);
            List<ConsumptionIntegrationDto> consumptionIntegrationList = new List<ConsumptionIntegrationDto>();
            if (addVo.StatusCode == "TRADE_FINISHED" && addVo.ActualPayment >= 1 && !string.IsNullOrWhiteSpace(addVo.Phone))
            {

                bool isIntegrationGenerateRecord = await integrationAccountService.GetIsIntegrationGenerateRecordByOrderIdAsync(addVo.OrderId);
                if (isIntegrationGenerateRecord != true)
                {

                    var customerId = await customerService.GetCustomerIdByPhoneAsync(addVo.Phone);
                    if (!string.IsNullOrWhiteSpace(customerId))
                    {

                        ConsumptionIntegrationDto consumptionIntegration = new ConsumptionIntegrationDto();
                        consumptionIntegration.CustomerId = customerId;
                        consumptionIntegration.OrderId = addVo.OrderId;
                        consumptionIntegration.AmountOfConsumption = (decimal)addVo.ActualPayment;
                        consumptionIntegration.Date = DateTime.Now;

                        var memberCard = await memberCardService.GetMemberCardHandelByCustomerIdAsync(customerId);
                        if (memberCard != null)
                        {
                            consumptionIntegration.Quantity = Math.Floor(memberCard.GenerateIntegrationPercent * (decimal)addVo.ActualPayment);
                            consumptionIntegration.Percent = memberCard.GenerateIntegrationPercent;
                        }
                        else
                        {
                            var memberRank = await memberRankInfoService.GetMinGeneratePercentMemberRankInfoAsync();
                            consumptionIntegration.Quantity = Math.Floor(memberRank.GenerateIntegrationPercent * (decimal)addVo.ActualPayment);
                            consumptionIntegration.Percent = memberRank.GenerateIntegrationPercent;

                        }

                        if (consumptionIntegration.Quantity > 0)
                            consumptionIntegrationList.Add(consumptionIntegration);

                    }
                }
            }

            foreach (var item in consumptionIntegrationList)
            {
                await integrationAccountService.AddByConsumptionAsync(item);
            }
            return ResultData.Success();
        }

        /// <summary>
        /// 订单校对
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("CheckOrder")]
        public async Task<ResultData> CheckOrderAsync(RepairOrderVo input)
        {
            OrderInfoVo result = new OrderInfoVo();
            if (input.OrderAppType == (byte)AppType.Tmall)
            {
                var amiyaOrder = await syncOrder.TranslateTradesSoldOrdersByOrderId(Convert.ToInt64(input.OrderId));
                var FirstOrder = amiyaOrder.FirstOrDefault();
                if (FirstOrder == null)
                {
                    throw new Exception("未找到对应的订单，请核对订单号后重试");
                }
                result.Id = FirstOrder.Id;
                result.StatusCode = FirstOrder.StatusCode;
                result.ActualPayment = FirstOrder.ActualPayment;
                result.AccountReceivable = FirstOrder.AccountReceivable;
                result.UpdateDate = FirstOrder.UpdateDate;
                result.WriteOffDate = FirstOrder.WriteOffDate;
                await orderService.UpdateOrderStatusAsync(result.Id, result.StatusCode, result.ActualPayment, result.AccountReceivable, result.UpdateDate, result.WriteOffDate);
            }
            return ResultData.Success();
        }

        /// <summary>
        /// 订单归属主播
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("LiveAnchorOrder")]
        public async Task<ResultData> LiveAnchorOrderAsync(LiveAnchorOrderVo input)
        {
            UpdateLiveAnchorOrderDto dto = new UpdateLiveAnchorOrderDto();
            dto.OrderId = input.OrderId;
            dto.LiveAnchorId = input.LiveAnchorId;
            await orderService.UpdateOrderLiveAnchorAsync(dto);
            return ResultData.Success();
        }

        /// <summary>
        /// 修改下单平台订单归属客服
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("BelongEmployeeOrder")]
        public async Task<ResultData> BelongEmployeeOrderAsync(BelongEmpInfoOrderVo input)
        {
            UpdateBelongEmpInfoOrderDto dto = new UpdateBelongEmpInfoOrderDto();
            dto.OrderId = input.OrderId;
            dto.BelongEmpId = input.BelongEmpInfo;
            await orderService.UpdateOrderBelongEmpIdAsync(dto);
            return ResultData.Success();
        }

        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="UpdateVo"></param>
        /// <returns></returns>
        [HttpPut("UpdateOrder")]
        public async Task<ResultData> UpdateOrderAsync(OrderInfoUpdateVo UpdateVo)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            //验证手机号是否有归属
            if (string.IsNullOrEmpty(UpdateVo.Phone))
            {
                throw new Exception("该订单没有手机号，不能绑定客服");
            }

            var bind = await _dalBindCustomerService.GetAll()
              .Include(e => e.CustomerServiceAmiyaEmployee)
              .SingleOrDefaultAsync(e => e.BuyerPhone == UpdateVo.Phone);
            if (bind != null)
            {
                if (bind.CustomerServiceId != employeeId)
                    throw new Exception("该客户已绑定给" + bind.CustomerServiceAmiyaEmployee.Name + ",请联系对应人员进行录单修改！");
            }
            else
            {
                //添加绑定客服
                BindCustomerService bindCustomerService = new BindCustomerService();
                bindCustomerService.CustomerServiceId = employeeId;
                bindCustomerService.BuyerPhone = UpdateVo.Phone;
                bindCustomerService.UserId = null;
                bindCustomerService.CreateBy = employeeId;
                bindCustomerService.CreateDate = DateTime.Now;
                await _dalBindCustomerService.AddAsync(bindCustomerService, true);
            }
            //修改订单
            OrderInfoUpdateDto updateDto = new OrderInfoUpdateDto();
            updateDto.Id = UpdateVo.OrderId;
            updateDto.GoodsName = UpdateVo.GoodsName;
            updateDto.Description = UpdateVo.Remark;
            updateDto.GoodsId = UpdateVo.GoodsId;
            updateDto.Phone = UpdateVo.Phone;
            updateDto.AppointmentCity = UpdateVo.AppointmentCity;
            updateDto.AppointmentDate = UpdateVo.AppointmentDate;
            updateDto.AppointmentHospital = UpdateVo.AppointmentHospital;
            updateDto.StatusCode = UpdateVo.StatusCode;
            updateDto.ActualPayment = UpdateVo.ActualPayment;
            updateDto.CreateDate = DateTime.Now;
            updateDto.ThumbPicUrl = _amiyaGoodsDemandService.GetByIdAsync(UpdateVo.GoodsId).Result.ThumbPictureUrl.ToString();
            updateDto.BuyerNick = UpdateVo.BuyerNick;
            updateDto.AppType = UpdateVo.AppType;
            updateDto.BuyerNick = UpdateVo.BuyerNick;
            updateDto.IsAppointment = UpdateVo.IsAppointment;
            updateDto.OrderType = (UpdateVo.OrderType.HasValue) ? UpdateVo.OrderType.Value : (byte)0;
            updateDto.OrderNature = (UpdateVo.OrderNature.HasValue) ? UpdateVo.OrderNature.Value : (byte)0;
            updateDto.Quantity = (UpdateVo.Quantity.HasValue) ? UpdateVo.Quantity : 0;
            updateDto.IntegrationQuantity = 0;
            updateDto.ExchangeType = UpdateVo.ExchangeType;
            await orderService.UpdateAddedOrderAsync(updateDto);
            return ResultData.Success();
        }


        /// <summary>
        /// 完成订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("{id}")]
        public async Task<ResultData> FinishAsync(string id)
        {
            await orderService.FinishOrderAsync(id);
            return ResultData.Success();
        }

        /// <summary>
        /// 审核订单
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("checkOrder")]
        [FxInternalAuthorize]
        public async Task<ResultData> CheckOrderAsync(ContentPlateFormOrderCheckVo updateVo)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            if (employee.PositionId != "1")
            {
                if (employee.PositionId != "13")
                {
                    throw new Exception("只有管理员与财务才可进行订单审核！");
                }
            }
            //修改订单
            ContentPlateFormOrderCheckDto updateDto = new ContentPlateFormOrderCheckDto();
            updateDto.Id = updateVo.Id;
            updateDto.CheckPrice = updateVo.CheckPrice;
            updateDto.CheckState = updateVo.CheckState;
            updateDto.SettlePrice = updateVo.SettlePrice;
            updateDto.employeeId = employeeId;
            updateDto.CheckRemark = updateVo.CheckRemark;
            updateDto.CheckPicture = updateVo.CheckPicture;
            updateDto.ReconciliationDocumentsId = updateVo.ReconciliationDocumentsId;
            await orderService.CheckOrderAsync(updateDto);
            return ResultData.Success();
        }

        /// <summary>
        /// 订单审核后回款
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("returnBackOrder")]
        [FxInternalAuthorize]
        public async Task<ResultData> ReturnBackOrderAsync(ReturnBackOrderVo updateVo)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            if (employee.PositionId != "1")
            {
                if (employee.PositionId != "13")
                {
                    throw new Exception("只有管理员与财务才可进行订单回款！");
                }
            }
            //修改订单
            ReturnBackOrderDto updateDto = new ReturnBackOrderDto();
            updateDto.OrderId = updateVo.OrderId;
            updateDto.ReturnBackPrice = updateVo.ReturnBackPrice;
            updateDto.ReturnBackDate = updateVo.ReturnBackDate;
            await orderService.ReturnBackOrderAsync(updateDto);
            return ResultData.Success();
        }

        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(string id)
        {
            await orderService.DeleteAsync(id);
            return ResultData.Success();
        }


        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="startDate">创建开始时间</param>
        /// <param name="endDate">创建结束时间</param>
        /// <param name="writeOffStartDate">核销开始时间</param>
        /// <param name="writeOffEndDate">核销结束时间</param>
        /// <param name="belongEmpId">归属客服</param>
        /// <param name="keyword"></param>
        /// <param name="statusCode">状态码</param>
        /// <param name="appType">渠道</param>
        /// <param name="orderNature">订单性质</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("tmallOrderLlistWithPage")]
        public async Task<ResultData<FxPageInfo<OrderInfoVo>>> GetOrderListWithPageAsync(DateTime? startDate, DateTime? endDate, DateTime? writeOffStartDate, DateTime? writeOffEndDate, int? belongEmpId, string keyword, string statusCode, byte? appType, byte? orderNature, int pageNum, int pageSize)
        {
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                var q = await orderService.GetOrderListWithPageAsync(startDate, endDate, writeOffStartDate, writeOffEndDate, belongEmpId, keyword, statusCode, appType, orderNature, employeeId, pageNum, pageSize);
                var order = from d in q.List
                            select new OrderInfoVo
                            {
                                Id = d.Id,
                                ThumbPicUrl = d.ThumbPicUrl,
                                GoodsName = d.GoodsName,
                                NickName = d.BuyerNick,
                                GoodsId = d.GoodsId,
                                Phone = d.Phone,
                                EncryptPhone = d.EncryptPhone,
                                AppointmentCity = d.AppointmentCity,
                                AppointmentDate = d.AppointmentDate,
                                AppointmentHospital = d.AppointmentHospital,
                                SendOrderHospital = d.SendOrderHospital,
                                IsAppointment = d.IsAppointment,
                                StatusCode = d.StatusCode,
                                StatusText = d.StatusText,
                                ActualPayment = d.ActualPayment,
                                CreateDate = d.CreateDate,
                                WriteOffDate = d.WriteOffDate,
                                AppType = d.AppType,
                                AppTypeText = d.AppTypeText,
                                OrderType = d.OrderType,
                                OrderTypeText = d.OrderTypeText,
                                OrderNature = d.OrderNature,
                                OrderNatureText = d.OrderNatureText,
                                Quantity = d.Quantity,
                                IntegrationQuantity = d.IntegrationQuantity,
                                ExchangeType = d.ExchangeType,
                                Description = d.Description,
                                ExchangeTypeText = d.ExchangeTypeText,
                                TradeId = d.TradeId,
                                FinalConsumptionHospital = d.FinalConsumptionHospital,
                                LiveAnchor = d.LiveAnchorName,
                                LiveAnchorPlatForm = d.LiveAnchorPlatForm,
                                BelongEmpName = d.BelongEmpName,
                                Standard=d.Standard
                            };
                FxPageInfo<OrderInfoVo> orderPageInfo = new FxPageInfo<OrderInfoVo>();
                orderPageInfo.TotalCount = q.TotalCount;
                orderPageInfo.List = order;
                return ResultData<FxPageInfo<OrderInfoVo>>.Success().AddData("order", orderPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<OrderInfoVo>>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 获取已成交订单列表
        /// </summary>
        /// <param name="writeOffStartDate">（必填）核销开始时间</param>
        /// <param name="writeOffEndDate">（必填）核销结束时间</param>
        /// <param name="keyword"></param>
        /// <param name="CheckState">审核状态,为空查询所有</param>
        /// <param name="ReturnBackPriceState">回款状态,为空查询所有</param>
        /// <param name="appType">渠道</param>
        /// <param name="orderNature">订单性质</param>
        /// <param name="createBillCompanyId">开票公司id</param>
        /// <param name="isCreateBill">是否开票</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("tmallOrderFinishLlistWithPage")]
        public async Task<ResultData<FxPageInfo<OrderInfoVo>>> GetOrderFinishListWithPageAsync(DateTime? writeOffStartDate, DateTime? writeOffEndDate, int? CheckState, bool? ReturnBackPriceState, string keyword, byte? appType, byte? orderNature, int pageNum, int pageSize,string createBillCompanyId,bool? isCreateBill)
        {
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                var q = await orderService.GetOrderFinishListWithPageAsync(writeOffStartDate, writeOffEndDate, CheckState, ReturnBackPriceState, keyword, appType, orderNature, employeeId, createBillCompanyId, isCreateBill,pageNum, pageSize);
                var order = from d in q.List
                            select new OrderInfoVo
                            {
                                Id = d.Id,
                                ThumbPicUrl = d.ThumbPicUrl,
                                GoodsName = d.GoodsName,
                                NickName = d.BuyerNick,
                                GoodsId = d.GoodsId,
                                Phone = d.Phone,
                                EncryptPhone = d.EncryptPhone,
                                AppointmentCity = d.AppointmentCity,
                                AppointmentDate = d.AppointmentDate,
                                AppointmentHospital = d.AppointmentHospital,
                                SendOrderHospital = d.SendOrderHospital,
                                IsAppointment = d.IsAppointment,
                                StatusCode = d.StatusCode,
                                StatusText = d.StatusText,
                                ActualPayment = d.ActualPayment,
                                CreateDate = d.CreateDate,
                                WriteOffDate = d.WriteOffDate,
                                AppType = d.AppType,
                                AppTypeText = d.AppTypeText,
                                BelongEmpName = d.BelongEmpName,
                                OrderType = d.OrderType,
                                OrderTypeText = d.OrderTypeText,
                                OrderNature = d.OrderNature,
                                OrderNatureText = d.OrderNatureText,
                                Quantity = d.Quantity,
                                IntegrationQuantity = d.IntegrationQuantity,
                                ExchangeType = d.ExchangeType,
                                ExchangeTypeText = d.ExchangeTypeText,
                                TradeId = d.TradeId,
                                FinalConsumptionHospital = d.FinalConsumptionHospital,
                                LiveAnchor = d.LiveAnchorName,
                                LiveAnchorPlatForm = d.LiveAnchorPlatForm,
                                CheckState = d.CheckState,
                                CheckPrice = d.CheckPrice,
                                CheckDate = d.CheckDate,
                                CheckByEmpName = d.CheckByEmpName,
                                CheckRemark = d.CheckRemark,
                                SettlePrice = d.SettlePrice,
                                IsReturnBackPrice = d.IsReturnBackPrice,
                                ReturnBackPrice = d.ReturnBackPrice,
                                ReturnBackDate = d.ReturnBackDate,
                                ReconciliationDocumentsId = d.ReconciliationDocumentsId,

                            };
                FxPageInfo<OrderInfoVo> orderPageInfo = new FxPageInfo<OrderInfoVo>();
                orderPageInfo.TotalCount = q.TotalCount;
                orderPageInfo.List = order;
                return ResultData<FxPageInfo<OrderInfoVo>>.Success().AddData("order", orderPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<OrderInfoVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 根据对账单id获取已成交订单列表
        /// </summary>
        /// <param name="reconciliationDocumentsId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("getOrderByReconciliationDocumentsIdLlistWithPage")]
        public async Task<ResultData<FxPageInfo<OrderInfoVo>>> GetOrderByReconciliationDocumentsIdLlistWithPageAsync(string reconciliationDocumentsId, int pageNum, int pageSize)
        {
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                var q = await orderService.GetOrderByReconciliationDocumentsIdLlistWithPageAsync(reconciliationDocumentsId, pageNum, pageSize);
                var order = from d in q.List
                            select new OrderInfoVo
                            {
                                Id = d.Id,
                                ThumbPicUrl = d.ThumbPicUrl,
                                GoodsName = d.GoodsName,
                                NickName = d.BuyerNick,
                                GoodsId = d.GoodsId,
                                Phone = d.Phone,
                                EncryptPhone = d.EncryptPhone,
                                AppointmentCity = d.AppointmentCity,
                                AppointmentDate = d.AppointmentDate,
                                AppointmentHospital = d.AppointmentHospital,
                                SendOrderHospital = d.SendOrderHospital,
                                IsAppointment = d.IsAppointment,
                                StatusCode = d.StatusCode,
                                StatusText = d.StatusText,
                                ActualPayment = d.ActualPayment,
                                CreateDate = d.CreateDate,
                                WriteOffDate = d.WriteOffDate,
                                AppType = d.AppType,
                                AppTypeText = d.AppTypeText,
                                OrderType = d.OrderType,
                                OrderTypeText = d.OrderTypeText,
                                OrderNature = d.OrderNature,
                                OrderNatureText = d.OrderNatureText,
                                Quantity = d.Quantity,
                                IntegrationQuantity = d.IntegrationQuantity,
                                ExchangeType = d.ExchangeType,
                                ExchangeTypeText = d.ExchangeTypeText,
                                TradeId = d.TradeId,
                                FinalConsumptionHospital = d.FinalConsumptionHospital,
                                LiveAnchor = d.LiveAnchorName,
                                BelongEmpName = d.BelongEmpName,
                                LiveAnchorPlatForm = d.LiveAnchorPlatForm,
                                CheckState = d.CheckState,
                                CheckPrice = d.CheckPrice,
                                CheckDate = d.CheckDate,
                                CheckByEmpName = d.CheckByEmpName,
                                CheckRemark = d.CheckRemark,
                                SettlePrice = d.SettlePrice,
                                IsReturnBackPrice = d.IsReturnBackPrice,
                                ReturnBackPrice = d.ReturnBackPrice,
                                ReturnBackDate = d.ReturnBackDate,
                                ReconciliationDocumentsId = d.ReconciliationDocumentsId,

                            };
                FxPageInfo<OrderInfoVo> orderPageInfo = new FxPageInfo<OrderInfoVo>();
                orderPageInfo.TotalCount = q.TotalCount;
                orderPageInfo.List = order;
                return ResultData<FxPageInfo<OrderInfoVo>>.Success().AddData("order", orderPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<OrderInfoVo>>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 导出订单列表
        /// </summary>
        /// <param name="startDate">创建开始时间</param>
        /// <param name="endDate">创建结束时间</param>
        /// <param name="writeOffStartDate">核销开始时间</param>
        /// <param name="writeOffEndDate">核销结束时间</param>
        /// <param name="keyword"></param>
        /// <param name="statusCode">状态码</param>
        /// <param name="appType">渠道</param>
        /// <param name="orderNature">订单性质</param>
        /// <returns></returns>
        [HttpGet("exportTmallOrderLlist")]
        [FxInternalAuthorize]
        public async Task<FileStreamResult> ExportOrderListAsync(DateTime? startDate, DateTime? endDate, DateTime? writeOffStartDate, DateTime? writeOffEndDate, string keyword, string statusCode, byte? appType, byte? orderNature)
        {
            bool isHidePhone = true;
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            if (employee.DepartmentId == "1" || employee.DepartmentId == "7")
            {
                isHidePhone = false;
            }
            var q = await orderService.ExportOrderListAsync(startDate, endDate, writeOffStartDate, writeOffEndDate, keyword, statusCode, appType, orderNature, employeeId, isHidePhone);
            var order = from d in q
                        select new ExportOrderVo
                        {
                            Id = d.Id,
                            GoodsName = d.GoodsName,
                            NickName = d.BuyerNick,
                            GoodsId = d.GoodsId,
                            Phone = d.Phone,
                            AppointmentCity = d.AppointmentCity,
                            AppointmentDate = d.AppointmentDate,
                            AppointmentHospital = d.AppointmentHospital,
                            SendOrderHospital = d.SendOrderHospital,
                            ActualPayment = (d.ActualPayment.HasValue) ? d.ActualPayment.Value : 0,
                            CreateDate = d.CreateDate,
                            WriteOffDate = d.WriteOffDate,
                            AppTypeText = d.AppTypeText,
                            StatusText = d.StatusText,
                            Quantity = d.Quantity,
                            IntegrationQuantity = (d.IntegrationQuantity.HasValue) ? d.IntegrationQuantity.Value : 0,
                            Standard=d.Standard
                        };
            var exportOrder = order.ToList();
            var stream = ExportExcelHelper.ExportExcel(exportOrder);
            var result = File(stream, "application/vnd.ms-excel", $"" + startDate.Value.ToString("yyyy年MM月dd日") + "-" + endDate.Value.ToString("yyyy年MM月dd日") + "订单列表.xls");
            return result;
        }


        /// <summary>
        /// 根据加密手机号获取订单列表
        /// </summary>
        /// <param name="encryptPhone">加密手机号</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listByEncryptPhone")]
        public async Task<ResultData<FxPageInfo<OrderInfoVo>>> GetListByEncryptPhoneAsync(string encryptPhone, int pageNum, int pageSize)
        {
            try
            {
                var q = await orderService.GetListByEncryptPhoneAsync(encryptPhone, pageNum, pageSize);

                var order = from d in q.List
                            select new OrderInfoVo
                            {
                                Id = d.Id,
                                GoodsName = d.GoodsName,
                                GoodsId = d.GoodsId,
                                Phone = d.Phone,
                                EncryptPhone = d.EncryptPhone,
                                AppointmentHospital = d.AppointmentHospital,
                                IsAppointment = d.IsAppointment,
                                StatusCode = d.StatusCode,
                                StatusText = d.StatusText,
                                ActualPayment = d.ActualPayment,
                                AppType = d.AppType,
                                AppTypeText = d.AppTypeText,
                                Quantity = d.Quantity,
                                IntegrationQuantity = d.IntegrationQuantity,
                                ExchangeType = d.ExchangeType,
                                ExchangeTypeText = d.ExchangeTypeText,
                                TradeId = d.TradeId,
                            };

                FxPageInfo<OrderInfoVo> orderPageInfo = new FxPageInfo<OrderInfoVo>();
                orderPageInfo.TotalCount = q.TotalCount;
                orderPageInfo.List = order;
                return ResultData<FxPageInfo<OrderInfoVo>>.Success().AddData("order", orderPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<OrderInfoVo>>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 获取未绑定客服的订单列表
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="keyword"></param>
        /// <param name="minPayment">最下金额</param>
        /// <param name="maxPayment">最大金额</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("unBindCustomerService")]
        public async Task<ResultData<FxPageInfo<OrderInfoVo>>> GetUnBindCustomerServiceOrderListAsync(string statusCode, string keyword, decimal? minPayment, decimal? maxPayment, byte? appType, int pageNum, int pageSize)
        {
            var q = await orderService.GetUnBindCustomerServiceOrderListAsync(statusCode, keyword, minPayment, maxPayment, appType, pageNum, pageSize);
            var order = from d in q.List
                        select new OrderInfoVo
                        {
                            Id = d.Id,
                            GoodsName = d.GoodsName,
                            GoodsId = d.GoodsId,
                            Phone = d.Phone,
                            EncryptPhone = d.EncryptPhone,
                            AppointmentHospital = d.AppointmentHospital,
                            IsAppointment = d.IsAppointment,
                            StatusCode = d.StatusCode,
                            StatusText = d.StatusText,
                            ActualPayment = d.ActualPayment,
                            ThumbPicUrl = d.ThumbPicUrl,
                            AppType = d.AppType,
                            AppTypeText = d.AppTypeText,
                            Quantity = d.Quantity,
                            IntegrationQuantity = d.IntegrationQuantity,
                            ExchangeType = d.ExchangeType,
                            ExchangeTypeText = d.ExchangeTypeText,
                            TradeId = d.TradeId,
                        };

            FxPageInfo<OrderInfoVo> orderPageInfo = new FxPageInfo<OrderInfoVo>();
            orderPageInfo.TotalCount = q.TotalCount;
            orderPageInfo.List = order;
            return ResultData<FxPageInfo<OrderInfoVo>>.Success().AddData("order", orderPageInfo);
        }



        /// <summary>
        /// 获取已绑定了客服的订单列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="customerServiceId"></param>
        /// <param name="appType">下单平台</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("bindCustomerServieOrderList")]
        public async Task<ResultData<FxPageInfo<BindCustomerServiceOrderVo>>> GetBindCustomerServieOrderListAsync(string keyword, int? customerServiceId, byte? appType, string statusCode, decimal? minPayment, decimal? maxPayment, int pageNum, int pageSize)
        {
            var q = await orderService.GetBindCustomerServieOrderListAsync(keyword, customerServiceId, appType, statusCode, minPayment, maxPayment, pageNum, pageSize);
            var order = from d in q.List
                        select new BindCustomerServiceOrderVo
                        {
                            Id = d.Id,
                            GoodsName = d.GoodsName,
                            GoodsId = d.GoodsId,
                            Phone = d.Phone,
                            EncryptPhone = d.EncryptPhone,
                            AppointmentHospital = d.AppointmentHospital,
                            IsAppointment = d.IsAppointment,
                            Status = d.StatusCode,
                            StatusText = d.StatusText,
                            CustomerServiceId = d.CustomerServiceId,
                            CustomerServiceName = d.CustomerServiceName,
                            ActualPayment = d.ActualPayment,
                            ThumbPicUrl = d.ThumbPicUrl,
                            AppType = d.AppType,
                            AppTypeText = d.AppTypeText,
                            Quantity = d.Quantity,
                            IntegrationQuantity = d.IntegrationQuantity,
                            ExchangeType = d.ExchangeType,
                            ExchangeTypeText = d.ExchangeTypeText,
                            TradeId = d.TradeId,
                        };
            FxPageInfo<BindCustomerServiceOrderVo> orderPageInfo = new FxPageInfo<BindCustomerServiceOrderVo>();
            orderPageInfo.TotalCount = q.TotalCount;
            orderPageInfo.List = order;
            return ResultData<FxPageInfo<BindCustomerServiceOrderVo>>.Success().AddData("order", orderPageInfo);
        }



        /// <summary>
        /// 获取订单数据
        /// </summary>
        /// <returns></returns>
        /// <returns></returns>
        [HttpGet("headOrderData")]
        public async Task<ResultData<OrderDataVo>> GetHeadOrderDataAsync(int? employeeId)
        {
            OrderDataVo orderDataVo = new OrderDataVo();
            if (employeeId == null)
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                employeeId = Convert.ToInt32(employee.Id);
                orderDataVo.TotalOrderQuantity = await orderService.GetTotalOrderQuantityAsync((int)employeeId);
                orderDataVo.TodayIncrementQuantity = await orderService.GetTodayIncrementQuantityAsync((int)employeeId);
                orderDataVo.LatelyStatusChangeDate = await orderService.GetLatelyStatusChangeDateAsync((int)employeeId);
                orderDataVo.UnBindCustoemrServiceQuantity = await orderService.GetUnBindOrderQuantityAsync((int)employeeId);
                orderDataVo.UnSendOrderQuantity = await orderService.GetUnSendOrderQuantityAsync((int)employeeId);
                return ResultData<OrderDataVo>.Success().AddData("orderData", orderDataVo);
            }
            else
            {
                orderDataVo.TotalOrderQuantity = 0;
                orderDataVo.TodayIncrementQuantity = 0;
                orderDataVo.LatelyStatusChangeDate = null;
                orderDataVo.UnBindCustoemrServiceQuantity = 0;
                orderDataVo.UnSendOrderQuantity = 0;
                return ResultData<OrderDataVo>.Success().AddData("orderData", orderDataVo);
            }

        }


        /// <summary>
        /// 订单各状态数量
        /// </summary>
        /// <returns></returns>
        [HttpGet("orderStatusData")]
        public async Task<ResultData<List<OrderStatusDataVo>>> GetOrderStatusDataAsync(int? employeeId)
        {
            if (employeeId == null)
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                employeeId = Convert.ToInt32(employee.Id);
            }


            var order = from d in await orderService.GetOrderStatusDataAsync((int)employeeId)
                        select new OrderStatusDataVo
                        {
                            StatusText = d.StatusText,
                            Quantity = d.Quantity
                        };

            return ResultData<List<OrderStatusDataVo>>.Success().AddData("order", order.ToList());
        }




        /// <summary>
        /// 获取今天新增订单
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("todayIncrementList")]
        public async Task<FxPageInfo<OrderInfoVo>> GetTodayIncrementListAsync(int pageNum, int pageSize)
        {
            var q = await orderService.GetTodayIncrementListAsync(pageNum, pageSize);
            var order = from d in q.List
                        select new OrderInfoVo
                        {
                            Id = d.Id,
                            GoodsName = d.GoodsName,
                            GoodsId = d.GoodsId,
                            ThumbPicUrl = d.ThumbPicUrl,
                            Phone = d.Phone,
                            EncryptPhone = d.EncryptPhone,
                            AppointmentHospital = d.AppointmentHospital,
                            IsAppointment = d.IsAppointment,
                            ActualPayment = d.ActualPayment,
                            CreateDate = d.CreateDate,
                            StatusCode = d.StatusCode,
                            StatusText = d.StatusText,
                            AppType = d.AppType,
                            AppTypeText = d.AppTypeText,
                            Quantity = d.Quantity,
                            IntegrationQuantity = d.IntegrationQuantity,
                            ExchangeType = d.ExchangeType,
                            ExchangeTypeText = d.ExchangeTypeText,
                            TradeId = d.TradeId,
                        };
            FxPageInfo<OrderInfoVo> orderPageInfo = new FxPageInfo<OrderInfoVo>();
            orderPageInfo.TotalCount = q.TotalCount;
            orderPageInfo.List = order;
            return orderPageInfo;
        }




        /// <summary>
        /// 获取今日订单状态发生改变的订单列表
        /// </summary>
        /// <param name="employeeId">-1查全部</param>
        /// <param name="keyword"></param>
        /// <param name="statusCode">状态码</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("todayStatusChangeList")]
        public async Task<ResultData<FxPageInfo<OrderInfoVo>>> GetTodayStatusChangeListAsync(int? employeeId, string keyword, string statusCode, int pageNum, int pageSize)
        {
            if (employeeId == null)
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                employeeId = Convert.ToInt32(employee.Id);
            }
            var q = await orderService.GetTodayStatusChangeListAsync((int)employeeId, keyword, statusCode, pageNum, pageSize);
            var order = from d in q.List
                        select new OrderInfoVo
                        {
                            Id = d.Id,
                            GoodsName = d.GoodsName,
                            GoodsId = d.GoodsId,
                            ThumbPicUrl = d.ThumbPicUrl,
                            Phone = d.Phone,
                            EncryptPhone = d.EncryptPhone,
                            AppointmentHospital = d.AppointmentHospital,
                            IsAppointment = d.IsAppointment,
                            ActualPayment = d.ActualPayment,
                            CreateDate = d.CreateDate,
                            UpdateDate = d.UpdateDate,
                            StatusCode = d.StatusCode,
                            StatusText = d.StatusText,
                            AppType = d.AppType,
                            AppTypeText = d.AppTypeText,
                            Quantity = d.Quantity,
                            IntegrationQuantity = d.IntegrationQuantity,
                            ExchangeType = d.ExchangeType,
                            ExchangeTypeText = d.ExchangeTypeText,
                            TradeId = d.TradeId,
                        };

            FxPageInfo<OrderInfoVo> orderPageInfo = new FxPageInfo<OrderInfoVo>();
            orderPageInfo.TotalCount = q.TotalCount;
            orderPageInfo.List = order;
            return ResultData<FxPageInfo<OrderInfoVo>>.Success().AddData("order", orderPageInfo);
        }




        /// <summary>
        /// 根据员工编号获取订单列表
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="statusCode"></param>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("orderListByEmployeeId")]
        public async Task<ResultData<FxPageInfo<OrderInfoVo>>> GetOrderByEmployeeIdAsync(int employeeId, string statusCode, string keyword, int pageNum, int pageSize)
        {
            var q = await orderService.GetOrderByEmployeeIdAsync(employeeId, statusCode, keyword, pageNum, pageSize);
            var order = from d in q.List
                        select new OrderInfoVo
                        {
                            Id = d.Id,
                            GoodsId = d.GoodsId,
                            GoodsName = d.GoodsName,
                            ThumbPicUrl = d.ThumbPicUrl,
                            Phone = d.Phone,
                            EncryptPhone = d.EncryptPhone,
                            AppointmentHospital = d.AppointmentHospital,
                            IsAppointment = d.IsAppointment,
                            StatusCode = d.StatusCode,
                            StatusText = d.StatusText,
                            ActualPayment = d.ActualPayment,
                            CreateDate = d.CreateDate,
                            AppType = d.AppType,
                            AppTypeText = d.AppTypeText,
                            Quantity = d.Quantity,
                            IntegrationQuantity = d.IntegrationQuantity,
                            ExchangeType = d.ExchangeType,
                            ExchangeTypeText = d.ExchangeTypeText,
                            TradeId = d.TradeId,
                        };
            FxPageInfo<OrderInfoVo> orderPageInfo = new FxPageInfo<OrderInfoVo>();
            orderPageInfo.TotalCount = q.TotalCount;
            orderPageInfo.List = order;
            return ResultData<FxPageInfo<OrderInfoVo>>.Success().AddData("order", orderPageInfo);
        }



        /// <summary>
        /// 根据订单编号获取订单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<OrderInfoVo>> GetByIdAsync(string id)
        {
            var order = await orderService.GetByIdInCRMAsync(id);
            OrderInfoVo tmallOrderVo = new OrderInfoVo();
            tmallOrderVo.Id = order.Id;
            tmallOrderVo.UserId = order.UserId;
            tmallOrderVo.GoodsName = order.GoodsName;
            tmallOrderVo.NickName = order.BuyerNick;
            tmallOrderVo.GoodsId = order.GoodsId;
            tmallOrderVo.OrderNature = order.OrderNature;
            tmallOrderVo.ThumbPicUrl = order.ThumbPicUrl;
            tmallOrderVo.OrderType = order.OrderType;
            tmallOrderVo.Phone = order.Phone;
            tmallOrderVo.EncryptPhone = order.EncryptPhone;
            tmallOrderVo.AppointmentCity = order.AppointmentCity;
            tmallOrderVo.AppointmentDate = order.AppointmentDate;
            tmallOrderVo.AppointmentHospital = order.AppointmentHospital;
            tmallOrderVo.IsAppointment = order.IsAppointment;
            tmallOrderVo.Description = order.Description;
            tmallOrderVo.StatusCode = order.StatusCode;
            tmallOrderVo.StatusText = order.StatusText;
            tmallOrderVo.ActualPayment = order.ActualPayment;
            tmallOrderVo.CreateDate = order.CreateDate;
            tmallOrderVo.UpdateDate = order.UpdateDate;
            tmallOrderVo.AppType = order.AppType;
            tmallOrderVo.AppTypeText = order.AppTypeText;
            tmallOrderVo.ExchangeType = order.ExchangeType;
            tmallOrderVo.ExchangeTypeText = order.ExchangeTypeText;
            tmallOrderVo.Quantity = order.Quantity;

            tmallOrderVo.WriteOffDate = order.WriteOffDate;
            tmallOrderVo.LiveAnchor = order.LiveAnchorName;
            tmallOrderVo.IsReturnBackPrice = order.IsReturnBackPrice;
            tmallOrderVo.LiveAnchorPlatForm = order.LiveAnchorPlatForm;
            tmallOrderVo.OrderNatureText = order.OrderNatureText;
            tmallOrderVo.BelongEmpName = order.BelongEmpName;
            tmallOrderVo.SendOrderHospital = order.SendOrderHospital;
            tmallOrderVo.FinalConsumptionHospital = order.FinalConsumptionHospital;
            tmallOrderVo.AccountReceivable = order.AccountReceivable;
            tmallOrderVo.OrderTypeText = order.OrderTypeText;
            tmallOrderVo.CheckState = order.CheckState;
            tmallOrderVo.CheckPrice = order.CheckPrice;
            tmallOrderVo.CheckDate = order.CheckDate;
            tmallOrderVo.SettlePrice = order.SettlePrice;
            tmallOrderVo.CheckByEmpName = order.CheckByEmpName;
            tmallOrderVo.CheckRemark = order.CheckRemark;
            tmallOrderVo.ReturnBackPrice = order.ReturnBackPrice;
            tmallOrderVo.ReturnBackDate = order.ReturnBackDate;
            tmallOrderVo.IsCreateBill = order.IsCreateBill;
            tmallOrderVo.CreateBillCompany = order.BelongCompany;
            return ResultData<OrderInfoVo>.Success().AddData("order", tmallOrderVo);
        }

        /// <summary>
        /// 根据核销编号获取订单信息
        /// </summary>
        /// <param name="writeOffCode">核销编号</param>
        /// <returns></returns>
        [HttpGet("byWriteOffCode")]
        public async Task<ResultData<List<OrderInfoVo>>> GetByWriteOffCodeAsync([Required] string writeOffCode)
        {
            List<OrderInfoVo> orderInfoResultList = new List<OrderInfoVo>();
            var orderResult = await orderService.GetOrderInfoByWriteOffCode(writeOffCode);
            foreach (var order in orderResult)
            {
                for (int x = 0; x < order.Quantity - order.AlreadyWriteOffAmount; x++)
                {
                    OrderInfoVo tmallOrderVo = new OrderInfoVo();
                    tmallOrderVo.Id = order.Id;
                    tmallOrderVo.GoodsName = order.GoodsName;
                    tmallOrderVo.GoodsId = order.GoodsId;
                    tmallOrderVo.ThumbPicUrl = order.ThumbPicUrl;
                    tmallOrderVo.Phone = order.Phone;
                    tmallOrderVo.EncryptPhone = order.EncryptPhone;
                    tmallOrderVo.AppointmentHospital = order.AppointmentHospital;
                    tmallOrderVo.IsAppointment = order.IsAppointment;
                    tmallOrderVo.StatusCode = order.StatusCode;
                    tmallOrderVo.StatusText = order.StatusText;
                    tmallOrderVo.ActualPayment = order.ActualPayment / order.Quantity;
                    tmallOrderVo.CreateDate = order.CreateDate;
                    tmallOrderVo.UpdateDate = order.UpdateDate;
                    tmallOrderVo.AppType = order.AppType;
                    tmallOrderVo.AppTypeText = order.AppTypeText;
                    tmallOrderVo.Quantity = 1;
                    tmallOrderVo.OrderType = order.OrderType;
                    if (tmallOrderVo.OrderType == 1)
                    {
                        tmallOrderVo.IntegrationQuantity = order.IntegrationQuantity;
                    }
                    orderInfoResultList.Add(tmallOrderVo);
                }
            }
            return ResultData<List<OrderInfoVo>>.Success().AddData("order", orderInfoResultList);
        }


        /// <summary>
        /// 核销订单
        /// </summary>
        /// <param name="orderId">订单号</param>
        /// <param name="hospitalId">医院id</param>
        /// <returns></returns>
        [HttpPut("WriteOff")]
        public async Task<ResultData> WriteOffOrderAsync([Required] string orderId, [Required] int hospitalId)
        {
            await orderService.WriteOffAsync(orderId, hospitalId);
            return ResultData.Success();
        }


        /// <summary>
        /// 记录订单最终核销医院
        /// </summary>
        /// <param name="orderId">订单号</param>
        /// <param name="hospitalId">医院id</param>
        /// <returns></returns>
        [HttpPut("UpdateOrderFinalConsumptionHospital")]
        public async Task<ResultData> UpdateOrderFinalConsumptionHospital([Required] string orderId, [Required] int hospitalId)
        {
            await orderService.UpdateOrderFinalConsumptionHospital(orderId, hospitalId);
            return ResultData.Success();
        }


        /// <summary>
        /// 修改京东退款成功的订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("refundOfJd/{id}")]
        public async Task<ResultData> UpdateRefundOfJdAsync(string id)
        {
            await orderService.UpdateRefundOfJdAsync(id);
            return ResultData.Success();
        }



        /// <summary>
        /// 获取小程序订单交易列表
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="isSendGoods">是否已发货，null：全部</param>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("miniProgramMaterialOrderTradeList")]
        public async Task<ResultData<FxPageInfo<MiniProgramOrderTradeVo>>> GetMiniProgramMaterialOrderTradeList(DateTime startDate, DateTime endDate, bool? isSendGoods, string keyword, int pageNum, int pageSize)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            var q = await orderService.GetMiniProgramMaterialOrderTradeList(startDate, endDate, employeeId, isSendGoods, keyword, pageNum, pageSize);
            var orderTrades = from d in q.List
                              select new MiniProgramOrderTradeVo
                              {
                                  TradeId = d.TradeId,
                                  Phone = d.Phone,
                                  CreateDate = d.CreateDate,
                                  Remark = d.Remark,
                                  StatusText = d.StatusText,
                                  Address = d.Address,
                                  ReceiveName = d.ReceiveName,
                                  IntergrationAccounts = d.IntergrationAccounts,
                                  Quantities = d.Quantities,
                                  BindOrderIds = d.OrderIds,
                                  Goods = d.GoodsName,
                                  StatusCode = d.StatusCode,
                                  TotalAmount = d.TotalAmount.HasValue ? d.TotalAmount.Value : 0M,
                                  ReceivePhone = d.ReceivePhone,
                                  SendGoodsName = d.SendGoodsName,
                                  SendGoodsDate = d.SendGoodsDate,
                                  CourierNumber = d.CourierNumber,
                                  ExpressId = (!string.IsNullOrEmpty(d.ExpressId)) ? _expressManageService.GetByIdAsync(d.ExpressId).Result.ExpressCode.ToString() : "",
                                  ExpressName = (!string.IsNullOrEmpty(d.ExpressId)) ? _expressManageService.GetByIdAsync(d.ExpressId).Result.ExpressName.ToString() : ""
                              };
            FxPageInfo<MiniProgramOrderTradeVo> orderTradePageInfo = new FxPageInfo<MiniProgramOrderTradeVo>();
            orderTradePageInfo.TotalCount = q.TotalCount;
            orderTradePageInfo.List = orderTrades;
            return ResultData<FxPageInfo<MiniProgramOrderTradeVo>>.Success().AddData("orderTrades", orderTradePageInfo);
        }


        /// <summary>
        /// 导出小程序订单交易列表
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="isSendGoods">是否已发货，null：全部</param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        [HttpGet("exportMiniProgramOrderLlist")]
        [FxInternalAuthorize]
        public async Task<FileStreamResult> ExportMiniProgramMaterialOrderTradeListAsync(DateTime startDate, DateTime endDate, bool? isSendGoods, string keyword)
        {
            bool isHidePhone = true;
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            var q = await orderService.ExportMiniProgramMaterialOrderTradeList(startDate, endDate, employeeId, isSendGoods, keyword);
            var order = from d in q
                        select new ExportMiniProgramOrderTradeVo
                        {
                            Phone = d.Phone,
                            CreateDate = d.CreateDate,
                            Remark = d.Remark,
                            StatusText = d.StatusText,
                            Address = d.Address,
                            BindOrderIds = d.OrderIds,
                            GoodsCategory=d.CategoryName,
                            Goods = d.GoodsName,
                            Standard=d.Standard,
                            IntergrationAccounts = d.IntergrationAccounts,
                            TotalAmount = d.ActualPay,
                            Quantities = d.Quantities,
                            ReceiveName = d.ReceiveName,
                            ReceivePhone = d.ReceivePhone,
                            SendGoodsName = d.SendGoodsName,
                            SendGoodsDate = d.SendGoodsDate,
                            CourierNumber = d.CourierNumber,
                            ExpressName = (!string.IsNullOrEmpty(d.ExpressId)) ? _expressManageService.GetByIdAsync(d.ExpressId).Result.ExpressName.ToString() : "",
                            ExchageType=d.ExchangeType,
                            
                        };
            var exportOrder = order.ToList();
            var stream = ExportExcelHelper.ExportExcel(exportOrder);
            var result = File(stream, "application/vnd.ms-excel", $"" + startDate.ToString("yyyy年MM月dd日") + "-" + endDate.ToString("yyyy年MM月dd日") + "小程序实物订单.xls");
            return result;
        }

        /// <summary>
        /// 根据交易编号获取订单列表
        /// </summary>
        /// <param name="tradeId"></param>
        /// <returns></returns>
        [HttpGet("listByTradeId/{tradeId}")]
        public async Task<ResultData<List<OrderInfoVo>>> GetListByTradeIdAsync(string tradeId)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            var orders = from d in await orderService.GetListByTradeIdAsync(employeeId, tradeId)
                         select new OrderInfoVo
                         {
                             Id = d.Id,
                             GoodsId = d.GoodsId,
                             GoodsName = d.GoodsName + " " + goodsInfoService.GetByIdAsync(d.GoodsId).Result.Standard,
                             ThumbPicUrl = d.ThumbPicUrl,
                             Phone = d.Phone,
                             EncryptPhone = d.EncryptPhone,
                             AppointmentHospital = d.AppointmentHospital,
                             IsAppointment = d.IsAppointment,
                             StatusCode = d.StatusCode,
                             StatusText = d.StatusText,
                             ActualPayment = d.ActualPayment,
                             CreateDate = d.CreateDate,
                             AppType = d.AppType,
                             AppTypeText = d.AppTypeText,
                             OrderType = d.OrderType,
                             OrderTypeText = d.OrderTypeText,
                             Quantity = d.Quantity,
                             IntegrationQuantity = d.IntegrationQuantity,
                             ExchangeType = d.ExchangeType,
                             ExchangeTypeText = d.ExchangeTypeText,
                             TradeId = d.TradeId,
                             Standard=d.Standard,
                             CategoryName=d.GoodsCategory
                         };
            return ResultData<List<OrderInfoVo>>.Success().AddData("orders", orders.ToList());
        }



        /// <summary>
        /// 发货
        /// </summary>
        /// <param name="sendGoodsVo"></param>
        /// <returns></returns>
        [HttpPost("sendGoods")]
        public async Task<ResultData> SendGoodsAsync(SendGoodsVo sendGoodsVo)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            SendGoodsDto sendGoodsDto = new SendGoodsDto();
            sendGoodsDto.TradeId = sendGoodsVo.TradeId;
            sendGoodsDto.CourierNumber = sendGoodsVo.CourierNumber;
            sendGoodsDto.HandleBy = employeeId;
            sendGoodsDto.ExpressId = sendGoodsVo.ExpressId;
            await orderService.SendGoodsAsync(sendGoodsDto);
            return ResultData.Success();
        }


        /// <summary>
        /// 获取下单平台列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("appTypeList")]
        public ResultData<List<OrderAppTypeVo>> GetOrderAppTypeList()
        {
            var orderAppTypes = from d in orderService.GetOrderAppTypeList()
                                select new OrderAppTypeVo
                                {
                                    OrderType = d.OrderType,
                                    AppTypeText = d.AppTypeText
                                };
            return ResultData<List<OrderAppTypeVo>>.Success().AddData("orderAppTypes", orderAppTypes.ToList());
        }
        /// <summary>
        /// 获取订单性质列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("orderNatureList")]
        public ResultData<List<OrderNatureTypeVo>> GetOrderNatureList()
        {
            var orderNatures = from d in orderService.GetOrderNatureList()
                               select new OrderNatureTypeVo
                               {
                                   OrderNature = d.OrderNature,
                                   OrderNatureText = d.OrderNatureText
                               };
            return ResultData<List<OrderNatureTypeVo>>.Success().AddData("orderNatureList", orderNatures.ToList());
        }
    }
}