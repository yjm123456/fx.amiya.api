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
           // builder.Property(t => t.Age).HasColumnName("age").HasColumnType("int").IsRequired();
            builder.Property(t => t.Sex).HasColumnName("sex").HasColumnType("char(1)").IsRequired(false);
            builder.Property(t => t.Phone).HasColumnName("phone").HasColumnType("varchar(20)").IsRequired();
            builder.Property(t => t.Birthday).HasColumnName("birthday").HasColumnType("date").IsRequired(false);
            builder.Property(t => t.Occupation).HasColumnName("occupation").HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(t => t.WechatNumber).HasColumnName("wechat_number").HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(t => t.City).HasColumnName("city").HasColumnType("varchar(20)").IsRequired(false);
        }
    }
}
