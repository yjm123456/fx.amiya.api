using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
    public class TagInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte Type { get; set; }
        public bool Valid { get; set; }

        public List<HospitalTagDetail> HospitalTagDetailList { get; set; }
    }
}
