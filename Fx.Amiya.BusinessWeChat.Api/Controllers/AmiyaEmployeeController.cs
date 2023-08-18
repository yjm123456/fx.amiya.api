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
using Fx.Amiya.Core.Interfaces.MemberCard;
using Fx.Amiya.Core.Interfaces.Integration;
using Fx.Authorization.Attributes;
using Fx.Amiya.BusinessWeChat.Api.Vo.CustomerInfo;
using Fx.Amiya.BusinessWeChat.Api.Vo.Base;
using Fx.Amiya.BusinessWeChat.Api.Vo.AmiyaEmployee;
using Fx.Amiya.Dto.AmiyaEmployee;

namespace Fx.Amiya.BusinessWechat.Api.Controllers
{
    /// <summary>
    /// 啊美雅员工API
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class AmiyaEmployeeController : ControllerBase
    {
        private IAmiyaEmployeeService employeeService;
        private IHttpContextAccessor httpContextAccessor;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="employeeService"></param>
        /// <param name="httpContextAccessor"></param>
        public AmiyaEmployeeController(IAmiyaEmployeeService employeeService,
            IHttpContextAccessor httpContextAccessor)
        {
            this.employeeService = employeeService;
            this.httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 根据员工编号获取员工信息
        /// </summary>
        /// <param name="id">员工编号</param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<AmiyaEmployeeVo>> GetByIdAsync(int id)
        {
            try
            {
                AmiyaEmployeeVo employeeVo = new AmiyaEmployeeVo();
                var q = await employeeService.GetByIdAsync(id);
                if (q.Id != 0)
                {
                    employeeVo.Id = q.Id;
                    employeeVo.Name = q.Name;
                    employeeVo.Avatar = q.Avatar ?? "";
                    employeeVo.UserName = q.UserName;
                    employeeVo.Valid = q.Valid;
                    employeeVo.PositionId = q.PositionId;
                    employeeVo.Email = q.Email;
                    employeeVo.PositionName = q.PositionName;
                    employeeVo.IsCustomerService = q.IsCustomerService;
                    employeeVo.LiveAnchorIds = q.LiveAnchorIds;
                    employeeVo.LiveAnchorBaseId = q.LiveAnchorBaseId;
                    employeeVo.LiveAnchorBaseName = q.LiveAnchorBaseName;
                }
                return ResultData<AmiyaEmployeeVo>.Success().AddData("employeeInfo", employeeVo);
            }
            catch (Exception ex)
            {
                return ResultData<AmiyaEmployeeVo>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 修改员工信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<ResultData> UpdateAsync(UpdateAmiyaEmployeeVo updateVo)
        {
            try
            {
                UpdateAmiyaEmployeeDto updateDto = new UpdateAmiyaEmployeeDto();
                updateDto.Id = updateVo.Id;
                updateDto.Name = updateVo.Name;
                updateDto.UserName = updateVo.UserName;
                updateDto.Valid = updateVo.Valid;
                updateDto.Email = updateVo.Email;
                updateDto.PositionId = updateVo.PositionId;
                updateDto.IsCustomerService = updateVo.IsCustomerService;
                updateDto.LiveAnchorIds = updateVo.LiveAnchorIds;

                await employeeService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 检查密码是否合法
        /// </summary>
        /// <returns></returns>
        [HttpGet("checkPassword/{password}")]
        public async Task<ResultData<bool>> CheckPasswordAsync(string password)
        {
            bool legitimate = await employeeService.CheckPasswordAsync(password);
            return ResultData<bool>.Success().AddData("islegitimate", legitimate);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("updatePassword")]
        public async Task<ResultData> UpdatePasswordAsync(UpdatePasswordAmiyaVo updateVo)
        {
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);

                UpdatePasswordAmiyaDto updateDto = new UpdatePasswordAmiyaDto();
                updateDto.OldPassword = updateVo.OldPassword.GetMD5String();
                updateDto.NewPassword = updateVo.NewPassword.GetMD5String();
                await employeeService.UpdatePasswordAsync(updateDto, employeeId);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取客服姓名列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("customerServiceNameList")]
        public async Task<ResultData<List<BaseKeyAndValueVo>>> GetCustomerServiceNameListAsync()
        {
            var employee = from d in await employeeService.GetCustomerServiceNameListAsync()
                           select new BaseKeyAndValueVo
                           {
                               Id = d.Id.ToString(),
                               Name = d.Name
                           };
            return ResultData<List<BaseKeyAndValueVo>>.Success().AddData("employee", employee.ToList());
        }

        /// <summary>
        /// 根据职位id获取人员(非客服)
        /// </summary>
        /// <returns></returns>
        [HttpGet("getEmployeeByPositionId")]
        public async Task<ResultData<List<BaseKeyAndValueVo>>> GetemployeeByPositionIdAsync(int? positionId)
        {
            var employee = from d in await employeeService.GetemployeeByPositionIdAsync(positionId)
                           select new BaseKeyAndValueVo
                           {
                               Id = d.Id.ToString(),
                               Name = d.Name
                           };
            return ResultData<List<BaseKeyAndValueVo>>.Success().AddData("employee", employee.ToList());
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
                await employeeService.UpdateAvatarAsync(updateVo.Id, updateVo.Url);
                return ResultData<string>.Success().AddData("avatar",updateVo.Url);
            }
            catch (Exception ex)
            {
                throw new Exception("修改头像失败,请稍后重试！");
            }
        }
    }
}
