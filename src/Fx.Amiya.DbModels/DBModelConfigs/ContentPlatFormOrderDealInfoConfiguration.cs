using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class ContentPlatFormOrderDealInfoConfiguration : IEntityTypeConfiguration<ContentPlatformOrderDealInfo>
    {
        public void Configure(EntityTypeBuilder<ContentPlatformOrderDealInfo> builder)
        {
            builder.ToTable("tbl_content_platform_order_deal_info");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.ContentPlatFormOrderId).HasColumnName("content_platform_order_id").HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.IsToHospital).HasColumnName("is_to_hospital").HasColumnType("bit").IsRequired();
            builder.Property(e => e.ToHospitalDate).HasColumnName("to_hospital_date").HasColumnType("DATETIME").IsRequired(false);
            builder.Property(e => e.LastDealHospitalId).HasColumnName("last_deal_hospital_id").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.IsDeal).HasColumnName("is_deal").HasColumnType("bit").IsRequired();
            builder.Property(t => t.DealPicture).HasColumnName("deal_picture").HasColumnType("varchar(200)").IsRequired(false);
            builder.Property(t => t.Remark).HasColumnName("remark").HasColumnType("varchar(200)").IsRequired(false);
            builder.Property(t => t.Price).HasColumnName("price").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(t => t.DealDate).HasColumnName("deal_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.OtherAppOrderId).HasColumnName("other_order_id").HasColumnType("varchar(50)").IsRequired(false);
        }
    }
}
