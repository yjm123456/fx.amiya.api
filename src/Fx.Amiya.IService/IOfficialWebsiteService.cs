using Fx.Amiya.Dto.OfficialWebsite.Input;
using Fx.Amiya.Dto.OfficialWebsite.Result;
using Fx.Amiya.Dto.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IOfficialWebsiteService
    {
        /// <summary>
        /// 获取签名
        /// </summary>
        /// <param name="getSignVo"></param>
        /// <returns></returns>
        Task<OrderSignDto> GetSignAsync(GetDesignOrderSignDto getSignVo);
        /// <summary>
        /// 设计卡下单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<OrderPayInfoDto> AddDesignOrderAsync(DesignOrderDto order);
        /// <summary>
        /// 获取商品下单签名
        /// </summary>
        /// <param name="getSignVo"></param>
        /// <returns></returns>
        Task<OrderSignDto> GetGoodsOrderSignAsync(GetGoodsOrderSignDto getSignVo);
        /// <summary>
        /// 商品下单
        /// </summary>
        /// <param name="addOrder"></param>
        /// <returns></returns>
        Task<OrderPayInfoDto> AddGoodsOrderAsync(GoodsOrderDto order);
    }
}
