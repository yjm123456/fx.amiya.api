﻿
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.GoodsConsumptionVoucher;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using jos_sdk_net.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class GoodsConsumptionVoucherService : IGoodsConsumptionVoucherService
    {
        private IDalGoodsConsumptionVoucher dalGoodsConsumptionVoucher;
        private IDalConsumptionVoucher dalConsumptionVoucher;


        public GoodsConsumptionVoucherService(IDalGoodsConsumptionVoucher dalGoodsConsumptionVoucher, IDalConsumptionVoucher dalConsumptionVoucher)
        {
            this.dalGoodsConsumptionVoucher = dalGoodsConsumptionVoucher;
            this.dalConsumptionVoucher = dalConsumptionVoucher;
        }

        public async Task AddAsync(GoodsConsumptionVoucherAddDto goodsConsumptionVoucherAddDto)
        {
            GoodsConsumptionVoucher goodsConsumptionVoucher = new GoodsConsumptionVoucher {
                Id = CreateOrderIdHelper.GetNextNumber(),
                GoodsId= goodsConsumptionVoucherAddDto.GoodsId,
                ConsumptionVoucherId=goodsConsumptionVoucherAddDto.ConsumptionVoucherId
            };
            await dalGoodsConsumptionVoucher.AddAsync(goodsConsumptionVoucher, true);
        }

        public async Task DeleteByGoodsIdAsync(string goodsId)
        {
            var list = dalGoodsConsumptionVoucher.GetAll().Where(e => e.GoodsId == goodsId).ToList();
            foreach (var item in list)
            {
                await dalGoodsConsumptionVoucher.DeleteAsync(item,true);
            }
        }

        /// <summary>
        /// 根据商品id获取商品可使用的抵用券列表
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        public async Task<List<GoodsConsumptionVoucherDto>> GetGoodsConsumptionVoucherByGoodsIdAsync(string goodsId)
        {           
            var consumptionVoucherList= from c in dalGoodsConsumptionVoucher.GetAll()
            join v in dalConsumptionVoucher.GetAll() on c.ConsumptionVoucherId equals v.Id
            where (c.GoodsId == goodsId || v.IsSpecifyProduct == false)
            select new GoodsConsumptionVoucherDto
            {
                ConsumptionVoucherId=c.ConsumptionVoucherId,
                ConsumptionVoucherName=v.Name
            };
            return consumptionVoucherList.ToList();
        }
    }
}
