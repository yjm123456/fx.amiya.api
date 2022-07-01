using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HospitalEnvironmentPicture
{
    public class hospitalEnvironmentPictureAddDto
    {
        public int HospitalId { get; set; }
        public string HospitalEnvironmentId { get; set; }
        public string PictureUrl { get; set; }
    }
}
