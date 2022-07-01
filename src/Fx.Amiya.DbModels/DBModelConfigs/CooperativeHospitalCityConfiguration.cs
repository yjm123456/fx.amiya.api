using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class CooperativeHospitalCityConfiguration : IEntityTypeConfiguration<CooperativeHospitalCity>
    {
        public void Configure(EntityTypeBuilder<CooperativeHospitalCity> builder)
        {
            builder.ToTable("tbl_cooperative_hospital_city");
            builder.HasKey(e => e.Id);
            builder.Property(e=>e.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(e=>e.Name).HasColumnName("name").HasColumnType("varchar(20)").IsRequired();
            builder.Property(e=>e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.ProvinceId).HasColumnName("province_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.IsHot).HasColumnName("is_hot").HasColumnType("bit").IsRequired();
        }
    }
}
