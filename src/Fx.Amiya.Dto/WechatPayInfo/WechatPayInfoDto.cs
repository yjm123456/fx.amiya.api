using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.WechatPayInfo
{
    public class WechatPayInfoDto
    {
        public string Id { get; set; }
        public string AppId { get; set; }
        public string AppSecret { get; set; }
        /// <summary>
        /// 微信支付商户号
        /// </summary>
        public int PartnerId { get; set; }
        /// <summary>
        /// 微信支付密钥
        /// </summary>
        public string PartnerKey { get; set; }
        public bool EnableSP { get; set; }
        public string SubAppId { get; set; }
        public string SubMchId { get; set; }
        
    }
}
