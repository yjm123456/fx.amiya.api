using Fx.Amiya.Dto.ContentPlateFormOrder;
using Fx.Amiya.Dto.ExpressManage;
using Fx.Amiya.Dto.OrderCheckPicture;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IOrderCheckPictureService
    {
        /// <summary>
        /// 根据订单编号获取审核图片(分页)
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<OrderCheckPictureDto>> GetListWithPageAsync(string orderId, int OrderFrom, int pageNum, int pageSize);

        /// <summary>
        /// 根据订单编号获取审核图片
        /// </summary>
        /// <param name="contentPlatFormId"></param>
        /// <returns></returns>
        Task<List<OrderCheckPictureDto>> GetListAsync(string contentPlatFormId);
        /// <summary>
        /// 新增审核图片
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddAsync(AddOrderCheckPictureDto addDto);
        /// <summary>
        /// 根据id获取信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OrderCheckPictureDto> GetByIdAsync(string id);
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(string id);
        /// <summary>
        /// 根据订单编号删除审核图片
        /// </summary>
        /// <param name="contentPlatFormOrderId"></param>
        /// <returns></returns>
        Task DeleteByOrderIdAsync(string contentPlatFormOrderId);
    }
}
