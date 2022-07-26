using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class TikTokUserInfo
    {
        public string Id { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string CipherPhone { get; set; }
        public string CipherName { get; set; }
        public List<TikTokOrderInfo> TikTokOrderInfoList { get; set; }
    }
}
