using Fx.Amiya.Background.Api.Filters;
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
        private readonly IValidateCodeService validateCodeService;
        private readonly IOffcialWebUserSessionStorage offcialWebUserSessionStorage;
        public OfficialWebsiteController(IOfficialWebsiteService officialWebsiteService, IValidateCodeService validateCodeService, IOffcialWebUserSessionStorage offcialWebUserSessionStorage)
        {
            this.officialWebsiteService = officialWebsiteService;
            this.validateCodeService = validateCodeService;
            this.offcialWebUserSessionStorage = offcialWebUserSessionStorage;
        }

        /// <summary>
        /// 获取设计卡下单签名
        /// </summary>
        /// <param name="getSign"></param>
        /// <returns></returns>
        [HttpPost("getSign")]
        [ServiceFilter(typeof(ValidateLoginAttribute))]
        public async Task<ResultData<OrderSignVo>> GetSignAsync(GetDesignOrderSignVo getSign)
        {
            string token = HttpContext.Request.Headers["Token"];
            var session = offcialWebUserSessionStorage.GetSession(token);
            var phone = session?.Phone;
            if (string.IsNullOrEmpty(phone)) throw new Exception("登录过期,请重新登录");
            OrderSignVo sign = new OrderSignVo();
            GetDesignOrderSignDto getDto = new GetDesignOrderSignDto();
            getDto.NickName = getSign.NickName;
            getDto.Phone = phone;
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
        [ServiceFilter(typeof(ValidateLoginAttribute))]
        public async Task<ResultData> DesignOrderAsync(DesignOrderVo order)
        {
            string token = HttpContext.Request.Headers["Token"];
            var session = offcialWebUserSessionStorage.GetSession(token);
            var phone = session?.Phone;
            if (string.IsNullOrEmpty(phone)) throw new Exception("登录过期,请重新登录");
            DesignOrderDto orderDto = new DesignOrderDto();
            orderDto.NickName = order.NickName;
            orderDto.Phone = phone;
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
        [ServiceFilter(typeof(ValidateLoginAttribute))]
        public async Task<ResultData<OrderSignVo>> GetGoodsOrderSignAsync(GetGoodsOrderSignVo getSign)
        {
            string token = HttpContext.Request.Headers["Token"];
            var session = offcialWebUserSessionStorage.GetSession(token);
            var phone = session?.Phone;
            if (string.IsNullOrEmpty(phone)) throw new Exception("登录过期,请重新登录");
            OrderSignVo sign = new OrderSignVo();
            GetGoodsOrderSignDto getDto = new GetGoodsOrderSignDto();
            getDto.GoodsId = getSign.GoodsId;
            getDto.Phone = phone;
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
        [ServiceFilter(typeof(ValidateLoginAttribute))]
        public async Task<ResultData> GoodsOrderAsync(GoodsOrderVo goodsOrder)
        {
            string token = HttpContext.Request.Headers["Token"];
            var session=offcialWebUserSessionStorage.GetSession(token);
            var phone = session?.Phone;
            if (string.IsNullOrEmpty(phone)) throw new Exception("登录过期,请重新登录");
            GoodsOrderDto orderDto = new GoodsOrderDto();
            orderDto.GoodsId = goodsOrder.GoodsId;
            orderDto.Quantity = goodsOrder.Quantity;
            orderDto.HospitalName = goodsOrder.HospitalName;
            orderDto.StandardId = goodsOrder.StandardId;
            orderDto.Remark = goodsOrder.Remark;
            orderDto.AppointmentDate = goodsOrder.AppointmentDate;
            orderDto.Phone = phone;
            orderDto.Sign = goodsOrder.Sign;
            var res = await officialWebsiteService.AddGoodsOrderAsync(orderDto);
            OrderPayInfoVo orderPayInfoVo = new OrderPayInfoVo();
            orderPayInfoVo.PayUrl = res.PayUrl;
            return ResultData<OrderPayInfoVo>.Success();
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<ResultData<string>> LoginAsync(LoginVo login)
        {
            var validateRes = await validateCodeService.ValidateAsync(login.Phone, login.Code);
            if (!validateRes)
            {
                throw new Exception("验证码错误");
            }
            var token = Guid.NewGuid().ToString().Replace("-", "");
            offcialWebUserSessionStorage.SetSession(token,new OffcialWebUserSession{
                Phone= login.Phone, 
                ExpireTime=DateTime.Now.AddDays(1)
            });
            return ResultData<string>.Success().AddData(token);
        }
    }
}
