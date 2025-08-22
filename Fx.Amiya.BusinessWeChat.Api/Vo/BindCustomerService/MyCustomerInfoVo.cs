using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWeChat.Api.Vo.BindCustomerService
{
    /// <summary>
    /// "我的客户"基础类
    /// </summary>
    public class MyCustomerInfoVo
    {

        /// <summary>
        /// 总客户
        /// </summary>
        public int MyCustomerCount { get; set; }

        /// <summary>
        /// 新客人数
        /// </summary>
        public int NewCustomerCount { get; set; }
        /// <summary>
        /// 老客人数
        /// </summary>
        public int OldCustomerCount { get; set; }

        /// <summary>
        /// 近期新增（七日内）
        /// </summary>
        public int SevenDaysInsertCount { get; set; }
        /// <summary>
        /// 今日新增
        /// </summary>
        public int TodayInsertCount { get; set; }
    }
}
