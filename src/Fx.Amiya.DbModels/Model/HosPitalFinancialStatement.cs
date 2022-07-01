using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class HosPitalFinancialStatement
    {
        /// <summary>
        /// 对账单编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 生成年份
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// 生成月份
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// 订单来源平台（1：下单平台；2：内容平台；3：升单)
        /// </summary>
        public int PlatForm { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public int OrderStatus { get; set; }

        /// <summary>
        /// 客户昵称
        /// </summary>
        public int BuyerNick { get; set; }

        /// <summary>
        /// 客户手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 订单创建时间
        /// </summary>
        public DateTime? OrderCreateTime { get; set; }

        /// <summary>
        /// 订单成交时间
        /// </summary>
        public DateTime? WriteOffTime { get; set; }

        /// <summary>
        /// 商品/项目
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 实付款
        /// </summary>
        public decimal? ActualPayment { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 派单价格
        /// </summary>
        public decimal? SendOrderPrice { get; set; }

        /// <summary>
        /// 结算佣金
        /// </summary>
        public decimal? SettleCommission { get; set; }

        /// <summary>
        /// 对账状态（0：对平，1：长款，2：短款，）
        /// </summary>
        public int SettleState { get; set; }

        /// <summary>
        /// 医院提报价格
        /// </summary>
        public decimal? HospitalSubmitPrice { get; set; }

        /// <summary>
        /// 医院提报佣金
        /// </summary>
        public decimal? HospitalSubmitSettleCommission { get; set; }
        
        /// <summary>
        /// 医院标记状态 （0：正常，1：标记新增，2：标记删除；3：标记差异）
        /// </summary>
        public int FlagState { get; set; }
    }
}
