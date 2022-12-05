using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HuiShouQianPay
{
    public class HuiShouQianPackageInfo
    {
        /// <summary>
        /// 商户私钥路径
        /// </summary>
        public string  PrivateKeyPath { get;private set; }
        /// <summary>
        /// 商户私钥密码
        /// </summary>
        public string  PrivateKeyPassword { get; set; }
        /// <summary>
        /// 慧收钱公钥路径
        /// </summary>
        public string PubilcKeyPath { get;private set; }
        public string Key { get;private set; }
        /// <summary>
        /// 下单Url
        /// </summary>
        public string OrderUrl { get;private set; }
        /// <summary>
        /// 退款Url
        /// </summary>
        public string RefundUrl { get; set; }
        public HuiShouQianPackageInfo() {
            this.PrivateKeyPath = AppDomain.CurrentDomain.BaseDirectory + "hsqzsamy4571_pri.pfx";
            this.PrivateKeyPassword = "amyhsq1005";
            this.PubilcKeyPath = AppDomain.CurrentDomain.BaseDirectory + "MANDAO_864001883569_pub.cer";
            this.Key = "e760852ffef2a52b5d2421d14bb5867d";
            //测试url
            //this.OrderUrl = "https://test-api.huishouqian.com/api/acquiring";
            //正式url
            this.OrderUrl = "https://api.huishouqian.com/api/acquiring";

            //测试
            //this.RefundUrl = "https://test-api.huishouqian.com/api/acquiring";
            //正式
            this.RefundUrl = "https://api.huishouqian.com/api/acquiring";
        }

    }
}
