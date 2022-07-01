
using Fx.Amiya.Modules.OrderWriteOff.DbModels;
using Fx.Amiya.Modules.OrderWriteOff.Domin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.OrderWriteOff.Infrastructure.Repositories
{
    public class DbModelConfigurations
    {
        public static void Configuration(IFreeSql freeSql)
        {
            
            freeSql.CodeFirst.Entity<OrderWriteOffDbModel>(entity =>
            {
                entity.ToTable("tbl_order_write_off_info");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(100)").IsRequired();
                entity.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
                entity.Property(t => t.WriteOffOrderId).HasColumnName("write_off_order_id").HasColumnType("VARCHAR(100)").IsRequired();
                entity.Property(t => t.WriteOffAmount).HasColumnName("write_off_amount").HasColumnType("int").IsRequired();
                entity.Property(t => t.OrderLeaseAmount).HasColumnName("order_least_amount").HasColumnType("int").IsRequired();
                entity.Property(t => t.WriteOffGoods).HasColumnName("write_off_goods").HasColumnType("VARCHAR(200)").IsRequired();
                entity.Property(t => t.HospitalId).HasColumnName("write_off_hospitalid").HasColumnType("VARCHAR(50)").IsRequired();
            });
        }

    }
}
