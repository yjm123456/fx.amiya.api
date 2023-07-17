using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class AmiyaWareHouseStorageRacksConfiguration : IEntityTypeConfiguration<AmiyaWareHouseStorageRacks>
    {
        public void Configure(EntityTypeBuilder<AmiyaWareHouseStorageRacks> builder)
        {
            builder.ToTable("tbl_amiya_warehouse_storage_racks");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(t => t.WareHouseId).HasColumnName("warehouse_id").HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(t => t.Name).HasColumnName("name").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("DATETIME").IsRequired();
            builder.Property(t => t.CreateBy).HasColumnName("create_by").HasColumnType("int").IsRequired();
            builder.Property(t => t.UpdateDate).HasColumnName("update_date").HasColumnType("DATETIME").IsRequired(false);
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(t => t.DeleteDate).HasColumnName("delete_date").HasColumnType("DATETIME").IsRequired(false);
            builder.HasOne(e => e.WareHouseNameManage).WithMany(e => e.AmiyaWareHouseStorageRacks).HasForeignKey(e => e.WareHouseId);
            builder.HasOne(e => e.AmiyaEmployee).WithMany(e => e.AmiyaWareHouseStorageRacks).HasForeignKey(e => e.CreateBy);
        }
    }
}
