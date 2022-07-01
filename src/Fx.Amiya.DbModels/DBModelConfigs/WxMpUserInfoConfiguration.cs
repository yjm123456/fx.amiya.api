using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class WxMpUserInfoConfiguration : IEntityTypeConfiguration<WxMpUserInfo>
    {
        public void Configure(EntityTypeBuilder<WxMpUserInfo> builder)
        {
            builder.ToTable("tbl_wx_mp_user_info");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.OpenId).HasColumnName("openid").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.AppId).HasColumnName("appid").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.IsSubscribed).HasColumnName("is_subscribed").HasColumnType("bit").IsRequired();
            builder.Property(t => t.UserId).HasColumnName("userid").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.SubscribeScene).HasColumnName("subscribe_scene").HasColumnType("varchar(255)").IsRequired();
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.SubscribeCount).HasColumnName("subscribe_count").HasColumnType("int").IsRequired();
            builder.Property(t => t.SubscribeTime).HasColumnName("subscribe_time").HasColumnType("int").IsRequired();
            builder.Property(t => t.SubscribeDateTime).HasColumnName("subscribe_datetime").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.Remark).HasColumnName("remark").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.GroupId).HasColumnName("groupid").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.TagIdList).HasColumnName("tagid_list").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.QrScene).HasColumnName("qr_scene").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.QrSceneStr).HasColumnName("qr_scene_str").HasColumnType("varchar(255)").IsRequired(false);
            builder.HasOne(t => t.UserInfo).WithMany(t => t.WxMpUserInfoList).HasForeignKey(t => t.UserId);
        }
    }
}
