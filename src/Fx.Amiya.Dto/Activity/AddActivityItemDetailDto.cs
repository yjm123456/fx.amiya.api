using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.Activity
{
   public class AddActivityItemDetailDto
    {
        public int ActivityId { get; set; }
        public List<AddActivityItemDto> AddActivityItemList { get; set; }
    }


    public class AddActivityItemDto
    { 
        public int ItemId { get; set; }
        public decimal SalePrice { get; set; }
        public decimal LivePrice { get; set; }
    }
}
