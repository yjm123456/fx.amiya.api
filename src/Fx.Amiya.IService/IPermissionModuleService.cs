using Fx.Amiya.Dto.PermissionModule;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
   public interface IPermissionModuleService
    {
        /// <summary>
        /// 获取菜单模块列表
        /// </summary>
        /// <returns></returns>
        Task<List<MenuDto>> GetMenuModuleListAsync();

        Task<List<PermissionMenuDto>> GetMenuModuleListByPositionIdAsync(int positionId);

        /// <summary>
        /// 修改啊美雅职位权限
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateAmyModuleCategoryAsync(List<UpdatePositionAuthDto> input);

        /// <summary>
        /// 根据职位id获取首页地址
        /// </summary>
        /// <param name="amyPositionId"></param>
        /// <returns></returns>
        Task<string> GetDefaultRouteAsync(int amyPositionId);
        /// <summary>
        /// 修改啊美雅职位首页
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateAmyPermissionIndexAsync(int amyPositionId, int moduleId);

        Task<List<ModuleCategoryDto>> GetModuleCategoryListAsync();

        Task<ModuleCategoryDto> GetByModuleCategoryIdAsync(int Id);

        /// <summary>
        /// 添加分类模块
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
       Task AddModuleCategoryAsync(AddModuleCategoryDto addDto);


        /// <summary>
        /// 修改分类模块
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateModuleCategoryAsync(UpdateModuleCategoryDto updateDto);



        /// <summary>
        /// 删除分类模块
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteModuleCategoryAsync(int id);


        Task<ModuleDto> GetByModuleIdAsync(int Id);
        /// <summary>
        /// 添加模块
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddModuleAsync(AddModuleDto addDto);



        /// <summary>
        /// 修改模块
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateModuleAsync(UpdateModuleDto updateDto);



        /// <summary>
        /// 删除模块
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteModuleAsync(int id);


        #region 移动模块
        Task MoveModuleCategoryAsync(ModuleCategoryMoveDto input);

        Task MoveTopOrDownModuleCategoryAsync(ModuleCategoryMoveDto input);

        Task MoveModuleAsync(ModuleMoveDto input);

        Task MoveTopOrDownModuleAsync(ModuleMoveDto input);
        #endregion


        /// <summary>
        /// 获取按钮权限信息列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<PermissionInfoDto>> GetPermissionInfoListAsync(int pageNum, int pageSize);

        /// <summary>
        /// 获取有效的按钮权限信息列表
        /// </summary>
        /// <returns></returns>
        Task<List<PermissionInfoDto>> GetPermissionInfoSimpleListAsync();
        Task<FxPageInfo<PositionPermissionInfoDto>> GetPermissionInfoListByPositionIdAsync(int positionId, int pageNum, int pageSize);

        /// <summary>
        /// 添加按钮权限信息
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
       Task AddPermissionInfoAsync(AddPermissionInfoDto addDto);



        /// <summary>
        /// 修改按钮权限信息
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
       Task UpdatePermissionInfoAsync(UpdatePermissionInfoDto updateDto);


        /// <summary>
        /// 删除按钮权限信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeletePermissionInfoAsync(int id);
    }
}
