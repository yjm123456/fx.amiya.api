using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class TagInfoConfiguration : IEntityTypeConfiguration<TagInfo>
    {
        public void Configure(EntityTypeBuilder<TagInfo> builder)
        {
            builder.ToTable("tbl_tag_info");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t => t.Name).HasColumnName("name").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.Type).HasColumnName("type").HasColumnType("tinyint").IsRequired();
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
        }
    }
}
