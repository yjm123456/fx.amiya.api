using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.ContentPlatFormOrderDealDetails.Input;
using Fx.Amiya.Background.Api.Vo.ContentPlatFormOrderDealDetails.Result;
using Fx.Amiya.Dto.ContentPlatFormOrderDealDetails;
using Fx.Amiya.Dto.ContentPlatFormOrderDealDetails.Input;
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
    /// 内容平台成交详情板块数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class ContentPlatFormOrderDealDetailsController : ControllerBase
    {
        private IContentPlatFormOrderDealDetailsService contentPlatFormOrderDealDetailsService;
        private IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="contentPlatFormOrderDealDetailsService"></param>
        public ContentPlatFormOrderDealDetailsController(IContentPlatFormOrderDealDetailsService contentPlatFormOrderDealDetailsService, IHttpContextAccessor httpContextAccessor)
        {
            this.contentPlatFormOrderDealDetailsService = contentPlatFormOrderDealDetailsService;
            _httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// 根据时间，成交情况编号，订单号获取内容平台成交详情列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<FxPageInfo<ContentPlatFormOrderDealDetailsVo>>> GetListWithPageAsync([FromQuery] QueryContentPlatFormOrderDealDetailsListVo query)
        {
            try
            {
                QueryContentPlatFormOrderDealDetailsDto queryCustomerAppointSchedulePageListDto = new QueryContentPlatFormOrderDealDetailsDto();
                queryCustomerAppointSchedulePageListDto.ContentPlatFormOrderDealId = query.ContentPlatFormOrderDealId;
                queryCustomerAppointSchedulePageListDto.ContentPlatFormOrderId = query.ContentPlatFormOrderId;
                queryCustomerAppointSchedulePageListDto.StartDate = query.StartDate;
                queryCustomerAppointSchedulePageListDto.EndDate = query.EndDate;
                var q = await contentPlatFormOrderDealDetailsService.GetListAsync(queryCustomerAppointSchedulePageListDto);

                var contentPlatFormOrderDealDetails = from d in q.List
                                                      select new ContentPlatFormOrderDealDetailsVo
                                                      {
                                                          Id = d.Id,
                                                          CreateBy = d.CreateBy,
                                                          CreateByEmpName = d.CreateByEmpName,
                                                          CreateDate = d.CreateDate,
                                                          UpdateDate = d.UpdateDate,
                                                          Valid = d.Valid,
                                                          DeleteDate = d.DeleteDate,
                                                          GoodsName = d.GoodsName,
                                                          GoodsSpec = d.GoodsSpec,
                                                          Quantity = d.Quantity,
                                                          Price = d.Price,
                                                          ContentPlatFormOrderDealId = d.ContentPlatFormOrderDealId,
                                                          ContentPlatFormOrderId = d.ContentPlatFormOrderId,
                                                      };

                FxPageInfo<ContentPlatFormOrderDealDetailsVo> result = new FxPageInfo<ContentPlatFormOrderDealDetailsVo>();
                result.TotalCount = q.TotalCount;
                result.List = contentPlatFormOrderDealDetails;

                return ResultData<FxPageInfo<ContentPlatFormOrderDealDetailsVo>>.Success().AddData("contentPlatFormOrderDealDetails", result);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<ContentPlatFormOrderDealDetailsVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [FxInternalAuthorize]
        [HttpGet("byId/{id}")]

        public async Task<ResultData<ContentPlatFormOrderDealDetailsVo>> GetByIdAsync(string id)
        {
            try
            {
                var contentPlatFormOrderDealInfoDetails = await contentPlatFormOrderDealDetailsService.GetByIdAsync(id);
                ContentPlatFormOrderDealDetailsVo contentPlatFormOrderDealInfoVo = new ContentPlatFormOrderDealDetailsVo();
                contentPlatFormOrderDealInfoVo.Id = contentPlatFormOrderDealInfoDetails.Id;
                contentPlatFormOrderDealInfoVo.Id = contentPlatFormOrderDealInfoDetails.Id;
                contentPlatFormOrderDealInfoVo.CreateBy = contentPlatFormOrderDealInfoDetails.CreateBy;
                contentPlatFormOrderDealInfoVo.CreateDate = contentPlatFormOrderDealInfoDetails.CreateDate;
                contentPlatFormOrderDealInfoVo.UpdateDate = contentPlatFormOrderDealInfoDetails.UpdateDate;
                contentPlatFormOrderDealInfoVo.Valid = contentPlatFormOrderDealInfoDetails.Valid;
                contentPlatFormOrderDealInfoVo.DeleteDate = contentPlatFormOrderDealInfoDetails.DeleteDate;
                contentPlatFormOrderDealInfoVo.GoodsName = contentPlatFormOrderDealInfoDetails.GoodsName;
                contentPlatFormOrderDealInfoVo.GoodsSpec = contentPlatFormOrderDealInfoDetails.GoodsSpec;
                contentPlatFormOrderDealInfoVo.Quantity = contentPlatFormOrderDealInfoDetails.Quantity;
                contentPlatFormOrderDealInfoVo.Price = contentPlatFormOrderDealInfoDetails.Price;

                return ResultData<ContentPlatFormOrderDealDetailsVo>.Success().AddData("contentPlatFormOrderDealDetailsInfo", contentPlatFormOrderDealInfoVo);
            }
            catch (Exception ex)
            {
                return ResultData<ContentPlatFormOrderDealDetailsVo>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 修改成交详情归属订单信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        [FxInternalAuthorize]
        public async Task<ResultData> UpdateDealDetailsBelongOrderAsync(UpdateDealDetailsBelongOrderVo updateVo)
        {
            try
            {
                var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                ConfirmContentPlatFormOrderDealDetailsDto updateDto = new ConfirmContentPlatFormOrderDealDetailsDto();
                updateDto.Id = updateVo.Id;
                updateDto.ContentPlatFormOrderId = updateVo.ContentPlatFormOrderId;
                updateDto.ContentPlatFormOrderDealId = updateVo.ContentPlatFormOrderDealId;
                updateDto.CreateBy = employeeId;
                await contentPlatFormOrderDealDetailsService.ConfirmOrderAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 作废成交详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                DeleteContentPlatFormOrderDealDetailsDto deleteContentPlatFormOrderDealDetailsDto = new DeleteContentPlatFormOrderDealDetailsDto();
                deleteContentPlatFormOrderDealDetailsDto.Id = id;
                deleteContentPlatFormOrderDealDetailsDto.CreateBy = employeeId;
                await contentPlatFormOrderDealDetailsService.DeleteAsync(deleteContentPlatFormOrderDealDetailsDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
    }
}
