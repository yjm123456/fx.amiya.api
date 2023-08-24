using Fx.Amiya.Dto.ItemInfo;
using Fx.Amiya.IDal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Fx.Amiya.IService;
using Fx.Infrastructure;
using Fx.Amiya.DbModels.Model;
using Fx.Common;
using Fx.Amiya.Dto;

namespace Fx.Amiya.Service
{
    public class ItemInfoService : IItemInfoService
    {
        private IDalItemInfo dalItemInfo;
        private IDalCustomerInfo dalCustomerInfo;
        private IDalOrderInfo dalOrderInfo;
        private IAmiyaHospitalDepartmentService _hospitalDepartmentService;
        private ISupplierBrandService supplierBrandService;
        private ISupplierCategoryService supplierCategoryService;
        private ISupplierItemDetailsService supplierItemDetailsService;
        private IDalSupplierBrand dalSupplierBrand;
        private IDalSupplierCategory dalSupplierCategory;
        private IDalSupplierItemDetails dalSupplierItemDetails;
        public ItemInfoService(IDalItemInfo dalItemInfo,
            IDalCustomerInfo dalCustomerInfo,
            ISupplierBrandService supplierBrandService,
            ISupplierCategoryService supplierCategoryService,
            IAmiyaHospitalDepartmentService hospitalDepartmentService,
            ISupplierItemDetailsService supplierItemDetailsService,
            IDalOrderInfo dalOrderInfo, IDalSupplierBrand dalSupplierBrand, IDalSupplierCategory dalSupplierCategory, IDalSupplierItemDetails dalSupplierItemDetails)
        {
            this.dalItemInfo = dalItemInfo;
            this.dalCustomerInfo = dalCustomerInfo;
            this.dalOrderInfo = dalOrderInfo;
            this.supplierItemDetailsService = supplierItemDetailsService;
            this.supplierBrandService = supplierBrandService;
            this.supplierCategoryService = supplierCategoryService;
            _hospitalDepartmentService = hospitalDepartmentService;
            this.dalSupplierBrand = dalSupplierBrand;
            this.dalSupplierCategory = dalSupplierCategory;
            this.dalSupplierItemDetails = dalSupplierItemDetails;
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
        /// <returns></returns>
        public async Task<FxPageInfo<ItemInfoDto>> GetListWithPageAsync(string keyword, string brandId, string categoryId, string itemDetailsId, int pageNum, int pageSize, bool? valid)
        {
            try
            {
                var itemInfo = from d in dalItemInfo.GetAll()
                               .Include(e => e.CreateEmployee)
                               .Include(e => e.UpdateEmployee)
                               where (keyword == null || d.Name.Contains(keyword) || d.Description.Contains(keyword))
                               where (string.IsNullOrEmpty(brandId) || d.BrandId == brandId)
                               where (string.IsNullOrEmpty(categoryId) || d.CategoryId == categoryId)
                               where (string.IsNullOrEmpty(itemDetailsId) || d.ItemDetailsId == itemDetailsId)
                               && (valid == null || d.Valid == valid)
                               select new ItemInfoDto
                               {
                                   Id = d.Id,
                                   OtherAppItemId = d.OtherAppItemId,
                                   Name = d.Name,
                                   HospitalDepartmentId = d.HospitalDepartmentId,
                                   ThumbPicUrl = d.ThumbPicUrl,
                                   Description = d.Description,
                                   Standard = d.Standard,
                                   Parts = d.Parts,
                                   SalePrice = d.SalePrice,
                                   LivePrice = d.LivePrice,
                                   AppType = d.AppType,
                                   BrandId = d.BrandId,
                                   CategoryId = d.CategoryId,
                                   ItemDetailsId = d.ItemDetailsId,
                                   IsLimitBuy = d.IsLimitBuy,
                                   LimitBuyQuantity = d.LimitBuyQuantity,
                                   Commitment = d.Commitment,
                                   Guarantee = d.Guarantee,
                                   AppointmentNotice = d.AppointmentNotice,
                                   Valid = d.Valid,
                                   CreateBy = d.CreateBy,
                                   CreateName = d.CreateEmployee.Name,
                                   CreateDate = d.CreateDate,
                                   UpdateBy = d.UpdateBy,
                                   UpdateName = d.UpdateEmployee.Name,
                                   UpdateDate = d.UpdateDate
                               };

                FxPageInfo<ItemInfoDto> itemPageInfo = new FxPageInfo<ItemInfoDto>();
                itemPageInfo.TotalCount = await itemInfo.CountAsync();
                itemPageInfo.List = await itemInfo.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
                foreach (var x in itemPageInfo.List)
                {
                    if (!string.IsNullOrEmpty(x.HospitalDepartmentId))
                    {
                        var hospitalDepartment = await _hospitalDepartmentService.GetByIdAsync(x.HospitalDepartmentId);
                        if (hospitalDepartment != null)
                        {
                            x.DepartmentName = hospitalDepartment.DepartmentName;
                        }
                    }
                    if (!string.IsNullOrEmpty(x.BrandId))
                    {
                        var brandInfo = await supplierBrandService.GetByIdAsync(x.BrandId);
                        x.BrandName = brandInfo.BrandName;
                    }
                    if (!string.IsNullOrEmpty(x.CategoryId))
                    {
                        var categoryInfo = await supplierCategoryService.GetByIdAsync(x.CategoryId);
                        x.CategoryName = categoryInfo.CategoryName;
                    }
                    if (!string.IsNullOrEmpty(x.ItemDetailsId))
                    {
                        var itemDetailsInfo = await supplierItemDetailsService.GetByIdAsync(x.ItemDetailsId);
                        x.ItemDetailsName = itemDetailsInfo.ItemDetailsName;
                    }
                    if (!string.IsNullOrEmpty(x.AppType))
                    {
                        string appTypeResult = "";
                        List<string> appTypes = new List<string>(x.AppType.Split(","));
                        foreach (var z in appTypes)
                        {
                            appTypeResult += ServiceClass.GetAppTypeText(Convert.ToByte(z)) + " ";
                        }
                        x.AppTypeText = appTypeResult;
                    }
                }
                return itemPageInfo;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// 获取简单有效的项目列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<ItemInfoSimpleDto>> GetSimpleListWithPageAsync(string keyword, int pageNum, int pageSize)
        {
            var item = from d in dalItemInfo.GetAll()
                       where d.Valid && (keyword == null || d.Name.Contains(keyword) || d.Description.Contains(keyword) || d.Parts.Contains(keyword))
                       select new ItemInfoSimpleDto
                       {
                           Id = d.Id,
                           OtherAppItemId = d.OtherAppItemId,
                           Name = d.Name,
                           ThumbPicUrl = d.ThumbPicUrl,
                           Description = d.Description,
                           Standard = d.Standard,
                           HospitalDepartmentId = d.HospitalDepartmentId,
                           Parts = d.Parts,
                           SalePrice = d.SalePrice,
                           LivePrice = d.LivePrice == null ? d.SalePrice : d.LivePrice,
                           IsLimitBuy = d.IsLimitBuy,
                           LimitBuyQuantity = d.LimitBuyQuantity,
                           Remark = d.Remark
                       };

            FxPageInfo<ItemInfoSimpleDto> itemPageInfo = new FxPageInfo<ItemInfoSimpleDto>();
            itemPageInfo.TotalCount = await item.CountAsync();
            itemPageInfo.List = await item.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            foreach (var x in itemPageInfo.List)
            {
                if (!string.IsNullOrEmpty(x.HospitalDepartmentId))
                {
                    var hospitalDepartment = await _hospitalDepartmentService.GetByIdAsync(x.HospitalDepartmentId);
                    if (hospitalDepartment != null)
                    {
                        x.DepartmentName = hospitalDepartment.DepartmentName;
                    }
                }
            }
            return itemPageInfo;
        }


        /// <summary>
        /// 添加项目
        /// </summary>
        /// <param name="addDto"></param>
        /// <param name="amiyaEmployeeId"></param>
        /// <returns></returns>
        public async Task AddAsync(AddItemInfoDto addDto, int amiyaEmployeeId)
        {
            try
            {
                ItemInfo itemInfo = new ItemInfo();
                itemInfo.Name = addDto.Name;
                itemInfo.HospitalDepartmentId = addDto.HospitalDepartmentId;
                itemInfo.ThumbPicUrl = addDto.ThumbPicUrl;
                itemInfo.Description = addDto.Description;
                itemInfo.Standard = addDto.Standard;
                itemInfo.Parts = addDto.Parts;
                itemInfo.SalePrice = addDto.SalePrice;
                itemInfo.LivePrice = addDto.LivePrice;
                itemInfo.AppType = addDto.AppType;
                itemInfo.BrandId = addDto.BrandId;
                itemInfo.CategoryId = addDto.CategoryId;
                itemInfo.ItemDetailsId = addDto.ItemDetailsId;
                itemInfo.IsLimitBuy = addDto.IsLimitBuy;
                itemInfo.LimitBuyQuantity = addDto.LimitBuyQuantity;
                itemInfo.Commitment = addDto.Commitment;
                itemInfo.Guarantee = addDto.Guarantee;
                itemInfo.AppointmentNotice = addDto.AppointmentNotice;
                itemInfo.OtherAppItemId = addDto.OtherAppItemId;
                itemInfo.Valid = true;
                itemInfo.CreateBy = amiyaEmployeeId;
                itemInfo.CreateDate = DateTime.Now;
                itemInfo.Remark = addDto.Remark;

                await dalItemInfo.AddAsync(itemInfo, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }



        /// <summary>
        /// 根据项目编号获取项目信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ItemInfoDto> GetByIdAsync(int id)
        {
            try
            {
                var itemInfo = await dalItemInfo.GetAll()
                    .Include(e => e.CreateEmployee)
                    .Include(e => e.UpdateEmployee)
                    .SingleOrDefaultAsync(e => e.Id == id);
                if (itemInfo == null)
                    throw new Exception("项目编号错误");

                ItemInfoDto itemInfoDto = new ItemInfoDto();
                itemInfoDto.Id = itemInfo.Id;
                itemInfoDto.OtherAppItemId = itemInfo.OtherAppItemId;
                itemInfoDto.Name = itemInfo.Name;
                itemInfoDto.HospitalDepartmentId = itemInfo.HospitalDepartmentId;

                if (!string.IsNullOrEmpty(itemInfoDto.HospitalDepartmentId))
                {
                    var hospitalDepartment = await _hospitalDepartmentService.GetByIdAsync(itemInfoDto.HospitalDepartmentId);
                    if (hospitalDepartment != null)
                    {
                        itemInfoDto.DepartmentName = hospitalDepartment.DepartmentName;
                    }
                }
                itemInfoDto.ThumbPicUrl = itemInfo.ThumbPicUrl;
                itemInfoDto.Description = itemInfo.Description;
                itemInfoDto.Standard = itemInfo.Standard;
                itemInfoDto.Parts = itemInfo.Parts;
                itemInfoDto.SalePrice = itemInfo.SalePrice;
                itemInfoDto.LivePrice = itemInfo.LivePrice;
                itemInfoDto.BrandId = itemInfo.BrandId;
                itemInfoDto.AppType = itemInfo.AppType;
                itemInfoDto.CategoryId = itemInfo.CategoryId;
                itemInfoDto.ItemDetailsId = itemInfo.ItemDetailsId;
                itemInfoDto.IsLimitBuy = itemInfo.IsLimitBuy;
                itemInfoDto.LimitBuyQuantity = itemInfo.LimitBuyQuantity;
                itemInfoDto.Commitment = itemInfo.Commitment;
                itemInfoDto.Guarantee = itemInfo.Guarantee;
                itemInfoDto.AppointmentNotice = itemInfo.AppointmentNotice;
                itemInfoDto.Valid = itemInfo.Valid;
                itemInfoDto.CreateBy = itemInfo.CreateBy;
                itemInfoDto.CreateName = itemInfo.CreateEmployee.Name;
                itemInfoDto.CreateDate = itemInfo.CreateDate;
                itemInfoDto.UpdateBy = itemInfo.UpdateBy;
                itemInfoDto.UpdateName = itemInfo.UpdateEmployee?.Name;
                itemInfoDto.UpdateDate = itemInfo.UpdateDate;
                itemInfoDto.Remark = itemInfo.Remark;

                return itemInfoDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        /// <summary>
        /// 根据产品编号获取项目信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ItemInfoDto> GetByOtherAppItemIdAsync(string otherAppItemId)
        {
            try
            {
                var itemInfo = await dalItemInfo.GetAll()
                    .Include(e => e.CreateEmployee)
                    .Include(e => e.UpdateEmployee).Where(x => x.Valid == true)
                    .FirstOrDefaultAsync(e => e.OtherAppItemId == otherAppItemId);
                if (itemInfo == null)
                    return new ItemInfoDto();

                ItemInfoDto itemInfoDto = new ItemInfoDto();
                itemInfoDto.Id = itemInfo.Id;
                itemInfoDto.OtherAppItemId = itemInfo.OtherAppItemId;
                itemInfoDto.Name = itemInfo.Name;
                itemInfoDto.ThumbPicUrl = itemInfo.ThumbPicUrl;
                itemInfoDto.Description = itemInfo.Description;
                itemInfoDto.Standard = itemInfo.Standard;
                itemInfoDto.Parts = itemInfo.Parts;
                itemInfoDto.SalePrice = itemInfo.SalePrice;
                itemInfoDto.LivePrice = itemInfo.LivePrice;
                itemInfoDto.IsLimitBuy = itemInfo.IsLimitBuy;
                itemInfoDto.LimitBuyQuantity = itemInfo.LimitBuyQuantity;
                itemInfoDto.Commitment = itemInfo.Commitment;
                itemInfoDto.Guarantee = itemInfo.Guarantee;
                itemInfoDto.AppointmentNotice = itemInfo.AppointmentNotice;
                itemInfoDto.Valid = itemInfo.Valid;
                itemInfoDto.CreateBy = itemInfo.CreateBy;
                itemInfoDto.CreateName = itemInfo.CreateEmployee.Name;
                itemInfoDto.CreateDate = itemInfo.CreateDate;
                itemInfoDto.UpdateBy = itemInfo.UpdateBy;
                itemInfoDto.UpdateName = itemInfo.UpdateEmployee?.Name;
                itemInfoDto.UpdateDate = itemInfo.UpdateDate;
                itemInfoDto.Remark = itemInfo.Remark;

                return itemInfoDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }



        /// <summary>
        /// 修改项目信息
        /// </summary>
        /// <param name="updateDto"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateItemInfoDto updateDto, int employeeId)
        {
            try
            {
                var itemInfo = await dalItemInfo.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (itemInfo == null)
                    throw new Exception("项目编号错误");

                itemInfo.OtherAppItemId = updateDto.OtherAppItemId;
                itemInfo.Name = updateDto.Name;
                itemInfo.ThumbPicUrl = updateDto.ThumbPicUrl;
                itemInfo.HospitalDepartmentId = updateDto.HospitalDepartmentId;
                itemInfo.Description = updateDto.Description;
                itemInfo.Standard = updateDto.Standard;
                itemInfo.Parts = updateDto.Parts;
                itemInfo.AppType = updateDto.AppType;
                itemInfo.CategoryId = updateDto.CategoryId;
                itemInfo.ItemDetailsId = updateDto.ItemDetailsId;
                itemInfo.BrandId = updateDto.BrandId;
                itemInfo.SalePrice = updateDto.SalePrice;
                itemInfo.LivePrice = updateDto.LivePrice;
                itemInfo.IsLimitBuy = updateDto.IsLimitBuy;
                if (!updateDto.IsLimitBuy)
                {
                    itemInfo.LimitBuyQuantity = null;
                }
                else
                {
                    itemInfo.LimitBuyQuantity = updateDto.LimitBuyQuantity;
                }
                itemInfo.Commitment = updateDto.Commitment;
                itemInfo.Guarantee = updateDto.Guarantee;
                itemInfo.AppointmentNotice = updateDto.AppointmentNotice;
                itemInfo.Valid = updateDto.Valid;
                itemInfo.UpdateBy = employeeId;
                itemInfo.UpdateDate = DateTime.Now;
                itemInfo.Remark = updateDto.Remark;

                await dalItemInfo.UpdateAsync(itemInfo, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }



        /// <summary>
        /// 根据项目编号删除项目信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            try
            {
                var itemInfo = await dalItemInfo.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                itemInfo.Valid = false;
                await dalItemInfo.UpdateAsync(itemInfo, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }





        /// <summary>
        /// 获取简单项目列表（小程序）
        /// </summary>
        /// <returns></returns>
        public async Task<List<WxSimpleItemInfoDto>> GetSimpleListAsync(string keyword)
        {
            try
            {
                var item = from d in dalItemInfo.GetAll()
                           where d.Valid && (keyword == null || d.Name.ToUpper().Contains(keyword.ToUpper()))
                           select new WxSimpleItemInfoDto
                           {
                               Id = d.Id,
                               Name = d.Name,
                               ThumbPicUrl = d.ThumbPicUrl
                           };

                return await item.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        /// <summary>
        /// 客户获取已购买的项目列表（小程序）
        /// </summary>
        /// <returns></returns>
        public async Task<List<WxSimpleItemInfoDto>> GetListByCustomerAsync(string customerId)
        {
            try
            {
                var customer = await dalCustomerInfo.GetAll().SingleOrDefaultAsync(e => e.Id == customerId);

                var item = from d in dalOrderInfo.GetAll()
                           join t in dalItemInfo.GetAll() on d.GoodsId equals t.OtherAppItemId
                           where d.IsAppointment == false
                           && d.Phone == customer.Phone
                           && t.Valid
                           && d.SendOrderInfoList.Count(e => e.OrderId == d.Id) == 0
                           && (d.StatusCode == OrderStatusCode.WAIT_BUYER_CONFIRM_GOODS || d.StatusCode == OrderStatusCode.WAIT_SELLER_SEND_GOODS)
                           select new WxSimpleItemInfoDto
                           {
                               Id = t.Id,
                               Name = t.Name,
                               ThumbPicUrl = t.ThumbPicUrl
                           };


                return await item.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// 客户获取可核销项目数量（小程序）
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<List<WxSimpleOrderInfoDto>> GetCanWriteOffOrdersCount(string customerId)
        {
            try
            {
                var customer = await dalCustomerInfo.GetAll().SingleOrDefaultAsync(e => e.Id == customerId);

                var item = from d in dalOrderInfo.GetAll()
                           where d.Phone == customer.Phone
                           && (OrderType)d.OrderType.Value == OrderType.VirtualOrder
                           && (d.StatusCode == OrderStatusCode.WAIT_BUYER_CONFIRM_GOODS || d.StatusCode == OrderStatusCode.WAIT_SELLER_SEND_GOODS)
                           select new WxSimpleOrderInfoDto
                           {
                               OrderId = d.Id,
                               Name = d.GoodsName,
                               ThumbPicUrl = d.ThumbPicUrl
                           };


                return await item.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// 根据项目编号获取项目详情（小程序）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<WxItemInfoDto> GetDetailByIdAsync(int id)
        {
            try
            {
                var item = await dalItemInfo.GetAll()
                    .SingleOrDefaultAsync(e => e.Id == id);

                WxItemInfoDto wxItemInfoDto = new WxItemInfoDto();
                wxItemInfoDto.Id = item.Id;
                wxItemInfoDto.OtherAppItemId = item.OtherAppItemId;
                wxItemInfoDto.Name = item.Name;
                wxItemInfoDto.ThumbPicUrl = item.ThumbPicUrl;
                wxItemInfoDto.Description = item.Description;
                wxItemInfoDto.Standard = item.Standard;
                wxItemInfoDto.Parts = item.Parts;
                wxItemInfoDto.Commitment = item.Commitment;
                wxItemInfoDto.Guarantee = item.Guarantee;
                wxItemInfoDto.AppointmentNotice = item.AppointmentNotice;
                wxItemInfoDto.ItemDetailHtml = "";

                return wxItemInfoDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// 获取项目列表（小程序）
        /// </summary>
        /// <returns></returns>
        public async Task<List<WxItemInfoDto>> GetDetailListAsync()
        {
            try
            {
                var item = from d in dalItemInfo.GetAll()
                           where d.Valid
                           select new WxItemInfoDto
                           {
                               Id = d.Id,
                               OtherAppItemId = d.OtherAppItemId,
                               Name = d.Name,
                               ThumbPicUrl = d.ThumbPicUrl,
                               Description = d.Description,
                               Standard = d.Standard,
                               Parts = d.Parts,
                               Commitment = d.Commitment,
                               Guarantee = d.Guarantee,
                               AppointmentNotice = d.AppointmentNotice,
                               ItemDetailHtml = "",
                           };

                return await item.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }


        /// <summary>
        /// 获取项目名称列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<ItemNameDto>> GetNameListWithPageAsync(string keyword, int pageNum, int pageSize)
        {
            var items = from d in dalItemInfo.GetAll()
                        where (string.IsNullOrWhiteSpace(keyword) || d.Name.Contains(keyword) || d.Standard.Contains(keyword) || d.Description.Contains(keyword))
                        select new ItemNameDto
                        {
                            Id = d.Id,
                            Name = d.Name
                        };
            FxPageInfo<ItemNameDto> itemPageInfo = new FxPageInfo<ItemNameDto>();
            itemPageInfo.TotalCount = await items.CountAsync();
            itemPageInfo.List = await items.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return itemPageInfo;
        }

        /// <summary>
        /// 根据品牌品类id获取项目id和名称
        /// </summary>
        /// <param name="brandId">品牌id</param>
        /// <param name="categoryId">品类id</param>
        /// <param name="itemDetailsId">品项id</param>
        /// <returns></returns>
        /// <returns></returns>
        public async Task<List<BaseKeyValueDto>> GetItemNameByBrandIdAndCategoryIdAsync(string brandId, string itemDetailsId)
        {
            var items = from d in dalItemInfo.GetAll()
                        where (d.Valid == true)
                        where (string.IsNullOrEmpty(brandId) || d.BrandId == brandId)
                        where (string.IsNullOrEmpty(itemDetailsId) || d.ItemDetailsId == itemDetailsId)
                        select new BaseKeyValueDto
                        {
                            Key = d.Id.ToString(),
                            Value = d.Name
                        };
            return await items.ToListAsync();
        }
        /// <summary>
        /// 获取有效带货商品的品牌类别,品项信息
        /// </summary>
        /// <returns></returns>
        public async Task<List<GoodsItemInfoDto>> GetValidItemInfoAsync()
        {
            var data = from goods in dalItemInfo.GetAll()
                       where goods.Valid == true
                       from brand in dalSupplierBrand.GetAll()
                       where goods.BrandId == brand.Id
                       from category in dalSupplierCategory.GetAll()
                       where goods.CategoryId == category.Id
                       from itemDetail in dalSupplierItemDetails.GetAll()
                       where goods.ItemDetailsId == itemDetail.Id
                       select new GoodsItemInfoDto
                       {
                           Category = category.CategoryName,
                           CategoryId = category.Id,
                           Brand = brand.BrandName,
                           BrandId = brand.Id,
                           ItemDetail = itemDetail.ItemDetailsName,
                           ItemDetailId = itemDetail.Id,
                           GoodsId = goods.Id,
                           GoodsName = goods.Name
                       };
            return await data.ToListAsync();
        }
    }
}
