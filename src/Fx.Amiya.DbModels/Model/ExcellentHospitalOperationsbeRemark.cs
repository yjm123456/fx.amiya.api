using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    /// <summary>
    /// 优秀机构运营健康指标标注
    /// </summary>
    public class ExcellentHospitalOperationsbeRemark:BaseDbModel
    {
        public string Id { get; set; }
        public string Remark { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
