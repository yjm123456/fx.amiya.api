using Fx.Amiya.Dto;
using Fx.Amiya.Dto.Gift;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IGiftService
    {
        /// <summary>
        /// 获取礼品列表
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="categoryId">类别id</param>
        /// <returns></returns>
        Task<FxPageInfo<GiftInfoDto>> GetListWithPageAsync(string name, int pageNum, int pageSize, string categoryId);


        /// <summary>
        /// 添加礼品
        /// </summary>
        /// <param name="addDto"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task AddAsync(AddGiftInfoDto addDto, int employeeId);



        /// <summary>
        /// 根据编号获取礼品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GiftInfoDto> GetByIdAsync(int id);


        /// <summary>
        /// 修改礼品信息
        /// </summary>
        /// <param name="updateDto"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task UpdateAsync(UpdateGiftInfoDto updateDto, int employeeId);


        /// <summary>
        /// 删除礼品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeletaAsync(int id);




        /// <summary>
        /// 获取领取礼品列表
        /// </summary>
        /// <param name="isSendGoods"></param>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<ReceiveGiftDto>> GetReceiveGiftListAsync(DateTime? startDaste, DateTime? endDate, int employeeId,bool? isSendGoods, string keyword, int pageNum, int pageSize,string categoryId);
        /// <summary>
        /// 导出领取礼品列表
        /// </summary>
        /// <param name="startDaste"></param>
        /// <param name="endDate"></param>
        /// <param name="isSendGoods"></param>
        /// <param name="employeeId"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        Task<List<ReceiveGiftDto>> ExportReceiveGiftListAsync(DateTime? startDaste, DateTime? endDate, bool? isSendGoods, int employeeId, string keyword,string categoryId);

        /// <summary>
        /// 根据手机号加密文本获取领取礼品列表
        /// </summary>
        /// <param name="encryptPhone"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
       Task<FxPageInfo<ReceiveGiftSimpleDto>> GetReceiveGiftListByEncryptPhoneAsync(string encryptPhone, int pageNum, int pageSize);



        /// <summary>
        /// 发货礼品
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task SendGoodsAsync(SendGoodsDto sendGoodsDto, int employeeId);




        /// <summary>
        /// 小程序获取礼品列表
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<GiftInfoSimpleDto>> GetSimpleListOfWxAsync(string name, int pageNum, int pageSize,string categoryId);

        /// <summary>
        /// 获取可领取礼品数量
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<int> GetCanReceiveQuantityOfWxAsync(string customerId);


        /// <summary>
        /// 添加领取礼品
        /// </summary>
        /// <param name="addDto"></param>
        /// <param name="customerId"></param>
        /// <returns></returns>
         Task AddReceiveGiftAsync(AddReceiveGiftDto addDto, string customerId);

        /// <summary>
        /// 修改收货地址
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateAddressAsync(UpdateAddressDto updateDto);


        /// <summary>
        /// 根据客户编号获取已领取的礼品
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<ReceiveGiftWrapperOfWxDto>> GetReceiveGiftListByCustomerIdAsync(string customerId, int pageNum, int pageSize,string categoryId);
        /// <summary>
        /// 根据礼品类别获取礼品名称列表
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<List<BaseIdAndNameDto>> GetGiftNameListByCategoryId(string categoryId);
        /// <summary>
        /// 手动发放礼品
        /// </summary>
        /// <param name="addDto"></param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task SendReceiveGiftAsync(SendReceiveGiftDto addDto, string customerId);
    }
}
