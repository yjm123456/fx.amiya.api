using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class HospitalPositionModulePermissionConfiguration : IEntityTypeConfiguration<HospitalPositionModulePermission>
    {
        public void Configure(EntityTypeBuilder<HospitalPositionModulePermission> builder)
        {
            builder.ToTable("tbl_hospital_position_module_permission");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t => t.HospitalPositionId).HasColumnName("hospital_position_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.ModuleCategoryId).HasColumnName("module_category_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.ModuleId).HasColumnName("module_id").HasColumnType("int").IsRequired();


            builder.HasOne(t => t.HospitalPositionInfo).WithMany(t => t.HospitalPositionModulePermissionList).HasForeignKey(t => t.HospitalPositionId);
            builder.HasOne(t => t.ModuleCategory).WithMany(t => t.HospitalPositionModulePermissionList).HasForeignKey(t => t.ModuleCategoryId);
            builder.HasOne(t => t.Module).WithMany(t => t.HospitalPositionModulePermissionList).HasForeignKey(t => t.ModuleId);
        }
    }
}
