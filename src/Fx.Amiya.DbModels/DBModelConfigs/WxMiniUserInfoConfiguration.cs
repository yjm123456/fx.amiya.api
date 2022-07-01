using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class WxMiniUserInfoConfiguration : IEntityTypeConfiguration<WxMiniUserInfo>
    {
        public void Configure(EntityTypeBuilder<WxMiniUserInfo> builder)
        {
            builder.ToTable("tbl_wx_mini_user_info");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.OpenId).HasColumnName("openid").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.AppId).HasColumnName("appid").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.AppPath).HasColumnName("app_path").HasColumnType("varchar(500)").IsRequired();
            builder.Property(t => t.UserId).HasColumnName("userid").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.Scene).HasColumnName("scene").HasColumnType("int").IsRequired();
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.HasOne(t => t.UserInfo).WithMany(t => t.WxMiniUserInfoList).HasForeignKey(t => t.UserId);
        }
    }
}
