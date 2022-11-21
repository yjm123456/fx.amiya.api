using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class CustomerBaseInfoConfiguration : IEntityTypeConfiguration<CustomerBaseInfo>
    {
        public void Configure(EntityTypeBuilder<CustomerBaseInfo> builder)
        {
            builder.ToTable("tbl_customer_base_info");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t => t.Name).HasColumnName("name").HasColumnType("varchar(20)").IsRequired(false);
            builder.Property(t => t.RealName).HasColumnName("real_name").HasColumnType("varchar(45)").IsRequired(false);
            // builder.Property(t => t.Age).HasColumnName("age").HasColumnType("int").IsRequired();
            builder.Property(t => t.Sex).HasColumnName("sex").HasColumnType("char(1)").IsRequired(false);
            builder.Property(t => t.Phone).HasColumnName("phone").HasColumnType("varchar(20)").IsRequired();
            builder.Property(t => t.Birthday).HasColumnName("birthday").HasColumnType("date").IsRequired(false);
            builder.Property(t => t.Occupation).HasColumnName("occupation").HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(t => t.WechatNumber).HasColumnName("wechat_number").HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(t => t.City).HasColumnName("city").HasColumnType("varchar(20)").IsRequired(false);
            builder.Property(t => t.PersonalWechat).HasColumnName("personal_wechat").HasColumnType("bit").IsRequired();
            builder.Property(t => t.BusinessWeChat).HasColumnName("business_wechat").HasColumnType("bit").IsRequired();
            builder.Property(t => t.WechatMiniProgram).HasColumnName("wechat_miniprogram").HasColumnType("bit").IsRequired();
            builder.Property(t => t.OfficialAccounts).HasColumnName("official_accounts").HasColumnType("bit").IsRequired();
            builder.Property(t => t.OtherPhone).HasColumnName("other_phone").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.DetailAddress).HasColumnName("detail_address").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.IsSendNote).HasColumnName("is_send_note").HasColumnType("bit").IsRequired();
            builder.Property(t => t.IsCall).HasColumnName("is_call").HasColumnType("bit").IsRequired();
            builder.Property(t => t.IsSendWeChat).HasColumnName("is_send_wechat").HasColumnType("bit").IsRequired();
            builder.Property(t => t.UnTrackReason).HasColumnName("un_track_reason").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.CustomerState).HasColumnName("customer_state").HasColumnType("int").IsRequired();
            builder.Property(t => t.CustomerRequirement).HasColumnName("customer_requirement").HasColumnType("varchar(100)").IsRequired(false);
        }
    }
}
