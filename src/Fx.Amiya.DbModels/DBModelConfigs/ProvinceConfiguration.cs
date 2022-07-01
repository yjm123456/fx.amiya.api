using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.ToTable("tbl_province");
            builder.HasKey(e => e.Id);
            builder.Property(e=>e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e=>e.Name).HasColumnName("name").HasColumnType("varchar(20)").IsRequired();
            builder.Property(e=>e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
        }
    }
}
