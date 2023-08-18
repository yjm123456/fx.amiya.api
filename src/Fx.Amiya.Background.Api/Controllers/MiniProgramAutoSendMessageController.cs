using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.MiniProgramAutoSendMessage;
using Fx.Amiya.Dto.MiniProgramAutoSendMessage;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using jos_sdk_net.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 小程序自动回复留言板块数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class MiniProgramAutoSendMessageController : ControllerBase
    {
        private IMiniProgramAutoSendMessageService miniProgramAutoSendMessageService;
        private IOrderService _orderService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="miniProgramAutoSendMessageService"></param>
        public MiniProgramAutoSendMessageController(IMiniProgramAutoSendMessageService miniProgramAutoSendMessageService, IOrderService orderService)
        {
            this.miniProgramAutoSendMessageService = miniProgramAutoSendMessageService;
            _orderService = orderService;
        }


        /// <summary>
        /// 获取小程序自动回复留言信息列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<FxPageInfo<MiniProgramAutoSendMessageVo>>> GetListWithPageAsync()
        {
            try
            {
                var q = await miniProgramAutoSendMessageService.GetMiniProgramAutoSendMessageAsync();


                List<MiniProgramAutoSendMessageVo> miniProgramAutoSendMessagePageInfo = new List<MiniProgramAutoSendMessageVo>();
                FxPageInfo<MiniProgramAutoSendMessageVo> fxPageInfoMiniProgramAutoSendMessagePageInfo = new FxPageInfo<MiniProgramAutoSendMessageVo>();
                MiniProgramAutoSendMessageVo miniProgramAutoSendMessageVo = new MiniProgramAutoSendMessageVo();
                miniProgramAutoSendMessageVo.Id = q.Id;
                miniProgramAutoSendMessageVo.Message = q.Message;
                miniProgramAutoSendMessagePageInfo.Add(miniProgramAutoSendMessageVo);
                fxPageInfoMiniProgramAutoSendMessagePageInfo.TotalCount =1;
                fxPageInfoMiniProgramAutoSendMessagePageInfo.List = miniProgramAutoSendMessagePageInfo;

                return ResultData<FxPageInfo<MiniProgramAutoSendMessageVo>>.Success().AddData("miniProgramAutoSendMessageInfo", fxPageInfoMiniProgramAutoSendMessagePageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<MiniProgramAutoSendMessageVo>>.Fail(ex.Message);
            }
        }




        /// <summary>
        /// 修改小程序自动回复留言信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateMiniProgramAutoSendMessageVo updateVo)
        {
            try
            {
                await miniProgramAutoSendMessageService.UpdateAsync(updateVo.Message);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }

    }
}
