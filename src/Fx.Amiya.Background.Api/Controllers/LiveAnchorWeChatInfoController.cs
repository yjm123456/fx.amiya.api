using Fx.Amiya.Background.Api.Vo.LiveAnchorWeChatInfo;
using Fx.Amiya.Dto.LiveAnchorWeChatInfo;
using Fx.Amiya.IService;
using Fx.Amiya.Service;
using Fx.Common;
using Fx.Infrastructure;
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
    /// 主播微信账号
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class LiveAnchorWechatInfoController : ControllerBase
    {
        private ILiveAnchorWeChatInfoService liveAnchorWechatInfoService;
        private IHttpContextAccessor httpContextAccessor;
        public LiveAnchorWechatInfoController(IHttpContextAccessor httpContextAccessor, ILiveAnchorWeChatInfoService liveAnchorWechatInfoService)
        {
            this.liveAnchorWechatInfoService = liveAnchorWechatInfoService;
            this.httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        ///  获取有效的主播微信账号列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("valid")]
        public async Task<ResultData<List<LiveAnchorWechatInfoIdAndNameVo>>> GetValidListAsync()
        {
            var liveAnchorWechatInfos = from d in await liveAnchorWechatInfoService.GetValidAsync()
                                        select new LiveAnchorWechatInfoIdAndNameVo
                                        {
                                            Id = d.Id,
                                            Name = d.WeChatNo,
                                        };
            return ResultData<List<LiveAnchorWechatInfoIdAndNameVo>>.Success().AddData("liveAnchorWechatInfos", liveAnchorWechatInfos.ToList());
        }

        /// <summary>
        ///  根据主播获取有效的主播微信账号列表
        /// </summary>
        /// <param name="liveanchorId">主播id</param>
        /// <returns></returns>
        [HttpGet("validList")]
        public async Task<ResultData<List<LiveAnchorWechatInfoVo>>> GetValidListAsync(int? liveanchorId)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            var liveAnchorWechatInfos = from d in await liveAnchorWechatInfoService.GetValidListByLiveAnchorIdAsync(liveanchorId, employeeId)
                                        select new LiveAnchorWechatInfoVo
                                        {
                                            Id = d.Id,
                                            LiveAnchorId = d.LiveAnchorId,
                                            LiveAnchorName = d.LiveAnchorName,
                                            ContentPlatFormName = d.ContentPlatFormName,
                                            WeChatNo = d.WeChatNo,
                                            NickName = d.NickName,
                                            Remark = d.Remark,
                                            Valid = d.Valid
                                        };
            return ResultData<List<LiveAnchorWechatInfoVo>>.Success().AddData("liveAnchorWechatInfos", liveAnchorWechatInfos.ToList());
        }

        /// <summary>
        /// 获取主播微信账号列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="liveAnchorId"></param>
        /// <param name="valid"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<FxPageInfo<LiveAnchorWechatInfoVo>>> GetListAsync(string keyword, int? liveAnchorId, bool valid, int pageNum, int pageSize)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            var q = await liveAnchorWechatInfoService.GetListAsync(keyword, liveAnchorId, employeeId, valid, pageNum, pageSize);
            var liveAnchorWechatInfos = from d in q.List
                                        select new LiveAnchorWechatInfoVo
                                        {
                                            Id = d.Id,
                                            LiveAnchorId = d.LiveAnchorId,
                                            LiveAnchorName = d.LiveAnchorName,
                                            ContentPlatFormName = d.ContentPlatFormName,
                                            WeChatNo = d.WeChatNo,
                                            NickName = d.NickName,
                                            Remark = d.Remark,
                                            Valid = d.Valid
                                        };
            FxPageInfo<LiveAnchorWechatInfoVo> liveAnchorWechatInfoPageInfo = new FxPageInfo<LiveAnchorWechatInfoVo>();
            liveAnchorWechatInfoPageInfo.TotalCount = q.TotalCount;
            liveAnchorWechatInfoPageInfo.List = liveAnchorWechatInfos;
            return ResultData<FxPageInfo<LiveAnchorWechatInfoVo>>.Success().AddData("liveAnchorWechatInfos", liveAnchorWechatInfoPageInfo);
        }




        /// <summary>
        /// 添加主播微信账号
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddLiveAnchorWechatInfoVo addVo)
        {
            AddLiveAnchorWeChatInfoDto addDto = new AddLiveAnchorWeChatInfoDto();
            addDto.LiveAnchorId = addVo.LiveAnchorId;
            addDto.WeChatNo = addVo.WeChatNo;
            addDto.NickName = addVo.NickName;
            addDto.Remark = addVo.Remark;
            await liveAnchorWechatInfoService.AddAsync(addDto);
            return ResultData.Success();
        }


        /// <summary>
        /// 根据编号获取主播微信账号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<LiveAnchorWechatInfoVo>> GetByIdAsync(string id)
        {

            var result = await liveAnchorWechatInfoService.GetByIdAsync(id);
            LiveAnchorWechatInfoVo wechatInfo = new LiveAnchorWechatInfoVo();
            wechatInfo.Id = result.Id;
            wechatInfo.ContentPlatFormId = result.ContentPlatFormId;
            wechatInfo.LiveAnchorId = result.LiveAnchorId;
            wechatInfo.WeChatNo = result.WeChatNo;
            wechatInfo.NickName = result.NickName;
            wechatInfo.Remark = result.Remark;
            wechatInfo.Valid = result.Valid;
            return ResultData<LiveAnchorWechatInfoVo>.Success().AddData("liveAnchorWechatInfo", wechatInfo);
        }

        /// <summary>
        /// 修改主播微信账号
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateLiveAnchorWechatInfoVo updateVo)
        {
            UpdateLiveAnchorWeChatInfoDto updateDto = new UpdateLiveAnchorWeChatInfoDto();
            updateDto.Id = updateVo.Id;
            updateDto.LiveAnchorId = updateVo.LiveAnchorId;
            updateDto.WeChatNo = updateVo.WeChatNo;
            updateDto.Valid = updateVo.Valid;
            updateDto.NickName = updateVo.NickName;
            updateDto.Remark = updateVo.Remark;
            await liveAnchorWechatInfoService.UpdateAsync(updateDto);
            return ResultData.Success();
        }



        /// <summary>
        /// 删除主播微信账号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync([FromRoute] string id)
        {
            await liveAnchorWechatInfoService.DeleteAsync(id);
            return ResultData.Success();
        }
    }
}
