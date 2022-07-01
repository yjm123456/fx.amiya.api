using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class HospitalEnvironmentPicture
    {
        public string Id { get; set; }
        public int HospitalId { get; set; }
        public string HospitalEnvironmentId { get; set; }
        public string PictureUrl { get; set; }
    }
}
