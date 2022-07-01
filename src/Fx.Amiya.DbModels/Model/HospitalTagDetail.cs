using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
    public class HospitalTagDetail
    {
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public int TagId { get; set; }


        public HospitalInfo HospitalInfo { get; set; }
        public TagInfo TagInfo { get; set; }
    }
}
