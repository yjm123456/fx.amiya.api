using Fx.Amiya.Dto.AmiyaRemark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IAmiyaRemarkService
    {
        Task AddAsync(AddAmeiyRemarkDto addDto);
        Task<Dictionary<string, List<AmeiyRemarkDto>>> GetImproveAndRemark(string indicatorsId, int hospitalId);
        Task UpdateImproveAndRemark(UpdateAmeiyRemarkDto updateDto);
        Task DeleteAsync(string indicatorsId, int hospitalId);
    }
}
