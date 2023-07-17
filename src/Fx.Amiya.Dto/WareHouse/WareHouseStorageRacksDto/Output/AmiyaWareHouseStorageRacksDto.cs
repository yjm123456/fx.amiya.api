using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.WareHouse.WareHouseStorageRacksDto.Output
{
    public class AmiyaWareHouseStorageRacksDto:BaseDto
    {

        public string WareHouseId { get; set; }
        public string WareHouseName { get; set; }
        public int CreateBy { get; set; }
        public string CreateByEmpName { get; set; }
        public string Name { get; set; }
    }
}
