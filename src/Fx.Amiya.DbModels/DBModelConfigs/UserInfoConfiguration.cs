using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class UserInfoConfiguration : IEntityTypeConfiguration<UserInfo>
    {
        public void Configure(EntityTypeBuilder<UserInfo> builder)
        {
            builder.ToTable("tbl_user_info");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.CreateFromType).HasColumnName("create_from_type").HasColumnType("tinyint").IsRequired();
            builder.Property(t => t.Frozen).HasColumnName("frozen").HasColumnType("bit").IsRequired();
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(t => t.Country).HasColumnName("country").HasColumnType("varchar(255)").IsRequired(false);
            builder.Property(t => t.Province).HasColumnName("province").HasColumnType("varchar(255)").IsRequired(false);
            builder.Property(t => t.City).HasColumnName("city").HasColumnType("varchar(255)").IsRequired(false);
            builder.Property(t => t.Area).HasColumnName("area").HasColumnType("varchar(255)").IsRequired(false);
            builder.Property(t => t.BirthDay).HasColumnName("birthday").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.Name).HasColumnName("name").HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(t => t.PersonalSignature).HasColumnName("personal_signature").HasColumnType("varchar(255)").IsRequired(false);
            builder.Property(t => t.NickName).HasColumnName("nick_name").HasColumnType("varchar(255)").IsRequired(false);
            builder.Property(t => t.Gender).HasColumnName("gender").HasColumnType("tinyint").IsRequired();
            builder.Property(t => t.Avatar).HasColumnName("avatar").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.Language).HasColumnName("language").HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(t => t.UnionId).HasColumnName("unionid").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.WxBindPhone).HasColumnName("wx_bind_phone").HasColumnType("varchar(20)").IsRequired(false);
            builder.Property(t => t.DetailAddress).HasColumnName("detail_address").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t=>t.SuperiorId).HasColumnName("superior_id").HasColumnType("varchar(50)").IsRequired(false);
        }
    }
}
