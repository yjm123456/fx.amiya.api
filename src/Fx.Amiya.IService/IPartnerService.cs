using Fx.Amiya.Dto.Partner;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
   public interface IPartnerService
    {
        Task<FxPageInfo<PartnerInfoDto>> GetInfoListWithPageAsync(int pageNum, int pageSize);


        Task AddInfoAsync(AddPartnerInfoDto addDto, int employeeId);


        Task<PartnerInfoDto> GetInfoByIdAsync(int id);


        Task UpdateInfoAsync(UpdatePartnerInfoDto updateDto);


        Task DeleteInfoAsync(int id);


        /// <summary>
        /// 添加合作方权限
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddPermissionAsync(AddPartnerPermissionDto addDto);

        /// <summary>
        /// 修改合作方权限
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdatePermissionAsync(UpdatePartnerPermissionDto updateDto);
    }
}
