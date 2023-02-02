using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.UnCheckOrder
{
    /// <summary>
    /// 添加未上传对账单订单
    /// </summary>
    public class AddUnCheckOrderVo
    {
        /// <summary>
        /// 订单基础信息集合
        /// </summary>
        public List<AddBaseOrderInfoVo> AddBaseOrderInfoVoList { get; set; }
        /// <summary>
        /// 订单来源
        /// </summary>
        public int OrderFrom { get; set; }
        /// <summary>
        /// 信息服务费比例
        /// </summary>
        public decimal InformationPricePercent { get; set; }
        /// <summary>
        /// 系统使用费比例
        /// </summary>
        public decimal SystemUpdatePercent { get; set; }
    }
    /// <summary>
    /// 订单基础信息添加
    /// </summary>
    public class AddBaseOrderInfoVo
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 成交时间
        /// </summary>
        public DateTime DealDate { get; set; }
        /// <summary>
        /// 成交金额
        /// </summary>
        public decimal DealPrice { get; set; }
    }
}
