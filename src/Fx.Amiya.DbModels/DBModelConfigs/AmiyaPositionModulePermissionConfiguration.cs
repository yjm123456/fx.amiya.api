using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class AmiyaPositionModulePermissionConfiguration : IEntityTypeConfiguration<AmiyaPositionModulePermission>
    {
        public void Configure(EntityTypeBuilder<AmiyaPositionModulePermission> builder)
        {
            builder.ToTable("tbl_amiya_position_module_permission");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t => t.AmiyaPositionId).HasColumnName("amiya_position_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.ModuleCategoryId).HasColumnName("module_category_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.ModuleId).HasColumnName("module_id").HasColumnType("int").IsRequired();


            builder.HasOne(t => t.AmiyaPositionInfo).WithMany(t => t.PositionModulePermissionList).HasForeignKey(t=>t.AmiyaPositionId);
            builder.HasOne(t => t.ModuleCategory).WithMany(t => t.PositionModulePermissionList).HasForeignKey(t=>t.ModuleCategoryId);
            builder.HasOne(t => t.Module).WithMany(t => t.PositionModulePermissionList).HasForeignKey(t=>t.ModuleId);
        }
    }
}
