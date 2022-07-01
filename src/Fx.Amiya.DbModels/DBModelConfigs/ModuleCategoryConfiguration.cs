using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class ModuleCategoryConfiguration : IEntityTypeConfiguration<ModuleCategory>
    {
        public void Configure(EntityTypeBuilder<ModuleCategory> builder)
        {
            builder.ToTable("tbl_module_category");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(e => e.Name).HasColumnName("name").HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.Description).HasColumnName("description").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.Path).HasColumnName("path").HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.Sort).HasColumnName("sort").HasColumnType("int").IsRequired();
        }
    }
}
