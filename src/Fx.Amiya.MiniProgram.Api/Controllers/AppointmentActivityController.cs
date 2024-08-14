using Fx.Amiya.IService;
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
    public class AppointmentActivityController : ControllerBase
    {
        private readonly IAppointmentActivityService appointmentActivityService;
        private IMiniSessionStorage sessionStorage;
        private TokenReader tokenReader;
        public AppointmentActivityController(IAppointmentActivityService appointmentActivityService, IMiniSessionStorage sessionStorage, TokenReader tokenReader)
        {
            this.appointmentActivityService = appointmentActivityService;
            this.sessionStorage = sessionStorage;
            this.tokenReader = tokenReader;
        }
        [HttpPost]
        public async Task<ResultData> AppointmentAsync()
        {
            try
            {
                var token = tokenReader.GetToken();
                var session = sessionStorage.GetSession(token);
                string userId = session.FxUserId;
                await appointmentActivityService.AppointmentAsync(userId);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }

        }
    }
}
