using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class ConsumptionLevelConfiguration : IEntityTypeConfiguration<ConsumptionLevel>
    {
        public void Configure(EntityTypeBuilder<ConsumptionLevel> builder)
        {
            builder.ToTable("tbl_consumption_level");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.Name).HasColumnName("name").HasColumnType("varchar(45)").IsRequired();
            builder.Property(t => t.MinPrice).HasColumnName("min_price").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.MaxPrice).HasColumnName("max_price").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
        }
    }
}
