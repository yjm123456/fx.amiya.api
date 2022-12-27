using Fx.Amiya.Background.Api.Vo.GoodsConsumptionVoucher;
using Fx.Amiya.Background.Api.Vo.GoodsInfo;
using Fx.Amiya.Background.Api.Vo.GoodsMemberRankPrice;
using Fx.Amiya.Core.Dto.Goods;
using Fx.Amiya.Core.Dto.GoodsHospitalPrice;
using Fx.Amiya.Core.Infrastructure;
using Fx.Amiya.Core.Interfaces.Goods;
using Fx.Amiya.Dto.GoodsConsumptionVoucher;
using Fx.Amiya.Dto.GoodsStandardsPrice;
using Fx.Amiya.Dto.MemberRankPrice;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class GoodsInfoController : ControllerBase
    {
        private IGoodsInfo goodsInfoService;
        private IHttpContextAccessor httpContextAccessor;
        private IHospitalInfoService _hospitalInfoService;
        public GoodsInfoController(IGoodsInfo goodsInfoService,
            IHttpContextAccessor httpContextAccessor,
            IHospitalInfoService hospitalInfoService)
        {
            this.goodsInfoService = goodsInfoService;
            this.httpContextAccessor = httpContextAccessor;
            _hospitalInfoService = hospitalInfoService;
        }

        /// <summary>
        /// 获取所有商品列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="categoryId">商品分类编号</param>
        /// <param name="valid"></param>
        /// <param name="exchangeType">交易方式（0积分支付，1三方支付，2线下支付）</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<FxPageInfo<GoodsInfoForListVo>>> GetListAsync(string keyword, int? exchangeType, int? categoryId, bool? valid, int pageNum, int pageSize)
        {
            var q = await goodsInfoService.GetListAsync(keyword, exchangeType, categoryId, valid, pageNum, pageSize);

            var goodsInfos = from d in q.List
                             select new GoodsInfoForListVo
                             {
                                 Id = d.Id,
                                 Name = d.Name,
                                 SimpleCode = d.SimpleCode,
                                 Description = d.Description,
                                 Standard = d.Standard,
                                 Unit = d.Unit,
                                 SalePrice = d.SalePrice,
                                 InventoryQuantity = d.InventoryQuantity,
                                 Valid = d.Valid,
                                 ExchangeType = d.ExchangeType,
                                 ExchangeTypeText = d.ExchangeTypeText,
                                 IntegrationQuantity = d.IntegrationQuantity,
                                 ThumbPicUrl = d.ThumbPicUrl,
                                 IsMaterial = d.IsMaterial,
                                 GoodsType = d.GoodsType,
                                 GoodsTypeName = d.GoodsTypeName,
                                 IsLimitBuy = d.IsLimitBuy,
                                 LimitBuyQuantity = d.LimitBuyQuantity,
                                 CategoryId = d.CategoryId,
                                 CategoryName = d.CategoryName,
                                 GoodsDetailId = d.GoodsDetailId,
                                 CreateBy = d.CreateBy,
                                 CreateDate = d.CreateDate,
                                 UpdateBy = d.UpdateBy,
                                 UpdatedDate = d.UpdatedDate,
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
        /// 根据编号获取商品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ResultData<GoodsInfoForSingleVo>> GetByIdAsync(string id)
        {
            var goodsInfo = await goodsInfoService.GetByIdAsync(id);

            List<GoodsHospitalPriceVo> goodsHospitalPriceVoList = new List<GoodsHospitalPriceVo>();
            foreach (var x in goodsInfo.GoodsHospitalPrice)
            {
                GoodsHospitalPriceVo goodsHospitalPriceVo = new GoodsHospitalPriceVo();
                goodsHospitalPriceVo.HospitalId = x.HospitalId;
                var hospitalResult = await _hospitalInfoService.GetBaseByIdAsync(x.HospitalId);
                if (hospitalResult == null)
                {
                    continue;
                }
                else
                {
                    goodsHospitalPriceVo.HospitalName = hospitalResult.Name.ToString();
                    goodsHospitalPriceVo.Price = x.Price;
                    goodsHospitalPriceVoList.Add(goodsHospitalPriceVo);
                }
            }
            List<GoodsStandardsPriceAddVo> goodsStandardsPriceVoList = new List<GoodsStandardsPriceAddVo>();
            foreach (var x in goodsInfo.GoodsStandardsPrice)
            {
                GoodsStandardsPriceAddVo goodsStandardsPriceVo = new GoodsStandardsPriceAddVo();
                goodsStandardsPriceVo.Standards = x.Standards;
                goodsStandardsPriceVo.Price = x.Price;
                goodsStandardsPriceVo.StandardsImg = x.StandardsImg;
                goodsStandardsPriceVoList.Add(goodsStandardsPriceVo);

            }
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
                ExchangeTypeText = goodsInfo.ExchangeTypeText,
                IntegrationQuantity = goodsInfo.IntegrationQuantity,
                ThumbPicUrl = goodsInfo.ThumbPicUrl,
                IsMaterial = goodsInfo.IsMaterial,
                GoodsType = goodsInfo.GoodsType,
                GoodsTypeName = goodsInfo.GoodsTypeName,
                IsLimitBuy = goodsInfo.IsLimitBuy,
                LimitBuyQuantity = goodsInfo.LimitBuyQuantity,
                CategoryId = goodsInfo.CategoryId,
                CategoryName = goodsInfo.CategoryName,
                CreateBy = goodsInfo.CreateBy,
                CreateDate = goodsInfo.CreateDate,
                UpdateBy = goodsInfo.UpdateBy,
                UpdatedDate = goodsInfo.UpdatedDate,
                GoodsDetailId = goodsInfo.GoodsDetailId,
                GoodsDetailHtml = goodsInfo.GoodsDetailHtml,
                DetailsDescription = goodsInfo.DetailsDescription,
                MaxShowPrice = goodsInfo.MaxShowPrice,
                MinShowPrice = goodsInfo.MinShowPrice,
                ShowSaleCount = goodsInfo.ShowSaleCount,
                VisitCount = goodsInfo.VisitCount,
                GoodsHospitalPrice = goodsHospitalPriceVoList,
                GoodsStandardPrice=goodsStandardsPriceVoList,
                GoodsMemberRankPrices = goodsInfo.GoodsMemberRankPrice.Select(e => new GoodsMemberRankPriceVo
                {
                    MemberRankId = e.MemberRankId,
                    MemberCardName = e.MemberRankName,
                    Price = e.Price
                }).ToList(),
                GoodsConsumptionVoucher = goodsInfo.GoodsConsumptionVoucher.Select(e => new GoodsConsumptionVoucherVo
                {
                    ConsumptionVoucherId = e.ConsumptionVoucherId,
                    ConsumptionName = e.ConsumptionVoucherName
                }).ToList(),
                CarouselImageUrls = (from d in goodsInfo.CarouselImageUrls
                                     select new GoodsInfoCarouselImageVo
                                     {
                                         Id = d.Id,
                                         PicUrl = d.PicUrl,
                                         DisplayIndex = d.DisplayIndex
                                     }).ToList()
            };

            return ResultData<GoodsInfoForSingleVo>.Success().AddData("goodsInfo", goods);
        }



        /// <summary>
        /// 添加商品信息
        /// </summary>
        /// <param name="goodsInfoAdd"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(GoodsInfoAddVo goodsInfoAdd)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            GoodsInfoAddDto goodsInfo = new GoodsInfoAddDto();
            goodsInfo.Name = goodsInfoAdd.Name;
            goodsInfo.ThumbPicUrl = goodsInfoAdd.ThumbPicUrl;
            goodsInfo.SimpleCode = goodsInfoAdd.SimpleCode;
            goodsInfo.Description = goodsInfoAdd.Description;
            goodsInfo.Standard = goodsInfoAdd.Standard;
            goodsInfo.Unit = goodsInfoAdd.Unit;
            goodsInfo.SalePrice = goodsInfoAdd.SalePrice;
            goodsInfo.InventoryQuantity = goodsInfoAdd.InventoryQuantity;
            goodsInfo.ExchangeType = goodsInfoAdd.ExchangeType;
            goodsInfo.IntegrationQuantity = goodsInfoAdd.IntegrationQuantity;
            goodsInfo.IsMaterial = goodsInfoAdd.IsMaterial;
            goodsInfo.GoodsType = (byte)GoodsType.General;
            goodsInfo.IsLimitBuy = goodsInfoAdd.IsLimitBuy;
            goodsInfo.LimitBuyQuantity = goodsInfoAdd.LimitBuyQuantity;
            goodsInfo.CategoryId = goodsInfoAdd.CategoryId;
            goodsInfo.CreateBy = employeeId;
            goodsInfo.GoodsDetailHtml = goodsInfoAdd.GoodsDetailHtml;
            goodsInfo.DetailsDescription = goodsInfoAdd.DetailsDescription;
            goodsInfo.MaxShowPrice = goodsInfoAdd.MaxShowPrice;
            goodsInfo.MinShowPrice = goodsInfoAdd.MinShowPrice;
            goodsInfo.VisitCount = goodsInfoAdd.VisitCount;
            goodsInfo.ShowSaleCount = goodsInfoAdd.ShowSaleCount;
            goodsInfo.GoodsHospitalsAPrice = (from d in goodsInfoAdd.AddGoodsHospitalPrice
                                              select new GoodsHospitalPriceAddDto
                                              {
                                                  HospitalId = d.HospitalId,
                                                  Price = d.Price
                                              }).ToList();

            goodsInfo.GoodsStandardsPrice = (from d in goodsInfoAdd.GoodsStandardsPrice
                                             select new GoodsStandardsPriceAddDto
                                             {
                                                 Standards = d.Standards,
                                                 Price = d.Price,
                                                 StandardsImg=d.StandardsImg
                                             }).ToList();
            goodsInfo.CarouselImageUrls = (from d in goodsInfoAdd.CarouselImageUrls
                                           select new GoodsInfoCarouselImageAddDto
                                           {
                                               PicUrl = d.PicUrl,
                                               DisplayIndex = d.DisplayIndex
                                           }).ToList();
            //添加会员价格
            goodsInfo.GoodsMemberRankPrice = goodsInfoAdd.AddGoodsMemberRankPrice.Select(e => new GoodsMemberRankPriceAddDto
            {
                MemberRankId = e.MemberRankId,
                Price = e.Price

            }).ToList();
            //添加抵用券
            goodsInfo.GoodsConsumptionVouchers = goodsInfoAdd.AddGoodsConsumptionVoucher.Select(e => new GoodsConsumptionVoucherAddDto
            {
                ConsumptionVoucherId = e.ConsumptionVoucherId
            }).ToList();
            await goodsInfoService.AddAsync(goodsInfo);
            return ResultData.Success();
        }


        /// <summary>
        /// 修改商品信息
        /// </summary>
        /// <param name="goodsInfoUpdate"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(GoodsInfoUpdateVo goodsInfoUpdate)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            GoodsInfoUpdateDto goodsInfo = new GoodsInfoUpdateDto();
            goodsInfo.Id = goodsInfoUpdate.Id;
            goodsInfo.Name = goodsInfoUpdate.Name;
            goodsInfo.Valid = goodsInfoUpdate.Valid;
            goodsInfo.ThumbPicUrl = goodsInfoUpdate.ThumbPicUrl;
            goodsInfo.SimpleCode = goodsInfoUpdate.SimpleCode;
            goodsInfo.Description = goodsInfoUpdate.Description;
            goodsInfo.Standard = goodsInfoUpdate.Standard;
            goodsInfo.Unit = goodsInfoUpdate.Unit;
            goodsInfo.SalePrice = goodsInfoUpdate.SalePrice;
            goodsInfo.InventoryQuantity = goodsInfoUpdate.InventoryQuantity;
            goodsInfo.ExchangeType = goodsInfoUpdate.ExchangeType;
            goodsInfo.IntegrationQuantity = goodsInfoUpdate.IntegrationQuantity;
            goodsInfo.IsMaterial = goodsInfoUpdate.IsMaterial;
            goodsInfo.GoodsType = (byte)GoodsType.General;
            goodsInfo.IsLimitBuy = goodsInfoUpdate.IsLimitBuy;
            goodsInfo.LimitBuyQuantity = goodsInfoUpdate.LimitBuyQuantity;
            goodsInfo.CategoryId = goodsInfoUpdate.CategoryId;
            goodsInfo.UpdateBy = employeeId;
            goodsInfo.GoodsDetailId = goodsInfoUpdate.GoodsDetailId;
            goodsInfo.GoodsDetailHtml = goodsInfoUpdate.GoodsDetailHtml;
            goodsInfo.DetailsDescription = goodsInfoUpdate.DetailsDescription;
            goodsInfo.MaxShowPrice = goodsInfoUpdate.MaxShowPrice;
            goodsInfo.MinShowPrice = goodsInfoUpdate.MinShowPrice;
            goodsInfo.VisitCount = goodsInfoUpdate.VisitCount;
            goodsInfo.ShowSaleCount = goodsInfoUpdate.ShowSaleCount;
            //规格价格
            goodsInfo.GoodsStandardsPrice = (from d in goodsInfoUpdate.UpdateGoodsStandardsPrice
                                             select new GoodsStandardsPriceAddDto
                                             {
                                                 Standards = d.Standards,
                                                 Price = d.Price,
                                                 StandardsImg=d.StandardsImg
                                             }).ToList();
            //医院价格
            goodsInfo.GoodsHospitalsPrice = (from d in goodsInfoUpdate.UpdateGoodsHospitalPrice
                                             select new GoodsHospitalPriceAddDto
                                             {
                                                 HospitalId = d.HospitalId,
                                                 Price = d.Price
                                             }).ToList();
            goodsInfo.CarouselImageUrls = (from d in goodsInfoUpdate.CarouselImageUrls
                                           select new GoodsInfoCarouselImageUpdateDto
                                           {
                                               GoodsInfoId = goodsInfoUpdate.Id,
                                               PicUrl = d.PicUrl,
                                               DisplayIndex = d.DisplayIndex
                                           }).ToList();
            //会员价
            goodsInfo.GoodsMemberRankPrice = goodsInfoUpdate.UpdateGoodsMemberRankPrice.Select(e => new GoodsMemberRankPriceAddDto
            {
                MemberRankId = e.MemberRankId,
                Price = e.Price,
                GoodsId = goodsInfoUpdate.Id
            }).ToList();
            //抵用券
            goodsInfo.GoodsConsumptionVoucher = goodsInfoUpdate.UpdateGoodsConsumptionVoucher.Select(e => new GoodsConsumptionVoucherAddDto
            {
                ConsumptionVoucherId = e.ConsumptionVoucherId,
                GoodsId = goodsInfoUpdate.Id
            }).ToList();
            await goodsInfoService.UpdateAsync(goodsInfo);
            return ResultData.Success();
        }



        /// <summary>
        /// 删除商品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(string id)
        {
            await goodsInfoService.DeleteAsync(id);
            return ResultData.Success();
        }



        /// <summary>
        /// 修改商品信息是否有效
        /// </summary>
        /// <param name="id">商品编号</param>
        /// <param name="valid">是否有效</param>
        /// <returns></returns>
        [HttpPut("valid/{id}/{valid}")]
        public async Task<ResultData> UpdateValidAsync(string id, bool valid)
        {
            await goodsInfoService.UpdateValidAsync(id, valid);
            return ResultData.Success();
        }


        /// <summary>
        /// 获取交易类型列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("exchangeTypeList")]
        public ResultData<List<ExchangeTypeVo>> GetExchangeTypeList()
        {
            var exchangeTypes = from d in goodsInfoService.GetExchangeTypeList()
                                select new ExchangeTypeVo
                                {
                                    ExchangeType = d.ExchangeType,
                                    ExchangeTypeText = d.ExchangeTypeText
                                };
            return ResultData<List<ExchangeTypeVo>>.Success().AddData("exchangeTypes", exchangeTypes.ToList());
        }
    }
}
