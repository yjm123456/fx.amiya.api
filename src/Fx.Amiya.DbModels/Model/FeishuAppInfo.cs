using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class FeishuAppInfo:BaseDbModel
    {
        /// <summary>
        /// 作为应用的唯一标识
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 应用id
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 应用密钥
        /// </summary>
        public string AppSecret { get; set; }
        /// <summary>
        /// 多维表格app_token
        /// </summary>
        public string AppToken { get; set; }
        /// <summary>
        /// 多维表格tableId
        /// </summary>
        public string TableId { get; set; }
        /// <summary>
        /// token
        /// </summary>
        public string AccessToken { get; set; }
        /// <summary>
        /// token过期时间
        /// </summary>
        public DateTime? ExpireDate { get; set; }
        /// <summary>
        /// 归属主播
        /// </summary>
        public int BelongLiveAnchorId { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
