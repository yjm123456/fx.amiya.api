using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.GiftCategory
{
    public class UpdateGiftCategoryDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SimpleCode { get; set; }
        public int UpdateBy { get; set; }
        public bool Valid { get; set; }
    }
}
