using Fx.Amiya.Background.Api.Vo.ContentPlateFormOrder;
using Fx.Amiya.Background.Api.Vo.Order;
using Fx.Amiya.Background.Api.Vo.OrderCheck;
using Fx.Amiya.Background.Api.Vo.TikTok;
using Fx.Amiya.Core.Dto.Goods;
using Fx.Amiya.Core.Dto.Integration;
using Fx.Amiya.Core.Interfaces.Goods;
using Fx.Amiya.Core.Interfaces.Integration;
using Fx.Amiya.Core.Interfaces.MemberCard;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.ContentPlateFormOrder;
using Fx.Amiya.Dto.TikTokOrder;
using Fx.Amiya.Dto.TmallOrder;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Amiya.Service;
using Fx.Amiya.SyncOrder.Core;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Common.Utils;
using Fx.Open.Infrastructure.Web;
using Jd.Api.Util;
using jos_sdk_net.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 抖点订单 API
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class TikTokOrderController : ControllerBase
    {
        private ITikTokOrderInfoService tikTokOrderService;
        private IHttpContextAccessor httpContextAccessor;
        private IGoodsInfo goodsInfoService;
        private IDalBindCustomerService _dalBindCustomerService;
        private IMemberCard memberCardService;
        private ICustomerService customerService;
        private IIntegrationAccount integrationAccountService;
        private IExpressManageService _expressManageService;
        private IAmiyaGoodsDemandService _amiyaGoodsDemandService;
        private IMemberRankInfo memberRankInfoService;
        private ITikTokOrderInfoService tikTokOrderInfoService;
        private IDalTikTokUserInfo dalTikTokUserInfo;
        private IDalTikTokOrderInfo dalTikTokOrderInfo;
        private ITikTokUserInfoService tikTokUserInfo;
        private IDalAmiyaEmployee dalAmiyaEmployee;
        private IDalBindCustomerService dalBindCustomerService;
        private IWxAppConfigService _wxAppConfigService;
        private ILiveAnchorService liveAnchorService;
        private IContentPlatformService contentPlatFormService;
        private ISendOrderInfoService _sendOrderInfoService;
        private ISyncTikTokOrder syncTikTokOrder;
        private IDalCustomerBaseInfo dalCustomerBaseInfo;

        public TikTokOrderController(ITikTokOrderInfoService orderService, IHttpContextAccessor httpContextAccessor, IGoodsInfo goodsInfoService, IDalBindCustomerService dalBindCustomerService, IMemberCard memberCardService, ICustomerService customerService, IIntegrationAccount integrationAccountService, IExpressManageService expressManageService, IAmiyaGoodsDemandService amiyaGoodsDemandService, IMemberRankInfo memberRankInfoService, ITikTokOrderInfoService tikTokOrderInfoService, IDalTikTokUserInfo dalTikTokUserInfo, ITikTokUserInfoService tikTokUserInfo, IDalAmiyaEmployee dalAmiyaEmployee, IWxAppConfigService wxAppConfigService, ILiveAnchorService liveAnchorService, IContentPlatformService contentPlatFormService, ISendOrderInfoService sendOrderInfoService, ITikTokOrderInfoService tikTokOrderService, IDalTikTokOrderInfo dalTikTokOrderInfo, ISyncTikTokOrder syncTikTokOrder, IDalCustomerBaseInfo dalCustomerBaseInfo)
        {
            this.tikTokOrderService = orderService;
            this.httpContextAccessor = httpContextAccessor;
            this.goodsInfoService = goodsInfoService;
            _dalBindCustomerService = dalBindCustomerService;
            this.memberCardService = memberCardService;
            this.customerService = customerService;
            this.integrationAccountService = integrationAccountService;
            _expressManageService = expressManageService;
            _amiyaGoodsDemandService = amiyaGoodsDemandService;
            this.memberRankInfoService = memberRankInfoService;
            this.tikTokOrderInfoService = tikTokOrderInfoService;
            this.dalTikTokUserInfo = dalTikTokUserInfo;
            this.tikTokUserInfo = tikTokUserInfo;
            this.dalAmiyaEmployee = dalAmiyaEmployee;
            _wxAppConfigService = wxAppConfigService;
            this.liveAnchorService = liveAnchorService;
            this.contentPlatFormService = contentPlatFormService;
            _sendOrderInfoService = sendOrderInfoService;
            this.tikTokOrderService = tikTokOrderService;
            this.dalTikTokOrderInfo = dalTikTokOrderInfo;
            this.syncTikTokOrder = syncTikTokOrder;
            this.dalCustomerBaseInfo = dalCustomerBaseInfo;
        }
        /// <summary>
        /// 获取tiktok订单列表
        /// </summary>
        /// <param name="startDate">创建开始时间</param>
        /// <param name="endDate">创建结束时间</param>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("tikTokOrderLlistWithPage")]
        public async Task<ResultData<FxPageInfo<TikTokOrderInfoVo>>> GetTikTokOrderListWithPageAsync(DateTime? startDate, DateTime? endDate, string keyword, int pageNum, int pageSize)
        {
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                var q = await tikTokOrderInfoService.GetOrderListWithPageAsync(startDate, endDate, keyword, pageNum, pageSize);
                var order = from d in q.List
                            select new TikTokOrderInfoVo
                            {
                                Id = d.Id,
                                ThumbPicUrl = d.ThumbPicUrl,
                                GoodsName = d.GoodsName,
                                NickName = d.BuyerNick,
                                GoodsId = d.GoodsId,
                                Phone = d.Phone,
                                EncryptPhone = d.EncryptPhone,
                                IsAppointment = d.IsAppointment,
                                StatusCode = d.StatusCode,
                                StatusText = d.StatusText,
                                ActualPayment = d.ActualPayment,
                                AccountReceivable=d.AccountReceivable,
                                CreateDate = d.CreateDate,
                                AppType = d.AppType,
                                AppTypeText = d.AppTypeText,
                                OrderType = d.OrderType,
                                OrderTypeText = d.OrderTypeText,
                                Quantity = d.Quantity,
                                ExchangeType = d.ExchangeType,
                                Description = d.Description,
                                ExchangeTypeText = d.ExchangeTypeText,
                                TradeId = d.TradeId,
                                LiveAnchor = d.LiveAnchorName,
                                LiveAnchorPlatForm = d.LiveAnchorPlatForm,
                                UpdateDate=d.UpdateDate
                            };
                FxPageInfo<TikTokOrderInfoVo> orderPageInfo = new FxPageInfo<TikTokOrderInfoVo>();
                orderPageInfo.TotalCount = q.TotalCount;
                orderPageInfo.List = order;
                return ResultData<FxPageInfo<TikTokOrderInfoVo>>.Success().AddData("order", orderPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<TikTokOrderInfoVo>>.Fail(ex.Message);
            }
        }
        /// <summary>
        /// 用户信息解密
        /// </summary>
        /// <param name="orderid">订单id</param>
        /// <returns></returns>
        [HttpGet("decryptUserInfo")]
        public async Task<ResultData> DecryptUserInfo(string orderid)
        {
            var info = dalTikTokOrderInfo.GetAll().Where(e => e.Id == orderid).Include(e => e.TikTokUserInfo).SingleOrDefault();
            if (!string.IsNullOrEmpty(info.Phone)) {
                return ResultData.Fail("用户信息已解密,请勿重复解密");
            }
            if (info.StatusCode== "TRADE_CLOSED" || info.StatusCode== "REFUNDING") {
                return ResultData.Fail("订单已无法解密");
            }
            var decryptRes = await tikTokUserInfo.DecryptUserInfoAsync(info.TikTokUserInfo.Id, orderid);
            if (decryptRes==null) {
                return ResultData.Fail("订单可解密时间已过,无法解密");
            }
            if (decryptRes != null)
            {
                TikTokUserInfoVo tikTokUserInfoVo = new TikTokUserInfoVo();
                tikTokUserInfoVo.Id = decryptRes.Id;
                tikTokUserInfoVo.Name = decryptRes.Name;
                tikTokUserInfoVo.Phone = decryptRes.Phone;
                return ResultData<TikTokUserInfoVo>.Success();
            }
            return ResultData.Fail("解密失败");
        }

        /// <summary>
        /// 录单
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("EntryOrder")]
        public async Task<ResultData> EntryOrderAsync(TikTokEntryOrderAddVo addVo)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);          
            //添加订单
            List<TikTokOrderAddDto> amiyaOrderList = new List<TikTokOrderAddDto>();
            TikTokOrderAddDto addDto = new TikTokOrderAddDto();
            addDto.Id = CreateOrderIdHelper.GetNextNumber();
            addDto.GoodsName = addVo.GoodsName;
            addDto.GoodsId = addVo.GoodsId;
            addDto.Phone = addVo.Phone;
            addDto.StatusCode = addVo.StatusCode;
            addDto.ActualPayment = addVo.ActualPayment;
            addDto.AccountReceivable = addVo.AccountReceivable;
            addDto.CreateDate = DateTime.Now;
            addDto.ThumbPicUrl = addVo.ThumbPicUrl;
            addDto.BuyerNick = addVo.NickName;
            addDto.AppType = (byte)AppType.Douyin;
            addDto.IsAppointment = addVo.IsAppointment;
            addDto.OrderType = (addVo.OrderType.HasValue) ? addVo.OrderType.Value : 2;
            addDto.Quantity = (addVo.Quantity.HasValue) ? addVo.Quantity : 0;
            addDto.ExchangeType = addVo.ExchangeType;
            addDto.Description = addVo.Remark;
            amiyaOrderList.Add(addDto);
            OrderTradeAddDto orderTradeAdd = new OrderTradeAddDto();
            orderTradeAdd.CustomerId = "客服-" + employee.ToString();
            orderTradeAdd.CreateDate = DateTime.Now;
            orderTradeAdd.AddressId = 0;
            orderTradeAdd.Remark = addVo.Remark;
            orderTradeAdd.TikTokOrderInfoAddList = amiyaOrderList;
            orderTradeAdd.IsAdminAdd = true;
            await tikTokOrderInfoService.AddAmiyaOrderAsync(orderTradeAdd);
            return ResultData.Success();
        }
        /// <summary>
        /// 根据订单号查询要补单的信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("repairOrder")]
        public async Task<ResultData<TikTokInfoVo>> RepairOrder(TikTokRepairOrderVo input)
        {
                TikTokInfoVo result = new TikTokInfoVo();
                var amiyaOrder = await syncTikTokOrder.TranslateTradesSoldOrdersByOrderId(input.OrderId);
                var FirstOrder = amiyaOrder.FirstOrDefault();
                if (FirstOrder == null)
                {
                    throw new Exception("未找到对应的订单，请核对订单号后重试");
                }
                result.Id = FirstOrder.Id;
                result.GoodsName = FirstOrder.GoodsName;
                result.GoodsId = FirstOrder.GoodsId;
                result.Phone = FirstOrder.Phone;
                result.StatusCode = FirstOrder.StatusCode;
                result.ActualPayment = FirstOrder.ActualPayment;
                result.AccountReceivable = FirstOrder.ActualPayment;
                result.NickName = FirstOrder.BuyerNick;
                result.AppType = (byte)AppType.Douyin;
                result.IsAppointment = FirstOrder.IsAppointment;
                result.OrderType = FirstOrder.OrderType;
                result.OrderTypeText = ServiceClass.GetTikTokOrderTypeText((byte)FirstOrder.OrderType);
                result.Quantity = FirstOrder.Quantity;
                result.ThumbPicUrl = FirstOrder.ThumbPicUrl;
                result.CipherName = FirstOrder.CipherName;
                result.CipherPhone = FirstOrder.CipherPhone;
                result.Phone = FirstOrder.Phone;
                result.NickName = FirstOrder.BuyerNick;
                result.ExchangeType = 1;
                result.ExchangeTypeText = ServiceClass.GetExchangeTypeText(1);
                result.UpdateDate = FirstOrder.UpdateDate;
                result.CreateDate = FirstOrder.CreateDate;
            
            
            return ResultData<TikTokInfoVo>.Success().AddData("orderData", result);
        }

        /// <summary>
        /// 补单
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("AddOrder")]
        public async Task<ResultData> AddOrderAsync(TikTokOrderInfoAddVo addVo)
        {
            var order = dalTikTokOrderInfo.GetAll().SingleOrDefault(o=>o.Id==addVo.Id);
            if (order!=null) {
                throw new Exception("该订单已存在,请勿重复录入");
            }
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            //如果通过解密获取了手机号
            if (!string.IsNullOrEmpty(addVo.Phone))
            {             
                //添加订单
                List<TikTokOrderAddDto> amiyaOrderList = new List<TikTokOrderAddDto>();
                TikTokOrderAddDto addDto = new TikTokOrderAddDto();
                addDto.Id = addVo.Id;
                addDto.GoodsName = addVo.GoodsName;
                addDto.GoodsId = addVo.GoodsId;
                addDto.Phone = addVo.Phone;
                addDto.StatusCode = addVo.StatusCode;
                addDto.ActualPayment = addVo.ActualPayment;
                addDto.AccountReceivable = addVo.AccountReceivable;
                addDto.CreateDate = addVo.CreateDate;
                addDto.UpdateDate = addVo.UpdateDate;
                addDto.ThumbPicUrl = addVo.ThumbPicUrl;
                addDto.BuyerNick = addVo.NickName;
                addDto.AppType = (byte)AppType.Douyin;
                addDto.BuyerNick = addVo.NickName;
                addDto.IsAppointment = addVo.IsAppointment;
                addDto.BelongEmpId = employeeId;
                addDto.OrderType = (addVo.OrderType.HasValue) ? addVo.OrderType.Value : (byte)0;
                addDto.Quantity = (addVo.Quantity.HasValue) ? addVo.Quantity : 0;
                addDto.IntegrationQuantity = 0;
                addDto.ExchangeType = addVo.ExchangeType;
                addDto.CipherName = addVo.CipherName;
                addDto.CipherPhone = addVo.CipherPhone;
                amiyaOrderList.Add(addDto);
                OrderTradeAddDto orderTradeAdd = new OrderTradeAddDto();
                orderTradeAdd.CustomerId = "客服-" + employee.Name.ToString();
                orderTradeAdd.CreateDate = DateTime.Now;
                orderTradeAdd.AddressId = 0;
                orderTradeAdd.Remark = addVo.Remark;
                orderTradeAdd.TikTokOrderInfoAddList = amiyaOrderList;
                orderTradeAdd.IsAdminAdd = true;
                await tikTokOrderService.AddAmiyaOrderAsync(orderTradeAdd);
            }
            else {
                //如果没有解密信息
 
                //添加tiktok用户信息
                TikTokUserInfo tikTokUserInfo = new TikTokUserInfo();
                tikTokUserInfo.CipherName = addVo.CipherName;
                tikTokUserInfo.CipherPhone = addVo.CipherPhone;
                tikTokUserInfo.Id = GuidUtil.NewGuidShortString();
                await dalTikTokUserInfo.AddAsync(tikTokUserInfo, true);

                //添加订单
                List<TikTokOrderAddDto> amiyaOrderList = new List<TikTokOrderAddDto>();
                TikTokOrderAddDto addDto = new TikTokOrderAddDto();
                addDto.Id = addVo.Id;
                addDto.GoodsName = addVo.GoodsName;
                addDto.GoodsId = addVo.GoodsId;
                addDto.Phone = addVo.Phone;
                addDto.StatusCode = addVo.StatusCode;
                addDto.ActualPayment = addVo.ActualPayment;
                addDto.AccountReceivable = addVo.AccountReceivable;
                addDto.CreateDate = addVo.CreateDate;
                addDto.UpdateDate = addVo.UpdateDate;
                addDto.ThumbPicUrl = addVo.ThumbPicUrl;
                addDto.BuyerNick = addVo.NickName;
                addDto.AppType = (byte)AppType.Douyin;
                addDto.BuyerNick = addVo.NickName;
                addDto.IsAppointment = addVo.IsAppointment;
                addDto.BelongEmpId = employeeId;
                addDto.OrderType = (addVo.OrderType.HasValue) ? addVo.OrderType.Value : (byte)0;
                addDto.Quantity = (addVo.Quantity.HasValue) ? addVo.Quantity : 0;
                addDto.IntegrationQuantity = 0;
                addDto.ExchangeType = addVo.ExchangeType;
                addDto.TikTokUserId = tikTokUserInfo.Id;
                addDto.CipherName = addVo.CipherName;
                addDto.CipherPhone = addVo.CipherPhone;
                addDto.UpdateDate = addVo.UpdateDate;
                amiyaOrderList.Add(addDto);
                OrderTradeAddDto orderTradeAdd = new OrderTradeAddDto();
                orderTradeAdd.CustomerId = "客服-" + employee.Name.ToString();
                orderTradeAdd.CreateDate = DateTime.Now;
                orderTradeAdd.AddressId = 0;
                orderTradeAdd.Remark = addVo.Remark;
                orderTradeAdd.TikTokOrderInfoAddList = amiyaOrderList;
                orderTradeAdd.IsAdminAdd = true;
                await tikTokOrderService.AddAmiyaOrderAsync(orderTradeAdd);
            }
            return ResultData.Success();
        }
        /// <summary>
        /// 订单校对
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /*[HttpPost("CheckOrder")]
        public async Task<ResultData> CheckOrderAsync(RepairOrderVo input)
        {
            TikTokInfoVo result = new TikTokInfoVo();
            if (input.OrderAppType == (byte)AppType.Tmall)
            {
                var amiyaOrder = await syncTikTokOrder.TranslateTradesSoldOrdersByOrderId(input.OrderId);
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
                await tikTokOrderService.UpdateOrderStatusAsync(result.Id, result.StatusCode, result.ActualPayment, result.AccountReceivable, result.UpdateDate, result.WriteOffDate);
            }
            return ResultData.Success();
        }*/
        /// <summary>
        /// 订单归属主播
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /*[HttpPost("LiveAnchorOrder")]
        public async Task<ResultData> LiveAnchorOrderAsync(LiveAnchorOrderVo input)
        {
            UpdateLiveAnchorOrderDto dto = new UpdateLiveAnchorOrderDto();
            dto.OrderId = input.OrderId;
            dto.LiveAnchorId = input.LiveAnchorId;
            await tikTokOrderService.UpdateOrderLiveAnchorAsync(dto);
            return ResultData.Success();
        }*/
        /// <summary>
        /// 修改下单平台订单归属客服
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /*[HttpPost("BelongEmployeeOrder")]
        public async Task<ResultData> BelongEmployeeOrderAsync(BelongEmpInfoOrderVo input)
        {
            UpdateBelongEmpInfoOrderDto dto = new UpdateBelongEmpInfoOrderDto();
            dto.OrderId = input.OrderId;
            dto.BelongEmpId = input.BelongEmpInfo;
            await tikTokOrderService.UpdateOrderBelongEmpIdAsync(dto);
            return ResultData.Success();
        }*/
        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="UpdateVo"></param>
        /// <returns></returns>
        /*[HttpPut("UpdateOrder")]
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
            TikTokOrderInfoUpdateDto updateDto = new TikTokOrderInfoUpdateDto();
            updateDto.Id = UpdateVo.OrderId;
            updateDto.GoodsName = UpdateVo.GoodsName;
            updateDto.Description = UpdateVo.Remark;
            updateDto.GoodsId = UpdateVo.GoodsId;
            updateDto.Phone = UpdateVo.Phone;
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
            await tikTokOrderService.UpdateAddedOrderAsync(updateDto);
            return ResultData.Success();
        }*/
        /// <summary>
        /// 完成订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /*[HttpPost("{id}")]
        public async Task<ResultData> FinishAsync(string id)
        {
            await tikTokOrderService.FinishOrderAsync(id);
            return ResultData.Success();
        }*/
        /// <summary>
        /// 审核订单
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        /*[HttpPut("checkOrder")]
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
            await tikTokOrderService.CheckOrderAsync(updateDto);
            return ResultData.Success();
        }*/
        /// <summary>
        /// 订单审核后回款
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        /*[HttpPut("returnBackOrder")]
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
            await tikTokOrderService.ReturnBackOrderAsync(updateDto);
            return ResultData.Success();
        }*/
        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /*[HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(string id)
        {
            await tikTokOrderService.DeleteAsync(id);
            return ResultData.Success();
        }*/
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
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /*[HttpGet("tikTokOrderFinishLlistWithPage")]
        public async Task<ResultData<FxPageInfo<TikTokOrderInfoVo>>> GetOrderFinishListWithPageAsync(DateTime? writeOffStartDate, DateTime? writeOffEndDate, int? CheckState, bool? ReturnBackPriceState, string keyword, byte? appType, byte? orderNature, int pageNum, int pageSize)
        {
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                var q = await tikTokOrderService.GetOrderFinishListWithPageAsync(writeOffStartDate, writeOffEndDate, CheckState, ReturnBackPriceState, keyword, appType, orderNature, employeeId, pageNum, pageSize);
                var order = from d in q.List
                            select new TikTokOrderInfoVo
                            {
                                Id = d.Id,
                                ThumbPicUrl = d.ThumbPicUrl,
                                GoodsName = d.GoodsName,
                                NickName = d.BuyerNick,
                                GoodsId = d.GoodsId,
                                Phone = d.Phone,
                                EncryptPhone = d.EncryptPhone,
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
                                LiveAnchorPlatForm = d.LiveAnchorPlatForm,
                                CheckState = d.CheckState,
                                CheckPrice = d.CheckPrice,
                                CheckDate = d.CheckDate,
                                CheckByEmpName = d.CheckByEmpName,
                                CheckRemark = d.CheckRemark,
                                SettlePrice = d.SettlePrice,
                                IsReturnBackPrice = d.IsReturnBackPrice,
                                ReturnBackPrice = d.ReturnBackPrice,
                                ReturnBackDate = d.ReturnBackDate

                            };
                FxPageInfo<TikTokOrderInfoVo> orderPageInfo = new FxPageInfo<TikTokOrderInfoVo>();
                orderPageInfo.TotalCount = q.TotalCount;
                orderPageInfo.List = order;
                return ResultData<FxPageInfo<TikTokOrderInfoVo>>.Success().AddData("order", orderPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<TikTokOrderInfoVo>>.Fail(ex.Message);
            }
        }*/
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
        /*[HttpGet("exportTikTokOrderLlist")]
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
            var q = await tikTokOrderService.ExportOrderListAsync(startDate, endDate, writeOffStartDate, writeOffEndDate, keyword, statusCode, appType, orderNature, employeeId, isHidePhone);
            var order = from d in q
                        select new ExportOrderVo
                        {
                            Id = d.Id,
                            GoodsName = d.GoodsName,
                            NickName = d.BuyerNick,
                            GoodsId = d.GoodsId,
                            Phone = d.Phone,
                            AppointmentHospital = d.AppointmentHospital,
                            SendOrderHospital = d.SendOrderHospital,
                            ActualPayment = (d.ActualPayment.HasValue) ? d.ActualPayment.Value : 0,
                            CreateDate = d.CreateDate,
                            WriteOffDate = d.WriteOffDate,
                            AppTypeText = d.AppTypeText,
                            StatusText = d.StatusText,
                            Quantity = d.Quantity,
                            IntegrationQuantity = (d.IntegrationQuantity.HasValue) ? d.IntegrationQuantity.Value : 0,

                        };
            var exportOrder = order.ToList();
            var stream = ExportExcelHelper.ExportExcel(exportOrder);
            var result = File(stream, "application/vnd.ms-excel", $"" + startDate.Value.ToString("yyyy年MM月dd日") + "-" + endDate.Value.ToString("yyyy年MM月dd日") + "订单列表.xls");
            return result;
        }*/
        /// <summary>
        /// 根据加密手机号获取订单列表
        /// </summary>
        /// <param name="encryptPhone">加密手机号</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /*[HttpGet("listByEncryptPhone")]
        public async Task<ResultData<FxPageInfo<TikTokOrderInfoVo>>> GetListByEncryptPhoneAsync(string encryptPhone, int pageNum, int pageSize)
        {
            try
            {
                var q = await tikTokOrderService.GetListByEncryptPhoneAsync(encryptPhone, pageNum, pageSize);

                var order = from d in q.List
                            select new TikTokOrderInfoVo
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

                FxPageInfo<TikTokOrderInfoVo> orderPageInfo = new FxPageInfo<TikTokOrderInfoVo>();
                orderPageInfo.TotalCount = q.TotalCount;
                orderPageInfo.List = order;
                return ResultData<FxPageInfo<TikTokOrderInfoVo>>.Success().AddData("order", orderPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<TikTokOrderInfoVo>>.Fail(ex.Message);
            }
        }*/
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
        /*[HttpGet("unBindCustomerService")]
        public async Task<ResultData<FxPageInfo<TikTokOrderInfoVo>>> GetUnBindCustomerServiceOrderListAsync(string statusCode, string keyword, decimal? minPayment, decimal? maxPayment, byte? appType, int pageNum, int pageSize)
        {
            var q = await tikTokOrderService.GetUnBindCustomerServiceOrderListAsync(statusCode, keyword, minPayment, maxPayment, appType, pageNum, pageSize);
            var order = from d in q.List
                        select new TikTokOrderInfoVo
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

            FxPageInfo<TikTokOrderInfoVo> orderPageInfo = new FxPageInfo<TikTokOrderInfoVo>();
            orderPageInfo.TotalCount = q.TotalCount;
            orderPageInfo.List = order;
            return ResultData<FxPageInfo<TikTokOrderInfoVo>>.Success().AddData("order", orderPageInfo);
        }*/
        /// <summary>
        /// 获取已绑定了客服的订单列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="customerServiceId"></param>
        /// <param name="appType">下单平台</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /*[HttpGet("bindCustomerServieOrderList")]
        public async Task<ResultData<FxPageInfo<BindCustomerServiceOrderVo>>> GetBindCustomerServieOrderListAsync(string keyword, int? customerServiceId, byte? appType, string statusCode, decimal? minPayment, decimal? maxPayment, int pageNum, int pageSize)
        {
            var q = await tikTokOrderInfoService.GetBindCustomerServieOrderListAsync(keyword, customerServiceId, appType, statusCode, minPayment, maxPayment, pageNum, pageSize);
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
        }*/
        ///// <summary>
        ///// 获取订单数据
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet("headOrderData")]
        //public async Task<ResultData<OrderDataVo>> GetHeadOrderDataAsync(int? employeeId)
        //{
        //    OrderDataVo orderDataVo = new OrderDataVo();
        //    if (employeeId == null)
        //    {
        //        var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
        //        employeeId = Convert.ToInt32(employee.Id);
        //        orderDataVo.TotalOrderQuantity = await tikTokOrderInfoService.GetTotalOrderQuantityAsync((int)employeeId);
        //        orderDataVo.TodayIncrementQuantity = await tikTokOrderInfoService.GetTodayIncrementQuantityAsync((int)employeeId);
        //        orderDataVo.LatelyStatusChangeDate = await tikTokOrderInfoService.GetLatelyStatusChangeDateAsync((int)employeeId);
        //        orderDataVo.UnBindCustoemrServiceQuantity = await tikTokOrderInfoService.GetUnBindOrderQuantityAsync((int)employeeId);
        //        orderDataVo.UnSendOrderQuantity = await tikTokOrderInfoService.GetUnSendOrderQuantityAsync((int)employeeId);
        //        return ResultData<OrderDataVo>.Success().AddData("orderData", orderDataVo);
        //    }
        //    else
        //    {
        //        orderDataVo.TotalOrderQuantity = 0;
        //        orderDataVo.TodayIncrementQuantity = 0;
        //        orderDataVo.LatelyStatusChangeDate = null;
        //        orderDataVo.UnBindCustoemrServiceQuantity = 0;
        //        orderDataVo.UnSendOrderQuantity = 0;
        //        return ResultData<OrderDataVo>.Success().AddData("orderData", orderDataVo);
        //    }

        //}
        /// <summary>
        /// 订单各状态数量
        /// </summary>
        /// <returns></returns>
        /*[HttpGet("orderStatusData")]
        public async Task<ResultData<List<OrderStatusDataVo>>> GetOrderStatusDataAsync(int? employeeId)
        {
            if (employeeId == null)
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                employeeId = Convert.ToInt32(employee.Id);
            }


            var order = from d in await tikTokOrderInfoService.GetOrderStatusDataAsync((int)employeeId)
                        select new OrderStatusDataVo
                        {
                            StatusText = d.StatusText,
                            Quantity = d.Quantity
                        };

            return ResultData<List<OrderStatusDataVo>>.Success().AddData("order", order.ToList());
        }*/
        /// <summary>
        /// 获取今天新增订单
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /*[HttpGet("todayIncrementList")]
        public async Task<FxPageInfo<TikTokOrderInfoVo>> GetTodayIncrementListAsync(int pageNum, int pageSize)
        {
            var q = await tikTokOrderInfoService.GetTodayIncrementListAsync(pageNum, pageSize);
            var order = from d in q.List
                        select new TikTokOrderInfoVo
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
            FxPageInfo<TikTokOrderInfoVo> orderPageInfo = new FxPageInfo<TikTokOrderInfoVo>();
            orderPageInfo.TotalCount = q.TotalCount;
            orderPageInfo.List = order;
            return orderPageInfo;
        }*/
        /// <summary>
        /// 获取今日订单状态发生改变的订单列表
        /// </summary>
        /// <param name="employeeId">-1查全部</param>
        /// <param name="keyword"></param>
        /// <param name="statusCode">状态码</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /*[HttpGet("todayStatusChangeList")]
        public async Task<ResultData<FxPageInfo<TikTokOrderInfoVo>>> GetTodayStatusChangeListAsync(int? employeeId, string keyword, string statusCode, int pageNum, int pageSize)
        {
            if (employeeId == null)
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                employeeId = Convert.ToInt32(employee.Id);
            }
            var q = await tikTokOrderInfoService.GetTodayStatusChangeListAsync((int)employeeId, keyword, statusCode, pageNum, pageSize);
            var order = from d in q.List
                        select new TikTokOrderInfoVo
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

            FxPageInfo<TikTokOrderInfoVo> orderPageInfo = new FxPageInfo<TikTokOrderInfoVo>();
            orderPageInfo.TotalCount = q.TotalCount;
            orderPageInfo.List = order;
            return ResultData<FxPageInfo<TikTokOrderInfoVo>>.Success().AddData("order", orderPageInfo);
        }*/
        /// <summary>
        /// 根据员工编号获取订单列表
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="statusCode"></param>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /*[HttpGet("orderListByEmployeeId")]
        public async Task<ResultData<FxPageInfo<TikTokOrderInfoVo>>> GetOrderByEmployeeIdAsync(int employeeId, string statusCode, string keyword, int pageNum, int pageSize)
        {
            var q = await tikTokOrderInfoService.GetOrderByEmployeeIdAsync(employeeId, statusCode, keyword, pageNum, pageSize);
            var order = from d in q.List
                        select new TikTokOrderInfoVo
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
            FxPageInfo<TikTokOrderInfoVo> orderPageInfo = new FxPageInfo<TikTokOrderInfoVo>();
            orderPageInfo.TotalCount = q.TotalCount;
            orderPageInfo.List = order;
            return ResultData<FxPageInfo<TikTokOrderInfoVo>>.Success().AddData("order", orderPageInfo);
        }*/
        /// <summary>
        /// 根据订单编号获取订单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /*[HttpGet("byId/{id}")]
        public async Task<ResultData<TikTokOrderInfoVo>> GetByIdAsync(string id)
        {
            var order = await tikTokOrderInfoService.GetByIdInCRMAsync(id);
            TikTokOrderInfoVo tikTokOrderVo = new TikTokOrderInfoVo();
            tikTokOrderVo.Id = order.Id;
            tikTokOrderVo.GoodsName = order.GoodsName;
            tikTokOrderVo.NickName = order.BuyerNick;
            tikTokOrderVo.GoodsId = order.GoodsId;
            tikTokOrderVo.OrderNature = order.OrderNature;
            tikTokOrderVo.ThumbPicUrl = order.ThumbPicUrl;
            tikTokOrderVo.OrderType = order.OrderType;
            tikTokOrderVo.Phone = order.Phone;
            tikTokOrderVo.EncryptPhone = order.EncryptPhone;
            tikTokOrderVo.AppointmentHospital = order.AppointmentHospital;
            tikTokOrderVo.IsAppointment = order.IsAppointment;
            tikTokOrderVo.Description = order.Description;
            tikTokOrderVo.StatusCode = order.StatusCode;
            tikTokOrderVo.StatusText = order.StatusText;
            tikTokOrderVo.ActualPayment = order.ActualPayment;
            tikTokOrderVo.CreateDate = order.CreateDate;
            tikTokOrderVo.UpdateDate = order.UpdateDate;
            tikTokOrderVo.AppType = order.AppType;
            tikTokOrderVo.AppTypeText = order.AppTypeText;
            tikTokOrderVo.ExchangeType = order.ExchangeType;
            tikTokOrderVo.ExchangeTypeText = order.ExchangeTypeText;
            tikTokOrderVo.Quantity = order.Quantity;

            tikTokOrderVo.WriteOffDate = order.WriteOffDate;
            tikTokOrderVo.LiveAnchor = order.LiveAnchorName;
            tikTokOrderVo.IsReturnBackPrice = order.IsReturnBackPrice;
            tikTokOrderVo.LiveAnchorPlatForm = order.LiveAnchorPlatForm;
            tikTokOrderVo.OrderNatureText = order.OrderNatureText;
            tikTokOrderVo.BelongEmpName = order.BelongEmpName;
            tikTokOrderVo.SendOrderHospital = order.SendOrderHospital;
            tikTokOrderVo.FinalConsumptionHospital = order.FinalConsumptionHospital;
            tikTokOrderVo.AccountReceivable = order.AccountReceivable;
            tikTokOrderVo.OrderTypeText = order.OrderTypeText;
            tikTokOrderVo.CheckState = order.CheckState;
            tikTokOrderVo.CheckPrice = order.CheckPrice;
            tikTokOrderVo.CheckDate = order.CheckDate;
            tikTokOrderVo.SettlePrice = order.SettlePrice;
            tikTokOrderVo.CheckByEmpName = order.CheckByEmpName;
            tikTokOrderVo.CheckRemark = order.CheckRemark;
            tikTokOrderVo.ReturnBackPrice = order.ReturnBackPrice;
            tikTokOrderVo.ReturnBackDate = order.ReturnBackDate;

            return ResultData<TikTokOrderInfoVo>.Success().AddData("order", tikTokOrderVo);
        }*/
        /// <summary>
        /// 根据核销编号获取订单信息
        /// </summary>
        /// <param name="writeOffCode">核销编号</param>
        /// <returns></returns>
        /*[HttpGet("byWriteOffCode")]
        public async Task<ResultData<List<TikTokOrderInfoVo>>> GetByWriteOffCodeAsync([Required] string writeOffCode)
        {
            List<TikTokOrderInfoVo> orderInfoResultList = new List<TikTokOrderInfoVo>();
            var orderResult = await tikTokOrderInfoService.GetOrderInfoByWriteOffCode(writeOffCode);
            foreach (var order in orderResult)
            {
                for (int x = 0; x < order.Quantity - order.AlreadyWriteOffAmount; x++)
                {
                    TikTokOrderInfoVo tmallOrderVo = new TikTokOrderInfoVo();
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
            return ResultData<List<TikTokOrderInfoVo>>.Success().AddData("order", orderInfoResultList);
        }*/
        /// <summary>
        /// 核销订单
        /// </summary>
        /// <param name="orderId">订单号</param>
        /// <param name="hospitalId">医院id</param>
        /// <returns></returns>
        /*[HttpPut("WriteOff")]
        public async Task<ResultData> WriteOffOrderAsync([Required] string orderId, [Required] int hospitalId)
        {
            await tikTokOrderInfoService.WriteOffAsync(orderId, hospitalId);
            return ResultData.Success();
        }*/
        /// <summary>
        /// 记录订单最终核销医院
        /// </summary>
        /// <param name="orderId">订单号</param>
        /// <param name="hospitalId">医院id</param>
        /// <returns></returns>
        /*[HttpPut("UpdateOrderFinalConsumptionHospital")]
        public async Task<ResultData> UpdateOrderFinalConsumptionHospital([Required] string orderId, [Required] int hospitalId)
        {
            await tikTokOrderInfoService.UpdateOrderFinalConsumptionHospital(orderId, hospitalId);
            return ResultData.Success();
        }*/
        /// <summary>
        /// 根据交易编号获取订单列表
        /// </summary>
        /// <param name="tradeId"></param>
        /// <returns></returns>
        /*[HttpGet("listByTradeId/{tradeId}")]
        public async Task<ResultData<List<TikTokOrderInfoVo>>> GetListByTradeIdAsync(string tradeId)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            var orders = from d in await tikTokOrderInfoService.GetListByTradeIdAsync(employeeId, tradeId)
                         select new TikTokOrderInfoVo
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

                         };
            return ResultData<List<TikTokOrderInfoVo>>.Success().AddData("orders", orders.ToList());
        }*/
        /// <summary>
        /// 发货
        /// </summary>
        /// <param name="sendGoodsVo"></param>
        /// <returns></returns>
        /*[HttpPost("sendGoods")]
        public async Task<ResultData> SendGoodsAsync(SendGoodsVo sendGoodsVo)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            SendGoodsDto sendGoodsDto = new SendGoodsDto();
            sendGoodsDto.TradeId = sendGoodsVo.TradeId;
            sendGoodsDto.CourierNumber = sendGoodsVo.CourierNumber;
            sendGoodsDto.HandleBy = employeeId;
            sendGoodsDto.ExpressId = sendGoodsVo.ExpressId;
            await tikTokOrderInfoService.SendGoodsAsync(sendGoodsDto);
            return ResultData.Success();
        }*/
        /// <summary>
        /// 获取下单平台列表
        /// </summary>
        /// <returns></returns>
        /*[HttpGet("appTypeList")]
        public ResultData<List<OrderAppTypeVo>> GetOrderAppTypeList()
        {
            var orderAppTypes = from d in tikTokOrderInfoService.GetOrderAppTypeList()
                                select new OrderAppTypeVo
                                {
                                    OrderType = d.OrderType,
                                    AppTypeText = d.AppTypeText
                                };
            return ResultData<List<OrderAppTypeVo>>.Success().AddData("orderAppTypes", orderAppTypes.ToList());
        }*/
        /// <summary>
        /// 获取订单性质列表
        /// </summary>
        /// <returns></returns>
        /*[HttpGet("orderNatureList")]
        public ResultData<List<OrderNatureTypeVo>> GetOrderNatureList()
        {
            var orderNatures = from d in tikTokOrderInfoService.GetOrderNatureList()
                               select new OrderNatureTypeVo
                               {
                                   OrderNature = d.OrderNature,
                                   OrderNatureText = d.OrderNatureText
                               };
            return ResultData<List<OrderNatureTypeVo>>.Success().AddData("orderNatureList", orderNatures.ToList());
        }*/

    }

}

