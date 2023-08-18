using Fx.Amiya.Dto.Permission;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Fx.Amiya.DbModels.Model;
using Fx.Infrastructure.DataAccess;
using Fx.Common;

namespace Fx.Amiya.Service
{
    public class PermissionService : IPermissionService
    {
        private IDalModuleCategory dalModuleCategory;
        private IDalAmiyaPositionModulePermission dalAmiyaPositionModulePermission;
        private IDalAmiyaPositionDefaultRoute dalAmiyaPositionDefaultRoute;
        private IDalHospitalEmployee dalHospitalEmployee;
        private IDalHospitalPositionModulePermission dalHospitalPositionModulePermission;
        private IDalHospitalPositionDefaultRoute dalHospitalPositionDefaultRoute;
        private IDalAmiyaPositionPermission dalAmiyaPositionPermission;
        private IDalPermissionInfo _dalPermissionInfo;
        private IUnitOfWork unitOfWork;

        public PermissionService(IDalModuleCategory dalModuleCategory,
            IDalAmiyaPositionModulePermission dalAmiyaPositionModulePermission,
            IDalAmiyaPositionDefaultRoute dalAmiyaPositionDefaultRoute,
            IDalHospitalEmployee dalHospitalEmployee,
            IDalHospitalPositionModulePermission dalHospitalPositionModulePermission,
            IDalHospitalPositionDefaultRoute dalHospitalPositionDefaultRoute,
            IDalAmiyaPositionPermission dalAmiyaPositionPermission,
            IDalPermissionInfo dalPermissionInfo,
            IUnitOfWork unitOfWork)
        {
            this.dalModuleCategory = dalModuleCategory;
            this.dalAmiyaPositionModulePermission = dalAmiyaPositionModulePermission;
            this.dalAmiyaPositionDefaultRoute = dalAmiyaPositionDefaultRoute;
            this.dalHospitalEmployee = dalHospitalEmployee;
            this.dalHospitalPositionModulePermission = dalHospitalPositionModulePermission;
            this.dalHospitalPositionDefaultRoute = dalHospitalPositionDefaultRoute;
            this.dalAmiyaPositionPermission = dalAmiyaPositionPermission;
            _dalPermissionInfo = dalPermissionInfo;
            this.unitOfWork = unitOfWork;
        }



        /// <summary>
        /// 根据职位获取菜单列表
        /// </summary>
        /// <param name="employeeType"></param>
        /// <param name="positionId"></param>
        /// <returns></returns>
        public async Task<List<MenuDto>> GetMenuListAsync(string employeeType, int positionId)
        {
            try
            {
                IEnumerable<MenuDto> menuList;


                if (employeeType == "amiyaEmployee")
                {
                    var q = from d in dalAmiyaPositionModulePermission.GetAll()
                            where d.AmiyaPositionId == positionId && d.ModuleCategory.Valid && d.Module.Valid
                            group d by new
                            {
                                d.ModuleCategoryId,
                                CategoryName = d.ModuleCategory.Name,
                                CategoryDescrption = d.ModuleCategory.Description,
                                CategoryPath = d.ModuleCategory.Path,
                                CategorySort = d.ModuleCategory.Sort,
                                d.ModuleId,
                                ModuleName = d.Module.Name,
                                ModuleDescription = d.Module.Description,
                                ModulePath = d.Module.Path,
                                ModuleSort = d.Module.Sort
                            } into g
                            select new { g.Key };


                    menuList = from d in await q.ToListAsync()
                               group d by new { d.Key.ModuleCategoryId, d.Key.CategoryName, d.Key.CategoryDescrption, d.Key.CategoryPath, d.Key.CategorySort } into g
                               select new MenuDto
                               {
                                   CategoryId = g.Key.ModuleCategoryId,
                                   Name = g.Key.CategoryName,
                                   Description = g.Key.CategoryDescrption,
                                   Path = g.Key.CategoryPath,
                                   Sort = g.Key.CategorySort,
                                   SubMenuList = (from d in g
                                                  select new SubMenuDto
                                                  {
                                                      ModuleId = d.Key.ModuleId,
                                                      Name = d.Key.ModuleName,
                                                      Description = d.Key.ModuleDescription,
                                                      Path = d.Key.ModulePath,
                                                      CategoryId = d.Key.ModuleCategoryId,
                                                      ParentName = d.Key.CategoryDescrption,
                                                      Sort = d.Key.ModuleSort
                                                  }).OrderByDescending(z => z.Sort).ToList()
                               };

                }
                else
                {
                    var q = from d in dalHospitalPositionModulePermission.GetAll()
                            where d.HospitalPositionId == positionId && d.ModuleCategory.Valid && d.Module.Valid
                            group d by new
                            {
                                d.ModuleCategoryId,
                                CategoryName = d.ModuleCategory.Name,
                                CategoryDescrption = d.ModuleCategory.Description,
                                CategoryPath = d.ModuleCategory.Path,
                                CategorySort = d.ModuleCategory.Sort,
                                d.ModuleId,
                                ModuleName = d.Module.Name,
                                ModuleDescription = d.Module.Description,
                                ModulePath = d.Module.Path,
                                ModuleSort = d.Module.Sort,
                            } into g
                            select new { g.Key };

                    menuList = from d in await q.ToListAsync()
                               group d by new { d.Key.ModuleCategoryId, d.Key.CategoryName, d.Key.CategoryDescrption, d.Key.CategoryPath, d.Key.CategorySort } into g
                               select new MenuDto
                               {
                                   CategoryId = g.Key.ModuleCategoryId,
                                   Name = g.Key.CategoryName,
                                   Description = g.Key.CategoryDescrption,
                                   Path = g.Key.CategoryPath,
                                   Sort = g.Key.CategorySort,
                                   SubMenuList = (from d in g
                                                  select new SubMenuDto
                                                  {
                                                      ModuleId = d.Key.ModuleId,
                                                      Name = d.Key.ModuleName,
                                                      Description = d.Key.ModuleDescription,
                                                      Path = d.Key.ModulePath,
                                                      CategoryId = d.Key.ModuleCategoryId,
                                                      ParentName = d.Key.CategoryDescrption,
                                                      Sort = d.Key.ModuleSort

                                                  }).OrderByDescending(z => z.Sort).ToList()
                               };
                }


                var res = menuList.OrderByDescending(z => z.Sort).ToList();
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        /// <summary>
        /// 根据职位获取默认页面路径
        /// </summary>
        /// <param name="employeeType"></param>
        /// <param name="positionId"></param>
        /// <returns></returns>
        public async Task<string> GetDefaultRouteAsync(string employeeType, int positionId)
        {
            try
            {
                // var q = await dalAmiyaPositionDefaultRoute.GetAll().ToListAsync();
                if (employeeType == "amiyaEmployee")
                {
                    var defaultRoute = await dalAmiyaPositionDefaultRoute.GetAll().SingleOrDefaultAsync(e => e.AmiyaPositionId == positionId);
                    return defaultRoute?.Route;
                }
                else
                {
                    var defaultRoute = await dalHospitalPositionDefaultRoute.GetAll().SingleOrDefaultAsync(e => e.HospitalPositionId == positionId);
                    return defaultRoute?.Route;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }



        /// <summary>
        /// 根据职位获取路由列表
        /// </summary>
        /// <param name="employeeType"></param>
        /// <param name="positionId"></param>
        /// <returns></returns>
        public async Task<List<RouteDto>> GetRouteListAsync(string employeeType, int positionId)
        {
            try
            {
                IQueryable<RouteDto> categoryRoute;
                IQueryable<RouteDto> moduleRoute;

                if (employeeType == "amiyaEmployee")
                {
                    categoryRoute = from d in dalAmiyaPositionModulePermission.GetAll()
                                    where d.ModuleCategory.Valid && d.AmiyaPositionId == positionId
                                    group d by new
                                    {
                                        d.ModuleCategoryId,
                                        d.ModuleCategory.Name,
                                        d.ModuleCategory.Description,
                                        d.ModuleCategory.Path,
                                        d.ModuleCategory.Sort
                                    } into g
                                    select new RouteDto
                                    {
                                        CategoryId = g.Key.ModuleCategoryId,
                                        Name = g.Key.Name,
                                        Description = g.Key.Description,
                                        Path = g.Key.Path,
                                        Sort = g.Key.Sort
                                    };


                    moduleRoute = from d in dalAmiyaPositionModulePermission.GetAll()
                                  where d.ModuleCategory.Valid && d.Module.Valid && d.AmiyaPositionId == positionId
                                  select new RouteDto
                                  {
                                      MosuleId = d.ModuleId,
                                      Name = d.Module.Name,
                                      Description = d.Module.Description,
                                      Path = d.Module.Path,
                                      Sort = d.Module.Sort
                                  };
                }
                else
                {
                    categoryRoute = from d in dalHospitalPositionModulePermission.GetAll()
                                    where d.ModuleCategory.Valid && d.HospitalPositionId == positionId
                                    group d by new
                                    {
                                        d.ModuleCategoryId,
                                        d.ModuleCategory.Name,
                                        d.ModuleCategory.Description,
                                        d.ModuleCategory.Path,
                                        d.ModuleCategory.Sort
                                    } into g
                                    select new RouteDto
                                    {
                                        CategoryId = g.Key.ModuleCategoryId,
                                        Name = g.Key.Name,
                                        Description = g.Key.Description,
                                        Path = g.Key.Path,
                                        Sort = g.Key.Sort
                                    };


                    moduleRoute = from d in dalHospitalPositionModulePermission.GetAll()
                                  where d.ModuleCategory.Valid && d.Module.Valid && d.HospitalPositionId == positionId
                                  select new RouteDto
                                  {
                                      MosuleId = d.ModuleId,
                                      Name = d.Module.Name,
                                      Description = d.Module.Description,
                                      Path = d.Module.Path,
                                      Sort = d.Module.Sort
                                  };
                }


                List<RouteDto> routeList = new List<RouteDto>();
                routeList.AddRange(await categoryRoute.OrderByDescending(x => x.Sort).ToListAsync());
                routeList.AddRange(await moduleRoute.OrderByDescending(x => x.Sort).ToListAsync());

                return routeList;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<FxPageInfo<PermissInfoDto>> ListWithPageAsync(string keyWord, int pageNum, int pageSize)
        {
            var q = from d in _dalPermissionInfo.GetAll()   
                    where ((string.IsNullOrEmpty(keyWord))|| d.Name.Contains(keyWord) || d.Description.Contains(keyWord))
                    select new PermissInfoDto
                    {
                        Id = d.Id,
                        Name = d.Name,
                        Desciption = d.Description
                    };
            FxPageInfo<PermissInfoDto> permissInfoDtoPageInfo = new FxPageInfo<PermissInfoDto>();
            permissInfoDtoPageInfo.TotalCount = await q.CountAsync();
            permissInfoDtoPageInfo.List = await q.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return permissInfoDtoPageInfo;
        }

        /// <summary>
        /// 根据职位获取按钮权限列表
        /// </summary>
        /// <param name="employeeType"></param>
        /// <param name="employeeId"></param>
        /// <param name="positionId"></param>
        /// <returns></returns>
        public async Task<List<string>> GetPermissionListAsync(string employeeType, int employeeId, int positionId)
        {
            try
            {
                List<string> permissionList = new List<string>();
                if (employeeType == "hospitalEmployee")
                {
                    var employee = await dalHospitalEmployee.GetAll().SingleOrDefaultAsync(e => e.Id == employeeId);
                    if (employee.IsCreateSubAccount)
                        permissionList.Add("fx.amiya.permission.ADD_HOSPITAL_EMPLOYEE");
                }
                else
                {
                    permissionList.Add("fx.amiya.permission.ADD_HOSPITAL_EMPLOYEE");

                    var permission = await dalAmiyaPositionPermission.GetAll()
                        .Include(e => e.PermissionInfo)
                        .Where(e => e.AmiyaPositionId == positionId).ToListAsync();

                    foreach (var item in permission)
                    {
                        permissionList.Add(item.PermissionInfo.Name);
                    }

                }
                return permissionList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<List<int>> getPermissionsById(int positionId)
        {
            var permission = await dalAmiyaPositionPermission.GetAll()
                                   .Include(e => e.PermissionInfo)
                                   .Where(e => e.AmiyaPositionId == positionId).ToListAsync();
            return permission.Select(x => x.PermissionId).ToList();
        }

        public async Task UpdatePermissionsAsync(List<UpdatePermissionsDto> input)
        {
            try
            {
                unitOfWork.BeginTransaction();
                var positonId = input.Select(x => x.PositionId).FirstOrDefault();
                var amyPositon = await dalAmiyaPositionPermission.GetAll().Where(e => e.AmiyaPositionId == positonId).ToListAsync();
                if (amyPositon.Count > 0)
                {
                    foreach (var x in amyPositon)
                    {
                        await dalAmiyaPositionPermission.DeleteAsync(x, true);
                    }
                }
                foreach (var x in input)
                {
                    if (x.PermissionId != 0)
                    {
                        AmiyaPositionPermission modulePermission = new AmiyaPositionPermission();
                        modulePermission.AmiyaPositionId = x.PositionId;
                        modulePermission.PermissionId = x.PermissionId;
                        await dalAmiyaPositionPermission.AddAsync(modulePermission, true);
                    }
                }
                unitOfWork.Commit();
            }
            catch (Exception err)
            {
                unitOfWork.RollBack();
                throw new Exception(err.Message.ToString());;
            }
        }

        /// <summary>
        /// 设置权限
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddAsync(AddPositionPermissionDto addDto)
        {
            try
            {
                unitOfWork.BeginTransaction();
                //设置默认路由
                var defaultRoute = await dalAmiyaPositionDefaultRoute.GetAll().SingleOrDefaultAsync(e => e.AmiyaPositionId == addDto.PositionId);
                if (defaultRoute != null)
                {
                    if (defaultRoute.Route != addDto.DefaultRoute)
                    {
                        defaultRoute.Route = addDto.DefaultRoute;
                        await dalAmiyaPositionDefaultRoute.UpdateAsync(defaultRoute, true);
                    }
                }
                else
                {
                    AmiyaPositionDefaultRoute amiyaPositionDefaultRoute = new AmiyaPositionDefaultRoute();
                    amiyaPositionDefaultRoute.AmiyaPositionId = addDto.PositionId;
                    amiyaPositionDefaultRoute.Route = addDto.DefaultRoute;
                    await dalAmiyaPositionDefaultRoute.AddAsync(amiyaPositionDefaultRoute, true);
                }


                //设置分类模块和模块
                var modulePermissions = await dalAmiyaPositionModulePermission.GetAll().Where(e => e.AmiyaPositionId == addDto.PositionId).ToListAsync();
                foreach (var item in modulePermissions)
                {
                    await dalAmiyaPositionModulePermission.DeleteAsync(item, true);
                }

                List<AmiyaPositionModulePermission> modulePermissionList = new List<AmiyaPositionModulePermission>();
                foreach (var categroyModule in addDto.ModuleCategroyePermissionList)
                {
                    foreach (var moduleItem in categroyModule.ModuleIds)
                    {
                        AmiyaPositionModulePermission modulePermission = new AmiyaPositionModulePermission();
                        modulePermission.AmiyaPositionId = addDto.PositionId;
                        modulePermission.ModuleCategoryId = categroyModule.ModuleCategoryId;
                        modulePermission.ModuleId = moduleItem;
                        modulePermissionList.Add(modulePermission);
                    }
                }
                await dalAmiyaPositionModulePermission.AddCollectionAsync(modulePermissionList, true);



                //设置按钮权限
                var permissions = await dalAmiyaPositionPermission.GetAll().Where(e => e.AmiyaPositionId == addDto.PositionId).ToListAsync();

                foreach (var item in addDto.PermissionIds)
                {
                    if (!permissions.Exists(e => e.PermissionId == item))
                    {
                        AmiyaPositionPermission amiyaPositionPermission = new AmiyaPositionPermission();
                        amiyaPositionPermission.AmiyaPositionId = addDto.PositionId;
                        amiyaPositionPermission.PermissionId = item;
                        await dalAmiyaPositionPermission.AddAsync(amiyaPositionPermission, true);
                    }
                }


                foreach (var item in permissions)
                {
                    if (!addDto.PermissionIds.Exists(e => e == item.PermissionId))
                    {
                        var permission = await dalAmiyaPositionPermission.GetAll().SingleOrDefaultAsync(e => e.PermissionId == item.PermissionId);
                        await dalAmiyaPositionPermission.DeleteAsync(permission, true);
                    }
                }

                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message.ToString());
            }

        }

        public async Task AddPermissionInfoAsync(AddPermissInfoDto addDto)
        {
            PermissionInfo permissionInfo = new PermissionInfo();
            permissionInfo.Name = addDto.Name;
            permissionInfo.Description = addDto.Description;
            await _dalPermissionInfo.AddAsync(permissionInfo, true);
        }

        public async Task<PermissInfoDto> GetByIdAsync(int id)
        {
            var result = await _dalPermissionInfo.GetAll().Where(x => x.Id == id).SingleOrDefaultAsync();
            PermissInfoDto resultDto = new PermissInfoDto();
            resultDto.Id = result.Id;
            resultDto.Name = result.Name;
            resultDto.Desciption = result.Description;
            return resultDto;
        }

        public async Task UpdateAsync(UpdatePermissInfoDto updateDto)
        {
            var result = await _dalPermissionInfo.GetAll().Where(x => x.Id == updateDto.Id).SingleOrDefaultAsync();
            result.Name = updateDto.Name;
            result.Description = updateDto.Description;
            await _dalPermissionInfo.UpdateAsync(result, true);
        }

        public async Task DeleteAsync(int Id)
        {
            var result = await _dalPermissionInfo.GetAll()
                                   .Include(e => e.AmiyaPositionPermissionList).Where(x => x.Id == Id).SingleOrDefaultAsync();
            if (result.AmiyaPositionPermissionList.Count > 0)
            {
                throw new Exception("该按钮已经被分配到职位使用，请先取消职位应用的按钮再进行删除操作！");
            }
            await _dalPermissionInfo.DeleteAsync(result, true);
        }
    }
}
