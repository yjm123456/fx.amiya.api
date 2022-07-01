using Fx.Amiya.Dto.Permission;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IPermissionService
    {
        /// <summary>
        /// 根据职位编号获取菜单权限
        /// </summary>
        /// <param name="employeeType"></param>
        /// <param name="positionId"></param>
        /// <returns></returns>
        Task<List<MenuDto>> GetMenuListAsync(string employeeType, int positionId);


        /// <summary>
        /// 获取默认路由
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns></returns>
        Task<string> GetDefaultRouteAsync(string employeeType,int positionId);


        /// <summary>
        /// 获取路由列表
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns></returns>
        Task<List<RouteDto>> GetRouteListAsync(string employeeType,int positionId);

        /// <summary>
        /// 分页获取按钮
        /// </summary>
        /// <param name="keyWord"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<PermissInfoDto>> ListWithPageAsync(string keyWord, int pageNum, int pageSize);

        /// <summary>
        /// 获取按钮权限
        /// </summary>
        /// <param name="employeeType"></param>
        /// <param name="employeeId"></param>
        /// <param name="positionId"></param>
        /// <returns></returns>
        Task<List<string>> GetPermissionListAsync(string employeeType, int employeeId,int positionId);
        /// <summary>
        /// 根据角色获取按钮权限id
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns></returns>
        Task<List<int>> getPermissionsById(int positionId);

        /// <summary>
        /// 设置按钮权限
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdatePermissionsAsync(List<UpdatePermissionsDto> input);

        /// <summary>
        /// 设置权限
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
       Task AddAsync(AddPositionPermissionDto addDto);

        Task AddPermissionInfoAsync(AddPermissInfoDto addDto);

        Task<PermissInfoDto> GetByIdAsync(int id);
        Task UpdateAsync(UpdatePermissInfoDto updateDto);
        Task DeleteAsync(int Id);
    }
}
