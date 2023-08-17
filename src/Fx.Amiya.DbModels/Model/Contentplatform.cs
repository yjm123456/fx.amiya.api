using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class Contentplatform
    {
        public string Id { get; set; }

        public string ContentPlatformName { get; set; }
        public bool Valid { get; set; }

        public List<ContentPlatformOrder> ContentPlatformOrderList { get; set; }

        public List<ShoppingCartRegistration> ShoppingCartRegistrationList { get; set; }
        public List<LivingDailyTakeGoods> LivingDailyTakeGoodsList { get; set; }
        public List<LiveReplay> LiveReplayList { get; set; }
    }
}
