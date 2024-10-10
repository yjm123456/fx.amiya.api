using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result
{
    public class AdminCustomerFilterDataVo
    {
        /// <summary>
        /// 组数据
        /// </summary>
        public AdminCustomerFilterDataItemVo GroupData { get; set; }
        /// <summary>
        /// 加v后数据
        /// </summary>

        public AdminCustomerFilterDataItemVo AddwechatData { get; set; }
    }
    public class AdminCustomerFilterDataItemVo
    {
        /// <summary>
        /// 加v率
        /// </summary>
        public decimal? AddWeChatRate { get; set; }
        /// <summary>
        /// 加v率健康值
        /// </summary>
        public decimal AddWeChatRateHealthValueThisMonth { get; set; }
        /// <summary>
        /// 派单率
        /// </summary>
        public decimal? SendOrderRate { get; set; }
        /// <summary>
        /// 派单率健康值
        /// </summary>
        public decimal SendOrderRateHealthValueThisMonth { get; set; }
        /// <summary>
        /// 上门率
        /// </summary>
        public decimal? ToHospitalRate { get; set; }
        /// <summary>
        /// 上门率健康值
        /// </summary>
        public decimal ToHospitalRateHealthValueThisMonth { get; set; }
        /// <summary>
        /// 派单周期
        /// </summary>
        public int SendCycle { get; set; }
        /// <summary>
        /// 上门周期
        /// </summary>
        public int HospitalCycle { get; set; }
        /// <summary>
        /// 漏斗图数据
        /// </summary>
        public List<AdminCustomerFilterDetailDataVo> DataList { get; set; }

    }
    /// <summary>
    /// 业绩输出详情
    /// </summary>
    public class AdminCustomerFilterDetailDataVo
    {
        /// <summary>
        /// 标识码
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public decimal Value { get; set; }
    }
}
