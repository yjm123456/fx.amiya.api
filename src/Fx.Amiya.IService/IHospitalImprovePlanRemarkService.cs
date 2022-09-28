using Fx.Amiya.Background.Api.Vo.HospitalImprovePlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IHospitalImprovePlanRemarkService
    {
        /// <summary>
        /// 获取机构提升计划
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task<HospitalImprovePlanDto> GetHospitalImprovePlan(string indicatorId,int hospitalId);
        /// <summary>
        /// 添加机构提升计划
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddHospitalImprovePlan(AddHospitalImprovePlanDto addDto);
        /// <summary>
        /// 修改机构提升计划
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateHospitalImprovePlan(UpdateHospitalImprovePlanDto updateDto);
    }
}
