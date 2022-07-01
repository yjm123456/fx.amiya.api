using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class HospitalEnvironmentConfiguration : IEntityTypeConfiguration<HospitalEnvironment>
    {
        public void Configure(EntityTypeBuilder<HospitalEnvironment> builder)
        {
            builder.ToTable("tbl_hospital_environment");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.Name).HasColumnName("name").HasColumnType("varchar(45)").IsRequired();
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
        }
    }
}
