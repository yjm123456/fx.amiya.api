using Fx.Amiya.DbModels;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.IDal;
using Fx.Infrastructure.DataAccess.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dal
{
    public class DalContentPlatFormCustomerPicture : DalEFCore<ContentPlatFormCustomerPicture>, IDalContentPlatFormCustomerPicture
    {
        public DalContentPlatFormCustomerPicture(AmiyaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
