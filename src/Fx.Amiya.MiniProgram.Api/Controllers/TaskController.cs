using Fx.Amiya.IService;
using Fx.Amiya.MiniProgram.Api.Filters;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Controllers
{
    [Route("amiya/wxmini/[controller]")]
    [ApiController]
    [FxAmiyaApiUserTypeAuthorization(UserType.Customer)]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService taskService;
        private TokenReader _tokenReader;
        private IMiniSessionStorage _sessionStorage;

        public TaskController(ITaskService taskService, TokenReader tokenReader, IMiniSessionStorage sessionStorage)
        {
            this.taskService = taskService;
            _tokenReader = tokenReader;
            _sessionStorage = sessionStorage;
        }
        /// <summary>
        /// 签到任务
        /// </summary>
        /// <returns></returns>
        [HttpPost("signIn")]
        public async Task<ResultData<string>> CompleteSignTask() {
            string token = _tokenReader.GetToken();
            var sessionInfo = _sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;
            await taskService.CompleteSignTaskAsync(customerId);
            return ResultData<string>.Success().AddData("签到成功");
        }
        
    }
}
