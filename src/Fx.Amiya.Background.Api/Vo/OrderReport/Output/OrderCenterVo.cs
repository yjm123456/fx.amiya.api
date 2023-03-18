using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport.OutPut
{
    /// <summary>
    /// 订单数据可视化看板基础类
    /// </summary>
    public class OrderCenterVo
    {
        /// <summary>
        /// 今日核销订单量
        /// </summary>
        public int TodayWriteOffOrderQuantity { get; set; }

        /// <summary>
        /// 今日订单关闭量
        /// </summary>
        public int TodayClosedOrderQuantity { get; set; }

        /// <summary>
        /// 今日总订单
        /// </summary>
        public int TodayOrderQuantity { get; set; }

        /// <summary>
        /// 今日各医院接单情况
        /// </summary>
        public List<TodayHospitalOrderNum> TodayHospitalOrderNum { get; set; }

        /// <summary>
        /// 今日录单情况
        /// </summary>
        public List<TodayAddOrderNum> TodayAddOrderNum { get; set; }

        /// <summary>
        /// 今日派单情况
        /// </summary>
        public List<TodaySendOrderInfo> TodaySendOrderInfo { get; set; }
    }

    /// <summary>
    /// 今日医院订单量
    /// </summary>
    public class TodayHospitalOrderNum
    {
        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }
        /// <summary>
        /// 订单量
        /// </summary>
        public int OrderCount { get; set; }
    }
    /// <summary>
    /// 今日录单情况
    /// </summary>
    public class TodayAddOrderNum
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 客户
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 项目
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// 订单类型
        /// </summary>
        public string OrderType { get; set; }
    }

    /// <summary>
    /// 今日派单情况
    /// </summary>
    public class TodaySendOrderInfo
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 商品
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 实付款
        /// </summary>
        public decimal? ActuralPayment { get; set; }
        /// <summary>
        /// 派单医院
        /// </summary>
        public string SendHospital { get; set; }
    }
}
