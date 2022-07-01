using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ItemInfo
{
    public  class ItemSimpleListDto
    {
        public int Id { get; set; }
        public bool IsAgreeLivingPrice { get; set; }
        public decimal? HospitalPrice { get; set; }
    }
}
