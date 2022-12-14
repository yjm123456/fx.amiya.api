using Fx.Amiya.Background.Api.Vo.MessageRecieve;
using Fx.Amiya.Dto.MessageRecieve;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 医院接收消息信息
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [FxTenantAuthorize]
    public class HospitalMessageRecieveController : ControllerBase
    {
        private IHttpContextAccessor httpContextAccessor;
        private IMessageRecieveService messageRecieveService;

        public HospitalMessageRecieveController(IHttpContextAccessor httpContextAccessor, IMessageRecieveService messageRecieveService)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.messageRecieveService = messageRecieveService;
        }
        /// <summary>
        /// 获取接收消息信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResultData<MessageRecieveVo>> GetInfo() {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaHospitalEmployeeIdentity;
            int hospitalId = employee.HospitalId;
            var employeeId = Convert.ToInt32(employee.Id);
            var record= await messageRecieveService.GetInfo(hospitalId, employeeId);
            MessageRecieveVo messageRecieveVo = new MessageRecieveVo();
            messageRecieveVo.Id = record.Id;
            /*messageRecieveVo.IsBindWechat = record.IsBindWechat;
            messageRecieveVo.IsBindOfficialAccounts = record.IsBindOfficialAccounts;*/
            messageRecieveVo.IsReceive = record.IsReceive;
            messageRecieveVo.StartTime = record.StartTime;
            messageRecieveVo.EndTime = record.EndTime;
            return ResultData<MessageRecieveVo>.Success().AddData("messageRecieve", messageRecieveVo);
        }
        /// <summary>
        /// 修改接收消息信息
        /// </summary>
        /// <param name="updateMessageRecieveVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData<bool>> UpdateInfo(UpdateMessageRecieveVo updateMessageRecieveVo) {
            UpdateMessageRecieveDto updateMessageRecieveDto = new UpdateMessageRecieveDto();
            updateMessageRecieveDto.Id = updateMessageRecieveVo.Id;
            /*updateMessageRecieveDto.IsBindWechat = updateMessageRecieveVo.IsBindWechat;
            updateMessageRecieveDto.IsBindOfficialAccounts = updateMessageRecieveVo.IsBindOfficialAccounts;*/
            updateMessageRecieveDto.IsReceive = updateMessageRecieveVo.IsReceive;
            updateMessageRecieveDto.StartTime = updateMessageRecieveVo.StartTime;
            updateMessageRecieveDto.EndTime = updateMessageRecieveVo.EndTime;
            await messageRecieveService.UpdateInfo(updateMessageRecieveDto);
            return ResultData<bool>.Success();
        } 
    }
}
