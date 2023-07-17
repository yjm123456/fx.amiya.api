using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class AmiyaWareHouseConfiguration : IEntityTypeConfiguration<AmiyaWareHouse>
    {
        public void Configure(EntityTypeBuilder<AmiyaWareHouse> builder)
        {
            builder.ToTable("tbl_amiya_warehouse");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(t => t.Unit).HasColumnName("unit").HasColumnType("varchar(45)").IsRequired(false);
            builder.Property(t => t.GoodsName).HasColumnName("goods_name").HasColumnType("VARCHAR(300)").IsRequired();
            builder.Property(t => t.GoodsSourceId).HasColumnName("goods_source_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.StorageRacksId).HasColumnName("storage_racks_id").HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(t => t.SinglePrice).HasColumnName("single_price").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.Amount).HasColumnName("amount").HasColumnType("int").IsRequired();
            builder.Property(t => t.TotalPrice).HasColumnName("total_price").HasColumnType("decimal(12,2)").IsRequired();

            builder.HasOne(e => e.WareHouseNameManage).WithMany(e => e.WareHouse).HasForeignKey(e => e.GoodsSourceId);
        }
    }
}
