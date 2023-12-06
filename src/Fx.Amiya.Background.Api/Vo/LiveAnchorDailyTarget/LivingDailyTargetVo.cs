using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LiveAnchorDailyTarget
{
    public class LivingDailyTargetVo:BaseVo
    {
        /// <summary>
        /// 主播月目标id
        /// </summary>
        public string LiveAnchorMonthlyTargetId { get; set; }

        /// <summary>
        /// 主播
        /// </summary>
        public string LiveAnchor { get; set; }
        /// <summary>
        /// 直播间人员id
        /// </summary>

        public int OperationEmpId { get; set; }
        /// <summary>
        /// 直播间人员
        /// </summary>

        public string OperationEmpName { get; set; }
        /// <summary>
        /// 直播间投流费用
        /// </summary>

        public decimal LivingRoomFlowInvestmentNum { get; set; }

        /// <summary>
        /// 抖+投流费用
        /// </summary>
        public decimal TikTokPlusNum { get; set; }
        /// <summary>
        /// 千川投流
        /// </summary>
        public decimal QianChuanNum { get; set; }
        /// <summary>
        /// 随心推
        /// </summary>
        public decimal ShuiXinTuiNum { get; set; }
        /// <summary>
        /// 微信豆
        /// </summary>
        public decimal WeiXinDou { get; set; }
        /// <summary>
        /// 照片面诊卡下单数量
        /// </summary>

        public int Consultation { get; set; }
        /// <summary>
        /// 视频面诊卡下单数量
        /// </summary>
        public int Consultation2 { get; set; }
        /// <summary>
        /// 带货结算佣金
        /// </summary>
        public decimal CargoSettlementCommission { get; set; }
        /// <summary>
        /// 填报时间
        /// </summary>

        public DateTime RecordDate { get; set; }
        /// <summary>
        /// 今日退卡量
        /// </summary>
        public decimal RefundCard { get; set; }
        /// <summary>
        /// 今日GMV
        /// </summary>
        public decimal GMV { get; set; }

        /// <summary>
        /// 今日去卡GMV
        /// </summary>
        public decimal EliminateCardGMV { get; set; }
        /// <summary>
        /// 今日退款GMV
        /// </summary>
        public decimal RefundGMV { get; set; }
    }
}
