using Fx.Amiya.Dto.HospitalPerformance;
using Fx.Amiya.IService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class HospitalPerformanceService : IHospitalPerformanceService
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        private IContentPlateFormOrderService contentPlateFormOrderService;
        public HospitalPerformanceService(IContentPlateFormOrderService contentPlateFormOrderService)
        {
            this.contentPlateFormOrderService = contentPlateFormOrderService;
        }

        /// <summary>
        /// 获取全国机构日运营数据概况
        /// </summary>
        /// <returns></returns>
        public async Task<List<HospitalPerformanceDto>> GetHospitalDailyPerformanceAsync()
        {
            List<HospitalPerformanceDto> resultList = new List<HospitalPerformanceDto>();
            return resultList;
        }

        #region【公共使用业务，包括折线图，业绩明细等】


        #endregion

        #region  【内部方法】


        #endregion
    }
}