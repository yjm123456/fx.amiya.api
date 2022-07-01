using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class AmiyaHospitalDepartmentConfiguration : IEntityTypeConfiguration<AmiyaHospitalDepartment>
    {
        public void Configure(EntityTypeBuilder<AmiyaHospitalDepartment> builder)
        {
            builder.ToTable("tbl_amiya_hospital_department");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.DepartmentName).HasColumnName("department_name").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t => t.Description).HasColumnName("description").HasColumnType("varchar(200)").IsRequired(false);
            builder.Property(t => t.Sort).HasColumnName("sort").HasColumnType("int").IsRequired();
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
        }
    }
}
