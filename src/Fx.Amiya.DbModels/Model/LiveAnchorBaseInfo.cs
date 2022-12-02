using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class LiveAnchorBaseInfo
    {
        public string Id { get; set; }
        public string LiveAnchorName { get; set; }
        public string ThumbPicture { get; set; }
        public string NickName { get; set; }
        public string IndividualitySignature { get; set; }
        public string Description { get; set; }
        public string DetailPicture { get; set; }
        public string VideoUrl { get; set; }
        public string ContractUrl { get; set; }
        public int? IsMain { get; set; }
        public DateTime? DueTime { get; set; }
        public bool Valid { get; set; }
        public List<CustomerConsumptionCredentials> CustomerConsumptionCredentialsList { get; set; }

    }
}
