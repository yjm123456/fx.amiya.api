using Fx.Amiya.Dto.ContentPlateFormOrder;
using Fx.Amiya.Dto.ContentPlatFormOrderSend;
using Fx.Amiya.Dto.HospitalPerformance;
using Fx.Amiya.Dto.Performance;
using Fx.Amiya.Dto.ShoppingCartRegistration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IHospitalPerformanceService
    {
        /// <summary>
        /// 获取全国机构日运营数据概况
        /// </summary>
        /// <returns></returns>
        Task<List<HospitalPerformanceDto>> GetHospitalDailyPerformanceAsync();




        #region【 其他相关业务接口（折线图，明细等）】

        #endregion
    }
}
