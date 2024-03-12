using Fx.Amiya.Background.Api.Vo.OfficialWebsite.Input;
using Fx.Amiya.Background.Api.Vo.OfficialWebsite.Result;
using Fx.Amiya.Dto.OfficialWebsite.Input;
using Fx.Amiya.IService;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 官网商城相关接口
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OfficialWebsiteController : ControllerBase
    {
        private readonly IOfficialWebsiteService officialWebsiteService;

        public OfficialWebsiteController(IOfficialWebsiteService officialWebsiteService)
        {
            this.officialWebsiteService = officialWebsiteService;
        }

        /// <summary>
        /// 获取设计卡下单签名
        /// </summary>
        /// <param name="getSign"></param>
        /// <returns></returns>
        [HttpPost("getSign")]
        public async Task<ResultData<OrderSignVo>> GetSignAsync(GetDesignOrderSignVo getSign)
        {
            OrderSignVo sign = new OrderSignVo();
            GetDesignOrderSignDto getDto = new GetDesignOrderSignDto();
            getDto.NickName = getSign.NickName;
            getDto.Phone = getSign.Phone;
            getDto.Gender = getSign.Gender;
            getDto.BirthDay = getSign.BirthDay;
            getDto.Profession = getSign.Profession;
            getDto.WechatRemark = getSign.WechatRemark;
            getDto.City = getSign.City;
            var res = await officialWebsiteService.GetSignAsync(getDto);
            sign.Sign = res.Sign;
            return ResultData<OrderSignVo>.Success().AddData("sign", sign);
        }
        /// <summary>
        /// 设计卡下单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost("designOrder")]
        public async Task<ResultData> DesignOrderAsync(DesignOrderVo order)
        {
            DesignOrderDto orderDto = new DesignOrderDto();
            orderDto.NickName = order.NickName;
            orderDto.Phone = order.Phone;
            orderDto.Gender = order.Gender;
            orderDto.BirthDay = order.BirthDay;
            orderDto.Profession = order.Profession;
            orderDto.WechatRemark = order.WechatRemark;
            orderDto.City = order.City;
            orderDto.Sign = order.Sign;
            var res = await officialWebsiteService.AddDesignOrderAsync(orderDto);
            OrderPayInfoVo orderPayInfoVo = new OrderPayInfoVo();
            orderPayInfoVo.PayUrl = res.PayUrl;
            return ResultData<OrderPayInfoVo>.Success().AddData("pay", orderPayInfoVo);
            
        }
        /// <summary>
        /// 获取商品下单签名
        /// </summary>
        /// <param name="getSign"></param>
        /// <returns></returns>
        [HttpPost("getGoodsOrderSign")]
        public async Task<ResultData<OrderSignVo>> GetGoodsOrderSignAsync(GetGoodsOrderSignVo getSign)
        {
            OrderSignVo sign = new OrderSignVo();
            GetGoodsOrderSignDto getDto = new GetGoodsOrderSignDto();
            getDto.GoodsId = getSign.GoodsId;
            getDto.Phone = getSign.Phone;
            getDto.Quantity = getSign.Quantity;
            getDto.HospitalName = getSign.HospitalName;
            getDto.StandardId = getSign.StandardId;
            getDto.Remark = getSign.Remark;
            getDto.AppointmentDate = getSign.AppointmentDate;
            var res = await officialWebsiteService.GetGoodsOrderSignAsync(getDto);
            sign.Sign = res.Sign;
            return ResultData<OrderSignVo>.Success().AddData("sign", sign);
        }
        /// <summary>
        /// 商品下单
        /// </summary>
        /// <param name="goodsOrder"></param>
        /// <returns></returns>
        [HttpPost("goodsOrder")]
        public async Task<ResultData> GoodsOrderAsync(GoodsOrderVo goodsOrder)
        {
            GoodsOrderDto orderDto = new GoodsOrderDto();
            orderDto.GoodsId = goodsOrder.GoodsId;
            orderDto.Quantity = goodsOrder.Quantity;
            orderDto.HospitalName = goodsOrder.HospitalName;
            orderDto.StandardId = goodsOrder.StandardId;
            orderDto.Remark = goodsOrder.Remark;
            orderDto.AppointmentDate = goodsOrder.AppointmentDate;
            orderDto.Phone = goodsOrder.Phone;
            orderDto.Sign = goodsOrder.Sign;
            var res = await officialWebsiteService.AddGoodsOrderAsync(orderDto);
            OrderPayInfoVo orderPayInfoVo = new OrderPayInfoVo();
            orderPayInfoVo.PayUrl = res.PayUrl;
            return ResultData<OrderPayInfoVo>.Success();
        }
    }
}
