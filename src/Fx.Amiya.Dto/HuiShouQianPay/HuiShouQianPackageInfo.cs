using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HuiShouQianPay
{
    public class HuiShouQianPackageInfo
    {
        public string PrivateKey { get; set; }
        public string PublicKey { get; set; }
        /// <summary>
        /// 商户私钥路径
        /// </summary>
        public string PrivateKeyPath { get; private set; }
        /// <summary>
        /// 商户私钥密码
        /// </summary>
        public string PrivateKeyPassword { get; set; }
        /// <summary>
        /// 慧收钱公钥路径
        /// </summary>
        public string PubilcKeyPath { get; private set; }
        public string Key { get; private set; }
        /// <summary>
        /// 下单Url
        /// </summary>
        public string OrderUrl { get; private set; }
        /// <summary>
        /// 退款Url
        /// </summary>
        public string RefundUrl { get; set; }
        public HuiShouQianPackageInfo()
        {
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
            this.PrivateKey = @"MIIEowIBAAKCAQEAzSBasvvzJEYixOnWy9nwp7IvbFkfLXu016d+VmDz5FpntUN+
LLVeF67q/Jq7DTT1shvxFhmlCXQLJP5QUwYYKUyW1QcP2xPLawEXcy4mzb3NvNKB
9dnGDM57eaWWvgRdRarMsnHqxcPH85tfQ59hlogq4a2sKQ/QLGrs+EpJpcFuKuN3
cJeB2PnQWx+uqxxsWE4bf60BqyvpMfCFKIVcbQ0ZZou+cVx3/qphZWqsGHRRv/8K
h0LAmXZZ+kJsUJZJcQwRXYdiusQq8mQEwCSEMRaklXLG5EdtoYMscEfHFChbUhSQ
gNHSKnLxE2nfs2Uep8bLHOYgnr/mRAc1eFG0DwIDAQABAoIBADgWoLZQLiu9AcTW
K+WRsjwofM8jj2LgcJKHOgRkfkvybGkkC1wuO4w+SALKTFtQH96TxVhFqtrq4CE9
aLlK8VBZoOSfCbbdssGPitnzxKh9PcRjyyVuZrkZvKmGnbFXgCmMimxAufFZl1MF
KQdUjVqb4R3UXz7bFBERK7q4lWq8/AahyyE9D4lzITVtfO/6IkObvh4oNMBpyMRh
kOYCihkwt8h208OK5Pug84Xz0ltx7cc0xIan8He/Ar7JylDQfYmerF1ggAhXw0vP
m5xH9uwuh2t1hVnLGCi5PTuCIkDdukgWmKqpaaxprbAvUz+3ygsJVsrbeK3eD6TI
5OmvYAECgYEA6wnekGWXpywmLIF3B8utsiG0xQXkCmyBv/U0WHrkAGyW2+Pgfpz7
pQeUfWeUV/IWSXyIOWs9AZvpw9+Wb+NF4GIw2N2oCNoxjCWt5dR9JjeXaXdDWhFk
YKTgYEs1GaZVTHui0WgvR7D25vbJrLeF2MOtbC8TJe3J4uVDL0GlG9kCgYEA32uQ
iNQGeMDnJRly5127RE18DlWUlNX/+QjuJ/+jajv26X5Yj3Pws8lJVM6lhjetcYEk
XQ+AYxv05MOito+sjFeYnvS3nd19bOuG7dYd8ywpdxbqKAiYR6zYMrSf93F7Wxjy
MV0tOMqUWjMRhYMHXLUxksE4ahnHa47fUHZiZicCgYEAoFA6A2mX+AmP/BlOM/4D
+pUs9JnhAg8irOi2DIe9zmBCwbb7n8C5j8XMzYCB2T6hXvxW+jsgAGH1H4n41VZC
ihrPUIxXmbohw4LLyxCVUCTo3KHhSaTFP3oWJPgHPviKA8Hsu0KBxTd6IO1Bf9Ip
tEE7n6e4Os2nP2C645e143kCgYAKVvcMbguSoRLRc7kOnhbhlVhtbWZ/8Nt00gX7
keglLXtC2RcOJIZ6O5GKPDoK2R7MxvZA3EvLympt/+PS4RlSMWedy6OHyc1ZMhk/
fo5KR7vvh/70NVmez4/94MAaeoUD9UaYJEDIhQ+SkRR5glPf5X7S1OBggKrq/mS1
W5U4NwKBgB2afUypRtyOGI+qKE6v8rzUKZ7aqwaUCT4IOm5bFZGqq2uPP0NLgdkH
QHUPZ/ri0TSGZLNoJryhz71TO2ox8JtO2+BVBuxrJ83IRlsZUbnicZtJkshRuW90
FzhYELCmng0bfbfA6mKxtV3V+d9EmdFB+D/mUpGd/imqgNCDzCu3";
            this.PublicKey = @"MIIDCTCCAfGgAwIBAgIGAYStbkUyMA0GCSqGSIb3DQEBDQUAMCExEjAQBgNVBAoMCUNGQ0EgT0NB
MTELMAkGA1UEBhMCQ04wIBcNMjIxMTI1MDYxNjM1WhgPMjA1MDA0MTIwNjE2MzVaMGgxETAPBgNV
BAMMCGtjYmViYW5rMRcwFQYDVQQLDA5rY2JlYmFuay1ydXlhbjEZMBcGA1UECwwQT3JnYW5pemF0
aW9uYWwtMTESMBAGA1UECgwJQ0ZDQSBPQ0ExMQswCQYDVQQGEwJDTjCCASIwDQYJKoZIhvcNAQEB
BQADggEPADCCAQoCggEBALIemXwHL5cIcOjZvrWcJALIs37nRIYZRihZu8SdAPkTMO6nDlBZO9OB
Qe3j9aJOiopeYwRy/zN9JgP2VdnMN8T7Sl33LqOQ9KG+9U/QNR+rteA6VKiVwMwbSLt+OkqYMCRI
VXY4+Kkd7nAPJXaAWVtnmfBRpNW/d1hQHaakaq9rPFexFjzyU7W0TLcknUhUPxxYMErFADMPuQJz
B9Zhn63ImwzdIIdSf+bUZLeldbGTjD/Iz6I813gtu+h4PW3pWkJeXSnnybHZNZmb/luAqkv2J+NM
ET7vKxZopUh0j0A/iuCakp2cuTsqTkaJuzvHyOp77ZqoXz0Babok6Z80rm0CAwEAATANBgkqhkiG
9w0BAQ0FAAOCAQEATSB6Ja0lTAROHsMnLxc31LxfXYOM55J8lRMvQPrxZLPzvknTu0wPSltGvGj1
bJyW4qJu3Roymz1N0WNo3hpIY+jj6mTYWgWesfmLoJzg+CuEqtgZlxQvW8io3XR22K8WvfloeGWF
0bIb7OZRt28UhNZYuLqANkctyuaWkwCxpdMt/XsXdQWJa8SoxYw9f7h4MDmDRxUx0npu/VFoLvCp
d5e1WORROlAEWUtsJQQ6uaBisL0CuQZZTe/1mUDcPpYyv7Q1YcsyfDUkEgV4b7z8gRpCuqiQ5v87
EomLgL9PbAjHMBxlYfyFK+SqaPvArCV23ypmASjB6zmISUVRTPABhA==";
        }

    }
}
