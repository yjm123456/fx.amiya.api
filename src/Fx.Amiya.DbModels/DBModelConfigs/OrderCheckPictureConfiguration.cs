using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class OrderCheckPictureConfiguration : IEntityTypeConfiguration<OrderCheckPicture>
    {
        public void Configure(EntityTypeBuilder<OrderCheckPicture> builder)
        {
            builder.ToTable("tbl_order_check_picture");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.OrderId).HasColumnName("order_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.OrderFrom).HasColumnName("order_from").HasColumnType("int").IsRequired();
            builder.Property(t => t.PictureUrl).HasColumnName("picture_url").HasColumnType("varchar(300)").IsRequired(false);
        }
    }
}
