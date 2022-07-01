using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo.Permission;
using Fx.Amiya.Dto.Permission;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.Background.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [FxInternalOrTenantAuthroize]
    public class PermissionController : ControllerBase
    {

        private IPermissionService permissionService;
        private IHttpContextAccessor httpContextAccessor;
        public PermissionController(IPermissionService permissionService, IHttpContextAccessor httpContextAccessor)
        {
            this.permissionService = permissionService;
            this.httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 分页获取按钮列表
        /// </summary>
        /// <param name="keyWord">关键词搜索</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<PermissInfoVo>>> GetListWithPageAsync(string keyWord, int pageNum, int pageSize)
        {
            try
            {
                var q = await permissionService.ListWithPageAsync(keyWord, pageNum, pageSize);

                var permissInfo = from d in q.List
                                              select new PermissInfoVo
                                              {
                                                  Id = d.Id,
                                                  Name=d.Name,
                                                  Description=d.Desciption
                                              };

                FxPageInfo<PermissInfoVo> permissionInfoPageInfo = new FxPageInfo<PermissInfoVo>();
                permissionInfoPageInfo.TotalCount = q.TotalCount;
                permissionInfoPageInfo.List = permissInfo;

                return ResultData<FxPageInfo<PermissInfoVo>>.Success().AddData("permissionInfoPageInfo", permissionInfoPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<PermissInfoVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddPermissInfoVo addVo)
        {
            try
            {
                AddPermissInfoDto addDto = new AddPermissInfoDto();
                addDto.Name = addVo.Name;
                addDto.Description = addVo.Description;
                await permissionService.AddPermissionInfoAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 根据id获取按钮
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<PermissInfoVo>> GetByIdAsync(int id)
        {
            try
            {
                var permission = await permissionService.GetByIdAsync(id);
                PermissInfoVo permissionVo = new PermissInfoVo();
                permissionVo.Id = permission.Id;
                permissionVo.Name = permission.Name;
                permissionVo.Description = permission.Desciption;
                return ResultData<PermissInfoVo>.Success().AddData("PermissInfo", permissionVo);
            }
            catch (Exception ex)
            {
                return ResultData<PermissInfoVo>.Fail(ex.Message);
            }
        }
        /// <summary>
        /// 修改按钮
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdatePermissInfoVo updateVo)
        {
            try
            {
                UpdatePermissInfoDto updateDto = new UpdatePermissInfoDto();
                updateDto.Id = updateVo.Id;
                updateDto.Name = updateVo.Name;
                updateDto.Description = updateVo.Description;
                await permissionService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(int id)
        {
            try
            {
                await permissionService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet("collection")]
        public async Task<ResultData<PermissionCollectionVo>> GetPermissionsAsync()
        {
            string employeeType = "";
            int positionId=0;
            int employeeId = 0;

            if (httpContextAccessor.HttpContext.User is FxAmiyaEmployeeIdentity employee)
            {
                employeeId= Convert.ToInt32(employee.Id);
                positionId = Convert.ToInt32(employee.PositionId);
                employeeType = EmployeeTypeConstant.AMIYA_EMPLOYEE_TYPE;
            }

            if (httpContextAccessor.HttpContext.User is FxAmiyaHospitalEmployeeIdentity tenant)
            {
                employeeId = Convert.ToInt32(tenant.Id);
                positionId = Convert.ToInt32(tenant.PositionId);
                employeeType = EmployeeTypeConstant.HOSPITAL_EMPLOYEE_TYPE;
            }
            PermissionCollectionVo permissionCollection = new PermissionCollectionVo();

            
            var menuList = from d in await permissionService.GetMenuListAsync(employeeType, positionId)
                           select new MenuVo
                           {
                               Name = d.Name,
                               Description = d.Description,
                               Path = d.Path,
                               ParentName = d.ParentName,
                               SubMenus = (from t in d.SubMenuList
                                           select new SubMenuVo
                                           {
                                               ModuleId = t.ModuleId,
                                               Name = t.Name,
                                               Description = t.Description,
                                               Path = t.Path,
                                               CategoryId = t.CategoryId,
                                               ParentName = t.ParentName
                                           }).ToList()
                           };

            var routeList = from d in await permissionService.GetRouteListAsync(employeeType, positionId)
                            select new RouteVo
                            {
                                Name = d.Name,
                                Description = d.Description,
                                Path = d.Path
                            };

            permissionCollection.DefaultPageRoutePage = await permissionService.GetDefaultRouteAsync(employeeType, positionId);
            permissionCollection.Menus = menuList.ToList();
            permissionCollection.Routes = routeList.ToList();
            permissionCollection.Permissions = await permissionService.GetPermissionListAsync(employeeType, employeeId, positionId);


            return ResultData<PermissionCollectionVo>.Success().AddData("permissions", permissionCollection);
        }

        /// <summary>
        /// 根据职位获取按钮权限
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns></returns>
        [HttpGet("getPermissionsById/{positionId}")]
        public async Task<ResultData<List<int>>> getPermissionsById(int positionId)
        {
            var menuModule = from d in await permissionService.getPermissionsById(positionId)
                             select d;
            return ResultData<List<int>>.Success().AddData("permissionIds", menuModule.ToList());
        }

        /// <summary>
        /// 修改阿美雅职位按钮权限
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut("updatePermissions")]
        public async Task<ResultData> UpdatePermissionsAsync(List<UpdatePermissionsVo> input)
        {
            List<UpdatePermissionsDto> inputList = new List<UpdatePermissionsDto>();
            foreach (var x in input)
            {
                UpdatePermissionsDto dto = new UpdatePermissionsDto();
                dto.PositionId = x.PositionId;
                dto.PermissionId = x.PermissionId;
                inputList.Add(dto);
            }
            await permissionService.UpdatePermissionsAsync(inputList);
            return ResultData.Success();

        }
    }
}