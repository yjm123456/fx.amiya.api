using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class NoticeConfigConfiguration : IEntityTypeConfiguration<NoticeConfig>
    {
        public void Configure(EntityTypeBuilder<NoticeConfig> builder)
        {
            builder.ToTable("tbl_notice_config");
            builder.HasKey(e => e.Id);
            builder.Property(e=>e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e=>e.Name).HasColumnName("name").HasColumnType("varchar(45)").IsRequired();
            builder.Property(e=>e.State).HasColumnName("state").HasColumnType("bit(1)").IsRequired();
        }
    }
}
