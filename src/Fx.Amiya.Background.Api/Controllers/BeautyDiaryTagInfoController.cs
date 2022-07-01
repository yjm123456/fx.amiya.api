using Fx.Amiya.Background.Api.Vo.BeautyDiaryTagInfo;
using Fx.Amiya.Dto.BeautyDiaryTagInfo;
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
    /// 日记标签接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class BeautyDiaryTagInfoController : ControllerBase
    {
        private IBeautyDiaryTagInfoService _beautyDiaryBeautyDiaryTagInfoService;

        public BeautyDiaryTagInfoController(IBeautyDiaryTagInfoService beautyDiaryBeautyDiaryTagInfoService)
        {
            _beautyDiaryBeautyDiaryTagInfoService = beautyDiaryBeautyDiaryTagInfoService;
        }

        /// <summary>
        /// 获取所有标签列表(分页)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<BeautyDiaryTagInfoVo>>> GetListWithPageAsync(string name, int pageNum, int pageSize)
        {
            try
            {
                var q = await _beautyDiaryBeautyDiaryTagInfoService.GetListWithPageAsync( name, pageNum, pageSize);
                var tagInfo = from d in q.List
                              select new BeautyDiaryTagInfoVo
                              {
                                  Id = d.Id,
                                  Name = d.Name,
                                  Valid = d.Valid
                              };

                FxPageInfo<BeautyDiaryTagInfoVo> tagPageInfo = new FxPageInfo<BeautyDiaryTagInfoVo>();
                tagPageInfo.TotalCount = q.TotalCount;
                tagPageInfo.List = tagInfo;

                return ResultData<FxPageInfo<BeautyDiaryTagInfoVo>>.Success().AddData("tagInfo", tagPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<BeautyDiaryTagInfoVo>>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 获取可用的标签列表id和name
        /// </summary>
        /// <returns></returns>
        [HttpGet("nameList")]
        public async Task<ResultData<List<BeautyDiaryTagNameVo>>> GetNameListAsync()
        {
            try
            {
                var tagInfo = from d in await _beautyDiaryBeautyDiaryTagInfoService.GetNameListAsync()
                              select new BeautyDiaryTagNameVo
                              {
                                  Id = d.Id,
                                  Name = d.Name
                              };
                return ResultData<List<BeautyDiaryTagNameVo>>.Success().AddData("tagInfo", tagInfo.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<BeautyDiaryTagNameVo>>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 添加日记标签
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<ResultData> AddAsync(AddBeautyDiaryTagInfoVo addVo)
        {
            try
            {
                AddBeautyDiaryTagInfoDto addDto = new AddBeautyDiaryTagInfoDto();
                addDto.Name = addVo.Name;

                await _beautyDiaryBeautyDiaryTagInfoService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 根据标签编号获取标签信息
        /// </summary>
        /// <param name="id">标签编号</param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<BeautyDiaryTagInfoVo>> GetByIdAsync(string id)
        {
            try
            {
                var tagInfo = await _beautyDiaryBeautyDiaryTagInfoService.GetByIdAsync(id);
                BeautyDiaryTagInfoVo tagInfoVo = new BeautyDiaryTagInfoVo();
                tagInfoVo.Id = tagInfo.Id;
                tagInfoVo.Name = tagInfo.Name;
                tagInfoVo.Valid = tagInfo.Valid;

                return ResultData<BeautyDiaryTagInfoVo>.Success().AddData("tagInfo", tagInfoVo);
            }
            catch (Exception ex)
            {
                return ResultData<BeautyDiaryTagInfoVo>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 修改日记标签信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateBeautyDiaryTagInfoVo updateVo)
        {
            try
            {
                UpdateBeautyDiaryTagInfoDto updateDto = new UpdateBeautyDiaryTagInfoDto();
                updateDto.Id = updateVo.Id;
                updateDto.Name = updateVo.Name;
                updateDto.Valid = updateVo.Valid;

                await _beautyDiaryBeautyDiaryTagInfoService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 删除日记标签
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await _beautyDiaryBeautyDiaryTagInfoService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
    }
}
