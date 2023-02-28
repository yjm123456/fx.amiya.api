using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.LiveAnchorBaseInfo
{
    public class AddLiveAnchorBaseInfoDto
    {
        public string LiveAnchorName { get; set; }
        public string ThumbPicture { get; set; }
        public string NickName { get; set; }
        public string IndividualitySignature { get; set; }
        public string Description { get; set; }
        public string DetailPicture { get; set; }
        public string VideoUrl { get; set; }
        public string ContractUrl { get; set; }

        public DateTime? DueTime { get; set; }
        public bool IsSelfLivevAnchor { get; set; }
        public int? IsMain { get; set; }
    }
}
