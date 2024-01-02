using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo.Login;
using Fx.Amiya.Common;
using Fx.Amiya.IService;
using Fx.Infrastructure.Utils;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Fx.Amiya.Background.Api.Vo.Auth;
using Newtonsoft.Json;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;
using Fx.Common.Extensions;
using Fx.Identity.Core;
using System.Security.Claims;
using Fx.Authentication.Jwt;
using Fx.Amiya.Background.Api.Vo.AmiyaEmployee;
using Fx.Amiya.Dto.OperationLog;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace Fx.Amiya.Background.Api.Controllers
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
            IHttpContextAccessor httpContextAccessor,
             IOperationLogService operationLogService,
            FxAppGlobal fxAppGlobal)
        {
            this.amiyaEmployeeService = amiyaEmployeeService;
            this.hospitalEmployeeService = hospitalEmployeeService;
            this.httpContextAccessor = httpContextAccessor;
            this.operationLogService = operationLogService;
            _fxAppGlobal = fxAppGlobal;
        }

        /// <summary>
        /// 啊美雅员工登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet("amiyaLogin")]
        public async Task<ResultData<AmiyaEmployeeAccountVo>> AmiyaLoginAsync([Required(ErrorMessage = "请输入用户名")] string userName, [Required(ErrorMessage = "请输入密码")] string password)
        {
            OperationAddDto operationLog = new OperationAddDto();
            operationLog.Source = (int)RequestSource.AmiyaBackground;
            operationLog.Code = 0;
            try
            {
                var jwtConfig = _fxAppGlobal.AppConfig.FxJwtConfig;
                var employee = await amiyaEmployeeService.LoginAsync(userName.Trim(), password.Trim().GetMD5String());
                int employeeId = Convert.ToInt32(employee.Id);
                operationLog.OperationBy = employeeId;
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
                    Avatar = employee.Avatar ?? "",
                    DepartmentName = employee.DepartmentName,
                    ReadDataCenter = employee.ReadDataCenter
                };

                return ResultData<AmiyaEmployeeAccountVo>.Success().AddData("token", accountVo);
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


                operationLog.Parameters = "用户登陆 账户："+ userName + "， 主机名称：" + hostName + "，IP地址：" + localIP + "，其他信息：" + localOtherInfo;
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
        public async Task<ResultData<TokenVo>> AmiyaRefreshToken([Required(ErrorMessage = "登录超时！")] string refreshToken)
        {
            try
            {

                var jwtConfig = _fxAppGlobal.AppConfig.FxJwtConfig;
                FxJwtParser fxJwtParser = new FxJwtParser(refreshToken);
                if (!fxJwtParser.ValidateSignature(jwtConfig.Key) || fxJwtParser.IsExpired() || !fxJwtParser.IsRefreshToken())
                    return ResultData<TokenVo>.Fail(401, "秘钥错误或已过期，请重新登录！");

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
                    Avatar = employee.Avatar ?? "",
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
        public async Task<ResultData<TokenVo>> HospitalRefreshToken([Required(ErrorMessage = "登录超时")] string refreshToken)
        {
            try
            {
                var jwtConfig = _fxAppGlobal.AppConfig.FxJwtConfig;
                FxJwtParser fxJwtParser = new FxJwtParser(refreshToken);
                if (!fxJwtParser.ValidateSignature(jwtConfig.Key) || fxJwtParser.IsExpired() || !fxJwtParser.IsRefreshToken())
                    return ResultData<TokenVo>.Fail(401, "秘钥错误或已过期，请重新登录！");

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
        /// <summary>
        /// 修改用户头像
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("updateAvatar")]
        public async Task<ResultData<string>> UpdateAvatarAsync(UpdateAvatarVo updateVo)
        {
            try
            {
                if (updateVo.Type == 1)
                {
                    await amiyaEmployeeService.UpdateAvatarAsync(updateVo.Id, updateVo.Url);
                }
                if (updateVo.Type == 2)
                {
                    await hospitalEmployeeService.UpdateAvatarAsync(updateVo.Id, updateVo.Url);
                }
                return ResultData<string>.Success().AddData("avatar", updateVo.Url);
            }
            catch (Exception ex)
            {
                throw new Exception("修改头像失败,请稍后重试！");
            }

        }




    }
}