using Fx.Amiya.DbModels.Model;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fx.Infrastructure.DataAccess;
using jos_sdk_net.Util;
using Fx.Amiya.Dto.WareHouse.WareHouseInfo;
using Fx.Amiya.Dto.WareHouse.InventoryList;
using Fx.Amiya.Dto.WareHouse.OutWareHouse;
using Fx.Amiya.Dto.WareHouse.InWareHouse;
using Fx.Amiya.Dto.GoodsStandardsPrice;

namespace Fx.Amiya.Service
{
    public class GoodsStandardsPriceService : IGoodsStandardsPriceService
    {
        private readonly IDalGoodsStandardsPrice dalGoodsStandardsPrice;
        public GoodsStandardsPriceService(IDalGoodsStandardsPrice dalGoodsStandardsPrice)
        {
            this.dalGoodsStandardsPrice = dalGoodsStandardsPrice;
        }

        public async Task AddAsync(GoodsStandardsPriceAddDto goodsInfoAdd)
        {
            GoodsStandardsPrice goodsStandardssPrice = new GoodsStandardsPrice();
            goodsStandardssPrice.Id = Guid.NewGuid().ToString();
            goodsStandardssPrice.GoodsId = goodsInfoAdd.GoodsId;
            goodsStandardssPrice.Standards = goodsInfoAdd.Standards;
            goodsStandardssPrice.Price = goodsInfoAdd.Price;
            await dalGoodsStandardsPrice.AddAsync(goodsStandardssPrice, true);
        }

        public async Task DeleteByGoodsId(string goodsId)
        {
            try
            {
                var hospitalCustomerInfo = from d in dalGoodsStandardsPrice.GetAll()
                                           where (d.GoodsId == goodsId)
                                           select d;
                var deleteResult = await hospitalCustomerInfo.ToListAsync();
                foreach (var x in deleteResult)
                {
                    await dalGoodsStandardsPrice.DeleteAsync(x, true);
                }
            }
            catch (Exception err)
            {
                throw new Exception("删除失败");
            }
        }

        public async Task<List<GoodsStandardsPriceDto>> GetByGoodsId(string goodsId)
        {
            try
            {
                var hospitalCustomerInfo = from d in dalGoodsStandardsPrice.GetAll()
                                           where (d.GoodsId == goodsId)
                                           select new GoodsStandardsPriceDto
                                           {
                                               Id=d.Id,
                                               GoodsId = d.GoodsId,
                                               Standards = d.Standards,
                                               Price = d.Price
                                           };

                List<GoodsStandardsPriceDto> resultList = new List<GoodsStandardsPriceDto>();
                resultList = await hospitalCustomerInfo.ToListAsync();
                return resultList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 根据商品id和规格获取价格
        /// </summary>
        /// <param name="goodsId"></param>
        /// <param name="standards"></param>
        /// <returns></returns>
        public async Task<GoodsStandardsPriceDto> GetByGoodsIdAndHospitalId(string goodsId, string standards)
        {

            var hospitalCustomerInfo = from d in dalGoodsStandardsPrice.GetAll()
                                       where (d.GoodsId == goodsId && d.Standards == standards)
                                       select new GoodsStandardsPriceDto
                                       {
                                           GoodsId = d.GoodsId,
                                           Standards = d.Standards,
                                           Price = d.Price
                                       };
            var result = await hospitalCustomerInfo.FirstOrDefaultAsync();
            return result;
        }
    }
}
