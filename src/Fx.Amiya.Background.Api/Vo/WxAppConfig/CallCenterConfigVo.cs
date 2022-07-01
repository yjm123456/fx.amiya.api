using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.WxAppConfig
{
    public class CallCenterConfigVo
    {
        public string CallRecordStoreAddress { get; set; }
        public bool EnableVoiceCardCallable { get; set; }
        public bool SupportOldCallBox { get; set; }
        public int SwitchSimCardInCallCount { get; set; }
        public string VoiceCardManagerAddress { get; set; }
        public string PhoneEncryptKey { get; set; }
        public bool EnablePhoneEncrypt { get; set; }
        public bool HidePhoneNumber { get; set; }
    }
}
