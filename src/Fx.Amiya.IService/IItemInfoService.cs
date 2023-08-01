using Fx.Amiya.Dto;
using Fx.Amiya.Dto.ItemInfo;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IItemInfoService
    {

        /// <summary>
        /// 获取项目列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="brandId">品牌</param>
        /// <param name="categoryId">品类</param>
        /// <param name="itemDetailsId">品项</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<ItemInfoDto>> GetListWithPageAsync(string keyword, string brandId, string categoryId, string itemDetailsId, int pageNum, int pageSize,bool? valid);




        /// <summary>
        /// 获取简单有效的项目列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
       Task<FxPageInfo<ItemInfoSimpleDto>> GetSimpleListWithPageAsync(string keyword, int pageNum, int pageSize);


        /// <summary>
        /// 添加项目
        /// </summary>
        /// <param name="addDto"></param>
        /// <param name="amiyaEmployeeId"></param>
        /// <returns></returns>
       Task AddAsync(AddItemInfoDto addDto, int amiyaEmployeeId);



        /// <summary>
        /// 根据项目编号获取项目信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         Task<ItemInfoDto> GetByIdAsync(int id);

        /// <summary>
        /// 根据产品编号获取项目信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ItemInfoDto> GetByOtherAppItemIdAsync(string otherAppItemId);

        /// <summary>
        /// 修改项目信息
        /// </summary>
        /// <param name="updateDto"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task UpdateAsync(UpdateItemInfoDto updateDto, int employeeId);


        /// <summary>
        /// 根据项目编号删除项目信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       Task DeleteAsync(int id);




        /// <summary>
        /// 获取项目列表（小程序）
        /// </summary>
        /// <returns></returns>
        Task<List<WxSimpleItemInfoDto>> GetSimpleListAsync(string keyword);

        /// <summary>
        /// 客户获取已购买的项目列表（小程序）
        /// </summary>
        /// <returns></returns>
        Task<List<WxSimpleItemInfoDto>> GetListByCustomerAsync(string customerId);

        /// <summary>
        /// 客户获取可核销项目数量（小程序）
        /// </summary>
        /// <returns></returns>
        Task<List<WxSimpleOrderInfoDto>> GetCanWriteOffOrdersCount(string customerId);

        /// <summary>
        /// 根据项目编号获取项目详情（小程序）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<WxItemInfoDto> GetDetailByIdAsync(int id);

        /// <summary>
        /// 获取项目列表（小程序）
        /// </summary>
        /// <returns></returns>
        Task<List<WxItemInfoDto>> GetDetailListAsync();


        /// <summary>
        /// 获取项目名称列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<ItemNameDto>> GetNameListWithPageAsync(string keyword, int pageNum, int pageSize);

        /// <summary>
        /// 根据品牌品类id获取项目id和名称
        /// </summary>
        /// <param name="brandId">品牌id</param>
        /// <param name="categoryId">品类id</param>
        /// <param name="itemDetailsId">品项id</param>
        /// <returns></returns>
        Task<List<BaseKeyValueDto>> GetItemNameByBrandIdAndCategoryIdAsync(string brandId, string categoryId, string itemDetailsId);
    }
}
