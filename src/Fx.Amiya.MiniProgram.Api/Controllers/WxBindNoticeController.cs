using Fx.Amiya.IService;
using Fx.Amiya.MiniProgram.Api.Vo.WxBInd;
using Fx.Common.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Controllers
{
    [Route("amiya/wxmini/[controller]")]
    [ApiController]
    public class WxBindNoticeController : ControllerBase
    {
        private readonly IDockingHospitalCustomerInfoService dockingHospitalCustomerInfoService;

        public WxBindNoticeController(IDockingHospitalCustomerInfoService dockingHospitalCustomerInfoService)
        {
            this.dockingHospitalCustomerInfoService = dockingHospitalCustomerInfoService;
        }

        [HttpGet("checkToken")]
        public async Task<string> CheckToken([FromQuery] WxBackInfo wxBackInfo)
        {
            return wxBackInfo.echostr;
        }
        /// <summary>
        /// 测试设置模板
        /// </summary>
        /// <returns></returns>
        [HttpGet("setTemplate")]
        public async Task SetTemplate()
        {
            var appInfo = await dockingHospitalCustomerInfoService.GetMiniProgramAccessTokenInfo(4);
            var requestUrl = $"https://api.weixin.qq.com/cgi-bin/message/subscribe/send?access_token={appInfo.AccessToken}";
            var messageBody = new
            {
                template_id = "bbzpcTSDNUnsYCUQeeFz5u5-aRoVRDNUSffS1rNa_wE",
                touser = "oJrxj5RfkI1gjFJOdAjA-t-UJJlA",
                page = "/pages/index/index",// 点击提示信息要进入的小程序页面
                miniprogram_state = "trial",
                lang = "zh_CN",
                data = new
                {
                    thing1 = new { value = "测试积分消息" },
                    thing2 = new { value = "消费领积分" },
                    character_string4 = new { value = "+100.00" },
                    time5 = new { value = "2022年1月7号" },
                    number10 = new { value = 100 }
                }
            };
            string body = JsonConvert.SerializeObject(messageBody);
            var result = HttpUtil.HTTPJsonPost(requestUrl, body);

        }
    }
}
