using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class WxAppInfoConfiguration : IEntityTypeConfiguration<WxAppInfo>
    {
        public void Configure(EntityTypeBuilder<WxAppInfo> builder)
        {
            builder.ToTable("tbl_wx_app_info");
            builder.HasKey(t => t.WxAppId);
            builder.Property(t => t.WxAppId).HasColumnName("wx_appid").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.AppSecret).HasColumnName("app_secret").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.Description).HasColumnName("description").HasColumnType("varchar(255)").IsRequired(false);
            builder.Property(t => t.AppName).HasColumnName("app_name").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.Type).HasColumnName("type").HasColumnType("tinyint").IsRequired();
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();

            builder.Property(t => t.GrantType).HasColumnName("grant_type").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.AccountId).HasColumnName("account_id").HasColumnType("varchar(50)").IsRequired();
        }
    }
}
