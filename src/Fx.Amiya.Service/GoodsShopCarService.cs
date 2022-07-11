using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.GoodsShopCar;
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
        public GoodsShopCarService(IDalGoodsShopCar dalGoodsShopCarService)
        {
            this.dalGoodsShopCarService = dalGoodsShopCarService;
        }



        public async Task<FxPageInfo<GoodsShopCarDto>> GetListWithPageAsync(string keyword, string customerId, int pageNum, int pageSize)
        {
            try
            {

                var goodsShopCarService = from d in dalGoodsShopCarService.GetAll()
                                          where (keyword == null || d.GoodsInfo.Name.Contains(keyword))
                                               && (d.CustomerId == customerId)
                                               && (d.Num > 0)
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
                                              UpdateDate = d.UpdateDate,
                                              CreateDate = d.CreateDate,
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
                var isExistGoodsShopCar = await this.GetByGoodsIdAndCustomerIdAsync(addDto.GoodsId, addDto.CustomerId);
                if (!string.IsNullOrEmpty(isExistGoodsShopCar.Id))
                {
                    UpdateGoodsShopCarDto updateDto = new UpdateGoodsShopCarDto();
                    updateDto.Id = isExistGoodsShopCar.Id;
                    updateDto.CustomerId = addDto.CustomerId;
                    updateDto.GoodsId = addDto.GoodsId;
                    updateDto.Num = isExistGoodsShopCar.Num + addDto.Num;
                    await this.UpdateAsync(updateDto);
                }
                else
                {
                    GoodsShopCar goodsShopCar = new GoodsShopCar();
                    goodsShopCar.Id = Guid.NewGuid().ToString();
                    goodsShopCar.CustomerId = addDto.CustomerId;
                    goodsShopCar.GoodsId = addDto.GoodsId;
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
                return goodsShopCarServiceDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public async Task<GoodsShopCarDto> GetByGoodsIdAndCustomerIdAsync(string goodsId, string customerId)
        {
            try
            {
                var goodsShopCarService = await dalGoodsShopCarService.GetAll().FirstOrDefaultAsync(e => e.GoodsId == goodsId && e.CustomerId == customerId);
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
                goodsShopCarService.Num = goodsShopCarService.Num+updateDto.Num;
                goodsShopCarService.UpdateDate = DateTime.Now;
                await dalGoodsShopCarService.UpdateAsync(goodsShopCarService, true);


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
                var goodsShopCarService = await dalGoodsShopCarService.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (goodsShopCarService == null)
                    throw new Exception("入库编号错误");

                await dalGoodsShopCarService.DeleteAsync(goodsShopCarService, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
