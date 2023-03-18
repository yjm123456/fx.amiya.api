using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class AestheticsDesign:BaseDbModel
    {
        public string AestheticsDesignReportId { get; set; }
        public string Design { get; set; }
        public string SimpleHospitalName { get; set; }
        public string RecommendDoctor { get; set; }
    }
}
