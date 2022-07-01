using Fx.Amiya.Core.Dto.Goods;
using Fx.Amiya.Core.Dto.OrderWriteOff;
using Fx.Amiya.Core.Interfaces.Goods;
using Fx.Amiya.Core.Interfaces.OrderWriteOff;
using Fx.Amiya.Modules.OrderWriteOff.Domin;
using Fx.Amiya.Modules.OrderWriteOff.Domin.IRepository;
using Fx.Amiya.Modules.OrderWriteOff.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.OrderWriteOff.AppService
{
    public class OrderWriteOffService : IOrderWriteOff
    {
        private IOrderWriteOffRepository _OrderWriteOffRepository;
        private IFreeSql<OrderWriteOffFlag> freeSql;
        public OrderWriteOffService(IOrderWriteOffRepository OrderWriteOffRepository,
              IFreeSql<OrderWriteOffFlag> freeSql)
        {
            _OrderWriteOffRepository = OrderWriteOffRepository;
            this.freeSql = freeSql;
        }

        public async Task AddAsync(OrderWriteOffAddDto goodsInfoAdd)
        {
            OrderWriteOffInfo OrderWriteOff = new OrderWriteOffInfo();
            OrderWriteOff.Id = Guid.NewGuid().ToString();
            OrderWriteOff.HospitalId = goodsInfoAdd.HospitalId;
            OrderWriteOff.CreateDate = goodsInfoAdd.CreateDate;
            OrderWriteOff.WriteOffOrderId = goodsInfoAdd.WriteOffOrderId;
            OrderWriteOff.WriteOffAmount = goodsInfoAdd.WriteOffAmount;
            OrderWriteOff.OrderLeaseAmount = goodsInfoAdd.OrderLeaseAmount;
            OrderWriteOff.WriteOffGoods = goodsInfoAdd.WriteOffGoods;
            await _OrderWriteOffRepository.AddAsync(OrderWriteOff);
        }

        //public async Task DeleteByGoodsId(string goodsId)
        //{
        //    try
        //    {
        //        await _OrderWriteOffRepository.RemoveAsync(goodsId);
        //    }
        //    catch (Exception err)
        //    {
        //        throw new Exception("删除失败");
        //    }
        //}
    }
}
