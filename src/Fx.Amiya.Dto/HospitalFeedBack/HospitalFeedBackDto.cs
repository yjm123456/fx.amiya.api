using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HospitalFeedBack
{
    public class HospitalFeedBackDto
    {

        public string Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public int Level { get; set; }
        public int CreateHospital { get; set; }
        public string Hospital { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
