using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class GiftInfoConfiguration : IEntityTypeConfiguration<GiftInfo>
    {
        public void Configure(EntityTypeBuilder<GiftInfo> builder)
        {
            builder.ToTable("tbl_gift_info");
            builder.HasKey(t => t.Id);
            builder.Property(t=>t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t=>t.Name).HasColumnName("name").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t=>t.ThumbPicUrl).HasColumnName("thumb_pic_url").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t=>t.Quantity).HasColumnName("quantity").HasColumnType("int").IsRequired();
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(t=>t.CreateBy).HasColumnName("create_by").HasColumnType("int").IsRequired();
            builder.Property(t=>t.CreateDate).HasColumnName("create_date").HasColumnType("update_date").IsRequired();
            builder.Property(t=>t.UpdateBy).HasColumnName("update_by").HasColumnType("int").IsRequired(false);
            builder.Property(t=>t.UpdateDate).HasColumnName("update_date").HasColumnType("update_date").IsRequired(false);
            builder.Property(t => t.Version).HasColumnName("version").HasColumnType("int").IsRequired().IsConcurrencyToken();
            builder.Property(t => t.CategoryId).HasColumnName("category_id").HasColumnType("varchar(50)").IsRequired(false);

            builder.HasOne(t=>t.CreateByAmiyaEmplooyee).WithMany(t=>t.CreateByGiftInfoList).HasForeignKey(t=>t.CreateBy);
            builder.HasOne(t=>t.UpdateByAmiyaEmplooyee).WithMany(t=>t.UpdateByGiftInfoList).HasForeignKey(t=>t.UpdateBy);
        }
    }
}
