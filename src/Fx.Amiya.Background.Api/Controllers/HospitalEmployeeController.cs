using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo.Login;
using Fx.Amiya.IService;
using Fx.Infrastructure.Utils;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Fx.Amiya.Background.Api.Vo.HospitalEmployee;
using Fx.Amiya.Dto.HospitalEmployee;
using Fx.Infrastructure;
using Fx.Amiya.Common;
using System.ComponentModel.DataAnnotations;
using Fx.Authorization.Attributes;
using Fx.Common.Extensions;
using Fx.Common;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 医院员工API
    /// </summary>
    [Route("[controller]")]
    [ApiController]
   
    public class HospitalEmployeeController : ControllerBase
    {
        private IHospitalEmployeeService hospitalEmployeeService;
        private IConfiguration configuration;
        private IHttpContextAccessor httpContextAccessor;
        private FxAppGlobal _fxAppGlobal;
        public HospitalEmployeeController(IHospitalEmployeeService hospitalEmployeeService,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor,
            FxAppGlobal fxAppGlobal)
        {
            this.hospitalEmployeeService = hospitalEmployeeService;
            this.configuration = configuration;
            this.httpContextAccessor = httpContextAccessor;
            _fxAppGlobal = fxAppGlobal;
        }

     

        /// <summary>
        /// 添加医院员工信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("add")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> AddEmployeeAsync(AddHospitalEmployeeVo addVo)
        {
            try
            {
                string employeeType ="";
                AddHospitalEmployeeDto addDto = new AddHospitalEmployeeDto();
                addDto.Name = addVo.Name;
                addDto.UserName = addVo.UserName;
                addDto.Password = addVo.Password.GetMD5String();
                addDto.HospitalPositionId = addVo.HospitalPositionId;
                addDto.IsCustomerService = addVo.IsCustomerService;

                if (httpContextAccessor.HttpContext.User is FxAmiyaHospitalEmployeeIdentity tenant)
                {
                    addDto.HospitalId = tenant.HospitalId;
                    employeeType = EmployeeTypeConstant.HOSPITAL_EMPLOYEE_TYPE;
                }
               

                if (httpContextAccessor.HttpContext.User is FxAmiyaEmployeeIdentity employee)
                {
                    addDto.HospitalId = (int)addVo.HospitalId;
                    addDto.IsCreateSubAccount = addVo.IsCreateSubAccount;
                    employeeType = EmployeeTypeConstant.AMIYA_EMPLOYEE_TYPE;
                }


                await hospitalEmployeeService.AddAsync(addDto, employeeType);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 更新帐户可用性
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpPut("UpdateAccountValid/{employeeId}/{valid}")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> UpdateAccountValid(int employeeId, bool valid)
        {
            try
            {
                await hospitalEmployeeService.UpdateAccountValidAsync(employeeId, valid);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 取所有医院员工列表（分页）
        /// </summary>
        /// <param name="hospitalId">医院编号，可空</param>
        /// <param name="keyword">搜索关键字,可空</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="valid">是否有效</param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<FxPageInfo<HospitalEmployeeVo>>> GetListWithPageAsync(int? hospitalId, string keyword,  int pageNum, int pageSize,bool? valid)
        {
            try
            {
                if (httpContextAccessor.HttpContext.User is FxAmiyaHospitalEmployeeIdentity tenant)
                    hospitalId = tenant.HospitalId;

                var q = await hospitalEmployeeService.GetListWithPageAsync(hospitalId, keyword, pageNum, pageSize,valid);

                var employeeInfos = from d in q.List
                                    select new HospitalEmployeeVo
                                    {
                                        Id = d.Id,
                                        Name = d.Name,
                                        UserName = d.UserName,
                                        Valid = d.Valid,
                                        HospitalId = d.HospitalId,
                                        HospitalName = d.HospitalName,
                                        IsCreateSubAccount = d.IsCreateSubAccount,
                                        HospitalPositionId = d.HospitalPositionId,
                                        HospitalPositionName = d.HospitalPositionName,
                                        IsCustomerService = d.IsCustomerService,
                                    };

                FxPageInfo<HospitalEmployeeVo> employeePage = new FxPageInfo<HospitalEmployeeVo>();
                employeePage.TotalCount = q.TotalCount;
                employeePage.List = employeeInfos;

                return ResultData<FxPageInfo<HospitalEmployeeVo>>.Success().AddData("employeeInfo", employeePage);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<HospitalEmployeeVo>>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 根据员工编号获取员工信息
        /// </summary>
        /// <param name="id">员工编号</param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<HospitalEmployeeVo>> GetByIdAsync(int id)
        {
            try
            {
                var q = await hospitalEmployeeService.GetByIdAsync(id);

                HospitalEmployeeVo employeeVo = new HospitalEmployeeVo();
                employeeVo.Id = q.Id;
                employeeVo.Name = q.Name;
                employeeVo.UserName = q.UserName;
                employeeVo.Valid = q.Valid;
                employeeVo.HospitalId = q.HospitalId;
                employeeVo.HospitalName = q.HospitalName;
                employeeVo.IsCreateSubAccount = q.IsCreateSubAccount;
                employeeVo.HospitalPositionId = q.HospitalPositionId;
                employeeVo.HospitalPositionName = q.HospitalPositionName;
                employeeVo.IsCustomerService = q.IsCustomerService;

                return ResultData<HospitalEmployeeVo>.Success().AddData("employeeInfo", employeeVo);
            }
            catch (Exception ex)
            {

                return ResultData<HospitalEmployeeVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改医院员工信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("info")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> UpdateAsync(UpdateHospitalEmployeeVo updateVo)
        {
            try
            {
               
                UpdateHospitalEmployeeDto updateDto = new UpdateHospitalEmployeeDto();
                updateDto.Id = updateVo.Id;
                updateDto.Name = updateVo.Name;
                updateDto.UserName = updateVo.UserName;
                updateDto.Valid = updateVo.Valid;
                updateDto.HospitalPositionId = updateVo.HospitalPositionId;
                updateDto.IsCreateSubAccount = updateVo.IsCreateSubAccount;
                updateDto.IsCustomerService = updateVo.IsCustomerService;

                string employeeType = "";
                if (httpContextAccessor.HttpContext.User is FxAmiyaHospitalEmployeeIdentity tenant)
                {
                    updateDto.HospitalId = tenant.HospitalId;
                    employeeType = EmployeeTypeConstant.HOSPITAL_EMPLOYEE_TYPE;
                }


                if (httpContextAccessor.HttpContext.User is FxAmiyaEmployeeIdentity employee)
                {
                    updateDto.HospitalId = (int)updateVo.HospitalId;
                    updateDto.IsCreateSubAccount = updateVo.IsCreateSubAccount;
                    employeeType = EmployeeTypeConstant.AMIYA_EMPLOYEE_TYPE;
                }

                await hospitalEmployeeService.UpdateAsync(updateDto, employeeType);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("updatePassword")]
        [FxTenantAuthorize]
        public async Task<ResultData> UpdatePasswordByIdAsync(UpdatePasswordHospitalVo updateVo)
        {
            try 
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaHospitalEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);

                UpdatePasswordHospitalDto updateDto = new UpdatePasswordHospitalDto();
                updateDto.OldPassword = updateVo.OldPassword.GetMD5String();
                updateDto.NewPassword = updateVo.NewPassword.GetMD5String();
                await hospitalEmployeeService.UpdatePasswordAsync(updateDto, employeeId);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 修改医院员工密码
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("passwordById")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> UpdateEmployeePasswordByIdAsync(UpdateEmployeePasswordVo updateVo)
        {
            UpdateEmployeePasswordDto updateDto = new UpdateEmployeePasswordDto();
            updateDto.Id = updateVo.Id;
            updateDto.Password = updateVo.Password.GetMD5String();
            await hospitalEmployeeService.UpdateEmployeePasswordByIdAsync(updateDto);
            return ResultData.Success();

        }



        /// <summary>
        /// 重置帐户密码
        /// 默认密码为：12345
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpPut("resetpassword/{employeeId}")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> ResetPassword(int employeeId)
        {
            try
            {
                await hospitalEmployeeService.ResetPasswordAsync(employeeId, "12345".GetMD5String());
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除医院员工
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> DeleteAsync(int id)
        {
            try
            {
                await hospitalEmployeeService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


    }
}