using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class OrderWriteOffInfoConfiguration : IEntityTypeConfiguration<OrderWriteOffInfo>
    {
        public void Configure(EntityTypeBuilder<OrderWriteOffInfo> entity)
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
        }
    }
}
