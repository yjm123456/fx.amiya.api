using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
   public class AmiyaPositionDefaultRoute
    {
        public int Id { get; set; }
        public int AmiyaPositionId { get; set; }
        public string Route { get; set; }

        public AmiyaPositionInfo AmiyaPositionInfo { get;set; }
    }
}
