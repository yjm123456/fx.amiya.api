using Fx.Amiya.Core.Dto.Goods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Order
{
    public class OrderAddVo
    {

        /// <summary>
        /// 收货地址编号（用于实物商品发货）
        /// </summary>
        public int? AddressId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 支付方式 1:支付宝支付，2:微信支付 3:余额支付,
        /// </summary>
        public int ExchangeType { get; set; }
        /// <summary>
        /// 是否是主播美肤卡
        /// </summary>
        public bool IsCard { get; set; }
        
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 美肤卡手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 抵用券id
        /// </summary>
        public string VoucherId { get; set; }
        /// <summary>
        /// 美肤卡图片
        /// </summary>
        public string ThumbPicUrl { get; set; }
        /// <summary>
        /// 美肤卡名称
        /// </summary>
        public string CardName { get; set; }
        
        public List<OrderItemVo> OrderItemList { get; set; }


    }
}
