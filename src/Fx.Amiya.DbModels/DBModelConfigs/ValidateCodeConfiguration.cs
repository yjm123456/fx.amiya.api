using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class ValidateCodeConfiguration : IEntityTypeConfiguration<ValidateCode>
    {
        public void Configure(EntityTypeBuilder<ValidateCode> builder)
        {
            builder.ToTable("tbl_validate_code");
            builder.HasKey(t => t.Id);
            builder.Property(t=>t.Id).HasColumnName("id").HasColumnType("bigint").IsRequired();
            builder.Property(t=>t.Code).HasColumnName("code").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t=>t.PhoneNumber).HasColumnName("phone_number").HasColumnType("varchar(20)").IsRequired();
            builder.Property(t=>t.ExpiredTime).HasColumnName("expired_time").HasColumnType("datetime").IsRequired();
            builder.Property(t=>t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t=>t.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
        }
    }
}
