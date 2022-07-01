using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class ActivityItemDetailConfiguration : IEntityTypeConfiguration<ActivityItemDetail>
    {
        public void Configure(EntityTypeBuilder<ActivityItemDetail> builder)
        {
            builder.ToTable("tbl_activity_item_detail");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t => t.ActityId).HasColumnName("activity_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.ItemId).HasColumnName("item_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.SalePrice).HasColumnName("sale_price").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(t => t.LivePrice).HasColumnName("live_price").HasColumnType("decimal(10,2)").IsRequired();
        

            builder.HasOne(t => t.ActivityInfo).WithMany(t => t.ActivityItemDetailList).HasForeignKey(t=>t.ActityId);
            builder.HasOne(t => t.ItemInfo).WithMany(t => t.ActivityItemDetailList).HasForeignKey(t=>t.ItemId);

        }
    }
}
