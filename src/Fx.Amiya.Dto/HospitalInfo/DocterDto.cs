using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.HospitalInfo
{
    public class DocterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PicUrl { get; set; }
        public string Position { get; set; }
        public int WorkYearNumer { get; set; }
        public string Description { get; set; }

        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
    }
}
