using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class ContentPlatFormCustomerPictureConfiguration : IEntityTypeConfiguration<ContentPlatFormCustomerPicture>
    {
        public void Configure(EntityTypeBuilder<ContentPlatFormCustomerPicture> builder)
        {
            builder.ToTable("tbl_content_plat_form_customer_picture");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.ContentPlatFormOrderId).HasColumnName("content_plat_form_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.CustomerPicture).HasColumnName("customer_picture").HasColumnType("varchar(300)").IsRequired(false);
            builder.Property(t => t.OrderDealId).HasColumnName("order_deal_id").HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(t => t.Description).HasColumnName("description").HasColumnType("varchar(200)").IsRequired(false);

            builder.HasOne(t => t.ContentPlatFormOrderInfo).WithMany(t => t.CustomerPictureList).HasForeignKey(t => t.ContentPlatFormOrderId);
        }
    }
}
