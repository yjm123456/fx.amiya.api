using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ContentPlateFormOrder
{
    public class ContentPlateformOrderSimpleInfoDto
    {
        public string Id { get; set; }
        public string AppointmentHospital { get; set; }
        public string OrderStatus { get; set; }
        public string ConsultContent { get; set; }
        public bool IsToHosiotal { get; set; }
    }
}
