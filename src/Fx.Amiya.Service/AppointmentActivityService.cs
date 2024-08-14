using Fx.Amiya.DbModels.Model;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using jos_sdk_net.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class AppointmentActivityService : IAppointmentActivityService
    {
        private readonly IDalAppointmentActivity dalAppointmentActivity;

        public AppointmentActivityService(IDalAppointmentActivity dalAppointmentActivity)
        {
            this.dalAppointmentActivity = dalAppointmentActivity;
        }
        /// <summary>
        /// 预约
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task AppointmentAsync(string userId)
        {
            var exists = dalAppointmentActivity.GetAll().Where(e => e.UserId == userId).FirstOrDefault();
            if (exists != null)
                throw new Exception("您已预约过该活动,请勿重复预约");
            if (string.IsNullOrEmpty(userId))
                throw new Exception("预约失败请稍后重试");
            AppointmentActivity appointment = new AppointmentActivity();
            appointment.Id = CreateOrderIdHelper.GetBillNextNumber();
            appointment.UserId = userId;
            appointment.IsAppointment = true;
            appointment.CreateDate = DateTime.Now;
            appointment.Valid = true;
            await dalAppointmentActivity.AddAsync(appointment, true);
        }
    }
}
