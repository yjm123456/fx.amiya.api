using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class OrderInitializerConfiguration : IEntityTypeConfiguration<Initializer>
    {
        public void Configure(EntityTypeBuilder<Initializer> builder)
        {
            builder.ToTable("tbl_initializer");
            builder.HasKey(t => t.Id);
            builder.Property(t=>t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t=>t.IsInitializer).HasColumnName("is_initializer").HasColumnType("bit").IsRequired();
            builder.Property(t=>t.Type).HasColumnName("type").HasColumnType("tinyint").IsRequired();
        }
    }
}
