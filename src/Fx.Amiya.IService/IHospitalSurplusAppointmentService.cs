using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IHospitalSurplusAppointmentService
    {
        /// <summary>
        /// 设置当天剩余可预约数量
        /// </summary>
        /// <returns></returns>
        Task SetSurplusQuantityAsync();
    }
}
