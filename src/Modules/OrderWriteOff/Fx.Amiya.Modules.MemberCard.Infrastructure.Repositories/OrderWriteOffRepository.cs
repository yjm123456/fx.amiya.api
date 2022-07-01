using Fx.Amiya.Modules.OrderWriteOff.DbModels;
using Fx.Amiya.Modules.OrderWriteOff.Domin;
using Fx.Amiya.Modules.OrderWriteOff.Domin.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.OrderWriteOff.Infrastructure.Repositories
{
    public class OrderWriteOffRepository : IOrderWriteOffRepository
    {
        private IFreeSql<OrderWriteOffFlag> freeSql;
        public OrderWriteOffRepository(IFreeSql<OrderWriteOffFlag> freeSql)
        {
            this.freeSql = freeSql;
        }

        public async Task<OrderWriteOffInfo> AddAsync(OrderWriteOffInfo entity)
        {
            OrderWriteOffDbModel OrderWriteOff = new OrderWriteOffDbModel()
            {
                Id = entity.Id,
                HospitalId = entity.HospitalId,
                CreateDate = entity.CreateDate,
                WriteOffOrderId = entity.WriteOffOrderId,
                WriteOffAmount = entity.WriteOffAmount,
                OrderLeaseAmount = entity.OrderLeaseAmount,
                WriteOffGoods=entity.WriteOffGoods
            };

            var res = await freeSql.Insert<OrderWriteOffDbModel>().AppendData(OrderWriteOff).ExecuteIdentityAsync();
            return entity;
        }

      

        public Task<OrderWriteOffInfo> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveAsync(OrderWriteOffInfo entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> RemoveAsync(string id)
        {
            return await freeSql.Delete<OrderWriteOffDbModel>().Where(e => e.Id == id).ExecuteAffrowsAsync();
        }

        public Task<int> UpdateAsync(OrderWriteOffInfo entity)
        {
            throw new NotImplementedException();
        }
    }
}
