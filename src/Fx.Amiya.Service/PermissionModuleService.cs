using Fx.Amiya.IDal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Fx.Amiya.Dto.PermissionModule;
using Fx.Amiya.DbModels.Model;
using Fx.Infrastructure;
using Fx.Amiya.IService;
using Fx.Common;
using Fx.Infrastructure.DataAccess;

namespace Fx.Amiya.Service
{
    public class PermissionModuleService : IPermissionModuleService
    {
        private IDalModuleCategory dalModuleCategory;
        private IDalModule dalModule;
        private IDalPermissionInfo dalPermissionInfo;
        private IUnitOfWork unitOfWork;
        private IDalAmiyaPositionModulePermission dalAmiyaPositionModulePermission;
        private IDalAmiyaPositionPermission dalAmiyaPositionPermission;
        private IDalAmiyaPositionDefaultRoute dalAmypositonRoute;
        public PermissionModuleService(IDalModuleCategory dalModuleCategory,
            IDalModule dalModule,
            IDalPermissionInfo dalPermissionInfo,
            IUnitOfWork unitOfWork,
            IDalAmiyaPositionModulePermission dalAmiyaPositionModulePermission,
            IDalAmiyaPositionPermission dalAmiyaPositionPermission,
            IDalAmiyaPositionDefaultRoute route)
        {
            this.dalModuleCategory = dalModuleCategory;
            this.dalModule = dalModule;
            this.unitOfWork = unitOfWork;
            this.dalPermissionInfo = dalPermissionInfo;
            this.dalAmiyaPositionModulePermission = dalAmiyaPositionModulePermission;
            this.dalAmiyaPositionPermission = dalAmiyaPositionPermission;
            this.dalAmypositonRoute = route;
        }


        /// <summary>
        /// 获取菜单模块列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<MenuDto>> GetMenuModuleListAsync()
        {
            var module = from d in dalModuleCategory.GetAll()
                         select new MenuDto
                         {
                             Id = d.Id,
                             Name = d.Name,
                             Description = d.Description,
                             Valid = d.Valid,
                             Sort = d.Sort,
                             Path = d.Path,
                             ModuleList = (from m in d.ModuleList
                                           select new ModuleDto
                                           {
                                               Id = m.Id,
                                               Name = m.Name,
                                               Description = m.Description,
                                               Valid = m.Valid,
                                               Path = m.Path,
                                               Sort = m.Sort,
                                               ModuleCategoryId = m.ModuleCategoryId
                                           }).OrderByDescending(z => z.Sort).ToList()
                         };
            return await module.OrderByDescending(z => z.Sort).ToListAsync();
        }

        /// <summary>
        /// 根据角色获取菜单权限
        /// </summary>
        /// <returns></returns>
        public async Task<List<MenuDto>> GetMenuPermissionModuleListAsync()
        {
            var module = from d in dalModuleCategory.GetAll()
                         select new MenuDto
                         {
                             Id = d.Id,
                             Name = d.Name,
                             Description = d.Description,
                             Valid = d.Valid,
                             Sort = d.Sort,
                             Path = d.Path,
                             ModuleList = (from m in d.ModuleList
                                           select new ModuleDto
                                           {
                                               Id = m.Id,
                                               Name = m.Name,
                                               Description = m.Description,
                                               Valid = m.Valid,
                                               Path = m.Path,
                                               Sort = m.Sort,
                                               ModuleCategoryId = m.ModuleCategoryId
                                           }).OrderByDescending(z => z.Sort).ToList()
                         };
            return await module.OrderByDescending(z => z.Sort).ToListAsync();
        }



        public async Task<List<PermissionMenuDto>> GetMenuModuleListByPositionIdAsync(int positionId)
        {
            var module = from d in dalModuleCategory.GetAll()
                         select new PermissionMenuDto
                         {
                             Id = d.Id,
                             Name = d.Name,
                             Description = d.Description,
                             Valid = d.Valid,
                             Path = d.Path,
                             Sort = d.Sort,
                             ModuleList = (from m in d.ModuleList
                                           join p in d.PositionModulePermissionList.Where(e => e.AmiyaPositionId == positionId) on m.Id equals p.ModuleId into mp
                                           from p in mp.DefaultIfEmpty()
                                           select new PermissionModuleDto
                                           {
                                               Id = m.Id,
                                               Name = m.Name,
                                               Description = m.Description,
                                               Valid = m.Valid,
                                               Path = m.Path,
                                               Sort = m.Sort,
                                               IsPermission = p == null ? false : true,
                                           }).OrderByDescending(z => z.Sort).ToList()
                         };
            return await module.OrderByDescending(k => k.Sort).ToListAsync();
        }


        /// <summary>
        /// 修改啊美雅职位权限
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateAmyModuleCategoryAsync(List<UpdatePositionAuthDto> input)
        {
            try
            {
                unitOfWork.BeginTransaction();
                var positonId = input.Select(x => x.AmyPositionId).FirstOrDefault();
                var amyPositon = await dalAmiyaPositionModulePermission.GetAll().Where(e => e.AmiyaPositionId == positonId).ToListAsync();
                if (amyPositon.Count > 0)
                {
                    foreach (var x in amyPositon)
                    {
                        await dalAmiyaPositionModulePermission.DeleteAsync(x, true);
                    }
                }
                foreach (var x in input)
                {
                    AmiyaPositionModulePermission modulePermission = new AmiyaPositionModulePermission();
                    modulePermission.AmiyaPositionId = x.AmyPositionId;
                    modulePermission.ModuleCategoryId = x.ModuleCategoryId;
                    modulePermission.ModuleId = x.ModuleId;
                    await dalAmiyaPositionModulePermission.AddAsync(modulePermission, true);
                }
                unitOfWork.Commit();
            }
            catch (Exception err)
            {
                unitOfWork.RollBack();
                throw err;
            }
        }
        /// <summary>
        /// 修改啊美雅职位首页
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task<string> GetDefaultRouteAsync(int amyPositionId)
        {
            var amyPositonRoute = await dalAmypositonRoute.GetAll().Where(e => e.AmiyaPositionId == amyPositionId).FirstOrDefaultAsync();
            if (amyPositonRoute != null)
            {
                return amyPositonRoute.Route;
            }
            else {
                return "";
            }
        }

        /// <summary>
        /// 修改啊美雅职位首页
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateAmyPermissionIndexAsync(int amyPositionId, int moduleId)
        {
            var module = await dalModule.GetAll().Where(z => z.Id == moduleId).FirstOrDefaultAsync();
            if (module == null)
            {
                throw new Exception("未找到该菜单信息，请重新选择！");
            }
            var amyPositonRoute = await dalAmypositonRoute.GetAll().Where(e => e.AmiyaPositionId == amyPositionId).FirstOrDefaultAsync();
            if (amyPositonRoute != null)
            {
                amyPositonRoute.Route = module.Path;
                await dalAmypositonRoute.UpdateAsync(amyPositonRoute, true);

            }
            else
            {
                AmiyaPositionDefaultRoute amiyaPositionDefaultRoute = new AmiyaPositionDefaultRoute();
                amiyaPositionDefaultRoute.AmiyaPositionId = amyPositionId;
                amiyaPositionDefaultRoute.Route = module.Path;
                await dalAmypositonRoute.AddAsync(amiyaPositionDefaultRoute, true);
            }

        }

        public async Task<List<ModuleCategoryDto>> GetModuleCategoryListAsync()
        {
            var moduleCreate = from d in dalModuleCategory.GetAll()
                               where d.Valid
                               select new ModuleCategoryDto
                               {
                                   Id = d.Id,
                                   Name = d.Name,
                                   Description = d.Description,
                                   Path = d.Path,
                                   Valid = d.Valid,
                                   Sort = d.Sort
                               };
            return await moduleCreate.OrderByDescending(z => z.Sort).ToListAsync();

        }


        /// <summary>
        /// 添加分类模块
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddModuleCategoryAsync(AddModuleCategoryDto addDto)
        {
            var minSort = await this.GetMaxOrMinSortModuleCategory(false);
            ModuleCategory moduleCategory = new ModuleCategory();
            moduleCategory.Name = addDto.Name;
            moduleCategory.Description = addDto.Description;
            moduleCategory.Path = addDto.Path;
            moduleCategory.Valid = true;
            moduleCategory.Sort = minSort - 1;
            await dalModuleCategory.AddAsync(moduleCategory, true);
        }


        /// <summary>
        /// 修改分类模块
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateModuleCategoryAsync(UpdateModuleCategoryDto updateDto)
        {
            var moduleCategory = await dalModuleCategory.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
            if (moduleCategory == null)
                throw new Exception("分类模块编号错误");
            moduleCategory.Name = updateDto.Name;
            moduleCategory.Valid = updateDto.Valid;
            moduleCategory.Path = updateDto.Path;
            moduleCategory.Description = updateDto.Description;
            await dalModuleCategory.UpdateAsync(moduleCategory, true);
        }


        /// <summary>
        /// 删除分类模块
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteModuleCategoryAsync(int id)
        {
            try
            {
                var category = await dalModuleCategory.GetAll().Include(e => e.ModuleList).SingleOrDefaultAsync(e => e.Id == id);
                await dalModuleCategory.DeleteAsync(category, true);
            }
            catch (Exception ex)
            {
                throw new Exception("删除失败");
            }
        }


        /// <summary>
        /// 添加模块
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddModuleAsync(AddModuleDto addDto)
        {
            Module module = new Module();
            var MinSort = await this.GetMaxOrMinSortModule(addDto.ModuleCategoryId, false);
            module.Name = addDto.Name;
            module.Description = addDto.Description;
            module.Valid = true;
            module.Path = addDto.Path;
            module.ModuleCategoryId = addDto.ModuleCategoryId;
            module.Sort = MinSort - 1;
            await dalModule.AddAsync(module, true);
        }


        /// <summary>
        /// 修改模块
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateModuleAsync(UpdateModuleDto updateDto)
        {
            var module = await dalModule.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
            if (module == null)
                throw new Exception("模块编号错误");
            module.Name = updateDto.Name;
            module.Description = updateDto.Description;
            module.Path = updateDto.Path;
            module.ModuleCategoryId = updateDto.ModuleCategoryId;
            module.Valid = updateDto.Valid;
            await dalModule.UpdateAsync(module, true);
        }



        /// <summary>
        /// 删除模块
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteModuleAsync(int id)
        {
            try
            {
                var module = await dalModule.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (module == null)
                    throw new Exception("模块编号错误");
                await dalModule.DeleteAsync(module, true);
            }
            catch (Exception ex)
            {
                throw new Exception("删除失败");
            }
        }



        /// <summary>
        /// 获取按钮权限信息列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<PermissionInfoDto>> GetPermissionInfoListAsync(int pageNum, int pageSize)
        {
            var permission = from d in dalPermissionInfo.GetAll()
                             select new PermissionInfoDto
                             {
                                 Id = d.Id,
                                 Name = d.Name,
                                 Descrition = d.Description
                             };

            FxPageInfo<PermissionInfoDto> permissionPageInfo = new FxPageInfo<PermissionInfoDto>();
            permissionPageInfo.TotalCount = await permission.CountAsync();
            permissionPageInfo.List = await permission.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return permissionPageInfo;
        }

        /// <summary>
        /// 获取有效的按钮权限信息列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<List<PermissionInfoDto>> GetPermissionInfoSimpleListAsync()
        {
            var permission = from d in dalPermissionInfo.GetAll()
                             select new PermissionInfoDto
                             {
                                 Id = d.Id,
                                 Name = d.Name,
                                 Descrition = d.Description
                             };
            return permission.ToList();
        }

        public async Task<FxPageInfo<PositionPermissionInfoDto>> GetPermissionInfoListByPositionIdAsync(int positionId, int pageNum, int pageSize)
        {
            var permission = from d in dalPermissionInfo.GetAll()
                             join p in dalAmiyaPositionPermission.GetAll().Where(e => e.AmiyaPositionId == positionId) on d.Id equals p.PermissionId into dp
                             from p in dp.DefaultIfEmpty()
                             select new PositionPermissionInfoDto
                             {
                                 Id = d.Id,
                                 Name = d.Name,
                                 Descrition = d.Description,
                                 IsPermission = p == null ? false : true
                             };

            FxPageInfo<PositionPermissionInfoDto> permissionPageInfo = new FxPageInfo<PositionPermissionInfoDto>();
            permissionPageInfo.TotalCount = await permission.CountAsync();
            permissionPageInfo.List = await permission.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return permissionPageInfo;
        }



        /// <summary>
        /// 添加按钮权限信息
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddPermissionInfoAsync(AddPermissionInfoDto addDto)
        {
            PermissionInfo permissionInfo = new PermissionInfo();
            permissionInfo.Name = addDto.Name;
            permissionInfo.Description = addDto.Descrition;
            await dalPermissionInfo.AddAsync(permissionInfo, true);
        }



        /// <summary>
        /// 修改按钮权限信息
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdatePermissionInfoAsync(UpdatePermissionInfoDto updateDto)
        {
            var permission = await dalPermissionInfo.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
            if (permission == null)
                throw new Exception("按钮权限信息编号错误");
            permission.Name = updateDto.Name;
            permission.Description = updateDto.Descrition;
            await dalPermissionInfo.UpdateAsync(permission, true);
        }


        /// <summary>
        /// 删除按钮权限信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeletePermissionInfoAsync(int id)
        {
            try
            {
                var permission = await dalPermissionInfo.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                await dalPermissionInfo.DeleteAsync(permission, true);
            }
            catch (Exception ex)
            {
                throw new Exception("删除失败");
            }
        }

        public async Task<ModuleCategoryDto> GetByModuleCategoryIdAsync(int Id)
        {
            var moduleCategory = await dalModuleCategory.GetAll().SingleOrDefaultAsync(e => e.Id == Id);
            ModuleCategoryDto result = new ModuleCategoryDto();
            result.Id = moduleCategory.Id;
            result.Name = moduleCategory.Name;
            result.Description = moduleCategory.Description;
            result.Path = moduleCategory.Path;
            result.Sort = moduleCategory.Sort;
            result.Valid = moduleCategory.Valid;
            return result;
        }

        public async Task<ModuleDto> GetByModuleIdAsync(int Id)
        {
            var module = await dalModule.GetAll().SingleOrDefaultAsync(e => e.Id == Id);
            ModuleDto result = new ModuleDto();
            result.Id = module.Id;
            result.Name = module.Name;
            result.Description = module.Description;
            result.Path = module.Path;
            result.Sort = module.Sort;
            result.Valid = module.Valid;
            result.ModuleCategoryId = module.ModuleCategoryId;
            return result;
        }

        #region 移动菜单业务层


        private async Task<int> GetMaxOrMinSortModuleCategory(bool IsMax)
        {
            if (IsMax == true)
            {
                return await dalModuleCategory.GetAll().MaxAsync(e => e.Sort);
            }
            else
            {
                return await dalModuleCategory.GetAll().MinAsync(e => e.Sort);
            }
        }
        private async Task<int> GetMaxOrMinSortModule(int ModuleCategoryId, bool IsMax)
        {
            var result = 0;
            if (IsMax == true)
            {
                var moduleMaxRes = await dalModule.GetAll().Where(z => z.ModuleCategoryId == ModuleCategoryId).ToListAsync();
                if (moduleMaxRes.Count > 0)
                {
                    result = moduleMaxRes.Max(e => e.Sort);
                }
            }
            else
            {
                var moduleMinRes = await dalModule.GetAll().Where(z => z.ModuleCategoryId == ModuleCategoryId).ToListAsync();
                if (moduleMinRes.Count > 0)
                {
                    result = moduleMinRes.Min(e => e.Sort);
                }
            }
            return result;
        }

        private async Task<ModuleCategory> GetNearModuleCategory(int Id, bool IsUp)
        {
            var moduleCategoryList = await dalModuleCategory.GetAll().AsNoTracking().OrderByDescending(z => z.Sort).ToListAsync();
            int ExistRow = 0;
            ModuleCategory category = new ModuleCategory();
            foreach (var x in moduleCategoryList)
            {
                if (x.Id == Id)
                {
                    break;
                }
                ExistRow++;
            }
            if (IsUp == true)
            {
                if (ExistRow == 0)
                {
                    var categoryModel = moduleCategoryList.Where(z => z.Id == Id).FirstOrDefault();
                    category.Id = categoryModel.Id;
                    category.Name = categoryModel.Name;
                    category.Description = categoryModel.Description;
                    category.Valid = categoryModel.Valid;
                    category.Path = categoryModel.Path;
                    category.Sort = categoryModel.Sort;
                }
                else
                {
                    var nearRow = moduleCategoryList[ExistRow - 1];
                    category.Id = nearRow.Id;
                    category.Name = nearRow.Name;
                    category.Description = nearRow.Description;
                    category.Valid = nearRow.Valid;
                    category.Path = nearRow.Path;
                    category.Sort = nearRow.Sort;
                }
            }
            else
            {
                if (ExistRow + 1 == moduleCategoryList.Count)
                {
                    var categoryModel = moduleCategoryList.Where(z => z.Id == Id).FirstOrDefault();
                    category.Id = categoryModel.Id;
                    category.Name = categoryModel.Name;
                    category.Description = categoryModel.Description;
                    category.Valid = categoryModel.Valid;
                    category.Path = categoryModel.Path;
                    category.Sort = categoryModel.Sort;
                }
                else
                {
                    var nearRow = moduleCategoryList[ExistRow + 1];
                    category.Id = nearRow.Id;
                    category.Name = nearRow.Name;
                    category.Description = nearRow.Description;
                    category.Valid = nearRow.Valid;
                    category.Path = nearRow.Path;
                    category.Sort = nearRow.Sort;
                }
            }
            return category;
        }

        private async Task<Module> GetNearModule(int Id, int ModuleCategoryId, bool IsUp)
        {
            var moduleList = await dalModule.GetAll().AsNoTracking().Where(z => z.ModuleCategoryId == ModuleCategoryId).OrderByDescending(z => z.Sort).ToListAsync();
            int ExistRow = 0;
            Module module = new Module();
            foreach (var x in moduleList)
            {
                if (x.Id == Id)
                {
                    break;
                }
                ExistRow++;
            }
            if (IsUp == true)
            {
                if (ExistRow == 0)
                {
                    var categoryModel = moduleList.Where(z => z.Id == Id).FirstOrDefault();
                    module.Id = categoryModel.Id;
                    module.Name = categoryModel.Name;
                    module.Description = categoryModel.Description;
                    module.Valid = categoryModel.Valid;
                    module.ModuleCategoryId = categoryModel.ModuleCategoryId;
                    module.Path = categoryModel.Path;
                    module.Sort = categoryModel.Sort;
                }
                else
                {
                    var nearRow = moduleList[ExistRow - 1];
                    module.Id = nearRow.Id;
                    module.Name = nearRow.Name;
                    module.Description = nearRow.Description;
                    module.ModuleCategoryId = nearRow.ModuleCategoryId;
                    module.Valid = nearRow.Valid;
                    module.Path = nearRow.Path;
                    module.Sort = nearRow.Sort;
                }
            }
            else
            {
                if (ExistRow + 1 == moduleList.Count)
                {
                    var categoryModel = moduleList.Where(z => z.Id == Id).FirstOrDefault();
                    module.Id = categoryModel.Id;
                    module.Name = categoryModel.Name;
                    module.Description = categoryModel.Description;
                    module.ModuleCategoryId = categoryModel.ModuleCategoryId;
                    module.Valid = categoryModel.Valid;
                    module.Path = categoryModel.Path;
                    module.Sort = categoryModel.Sort;
                }
                else
                {
                    var nearRow = moduleList[ExistRow + 1];
                    module.Id = nearRow.Id;
                    module.Name = nearRow.Name;
                    module.Description = nearRow.Description;
                    module.ModuleCategoryId = nearRow.ModuleCategoryId;
                    module.Valid = nearRow.Valid;
                    module.Path = nearRow.Path;
                    module.Sort = nearRow.Sort;
                }
            }
            return module;
        }

        public async Task MoveModuleCategoryAsync(ModuleCategoryMoveDto input)
        {
            var GetModuleCategoryInfo = from d in dalModuleCategory.GetAll().AsNoTracking() select d;
            var moduleCategoryInfo = GetModuleCategoryInfo.Where(z => z.Id == input.Id).FirstOrDefault();
            var changeModuleCategoryInfo = await this.GetNearModuleCategory(input.Id, input.MoveState);
            if (changeModuleCategoryInfo.Id != moduleCategoryInfo.Id)
            {
                int changeSort = moduleCategoryInfo.Sort;
                //修改参数
                moduleCategoryInfo.Sort = changeModuleCategoryInfo.Sort;
                //待修改参数数据
                changeModuleCategoryInfo.Sort = changeSort;
                List<ModuleCategory> addGoodsCategoryList = new List<ModuleCategory>();
                addGoodsCategoryList.Add(moduleCategoryInfo);
                addGoodsCategoryList.Add(changeModuleCategoryInfo);
                foreach (var z in addGoodsCategoryList)
                {
                    await dalModuleCategory.UpdateAsync(z, true);
                }
                await unitOfWork.SaveChangesAsync();
            }
        }

        public async Task MoveTopOrDownModuleCategoryAsync(ModuleCategoryMoveDto input)
        {
            var moduleCategoryInfo = await dalModuleCategory.GetAll().SingleOrDefaultAsync(z => z.Id == input.Id);
            if (input.MoveState == true)
            {
                moduleCategoryInfo.Sort = await this.GetMaxOrMinSortModuleCategory(true) + 1;
            }
            else
            {
                moduleCategoryInfo.Sort = await this.GetMaxOrMinSortModuleCategory(false) - 1;
            }
            await dalModuleCategory.UpdateAsync(moduleCategoryInfo, true);
        }

        public async Task MoveModuleAsync(ModuleMoveDto input)
        {

            var GetModuleInfo = from d in dalModule.GetAll().AsNoTracking() select d;
            var moduleInfo = GetModuleInfo.Where(z => z.Id == input.Id).FirstOrDefault();
            var changeModuleInfo = await this.GetNearModule(input.Id, input.ModuleCategoryId, input.MoveState);
            if (changeModuleInfo.Id != moduleInfo.Id)
            {
                int changeSort = moduleInfo.Sort;
                //修改参数
                moduleInfo.Sort = changeModuleInfo.Sort;
                //待修改参数数据
                changeModuleInfo.Sort = changeSort;
                List<Module> addGoodsCategoryList = new List<Module>();
                addGoodsCategoryList.Add(moduleInfo);
                addGoodsCategoryList.Add(changeModuleInfo);
                foreach (var z in addGoodsCategoryList)
                {
                    await dalModule.UpdateAsync(z, true);
                }
                await unitOfWork.SaveChangesAsync();
            }
        }

        public async Task MoveTopOrDownModuleAsync(ModuleMoveDto input)
        {
            var moduleCategoryInfo = await dalModule.GetAll().SingleOrDefaultAsync(z => z.Id == input.Id);
            if (input.MoveState == true)
            {
                moduleCategoryInfo.Sort = await this.GetMaxOrMinSortModule(input.ModuleCategoryId, true) + 1;
            }
            else
            {
                moduleCategoryInfo.Sort = await this.GetMaxOrMinSortModule(input.ModuleCategoryId, false) - 1;
            }
            await dalModule.UpdateAsync(moduleCategoryInfo, true);
        }


        #endregion
    }
}
