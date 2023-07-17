using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.WareHouse.WareHouseStorageRacksDto.Input
{
    public class QueryAmiyaWareHouseStorageRacksDto:BaseQueryDto
    {
        public string WarehouseId { get; set; }
        public bool? Valid { get; set; }
    }
}
