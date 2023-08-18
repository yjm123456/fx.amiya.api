using Fx.Amiya.Background.Api.Vo.BeautyDiaryManage;
using Fx.Amiya.Dto.BeautyDiaryManage;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
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
    /// 日记管理接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class BeautyDiaryManageController : ControllerBase
    {
        private IBeautyDiaryManageService beautyDiaryManageService;
        public BeautyDiaryManageController(IBeautyDiaryManageService beautyDiaryManageService)
        {
            this.beautyDiaryManageService = beautyDiaryManageService;
        }

        /// <summary>
        /// 获取所有日记列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="isReleased"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<FxPageInfo<BeautyDiaryManageForListVo>>> GetListAsync(string keyword, bool? isReleased, int pageNum, int pageSize)
        {
            var q = await beautyDiaryManageService.GetListWithPageAsync(keyword, pageNum, pageSize, isReleased);

            var beautyDiaryManages = from d in q.List
                                     select new BeautyDiaryManageForListVo
                                     {
                                         Id = d.Id,
                                         CoverTitle = d.CoverTitle,
                                         DetailsTitle = d.DetailsTitle,
                                         ReleaseState = d.ReleaseState,
                                         CreateDate = d.CreateDate,
                                         Views = d.Views,
                                         GivingLikes = d.GivingLikes,
                                         ThumbPictureUrl = d.ThumbPictureUrl,
                                         VideoUrl = d.VideoUrl,
                                         DetailsDescription = d.DetailsDescription
                                     };
            FxPageInfo<BeautyDiaryManageForListVo> beautyDiaryPageInfo = new FxPageInfo<BeautyDiaryManageForListVo>();
            beautyDiaryPageInfo.TotalCount = q.TotalCount;
            beautyDiaryPageInfo.List = beautyDiaryManages;
            return ResultData<FxPageInfo<BeautyDiaryManageForListVo>>.Success().AddData("beautyDiaryManages", beautyDiaryPageInfo);
        }


        /// <summary>
        /// 获取微信公众号消息列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("wechatlist")]
        public async Task<ResultData<FxPageInfo<WechatDiaryListVo>>> GetWechatListAsync(string keyword,  int pageNum, int pageSize)
        {
            var q = await beautyDiaryManageService.GetListWithPageForWechatAsync(keyword, pageNum, pageSize);

            var beautyDiaryManages = from d in q.List
                                     select new WechatDiaryListVo
                                     {
                                         Id = d.Id,
                                         Title=d.Title,
                                         PicPath=d.PicPath
                                     };
            FxPageInfo<WechatDiaryListVo> beautyDiaryPageInfo = new FxPageInfo<WechatDiaryListVo>();
            beautyDiaryPageInfo.TotalCount = q.TotalCount;
            beautyDiaryPageInfo.List = beautyDiaryManages;
            return ResultData<FxPageInfo<WechatDiaryListVo>>.Success().AddData("beautyDiaryManages", beautyDiaryPageInfo);
        }



        /// <summary>
        /// 根据编号获取日记详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ResultData<BeautyDiaryManageForDetailsListVo>> GetByIdAsync(string id)
        {
            var beautyDiaryManage = await beautyDiaryManageService.GetDetailByIdAsync(id);

            BeautyDiaryManageForDetailsListVo goods = new BeautyDiaryManageForDetailsListVo()
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
                BeautyDiaryTagName= (from d in beautyDiaryManage.BeautyDiaryTagList
                                     select new BeautyDiaryTagNameVo
                                     {
                                         Id = d.Id,
                                         Name = d.Name
                                     }).ToList()
            };

            return ResultData<BeautyDiaryManageForDetailsListVo>.Success().AddData("beautyDiaryManage", goods);
        }



        /// <summary>
        /// 添加日记信息
        /// </summary>
        /// <param name="beautyDiaryManageAdd"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(BeautyDiaryManageAddVo beautyDiaryManageAdd)
        {

            AddBeautyDiaryManageDto beautyDiaryManage = new AddBeautyDiaryManageDto();
            beautyDiaryManage.CoverTitle = beautyDiaryManageAdd.CoverTitle;
            beautyDiaryManage.DetailsTitle = beautyDiaryManageAdd.DetailsTitle;
            beautyDiaryManage.ReleaseState = beautyDiaryManageAdd.ReleaseState;
            beautyDiaryManage.Views = beautyDiaryManageAdd.Views;
            beautyDiaryManage.GivingLikes = beautyDiaryManageAdd.GivingLikes;
            beautyDiaryManage.ThumbPictureUrl = beautyDiaryManageAdd.ThumbPictureUrl;
            beautyDiaryManage.VideoUrl = beautyDiaryManageAdd.VideoUrl;
            beautyDiaryManage.DetailsDescription = beautyDiaryManageAdd.DetailsDescription;
            beautyDiaryManage.BeautyDiaryBannerImage = (from d in beautyDiaryManageAdd.BannerImage
                                                        select new BeautyDiaryBannerImageDto
                                                        {
                                                            PicUrl = d.PicUrl,
                                                            DisplayIndex = d.DisplayIndex
                                                        }).ToList();
            beautyDiaryManage.TagIds = beautyDiaryManageAdd.TagIds;

            await beautyDiaryManageService.AddAsync(beautyDiaryManage);
            return ResultData.Success();
        }


        /// <summary>
        /// 修改日记信息
        /// </summary>
        /// <param name="beautyDiaryManageUpdate"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(BeautyDiaryManageUpdateVo beautyDiaryManageUpdate)
        {

            UpdateBeautyDiaryManageDto beautyDiaryManage = new UpdateBeautyDiaryManageDto();
            beautyDiaryManage.Id = beautyDiaryManageUpdate.Id;
            beautyDiaryManage.CoverTitle = beautyDiaryManageUpdate.CoverTitle;
            beautyDiaryManage.DetailsTitle = beautyDiaryManageUpdate.DetailsTitle;
            beautyDiaryManage.ReleaseState = beautyDiaryManageUpdate.ReleaseState;
            beautyDiaryManage.Views = beautyDiaryManageUpdate.Views;
            beautyDiaryManage.GivingLikes = beautyDiaryManageUpdate.GivingLikes;
            beautyDiaryManage.ThumbPictureUrl = beautyDiaryManageUpdate.ThumbPictureUrl;
            beautyDiaryManage.VideoUrl = beautyDiaryManageUpdate.VideoUrl;
            beautyDiaryManage.DetailsDescription = beautyDiaryManageUpdate.DetailsDescription;
            beautyDiaryManage.BeautyDiaryBannerImage = (from d in beautyDiaryManageUpdate.BannerImage
                                                        select new BeautyDiaryBannerImageDto
                                                        {
                                                            PicUrl = d.PicUrl,
                                                            DisplayIndex = d.DisplayIndex
                                                        }).ToList();
            beautyDiaryManage.TagIds = beautyDiaryManageUpdate.TagIds;
            await beautyDiaryManageService.UpdateAsync(beautyDiaryManage);
            return ResultData.Success();
        }

        /// <summary>
        /// 上传微信公众号消息封面
        /// </summary>
        /// <param name="beautyDiaryManageUpdate"></param>
        /// <returns></returns>
        [HttpPut("updateWechatDiary")]
        public async Task<ResultData> UpdateAsync(UpdateWechatDiaryVo beautyDiaryManageUpdate)
        {
            UpdateDiaryWechatDto beautyDiaryManage = new UpdateDiaryWechatDto();
            beautyDiaryManage.Id = beautyDiaryManageUpdate.Id;
            beautyDiaryManage.PicPath = beautyDiaryManageUpdate.PicPath;
            await beautyDiaryManageService.UpdateWechatDiaryAsync(beautyDiaryManage);
            return ResultData.Success();
        }


        /// <summary>
        /// 删除日记信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(string id)
        {
            await beautyDiaryManageService.DeleteAsync(id);
            return ResultData.Success();
        }



        /// <summary>
        /// 修改日记信息是否发布
        /// </summary>
        /// <param name="id">日记编号</param>
        /// <param name="releaseState">是否发布</param>
        /// <returns></returns>
        [HttpPut("UpdateReleaseState/{id}/{releaseState}")]
        public async Task<ResultData> UpdateReleaseStateAsync(string id, bool releaseState)
        {
            await beautyDiaryManageService.UpdateReleaseStateAsync(id, releaseState);
            return ResultData.Success();
        }

    }
}
