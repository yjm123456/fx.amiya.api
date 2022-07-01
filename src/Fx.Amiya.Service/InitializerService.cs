using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Fx.Amiya.DbModels.Model;

namespace Fx.Amiya.Service
{
    public class InitializerService : IInitializerService
    {
        private IDalInitializer dalInitializer;
        public InitializerService(IDalInitializer dalInitializer)
        {
            this.dalInitializer = dalInitializer;
        }

        public async Task<bool> GetIsInitializerByTypeAsync(byte type)
        {
            var orderInitializer = await dalInitializer.GetAll().SingleOrDefaultAsync(e => e.Type == type);
            if (orderInitializer == null)
                return true;
            return orderInitializer.IsInitializer;
        }

        public async Task AddAsync(byte type)
        {
            var orderInitializerInfo = await dalInitializer.GetAll().SingleOrDefaultAsync(e => e.Type == type);
            if (orderInitializerInfo != null)
            {
                orderInitializerInfo.IsInitializer = false;
                await dalInitializer.UpdateAsync(orderInitializerInfo,true);
            }
            else
            {
                Initializer orderInitializer = new Initializer();
                orderInitializer.IsInitializer = false;
                orderInitializer.Type = type;
                await dalInitializer.AddAsync(orderInitializer, true);
            }
          
        }
    }
}
