using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class PermissionInfoConfiguration : IEntityTypeConfiguration<PermissionInfo>
    {
        public void Configure(EntityTypeBuilder<PermissionInfo> builder)
        {
            builder.ToTable("tbl_permission_info");
            builder.HasKey(t => t.Id);
            builder.Property(t=>t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t=>t.Description).HasColumnName("description").HasColumnType("varchar(30)").IsRequired();
            builder.Property(t=>t.Name).HasColumnName("name").HasColumnType("varchar(50)").IsRequired();
        }
    }
}
