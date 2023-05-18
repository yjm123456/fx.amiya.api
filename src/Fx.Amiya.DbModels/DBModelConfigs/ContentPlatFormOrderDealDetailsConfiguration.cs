using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class ContentPlatFormOrderDealDetailsConfiguration : IEntityTypeConfiguration<ContentPlatFormOrderDealDetails>
    {
        public void Configure(EntityTypeBuilder<ContentPlatFormOrderDealDetails> builder)
        {
            builder.ToTable("tbl_content_platform_order_deal_details");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.CreateBy).HasColumnName("create_by").HasColumnType("int").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.GoodsName).HasColumnName("goods_name").HasColumnType("varchar(300)").IsRequired(false);
            builder.Property(e => e.GoodsSpec).HasColumnName("goods_spec").HasColumnType("varchar(45)").IsRequired(false);
            builder.Property(e => e.Quantity).HasColumnName("quantity").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(e => e.Price).HasColumnName("price").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(e => e.ContentPlatFormOrderDealId).HasColumnName("content_platform_order_deal_id").HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(e => e.ContentPlatFormOrderId).HasColumnName("content_platform_order_id").HasColumnType("varchar(50)").IsRequired(false);

        }
    }
}
