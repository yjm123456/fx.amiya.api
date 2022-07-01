using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class ContentplatformConfiguration : IEntityTypeConfiguration<Contentplatform>
    {
        public void Configure(EntityTypeBuilder<Contentplatform> builder)
        {
            builder.ToTable("tbl_content_platform");
            builder.HasKey(e => e.Id);
            builder.Property(e=>e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e=>e.ContentPlatformName).HasColumnName("content_platform_name").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e=>e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
        }
    }
}
