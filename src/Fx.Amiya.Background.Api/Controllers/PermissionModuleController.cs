using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo.PermissionModule;
using Fx.Amiya.Dto.PermissionModule;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Infrastructure;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.Background.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class PermissionModuleController : ControllerBase
    {
        private IPermissionModuleService permissionModuleService;
        public PermissionModuleController(IPermissionModuleService permissionModuleService)
        {
            this.permissionModuleService = permissionModuleService;
        }

        /// <summary>
        /// 根据编号获取二级菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet("{moduleId}")]
        public async Task<ResultData<ModuleVo>> GetByModuleAsync(int moduleId)
        {

            var module = await permissionModuleService.GetByModuleIdAsync(moduleId);
            ModuleVo moduleVo = new ModuleVo();
            moduleVo.Id = module.Id;
            moduleVo.Name = module.Name;
            moduleVo.Description = module.Description;
            moduleVo.Valid = module.Valid;
            moduleVo.Path = module.Path;
            moduleVo.Sort = module.Sort;
            moduleVo.ModuleCategoryId = module.ModuleCategoryId;
            return ResultData<ModuleVo>.Success().AddData("moduleCategory", moduleVo);
        }

        /// <summary>
        /// 获取菜单模块列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("menuModuleList")]
        public async Task<ResultData<List<MenuModuleVo>>> GetMenuModuleListAsync()
        {
            var menuModule = from d in await permissionModuleService.GetMenuModuleListAsync()
                             select new MenuModuleVo
                             {
                                 Id = d.Id,
                                 Name = d.Name,
                                 Description = d.Description,
                                 Path = d.Path,
                                 Valid = d.Valid,
                                 Sort=d.Sort,
                                 ModuleList = (from m in d.ModuleList
                                               select new ModuleVo
                                               {
                                                   Id = m.Id,
                                                   Name = m.Name,
                                                   Description = m.Description,
                                                   Valid = m.Valid,
                                                   Sort=m.Sort,
                                                   Path = m.Path,
                                                   ModuleCategoryId = m.ModuleCategoryId
                                               }).ToList()
                             };
            return ResultData<List<MenuModuleVo>>.Success().AddData("menuModule", menuModule.ToList());
        }



        /// <summary>
        /// 根据职位获取菜单
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns></returns>
        [HttpGet("permissionMenuModuleList/{positionId}")]
        public async Task<ResultData<List<PermissionMenuVo>>> GetMenuModuleListByPositionIdAsync(int positionId)
        {
            var menuModule = from d in await permissionModuleService.GetMenuModuleListByPositionIdAsync(positionId)
                             select new PermissionMenuVo
                             {
                                 Id = d.Id,
                                 Name = d.Name,
                                 Description = d.Description,
                                 Valid = d.Valid,
                                 Path = d.Path,
                                 Sort=d.Sort,
                                 ModuleList = (from m in d.ModuleList
                                               select new PermissionModuleVo
                                               {
                                                   Id = m.Id,
                                                   Name = m.Name,
                                                   Description = m.Description,
                                                   Valid = m.Valid,
                                                   Path = m.Path,
                                                   ModuleCategoryId = m.ModuleCategoryId,
                                                   IsPermission = m.IsPermission,
                                                   Sort=m.Sort
                                               }).ToList()
                             };
            return ResultData<List<PermissionMenuVo>>.Success().AddData("menuModule", menuModule.ToList());
        }


        /// <summary>
        /// 修改啊美雅职位权限
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut("updateAmyPositionAuth")]
        public async Task<ResultData> UpdateAmyPositionAuthAsync(List<UpdatePositionAuthVo> input)
        {
            List<UpdatePositionAuthDto> inputList = new List<UpdatePositionAuthDto>();
            foreach (var x in input)
            {
                UpdatePositionAuthDto dto = new UpdatePositionAuthDto();
                dto.AmyPositionId = x.AmyPositionId;
                dto.ModuleCategoryId = x.ModuleCategoryId;
                dto.ModuleId = x.ModuleId;
                inputList.Add(dto);
            }
            await permissionModuleService.UpdateAmyModuleCategoryAsync(inputList);
            return ResultData.Success();

        }

        /// <summary>
        /// 根据职位id获取职位首页
        /// </summary>
        /// <param name="amyPositionId">职位id</param>
        /// <returns></returns>
        [HttpGet("getDefaultRoute")]
        public async Task<ResultData<string>> GetDefaultRouteAsync([Required] int amyPositionId)
        {
            var route= await permissionModuleService.GetDefaultRouteAsync(amyPositionId);
            return ResultData<string>.Success().AddData(route);
        }


        /// <summary>
        /// 修改啊美雅职位首页
        /// </summary>
        /// <param name="amyPositionId">职位id</param>
        /// <param name="moduleId">首页菜单id</param>
        /// <returns></returns>
        [HttpPut("updateAmyPositionIndex")]
        public async Task<ResultData> UpdateAmyPositionIndexAsync([Required] int amyPositionId,[Required]int moduleId)
        {
            await permissionModuleService.UpdateAmyPermissionIndexAsync(amyPositionId, moduleId);
            return ResultData.Success();
        }

        /// <summary>
        /// 获取主级菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet("moduleCreateList")]
        public async Task<ResultData<List<ModuleCategoryVo>>> GetModuleCategoryListAsync()
        {
            var moduleCreate = from d in await permissionModuleService.GetModuleCategoryListAsync()
                               select new ModuleCategoryVo
                               {
                                   Id = d.Id,
                                   Name = d.Name,
                                   Description = d.Description,
                                   Path = d.Path,
                                   Valid = d.Valid,
                                   Sort=d.Sort
                               };
            return ResultData<List<ModuleCategoryVo>>.Success().AddData("moduleCreate",moduleCreate.ToList());
        }




        /// <summary>
        /// 添加分类模块
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("moduleCategory")]
        public async Task<ResultData> AddModuleCategoryAsync(AddModuleCategoryVo addVo)
        {
            AddModuleCategoryDto addDto = new AddModuleCategoryDto();
            addDto.Name = addVo.Name;
            addDto.Description = addVo.Description;
            addDto.Path = addVo.Path;
            await permissionModuleService.AddModuleCategoryAsync(addDto);
            return ResultData.Success();
        }



        /// <summary>
        /// 修改分类模块
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("moduleCategroy")]
        public async Task<ResultData> UpdateModuleCategoryAsync(UpdateModuleCategoryVo updateVo)
        {
            UpdateModuleCategoryDto updateDto = new UpdateModuleCategoryDto();
            updateDto.Id = updateVo.Id;
            updateDto.Name = updateVo.Name;
            updateDto.Description = updateVo.Description;
            updateDto.Valid = updateVo.Valid;
            updateDto.Path = updateVo.Path;
            await permissionModuleService.UpdateModuleCategoryAsync(updateDto);
            return ResultData.Success();

        }


        /// <summary>
        /// 删除分类模块
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("moduleCategory/{id}")]
        public async Task<ResultData> DeleteModuleCategoryAsync(int id)
        {
            await permissionModuleService.DeleteModuleCategoryAsync(id);
            return ResultData.Success();
        }


        /// <summary>
        /// 根据编号获取一级菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet("moduleCategory/{moduleCategoryId}")]
        public async Task<ResultData<ModuleCategoryVo>> GetByModuleCategoryAsync(int moduleCategoryId)
        {

            var goodsCategory = await permissionModuleService.GetByModuleCategoryIdAsync(moduleCategoryId);
            ModuleCategoryVo category = new ModuleCategoryVo();
            category.Id = goodsCategory.Id;
            category.Name = goodsCategory.Name;
            category.Description = goodsCategory.Description;
            category.Valid = goodsCategory.Valid;
            category.Path = goodsCategory.Path;
            category.Sort = goodsCategory.Sort;
            return ResultData<ModuleCategoryVo>.Success().AddData("moduleCategory", category);
        }

        /// <summary>
        /// 添加模块
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("module")]
        public async Task<ResultData> AddModuleAsync(AddModuleVo addVo)
        {
            AddModuleDto addDto = new AddModuleDto();
            addDto.Name = addVo.Name;
            addDto.Description = addVo.Description;
            addDto.Path = addVo.Path;
            addDto.ModuleCategoryId = addVo.ModuleCategoryId;
            await permissionModuleService.AddModuleAsync(addDto);
            return ResultData.Success();
        }



        /// <summary>
        /// 修改模块
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("module")]
        public async Task<ResultData> UpdateModuleAsync(UpdateModuleVo updateVo)
        {
            UpdateModuleDto updateDate = new UpdateModuleDto();
            updateDate.Id = updateVo.Id;
            updateDate.Name = updateVo.Name;
            updateDate.Description = updateVo.Description;
            updateDate.Path = updateVo.Path;
            updateDate.ModuleCategoryId = updateVo.ModuleCategoryId;
            updateDate.Valid = updateVo.Valid;
            await permissionModuleService.UpdateModuleAsync(updateDate);
            return ResultData.Success();
        }




        /// <summary>
        /// 删除模块
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("module/{id}")]
        public async Task<ResultData> DeleteModuleAsync(int id)
        {
            await permissionModuleService.DeleteModuleAsync(id);
            return ResultData.Success();
        }

        #region 移动模块
        /// <summary>
        /// 移动外层菜单（ModuleCategory）
        /// </summary>
        /// <param name="goodsCategoryMove">菜单移动基础类</param>
        /// <returns></returns>
        [HttpPut("moveModuleCategory")]
        public async Task<ResultData> UpdateModuleCategorySortAsync(ModuleCategoryMoveVo goodsCategoryMove)
        {
            ModuleCategoryMoveDto moduleCategoryMoveDto = new ModuleCategoryMoveDto()
            {
                Id = goodsCategoryMove.Id,
                MoveState = goodsCategoryMove.MoveState,
            };
            await permissionModuleService.MoveModuleCategoryAsync(moduleCategoryMoveDto);
            return ResultData.Success();
        }


        /// <summary>
        /// 置顶/底外层菜单（ModuleCategory）
        /// </summary>
        /// <param name="goodsCategoryMove">菜单移动基础类</param>
        /// <returns></returns>
        [HttpPut("movetopordownModuleCategory")]
        public async Task<ResultData> UpdateTopOrDownModuleCategoryAsync(ModuleCategoryMoveVo goodsCategoryMove)
        {
            ModuleCategoryMoveDto goodsCategoryMoveDto = new ModuleCategoryMoveDto()
            {
                Id = goodsCategoryMove.Id,
                MoveState = goodsCategoryMove.MoveState,
            };
            await permissionModuleService.MoveTopOrDownModuleCategoryAsync(goodsCategoryMoveDto);
            return ResultData.Success();
        }

        /// <summary>
        /// 移动内层菜单（Module）
        /// </summary>
        /// <param name="moduleMove">菜单移动基础类</param>
        /// <returns></returns>
        [HttpPut("moveModule")]
        public async Task<ResultData> UpdateModuleSortAsync(ModuleMoveVo moduleMove)
        {
            ModuleMoveDto moduleMoveDto = new ModuleMoveDto()
            {
                Id = moduleMove.Id,
                ModuleCategoryId= moduleMove.ModuleCategoryId,
                MoveState = moduleMove.MoveState,
            };
            await permissionModuleService.MoveModuleAsync(moduleMoveDto);
            return ResultData.Success();
        }


        /// <summary>
        /// 置顶/底内层菜单（Module）
        /// </summary>
        /// <param name="moduleMove"></param>
        /// <returns></returns>
        [HttpPut("movetopordownModule")]
        public async Task<ResultData> UpdateTopOrDownModuleAsync(ModuleMoveVo moduleMove)
        {
            ModuleMoveDto goodsMoveDto = new ModuleMoveDto()
            {
                Id = moduleMove.Id,
                ModuleCategoryId = moduleMove.ModuleCategoryId,
                MoveState = moduleMove.MoveState,
            };
            await permissionModuleService.MoveTopOrDownModuleAsync(goodsMoveDto);
            return ResultData.Success();
        }
        #endregion




        /// <summary>
        /// 获取按钮权限信息列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("permissionList")]
        public async Task<ResultData<FxPageInfo<PermissionInfoVo>>> GetPermissionInfoListAsync(int pageNum, int pageSize)
        {
            var q = await permissionModuleService.GetPermissionInfoListAsync(pageNum, pageSize);
            var permission = from d in q.List
                             select new PermissionInfoVo
                             {
                                 Id = d.Id,
                                 Descrition = d.Descrition,
                                 Name = d.Name
                             };
            FxPageInfo<PermissionInfoVo> permissionPageInfo = new FxPageInfo<PermissionInfoVo>();
            permissionPageInfo.TotalCount = q.TotalCount;
            permissionPageInfo.List = permission;
            return ResultData<FxPageInfo<PermissionInfoVo>>.Success().AddData("permissionInfo", permissionPageInfo);

        }

        /// <summary>
        /// 获取有效的按钮权限信息列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("simplePermissionList")]
        public async Task<ResultData<List<PermissionInfoIdAndNameVo>>> GetSimplePermissionInfoListAsync()
        {
            var q = await permissionModuleService.GetPermissionInfoSimpleListAsync();
            var permission = from d in q
                             select new PermissionInfoIdAndNameVo
                             {
                                 Id = d.Id,
                                 Description = d.Descrition
                             };
            return ResultData<List<PermissionInfoIdAndNameVo>>.Success().AddData("permissionSimpleInfo", permission.ToList());

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="positionId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("positionPermissionList")]
        public async Task<ResultData<FxPageInfo<PositionPermissionInfoVo>>> GetPermissionInfoListByPositionIdAsync(int positionId, int pageNum, int pageSize)
        {
            var q = await permissionModuleService.GetPermissionInfoListByPositionIdAsync(positionId, pageNum, pageSize);
            var permission = from d in q.List
                             select new PositionPermissionInfoVo
                             {
                                 Id = d.Id,
                                 Descrition = d.Descrition,
                                 Name = d.Name,
                                 IsPermission = d.IsPermission
                             };
            FxPageInfo<PositionPermissionInfoVo> permissionPageInfo = new FxPageInfo<PositionPermissionInfoVo>();
            permissionPageInfo.TotalCount = q.TotalCount;
            permissionPageInfo.List = permission;
            return ResultData<FxPageInfo<PositionPermissionInfoVo>>.Success().AddData("permission", permissionPageInfo);


        }




        /// <summary>
        /// 添加按钮权限信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("permissionInfo")]
        public async Task<ResultData> AddPermissionInfoAsync(AddPermissionInfoVo addVo)
        {
            AddPermissionInfoDto addDto = new AddPermissionInfoDto();
            addDto.Descrition = addVo.Descrition;
            addDto.Name = addVo.Name;
            await permissionModuleService.AddPermissionInfoAsync(addDto);
            return ResultData.Success();
        }




        /// <summary>
        /// 修改按钮权限信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("permissionInfo")]
        public async Task<ResultData> UpdatePermissionInfoAsync(UpdatePermissionInfoVo updateVo)
        {
            UpdatePermissionInfoDto updateDto = new UpdatePermissionInfoDto();
            updateDto.Id = updateVo.Id;
            updateDto.Descrition = updateVo.Descrition;
            updateDto.Name = updateVo.Name;
            await permissionModuleService.UpdatePermissionInfoAsync(updateDto);
            return ResultData.Success();
        }



        /// <summary>
        /// 删除按钮权限信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("permissionInfo/{id}")]
        public async Task<ResultData> DeletePermissionInfoAsync(int id)
        {
            await permissionModuleService.DeletePermissionInfoAsync(id);
            return ResultData.Success();
        }
    }
}