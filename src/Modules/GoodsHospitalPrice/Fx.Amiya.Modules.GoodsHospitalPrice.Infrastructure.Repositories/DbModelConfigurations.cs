
using Fx.Amiya.Modules.GoodsHospitalPrice.Domin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.GoodsHospitalPrice.Infrastructure.Repositories
{
    public class DbModelConfigurations
    {
        public static void Configuration(IFreeSql freeSql)
        {
            
            freeSql.CodeFirst.Entity<GoodsHospitalsPriceDbModel>(entity =>
            {
                entity.ToTable("tbl_goods_hospital_price");
                entity.HasKey(t => t.GoodsId);
                entity.Property(t=>t.GoodsId).HasColumnName("goods_id").HasColumnType("varchar(50)").IsRequired();
                entity.Property(t => t.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
                entity.Property(t => t.Price).HasColumnName("price").HasColumnType("decimal(10,2)").IsRequired();
            });

        }

    }
}
