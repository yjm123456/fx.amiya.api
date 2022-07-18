using Fx.Amiya.Modules.GoodsShopCar.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.GoodsShopCar.Infrastructure.Repositories
{
    public class DbModelConfigurations
    {
        public static void Configuration(IFreeSql freeSql)
        {
            freeSql.CodeFirst.Entity<GoodsShopCarDdModel>(entity =>
            {
                entity.ToTable("tbl_goods_shopcar");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
                entity.Property(t => t.CustomerId).HasColumnName("customer_id").HasColumnType("varchar(50)").IsRequired();
                entity.Property(t => t.GoodsId).HasColumnName("goods_id").HasColumnType("varchar(150)").IsRequired();
                entity.Property(t => t.Num).HasColumnName("num").HasColumnType("int");
                entity.Property(t => t.Status).HasColumnName("status").HasColumnType("bit").IsRequired();
                entity.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
                entity.Property(t => t.UpdateDate).HasColumnName("update_date").HasColumnType("datetime");
                entity.Property(t => t.CityId).HasColumnName("city_id").HasColumnType("int");
                entity.Property(t=>t.HospitalId).HasColumnName("hospital_id").HasColumnType("int");
            });
        }
    }
}
