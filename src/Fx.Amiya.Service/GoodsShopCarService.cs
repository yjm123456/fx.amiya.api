using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.GoodsShopCar;
using Fx.Amiya.Dto.MemberRankPrice;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class GoodsShopCarService : IGoodsShopCarService
    {
        private IDalGoodsShopCar dalGoodsShopCarService;
        private IDalGoodsHospitalPrice dalGoodsHospitalPrice;
        private IDalGoodsStandardsPrice dalGoodsStandardsPrice;
        public GoodsShopCarService(IDalGoodsShopCar dalGoodsShopCarService,
            IDalGoodsStandardsPrice dalGoodsStandardsPrice,
            IDalGoodsHospitalPrice dalGoodsHospitalPrice)
        {
            this.dalGoodsShopCarService = dalGoodsShopCarService;
            this.dalGoodsHospitalPrice = dalGoodsHospitalPrice;
            this.dalGoodsStandardsPrice = dalGoodsStandardsPrice;
        }



        public async Task<FxPageInfo<GoodsShopCarDto>> GetListWithPageAsync(string keyword, string customerId, int pageNum, int pageSize)
        {
            try
            {

                var goodsShopCarService = from d in dalGoodsShopCarService.GetAll().Include(e => e.GoodsInfo).ThenInclude(e => e.GoodsMemberRankPrice)
                                          where (keyword == null || d.GoodsInfo.Name.Contains(keyword))
                                               && (d.CustomerId == customerId)
                                               && (d.Status == 1)
                                               && (d.Num > 0)
                                          orderby d.CreateDate descending
                                          select new GoodsShopCarDto
                                          {
                                              Id = d.Id,
                                              CustomerId = d.CustomerId,
                                              GoodsId = d.GoodsId,
                                              GoodsName = d.GoodsInfo.Name,
                                              Unit = d.GoodsInfo.Unit,
                                              Price = d.GoodsInfo.SalePrice * d.Num,
                                              InterGrationAccount = d.GoodsInfo.IntegrationQuantity,
                                              ExchangeType = d.GoodsInfo.ExchangeType,
                                              Num = d.Num,
                                              Status = d.Status,
                                              GoodsPictureUrl = d.GoodsInfo.ThumbPicUrl,
                                              UpdateDate = d.UpdateDate,
                                              CreateDate = d.CreateDate,
                                              HospitalId = d.HospitalId,
                                              Hospital = d.HospitalId.HasValue ? d.HospitalInfo.Name : "",
                                              CityId = d.CityId,
                                              City = d.CityId.HasValue ? d.City.Name : "",
                                              IsMaterial = d.GoodsInfo.IsMaterial,
                                              HospitalSalePrice = d.GoodsInfo.IsMaterial ? 0 : dalGoodsHospitalPrice.GetAll().Where(e => e.GoodsId == d.GoodsId && e.HospitalId == d.HospitalId).FirstOrDefault().Price * d.Num,
                                              GoodsMemberRankPriceList = d.GoodsInfo.GoodsMemberRankPrice.Select(e => new GoodsMemberRankPriceDto
                                              {
                                                  MemberRankId = e.MemberRankId,
                                                  Price = e.Price
                                              }).ToList()
                                          };
                FxPageInfo<GoodsShopCarDto> goodsShopCarServicePageInfo = new FxPageInfo<GoodsShopCarDto>();
                goodsShopCarServicePageInfo.TotalCount = await goodsShopCarService.CountAsync();
                goodsShopCarServicePageInfo.List = await goodsShopCarService.OrderByDescending(x => x.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
                return goodsShopCarServicePageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task AddAsync(AddGoodsShopCarDto addDto)
        {
            try
            {
                var isExistGoodsShopCar = await this.GetByGoodsIdAndCustomerIdAsync(addDto.GoodsId, addDto.CustomerId, addDto.HospitalId, addDto.CityId);
                if (!string.IsNullOrEmpty(isExistGoodsShopCar.Id))
                {
                    if (isExistGoodsShopCar.Status == 0)
                    {
                        var goodsShopCarService = await dalGoodsShopCarService.GetAll().SingleOrDefaultAsync(e => e.Id == isExistGoodsShopCar.Id);
                        if (goodsShopCarService == null)
                            throw new Exception("购物车编号错误");

                        goodsShopCarService.Status = 1;
                        goodsShopCarService.Num = addDto.Num;
                        await dalGoodsShopCarService.UpdateAsync(goodsShopCarService, true);
                    }
                    else
                    {
                        UpdateGoodsShopCarDto updateDto = new UpdateGoodsShopCarDto();
                        updateDto.Id = isExistGoodsShopCar.Id;
                        updateDto.CustomerId = addDto.CustomerId;
                        updateDto.GoodsId = addDto.GoodsId;
                        updateDto.CityId = addDto.CityId;
                        updateDto.HospitalId = addDto.HospitalId;
                        updateDto.Num = isExistGoodsShopCar.Num + addDto.Num;
                        await this.UpdateAsync(updateDto);
                    }

                }
                else
                {
                    GoodsShopCar goodsShopCar = new GoodsShopCar();
                    goodsShopCar.Id = Guid.NewGuid().ToString();
                    goodsShopCar.CustomerId = addDto.CustomerId;
                    goodsShopCar.GoodsId = addDto.GoodsId;
                    goodsShopCar.CityId = addDto.CityId;
                    goodsShopCar.HospitalId = addDto.HospitalId;
                    goodsShopCar.Num = addDto.Num;
                    goodsShopCar.Status = 1;
                    goodsShopCar.CreateDate = DateTime.Now;
                    goodsShopCar.UpdateDate = DateTime.Now;
                    await dalGoodsShopCarService.AddAsync(goodsShopCar, true);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GoodsShopCarDto> GetByIdAsync(string id)
        {
            try
            {
                var goodsShopCarService = await dalGoodsShopCarService.GetAll().Include(x => x.GoodsInfo).FirstOrDefaultAsync(e => e.Id == id);
                if (goodsShopCarService == null)
                {
                    return new GoodsShopCarDto();
                }

                GoodsShopCarDto goodsShopCarServiceDto = new GoodsShopCarDto();
                goodsShopCarServiceDto.Id = goodsShopCarService.Id;
                goodsShopCarServiceDto.CustomerId = goodsShopCarService.CustomerId;
                goodsShopCarServiceDto.GoodsId = goodsShopCarService.GoodsId;
                goodsShopCarServiceDto.GoodsName = goodsShopCarService.GoodsInfo.Name;
                goodsShopCarServiceDto.Unit = goodsShopCarService.GoodsInfo.Unit;
                goodsShopCarServiceDto.Price = goodsShopCarService.GoodsInfo.SalePrice;
                goodsShopCarServiceDto.InterGrationAccount = goodsShopCarService.GoodsInfo.IntegrationQuantity;
                goodsShopCarServiceDto.ExchangeType = goodsShopCarService.GoodsInfo.ExchangeType;
                goodsShopCarServiceDto.Num = goodsShopCarService.Num;
                goodsShopCarServiceDto.Status = goodsShopCarService.Status;
                goodsShopCarServiceDto.UpdateDate = goodsShopCarService.UpdateDate;
                goodsShopCarServiceDto.CreateDate = goodsShopCarService.CreateDate;
                goodsShopCarServiceDto.CityId = goodsShopCarService.CityId;
                goodsShopCarServiceDto.HospitalId = goodsShopCarService.HospitalId;
                return goodsShopCarServiceDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public async Task<GoodsShopCarDto> GetByGoodsIdAndCustomerIdAsync(string goodsId, string customerId, int? HospitalId, int? CityId)
        {
            try
            {
                var goodsShopCarService = await dalGoodsShopCarService.GetAll().FirstOrDefaultAsync(e => e.GoodsId == goodsId && e.CustomerId == customerId && (HospitalId == null || e.HospitalId == HospitalId) && (CityId == null || e.CityId == CityId));
                if (goodsShopCarService == null)
                {
                    return new GoodsShopCarDto();
                }

                GoodsShopCarDto goodsShopCarServiceDto = new GoodsShopCarDto();
                goodsShopCarServiceDto.Id = goodsShopCarService.Id;
                goodsShopCarServiceDto.CustomerId = goodsShopCarService.CustomerId;
                goodsShopCarServiceDto.GoodsId = goodsShopCarService.GoodsId;
                goodsShopCarServiceDto.Num = goodsShopCarService.Num;
                goodsShopCarServiceDto.Status = goodsShopCarService.Status;
                goodsShopCarServiceDto.UpdateDate = goodsShopCarService.UpdateDate;
                goodsShopCarServiceDto.CreateDate = goodsShopCarService.CreateDate;
                goodsShopCarServiceDto.CityId = goodsShopCarService.CityId;
                goodsShopCarServiceDto.HospitalId = goodsShopCarService.HospitalId;
                return goodsShopCarServiceDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task UpdateAsync(UpdateGoodsShopCarDto updateDto)
        {
            try
            {
                var goodsShopCarService = await dalGoodsShopCarService.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (goodsShopCarService == null)
                    throw new Exception("购物车编号错误！");
                goodsShopCarService.CustomerId = updateDto.CustomerId;
                goodsShopCarService.GoodsId = updateDto.GoodsId;
                goodsShopCarService.Num = updateDto.Num;
                goodsShopCarService.UpdateDate = DateTime.Now;
                goodsShopCarService.CityId = updateDto.CityId;
                goodsShopCarService.HospitalId = updateDto.HospitalId;
                await dalGoodsShopCarService.UpdateAsync(goodsShopCarService, true);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task DeleteAsync(List<string> id)
        {
            try
            {
                foreach (var x in id)
                {
                    var goodsShopCarService = await dalGoodsShopCarService.GetAll().SingleOrDefaultAsync(e => e.Id == x);
                    if (goodsShopCarService == null)
                        throw new Exception("购物车编号错误");

                    goodsShopCarService.Status = 0;
                    goodsShopCarService.Num = 0;
                    await dalGoodsShopCarService.UpdateAsync(goodsShopCarService, true);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
