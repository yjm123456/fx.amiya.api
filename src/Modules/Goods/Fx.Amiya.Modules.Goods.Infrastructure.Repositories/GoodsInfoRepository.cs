using Fx.Amiya.Modules.Goods.DbModel;
using Fx.Amiya.Modules.Goods.Domin;
using Fx.Amiya.Modules.Goods.Domin.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.Goods.Infrastructure.Repositories
{
    public class GoodsInfoRepository : IGoodsInfoRepository
    {
        private IFreeSql<GoodsFlag> freeSql;
        public GoodsInfoRepository(IFreeSql<GoodsFlag> freeSql)
        {
            this.freeSql = freeSql;
        }
        public async Task<GoodsInfo> AddAsync(GoodsInfo entity)
        {
            int? detailId = null;
            if (!string.IsNullOrWhiteSpace(entity.GoodsDetail?.GoodsDetailHtml))
            {
                GoodsDetailDbModel goodsDetailDbModel = new GoodsDetailDbModel()
                {
                    GoodsDetailHtml = entity.GoodsDetail.GoodsDetailHtml,
                    CreateBy = entity.GoodsDetail.CreateBy,
                    CreateDate = entity.CreateDate
                };
                detailId = (int)await freeSql.Insert<GoodsDetailDbModel>().AppendData(goodsDetailDbModel).ExecuteIdentityAsync();
            }



            GoodsInfoDbModel goodsInfo = new GoodsInfoDbModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                SimpleCode = entity.SimpleCode,
                Description = entity.Description,
                Standard = entity.Standard,
                Unit = entity.Unit,
                SalePrice = entity.SalePrice,
                InventoryQuantity = entity.InventoryQuantity,
                Valid = entity.Valid,
                ExchangeType = entity.ExchangeType,
                IntegrationQuantity = entity.IntegrationQuantity,
                ThumbPicUrl = entity.ThumbPicUrl,
                IsMaterial = entity.IsMaterial,
                GoodsType = entity.GoodsType,
                IsLimitBuy = entity.IsLimitBuy,
                LimitBuyQuantity = entity.LimitBuyQuantity,
                CategoryId = entity.CategoryId,
                GoodsDetailId = detailId,
                CreateBy = entity.CreateBy,
                CreateDate = entity.CreateDate,
                Version = entity.Version,
                DetailsDescription = entity.DetailsDescription,
                MaxShowPrice = entity.MaxShowPrice,
                MinShowPrice = entity.MinShowPrice,
                VisitCount = entity.VisitCount,
                ShowSaleCount = entity.ShowSaleCount,
                SaleCount = 0
        };
        await freeSql.Insert<GoodsInfoDbModel>().AppendData(goodsInfo).ExecuteAffrowsAsync();


        var carouselImageList = (from d in entity.GoodsInfoCarouselImages
                                 select new GoodsInfoCarouselImageDbModel
                                 {
                                     GoodsInfoId = entity.Id,
                                     PicUrl = d.PicUrl,
                                     DisplayIndex = d.DisplayIndex,
                                     CreateDate = d.CreateDate
                                 }).ToList();

        await freeSql.Insert<GoodsInfoCarouselImageDbModel>().AppendData(carouselImageList).ExecuteAffrowsAsync();

            return entity;

        }

    public async Task<GoodsInfo> GetByIdAsync(string id)
    {
        var goodsInfo = await freeSql.Select<GoodsInfoDbModel>()
            .Include(e => e.GoodsCategory)
            .Include(e => e.GoodsDetail)
            .IncludeMany(e => e.GoodsInfoCarouselImageList)
            .Where(e => e.Id == id).FirstAsync();
            if (goodsInfo == null)
            {
                return new GoodsInfo();
            }
        GoodsInfo goods = new GoodsInfo()
        {
            Id = goodsInfo.Id,
            Name = goodsInfo.Name,
            SimpleCode = goodsInfo.SimpleCode,
            Description = goodsInfo.Description,
            Standard = goodsInfo.Standard,
            Unit = goodsInfo.Unit,
            SalePrice = goodsInfo.SalePrice,
            InventoryQuantity = goodsInfo.InventoryQuantity,
            Valid = goodsInfo.Valid,
            ExchangeType = goodsInfo.ExchangeType,
            IntegrationQuantity = goodsInfo.IntegrationQuantity,
            ThumbPicUrl = goodsInfo.ThumbPicUrl,
            IsMaterial = goodsInfo.IsMaterial,
            GoodsType = goodsInfo.GoodsType,
            IsLimitBuy = goodsInfo.IsLimitBuy,
            LimitBuyQuantity = goodsInfo.LimitBuyQuantity,
            CategoryId = goodsInfo.CategoryId,
            CategoryName = goodsInfo.GoodsCategory.Name,
            CreateBy = goodsInfo.CreateBy,
            CreateDate = goodsInfo.CreateDate,
            UpdateBy = goodsInfo.UpdateBy,
            UpdatedDate = goodsInfo.UpdatedDate,
            Version = goodsInfo.Version,
            DetailsDescription = goodsInfo.DetailsDescription,
            MaxShowPrice = goodsInfo.MaxShowPrice,
            MinShowPrice = goodsInfo.MinShowPrice,
            ShowSaleCount = goodsInfo.ShowSaleCount,
            VisitCount = goodsInfo.VisitCount,

            GoodsDetail = goodsInfo.GoodsDetailId == null ? null : new GoodsDetail()
            {
                Id = (int)goodsInfo.GoodsDetailId,
                GoodsDetailHtml = goodsInfo.GoodsDetail.GoodsDetailHtml,

            },

            GoodsInfoCarouselImages = (from d in goodsInfo.GoodsInfoCarouselImageList
                                       select new GoodsInfoCarouselImage
                                       {
                                           Id = d.Id,
                                           PicUrl = d.PicUrl,
                                           DisplayIndex = d.DisplayIndex,
                                       }).ToList()
        };

        return goods;
    }

    public async Task<int> RemoveAsync(GoodsInfo entity)
    {
        return await RemoveAsync(entity.Id);
    }

    public async Task<int> RemoveAsync(string id)
    {
        // await freeSql.Delete<GoodsInfoCarouselImageDbModel>().Where(e => e.GoodsInfoId == id).ExecuteAffrowsAsync();
        return await freeSql.Delete<GoodsInfoDbModel>().Where(e => e.Id == id).ExecuteAffrowsAsync();

    }

    public async Task<int> UpdateAsync(GoodsInfo entity)
    {
        //商品详情
        int? detailId = null;
        if (entity.GoodsDetail?.Id == null)
        {
            if (!string.IsNullOrWhiteSpace(entity.GoodsDetail?.GoodsDetailHtml))
            {
                GoodsDetailDbModel goodsDetailDbModel = new GoodsDetailDbModel()
                {
                    GoodsDetailHtml = entity.GoodsDetail.GoodsDetailHtml,
                    CreateBy = (int)entity.UpdateBy,
                    CreateDate = entity.CreateDate
                };
                detailId = (int)await freeSql.Insert<GoodsDetailDbModel>().AppendData(goodsDetailDbModel).ExecuteIdentityAsync();
            }
        }
        else
        {
            if (string.IsNullOrWhiteSpace(entity.GoodsDetail?.GoodsDetailHtml))
            {
                await freeSql.Delete<GoodsDetailDbModel>().Where(e => e.Id == entity.GoodsDetail.Id).ExecuteAffrowsAsync();
            }
            else
            {
                await freeSql.Update<GoodsDetailDbModel>()
                    .Set(e => e.GoodsDetailHtml, entity.GoodsDetail.GoodsDetailHtml)
                    .Set(e => e.UpdateDate, entity.UpdatedDate)
                    .Set(e => e.UpdateBy, entity.UpdateBy)
                    .Where(e => e.Id == entity.GoodsDetail.Id)
                    .ExecuteAffrowsAsync();
                detailId = entity.GoodsDetail.Id;
            }
        }


        //轮播图
        var carouselImages = await freeSql.Select<GoodsInfoCarouselImageDbModel>().Where(e => e.GoodsInfoId == entity.Id).ToListAsync();
        foreach (var item in carouselImages)
        {
            if (!entity.GoodsInfoCarouselImages.Exists(e => e.PicUrl == item.PicUrl))
            {
                await freeSql.Delete<GoodsInfoCarouselImageDbModel>().Where(e => e.Id == item.Id).ExecuteAffrowsAsync();
            }
        }

        foreach (var item in entity.GoodsInfoCarouselImages)
        {
            if (!carouselImages.Exists(e => e.PicUrl == item.PicUrl))
            {

                GoodsInfoCarouselImageDbModel images = new GoodsInfoCarouselImageDbModel()
                {
                    GoodsInfoId = entity.Id,
                    PicUrl = item.PicUrl,
                    DisplayIndex = item.DisplayIndex,
                    CreateDate = (DateTime)entity.UpdatedDate
                };

                await freeSql.Insert<GoodsInfoCarouselImageDbModel>().AppendData(images).ExecuteAffrowsAsync();
            }
        }




        return await freeSql.Update<GoodsInfoDbModel>()
            .Set(e => e.Name, entity.Name)
            .Set(e => e.ThumbPicUrl, entity.ThumbPicUrl)
            .Set(e => e.SimpleCode, entity.SimpleCode)
            .Set(e => e.Description, entity.Description)
            .Set(e => e.Standard, entity.Standard)
            .Set(e => e.Unit, entity.Unit)
            .Set(e => e.SalePrice, entity.SalePrice)
            .Set(e => e.Valid, entity.Valid)
            .Set(e => e.InventoryQuantity, entity.InventoryQuantity)
            .Set(e => e.ExchangeType, entity.ExchangeType)
            .Set(e => e.IntegrationQuantity, entity.IntegrationQuantity)
            .Set(e => e.IsMaterial, entity.IsMaterial)
            .Set(e => e.GoodsType, entity.GoodsType)
            .Set(e => e.IsLimitBuy, entity.IsLimitBuy)
            .Set(e => e.LimitBuyQuantity, entity.LimitBuyQuantity)
            .Set(e => e.CategoryId, entity.CategoryId)
            .Set(e => e.UpdatedDate, entity.UpdatedDate)
            .Set(e => e.UpdateBy, entity.UpdateBy)
            .Set(e => e.DetailsDescription, entity.DetailsDescription)
            .Set(e => e.MaxShowPrice, entity.MaxShowPrice)
            .Set(e => e.MinShowPrice, entity.MinShowPrice)
            .Set(e => e.ShowSaleCount, entity.ShowSaleCount)
            .Set(e => e.VisitCount, entity.VisitCount)
            .Set(e => e.GoodsDetailId, detailId)
            .Where(e => e.Id == entity.Id)
            .ExecuteAffrowsAsync();

    }
}
}
