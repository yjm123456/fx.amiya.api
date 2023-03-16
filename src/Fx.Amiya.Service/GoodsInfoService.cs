using Fx.Amiya.Core.Dto.Goods;
using Fx.Amiya.Core.Interfaces.Goods;
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
        public GoodsInfoService(IDalGoodsInfo dalGoodsInfo, IDalCustomerTagInfo dalCustomerTagInfo, IDalTagDetailInfo dalTagDetailInfo, IGoodsCategory goodsCategory, IDalGoodsStandardsPrice dalGoodsStandardsPrice, IDalGoodsConsumptionVoucher dalGoodsConsumptionVoucher, IGoodsStandardsPriceService goodsStandardsPriceService, IGoodsConsumptionVoucherService goodsConsumptionVoucherService)
        {
            this.dalGoodsInfo = dalGoodsInfo;
            this.dalCustomerTagInfo = dalCustomerTagInfo;
            this.dalTagDetailInfo = dalTagDetailInfo;
            this.goodsCategory = goodsCategory;
            this.dalGoodsStandardsPrice = dalGoodsStandardsPrice;
            this.dalGoodsConsumptionVoucher = dalGoodsConsumptionVoucher;
            this.goodsStandardsPriceService = goodsStandardsPriceService;
            this.goodsConsumptionVoucherService = goodsConsumptionVoucherService;
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
                if (category.ShowDirectionType == (int)ShowDirectionType.Integral)
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
    }
}
