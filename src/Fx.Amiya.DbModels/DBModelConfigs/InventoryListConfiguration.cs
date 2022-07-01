using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class InventoryListConfiguration : IEntityTypeConfiguration<InventoryList>
    {
        public void Configure(EntityTypeBuilder<InventoryList> builder)
        {
            builder.ToTable("tbl_inventory_list");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(t => t.WareHouseId).HasColumnName("warehouse_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.InventoryState).HasColumnName("inventory_state").HasColumnType("int").IsRequired();
            builder.Property(t => t.InventoryNum).HasColumnName("inventory_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.InventoryPrice).HasColumnName("inventory_price").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.BeforeInventorySinglePrice).HasColumnName("before_inventory_single_price").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.BeforeInventoryNum).HasColumnName("before_inventory_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.BeforeInventoryAllPrice).HasColumnName("before_inventory_all_price").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.AfterInventorySinglePrice).HasColumnName("after_inventory_single_price").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.AfterInventoryNum).HasColumnName("after_inventory_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.AfterInventoryAllPrice).HasColumnName("after_inventory_all_price").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.CreateBy).HasColumnName("create_by").HasColumnType("int").IsRequired();
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.Remark).HasColumnName("remark").HasColumnType("varchar(500)").IsRequired(false);

            builder.HasOne(e => e.WareHouseInfo).WithMany(e => e.InventoryList).HasForeignKey(e => e.WareHouseId);
            builder.HasOne(e => e.Employee).WithMany(e => e.InventoryList).HasForeignKey(e => e.CreateBy);
        }
    }
}
