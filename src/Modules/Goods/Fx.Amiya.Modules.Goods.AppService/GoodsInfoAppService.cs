using Fx.Amiya.Core.Dto.Goods;
using Fx.Amiya.Core.Dto.GoodsHospitalPrice;
using Fx.Amiya.Core.Infrastructure;
using Fx.Amiya.Core.Interfaces.Goods;
using Fx.Amiya.Core.Interfaces.GoodsHospitalPrice;
using Fx.Amiya.Dto.GoodsStandardsPrice;
using Fx.Amiya.Dto.MemberRankPrice;
using Fx.Amiya.IService;
using Fx.Amiya.Modules.Goods.DbModel;
using Fx.Amiya.Modules.Goods.Domin;
using Fx.Amiya.Modules.Goods.Domin.IRepository;
using Fx.Amiya.Modules.Goods.Infrastructure.Repositories;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.Goods.AppService
{
    public class GoodsInfoAppService : IGoodsInfo
    {
        private IFreeSql<GoodsFlag> freeSql;
        private IGoodsInfoRepository _goodsInfoRepository;
        private IGoodsStandardsPriceService goodsStandardsPriceService;
        private IGoodsHospitalsPrice _goodsHospitalsPrice;
        private readonly IGoodsMemberRankPriceService goodsMemberRankPriceService;
        private readonly IGoodsConsumptionVoucherService goodsConsumptionVoucherService;
        public GoodsInfoAppService(IFreeSql<GoodsFlag> freeSql,
            IGoodsInfoRepository goodsInfoRepository,
            IGoodsHospitalsPrice goodsHospitalsPrice, IGoodsMemberRankPriceService goodsMemberRankPriceService,
            IGoodsStandardsPriceService goodsStandardsPriceService,
            IGoodsConsumptionVoucherService goodsConsumptionVoucherService)
        {
            this.freeSql = freeSql;
            _goodsInfoRepository = goodsInfoRepository;
            this.goodsStandardsPriceService = goodsStandardsPriceService;
            _goodsHospitalsPrice = goodsHospitalsPrice;
            this.goodsMemberRankPriceService = goodsMemberRankPriceService;
            this.goodsConsumptionVoucherService = goodsConsumptionVoucherService;
        }
        public async Task AddAsync(GoodsInfoAddDto goodsInfoAdd)
        {
            DateTime date = DateTime.Now;
            GoodsInfo goodsInfo = new GoodsInfo();
            goodsInfo.Id = Guid.NewGuid().ToString("N");
            goodsInfo.Name = goodsInfoAdd.Name;
            goodsInfo.ThumbPicUrl = goodsInfoAdd.ThumbPicUrl;
            goodsInfo.SimpleCode = goodsInfoAdd.SimpleCode;
            goodsInfo.Description = goodsInfoAdd.Description;
            goodsInfo.Standard = goodsInfoAdd.Standard;
            goodsInfo.Unit = goodsInfoAdd.Unit;
            goodsInfo.SalePrice = goodsInfoAdd.SalePrice;
            goodsInfo.Valid = true;
            goodsInfo.InventoryQuantity = goodsInfoAdd.InventoryQuantity;
            goodsInfo.ExchangeType = (byte)goodsInfoAdd.ExchangeType;
            goodsInfo.IntegrationQuantity = goodsInfoAdd.IntegrationQuantity;
            goodsInfo.IsMaterial = goodsInfoAdd.IsMaterial;
            goodsInfo.GoodsType = goodsInfoAdd.GoodsType;
            goodsInfo.IsLimitBuy = goodsInfoAdd.IsLimitBuy;
            goodsInfo.LimitBuyQuantity = goodsInfoAdd.LimitBuyQuantity;
            goodsInfo.CreateDate = date;
            goodsInfo.CreateBy = goodsInfoAdd.CreateBy;
            goodsInfo.Version = 0;
            goodsInfo.CategoryId = goodsInfoAdd.CategoryId;
            goodsInfo.DetailsDescription = goodsInfoAdd.DetailsDescription;
            goodsInfo.MaxShowPrice = goodsInfoAdd.MaxShowPrice;
            goodsInfo.MinShowPrice = goodsInfoAdd.MinShowPrice;
            goodsInfo.VisitCount = goodsInfoAdd.VisitCount;
            goodsInfo.ShowSaleCount = goodsInfoAdd.ShowSaleCount;
            goodsInfo.SaleCount = 0;
            goodsInfo.GoodsDetail = new GoodsDetail()
            {
                GoodsDetailHtml = goodsInfoAdd.GoodsDetailHtml,
                CreateBy = goodsInfoAdd.CreateBy,
                CreateDate = date
            };

            goodsInfo.GoodsInfoCarouselImages = (from d in goodsInfoAdd.CarouselImageUrls
                                                 select new GoodsInfoCarouselImage
                                                 {
                                                     GoodsInfoId = goodsInfo.Id,
                                                     CreateDate = date,
                                                     PicUrl = d.PicUrl,
                                                     DisplayIndex = d.DisplayIndex
                                                 }).ToList();

            foreach (var x in goodsInfoAdd.GoodsHospitalsAPrice)
            {
                GoodsHospitalPriceAddDto goodsHospitalPrice = new GoodsHospitalPriceAddDto();
                goodsHospitalPrice.GoodsId = goodsInfo.Id;
                goodsHospitalPrice.HospitalId = x.HospitalId;
                goodsHospitalPrice.Price = x.Price;
                await _goodsHospitalsPrice.AddAsync(goodsHospitalPrice);
            }

            foreach (var x in goodsInfoAdd.GoodsStandardsPrice)
            {
                GoodsStandardsPriceAddDto goodsStandardsPrice = new GoodsStandardsPriceAddDto();
                goodsStandardsPrice.GoodsId = goodsInfo.Id;
                goodsStandardsPrice.Standards = x.Standards;
                goodsStandardsPrice.Price = x.Price;
                await goodsStandardsPriceService.AddAsync(goodsStandardsPrice);
            }
            await _goodsInfoRepository.AddAsync(goodsInfo);
            //添加会员价格
            foreach (var item in goodsInfoAdd.GoodsMemberRankPrice)
            {
                item.GoodsId = goodsInfo.Id;
                await goodsMemberRankPriceService.AddAsync(item);
            }
            //添加抵用券
            foreach (var voucher in goodsInfoAdd.GoodsConsumptionVouchers) {
                voucher.GoodsId = goodsInfo.Id;
                await goodsConsumptionVoucherService.AddAsync(voucher);

            }
        }



        public async Task DeleteAsync(string id)
        {
            try
            {
                await _goodsInfoRepository.RemoveAsync(id);
            }
            catch (Exception)
            {
                throw new Exception("删除失败");
            }
        }



        public async Task<GoodsInfoForSingleDto> GetByIdAsync(string id)
        {
            try
            {
                var goodsInfo = await _goodsInfoRepository.GetByIdAsync(id);
                if (goodsInfo == null)
                {
                    return new GoodsInfoForSingleDto()
                    {
                        CategoryName = "",
                    };
                }
                var goodsHospitalPrice = await _goodsHospitalsPrice.GetByGoodsId(id);
                List<GoodsHospitalPriceDto> goodsHospitalPriceList = new List<GoodsHospitalPriceDto>();
                foreach (var z in goodsHospitalPrice)
                {
                    GoodsHospitalPriceDto goodsHospitalPricedto = new GoodsHospitalPriceDto();
                    goodsHospitalPricedto.GoodsId = id;
                    goodsHospitalPricedto.HospitalId = z.HospitalId;
                    goodsHospitalPricedto.Price = z.Price;
                    goodsHospitalPriceList.Add(goodsHospitalPricedto);
                }
                var goodsStandardsPrice = await goodsStandardsPriceService.GetByGoodsId(id);
                List<GoodsStandardsPriceDto> goodsStandardsPriceList = new List<GoodsStandardsPriceDto>();
                foreach (var z in goodsStandardsPrice)
                {
                    GoodsStandardsPriceDto goodsStandardsPricedto = new GoodsStandardsPriceDto();
                    goodsStandardsPricedto.GoodsId = id;
                    goodsStandardsPricedto.Standards = z.Standards;
                    goodsStandardsPricedto.Price = z.Price;
                    goodsStandardsPriceList.Add(goodsStandardsPricedto);
                }


                //会员价格
                var goodsMemberrankPrice =await goodsMemberRankPriceService.GetMemeberRankPriceByGoodsIdAsync(id);
                //可用抵用券
                var consumptionVoucher = await goodsConsumptionVoucherService.GetGoodsConsumptionVoucherByGoodsIdAsync(id);
                
                GoodsInfoForSingleDto goods = new GoodsInfoForSingleDto()
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
                    ExchangeType = (ExchangeType)goodsInfo.ExchangeType,
                    ExchangeTypeText = exchangeTypeDict[((ExchangeType)goodsInfo.ExchangeType)],
                    IntegrationQuantity = goodsInfo.IntegrationQuantity,
                    ThumbPicUrl = goodsInfo.ThumbPicUrl,
                    IsMaterial = goodsInfo.IsMaterial,
                    GoodsType = goodsInfo.GoodsType,
                    GoodsTypeName = goodsTypeDict[goodsInfo.GoodsType],
                    IsLimitBuy = goodsInfo.IsLimitBuy,
                    LimitBuyQuantity = goodsInfo.LimitBuyQuantity,
                    CategoryId = goodsInfo.CategoryId,
                    CategoryName = goodsInfo.CategoryName,
                    CreateBy = goodsInfo.CreateBy,
                    CreateDate = goodsInfo.CreateDate,
                    UpdateBy = goodsInfo.UpdateBy,
                    UpdatedDate = goodsInfo.UpdatedDate,
                    GoodsDetailId = goodsInfo.GoodsDetail?.Id,
                    GoodsDetailHtml = goodsInfo.GoodsDetail?.GoodsDetailHtml,
                    DetailsDescription = goodsInfo.DetailsDescription,
                    MaxShowPrice = goodsInfo.MaxShowPrice,
                    MinShowPrice = goodsInfo.MinShowPrice,
                    ShowSaleCount = goodsInfo.ShowSaleCount,
                    VisitCount = goodsInfo.VisitCount,
                    GoodsHospitalPrice = goodsHospitalPriceList,
                    GoodsStandardsPrice = goodsStandardsPrice,
                    GoodsMemberRankPrice =goodsMemberrankPrice,
                    CarouselImageUrls = (from d in goodsInfo.GoodsInfoCarouselImages
                                         select new GoodsInfoCarouselImageDto
                                         {
                                             Id = d.Id,
                                             PicUrl = d.PicUrl,
                                             DisplayIndex = d.DisplayIndex
                                         }).ToList(),
                    GoodsConsumptionVoucher= consumptionVoucher
                };
                return goods;
            }
            catch (Exception err)
            {
                return new GoodsInfoForSingleDto()
                {
                    CategoryName = "",
                };
            }
        }

        public async Task<FxPageInfo<GoodsInfoForListDto>> GetListAsync(string keyword, int? exchangeType, int? categoryId, bool? valid, int pageNum, int pageSize)
        {
            var goodsInfos = freeSql.Select<GoodsInfoDbModel>()
                .Include(e => e.GoodsCategory)
                .IncludeMany(e=>e.GoodsMemberRankPriceList)
                .Where(e => string.IsNullOrWhiteSpace(keyword) || e.Name.Contains(keyword) || e.SimpleCode.Contains(keyword) || e.Description.Contains(keyword))
                .Where(e => exchangeType == null || e.ExchangeType == exchangeType)
                .Where(e => categoryId == null || e.CategoryId == categoryId)
                .Where(e => valid == null || e.Valid == valid);
                
            var goodsInfoList = from d in await goodsInfos.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync()
                                select new GoodsInfoForListDto
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
                                    ExchangeType = (ExchangeType)d.ExchangeType,
                                    ExchangeTypeText = exchangeTypeDict[((ExchangeType)d.ExchangeType)],
                                    IntegrationQuantity = d.IntegrationQuantity,
                                    ThumbPicUrl = d.ThumbPicUrl,
                                    IsMaterial = d.IsMaterial,
                                    GoodsType = d.GoodsType,
                                    GoodsTypeName = goodsTypeDict[d.GoodsType],
                                    IsLimitBuy = d.IsLimitBuy,
                                    LimitBuyQuantity = d.LimitBuyQuantity,
                                    CategoryId = d.CategoryId,
                                    CategoryName = d.GoodsCategory.Name,
                                    GoodsDetailId = d.GoodsDetailId,
                                    CreateBy = d.CreateBy,
                                    CreateDate = d.CreateDate,
                                    UpdateBy = d.UpdateBy,
                                    UpdatedDate = d.UpdatedDate,
                                    DetailsDescription = d.DetailsDescription,
                                    MinShowPrice = d.MinShowPrice,
                                    MaxShowPrice = d.MaxShowPrice,
                                    VisitCount = d.VisitCount,
                                    ShowSaleCount = d.ShowSaleCount,
                                    IsMember=d.GoodsMemberRankPriceList.Any()                                                                                                 
                                };
            FxPageInfo<GoodsInfoForListDto> goodsPageInfo = new FxPageInfo<GoodsInfoForListDto>();
            goodsPageInfo.TotalCount = (int)await goodsInfos.CountAsync();
            goodsPageInfo.List = goodsInfoList;
            return goodsPageInfo;
        }

        public async Task<FxPageInfo<GoodsInfoForListDto>> GetLikeListAsync(bool? valid, int pageNum, int pageSize)
        {
            var goodsInfos = freeSql.Select<GoodsInfoDbModel>()
                .Include(e => e.GoodsCategory)
                .IncludeMany(e=>e.GoodsMemberRankPriceList)
                .Where(e => valid == null || e.Valid == valid)
                .Where(e=>e.ExchangeType==1)
                .OrderByDescending(e=>e.SaleCount);
            var goodsInfoList = from d in await goodsInfos.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync() 
                                select new GoodsInfoForListDto
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
                                    ExchangeType = (ExchangeType)d.ExchangeType,
                                    ExchangeTypeText = exchangeTypeDict[((ExchangeType)d.ExchangeType)],
                                    IntegrationQuantity = d.IntegrationQuantity,
                                    ThumbPicUrl = d.ThumbPicUrl,
                                    IsMaterial = d.IsMaterial,
                                    GoodsType = d.GoodsType,
                                    GoodsTypeName = goodsTypeDict[d.GoodsType],
                                    IsLimitBuy = d.IsLimitBuy,
                                    LimitBuyQuantity = d.LimitBuyQuantity,
                                    CategoryId = d.CategoryId,
                                    CategoryName = d.GoodsCategory.Name,
                                    GoodsDetailId = d.GoodsDetailId,
                                    CreateBy = d.CreateBy,
                                    CreateDate = d.CreateDate,
                                    UpdateBy = d.UpdateBy,
                                    UpdatedDate = d.UpdatedDate,
                                    DetailsDescription = d.DetailsDescription,
                                    MinShowPrice = d.MinShowPrice,
                                    MaxShowPrice = d.MaxShowPrice,
                                    VisitCount = d.VisitCount,
                                    ShowSaleCount = d.ShowSaleCount,  
                                    IsMember=d.GoodsMemberRankPriceList.Any()
                                };
            FxPageInfo<GoodsInfoForListDto> goodsPageInfo = new FxPageInfo<GoodsInfoForListDto>();
            goodsPageInfo.TotalCount = (int)await goodsInfos.CountAsync();
            goodsPageInfo.List = goodsInfoList;
            return goodsPageInfo;
        }

        Dictionary<byte, string> goodsTypeDict = new Dictionary<byte, string>()
        {
            { 0,"普通商品"}
        };

        public async Task UpdateAsync(GoodsInfoUpdateDto goodsInfoUpdate)
        {
            DateTime date = DateTime.Now;
            GoodsInfo goodsInfo = new GoodsInfo();
            goodsInfo.Id = goodsInfoUpdate.Id;
            goodsInfo.Name = goodsInfoUpdate.Name;
            goodsInfo.ThumbPicUrl = goodsInfoUpdate.ThumbPicUrl;
            goodsInfo.SimpleCode = goodsInfoUpdate.SimpleCode;
            goodsInfo.Description = goodsInfoUpdate.Description;
            goodsInfo.Standard = goodsInfoUpdate.Standard;
            goodsInfo.Unit = goodsInfoUpdate.Unit;
            goodsInfo.SalePrice = goodsInfoUpdate.SalePrice;
            goodsInfo.Valid = goodsInfoUpdate.Valid;
            goodsInfo.InventoryQuantity = goodsInfoUpdate.InventoryQuantity;
            goodsInfo.ExchangeType = (byte)goodsInfoUpdate.ExchangeType;
            goodsInfo.IntegrationQuantity = goodsInfoUpdate.IntegrationQuantity;
            goodsInfo.IsMaterial = goodsInfoUpdate.IsMaterial;
            goodsInfo.GoodsType = goodsInfoUpdate.GoodsType;
            goodsInfo.IsLimitBuy = goodsInfoUpdate.IsLimitBuy;
            goodsInfo.LimitBuyQuantity = goodsInfoUpdate.LimitBuyQuantity;
            goodsInfo.CategoryId = goodsInfoUpdate.CategoryId;
            goodsInfo.UpdateBy = goodsInfoUpdate.UpdateBy;
            goodsInfo.DetailsDescription = goodsInfoUpdate.DetailsDescription;
            goodsInfo.MaxShowPrice = goodsInfoUpdate.MaxShowPrice;
            goodsInfo.MinShowPrice = goodsInfoUpdate.MinShowPrice;
            goodsInfo.VisitCount = goodsInfoUpdate.VisitCount;
            goodsInfo.ShowSaleCount = goodsInfoUpdate.ShowSaleCount;
            goodsInfo.UpdatedDate = date;
            goodsInfo.GoodsDetail = new GoodsDetail()
            {
                Id = goodsInfoUpdate.GoodsDetailId,
                GoodsDetailHtml = goodsInfoUpdate.GoodsDetailHtml,
                UpdateBy = goodsInfo.UpdateBy
            };
            goodsInfo.GoodsInfoCarouselImages = (from d in goodsInfoUpdate.CarouselImageUrls
                                                 select new GoodsInfoCarouselImage
                                                 {
                                                     PicUrl = d.PicUrl,
                                                     DisplayIndex = d.DisplayIndex,
                                                     GoodsInfoId = d.GoodsInfoId
                                                 }).ToList();
            //移除规格价格
            await goodsStandardsPriceService.DeleteByGoodsId(goodsInfoUpdate.Id);
            //新增门店医院价格
            foreach (var x in goodsInfoUpdate.GoodsStandardsPrice)
            {
                GoodsStandardsPriceAddDto goodsHospitalPrice = new GoodsStandardsPriceAddDto();
                goodsHospitalPrice.GoodsId = goodsInfo.Id;
                goodsHospitalPrice.Standards = x.Standards;
                goodsHospitalPrice.Price = x.Price;
                await goodsStandardsPriceService.AddAsync(goodsHospitalPrice);
            }

            //移除门店医院价格
            await _goodsHospitalsPrice.DeleteByGoodsId(goodsInfoUpdate.Id);
            //新增门店医院价格
            foreach (var x in goodsInfoUpdate.GoodsHospitalsPrice)
            {
                GoodsHospitalPriceAddDto goodsHospitalPrice = new GoodsHospitalPriceAddDto();
                goodsHospitalPrice.GoodsId = goodsInfo.Id;
                goodsHospitalPrice.HospitalId = x.HospitalId;
                goodsHospitalPrice.Price = x.Price;
                await _goodsHospitalsPrice.AddAsync(goodsHospitalPrice);
            }
            await _goodsInfoRepository.UpdateAsync(goodsInfo);
            //移除会员价格
            await goodsMemberRankPriceService.DeleteByGoodsIdAsync(goodsInfoUpdate.Id);
            //新增会员价格
            foreach (var item in goodsInfoUpdate.GoodsMemberRankPrice)
            {
                await goodsMemberRankPriceService.AddAsync(item);
            }
            //移除抵用券
            await goodsConsumptionVoucherService.DeleteByGoodsIdAsync(goodsInfoUpdate.Id);
            //新增抵用券
            foreach (var item in goodsInfoUpdate.GoodsConsumptionVoucher)
            {
                await goodsConsumptionVoucherService.AddAsync(item);
            }
        }



        public async Task UpdateValidAsync(string id, bool valid)
        {
            await freeSql.Update<GoodsInfoDbModel>()
                 .Set(e => e.Valid, valid)
                 .Where(e => e.Id == id)
                 .ExecuteAffrowsAsync();
        }


        /// <summary>
        /// 加商品库存
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public async Task AddGoodsInventoryQuantityAsync(string id, int quantity)
        {
            var goodsInfo = await _goodsInfoRepository.GetByIdAsync(id);
            goodsInfo.AddInventoryQuantity(quantity);
            await _goodsInfoRepository.UpdateAsync(goodsInfo);
        }



        /// <summary>
        /// 减商品库存
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public async Task ReductionGoodsInventoryQuantityAsync(string id, int quantity)
        {
            var goodsInfo = await _goodsInfoRepository.GetByIdAsync(id);
            goodsInfo.ReductionInventoryQuantity(quantity);
            await _goodsInfoRepository.UpdateAsync(goodsInfo);
        }





        /// <summary>
        /// 根据商品编号获取同商品组的所有商品列表
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        public async Task<List<GoodsInfoSimpleDto>> GetGoodsListForGoodsGroupByGoodsIdAsync(string goodsId)
        {
            //现在还没有商品组，直接取商品信息


            var goodsInfo = await _goodsInfoRepository.GetByIdAsync(goodsId);

            GoodsInfoSimpleDto goods = new GoodsInfoSimpleDto();
            goods.Id = goodsInfo.Id;
            goods.Name = goodsInfo.Name;
            goods.Standard = goodsInfo.Standard;
            goods.ThumbPicUrl = goodsInfo.ThumbPicUrl;
            goods.Description = goodsInfo.Description;
            goods.Unit = goodsInfo.Unit;
            goods.SalePrice = goodsInfo.SalePrice;
            goods.IsLimitBuy = goodsInfo.IsLimitBuy;
            goods.LimitBuyQuantity = goodsInfo.LimitBuyQuantity;
            goods.ExchangeType = (ExchangeType)goodsInfo.ExchangeType;
            goods.IntegrationQuantity = goodsInfo.IntegrationQuantity;
            goods.InventoryQuantity = goodsInfo.InventoryQuantity;
            goods.IsMaterial = goodsInfo.IsMaterial;
            goods.Valid = goodsInfo.InventoryQuantity > 0 ? true : false;

            List<GoodsInfoSimpleDto> goodsInfoList = new List<GoodsInfoSimpleDto>();
            goodsInfoList.Add(goods);
            return goodsInfoList;
        }


        public List<ExchangeTypeDto> GetExchangeTypeList()
        {
            var exchangeTypes = Enum.GetValues(typeof(ExchangeType));
            List<ExchangeTypeDto> exchangeTypeList = new List<ExchangeTypeDto>();
            foreach (var item in exchangeTypes)
            {
                ExchangeTypeDto exchangeTypeDto = new ExchangeTypeDto();
                exchangeTypeDto.ExchangeType = Convert.ToByte(item);
                exchangeTypeDto.ExchangeTypeText = exchangeTypeDict[(ExchangeType)item];
                exchangeTypeList.Add(exchangeTypeDto);
            }
            return exchangeTypeList;
        }

        public async Task<FxPageInfo<GoodsInfoForListDto>> GetIntegraListAsync(bool? valid, int pageNum, int pageSize)
        {
            var goodsInfos = freeSql.Select<GoodsInfoDbModel>()
                .Include(e => e.GoodsCategory)
                .Where(e=>e.GoodsCategory.ShowDirectionType==0 && e.GoodsCategory.Valid==valid)
                .Where(e => valid == null || e.Valid == valid)
                .Where(e => e.ExchangeType == 0)
                .OrderByDescending(e => e.SaleCount);

            var goodsInfoList = from d in await goodsInfos.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync()
                                select new GoodsInfoForListDto
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
                                    ExchangeType = (ExchangeType)d.ExchangeType,
                                    ExchangeTypeText = exchangeTypeDict[((ExchangeType)d.ExchangeType)],
                                    IntegrationQuantity = d.IntegrationQuantity,
                                    ThumbPicUrl = d.ThumbPicUrl,
                                    IsMaterial = d.IsMaterial,
                                    GoodsType = d.GoodsType,
                                    GoodsTypeName = goodsTypeDict[d.GoodsType],
                                    IsLimitBuy = d.IsLimitBuy,
                                    LimitBuyQuantity = d.LimitBuyQuantity,
                                    CategoryId = d.CategoryId,
                                    CategoryName = d.GoodsCategory.Name,
                                    GoodsDetailId = d.GoodsDetailId,
                                    CreateBy = d.CreateBy,
                                    CreateDate = d.CreateDate,
                                    UpdateBy = d.UpdateBy,
                                    UpdatedDate = d.UpdatedDate,
                                    DetailsDescription = d.DetailsDescription,
                                    MinShowPrice = d.MinShowPrice,
                                    MaxShowPrice = d.MaxShowPrice,
                                    VisitCount = d.VisitCount,
                                    ShowSaleCount = d.ShowSaleCount
                                };
            FxPageInfo<GoodsInfoForListDto> goodsPageInfo = new FxPageInfo<GoodsInfoForListDto>();
            goodsPageInfo.TotalCount = (int)await goodsInfos.CountAsync();
            goodsPageInfo.List = goodsInfoList;
            return goodsPageInfo;
        }

        public async Task<GoodsInfoForSingleDto> GetSkinCareByCode(string code)
        {
            try
            {
                var goodsInfo = await _goodsInfoRepository.GetGoodsByCode(code);
                if (goodsInfo == null)
                {
                    return new GoodsInfoForSingleDto()
                    {
                        CategoryName = "",
                    };
                }
                var goodsHospitalPrice = await _goodsHospitalsPrice.GetByGoodsId(goodsInfo.Id);
                List<GoodsHospitalPriceDto> goodsHospitalPriceList = new List<GoodsHospitalPriceDto>();
                foreach (var z in goodsHospitalPrice)
                {
                    GoodsHospitalPriceDto goodsHospitalPricedto = new GoodsHospitalPriceDto();
                    goodsHospitalPricedto.GoodsId = goodsInfo.Id;
                    goodsHospitalPricedto.HospitalId = z.HospitalId;
                    goodsHospitalPricedto.Price = z.Price;
                    goodsHospitalPriceList.Add(goodsHospitalPricedto);
                }

                //会员价格
                var goodsMemberrankPrice = await goodsMemberRankPriceService.GetMemeberRankPriceByGoodsIdAsync(goodsInfo.Id);
                //可用抵用券
                var consumptionVoucher = await goodsConsumptionVoucherService.GetGoodsConsumptionVoucherByGoodsIdAsync(goodsInfo.Id);

                GoodsInfoForSingleDto goods = new GoodsInfoForSingleDto()
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
                    ExchangeType = (ExchangeType)goodsInfo.ExchangeType,
                    ExchangeTypeText = exchangeTypeDict[((ExchangeType)goodsInfo.ExchangeType)],
                    IntegrationQuantity = goodsInfo.IntegrationQuantity,
                    ThumbPicUrl = goodsInfo.ThumbPicUrl,
                    IsMaterial = goodsInfo.IsMaterial,
                    GoodsType = goodsInfo.GoodsType,
                    GoodsTypeName = goodsTypeDict[goodsInfo.GoodsType],
                    IsLimitBuy = goodsInfo.IsLimitBuy,
                    LimitBuyQuantity = goodsInfo.LimitBuyQuantity,
                    CategoryId = goodsInfo.CategoryId,
                    CategoryName = goodsInfo.CategoryName,
                    CreateBy = goodsInfo.CreateBy,
                    CreateDate = goodsInfo.CreateDate,
                    UpdateBy = goodsInfo.UpdateBy,
                    UpdatedDate = goodsInfo.UpdatedDate,
                    GoodsDetailId = goodsInfo.GoodsDetail?.Id,
                    GoodsDetailHtml = goodsInfo.GoodsDetail?.GoodsDetailHtml,
                    DetailsDescription = goodsInfo.DetailsDescription,
                    MaxShowPrice = goodsInfo.MaxShowPrice,
                    MinShowPrice = goodsInfo.MinShowPrice,
                    ShowSaleCount = goodsInfo.ShowSaleCount,
                    VisitCount = goodsInfo.VisitCount,
                    GoodsHospitalPrice = goodsHospitalPriceList,
                    GoodsMemberRankPrice = goodsMemberrankPrice,
                    
                    GoodsConsumptionVoucher = consumptionVoucher
                };
                return goods;
            }
            catch (Exception err)
            {
                return new GoodsInfoForSingleDto()
                {
                    CategoryName = "",
                };
            }

        }

        Dictionary<ExchangeType, string> exchangeTypeDict = new Dictionary<ExchangeType, string>()
        {
            { ExchangeType.Integration,"积分支付"},
            { ExchangeType.ThirdPartyPayment,"三方支付"},
            { ExchangeType.OffLinePay,"线下支付"},
            {ExchangeType.BalancePay,"余额支付"},
            {ExchangeType.Wechat,"微信支付"},
            {ExchangeType.Alipay,"支付宝"},
            { ExchangeType.HuiShouQian,"慧收钱"}
        };
    }
}
