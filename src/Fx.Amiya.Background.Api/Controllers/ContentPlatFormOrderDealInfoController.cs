using Fx.Amiya.Background.Api.Vo.ContentPlateFormOrder;
using Fx.Amiya.Dto.ContentPlatFormOrderSend;
using Fx.Amiya.Dto.WareHouse.WareHouseInfo;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Jd.Api.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 成交情况数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class ContentPlatFormOrderDealInfoController : ControllerBase
    {
        private IContentPlatFormOrderDealInfoService _contentPlatFormOrderDealInfoService;
        private IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="contentPlatFormOrderDealInfoService"></param>
        public ContentPlatFormOrderDealInfoController(IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService,

            IHttpContextAccessor httpContextAccessor)
        {
            _contentPlatFormOrderDealInfoService = contentPlatFormOrderDealInfoService;
            this.httpContextAccessor = httpContextAccessor;
        }





        /// <summary>
        /// 根据成交情况编号获取成交情况信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]

        public async Task<ResultData<ContentPlatFormOrderDealInfoVo>> GetByIdAsync(string id)
        {
            try
            {
                var contentPlatFormOrderDealInfo = await _contentPlatFormOrderDealInfoService.GetByIdAsync(id);
                ContentPlatFormOrderDealInfoVo contentPlatFormOrderDealInfoVo = new ContentPlatFormOrderDealInfoVo();
                contentPlatFormOrderDealInfoVo.Id = contentPlatFormOrderDealInfo.Id;
                contentPlatFormOrderDealInfoVo.ContentPlatFormOrderId = contentPlatFormOrderDealInfo.ContentPlatFormOrderId;
                contentPlatFormOrderDealInfoVo.CreateDate = contentPlatFormOrderDealInfo.CreateDate;
                contentPlatFormOrderDealInfoVo.IsOldCustomer = contentPlatFormOrderDealInfo.IsOldCustomer;
                contentPlatFormOrderDealInfoVo.IsAcompanying = contentPlatFormOrderDealInfo.IsAcompanying;
                contentPlatFormOrderDealInfoVo.CommissionRatio = contentPlatFormOrderDealInfo.CommissionRatio;
                contentPlatFormOrderDealInfoVo.IsToHospital = contentPlatFormOrderDealInfo.IsToHospital;
                contentPlatFormOrderDealInfoVo.ToHospitalType = contentPlatFormOrderDealInfo.ToHospitalType;
                contentPlatFormOrderDealInfoVo.TohospitalDate = contentPlatFormOrderDealInfo.ToHospitalDate;
                contentPlatFormOrderDealInfoVo.IsDeal = contentPlatFormOrderDealInfo.IsDeal;
                contentPlatFormOrderDealInfoVo.LastDealHospitalId = contentPlatFormOrderDealInfo.LastDealHospitalId;
                contentPlatFormOrderDealInfoVo.DealPicture = contentPlatFormOrderDealInfo.DealPicture;
                contentPlatFormOrderDealInfoVo.Remark = contentPlatFormOrderDealInfo.Remark;
                contentPlatFormOrderDealInfoVo.Price = contentPlatFormOrderDealInfo.Price;
                contentPlatFormOrderDealInfoVo.DealDate = contentPlatFormOrderDealInfo.DealDate;
                contentPlatFormOrderDealInfoVo.OtherOrderId = contentPlatFormOrderDealInfo.OtherAppOrderId;
                return ResultData<ContentPlatFormOrderDealInfoVo>.Success().AddData("contentPlatFormOrderDealInfoInfo", contentPlatFormOrderDealInfoVo);
            }
            catch (Exception ex)
            {
                return ResultData<ContentPlatFormOrderDealInfoVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改成交情况信息(暂停使用)
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("update")]

        public async Task<ResultData> UpdateAsync(UpdateContentPlatFormOrderDealInfoVo updateVo)
        {
            try
            {
                UpdateContentPlatFormOrderDealInfoDto updateDto = new UpdateContentPlatFormOrderDealInfoDto();
                updateDto.Id = updateVo.Id;
                updateDto.ContentPlatFormOrderId = updateVo.ContentPlatFormOrderId;
                updateDto.IsToHospital = updateVo.IsToHospital;
                updateDto.ToHospitalDate = updateVo.TohospitalDate;
                updateDto.IsDeal = updateVo.IsDeal;
                updateDto.LastDealHospitalId = updateVo.LastDealHospitalId;
                updateDto.DealPicture = updateVo.DealPicture;
                updateDto.ToHospitalType = updateVo.ToHospitalType;
                updateDto.Remark = updateVo.Remark;
                updateDto.Price = updateVo.Price;
                updateDto.DealDate = updateVo.DealDate;
                updateDto.OtherAppOrderId = updateVo.OtherAppOrderId;
                await _contentPlatFormOrderDealInfoService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }

    }
}
