using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.SyncOrder.WeChatVideo
{
    public class WeChatVideoOrderIdListResult
    {
        /// <summary>
        /// 错误码
        /// </summary>
        public int errcode { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string errmsg { get; set; }
        /// <summary>
        /// 订单号列表
        /// </summary>
        public List<string> order_id_list { get; set; }
        /// <summary>
        /// 分页参数,下一页请求回传
        /// </summary>
        public string next_key { get; set; }
        /// <summary>
        /// 是否还有下一页,true:有下一页;false:已经结束,没有下一页
        /// </summary>
        public bool has_more { get; set; }
    }
}
