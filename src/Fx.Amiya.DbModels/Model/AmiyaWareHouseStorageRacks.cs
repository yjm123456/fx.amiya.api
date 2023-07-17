using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class AmiyaWareHouseStorageRacks:BaseDbModel
    {
        public string WareHouseId { get; set; }
        public int CreateBy { get; set; }
        public string Name { get; set; }

        public AmiyaWareHouseNameManage WareHouseNameManage { get; set; }
        public AmiyaEmployee AmiyaEmployee { get; set; }
    }
}
