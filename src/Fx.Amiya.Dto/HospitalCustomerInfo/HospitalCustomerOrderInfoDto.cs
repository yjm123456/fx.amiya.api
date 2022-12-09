using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HospitalCustomerInfo
{
    /// <summary>
    /// 三方医院返回客户订单信息
    /// </summary>
    public class HospitalCustomerOrderInfoDto
    {
        /// <summary>
        /// 客户编号
        /// </summary>
        public string customerID { get; set; }

        /// <summary>
        /// 消费日期
        /// </summary>
        public DateTime? date { get; set; }

        /// <summary>
        /// 会员卡号
        /// </summary>
        public string memberCardNum { get; set; }

        /// <summary>
        /// 客户姓名
        /// </summary>
        public string customerName { get; set; }

        /// <summary>
        /// 现场咨询
        /// </summary>
        public string sceneName { get; set; }

        /// <summary>
        /// 渠道分类
        /// </summary>
        public string channelCategory { get; set; }

        /// <summary>
        /// 来源渠道
        /// </summary>
        public string channelName { get; set; }

        /// <summary>
        /// 单据类型
        /// </summary>
        public string docType { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string itemName { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string itemStandard { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public string quantity { get; set; }

        /// <summary>
        /// 总金额
        /// </summary>
        public decimal? amount { get; set; }

        /// <summary>
        /// 货币金额
        /// </summary>
        public decimal? cashAmount { get; set; }

        /// <summary>
        /// 预交冲款
        /// </summary>
        public decimal? prepaymentAmount { get; set; }

        /// <summary>
        /// 金额卡（真实金额）
        /// </summary>
        public decimal? cashOfMoneyCardAmount { get; set; }

        /// <summary>
        /// 年卡冲款
        /// </summary>
        public decimal? yearCardAmount { get; set; }

        /// <summary>
        /// 金额卡（虚拟金额）
        /// </summary>
        public decimal? handselOfMoneyCardAmount { get; set; }

        /// <summary>
        /// 积分冲款
        /// </summary>
        public decimal? integrationAmount { get; set; }

        /// <summary>
        /// 代金券消费
        /// </summary>
        public decimal? insteadMoneyAmount { get; set; }

        /// <summary>
        /// 欠款
        /// </summary>
        public decimal? arrearsAmount { get; set; }

    }
}
