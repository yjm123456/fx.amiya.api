using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.ContentPlateFormOrder;
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
    /// 客户照片板块数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalOrTenantAuthroize]
    public class ContentPlatFormCustomerPictureController : ControllerBase
    {
        private IContentPlatFormCustomerPictureService contentPlatFormCustomerPictureService;
        private IOrderService _orderService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="contentPlatFormCustomerPictureService"></param>
        public ContentPlatFormCustomerPictureController(IContentPlatFormCustomerPictureService contentPlatFormCustomerPictureService, IOrderService orderService)
        {
            this.contentPlatFormCustomerPictureService = contentPlatFormCustomerPictureService;
            _orderService = orderService;
        }


        /// <summary>
        /// 获取客户照片信息列表（分页）
        /// </summary>
        /// <param name="contentPlatFormOrderId">内容平台订单号</param>
        /// <param name="orderDealId">内容平台成交编号</param>
        /// <param name="description">描述（顾客照片/邀约凭证）</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<ContentPlatFormCustomerPictureVo>>> GetListWithPageAsync(string contentPlatFormOrderId,string orderDealId,string description, int pageNum, int pageSize)
        {
            try
            {
                var q = await contentPlatFormCustomerPictureService.GetListWithPageAsync(contentPlatFormOrderId,orderDealId,description, pageNum, pageSize);

                var contentPlatFormCustomerPicture = from d in q.List
                              select new ContentPlatFormCustomerPictureVo
                              {
                                  Id = d.Id,
                                  CustomerPicture = d.CustomerPicture,
                                  ContentPlatFormId = d.ContentPlatFormOrderId,
                              };

                FxPageInfo<ContentPlatFormCustomerPictureVo> contentPlatFormCustomerPicturePageInfo = new FxPageInfo<ContentPlatFormCustomerPictureVo>();
                contentPlatFormCustomerPicturePageInfo.TotalCount = q.TotalCount;
                contentPlatFormCustomerPicturePageInfo.List = contentPlatFormCustomerPicture;

                return ResultData<FxPageInfo<ContentPlatFormCustomerPictureVo>>.Success().AddData("contentPlatFormCustomerPictureInfo", contentPlatFormCustomerPicturePageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<ContentPlatFormCustomerPictureVo>>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除客户照片信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await contentPlatFormCustomerPictureService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



    }
}
