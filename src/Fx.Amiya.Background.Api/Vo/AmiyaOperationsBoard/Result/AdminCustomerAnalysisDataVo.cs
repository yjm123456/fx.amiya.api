using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result
{
    public class AdminCustomerAnalysisDataVo
    {
        /// <summary>
        /// 直播渠道分诊数据
        /// </summary>
        public List<ItemVo> DistributeConsulationDataList { get; set; }
        /// <summary>
        /// 直播渠道加v数据
        /// </summary>
        public List<ItemVo> DistributeConsulationAddWechatDataList { get; set; }
        /// <summary>
        /// 有效潜在分诊数据
        /// </summary>
        public List<ItemVo> EffAndPotDataList { get; set; }
        /// <summary>
        /// 有效潜在加v数据
        /// </summary>
        public List<ItemVo> EffAndPotAddWechatDataList { get; set; }
    }
    public class ItemVo
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public int Value { get; set; }
        /// <summary>
        /// 比例
        /// </summary>
        public decimal Rate { get; set; }

    }
}
