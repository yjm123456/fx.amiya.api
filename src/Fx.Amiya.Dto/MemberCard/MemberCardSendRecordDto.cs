using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.MemberCard
{
    public class MemberCardSendRecordDto
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public DateTime Date { get; set; }
        public string MemberCardNum { get; set; }
        public byte MemberRankId { get; set; }
        public int? HandleBy { get; set; }
    }
}
