using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService.Result
{
    public class AdminCustomerAssistantDisAndAddVDataDto
    {
        /// <summary>
        /// 助理分诊数据
        /// </summary>
        public List<DataItemDto> AssistantDistributeData { get; set; }
        /// <summary>
        /// 助理分诊数据详情
        /// </summary>
        public List<DataDetailItemDto> AssistantDistributeDataDetail { get; set; }
        /// <summary>
        /// 助理加V数据
        /// </summary>
        public List<DataItemDto> AssistantAddWechatData { get; set; }
        /// <summary>
        /// 助理加V数据详情
        /// </summary>
        public List<DataDetailItemDto> AssistantAddWechatDataDetail { get; set; }
    }
    public class DataItemDto
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public decimal Value { get; set; }
        
    }
    public class DataDetailItemDto
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 直播前
        /// </summary>
        public decimal BeforeLiveValue { get; set; }
        /// <summary>
        /// 直播中
        /// </summary>
        public decimal LivingValue { get; set; }
        /// <summary>
        /// 直播后
        /// </summary>
        public decimal AfterLiveValue { get; set; }
    }
}
