using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.SyncOrder.TikTok.TikTokAppInfoConfig
{
    public class TikTokDecryptResult
    {
        public TikTokDecrypt data;
    }
    public class TikTokDecrypt {
        public List<DecrypInfos> decrypt_infos { get; set; }
        public CustomErr custom_err { get; set; }
    }
    public class DecrypInfos {
        public string auth_id { get; set; }
        public string cipher_text { get; set; }
        public string decrypt_text { get; set; }
        public long err_no { get; set; }
        public string err_msg { get; set; }
        public bool is_virtual_tel { get; set; }
        public long expire_time { get; set; }
        public string phone_no_a { get; set; }
        public string phone_no_b { get; set; }
    }
    public class CustomErr {
        public long err_code { get; set; }
        public string err_msg { get; set; }
    }
}
