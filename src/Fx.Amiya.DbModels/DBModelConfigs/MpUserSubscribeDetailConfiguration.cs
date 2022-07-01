using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class MpUserSubscribeDetailConfiguration : IEntityTypeConfiguration<MpUserSubscribeDetail>
    {
        public void Configure(EntityTypeBuilder<MpUserSubscribeDetail> builder)
        {
            builder.ToTable("tbl_mp_user_subscribe_detail");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("bigint").ValueGeneratedOnAdd();
            builder.Property(t => t.MpUserId).HasColumnName("mp_user_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.AppId).HasColumnName("appid").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.Date).HasColumnName("date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.Subscribe).HasColumnName("subscribe").HasColumnType("bit").IsRequired();

            builder.HasOne(t => t.WxMpUserInfo).WithMany(t => t.SubscribeDetails).HasForeignKey(t => t.MpUserId);
        }
    }
}
