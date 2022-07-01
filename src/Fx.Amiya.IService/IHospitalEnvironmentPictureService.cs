using Fx.Amiya.Dto.HospitalEnvironmentPicture;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IHospitalEnvironmentPictureService
    {
        Task<FxPageInfo<HospitalEnvironmentPictureDto>> GetListWithPageAsync(string environmentId, int hospitalId, int pageNum, int pageSize);
        Task AddAsync(hospitalEnvironmentPictureAddDto addDto);
        Task DeleteAsync(string id);

        Task DeleteByHospitalIdAndEnvironmentIdAsync(int hospitalId, string environmentId);
    }
}
