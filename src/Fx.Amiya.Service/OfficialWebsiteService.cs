using Fx.Amiya.Core.Dto.Goods;
using Fx.Amiya.Core.Interfaces.Goods;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.ContentPlateFormOrder;
using Fx.Amiya.Dto.CustomerInfo;
using Fx.Amiya.Dto.HuiShouQianPay;
using Fx.Amiya.Dto.OfficialWebsite.Input;
using Fx.Amiya.Dto.OfficialWebsite.Result;
using Fx.Amiya.Dto.Order;
using Fx.Amiya.Dto.OrderAppInfo;
using Fx.Amiya.Dto.OrderRemark;
using Fx.Amiya.Dto.TmallOrder;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common.Utils;
using Fx.Infrastructure.DataAccess;
using jos_sdk_net.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Fx.Amiya.Service
{

    public class OfficialWebsiteService : IOfficialWebsiteService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IDalBindCustomerService _dalBindCustomerService;
        private readonly IContentPlatformService _contentPlatformService;
        private readonly IDalContentPlatformOrder _dalContentPlatformOrder;
        private readonly IDalLiveAnchor dalLiveAnchor;
        private readonly IDalAmiyaEmployee _dalAmiyaEmployee;
        private readonly IAmiyaGoodsDemandService amiyaGoodsDemandService;
        private readonly IOrderRemarkService orderRemarkService;
        private readonly IContentPlatFormCustomerPictureService _contentPlatFormCustomerPictureService;
        private readonly IShoppingCartRegistrationService _shoppingCartRegistration;
        private readonly IWxAppConfigService _wxAppConfigService;
        private readonly ICustomerService customerService;
        private readonly IDalGoodsInfo dalGoodsInfo;
        private readonly IDalGoodsStandardsPrice dalGoodsStandardsPrice;
        private readonly IOrderService orderService;
        private readonly IHuiShouQianPaymentService huiShouQianPaymentService;
        private readonly IGoodsInfo goodsInfoService;
        public OfficialWebsiteService(IUnitOfWork unitOfWork, IDalBindCustomerService dalBindCustomerService, IContentPlatformService contentPlatformService, IDalContentPlatformOrder dalContentPlatformOrder, IDalLiveAnchor dalLiveAnchor, IDalAmiyaEmployee dalAmiyaEmployee, IAmiyaGoodsDemandService amiyaGoodsDemandService, IOrderRemarkService orderRemarkService, IContentPlatFormCustomerPictureService contentPlatFormCustomerPictureService, IShoppingCartRegistrationService shoppingCartRegistration, IWxAppConfigService wxAppConfigService, ICustomerService customerService, IDalGoodsInfo dalGoodsInfo, IDalGoodsStandardsPrice dalGoodsStandardsPrice, IOrderService orderService, IHuiShouQianPaymentService huiShouQianPaymentService, IGoodsInfo goodsInfoService)
        {
            this.unitOfWork = unitOfWork;
            _dalBindCustomerService = dalBindCustomerService;
            _contentPlatformService = contentPlatformService;
            _dalContentPlatformOrder = dalContentPlatformOrder;
            this.dalLiveAnchor = dalLiveAnchor;
            _dalAmiyaEmployee = dalAmiyaEmployee;
            this.amiyaGoodsDemandService = amiyaGoodsDemandService;
            this.orderRemarkService = orderRemarkService;
            _contentPlatFormCustomerPictureService = contentPlatFormCustomerPictureService;
            _shoppingCartRegistration = shoppingCartRegistration;
            _wxAppConfigService = wxAppConfigService;
            this.customerService = customerService;
            this.dalGoodsInfo = dalGoodsInfo;
            this.dalGoodsStandardsPrice = dalGoodsStandardsPrice;
            this.orderService = orderService;
            this.huiShouQianPaymentService = huiShouQianPaymentService;
            this.goodsInfoService = goodsInfoService;
        }


        public async Task<OrderPayInfoDto> AddDesignOrderAsync(DesignOrderDto orderDto)
        {
            try
            {
                GetDesignOrderSignDto sign = new GetDesignOrderSignDto();
                sign.NickName = orderDto.NickName;
                sign.Phone = orderDto.Phone;
                sign.Gender = orderDto.Gender;
                sign.BirthDay = orderDto.BirthDay;
                sign.Profession = orderDto.Profession;
                sign.WechatRemark = orderDto.WechatRemark;
                sign.City = orderDto.City;
                var signResult = GetSign(sign);
                if (signResult != orderDto.Sign)
                {
                    throw new Exception("签名错误下单失败！");
                }
                unitOfWork.BeginTransaction();

                ContentPlateFormOrderAddDto input = new ContentPlateFormOrderAddDto();
                input.Phone = orderDto.Phone;
                input.ContentPlateFormId = "b0e992ad-1b7b-4397-a5fe-1bfbc1f0130e";
                input.EmployeeId = 188;
                input.LiveAnchorId = 160;
                input.LiveAnchorWeChatNo = "aac69783-0865-4ed9-ba0e-6d4b5f7668ea";
                input.Id = CreateOrderIdHelper.GetNextNumber();
                input.OrderType = 2;
                input.CreateDate = DateTime.Now;
                input.GoodsId = "0270a0f5-47b8-4fcd-80d1-e1a3ae9b5d51";
                input.ConsultationType = 2;
                input.CustomerName = orderDto.NickName;
                input.AddOrderPrice = 199;
                input.BelongMonth = 0;
                input.OrderSource = 1;
                input.CustomerSource = 5;
                input.CustomerType = 1;
                input.UnSendReason = null;
                input.ConsultationEmpId = 0;
                input.IsSupportOrder = false;
                input.SupportEmpId = 0;
                input.AcceptConsulting = null;
                input.HospitalDepartmentId = "7f9b164b-8560-4d32-bdbf-f7c28c55e0ae";
                input.GetCustomerType = 0;
                input.AppointmentDate = null;
                input.AppointmentHospitalId = 124;
                input.OrderStatus = 1;
                input.DepositAmount = 199;
                input.LateProjectStage = "";
                input.ConsultingContent = "";
                input.Remark = "";
                input.Sex = orderDto.Gender;
                input.CustomerPictures = new List<string>();

                var contentPlatForm = await _contentPlatformService.GetByIdAsync(input.ContentPlateFormId);
                var bind = await _dalBindCustomerService.GetAll()
                  .Include(e => e.CustomerServiceAmiyaEmployee)
                  .FirstOrDefaultAsync(e => e.BuyerPhone == input.Phone);
                if (bind != null)
                {
                    input.EmployeeId = bind.CustomerServiceId;
                    bind.NewConsumptionContentPlatform = (int)OrderFrom.ContentPlatFormOrder;
                    bind.NewContentPlatForm = contentPlatForm.ContentPlatformName;
                    bind.NewLiveAnchor = dalLiveAnchor.GetAll().Where(e => e.Id == input.LiveAnchorId).FirstOrDefault().Name;
                    bind.NewWechatNo = input.LiveAnchorWeChatNo;
                    await _dalBindCustomerService.UpdateAsync(bind, true);
                }
                else
                {
                    BindCustomerService bindCustomerService = new BindCustomerService();
                    bindCustomerService.CustomerServiceId = input.EmployeeId;
                    bindCustomerService.BuyerPhone = input.Phone;
                    bindCustomerService.UserId = null;
                    bindCustomerService.CreateBy = input.EmployeeId;
                    bindCustomerService.CreateDate = DateTime.Now;
                    var goodsInfo = await amiyaGoodsDemandService.GetByIdAsync(input.GoodsId);
                    bindCustomerService.FirstProjectDemand = "(" + goodsInfo.HospitalDepartmentName + ")" + goodsInfo.ProjectNname;
                    bindCustomerService.FirstConsumptionDate = DateTime.Now;
                    bindCustomerService.NewConsumptionContentPlatform = (int)OrderFrom.ContentPlatFormOrder;
                    bindCustomerService.NewContentPlatForm = contentPlatForm.ContentPlatformName;
                    var liveAnchor = dalLiveAnchor.GetAll().Where(e => e.Id == input.LiveAnchorId).FirstOrDefault();
                    if (liveAnchor != null)
                        if (liveAnchor != null)
                        {
                            bindCustomerService.NewLiveAnchor = liveAnchor.Name;
                        }
                    bindCustomerService.NewWechatNo = input.LiveAnchorWeChatNo;
                    bindCustomerService.AllPrice = 0;
                    bindCustomerService.AllOrderCount = 0;
                    bindCustomerService.RfmType = 9;
                    await _dalBindCustomerService.AddAsync(bindCustomerService, true);
                }

                ContentPlatformOrder order = new ContentPlatformOrder();
                order.Id = input.Id;
                order.OrderType = input.OrderType;
                order.ContentPlateformId = input.ContentPlateFormId;
                order.LiveAnchorId = input.LiveAnchorId;
                order.LiveAnchorWeChatNo = input.LiveAnchorWeChatNo;
                order.CreateDate = input.CreateDate;
                order.GoodsId = input.GoodsId;
                order.ConsulationType = input.ConsultationType;
                order.CustomerName = input.CustomerName;
                order.AddOrderPrice = input.AddOrderPrice;
                order.BelongMonth = input.BelongMonth;
                order.OrderSource = input.OrderSource;
                order.CustomerSource = input.CustomerSource;
                order.CustomerType = input.CustomerType;
                order.UnSendReason = input.UnSendReason;
                order.ConsultationEmpId = input.ConsultationEmpId;
                order.IsSupportOrder = input.IsSupportOrder;
                order.SupportEmpId = input.SupportEmpId;
                order.AcceptConsulting = input.AcceptConsulting;
                order.HospitalDepartmentId = input.HospitalDepartmentId;
                order.Phone = input.Phone;
                order.GetCustomerType = input.GetCustomerType;
                order.AppointmentDate = input.AppointmentDate;
                order.AppointmentHospitalId = input.AppointmentHospitalId;
                order.OrderStatus = input.OrderStatus;
                order.DepositAmount = input.DepositAmount;
                order.DealAmount = 0;
                order.DealPictureUrl = "";
                order.RepeatOrderPictureUrl = "";
                order.UnDealReason = "";
                order.LateProjectStage = input.LateProjectStage;
                order.ConsultingContent = input.ConsultingContent;
                order.Remark = input.Remark;
                order.CheckBy = 0;
                order.CheckPrice = 0.00M;
                order.CheckState = 0;
                order.SettlePrice = 0.00M;
                order.BelongEmpId = input.EmployeeId;
                order.IsRepeatProfundityOrder = false;
                await _dalContentPlatformOrder.AddAsync(order, true);
                foreach (var z in input.CustomerPictures)
                {
                    AddContentPlatFormCustomerPictureDto addPicture = new AddContentPlatFormCustomerPictureDto();
                    addPicture.ContentPlatFormOrderId = order.Id;
                    addPicture.CustomerPicture = z;
                    addPicture.Description = "顾客照片";
                    await _contentPlatFormCustomerPictureService.AddAsync(addPicture);
                }

                //小黄车更新录单触达
                await _shoppingCartRegistration.UpdateCreateOrderAsync(input.Phone);

                //订单备注新增数据
                if (!string.IsNullOrEmpty(order.Remark))
                {
                    AddOrderRemarkDto addOrderRemarkDto = new AddOrderRemarkDto();
                    addOrderRemarkDto.OrderId = order.Id;
                    addOrderRemarkDto.Remark = order.Remark;
                    addOrderRemarkDto.CreateBy = order.BelongEmpId.Value;
                    addOrderRemarkDto.BelongAuthorize = (int)AuthorizeStatusEnum.InternalAuthorize;
                    await orderRemarkService.AddAsync(addOrderRemarkDto);
                }

                //编辑客户基础信息
                EditCustomerDto editDto = new EditCustomerDto();
                var config = await _wxAppConfigService.GetWxAppCallCenterConfigAsync();
                string encryptPhon = ServiceClass.Encrypt(orderDto.Phone, config.PhoneEncryptKey);
                editDto.EncryptPhone = encryptPhon;
                editDto.Name = orderDto.NickName;
                editDto.Sex = orderDto.Gender;
                editDto.Birthday = orderDto.BirthDay;
                editDto.Occupation = orderDto.Profession;
                editDto.WechatNumber = orderDto.WechatRemark;
                editDto.City = orderDto.City;
                await customerService.EditAsync(editDto);
                unitOfWork.Commit();
                return new OrderPayInfoDto();
            }
            catch (Exception err)
            {
                unitOfWork.RollBack();
                throw new Exception(err.Message.ToString());
            }

        }

        public async Task<OrderPayInfoDto> AddGoodsOrderAsync(GoodsOrderDto order)
        {
            if (string.IsNullOrEmpty(order.Sign))
            {
                throw new Exception("下单数据异常,请检查后重试");
            }
            GetGoodsOrderSignDto orderSign = new GetGoodsOrderSignDto();
            orderSign.GoodsId = order.GoodsId;
            orderSign.Phone = order.Phone;
            orderSign.Quantity = order.Quantity;
            orderSign.HospitalName = order.HospitalName;
            orderSign.StandardId = order.StandardId;
            orderSign.Remark = order.Remark;
            orderSign.AppointmentDate = orderSign.AppointmentDate;
            if (order.Sign != GetGoodsOrderSign(orderSign))
            {
                throw new Exception("下单数据异常,请检查后重试");
            }
            if (order.Quantity <= 0)
            {
                throw new Exception("商品购买数量错误");
            }
            var goodsInfo = await goodsInfoService.GetByIdAsync(order.GoodsId);

            if (goodsInfo == null)
            {
                throw new Exception("商品编号错误");
            }
            if (goodsInfo.InventoryQuantity < order.Quantity)
            {
                throw new Exception("库存不足");
            }
            if (!goodsInfo.IsMaterial)
            {
                if (string.IsNullOrEmpty(order.HospitalName))
                {
                    throw new Exception("医院名称");
                }
                if (!order.AppointmentDate.HasValue)
                {
                    throw new Exception("请输入预约时间");
                }
            }
            var standard = dalGoodsStandardsPrice.GetAll().Where(e => e.GoodsId == order.GoodsId && e.Id == order.StandardId).SingleOrDefault();
            if (standard == null)
            {
                throw new Exception("商品规格编号错误");
            }
            var bindCustomerId = 188;
            var contentPlatForm = await _contentPlatformService.GetByIdAsync("b0e992ad-1b7b-4397-a5fe-1bfbc1f0130e");
            var bind = await _dalBindCustomerService.GetAll()
              .Include(e => e.CustomerServiceAmiyaEmployee)
              .FirstOrDefaultAsync(e => e.BuyerPhone == order.Phone);
            if (bind != null)
            {
                bindCustomerId = bind.CustomerServiceId;
                bind.NewConsumptionContentPlatform = (int)OrderFrom.ContentPlatFormOrder;
                bind.NewContentPlatForm = contentPlatForm.ContentPlatformName;
                await _dalBindCustomerService.UpdateAsync(bind, true);
            }
            else
            {
                BindCustomerService bindCustomerService = new BindCustomerService();
                
                bindCustomerService.CustomerServiceId = bindCustomerId;
                bindCustomerService.BuyerPhone = order.Phone;
                bindCustomerService.UserId = null;
                bindCustomerService.CreateBy = bindCustomerId;
                bindCustomerService.CreateDate = DateTime.Now;
                bindCustomerService.FirstProjectDemand = goodsInfo.Name;
                bindCustomerService.FirstConsumptionDate = DateTime.Now;
                bindCustomerService.NewConsumptionContentPlatform = (int)OrderFrom.ThirdPartyOrder;
                bindCustomerService.NewContentPlatForm = contentPlatForm.ContentPlatformName;
                bindCustomerService.AllPrice = 0;
                bindCustomerService.AllOrderCount = 0;
                bindCustomerService.RfmType = 9;
                await _dalBindCustomerService.AddAsync(bindCustomerService, true);
            }
            List<OrderInfoAddDto> list = new List<OrderInfoAddDto>();
            OrderTradeAddDto tradeAdd = new OrderTradeAddDto();
            tradeAdd.CustomerId = "";
            tradeAdd.CreateDate = DateTime.Now;
            tradeAdd.AddressId = order.Address;
            tradeAdd.Remark = order.Remark;
            OrderInfoAddDto orderAdd = new OrderInfoAddDto();
            orderAdd.Id = CreateOrderIdHelper.GetNextNumber();
            orderAdd.GoodsName = goodsInfo.Name;
            orderAdd.GoodsId = goodsInfo.Id;
            orderAdd.Phone = order.Phone;
            orderAdd.AppointmentDate = order.AppointmentDate;
            orderAdd.AppointmentHospital = order.HospitalName;
            orderAdd.StatusCode = OrderStatusCode.WAIT_BUYER_PAY;
            orderAdd.ActualPayment = standard.Price * order.Quantity;
            orderAdd.AccountReceivable = orderAdd.ActualPayment;
            orderAdd.CreateDate = tradeAdd.CreateDate;
            orderAdd.ThumbPicUrl = goodsInfo.ThumbPicUrl;
            orderAdd.AppType = (byte)AppType.OfficialWebsite;
            orderAdd.OrderType = goodsInfo.IsMaterial ? (byte)OrderType.MaterialOrder : (byte)OrderType.VirtualOrder;
            orderAdd.OrderNature = (byte)OrderNatureType.RegularOrder;
            orderAdd.Quantity = order.Quantity;
            orderAdd.Standard = order.StandardId;
            orderAdd.ExchangeType = (byte)ExchangeType.Wechat;
            orderAdd.BelongEmpId = bindCustomerId;
            orderAdd.TradeId = "";
            orderAdd.Standard = standard.Standards;
            list.Add(orderAdd);
            tradeAdd.OrderInfoAddList = list;
            var tradeId = await orderService.AddAmiyaOrderAsync(tradeAdd);
            //扣减库存
            await goodsInfoService.ReductionGoodsInventoryQuantityAsync(order.GoodsId, order.Quantity);
            #region 生成支付信息
            //OffcialWebSiteHuiShouQianPayRequestInfo payInfo = new OffcialWebSiteHuiShouQianPayRequestInfo();
            //decimal totalFee = orderAdd.ActualPayment.Value;
            //payInfo.PayType = "DYNAMIC_WECHAT";
            //payInfo.TransNo = Guid.NewGuid().ToString().Replace("-", "");
            //payInfo.OrderAmt = (totalFee * 100m).ToString().Split(".")[0];
            //payInfo.GoodsInfo = goodsInfo.Name;
            //payInfo.RequestDate = DateTime.Now.ToString("yyyyMMddHHmmss");
            //payInfo.Extend = tradeId;
            //var pay = await huiShouQianPaymentService.CreateOfficialWebsiteHuiShouQianOrder(payInfo);
            ////交易信息添加支付交易订单号
            //await orderService.TradeAddTransNoAsync(tradeId, pay.TransNo);
            #endregion
            OrderPayInfoDto orderPayInfo = new OrderPayInfoDto();
            orderPayInfo.PayUrl = "";
            return orderPayInfo;
        }

        /// <summary>
        /// 获取商品下单签名
        /// </summary>
        /// <param name="getSignVo"></param>
        /// <returns></returns>
        public async Task<OrderSignDto> GetGoodsOrderSignAsync(GetGoodsOrderSignDto getSignVo)
        {
            OrderSignDto sign = new OrderSignDto();
            sign.Sign = GetGoodsOrderSign(getSignVo);
            return sign;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="getSignVo"></param>
        /// <returns></returns>
        private string GetGoodsOrderSign(GetGoodsOrderSignDto getSignVo)
        {
            string salt = "amyGoodsOrder_2024#Ijuer@";
            StringBuilder builder = new StringBuilder();
            builder.Append($"appointmentdate={getSignVo.AppointmentDate};");
            builder.Append($"goodsid={getSignVo.GoodsId};");
            builder.Append($"phone={getSignVo.Phone};");
            builder.Append($"quantity={ getSignVo.Quantity};");
            builder.Append($"Remark={HttpUtility.UrlEncode(getSignVo.Remark)};");
            builder.Append($"standardid={getSignVo.StandardId};");
            builder.Append(salt);
            return MD5Helper.Get32MD5One(builder.ToString());
        }

        /// <summary>
        /// 获取签名
        /// </summary>
        /// <param name="getSignVo"></param>
        /// <returns></returns>
        public async Task<OrderSignDto> GetSignAsync(GetDesignOrderSignDto getSignVo)
        {
            OrderSignDto sign = new OrderSignDto();
            sign.Sign = GetSign(getSignVo);
            return sign;
        }

        private string GetSign(GetDesignOrderSignDto getSignVo)
        {
            string salt = "amyDesOrder_2024#Ijuer@";
            StringBuilder builder = new StringBuilder();
            builder.Append($"birthday={getSignVo.BirthDay};");
            builder.Append($"city={HttpUtility.UrlEncode(getSignVo.City)};");
            builder.Append($"gender={ getSignVo.Gender};");
            builder.Append($"nickname={HttpUtility.UrlEncode(getSignVo.NickName)};");
            builder.Append($"phone={getSignVo.Phone};");
            builder.Append($"profession={HttpUtility.UrlEncode(getSignVo.Profession)};");
            builder.Append($"wechatremark={HttpUtility.UrlEncode(getSignVo.WechatRemark)};");
            builder.Append(salt);
            return MD5Helper.Get32MD5One(builder.ToString());
        }
    }
}
