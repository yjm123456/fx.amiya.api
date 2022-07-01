using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
  public  class HospitalPositionDefaultRoute
    {
        public int Id { get; set; }
        public int HospitalPositionId { get; set; }
        public string Route { get; set; }

        public HospitalPositionInfo HospitalPositionInfo { get; set; }
    }
}
