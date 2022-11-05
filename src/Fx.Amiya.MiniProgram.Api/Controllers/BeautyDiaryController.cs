using Fx.Amiya.IService;
using Fx.Amiya.MiniProgram.Api.Filters;
using Fx.Amiya.MiniProgram.Api.Vo.BeautyDiary;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Controllers
{
    /// <summary>
    /// 美丽日记
    /// </summary>
    [Route("amiya/wxmini/[controller]")]
    [ApiController]
    public class BeautyDiaryController : ControllerBase
    {
        private IBeautyDiaryManageService _beautyDiaryManageService;
        public BeautyDiaryController(IBeautyDiaryManageService beautyDiaryManageService)
        {
            _beautyDiaryManageService = beautyDiaryManageService;
        }

        /// <summary>
        /// 获取日记列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<FxPageInfo<BeautyDiarySimpleVo>>> GetListAsync(string keyword, int pageNum, int pageSize)
        {
            var q = await _beautyDiaryManageService.GetSimpleListAsync(keyword, pageNum, pageSize);

            var beautyDiaryManages = from d in q.List
                                     select new BeautyDiarySimpleVo
                                     {
                                         Id = d.Id,
                                         CoverTitle = d.CoverTitle,
                                         Views = d.Views,
                                         GivingLikes = d.GivingLikes,
                                         ThumbPictureUrl = d.ThumbPictureUrl                                       
                                     };
            FxPageInfo<BeautyDiarySimpleVo> beautyDiaryPageInfo = new FxPageInfo<BeautyDiarySimpleVo>();
            beautyDiaryPageInfo.TotalCount = q.TotalCount;
            beautyDiaryPageInfo.List = beautyDiaryManages;
            beautyDiaryPageInfo.PageSize = pageSize;
            beautyDiaryPageInfo.CurrentPageIndex = pageNum;
            beautyDiaryPageInfo.PageCount = q.PageCount;
            return ResultData<FxPageInfo<BeautyDiarySimpleVo>>.Success().AddData("beautyDiaryManages", beautyDiaryPageInfo);
        }
        /// <summary>
        /// 从公众号获取日记列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("wechatlist")]
        public async Task<ResultData<FxPageInfo<WechatBeautyDiarySimpleVo>>> GetListFormWechatAsync(string keyword, int pageNum, int pageSize)
        {
            var q = await _beautyDiaryManageService.GetSimpleListFromWechatAsync(keyword, pageNum, pageSize);

            var beautyDiaryManages = from d in q.List
                                     select new WechatBeautyDiarySimpleVo
                                     {                                       
                                         CoverTitle = d.title,
                                         Author=d.author,                                    
                                         Url=d.url,
                                     };
            FxPageInfo<WechatBeautyDiarySimpleVo> beautyDiaryPageInfo = new FxPageInfo<WechatBeautyDiarySimpleVo>();
            beautyDiaryPageInfo.TotalCount = q.TotalCount;
            beautyDiaryPageInfo.List = beautyDiaryManages;
            beautyDiaryPageInfo.PageSize = pageSize;
            beautyDiaryPageInfo.CurrentPageIndex = pageNum;
            beautyDiaryPageInfo.PageCount = q.PageCount;
            return ResultData<FxPageInfo<WechatBeautyDiarySimpleVo>>.Success().AddData("beautyDiaryManages", beautyDiaryPageInfo);
        }

        /// <summary>
        /// 根据编号获取日记详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ResultData<BeautyDiaryManageForDetailsVo>> GetByIdAsync(string id)
        {
            var beautyDiaryManage = await _beautyDiaryManageService.GetDetailByIdAsync(id);
            BeautyDiaryManageForDetailsVo beautyDiary = new BeautyDiaryManageForDetailsVo()
            {
                Id = beautyDiaryManage.Id,
                CoverTitle = beautyDiaryManage.CoverTitle,
                DetailsTitle = beautyDiaryManage.DetailsTitle,
                ReleaseState = beautyDiaryManage.ReleaseState,
                CreateDate = beautyDiaryManage.CreateDate,
                Views = beautyDiaryManage.Views,
                GivingLikes = beautyDiaryManage.GivingLikes,
                ThumbPictureUrl = beautyDiaryManage.ThumbPictureUrl,
                VideoUrl = beautyDiaryManage.VideoUrl,
                DetailsDescription = beautyDiaryManage.DetailsDescription,
                BannerImage = (from d in beautyDiaryManage.BeautyDiaryBannerImageList
                               select new BeautyDiaryManageBannerImageVo
                               {
                                   Id = d.Id,
                                   PicUrl = d.PicUrl,
                                   DisplayIndex = d.DisplayIndex
                               }).ToList(),
                BeautyDiaryTagName = (from d in beautyDiaryManage.BeautyDiaryTagList
                                      select new BeautyDiaryTagNameVo
                                      {
                                          Id = d.Id,
                                          Name = d.Name
                                      }).ToList()
            };

            return ResultData<BeautyDiaryManageForDetailsVo>.Success().AddData("beautyDiaryManage", beautyDiary);
        }

        /// <summary>
        /// 点赞日记
        /// </summary>
        /// <param name="id">日记编号</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ResultData> GivingLikes(string id)
        {
            await _beautyDiaryManageService.GivingLikesAsync(id);
            return ResultData.Success();
        }
        /// <summary>
        /// 浏览日记（浏览量+1）
        /// </summary>
        /// <param name="id">日记编号</param>
        /// <returns></returns>
        [HttpPut("addViews/{id}")]
        public async Task<ResultData> AddViews(string id)
        {
            await _beautyDiaryManageService.AddViewsAsync(id);
            return ResultData.Success();
        }
    }
}
