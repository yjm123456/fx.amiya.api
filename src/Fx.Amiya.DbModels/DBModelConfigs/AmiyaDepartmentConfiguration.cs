using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class AmiyaDepartmentConfiguration : IEntityTypeConfiguration<AmiyaDepartment>
    {
        public void Configure(EntityTypeBuilder<AmiyaDepartment> builder)
        {
            builder.ToTable("tbl_amiya_department");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t => t.Name).HasColumnName("name").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(t => t.IsProcessingRequirementDepartment).HasColumnName("is_processing_requirement_department").HasColumnType("bit").IsRequired();

        }
    }
}
