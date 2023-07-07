using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class WechatPayInfo : BaseDbModel
    {

        public string AppId { get; set; }
        public string AppSecret { get; set; }
        /// <summary>
        /// 微信支付商户号
        /// </summary>
        public string PartnerId { get; set; }
        /// <summary>
        /// 微信支付密钥
        /// </summary>
        public string PartnerKey { get; set; }
        public bool EnableSP { get; set; }
        public string SubAppId { get; set; }
        public string SubMchId { get; set; }
        /// <summary>
        /// 私钥
        /// </summary>
        public string PrivateKey { get; set; }
        /// <summary>
        /// 公钥
        /// </summary>
        public string PublickKey { get; set; }
        /// <summary>
        /// 证书名称
        /// </summary>
        public string CertificateName { get; set; }
        /// <summary>
        /// 门店id用于杉德支付
        /// </summary>
        public string StoreId { get; set; }
        public string Remark { get; set; }
    }
}
