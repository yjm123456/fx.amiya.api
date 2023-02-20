

using Fx.Amiya.BusinessWeChat.Api.Vo.ContentPlateFormOrder;
using Fx.Amiya.BusinessWeChat.Api.Vo.ContentPlatFormOrderSend;
using Fx.Amiya.BusinessWeChat.Api.Vo.OrderCheckPicture;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWechat.Api.Controllers
{
    /// <summary>
    /// 审核照片板块数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class OrderCheckPictureController : ControllerBase
    {
        private IOrderCheckPictureService orderCheckPictureService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="orderCheckPictureService"></param>
        public OrderCheckPictureController(IOrderCheckPictureService orderCheckPictureService)
        {
            this.orderCheckPictureService = orderCheckPictureService;
        }



        /// <summary>
        /// 获取审核照片信息列表（分页）
        /// </summary>
        /// <param name="OrderId">订单号</param>
        /// <param name="OrderFrom">订单来源【1：下单平台，2：内容平台，3：升单】</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<OrderCheckPictureVo>>> GetListWithPageAsync(string OrderId, int OrderFrom, int pageNum, int pageSize)
        {
            try
            {
                var q = await orderCheckPictureService.GetListWithPageAsync(OrderId, OrderFrom, pageNum, pageSize);

                var orderCheckPicture = from d in q.List
                                        select new OrderCheckPictureVo
                                        {
                                            Id = d.Id,
                                            OrderFrom = d.OrderFrom,
                                            OrderId = d.OrderId,
                                            PictureUrl = d.PictureUrl,
                                        };

                FxPageInfo<OrderCheckPictureVo> orderCheckPicturePageInfo = new FxPageInfo<OrderCheckPictureVo>();
                orderCheckPicturePageInfo.TotalCount = q.TotalCount;
                orderCheckPicturePageInfo.List = orderCheckPicture;

                return ResultData<FxPageInfo<OrderCheckPictureVo>>.Success().AddData("orderCheckPictureInfo", orderCheckPicturePageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<OrderCheckPictureVo>>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除审核照片信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await orderCheckPictureService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
