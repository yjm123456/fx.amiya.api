
using Fx.Amiya.Core.Interfaces.Goods;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.GoodsInfo;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class GoodsInfoService : IGoodsInfoService
    {
        private readonly IDalGoodsInfo dalGoodsInfo;
        private readonly IDalCustomerTagInfo dalCustomerTagInfo;
        private readonly IDalTagDetailInfo dalTagDetailInfo;
        private readonly IGoodsCategory goodsCategory;
        private readonly IDalGoodsStandardsPrice dalGoodsStandardsPrice;
        private readonly IDalGoodsConsumptionVoucher dalGoodsConsumptionVoucher;
        private readonly IGoodsStandardsPriceService goodsStandardsPriceService;
        private readonly IGoodsConsumptionVoucherService goodsConsumptionVoucherService;
        private readonly IMiniprogramService miniprogramService;
        public GoodsInfoService(IDalGoodsInfo dalGoodsInfo, IDalCustomerTagInfo dalCustomerTagInfo, IDalTagDetailInfo dalTagDetailInfo, IGoodsCategory goodsCategory, IDalGoodsStandardsPrice dalGoodsStandardsPrice, IDalGoodsConsumptionVoucher dalGoodsConsumptionVoucher, IGoodsStandardsPriceService goodsStandardsPriceService, IGoodsConsumptionVoucherService goodsConsumptionVoucherService, IMiniprogramService miniprogramService)
        {
            this.dalGoodsInfo = dalGoodsInfo;
            this.dalCustomerTagInfo = dalCustomerTagInfo;
            this.dalTagDetailInfo = dalTagDetailInfo;
            this.goodsCategory = goodsCategory;
            this.dalGoodsStandardsPrice = dalGoodsStandardsPrice;
            this.dalGoodsConsumptionVoucher = dalGoodsConsumptionVoucher;
            this.goodsStandardsPriceService = goodsStandardsPriceService;
            this.goodsConsumptionVoucherService = goodsConsumptionVoucherService;
            this.miniprogramService = miniprogramService;
        }

        public async Task<List<GoodsOrderInfoDto>> GetGoodListByIdsAsync(List<string> ids)
        {          
            var goodsInfoList = dalGoodsInfo.GetAll().Where(e => ids.Contains(e.Id)).Select(e=>new GoodsOrderInfoDto { 
                Id=e.Id,
                ExchageType=e.ExchangeType,
                GoodsName=e.Name,
                InventoryQuantity=e.InventoryQuantity.Value,
                ThumailPic=e.ThumbPicUrl,
                Valid=e.Valid,
                CategoryId=e.CategoryId
            }).ToList();
            if (ids.Count != goodsInfoList.Count) throw new Exception("订单商品包含无效商品,请检查后重新下单！");
            var unAvailableGoods = goodsInfoList.Where(e=>e.Valid==false).Select(e => e.GoodsName).ToList();
            if (unAvailableGoods.Count > 0) throw new Exception($"商品{string.Join(",",unAvailableGoods)}已下架,请剔除后重新下单！");
            var standardList =await goodsStandardsPriceService.GetStandardByGoodsIdsAsync(ids);
            var voucherList =await goodsConsumptionVoucherService.GetGoodsConsumptionVoucherByGoodsIdsAsync(ids);
            foreach (var goods in goodsInfoList)
            {
                goods.StandardList = standardList.FindAll(e=>e.GoodsId==goods.Id);
                goods.VoucherList = voucherList.FindAll(e=>e.GoodsId==goods.Id);
            }
            return goodsInfoList;
        }

        public async Task<FxPageInfo<SimpleGoodsInfoDto>> SearchAsync(string keyword, int? categoryId, bool? orderByPrice, bool? orderBySaleCount, int pageNum, int pageSize)
        {
            bool isIntegralCategory = false;
            if (categoryId.HasValue)
            {
                var category = await goodsCategory.GetByIdAsync(categoryId.Value);
                if (category.ShowDirectionType == (int)Core.Dto.Goods.ShowDirectionType.Integral)
                {
                    isIntegralCategory = true;
                }
            }
            var tagInfoList = from d in dalTagDetailInfo.GetAll()
                              join c in dalCustomerTagInfo.GetAll()
                              on d.TagId equals c.Id
                              select new { c.TagName, d.CustomerGoodsId };
            var categoryIds =(await goodsCategory.GetCategoryNameListAsync(true)).Select(e=>e.Id);
            var goodsList = from g in dalGoodsInfo.GetAll()
                            where g.Valid == true && categoryIds.Contains(g.CategoryId)
                            join t in tagInfoList
                            on g.Id equals t.CustomerGoodsId into gt
                            from goods_tag in gt.DefaultIfEmpty()
                            select new { g, goods_tag };
            if (!string.IsNullOrEmpty(keyword))
            {
                goodsList = goodsList.Where(e => e.goods_tag.TagName.Contains(keyword) || e.g.Name.Contains(keyword));
            }
            if (categoryId.HasValue)
            {
                goodsList = goodsList.Where(e => e.g.CategoryId == categoryId);
            }
            if (orderByPrice.HasValue && orderByPrice.Value && !isIntegralCategory)
            {
                goodsList = goodsList.OrderByDescending(e => e.g.SalePrice);
            }
            if (isIntegralCategory)
            {
                goodsList = goodsList.OrderByDescending(e => e.g.IntegrationQuantity);
            }
            if (orderBySaleCount.HasValue && orderBySaleCount.Value)
            {
                goodsList = goodsList.OrderByDescending(e => e.g.SaleCount);
            }
            if (!orderBySaleCount.Value && !orderByPrice.Value&&!categoryId.HasValue)
            {
                goodsList = goodsList.OrderByDescending(e => e.g.Sort);
            }

            FxPageInfo<SimpleGoodsInfoDto> fxPageInfo = new FxPageInfo<SimpleGoodsInfoDto>();
            fxPageInfo.TotalCount = goodsList.Count();
            fxPageInfo.List = goodsList.Skip((pageNum - 1) * pageSize).Take(pageSize).Select(e => new SimpleGoodsInfoDto
            {
                GoodsId = e.g.Id,
                ExchageType = e.g.ExchangeType,
                Price = e.g.SalePrice,
                IntegralPrice = e.g.IntegrationQuantity,
                GoodsPicture = e.g.ThumbPicUrl,
                GoodsName = e.g.Name,
                MaxPrice = e.g.MaxShowPrice
            }).ToList();
            return fxPageInfo;
        }
        /// <summary>
        /// 根据标签获取商品信息
        /// </summary>
        /// <param name="tagId">标签id</param>
        /// <param name="sort">排序(0,序号排序,1价格排序,2销量排序)</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<SimpleGoodsInfoDto>> TagSearchAsync(string tagId, string appId, int sort, int pageNum, int pageSize)
        {
            var goodsList = from g in dalGoodsInfo.GetAll()
                            where g.Valid == true 
                            join t in dalTagDetailInfo.GetAll()
                            on g.Id equals t.CustomerGoodsId into gt
                            from goods in gt.DefaultIfEmpty()
                            where goods.TagId==tagId
                            select new { g };
            if (!string.IsNullOrEmpty(appId))
            {
                var appInfo = await miniprogramService.GetMiniprogramInfoByAppIdAsync(appId);
                if (appInfo.IsMain)
                {
                    goodsList = goodsList.Where(e => e.g.AppId == appId || string.IsNullOrEmpty(e.g.AppId));
                }

                if (!appInfo.IsMain)
                {
                    goodsList = goodsList.Where(e => e.g.AppId == appId || string.IsNullOrEmpty(e.g.AppId) || e.g.AppId == appInfo.BelongMiniprogramAppId);
                }

       
            }
            if (sort==0) {
                goodsList = goodsList.OrderByDescending(e => e.g.Sort);
            }
            if (sort==1) {
                goodsList = goodsList.OrderByDescending(e => e.g.SalePrice);
            }
            if (sort==2) {
                goodsList = goodsList.OrderByDescending(e => e.g.SaleCount);
            }            
            FxPageInfo<SimpleGoodsInfoDto> fxPageInfo = new FxPageInfo<SimpleGoodsInfoDto>();
            fxPageInfo.TotalCount = goodsList.Count();
            fxPageInfo.List = goodsList.Skip((pageNum - 1) * pageSize).Take(pageSize).Select(e => new SimpleGoodsInfoDto
            {
                GoodsId = e.g.Id,
                ExchageType = e.g.ExchangeType,
                Price = e.g.SalePrice,
                IntegralPrice = e.g.IntegrationQuantity,
                GoodsPicture = e.g.ThumbPicUrl,
                GoodsName = e.g.Name,
                MaxPrice = e.g.MaxShowPrice
            }).ToList();
            return fxPageInfo;
        }
        public async Task AddGoodsInfoAsync(GoodsInfoAddDto addDto) {
            //GoodsInfo goodsInfo = new GoodsInfo();
            //goodsInfo.Id = Guid.NewGuid().ToString("N");
            //goodsInfo.Name = addDto.Name;
            //goodsInfo.ThumbPicUrl = addDto.ThumbPicUrl;
            //goodsInfo.SimpleCode = addDto.SimpleCode;
            //goodsInfo.Description = addDto.Description;
            //goodsInfo.Standard = addDto.Standard;
            //goodsInfo.Unit = addDto.Unit;
            //goodsInfo.SalePrice = addDto.SalePrice;
            //goodsInfo.Valid = true;
            //goodsInfo.InventoryQuantity = addDto.InventoryQuantity;
            //goodsInfo.ExchangeType = (byte)goodsInfoAdd.ExchangeType;
            //goodsInfo.IntegrationQuantity = addDto.IntegrationQuantity;
            //goodsInfo.IsMaterial = addDto.IsMaterial;
            //goodsInfo.GoodsType = addDto.GoodsType;
            //goodsInfo.IsLimitBuy = addDto.IsLimitBuy;
            //goodsInfo.LimitBuyQuantity = addDto.LimitBuyQuantity;
            //goodsInfo.CreateDate = DateTime.Now;
            //goodsInfo.CreateBy = addDto.CreateBy;
            //goodsInfo.Version = 0;
            
            //goodsInfo.DetailsDescription = goodsInfoAdd.DetailsDescription;
            //goodsInfo.MaxShowPrice = goodsInfoAdd.MaxShowPrice;
            //goodsInfo.MinShowPrice = goodsInfoAdd.MinShowPrice;
            //goodsInfo.VisitCount = goodsInfoAdd.VisitCount;
            //goodsInfo.ShowSaleCount = goodsInfoAdd.ShowSaleCount;
            //goodsInfo.SaleCount = 0;
            //goodsInfo.Sort = goodsInfoAdd.Sort;
            //goodsInfo.AppId = goodsInfoAdd.AppId;
            //goodsInfo.IsHot = goodsInfoAdd.IsHot;
        }
    }
}
