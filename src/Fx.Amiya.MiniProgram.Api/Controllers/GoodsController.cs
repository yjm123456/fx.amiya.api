﻿using Fx.Amiya.Core.Interfaces.Goods;
using Fx.Amiya.IService;
using Fx.Amiya.MiniProgram.Api.Vo;
using Fx.Amiya.MiniProgram.Api.Vo.Goods;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Controllers
{
    [Route("amiya/wxmini/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        private IGoodsCategory goodsCategoryService;
        private IGoodsInfo goodsInfoService;
        private TokenReader _tokenReader;
        private IMiniSessionStorage _sessionStorage;
        private readonly IMemberCardHandleService memberCardHandleService;
        private readonly ICustomerTagInfoService customerTagInfoService;
        private readonly IGoodsInfoService goodsInfoService1;
        public GoodsController(IGoodsCategory goodsCategoryService,
            IGoodsInfo goodsInfoService,
            TokenReader tokenReader,
            IMiniSessionStorage sessionStorage, IMemberCardHandleService memberCardHandleService, ICustomerTagInfoService customerTagInfoService, IGoodsInfoService goodsInfoService1)
        {
            this.goodsCategoryService = goodsCategoryService;
            this.goodsInfoService = goodsInfoService;
            _tokenReader = tokenReader;
            _sessionStorage = sessionStorage;
            this.memberCardHandleService = memberCardHandleService;
            this.customerTagInfoService = customerTagInfoService;
            this.goodsInfoService1 = goodsInfoService1;
        }

        /// <summary>
        /// 根据展示方向获取商品分类列表
        /// </summary>
        /// <param name="showDirectionType">展示方向</param>
        /// <param name="appId">归属小程序appid</param>
        /// <returns></returns>
        [HttpGet("categoryList")]
        public async Task<ResultData<List<GoodsCategoryVo>>> GetGoodsCategoryListAsync(int showDirectionType,string appId)
        {
            var goodsCategorys = from d in await goodsCategoryService.GetCategoryNameListAsync(true,appId)
                                 select new GoodsCategoryVo
                                 {
                                     Id = d.Id,
                                     Name = d.Name,
                                     ShowDirectionType = d.ShowDirectionType.Value,
                                     CategoryImg=d.CategoryImg
                                 };


            return ResultData<List<GoodsCategoryVo>>.Success().AddData("goodsCategorys", goodsCategorys.Where(z => z.ShowDirectionType == showDirectionType).ToList());
        }
        /// <summary>
        /// 获取热门品牌列表
        /// </summary>
        /// <param name="showDirectionType">展示方向</param>
        /// <param name="appId">归属小程序appid</param>
        /// <returns></returns>
        [HttpGet("hotCategoryList")]
        public async Task<ResultData<List<GoodsCategoryVo>>> GetHotGoodsCategoryListAsync(int showDirectionType, string appId)
        {
            var goodsCategorys = from d in await goodsCategoryService.GetHotCategoryNameListAsync(true,4,true,true, appId)
                                 select new GoodsCategoryVo
                                 {
                                     Id = d.Id,
                                     Name = d.Name,
                                     ShowDirectionType = d.ShowDirectionType.Value,
                                     CategoryImg = d.CategoryImg
                                 };
            return ResultData<List<GoodsCategoryVo>>.Success().AddData("hotGoodsCategorys", goodsCategorys.ToList());
        }
        /// <summary>
        /// 获取热门分类列表
        /// </summary>
        /// <param name="showDirectionType">展示方向</param>
        /// <param name="appId">归属小程序appid</param>
        /// <returns></returns>
        [HttpGet("hotNotBrandCategoryList")]
        public async Task<ResultData<List<GoodsCategoryVo>>> GetNotBrandCategoryListAsync(int showDirectionType, string appId)
        {
            var goodsCategorys = from d in await goodsCategoryService.GetHotCategoryNameListAsync(true, 4, false,true, appId)
                                 select new GoodsCategoryVo
                                 {
                                     Id = d.Id,
                                     Name = d.Name,
                                     ShowDirectionType = d.ShowDirectionType.Value,
                                     CategoryImg = d.CategoryImg
                                 };
            return ResultData<List<GoodsCategoryVo>>.Success().AddData("hotGoodsCategorys", goodsCategorys.ToList());
        }
        /// <summary>
        /// 获取所有商品分类
        /// </summary>
        /// <param name="showDirectionType"></param>
        /// <returns></returns>
        [HttpGet("allCategoryList")]
        public async Task<ResultData<List<GoodsCategoryVo>>> GetAllGoodsCategoryListAsync()
        {
            var goodsCategorys = from d in await goodsCategoryService.GetCategoryNameListAsync(true)
                                 select new GoodsCategoryVo
                                 {
                                     Id = d.Id,
                                     Name = d.Name,
                                     ShowDirectionType = d.ShowDirectionType.Value,
                                     CategoryImg = d.CategoryImg
                                 };


            return ResultData<List<GoodsCategoryVo>>.Success().AddData("goodsCategorys", goodsCategorys.ToList());
        }

        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="exchangeType">交易方式（0积分支付，1三方支付，2线下支付）</param>
        /// <param name="categoryId"></param>
        /// <param name="appId">归属小程序</param>
        /// <param name="isHot">是否是热门商品</param>
        /// <param name="sort">排序方式(默认0:按序号排序,1:销量排序,2价格排序)</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("infoList")]
        public async Task<ResultData<FxPageInfo<GoodsInfoForListVo>>> GetGoodsInfoListAsync(string keyword, int? exchangeType, int? categoryId,string appId,bool? isHot,int sort, int pageNum, int pageSize)
        {

            var q = await goodsInfoService.GetMiniprogramGoodsListAsync(keyword, exchangeType, categoryId, true,appId,isHot,sort, pageNum, pageSize);
            var goodsInfos = from d in q.List
                             select new GoodsInfoForListVo
                             {
                                 Id = d.Id,
                                 Name = d.Name,
                                 ThumbPicUrl = d.ThumbPicUrl,
                                 Description = d.Description,
                                 SalePrice = d.SalePrice,
                                 InventoryQuantity = d.InventoryQuantity,
                                 ExchangeType = d.ExchangeType,
                                 IntegrationQuantity = d.IntegrationQuantity,
                                 IsLimitBuy = d.IsLimitBuy,
                                 LimitBuyQuantity = d.LimitBuyQuantity,
                                 DetailsDescription = d.DetailsDescription,
                                 MaxShowPrice = d.MaxShowPrice,
                                 MinShowPrice = d.MinShowPrice,
                                 ShowSaleCount = d.ShowSaleCount,
                                 VisitCount = d.VisitCount,
                                 isMember=d.IsMember
                             };
            FxPageInfo<GoodsInfoForListVo> goodsPageInfo = new FxPageInfo<GoodsInfoForListVo>();
            goodsPageInfo.TotalCount = q.TotalCount;
            goodsPageInfo.List = goodsInfos;
            return ResultData<FxPageInfo<GoodsInfoForListVo>>.Success().AddData("goodsInfos", goodsPageInfo);
        }




        /// <summary>
        /// 根据商品编号获取商品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("infoById/{id}")]
        public async Task<ResultData<GoodsInfoForSingleVo>> GetGoodsInfoByIdAsync(string id)
        {
            var token = _tokenReader.GetToken();
            var sesssionInfo = _sessionStorage.GetSession(token);
            string customerId = sesssionInfo.FxCustomerId;
            var goodsInfo = await goodsInfoService.GetByIdAsync(id);
            GoodsInfoForSingleVo goods = new GoodsInfoForSingleVo()
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
                CategoryIds = goodsInfo.CategoryIds,
                GoodsDetailId = goodsInfo.GoodsDetailId,
                GoodsDetailHtml = goodsInfo.GoodsDetailHtml,
                DetailsDescription = goodsInfo.DetailsDescription,
                MaxShowPrice = goodsInfo.MaxShowPrice,
                MinShowPrice = goodsInfo.MinShowPrice,
                ShowSaleCount = goodsInfo.ShowSaleCount,
                VisitCount = goodsInfo.VisitCount,
                CarouselImageUrls = (from d in goodsInfo.CarouselImageUrls
                                     select new GoodsInfoCarouselImageVo
                                     {
                                         PicUrl = d.PicUrl,
                                         DisplayIndex = d.DisplayIndex
                                     }).ToList(),
                IsMember = false,
                MemberRankPrice = goodsInfo.SalePrice.Value,
                CanUseVoucher = false,
                GoodsStandardsPrice=(from d in goodsInfo.GoodsStandardsPrice select new GoodsStandardsPriceVo {
                    Id=d.Id,
                    GoodsId=d.GoodsId,
                    Standards=d.Standards,
                    StandardsImg=d.StandardsImg,
                    Price=d.Price,
                    IntegralAmount=d.IntegralAmount
                }).ToList()
            };
            //当前用户的会员价格
            var member = await memberCardHandleService.GetMemberCardByCustomeridAsync(customerId);
            if (member != null)
            {
                var memberPrice = goodsInfo.GoodsMemberRankPrice.Find(e => e.MemberRankId == member.MemberRankId);
                if (memberPrice != null)
                {
                    goods.IsMember = true;
                    goods.MemberRankPrice = memberPrice.Price;
                    goods.MemberName = memberPrice.MemberRankName;
                }
            }
            //是否可以使用抵用券
            if (goodsInfo.GoodsConsumptionVoucher.Any()) {
                goods.CanUseVoucher = true;
            }
            return ResultData<GoodsInfoForSingleVo>.Success().AddData("goodsInfo", goods);
        }

        /// <summary>
        /// 根据商品编号获取商品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("infoBySimpleCode/{code}")]
        public async Task<ResultData<GoodsInfoForSingleVo>> GetGoodsInfoBySimpleCodeAsync(string code)
        {
            var token = _tokenReader.GetToken();
            var sesssionInfo = _sessionStorage.GetSession(token);
            string customerId = sesssionInfo.FxCustomerId;
            var goodsInfo = await goodsInfoService.GetSkinCareByCode(code);
            GoodsInfoForSingleVo goods = new GoodsInfoForSingleVo()
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
                CategoryIds = goodsInfo.CategoryIds,
                GoodsDetailId = goodsInfo.GoodsDetailId,
                DetailsDescription = goodsInfo.DetailsDescription,
                MaxShowPrice = goodsInfo.MaxShowPrice,
                MinShowPrice = goodsInfo.MinShowPrice,
                ShowSaleCount = goodsInfo.ShowSaleCount,
                VisitCount = goodsInfo.VisitCount,
                IsMember = false,
                MemberRankPrice = goodsInfo.SalePrice.Value,
                CanUseVoucher = false
            };
            //当前用户的会员价格
            var member = await memberCardHandleService.GetMemberCardByCustomeridAsync(customerId);
            if (member != null)
            {
                var memberPrice = goodsInfo.GoodsMemberRankPrice.Find(e => e.MemberRankId == member.MemberRankId);
                if (memberPrice != null)
                {
                    goods.IsMember = true;
                    goods.MemberRankPrice = memberPrice.Price;
                    goods.MemberName = memberPrice.MemberRankName;
                }
            }
            //是否可以使用抵用券
            if (goodsInfo.GoodsConsumptionVoucher.Any())
            {
                goods.CanUseVoucher = true;
            }
            return ResultData<GoodsInfoForSingleVo>.Success().AddData("goodsInfo", goods);
        }
        
        /// <summary>
        /// 根据商品编号获取同商品组的所有商品列表
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        [HttpGet("infoListForGoodsGroup/{goodsId}")]
        public async Task<ResultData<List<GoodsInfoSimpleVo>>> GetGoodsListForGoodsGroupByGoodsIdAsync(string goodsId)
        {
            var goodsInfos = from d in await goodsInfoService.GetGoodsListForGoodsGroupByGoodsIdAsync(goodsId)
                             select new GoodsInfoSimpleVo
                             {
                                 Id = d.Id,
                                 Name = d.Name,
                                 Standard = d.Standard,
                                 ThumbPicUrl = d.ThumbPicUrl,
                                 Description = d.Description,
                                 Unit = d.Unit,
                                 SalePrice = d.SalePrice,
                                 IsLimitBuy = d.IsLimitBuy,
                                 LimitBuyQuantity = d.LimitBuyQuantity,
                                 ExchangeType = d.ExchangeType,
                                 IntegrationQuantity = d.IntegrationQuantity,
                                 InventoryQuantity = d.InventoryQuantity,
                                 IsMaterial = d.IsMaterial,
                                 Valid = d.Valid
                             };
            return ResultData<List<GoodsInfoSimpleVo>>.Success().AddData("goodsInfos", goodsInfos.ToList());
        }
        /// <summary>
        /// 首页热门商品列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("hotGoodsList")]
        public async Task<ResultData<FxPageInfo<GoodsInfoForListVo>>> GetHotGoodsInfoListAsync(string appId,int pageNum, int pageSize)
        {

            var q = await goodsInfoService.GetHotGoodsListAsync(true,appId, pageNum, pageSize);
            var goodsInfos = from d in q.List
                             select new GoodsInfoForListVo
                             {
                                 Id = d.Id,
                                 Name = d.Name,
                                 ThumbPicUrl = d.ThumbPicUrl,
                                 Description = d.Description,
                                 SalePrice = d.SalePrice,
                                 InventoryQuantity = d.InventoryQuantity,
                                 ExchangeType = d.ExchangeType,
                                 IntegrationQuantity = d.IntegrationQuantity,
                                 IsLimitBuy = d.IsLimitBuy,
                                 LimitBuyQuantity = d.LimitBuyQuantity,
                                 DetailsDescription = d.DetailsDescription,
                                 MaxShowPrice = d.MaxShowPrice,
                                 MinShowPrice = d.MinShowPrice,
                                 ShowSaleCount = d.ShowSaleCount,
                                 VisitCount = d.VisitCount,
                                 isMember=d.IsMember,
                                 Unit=d.Unit
                             };
            FxPageInfo<GoodsInfoForListVo> goodsPageInfo = new FxPageInfo<GoodsInfoForListVo>();
            goodsPageInfo.TotalCount = q.TotalCount;
            goodsPageInfo.List = goodsInfos;
            return ResultData<FxPageInfo<GoodsInfoForListVo>>.Success().AddData("goodsInfos", goodsPageInfo);
        }
        [HttpGet("integralList")]
        public async Task<ResultData<FxPageInfo<GoodsInfoForListVo>>> GetIntegraGoodsInfoListAsync(int pageNum, int pageSize)
        {

            var q = await goodsInfoService.GetIntegraListAsync(true, pageNum, pageSize);
            var goodsInfos = from d in q.List
                             select new GoodsInfoForListVo
                             {
                                 Id = d.Id,
                                 Name = d.Name,
                                 ThumbPicUrl = d.ThumbPicUrl,
                                 Description = d.Description,
                                 SalePrice = d.SalePrice,
                                 InventoryQuantity = d.InventoryQuantity,
                                 ExchangeType = d.ExchangeType,
                                 IntegrationQuantity = d.IntegrationQuantity,
                                 IsLimitBuy = d.IsLimitBuy,
                                 LimitBuyQuantity = d.LimitBuyQuantity,
                                 DetailsDescription = d.DetailsDescription,
                                 MaxShowPrice = d.MaxShowPrice,
                                 MinShowPrice = d.MinShowPrice,
                                 ShowSaleCount = d.ShowSaleCount,
                                 VisitCount = d.VisitCount
                             };
            FxPageInfo<GoodsInfoForListVo> goodsPageInfo = new FxPageInfo<GoodsInfoForListVo>();
            goodsPageInfo.TotalCount = q.TotalCount;
            goodsPageInfo.List = goodsInfos;
            return ResultData<FxPageInfo<GoodsInfoForListVo>>.Success().AddData("goodsInfos", goodsPageInfo);
        }
        /// <summary>
        /// 商品标签列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("tagList")]
        public async Task<ResultData<List<BaseIdAndNameVo>>> GetTagListAsync() {
            var tags= await customerTagInfoService.GetGoodsTagNameListAsync();
            var result= tags.Select(e => new BaseIdAndNameVo
            {
                Id = e.Key,
                Name = e.Value
            }).ToList();
            return ResultData<List<BaseIdAndNameVo>>.Success().AddData("tags",result);
        }
        /// <summary>
        /// 根据关键词和商品类别查询商品
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpGet("search")]
        public async Task<ResultData<FxPageInfo<SearchGoodsResultVo>>> SearchAsync(string keyword,int? categoryId, bool? orderByPrice, bool? orderBySaleCount, int pageNum,int pageSize) {
            var searchResult= await goodsInfoService1.SearchAsync(keyword,categoryId,orderByPrice,orderBySaleCount,pageNum,pageSize);
            FxPageInfo<SearchGoodsResultVo> fxPageInfo = new FxPageInfo<SearchGoodsResultVo>();
            fxPageInfo.TotalCount = searchResult.TotalCount;
            fxPageInfo.List = searchResult.List.Select(e => new SearchGoodsResultVo
            {
                GoodsId = e.GoodsId,
                ExchageType = e.ExchageType,
                Price = e.Price,
                IntegralPrice = e.IntegralPrice,
                GoodsPicture = e.GoodsPicture,
                GoodsName = e.GoodsName,
                MaxPrice = e.MaxPrice
            }).ToList();
            return ResultData<FxPageInfo<SearchGoodsResultVo>>.Success().AddData("searchResult", fxPageInfo);
        }
        /// <summary>
        /// 根据标签获取商品
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpGet("tagGoodsList")]
        public async Task<ResultData<FxPageInfo<SearchGoodsResultVo>>> SearchAsync(string tagId, string appId, int sort, int pageNum, int pageSize)
        {
            var searchResult = await goodsInfoService1.TagSearchAsync(tagId, appId, sort, pageNum, pageSize);
            FxPageInfo<SearchGoodsResultVo> fxPageInfo = new FxPageInfo<SearchGoodsResultVo>();
            fxPageInfo.TotalCount = searchResult.TotalCount;
            fxPageInfo.List = searchResult.List.Select(e => new SearchGoodsResultVo
            {
                GoodsId = e.GoodsId,
                ExchageType = e.ExchageType,
                Price = e.Price,
                IntegralPrice = e.IntegralPrice,
                GoodsPicture = e.GoodsPicture,
                GoodsName = e.GoodsName,
                MaxPrice = e.MaxPrice
            }).ToList();
            return ResultData<FxPageInfo<SearchGoodsResultVo>>.Success().AddData("list", fxPageInfo);
        }


    }
}
