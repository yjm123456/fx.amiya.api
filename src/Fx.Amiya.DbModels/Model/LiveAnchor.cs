using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
   public class LiveAnchor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string HostAccountName { get; set; }

        public string ContentPlateFormId { get; set; }
        public bool Valid { get; set; }

        public string LiveAnchorBaseId { get; set; }


        public List<LiveRequirementInfo> LiveRequirementInfoList { get; set; }
        public List<ContentPlatformOrder> ContentPlatformOrderList { get; set; }

        public List<LiveAnchorMonthlyTargetBeforeLiving> LiveAnchorMonthlyTargetBeforeLivings { get; set; }

        public List<LiveAnchorWeChatInfo> LiveAnchorWeChatInfo { get; set; }

        public List<ShoppingCartRegistration> ShoppingCartRegistrationList { get; set; }

        public List<ShootingAndClip> ShootingAndClips { get; set; }
    }
}
