using Fx.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.MemberCard.Domain
{
   public class MemberCardHandle: IEntity
    {
        public string MemberCardNum { get; set; }
        public string CustomerId { get; set; }
        public DateTime Date { get; set; }
        public byte MemberRankId { get; set; }
        public bool Valid { get; set; }
        public int? HandleBy { get; set; }

        public virtual void SendToCustomer(string customerId)
        {
            CustomerId = customerId;
        }
    }
}
