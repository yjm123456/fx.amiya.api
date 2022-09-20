using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo.ShootingAndClip;
using Fx.Amiya.Dto.ShootingAndClip;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Infrastructure;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 拍剪组数据 API
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalOrTenantAuthroize]
    public class ShootingAndClipController : ControllerBase
    {
        private IShootingAndClipService shootingAndClipService;

        public ShootingAndClipController(IShootingAndClipService shootingAndClipService)
        {
            this.shootingAndClipService = shootingAndClipService;
        }


        /// <summary>
        /// 获取拍剪组数据信息列表（分页）
        /// </summary>
        /// <param name="shootingEmpId">拍摄人员id</param>
        /// <param name="clipEmpId">剪辑人员id</param>
        /// <param name="liveAnchorId">主播id</param>
        /// <param name="keyWord">标题关键词</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<ShootingAndClipVo>>> GetListWithPageAsync(int? shootingEmpId, int? clipEmpId, int? liveAnchorId, string keyWord, int pageNum, int pageSize)
        {
            try
            {
                var q = await shootingAndClipService.GetListWithPageAsync(shootingEmpId, clipEmpId, liveAnchorId, keyWord, pageNum, pageSize);

                var shootingAndClip = from d in q.List
                                      select new ShootingAndClipVo
                                      {
                                          Id = d.Id,
                                          ShootingEmpId = d.ShootingEmpId,
                                          ClipEmpId = d.ClipEmpId,
                                          Title = d.Title,
                                          LiveAnchorId = d.LiveAnchorId,
                                          ShootingEmpName = d.ShootingEmpName,
                                          ClipEmpName = d.ClipEmpName,
                                          LiveAnchorName = d.LiveAnchorName,
                                          CreateDate = d.CreateDate,
                                          RecordDate = d.RecordDate,
                                      };

                FxPageInfo<ShootingAndClipVo> shootingAndClipPageInfo = new FxPageInfo<ShootingAndClipVo>();
                shootingAndClipPageInfo.TotalCount = q.TotalCount;
                shootingAndClipPageInfo.List = shootingAndClip;

                return ResultData<FxPageInfo<ShootingAndClipVo>>.Success().AddData("shootingAndClipInfo", shootingAndClipPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<ShootingAndClipVo>>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 添加拍剪组数据信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddShootingAndClipVo addVo)
        {
            try
            {
                AddShootingAndClipDto addDto = new AddShootingAndClipDto();
                addDto.ShootingEmpId = addVo.ShootingEmpId;
                addDto.ClipEmpId = addVo.ClipEmpId;
                addDto.LiveAnchorId = addVo.LiveAnchorId;
                addDto.Title = addVo.Title;
                addDto.RecordDate = addVo.RecordDate;
                await shootingAndClipService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据拍剪组数据编号获取拍剪组数据信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<ShootingAndClipVo>> GetByIdAsync(string id)
        {
            try
            {
                var shootingAndClip = await shootingAndClipService.GetByIdAsync(id);
                ShootingAndClipVo shootingAndClipVo = new ShootingAndClipVo();
                shootingAndClipVo.Id = shootingAndClip.Id;
                shootingAndClipVo.ShootingEmpId = shootingAndClip.ShootingEmpId;
                shootingAndClipVo.ClipEmpId = shootingAndClip.ClipEmpId;
                shootingAndClipVo.Title = shootingAndClip.Title;
                shootingAndClipVo.LiveAnchorId = shootingAndClip.LiveAnchorId;
                shootingAndClipVo.CreateDate = shootingAndClip.CreateDate;
                shootingAndClipVo.RecordDate = shootingAndClip.RecordDate;

                return ResultData<ShootingAndClipVo>.Success().AddData("shootingAndClipInfo", shootingAndClipVo);
            }
            catch (Exception ex)
            {
                return ResultData<ShootingAndClipVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改拍剪组数据信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateShootingAndClipVo updateVo)
        {
            try
            {
                UpdateShootingAndClipDto updateDto = new UpdateShootingAndClipDto();
                updateDto.Id = updateVo.Id;
                updateDto.ShootingEmpId = updateVo.ShootingEmpId;
                updateDto.ClipEmpId = updateVo.ClipEmpId;
                updateDto.LiveAnchorId = updateVo.LiveAnchorId;
                updateDto.Title = updateVo.Title;
                updateDto.RecordDate = updateVo.RecordDate;
                await shootingAndClipService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除拍剪组数据信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await shootingAndClipService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}