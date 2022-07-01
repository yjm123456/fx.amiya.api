using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeSql.DataAnnotations;

namespace Fx.Amiya.Modules.MemberCard.DbModels
{
  public  class MemberCardSendRecordDbModel
    {
        [Column(IsIdentity = true)]
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public DateTime Date { get; set; }
        public string MemberCardNum { get; set; }
        public byte MemberRankId { get; set; }
       public int? HandleBy { get; set; }

        public MemberRankInfoDbModel MemberRankInfo { get; set; }
    }
}
