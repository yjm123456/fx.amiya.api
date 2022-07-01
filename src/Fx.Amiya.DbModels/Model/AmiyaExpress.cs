using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class AmiyaExpress
    {
        public string Id { get; set; }

        public string ExpressName { get; set; }
        public string ExpressCode { get; set; }
        public bool Valid { get; set; }
    }
}
