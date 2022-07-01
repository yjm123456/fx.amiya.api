using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.MemberCard.DbModels
{
   public class MemberCardHandleDbModel
    {
        public string  MemberCardNum { get; set; }
        public string CustomerId { get; set; }
        public DateTime Date { get; set; }
        public byte MemberRankId { get; set; }
        public bool Valid { get; set; }
        public int? HandleBy { get; set; }

        public MemberRankInfoDbModel MemberRankInfo { get; set; }
    }
}
