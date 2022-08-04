using Fx.Amiya.Dto.ContentPlateFormOrder;
using Fx.Amiya.Dto.ExpressManage;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IContentPlatFormCustomerPictureService
    {
        /// <summary>
        /// 根据内容平台订单编号获取客户图片(分页)
        /// </summary>
        /// <param name="contentPlatFormId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<ContentPlatFormOrderCustomerPictureDto>> GetListWithPageAsync(string contentPlatFormId, string orderDealId, string description, int pageNum, int pageSize);

        /// <summary>
        /// 根据内容平台订单编号获取客户图片
        /// </summary>
        /// <param name="contentPlatFormId"></param>
        /// <returns></returns>
        Task<List<ContentPlatFormOrderCustomerPictureDto>> GetListAsync(string contentPlatFormId);
        /// <summary>
        /// 新增客户图片
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddAsync(AddContentPlatFormCustomerPictureDto addDto);
        /// <summary>
        /// 根据id获取信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ContentPlatFormOrderCustomerPictureDto> GetByIdAsync(string id);
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(string id);
        /// <summary>
        /// 根据内容平台订单编号删除客户图片
        /// </summary>
        /// <param name="contentPlatFormOrderId"></param>
        /// <returns></returns>
        Task DeleteByContentPlatFormOrderIdAsync(string contentPlatFormOrderId);

        Task DeleteByContentPlatFormOrderDealIdAsync(string contentPlatFormOrderDealId);
    }
}
