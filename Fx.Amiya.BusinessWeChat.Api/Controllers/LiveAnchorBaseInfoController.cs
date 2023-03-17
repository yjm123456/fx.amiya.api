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
using Fx.Amiya.BusinessWeChat.Api.Vo.LiveAnchorBaseInfo;

namespace Fx.Amiya.BusinessWechat.Api.Controllers
{
    /// <summary>
    /// 主播基础信息API
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class LiveAnchorBaseInfoController : ControllerBase
    {
        private ILiveAnchorBaseInfoService liveAnchorBaseInfoService;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="liveAnchorBaseInfoService"></param>
        public LiveAnchorBaseInfoController(ILiveAnchorBaseInfoService liveAnchorBaseInfoService)
        {
            this.liveAnchorBaseInfoService = liveAnchorBaseInfoService;
        }

        /// <summary>
        ///  获取有效的主播基础信息列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("valid")]
        public async Task<ResultData<List<BaseKeyAndValueVo>>> GetValidListAsync(bool? isSelfLiveAnchor)
        {
            var liveAnchorBaseInfos = from d in await liveAnchorBaseInfoService.GetValidAsync(isSelfLiveAnchor)
                                      select new BaseKeyAndValueVo
                                      {
                                          Id = d.Id,
                                          Name = d.LiveAnchorName,
                                      };
            return ResultData<List<BaseKeyAndValueVo>>.Success().AddData("liveAnchorBaseInfos", liveAnchorBaseInfos.ToList());
        }

        /// <summary>
        /// 根据编号获取主播基础信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<LiveAnchorBaseInfoVo>> GetByIdAsync(string id)
        {

            var result = await liveAnchorBaseInfoService.GetByIdAsync(id);
            LiveAnchorBaseInfoVo liveAnchorBaseInfoVo = new LiveAnchorBaseInfoVo();
            liveAnchorBaseInfoVo.Id = result.Id;
            liveAnchorBaseInfoVo.LiveAnchorName = result.LiveAnchorName;
            liveAnchorBaseInfoVo.ThumbPicture = result.ThumbPicture;
            liveAnchorBaseInfoVo.DueTime = result.DueTime;
            liveAnchorBaseInfoVo.ContractUrl = result.ContractUrl;
            liveAnchorBaseInfoVo.VideoUrl = result.VideoUrl;
            liveAnchorBaseInfoVo.NickName = result.NickName;
            liveAnchorBaseInfoVo.IndividualitySignature = result.IndividualitySignature;
            liveAnchorBaseInfoVo.Description = result.Description;
            liveAnchorBaseInfoVo.DetailPicture = result.DetailPicture;
            liveAnchorBaseInfoVo.IsMain = result.IsMain;
            liveAnchorBaseInfoVo.IsSelfLivevAnchor = result.IsSelfLivevAnchor;
            liveAnchorBaseInfoVo.Valid = true;
            return ResultData<LiveAnchorBaseInfoVo>.Success().AddData("liveAnchorBaseInfo", liveAnchorBaseInfoVo);
        }
    }
}
