using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Fx.Amiya.DbModels.Model;

namespace Fx.Amiya.Service
{
  public  class HospitalSurplusAppointmentService: IHospitalSurplusAppointmentService
    {
        private IDalHospitalSurplusAppointment dalHospitalSurplusAppointment;
        private IDalHospitalAppointmentNumer dalHospitalAppointmentNumer;

        public HospitalSurplusAppointmentService(IDalHospitalSurplusAppointment dalHospitalSurplusAppointment,
            IDalHospitalAppointmentNumer dalHospitalAppointmentNumer)
        {
            this.dalHospitalSurplusAppointment = dalHospitalSurplusAppointment;
            this.dalHospitalAppointmentNumer = dalHospitalAppointmentNumer;
        }


        public async Task SetSurplusQuantityAsync()
        {
            var appointmentQuantitys = await dalHospitalAppointmentNumer.GetAll().ToListAsync();

            DateTime date = DateTime.Now;
          
            foreach (var item in appointmentQuantitys)
            {
               var suuplusQuantity= await dalHospitalSurplusAppointment.GetAll()
                    .SingleOrDefaultAsync(e => e.HospitalId == item.HospitalId&&e.Date.Date==date.Date);
                if (suuplusQuantity == null)
                {
                    HospitalSurplusAppointment hospitalSurplusAppointment = new HospitalSurplusAppointment();
                    hospitalSurplusAppointment.HospitalId = item.HospitalId;
                    hospitalSurplusAppointment.ForenoonSurplusQuantity = item.ForenoonCanAppointmentNumer;
                    hospitalSurplusAppointment.AfternoonSurplusQuantity = item.AfternoonCanAppointmentNumer;
                    hospitalSurplusAppointment.Date = date.Date;
                    hospitalSurplusAppointment.Version = 0;
                    await dalHospitalSurplusAppointment.AddAsync(hospitalSurplusAppointment,true);
                }
               
            }

            var suuplusQuantitys = await dalHospitalSurplusAppointment.GetAll().Where(e => e.Date.Date < date.Date).ToListAsync();
            foreach (var item in suuplusQuantitys)
            {
                await dalHospitalSurplusAppointment.DeleteAsync(item, true);
            }
        }
    }
}
