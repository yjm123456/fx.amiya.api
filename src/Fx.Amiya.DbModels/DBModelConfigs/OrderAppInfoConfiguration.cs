using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class OrderAppInfoConfiguration : IEntityTypeConfiguration<OrderAppInfo>
    {
        public void Configure(EntityTypeBuilder<OrderAppInfo> builder)
        {
         
            builder.ToTable("tbl_order_app_info");
            builder.HasKey(t => t.Id);
            builder.Property(t=>t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t => t.ShopId).HasColumnName("shop_id").HasColumnType("varchar(45)").IsRequired(false);
            builder.Property(t=>t.AppKey).HasColumnName("app_key").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t=>t.AppSecret).HasColumnName("app_secret").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t=>t.AccessToken).HasColumnName("access_token").HasColumnType("varchar(200)").IsRequired(false);
            builder.Property(t=>t.AuthorizeDate).HasColumnName("authorize_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.AppType).HasColumnName("app_type").HasColumnType("tinyint").IsRequired();
            builder.Property(t => t.ExpireDate).HasColumnName("expire_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.RefreshToken).HasColumnName("refresh_token").HasColumnType("varchar(200)").IsRequired();
            builder.Property(t => t.BelongLiveAnchor).HasColumnName("belong_liveanchor").HasColumnType("varchar(50)").IsRequired(false);
        }
    }
}
