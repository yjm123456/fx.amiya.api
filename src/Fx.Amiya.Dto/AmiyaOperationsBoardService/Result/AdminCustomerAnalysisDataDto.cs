using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService.Result
{
    public class AdminCustomerAnalysisDataDto
    {
        /// <summary>
        /// 直播渠道分诊数据
        /// </summary>
        public List<Item> DistributeConsulationDataList { get; set; }
        /// <summary>
        /// 直播渠道加v数据
        /// </summary>
        public List<Item> DistributeConsulationAddWechatDataList { get; set; }
        /// <summary>
        /// 有效潜在分诊数据
        /// </summary>
        public List<Item> EffAndPotDataList { get; set; }
        /// <summary>
        /// 有效潜在加v数据
        /// </summary>
        public List<Item> EffAndPotAddWechatDataList { get; set; }
    }
    public class Item
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
