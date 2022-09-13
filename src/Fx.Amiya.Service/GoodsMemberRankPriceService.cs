using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.MemberRankPrice;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using jos_sdk_net.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class GoodsMemberRankPriceService : IGoodsMemberRankPriceService
    {
        private readonly IDalGoodsMemberRankPrice _dalGoodsMemberRankPrice;

        public GoodsMemberRankPriceService(IDalGoodsMemberRankPrice dalGoodsMemberRankPrice)
        {
            _dalGoodsMemberRankPrice = dalGoodsMemberRankPrice;
        }

        public async Task AddAsync(GoodsMemberRankPriceAddDto goodsMemberRankPriceAddDto)
        {
            GoodsMemberRankPrice goodsMemberRankPrice = new GoodsMemberRankPrice {
                Id = CreateOrderIdHelper.GetNextNumber(),
                GoodsId=goodsMemberRankPriceAddDto.GoodsId,
                MemberRankId = goodsMemberRankPriceAddDto.MemberRankId,
                Price=goodsMemberRankPriceAddDto.Price
            };
            await _dalGoodsMemberRankPrice.AddAsync(goodsMemberRankPrice,true);
        }
        /// <summary>
        /// 根据商品id删除会员价格
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        public async Task DeleteByGoodsIdAsync(string goodsId)
        {

            var list= _dalGoodsMemberRankPrice.GetAll().Where(e => e.GoodsId == goodsId).ToList();
            foreach (var item in list)
            {
                await _dalGoodsMemberRankPrice.DeleteAsync(item,true);
            }
        }

        /// <summary>
        /// 根据商品id获取对应的会员价格列表
        /// </summary>
        /// <param name="goodsId">商品id</param>
        /// <returns></returns>
        public async Task<List<GoodsMemberRankPriceDto>> GetMemeberRankPriceByGoodsIdAsync(string goodsId)
        {
            return _dalGoodsMemberRankPrice.GetAll().Where(e => e.GoodsId == goodsId).Include(e=>e.MemberCardRankInfo).Select(e => new GoodsMemberRankPriceDto
            {
                GoodsId = e.GoodsId,
                MemberRankId = e.MemberRankId,
                Price = e.Price,
                MemberRankName=e.MemberCardRankInfo.Name
            }).ToList();
        }
    }
}
