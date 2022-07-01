using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport
{
    /// <summary>
    /// 数据中心
    /// </summary>
    public class OrderCenterDetailsVo
    {
        /// <summary>
        /// 派单数
        /// </summary>
        public SendListInfo SendOrderInfo { get; set; }

        /// <summary>
        /// 业绩
        /// </summary>
        public Achievement Achievement { get; set; }

        /// <summary>
        /// 上门数
        /// </summary>
        public OrderVisitInfo OrderVisitInfo { get; set; }

        /// <summary>
        /// 面诊卡
        /// </summary>
        public ConsultationCardInfo ConsultationCardInfo { get; set; }

        /// <summary>
        /// 医院订单量
        /// </summary>
        public List<HospitalOrderAndPriceInfoVo> HospitalOrderAndPriceInfoVo { get; set; }

    }



    /// <summary>
    /// 派单数
    /// </summary>
    public class SendListInfo
    {

        /// <summary>
        /// 累计已派单
        /// </summary>
        public int AllSendOrder { get; set; }

        /// <summary>
        /// 累计未派单
        /// </summary>
        public int AllUnSendOrder { get; set; }
        /// <summary>
        /// 已派单数量
        /// </summary>
        public List<OrderOperationConditionVo> sendOrderDataListCount { get; set; }

        /// <summary>
        /// 未派单数量
        /// </summary>
        public List<OrderOperationConditionVo> UnSendOrderDataListCount { get; set; }
    }

    /// <summary>
    /// 业绩
    /// </summary>
    public class Achievement
    {

        /// <summary>
        /// 累计新客业绩
        /// </summary>
        public decimal AllNewCustomerAchievement { get; set; }
        /// <summary>
        /// 累计老客业绩
        /// </summary>
        public decimal AllOldCustomerAchievement { get; set; }

        /// <summary>
        /// 总业绩
        /// </summary>
        public decimal AllAchievement { get; set; }
        /// <summary>
        /// 新客业绩
        /// </summary>
        public List<OrderPriceConditionVo> NewCustomerAchievement { get; set; }

        /// <summary>
        /// 老客业绩
        /// </summary>
        public List<OrderPriceConditionVo> OldCustomerAchievement { get; set; }
    }

    /// <summary>
    /// 上门数
    /// </summary>
    public class OrderVisitInfo
    {

        /// <summary>
        /// 累计新诊上门
        /// </summary>
        public int AllNewCustomerVisit { get; set; }

        /// <summary>
        /// 累计复诊上门
        /// </summary>
        public int AllOldCustomerVisit { get; set; }
        /// <summary>
        /// 新诊上门
        /// </summary>
        public List<OrderOperationConditionVo> NewCustomerVisit { get; set; }

        /// <summary>
        /// 复诊上门
        /// </summary>
        public List<OrderOperationConditionVo> OldCustomerVisit { get; set; }
    }


    /// <summary>
    /// 面诊卡
    /// </summary>
    public class ConsultationCardInfo
    {

        /// <summary>
        /// 累计面诊卡下单量
        /// </summary>
        public int AllConsultationCardInfoBuy { get; set; }

        /// <summary>
        /// 累计面诊卡消耗量
        /// </summary>
        public int AllConsultationCardInfoUsed { get; set; }
        /// <summary>
        /// 面诊卡下单量
        /// </summary>
        public List<OrderOperationConditionVo> ConsultationCardInfoBuy { get; set; }

        /// <summary>
        /// 面诊卡消耗量
        /// </summary>
        public List<OrderOperationConditionVo> ConsultationCardInfoUsed { get; set; }
    }



    /// <summary>
    /// 成交数
    /// </summary>
    public class OrderDealInfo
    {

        /// <summary>
        /// 累计新诊成交
        /// </summary>
        public int AllNewCustomerDeal { get; set; }

        /// <summary>
        /// 累计复诊成交
        /// </summary>
        public int AllOldCustomerDeal { get; set; }
        /// <summary>
        /// 新诊成交
        /// </summary>
        public List<OrderOperationConditionVo> NewCustomerDeal { get; set; }

        /// <summary>
        /// 复诊成交
        /// </summary>
        public List<OrderOperationConditionVo> OldCustomerDeal { get; set; }
    }



    /// <summary>
    /// 对账业绩
    /// </summary>
    public class CheckForPerformance
    {

        /// <summary>
        /// 累计对账金额
        /// </summary>
        public decimal AllCheckForPerformance { get; set; }
        /// <summary>
        /// 累计回款金额
        /// </summary>
        public decimal AllReceivablePerformance { get; set; }
        /// <summary>
        /// 新客业绩
        /// </summary>
        public List<OrderPriceConditionVo> CheckForPerformanceList { get; set; }

        /// <summary>
        /// 老客业绩
        /// </summary>
        public List<OrderPriceConditionVo> ReceivablePerformance { get; set; }
    }

    public class LiveAnchorPerformance
    {
        /// <summary>
        /// 人 
        /// </summary>
        public string LiveAnchorName { get; set; }
        /// <summary>
        /// 派单量
        /// </summary>
        public int OrderNum { get; set; }
        /// <summary>
        /// 业绩
        /// </summary>
        public decimal Performance { get; set; }
    }
}
