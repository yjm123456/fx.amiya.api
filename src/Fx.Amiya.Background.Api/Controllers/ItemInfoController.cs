using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.ItemInfo;
using Fx.Amiya.Dto.ItemInfo;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Infrastructure;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.Background.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class ItemInfoController : ControllerBase
    {
        private IItemInfoService itemInfoService;
        private IHttpContextAccessor httpContextAccessor;
        public ItemInfoController(IItemInfoService itemInfoService, IHttpContextAccessor httpContextAccessor)
        {
            this.itemInfoService = itemInfoService;
            this.httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// 获取项目列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="brandId">品牌</param>
        /// <param name="categoryId">品类</param>
        /// <param name="itemDetailsId">品项</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="valid"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<ItemInfoVo>>> GetListWithPageAsync(string keyword, string brandId, string categoryId, string itemDetailsId, int pageNum, int pageSize, bool? valid)
        {
            try
            {
                var q = await itemInfoService.GetListWithPageAsync(keyword,brandId,categoryId,itemDetailsId, pageNum, pageSize, valid);
                var itemInfos = from d in q.List
                                select new ItemInfoVo
                                {
                                    Id = d.Id,
                                    OtherAppItemId = d.OtherAppItemId,
                                    Name = d.Name,
                                    HospitalDepartmentId = d.HospitalDepartmentId,
                                    DepartmentName = d.DepartmentName,
                                    AppType = d.AppType,
                                    AppTypeText = d.AppTypeText,
                                    BrandId = d.BrandId,
                                    BrandName = d.BrandName,
                                    CategoryName = d.CategoryName,
                                    CategoryId = d.CategoryId,
                                    ItemDetailsId = d.ItemDetailsId,
                                    ItemDetailsName = d.ItemDetailsName,
                                    ThumbPicUrl = d.ThumbPicUrl,
                                    Description = d.Description,
                                    Standard = d.Standard,
                                    Parts = d.Parts,
                                    SalePrice = d.SalePrice,
                                    LivePrice = d.LivePrice,
                                    IsLimitBuy = d.IsLimitBuy,
                                    LimitBuyQuantity = d.LimitBuyQuantity,
                                    Commitment = d.Commitment,
                                    Guarantee = d.Guarantee,
                                    AppointmentNotice = d.AppointmentNotice,
                                    CreateDate = d.CreateDate,
                                    CreateBy = d.CreateBy,
                                    CreateName = d.CreateName,
                                    UpdateBy = d.UpdateBy,
                                    UpdateDate = d.UpdateDate,
                                    UpdateName = d.UpdateName,
                                    Valid = d.Valid,
                                    Remark = d.Remark,

                                };

                FxPageInfo<ItemInfoVo> itemPageInfo = new FxPageInfo<ItemInfoVo>();
                itemPageInfo.TotalCount = q.TotalCount;
                itemPageInfo.List = itemInfos;

                return ResultData<FxPageInfo<ItemInfoVo>>.Success().AddData("itemInfo", itemPageInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        /// <summary>
        /// 获取简单有效的项目列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("simpleWithPage")]
        public async Task<ResultData<FxPageInfo<ItemInfoSimpleVo>>> GetSimpleListWithPageAsync(string keyword, int pageNum, int pageSize)
        {
            var q = await itemInfoService.GetSimpleListWithPageAsync(keyword, pageNum, pageSize);
            var item = from d in q.List
                       select new ItemInfoSimpleVo
                       {
                           Id = d.Id,
                           OtherAppItemId = d.OtherAppItemId,
                           Name = d.Name,
                           DepartmentName = d.DepartmentName,
                           ThumbPicUrl = d.ThumbPicUrl,
                           Description = d.Description,
                           Standard = d.Standard,
                           Parts = d.Parts,
                           SalePrice = d.SalePrice,
                           LivePrice = d.LivePrice,
                           IsLimitBuy = d.IsLimitBuy,
                           LimitBuyQuantity = d.LimitBuyQuantity,
                           Remark = d.Remark
                       };

            FxPageInfo<ItemInfoSimpleVo> itemPageInfo = new FxPageInfo<ItemInfoSimpleVo>();
            itemPageInfo.TotalCount = q.TotalCount;
            itemPageInfo.List = item;
            return ResultData<FxPageInfo<ItemInfoSimpleVo>>.Success().AddData("item", itemPageInfo);
        }




        /// <summary>
        /// 添加项目
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<ResultData> AddAsync(AddItemInfoVo addVo)
        {
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);

                AddItemInfoDto addDto = new AddItemInfoDto();
                addDto.OtherAppItemId = addVo.OtherAppItemId;
                addDto.Name = addVo.Name;
                addDto.HospitalDepartmentId = addVo.HospitalDepartmentId;
                addDto.ThumbPicUrl = addVo.ThumbPicUrl;
                addDto.Description = addVo.Description;
                addDto.Standard = addVo.Standard;
                addDto.Parts = addVo.Parts;
                addDto.CategoryId = addVo.CategoryId;
                addDto.BrandId = addVo.BrandId;
                addDto.ItemDetailsId = addVo.ItemDetailsId;
                addDto.AppType = addVo.AppType;
                addDto.SalePrice = addVo.SalePrice;
                addDto.LivePrice = addVo.LivePrice;
                addDto.IsLimitBuy = addVo.IsLimitBuy;
                addDto.LimitBuyQuantity = addVo.LimitBuyQuantity;
                addDto.Commitment = addVo.Commitment;
                addDto.Guarantee = addVo.Guarantee;
                addDto.AppointmentNotice = addVo.AppointmentNotice;
                addDto.Remark = addVo.Remark;

                await itemInfoService.AddAsync(addDto, employeeId);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据项目编号获取项目信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<ItemInfoVo>> GetByIdAsync(int id)
        {
            try
            {
                var itemInfo = await itemInfoService.GetByIdAsync(id);

                ItemInfoVo itemInfoVo = new ItemInfoVo();
                itemInfoVo.Id = itemInfo.Id;
                itemInfoVo.OtherAppItemId = itemInfo.OtherAppItemId;
                itemInfoVo.Name = itemInfo.Name;
                itemInfoVo.DepartmentName = itemInfo.DepartmentName;
                itemInfoVo.HospitalDepartmentId = itemInfo.HospitalDepartmentId;
                itemInfoVo.ThumbPicUrl = itemInfo.ThumbPicUrl;
                itemInfoVo.Description = itemInfo.Description;
                itemInfoVo.Standard = itemInfo.Standard;
                itemInfoVo.Parts = itemInfo.Parts;
                itemInfoVo.SalePrice = itemInfo.SalePrice;
                itemInfoVo.LivePrice = itemInfo.LivePrice;
                itemInfoVo.AppType = itemInfo.AppType;
                itemInfoVo.BrandId = itemInfo.BrandId;
                itemInfoVo.CategoryId = itemInfo.CategoryId;
                itemInfoVo.ItemDetailsId = itemInfo.ItemDetailsId;
                itemInfoVo.IsLimitBuy = itemInfo.IsLimitBuy;
                itemInfoVo.LimitBuyQuantity = itemInfo.LimitBuyQuantity;
                itemInfoVo.Commitment = itemInfo.Commitment;
                itemInfoVo.Guarantee = itemInfo.Guarantee;
                itemInfoVo.AppointmentNotice = itemInfo.AppointmentNotice;
                itemInfoVo.Valid = itemInfo.Valid;
                itemInfoVo.CreateBy = itemInfo.CreateBy;
                itemInfoVo.CreateName = itemInfo.CreateName;
                itemInfoVo.CreateDate = itemInfo.CreateDate;
                itemInfoVo.UpdateBy = itemInfo.UpdateBy;
                itemInfoVo.UpdateName = itemInfo.UpdateName;
                itemInfoVo.UpdateDate = itemInfo.UpdateDate;
                itemInfoVo.Remark = itemInfo.Remark;

                return ResultData<ItemInfoVo>.Success().AddData("itemInfo", itemInfoVo);
            }
            catch (Exception ex)
            {
                return ResultData<ItemInfoVo>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 修改项目信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateItemInfoVo updateVo)
        {
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);

                UpdateItemInfoDto updateDto = new UpdateItemInfoDto();
                updateDto.Id = updateVo.Id;
                updateDto.OtherAppItemId = updateVo.OtherAppItemId;
                updateDto.Name = updateVo.Name;
                updateDto.AppType = updateVo.AppType;
                updateDto.BrandId = updateVo.BrandId;
                updateDto.CategoryId = updateVo.CategoryId;
                updateDto.ItemDetailsId = updateVo.ItemDetailsId;
                updateDto.HospitalDepartmentId = updateVo.HospitalDepartmentId;
                updateDto.ThumbPicUrl = updateVo.ThumbPicUrl;
                updateDto.Description = updateVo.Description;
                updateDto.Standard = updateVo.Standard;
                updateDto.Parts = updateVo.Parts;
                updateDto.SalePrice = updateVo.SalePrice;
                updateDto.LivePrice = updateVo.LivePrice;
                updateDto.IsLimitBuy = updateVo.IsLimitBuy;
                updateDto.LimitBuyQuantity = updateVo.LimitBuyQuantity;
                updateDto.SalePrice = updateVo.SalePrice;
                updateDto.Commitment = updateVo.Commitment;
                updateDto.Guarantee = updateVo.Guarantee;
                updateDto.AppointmentNotice = updateVo.AppointmentNotice;
                updateDto.Valid = updateVo.Valid;
                updateDto.Remark = updateVo.Remark;

                await itemInfoService.UpdateAsync(updateDto, employeeId);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据项目编号删除项目信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(int id)
        {
            try
            {
                await itemInfoService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 获取所有项目名称列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("allNameListWithPage")]
        public async Task<ResultData<FxPageInfo<ItemNameVo>>> GetNameListWithPageAsync(string keyword, int pageNum, int pageSize)
        {
            var q = await itemInfoService.GetNameListWithPageAsync(keyword, pageNum, pageSize);
            var items = from d in q.List
                        select new ItemNameVo
                        {
                            Id = d.Id,
                            Name = d.Name
                        };
            FxPageInfo<ItemNameVo> itemPageInfo = new FxPageInfo<ItemNameVo>();
            itemPageInfo.TotalCount = q.TotalCount;
            itemPageInfo.List = items;
            return ResultData<FxPageInfo<ItemNameVo>>.Success().AddData("items", itemPageInfo);
        }


        /// <summary>
        /// 根据品牌品类id,品项id获取项目id和名称
        /// </summary>
        /// <param name="brandId">品牌id</param>
        /// <param name="categoryId">品类id</param>
        /// <param name="itemDetailsId">品项id</param>
        /// <returns></returns>
        [HttpGet("getItemNameByBrandIdAndCategoryId")]
        public async Task<ResultData<List<BaseIdAndNameVo>>> GetItemNameByBrandIdAndCategoryIdAsync(string brandId, string categoryId, string itemDetailsId)
        {
            var q = await itemInfoService.GetItemNameByBrandIdAndCategoryIdAsync(brandId, categoryId, itemDetailsId);
            var items = from d in q
                        select new BaseIdAndNameVo
                        {
                            Id = d.Key,
                            Name = d.Value
                        };
            return ResultData<List<BaseIdAndNameVo>>.Success().AddData("items", items.ToList());
        }
    }
}