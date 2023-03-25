using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels
{
    public class BaseDbModel
    {
        public string Id { get; set; }
        public DateTime CreateDate { get; set; }

        //public int CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
       // public int? UpdateBy { get; set; }
        public bool Valid { get; set; }
        public DateTime? DeleteDate { get; set; }
       // public int? DeleteBy { get; set; }
    }
}
