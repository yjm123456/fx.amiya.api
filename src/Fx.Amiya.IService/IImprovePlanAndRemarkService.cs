using Fx.Amiya.Dto.ImprovePlanAndRemark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IImprovePlanAndRemarkService
    {
        Task AddAsync(AddImprovePlanAndRemarkDto addDto);
        Task<Dictionary<string, List<ImprovePlanAndRemarkDto>>> GetImproveAndRemark(string indicatorsId,int hospitalId);
        Task UpdateImproveAndRemark(UpdateImprovePlanAndRemarkDto updateDto);
        Task DeleteAsync(string indicatorsId, int hospitalId);
    }
}
