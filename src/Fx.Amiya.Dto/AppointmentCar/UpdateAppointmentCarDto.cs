using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AppointmentCar
{
    public class UpdateAppointmentCarDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Address { get; set; }
        public string Hospital { get; set; }
    }
}
