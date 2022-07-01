using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Dto.Gift;
using Fx.Amiya.IService;
using Fx.Amiya.MiniProgram.Api.Filters;
using Fx.Amiya.MiniProgram.Api.Vo.Gift;
using Fx.Amiya.MiniProgram.Api.Vo.Order;
using Fx.Common;
using Fx.Infrastructure;
using Fx.Open.Infrastructure.Web;
using jos_sdk_net.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.MiniProgram.Api.Controllers
{
    [Route("amiya/wxmini/[controller]")]
    [ApiController]
    public class GiftController : ControllerBase
    {
        private IGiftService giftService;
        private IMiniSessionStorage sessionStorage;
        private TokenReader tokenReader;
        private IOrderService _orderService;

        public GiftController(IGiftService giftService,
            TokenReader tokenReader,
            IMiniSessionStorage sessionStorage,
            IOrderService orderService)
        {
            this.giftService = giftService;
            this.tokenReader = tokenReader;
            this.sessionStorage = sessionStorage;
            _orderService = orderService;
        }


        /// <summary>
        /// 获取可领取礼品数量
        /// </summary>
        /// <returns></returns>
        [HttpGet("canReceiveQuantity")]
        [FxAmiyaApiUserTypeAuthorization(UserType.Customer)]
        public async Task<ResultData<int>> GetCanReceiveQuantityOfWxAsync()
        {
            var token = tokenReader.GetToken();
            var sesssionInfo = sessionStorage.GetSession(token);
            string customerId = sesssionInfo.FxCustomerId;
            int quantity = await giftService.GetCanReceiveQuantityOfWxAsync(customerId);
            return ResultData<int>.Success().AddData("quantity", quantity);
        }





        /// <summary>
        /// 获取礼品列表
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("infoList")]
        public async Task<ResultData<FxPageInfo<GiftInfoSimpleVo>>> GetSimpleListOfWxAsync(string name, int pageNum, int pageSize)
        {
            var q = await giftService.GetSimpleListOfWxAsync(name, pageNum, pageSize);
            var gift = from d in q.List
                       select new GiftInfoSimpleVo
                       {
                           Id = d.Id,
                           ThumbPicUrl = d.ThumbPicUrl,
                           Name = d.Name
                       };
            FxPageInfo<GiftInfoSimpleVo> giftPageInfo = new FxPageInfo<GiftInfoSimpleVo>();
            giftPageInfo.TotalCount = q.TotalCount;
            giftPageInfo.List = gift;
            return ResultData<FxPageInfo<GiftInfoSimpleVo>>.Success().AddData("giftInfo", giftPageInfo);
        }





        /// <summary>
        /// 领取礼品
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("receive")]
        [FxAmiyaApiUserTypeAuthorization(UserType.Customer)]
        public async Task<ResultData> AddReceiveGiftAsync(AddReceiveGiftVo addVo)
        {

            var token = tokenReader.GetToken();
            var sesssionInfo = sessionStorage.GetSession(token);
            string customerId = sesssionInfo.FxCustomerId;
            AddReceiveGiftDto addDto = new AddReceiveGiftDto();
            addDto.OrderId = addVo.OrderId;
            addDto.GiftId = addVo.GiftId;
            addDto.AddressId = addVo.AddressId;
            await giftService.AddReceiveGiftAsync(addDto, customerId);
            return ResultData.Success();
        }





        /// <summary>
        /// 获取已领取礼品
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("receiveGift")]
        [FxAmiyaApiUserTypeAuthorization(UserType.Customer)]
        public async Task<ResultData<FxPageInfo<ReceiveGiftOfWxVo>>> GetReceiveGiftListByCustomerIdAsync(int pageNum, int pageSize)
        {
            var token = tokenReader.GetToken();
            var sesssionInfo = sessionStorage.GetSession(token);
            string customerId = sesssionInfo.FxCustomerId;

            var q = await giftService.GetReceiveGiftListByCustomerIdAsync(customerId, pageNum, pageSize);
            var receiveGift = from d in q.List
                              select new ReceiveGiftOfWxVo
                              {
                                  CourierNumber = d.CourierNumber,
                                  ExpressId = d.ExpressId,
                                  ReceiverPhone = d.ReceiverPhone,
                                  DeliveryStatus = d.DeliveryStatus,
                                  GiftInfos = (from t in d.GiftInfos
                                               select new ReceiveGiftInfoSimpleVo
                                               {
                                                   Id = t.Id,
                                                   GiftId = t.GiftId,
                                                   GiftName = t.GiftName,
                                                   ThumbPicUrl = t.ThumbPicUrl
                                               }).ToList()
                              };



            FxPageInfo<ReceiveGiftOfWxVo> receiveGiftPageInfo = new FxPageInfo<ReceiveGiftOfWxVo>();
            receiveGiftPageInfo.TotalCount = q.TotalCount;
            receiveGiftPageInfo.List = receiveGift;
            return ResultData<FxPageInfo<ReceiveGiftOfWxVo>>.Success().AddData("receiveGift", receiveGiftPageInfo);
        }


        /// <summary>
        /// 根据条件获取核销好礼快递信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("giftExpressInfo")]
        public async Task<ResultData<OrderExpressInfoVo>> GetGiftExpressInfoAsync([FromQuery]GetGiftExpressInfoVo input)
        {
            var orderExpressInfoDto = await _orderService.GetExpressInfo(input.ReceiverPhone,input.CourierNumber,input.ExpressId);
            OrderExpressInfoVo orderExpressInfoVo = new OrderExpressInfoVo();
            var orderExpressInfoDetails = from d in orderExpressInfoDto.data
                                          select new ExpressDetailsVo
                                          {
                                              time = d.time,
                                              content = d.context
                                          };
            orderExpressInfoVo.ExpressNo = orderExpressInfoDto.ExpressNo;
            orderExpressInfoVo.ExpressName = orderExpressInfoDto.ExpressName;
            orderExpressInfoVo.state = KuaiDi100Utils.GetExpressState(orderExpressInfoDto.state);
            orderExpressInfoVo.ExpressDetailList = orderExpressInfoDetails.ToList();
            return ResultData<OrderExpressInfoVo>.Success().AddData("orderExpressInfoVo", orderExpressInfoVo);
        }
    }
}