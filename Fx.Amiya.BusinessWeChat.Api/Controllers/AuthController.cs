using Fx.Amiya.BusinessWechat.Api.Vo.Login;
using Fx.Amiya.Common;
using Fx.Amiya.IService;
using Fx.Authentication.Jwt;
using Fx.Identity.Core;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Fx.Common.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Fx.Amiya.Dto.OperationLog;

namespace Fx.Amiya.BusinessWechat.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAmiyaEmployeeService amiyaEmployeeService;
        private IHospitalEmployeeService hospitalEmployeeService;
        private IHttpContextAccessor httpContextAccessor;
        private FxAppGlobal _fxAppGlobal;
        private IOperationLogService operationLogService;

        public AuthController(IAmiyaEmployeeService amiyaEmployeeService,
            IHospitalEmployeeService hospitalEmployeeService,
             IOperationLogService operationLogService,
            IHttpContextAccessor httpContextAccessor,
            FxAppGlobal fxAppGlobal)
        {
            this.amiyaEmployeeService = amiyaEmployeeService;
            this.hospitalEmployeeService = hospitalEmployeeService;
            this.operationLogService = operationLogService;
            this.httpContextAccessor = httpContextAccessor;
            _fxAppGlobal = fxAppGlobal;
        }

        /// <summary>
        /// 通过code检索啊美雅员工信息
        /// </summary>
        /// <param name="code">企业微信Code</param>
        /// <returns></returns>
        [HttpGet("businessWechatAuth")]
        public async Task<ResultData<AmiyaEmployeeAccountVo>> AmiyaBusinessWechatAuthAsync(string code)
        {
            try
            {
                var employee = await amiyaEmployeeService.GetByCodeAsync(code);

                AmiyaEmployeeAccountVo accountVo = new AmiyaEmployeeAccountVo()
                {
                    EmployeeId = employee.Id,
                    EmployeeName = employee.Name,
                    AmiyaPositionId = employee.PositionId,
                    AmiyaPositionName = employee.PositionName,
                    EmployeeType = EmployeeTypeConstant.AMIYA_EMPLOYEE_TYPE,
                    IsCustomerService = employee.IsCustomerService,
                    DepartmentId = employee.DepartmentId,
                    DepartmentName = employee.DepartmentName,
                    UserId = employee.UserId,
                    Code = employee.Code
                };

                return ResultData<AmiyaEmployeeAccountVo>.Success().AddData("businessWechatAuth", accountVo);
            }
            catch (Exception ex)
            {
                return ResultData<AmiyaEmployeeAccountVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 啊美雅员工登录【使用场景：code检索返回无啊美雅员工数据时使用】
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="userId">企业微信UserId</param>
        /// <param name="code">企业微信Code</param>
        /// <returns></returns>
        [HttpGet("amiyaLogin")]
        public async Task<ResultData<AmiyaEmployeeAccountVo>> AmiyaLoginAsync([Required(ErrorMessage = "请输入用户名")] string userName, [Required(ErrorMessage = "请输入密码")] string password, string userId, string code)
        {
            OperationAddDto operationLog = new OperationAddDto();
            operationLog.Source = (int)RequestSource.AmiyaBusinessWechat;
            operationLog.Code = 0;
            try
            {
                var jwtConfig = _fxAppGlobal.AppConfig.FxJwtConfig;
                var employee = await amiyaEmployeeService.LoginAsync(userName.Trim(), password.Trim().GetMD5String());
                int employeeId = Convert.ToInt32(employee.Id);
                operationLog.OperationBy = employeeId;
                if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(code))
                {
                    if (!string.IsNullOrEmpty(employee.UserId) && employee.UserId != userId)
                    {
                        throw new Exception("该用户已绑定过他人企业微信账号，无法绑定到您的企业微信中,请重新登录！");
                    }
                    //await amiyaEmployeeService.UpdateBusinessWechatUserIdAndCode(employee.Id, userId, code);
                }
                var identity = new FxInternalEmployeeIdentity().CreateFxIdentity(employee.Id.ToString());

                AmiyaEmployeeAccountVo accountVo = new AmiyaEmployeeAccountVo()
                {
                    EmployeeId = employee.Id,
                    EmployeeName = employee.Name,
                    AmiyaPositionId = employee.PositionId,
                    AmiyaPositionName = employee.PositionName,
                    EmployeeType = EmployeeTypeConstant.AMIYA_EMPLOYEE_TYPE,
                    IsCustomerService = employee.IsCustomerService,
                    IsDirector = employee.IsDirector,
                    Token = identity.BuildJwtToken(jwtConfig.Key, jwtConfig.ExpireInSeconds / 60),
                    RefreshToken = identity.BuildRefreshToken(jwtConfig.Key, jwtConfig.RefreshTokenExpireInSeconds / 60),
                    DepartmentId = employee.DepartmentId,
                    DepartmentName = employee.DepartmentName,
                    ReadDataCenter = employee.ReadDataCenter,
                    ReadLiveAnchorData = employee.ReadLiveAnchorData,
                    Avatar=employee.Avatar
                };

                return ResultData<AmiyaEmployeeAccountVo>.Success().AddData("amiyaLogin", accountVo);
            }
            catch (Exception ex)
            {
                operationLog.Message = ex.Message;
                operationLog.Code = -1;
                return ResultData<AmiyaEmployeeAccountVo>.Fail(ex.Message);
            }
            finally
            {
                var localOtherInfo = "";
                var hostName = Dns.GetHostName();
                var ipAddresses = Dns.GetHostAddresses(hostName);
                foreach (var x in ipAddresses)
                {
                    localOtherInfo += x + ";";
                }
                localOtherInfo = localOtherInfo.Substring(0, localOtherInfo.Length - 1);
                var localIP = ipAddresses.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);


                operationLog.Parameters = "用户登陆,登陆方式：账号密码登陆，账户：" + userName + "， 主机名称：" + hostName + "，IP地址：" + localIP + "，其他信息：" + localOtherInfo;
                operationLog.RequestType = (int)RequestType.Login;
                operationLog.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
                await operationLogService.AddOperationLogAsync(operationLog);
            }
        }


        /// <summary>
        /// 啊美雅员工登录2【使用场景：code检索返回有啊美雅员工数据时使用】
        /// </summary>
        /// <param name="userId">企业微信UserId</param>
        /// <param name="code">企业微信Code</param>
        /// <returns></returns>
        [HttpGet("amiyaLoginByUserIdAndCode")]
        public async Task<ResultData<AmiyaEmployeeAccountVo>> AmiyaLoginByUserIdAndCodeAsync([Required(ErrorMessage = "请输入用户id")] string userId, [Required(ErrorMessage = "请输入用户code")] string code)
        {
            OperationAddDto operationLog = new OperationAddDto();
            operationLog.Source = (int)RequestSource.AmiyaBusinessWechat;
            operationLog.Code = 0;
            try
            {
                var jwtConfig = _fxAppGlobal.AppConfig.FxJwtConfig;
                var employee = await amiyaEmployeeService.LoginByUserIdAndCodeAsync(userId, code);
                int employeeId = Convert.ToInt32(employee.Id);
                operationLog.OperationBy = employeeId;
                if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(code))
                {
                    await amiyaEmployeeService.UpdateBusinessWechatUserIdAndCode(employee.Id, userId, code);
                }
                var identity = new FxInternalEmployeeIdentity().CreateFxIdentity(employee.Id.ToString());

                AmiyaEmployeeAccountVo accountVo = new AmiyaEmployeeAccountVo()
                {
                    EmployeeId = employee.Id,
                    EmployeeName = employee.Name,
                    AmiyaPositionId = employee.PositionId,
                    AmiyaPositionName = employee.PositionName,
                    EmployeeType = EmployeeTypeConstant.AMIYA_EMPLOYEE_TYPE,
                    IsCustomerService = employee.IsCustomerService,
                    IsDirector = employee.IsDirector,
                    Token = identity.BuildJwtToken(jwtConfig.Key, jwtConfig.ExpireInSeconds / 60),
                    RefreshToken = identity.BuildRefreshToken(jwtConfig.Key, jwtConfig.RefreshTokenExpireInSeconds / 60),
                    DepartmentId = employee.DepartmentId,
                    DepartmentName = employee.DepartmentName,
                    ReadDataCenter = employee.ReadDataCenter,
                    ReadLiveAnchorData = employee.ReadLiveAnchorData
                };

                return ResultData<AmiyaEmployeeAccountVo>.Success().AddData("amiyaLoginByUserIdAndCode", accountVo);
            }
            catch (Exception ex)
            {
                operationLog.Message = ex.Message;
                operationLog.Code = -1;
                return ResultData<AmiyaEmployeeAccountVo>.Fail(ex.Message);
            }
            finally
            {
                var localOtherInfo = "";
                var hostName = Dns.GetHostName();
                var ipAddresses = Dns.GetHostAddresses(hostName);
                foreach (var x in ipAddresses)
                {
                    localOtherInfo += x + ";";
                }
                localOtherInfo = localOtherInfo.Substring(0, localOtherInfo.Length - 1);
                var localIP = ipAddresses.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);


                operationLog.Parameters = "用户登陆, 登陆方式：企业微信授权登陆， 账户：" + userId + "， 主机名称：" + hostName + "，IP地址：" + localIP + "，其他信息：" + localOtherInfo;
                operationLog.RequestType = (int)RequestType.Login;
                operationLog.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
                await operationLogService.AddOperationLogAsync(operationLog);
            }
        }

        /// <summary>
        /// 刷新啊美雅登录账号token
        /// </summary>
        /// <returns></returns>
        [HttpGet("amiyaRefreshToken")]
        public async Task<ResultData<TokenVo>> AmiyaRefreshToken([Required(ErrorMessage = "refreshToken不能为空")] string refreshToken)
        {
            try
            {

                var jwtConfig = _fxAppGlobal.AppConfig.FxJwtConfig;
                FxJwtParser fxJwtParser = new FxJwtParser(refreshToken);
                if (!fxJwtParser.ValidateSignature(jwtConfig.Key) || fxJwtParser.IsExpired() || !fxJwtParser.IsRefreshToken())
                    return ResultData<TokenVo>.Fail(401, "refreshToken无效！");

                string identityType = fxJwtParser.Claims[FxIdentity.ClaimsType_IdentityType].ToString();
                if (identityType != IdentityType.INTERNAL)
                    throw new Exception("该接口只能内部员工调用");

                int employeeId = Convert.ToInt32(fxJwtParser.Claims[FxIdentity.ClaimsType_IdentityId]);
                var employee = await amiyaEmployeeService.GetByIdAsync(employeeId);
                var identity = new FxInternalEmployeeIdentity().CreateFxIdentity(employee.Id.ToString());

                TokenVo tokenVo = new TokenVo();
                tokenVo.Token = identity.BuildJwtToken(jwtConfig.Key, jwtConfig.ExpireInSeconds / 60);
                tokenVo.RefreshToken = identity.BuildRefreshToken(jwtConfig.Key, jwtConfig.RefreshTokenExpireInSeconds / 60);
                return ResultData<TokenVo>.Success().AddData("tokenData", tokenVo);
            }
            catch (Exception ex)
            {
                return ResultData<TokenVo>.Fail(401, ex.Message);
            }
        }




        /// <summary>
        /// 通过code检索医院员工信息
        /// </summary>
        /// <param name="code">企业微信Code</param>
        /// <returns></returns>
        [HttpGet("hospitalBusinessWechatAuth")]
        public async Task<ResultData<AmiyaEmployeeAccountVo>> HospitalBusinessWechatAuthAsync(string code)
        {
            try
            {
                var employee = await amiyaEmployeeService.GetByCodeAsync(code);

                AmiyaEmployeeAccountVo accountVo = new AmiyaEmployeeAccountVo()
                {
                    EmployeeId = employee.Id,
                    EmployeeName = employee.Name,
                    AmiyaPositionId = employee.PositionId,
                    AmiyaPositionName = employee.PositionName,
                    EmployeeType = EmployeeTypeConstant.AMIYA_EMPLOYEE_TYPE,
                    IsCustomerService = employee.IsCustomerService,
                    DepartmentId = employee.DepartmentId,
                    DepartmentName = employee.DepartmentName,
                    UserId = employee.UserId,
                    Code = employee.Code
                };

                return ResultData<AmiyaEmployeeAccountVo>.Success().AddData("businessWechatAuth", accountVo);
            }
            catch (Exception ex)
            {
                return ResultData<AmiyaEmployeeAccountVo>.Fail(ex.Message);
            }
        }
        /// <summary>
        /// 医院员工登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet("hospitalLogin")]
        public async Task<ResultData<HospitalEmployeeAccountVo>> HospitalLoginAsync([Required(ErrorMessage = "请输入用户名")] string userName, [Required(ErrorMessage = "请输入密码")] string password)
        {
            try
            {
                var jwtConfig = _fxAppGlobal.AppConfig.FxJwtConfig;
                var employee = await hospitalEmployeeService.LoginAsync(userName.Trim(), password.Trim().GetMD5String());

                var identity = new FxTenantIdentity().CreateFxIdentity(employee.Id.ToString());

                HospitalEmployeeAccountVo avvountVo = new HospitalEmployeeAccountVo()
                {
                    Avatar=employee.Avatar,
                    EmployeeId = employee.Id,
                    EmployeeName = employee.Name,
                    HospitalId = employee.HospitalId,
                    HospitalName = employee.HospitalName,
                    HospitalPositionId = employee.HospitalPositionId,
                    HospitalPositionName = employee.HospitalPositionName,
                    IsCustomerService = employee.IsCustomerService,
                    EmployeeType = EmployeeTypeConstant.HOSPITAL_EMPLOYEE_TYPE,
                    Token = identity.BuildJwtToken(jwtConfig.Key, jwtConfig.ExpireInSeconds / 60),
                    RefreshToken = identity.BuildRefreshToken(jwtConfig.Key, jwtConfig.RefreshTokenExpireInSeconds / 60)
                };

                return ResultData<HospitalEmployeeAccountVo>.Success().AddData("token", avvountVo);
            }
            catch (Exception ex)
            {
                return ResultData<HospitalEmployeeAccountVo>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 刷新医院登录账号token
        /// </summary>
        /// <returns></returns>
        [HttpGet("hospitalRefreshToken")]
        public async Task<ResultData<TokenVo>> HospitalRefreshToken([Required(ErrorMessage = "refreshToken不能为空")] string refreshToken)
        {
            try
            {
                var jwtConfig = _fxAppGlobal.AppConfig.FxJwtConfig;
                FxJwtParser fxJwtParser = new FxJwtParser(refreshToken);
                if (!fxJwtParser.ValidateSignature(jwtConfig.Key) || fxJwtParser.IsExpired() || !fxJwtParser.IsRefreshToken())
                    return ResultData<TokenVo>.Fail(401, "refreshToken无效！");

                string identityType = fxJwtParser.Claims[FxIdentity.ClaimsType_IdentityType].ToString();
                if (identityType != IdentityType.TENANT)
                    throw new Exception("该接口只能医院账户调用");

                int employeeId = Convert.ToInt32(fxJwtParser.Claims[FxIdentity.ClaimsType_IdentityId]);
                var employee = await hospitalEmployeeService.GetByIdAsync(employeeId);
                var identity = new FxTenantIdentity().CreateFxIdentity(employee.Id.ToString());

                TokenVo tokenVo = new TokenVo();
                tokenVo.Token = identity.BuildJwtToken(jwtConfig.Key, jwtConfig.ExpireInSeconds / 60);
                tokenVo.RefreshToken = identity.BuildRefreshToken(jwtConfig.Key, jwtConfig.RefreshTokenExpireInSeconds / 60);
                return ResultData<TokenVo>.Success().AddData("tokenData", tokenVo);
            }
            catch (Exception ex)
            {
                return ResultData<TokenVo>.Fail(401, ex.Message);
            }
        }


    }
}
