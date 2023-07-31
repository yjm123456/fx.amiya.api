using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.WeChatVideo;
using Fx.Amiya.Background.Api.Vo.WeChatVideo.Input;
using Fx.Amiya.Background.Api.Vo.WeChatVideo.Result;
using Fx.Amiya.Dto.WechatVideoOrder;
using Fx.Amiya.IService;
using Fx.Amiya.SyncOrder.Core;
using Fx.Amiya.SyncOrder.WeChatVideo;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class WeChatVideoOrderController : ControllerBase
    {
        private readonly IWeChatVideoOrderService weChatVideoOrderService;
        private readonly ISyncWeChatVideoOrder syncWeChatVideoOrder;
        private readonly ILiveAnchorService liveAnchorService;
        private readonly ISyncWeChatVideoOrder _syncTikTokOrder;

        public WeChatVideoOrderController(IWeChatVideoOrderService weChatVideoOrderService, ISyncWeChatVideoOrder syncWeChatVideoOrder, ILiveAnchorService liveAnchorService, ISyncWeChatVideoOrder syncTikTokOrder)
        {
            this.weChatVideoOrderService = weChatVideoOrderService;
            this.syncWeChatVideoOrder = syncWeChatVideoOrder;
            this.liveAnchorService = liveAnchorService;
            _syncTikTokOrder = syncTikTokOrder;
        }
        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<FxPageInfo<WeChatVideoOrderInfoVo>>> GetListByPage([FromQuery] QueryListVo query) {
            var order=await  weChatVideoOrderService.GetListByPageAsync(query.KeyWord,query.StartDate,query.EndDate,query.BelongLiveAnchorId,query.Status,query.OrderType,query.PageSize.Value,query.PageNum.Value);
            FxPageInfo<WeChatVideoOrderInfoVo> fxPageInfo = new FxPageInfo<WeChatVideoOrderInfoVo>();
            fxPageInfo.TotalCount = order.TotalCount;
            fxPageInfo.List = order.List.Select(e => new WeChatVideoOrderInfoVo
            {
                Id = e.Id,
                GoodsName = e.GoodsName,
                GoodsId = e.GoodsId,
                Phone = e.Phone,
                StatusCode = e.StatusCode,
                StatusCodeText = e.StatusCodeText,
                ActualPayment = e.ActualPayment,
                AccountReceivable = e.AccountReceivable,
                CreateDate = e.CreateDate.ToString("s"),
                UpdateDate = e.UpdateDate?.ToString("s"),
                ThumbPicUrl = e.ThumbPicUrl,
                BuyerNick = e.BuyerNick,
                OrderType = e.OrderType,
                OrderTypeText =e.OrderTypeText,
                Quantity = e.Quantity,
                BelongLiveAnchorId = e.BelongLiveAnchorId,
                BelongLiveAnchorName = e.BelongLiveAnchorName,
                EncryptPhone=e.EncryptPhone
            }).ToList();
            return ResultData<FxPageInfo<WeChatVideoOrderInfoVo>>.Success().AddData("list",fxPageInfo);
        }
        /// <summary>
        /// 补单
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddWechatVideoOrderVo add) {
            WechatVideoAddDto addDto = new WechatVideoAddDto();
            addDto.Id = add.Id;
            addDto.GoodsName = add.GoodsName;
            addDto.GoodsId = add.GoodsId;
            addDto.Phone = add.Phone;
            addDto.StatusCode = add.StatusCode;
            addDto.ActualPayment = add.ActualPayment;
            addDto.AccountReceivable = add.AccountReceivable;
            addDto.CreateDate = add.CreateDate;
            addDto.UpdateDate = add.UpdateDate;
            addDto.ThumbPicUrl = add.ThumbPicUrl;
            addDto.BuyerNick = add.BuyerNick;
            addDto.OrderType = add.OrderType;
            addDto.Quantity = add.Quantity;
            addDto.BelongLiveAnchorId = add.BelongLiveAnchorId;
            await weChatVideoOrderService.AddAsync(new List<WechatVideoAddDto> { addDto });
            return ResultData.Success();
        }
        /// <summary>
        /// 根据订单id获取订单详情
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("getById")]
        public async Task<ResultData<WeChatVideoOrderInfoVo>> GetOrderInfoById([FromQuery] GetOrderByIdVo input) {
            var order= await  syncWeChatVideoOrder.GetOrderInfoByIdAsync(input.OrderId,null,input.BelongLiveAnchorId);
            if (order == null) throw new Exception("获取订单失败,请检查订单号或稍后重试！");
            WeChatVideoOrderInfoVo weChatVideoOrderInfoVo = new WeChatVideoOrderInfoVo();
            weChatVideoOrderInfoVo.Id = order.Id;
            weChatVideoOrderInfoVo.GoodsName = order.GoodsName;
            weChatVideoOrderInfoVo.GoodsId = order.GoodsId;
            weChatVideoOrderInfoVo.Phone = order.Phone;
            weChatVideoOrderInfoVo.StatusCode = order.StatusCode;
            weChatVideoOrderInfoVo.ActualPayment = order.ActualPayment;
            weChatVideoOrderInfoVo.AccountReceivable = order.AccountReceivable;
            weChatVideoOrderInfoVo.CreateDate = order.CreateDate.Value.ToString("s");
            weChatVideoOrderInfoVo.UpdateDate = order.UpdateDate.Value.ToString("s");
            weChatVideoOrderInfoVo.ThumbPicUrl = order.ThumbPicUrl;
            weChatVideoOrderInfoVo.BuyerNick = order.BuyerNick;
            weChatVideoOrderInfoVo.OrderType = order.OrderType;
            weChatVideoOrderInfoVo.Quantity = order.Quantity;
            weChatVideoOrderInfoVo.BelongLiveAnchorId = input.BelongLiveAnchorId;
            return ResultData<WeChatVideoOrderInfoVo>.Success().AddData("orderInfo",weChatVideoOrderInfoVo);
        }
        /// <summary>
        /// 获取需要拉取订单的视频号主播
        /// </summary>
        /// <returns></returns>
        [HttpGet("wechatVideoOrderLiveAnchorId")]
        public async Task<ResultData<List<BaseIdAndNameVo<int>>>> GetWechatVideoOrderLiveAnchorIdAsync() {
            var nameList =await liveAnchorService.GetWechatVideoOrderLiveAnchorIdAsync();
            var result= nameList.Select(e => new BaseIdAndNameVo<int> { 
                Id=e.Id,
                Name=e.Name
            }).ToList();
            return ResultData<List<BaseIdAndNameVo<int>>>.Success().AddData("nameList",result);
        }

        /// <summary>
        /// 同步指定时间内的视频号订单
        /// </summary>
        /// <returns></returns>
        [HttpGet("syncWechatVideoOrder")]
        public async Task SyncVideoOrder(int liveAnchorId){
            

            var wechatVideoOrderResult = await _syncTikTokOrder.TranslateTradesSoldChangedOrders2(DateTime.Now, DateTime.Now, liveAnchorId);
            List<WechatVideoAddDto> wechatVideoList = new List<WechatVideoAddDto>();
            foreach (var item in wechatVideoOrderResult)
            {
                WechatVideoAddDto add = new WechatVideoAddDto();
                add.Id = item.Id;
                add.GoodsName = item.GoodsName;
                add.GoodsId = item.GoodsId;
                add.Phone = item.Phone;
                add.StatusCode = item.StatusCode;
                add.ActualPayment = item.ActualPayment;
                add.AccountReceivable = item.AccountReceivable;
                add.CreateDate = item.CreateDate.Value;
                add.UpdateDate = item.UpdateDate;
                add.ThumbPicUrl = item.ThumbPicUrl;
                add.BuyerNick = item.BuyerNick;
                add.OrderType = item.OrderType;
                add.Quantity = item.Quantity;
                add.BelongLiveAnchorId = item.BelongLiveAnchorId;
                wechatVideoList.Add(add);
            }
            await weChatVideoOrderService.AddAsync(wechatVideoList);
        }

        /// <summary>
        /// 自动填写视频号带货订单数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("autoCompleteData")]
        public async Task<ResultData<AutoCompleteDataVo>> AutoCompleteDataAsync([FromQuery]AutoCompleteDataParam param) {
            AutoCompleteDataVo result = new AutoCompleteDataVo();
            var data =await weChatVideoOrderService.AutoCompleteDataAsync(param.date,param.liveAnchorId,param.GoodsName,param.TakeGoodsType);
            result.Quantity = data.Quantity;
            result.TotalPrice = data.TotalPrice;
            return ResultData<AutoCompleteDataVo>.Success().AddData("data",result);
        }

    }
}
