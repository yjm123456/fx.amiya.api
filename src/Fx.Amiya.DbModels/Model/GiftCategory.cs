using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class GiftCategory:BaseDbModel
    {
        public string Name { get; set; }
        public string SimpleCode { get; set; }
        public int CreateBy { get; set; }
        public int? UpdateBy { get; set; }     
    }
}
