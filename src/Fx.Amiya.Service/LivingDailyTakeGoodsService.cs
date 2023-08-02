﻿using Fx.Amiya.DbModels.Model;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.LivingDailyTakeGoods.Input;
using Fx.Amiya.Dto.LivingDailyTakeGoods.OutPut;
using Fx.Amiya.Dto.TakeGoods;

namespace Fx.Amiya.Service
{
    public class LivingDailyTakeGoodsService : ILivingDailyTakeGoodsService
    {
        private IDalLivingDailyTakeGoods dalLivingDailyTakeGoodsService;
        private ILiveAnchorService liveAnchorService;

        public LivingDailyTakeGoodsService(IDalLivingDailyTakeGoods dalLivingDailyTakeGoodsService, ILiveAnchorService liveAnchorService)
        {
            this.dalLivingDailyTakeGoodsService = dalLivingDailyTakeGoodsService;
            this.liveAnchorService = liveAnchorService;
        }



        public async Task<FxPageInfo<LivingDailyTakeGoodsDto>> GetListWithPageAsync(QueryLivingDailyTakeGoodsDto query)
        {
            try
            {
                var livingDailyTakeGoodsService = from d in dalLivingDailyTakeGoodsService.GetAll().Include(x => x.AmiyaEmployee).Include(x => x.SupplierBrand).Include(x => x.SupplierCategory).Include(x => x.Contentplatform).Include(x => x.LiveAnchor).Include(x => x.ItemInfo).Include(x=>x.SupplierItemDetails)
                                                  where (query.KeyWord == null || d.Remark.Contains(query.KeyWord))
                                                           && (string.IsNullOrEmpty(query.BrandId) || d.BrandId == query.BrandId)
                                                           && (string.IsNullOrEmpty(query.CategoryId) || d.CategoryId == query.CategoryId)
                                                           && (string.IsNullOrEmpty(query.ItemDetailsId) || d.ItemDetailsId == query.ItemDetailsId)
                                                           && (!query.StartDate.HasValue || d.TakeGoodsDate.Value >= query.StartDate.Value)
                                                           && (!query.EndDate.HasValue || d.TakeGoodsDate < query.EndDate.Value.AddDays(1).AddMinutes(-1))
                                                           && (!query.CreateBy.HasValue || d.CreatBy == query.CreateBy)
                                                           && (!query.Valid.HasValue || d.Valid == query.Valid)
                                                  select new LivingDailyTakeGoodsDto
                                                  {
                                                      Id = d.Id,
                                                      CreateDate = d.CreateDate,
                                                      CreatBy = d.CreatBy,
                                                      CreateByEmpName = d.AmiyaEmployee.Name,
                                                      UpdateDate = d.UpdateDate,
                                                      Valid = d.Valid,
                                                      DeleteDate = d.DeleteDate,
                                                      TakeGoodsDate=d.TakeGoodsDate,
                                                      BrandName = d.SupplierBrand.BrandName,
                                                      CategoryName = d.SupplierCategory.CategoryName,
                                                      ItemDetailsName=d.SupplierItemDetails.ItemDetailsName,
                                                      ContentPlatFormName = d.Contentplatform.ContentPlatformName,
                                                      LiveAnchorName = d.LiveAnchor.Name,
                                                      ItemName = d.ItemInfo.Name,
                                                      SinglePrice = d.SinglePrice,
                                                      TakeGoodsQuantity = d.TakeGoodsQuantity,
                                                      TotalPrice = d.TotalPrice,
                                                      TakeGoodsTypeText = ServiceClass.GerTakeGoodsTypeText(d.TakeGoodsType),
                                                      Remark = d.Remark,
                                                  };
                FxPageInfo<LivingDailyTakeGoodsDto> livingDailyTakeGoodsServicePageInfo = new FxPageInfo<LivingDailyTakeGoodsDto>();
                livingDailyTakeGoodsServicePageInfo.TotalCount = await livingDailyTakeGoodsService.CountAsync();
                livingDailyTakeGoodsServicePageInfo.List = await livingDailyTakeGoodsService.OrderByDescending(x => x.CreateDate).Skip((query.PageNum.Value - 1) * query.PageSize.Value).Take(query.PageSize.Value).ToListAsync();
                return livingDailyTakeGoodsServicePageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task AddAsync(LivingDailyTakeGoodsAddDto addDto)
        {
            try
            {
                LivingDailyTakeGoods livingDailyTakeGoodsService = new LivingDailyTakeGoods();
                livingDailyTakeGoodsService.Id = Guid.NewGuid().ToString();
                livingDailyTakeGoodsService.CreatBy = addDto.CreatBy;
                livingDailyTakeGoodsService.TakeGoodsDate = addDto.TakeGoodsDate;
                livingDailyTakeGoodsService.BrandId = addDto.BrandId;
                livingDailyTakeGoodsService.CategoryId = addDto.CategoryId;
                livingDailyTakeGoodsService.ItemDetailsId = addDto.ItemDetailsId;
                livingDailyTakeGoodsService.ContentPlatFormId = addDto.ContentPlatFormId;
                livingDailyTakeGoodsService.LiveAnchorId = addDto.LiveAnchorId;
                livingDailyTakeGoodsService.ItemId = addDto.ItemId;
                livingDailyTakeGoodsService.SinglePrice = addDto.SinglePrice;
                livingDailyTakeGoodsService.TakeGoodsQuantity = addDto.TakeGoodsQuantity;
                livingDailyTakeGoodsService.TotalPrice = addDto.TotalPrice;
                livingDailyTakeGoodsService.TakeGoodsType = addDto.TakeGoodsType;
                livingDailyTakeGoodsService.Remark = addDto.Remark;

                livingDailyTakeGoodsService.CreateDate = DateTime.Now;
                livingDailyTakeGoodsService.Valid = true;

                await dalLivingDailyTakeGoodsService.AddAsync(livingDailyTakeGoodsService, true);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<LivingDailyTakeGoodsDto> GetByIdAsync(string id)
        {
            try
            {
                var livingDailyTakeGoodsService = await dalLivingDailyTakeGoodsService.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (livingDailyTakeGoodsService == null)
                {
                    return new LivingDailyTakeGoodsDto();
                }

                LivingDailyTakeGoodsDto livingDailyTakeGoodsServiceDto = new LivingDailyTakeGoodsDto();
                livingDailyTakeGoodsServiceDto.Id = livingDailyTakeGoodsService.Id;
                livingDailyTakeGoodsServiceDto.CreatBy = livingDailyTakeGoodsService.CreatBy;
                livingDailyTakeGoodsServiceDto.TakeGoodsDate = livingDailyTakeGoodsService.TakeGoodsDate;
                livingDailyTakeGoodsServiceDto.BrandId = livingDailyTakeGoodsService.BrandId;
                livingDailyTakeGoodsServiceDto.CategoryId = livingDailyTakeGoodsService.CategoryId;
                livingDailyTakeGoodsServiceDto.ItemDetailsId = livingDailyTakeGoodsService.ItemDetailsId;
                livingDailyTakeGoodsServiceDto.ContentPlatFormId = livingDailyTakeGoodsService.ContentPlatFormId;
                livingDailyTakeGoodsServiceDto.LiveAnchorId = livingDailyTakeGoodsService.LiveAnchorId;
                livingDailyTakeGoodsServiceDto.ItemId = livingDailyTakeGoodsService.ItemId;
                livingDailyTakeGoodsServiceDto.SinglePrice = livingDailyTakeGoodsService.SinglePrice;
                livingDailyTakeGoodsServiceDto.TakeGoodsQuantity = livingDailyTakeGoodsService.TakeGoodsQuantity;
                livingDailyTakeGoodsServiceDto.TotalPrice = livingDailyTakeGoodsService.TotalPrice;
                livingDailyTakeGoodsServiceDto.TakeGoodsType = livingDailyTakeGoodsService.TakeGoodsType;
                livingDailyTakeGoodsServiceDto.Remark = livingDailyTakeGoodsService.Remark;

                livingDailyTakeGoodsServiceDto.CreateDate = livingDailyTakeGoodsService.CreateDate;
                livingDailyTakeGoodsServiceDto.Valid = livingDailyTakeGoodsService.Valid;
                return livingDailyTakeGoodsServiceDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task UpdateAsync(LivingDailyTakeGoodsUpdateDto updateDto)
        {
            try
            {
                var livingDailyTakeGoodsService = await dalLivingDailyTakeGoodsService.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (livingDailyTakeGoodsService == null)
                    throw new Exception("带货商品编号错误！");

                livingDailyTakeGoodsService.BrandId = updateDto.BrandId;
                livingDailyTakeGoodsService.CategoryId = updateDto.CategoryId;
                livingDailyTakeGoodsService.ItemDetailsId = updateDto.ItemDetailsId;
                livingDailyTakeGoodsService.TakeGoodsDate = updateDto.TakeGoodsDate;
                livingDailyTakeGoodsService.ContentPlatFormId = updateDto.ContentPlatFormId;
                livingDailyTakeGoodsService.LiveAnchorId = updateDto.LiveAnchorId;
                livingDailyTakeGoodsService.ItemId = updateDto.ItemId;
                livingDailyTakeGoodsService.SinglePrice = updateDto.SinglePrice;
                livingDailyTakeGoodsService.TakeGoodsQuantity = updateDto.TakeGoodsQuantity;
                livingDailyTakeGoodsService.TotalPrice = updateDto.TotalPrice;
                livingDailyTakeGoodsService.TakeGoodsType = updateDto.TakeGoodsType;
                livingDailyTakeGoodsService.Remark = updateDto.Remark;

                livingDailyTakeGoodsService.UpdateDate = DateTime.Now;

                await dalLivingDailyTakeGoodsService.UpdateAsync(livingDailyTakeGoodsService, true);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task DeleteAsync(string id)
        {
            try
            {
                var livingDailyTakeGoodsService = await dalLivingDailyTakeGoodsService.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (livingDailyTakeGoodsService == null)
                    throw new Exception("带货商品编号错误");
                livingDailyTakeGoodsService.Valid = false;
                livingDailyTakeGoodsService.DeleteDate = DateTime.Now;

                await dalLivingDailyTakeGoodsService.UpdateAsync(livingDailyTakeGoodsService, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// 获取带货商品类型下拉框
        /// </summary>
        /// <returns></returns>

        public async Task<List<BaseKeyValueDto>> GetTakeGoodsTypeAsync()
        {
            var orderTypes = Enum.GetValues(typeof(TakeGoodsType));
            List<BaseKeyValueDto> orderTypeList = new List<BaseKeyValueDto>();
            foreach (var item in orderTypes)
            {
                BaseKeyValueDto keyValue = new BaseKeyValueDto();
                keyValue.Key = Convert.ToString(item);
                keyValue.Value = ServiceClass.GerTakeGoodsTypeText(Convert.ToByte(item));
                orderTypeList.Add(keyValue);
            }
            return orderTypeList;

        }
        /// <summary>
        /// 获取带货业绩数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="contentPlatformId"></param>
        /// <param name="baseLiveAnchorId"></param>
        /// <returns></returns>
        public async Task<List<TakeGoodsDataDto>> GetTakeGoodsDataAsync(DateTime startDate, DateTime endDate, string contentPlatformId, List<int> liveAnchorIds)
        {
            
            var data= dalLivingDailyTakeGoodsService.GetAll().Where(e => e.TakeGoodsDate >= startDate && e.TakeGoodsDate <= endDate&&e.Valid==true);
            if (!string.IsNullOrEmpty(contentPlatformId)) {
                data = data.Where(e => e.ContentPlatFormId == contentPlatformId);
                if (liveAnchorIds.Count>0) {
                    data = data.Where(e => liveAnchorIds.Contains(e.LiveAnchorId));
                }
            }
            return await data.Select(e=>new TakeGoodsDataDto { 
                GMV=e.TotalPrice,
                Count=e.TakeGoodsQuantity,
                SinglePrice=e.SinglePrice,
                LiveAnchorId=e.LiveAnchorId,
                TakeGoodsType=e.TakeGoodsType,
                TotalPrice=e.TotalPrice,
                TakeGoodsDate=e.TakeGoodsDate.Value
            }).ToListAsync();

        }


        /// <summary>
        /// 获取当月带货业绩数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="contentPlatformId"></param>
        /// <param name="baseLiveAnchorId"></param>
        /// <returns></returns>
        public async Task<List<LivingDailyTakeGoodsDto>> GetTakeGoodsAnalizeDataAsync(DateTime startDate, DateTime endDate, string contentPlatformId, List<int> liveAnchorIds)
        {

            var data = dalLivingDailyTakeGoodsService.GetAll().Include(x=>x.SupplierBrand).Include(x=>x.SupplierCategory).Include(x=>x.SupplierItemDetails)
                .Where(e => e.TakeGoodsDate >= startDate && e.TakeGoodsDate <= endDate && e.Valid == true);
            if (!string.IsNullOrEmpty(contentPlatformId))
            {
                data = data.Where(e => e.ContentPlatFormId == contentPlatformId);
                if (liveAnchorIds.Count > 0)
                {
                    data = data.Where(e => liveAnchorIds.Contains(e.LiveAnchorId));
                }
            }
            return await data.Select(e => new LivingDailyTakeGoodsDto
            {
                CategoryName = e.SupplierCategory.CategoryName,
                BrandName = e.SupplierBrand.BrandName,
                ItemDetailsName=e.SupplierItemDetails.ItemDetailsName,
                SinglePrice = e.SinglePrice,
                LiveAnchorId = e.LiveAnchorId,
                TakeGoodsType = e.TakeGoodsType,
                TotalPrice = e.TotalPrice,
                TakeGoodsQuantity=e.TakeGoodsQuantity,
                TakeGoodsDate = e.TakeGoodsDate.Value
            }).ToListAsync();

        }
    }
}
