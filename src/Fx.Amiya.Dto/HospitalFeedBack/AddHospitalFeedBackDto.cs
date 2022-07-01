using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HospitalFeedBack
{
    public class AddHospitalFeedBackDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int Level { get; set; }
        public int CreateHospital { get; set; }
    }
}
