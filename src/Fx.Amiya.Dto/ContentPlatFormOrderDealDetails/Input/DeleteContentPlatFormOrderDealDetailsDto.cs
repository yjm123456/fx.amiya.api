using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ContentPlatFormOrderDealDetails.Input
{
    public class DeleteContentPlatFormOrderDealDetailsDto
    {
        public int CreateBy { get; set; }
        public string Id { get; set; }
    }

    public class DeleteContentPlatFormOrderDealDetailsByDealIdDto
    {
        public int CreateBy { get; set; }
        public string DealId { get; set; }
    }
}
