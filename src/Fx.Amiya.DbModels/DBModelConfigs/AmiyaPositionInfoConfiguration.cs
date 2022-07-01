using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class AmiyaPositionInfoConfiguration : IEntityTypeConfiguration<AmiyaPositionInfo>
    {
        public void Configure(EntityTypeBuilder<AmiyaPositionInfo> builder)
        {
            builder.ToTable("tbl_amiya_position_info");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t => t.Name).HasColumnName("name").HasColumnType("varchar(150)").IsRequired();
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.UpdateBy).HasColumnName("update_by").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.IsDirector).HasColumnName("is_director").HasColumnType("bit").IsRequired();
            builder.Property(t => t.DepartmentId).HasColumnName("department_id").HasColumnType("int").IsRequired();


            builder.HasOne(t => t.UpdateByAmiyaEmployee).WithMany(t => t.UpdateByAmiyaPositionInfoList).HasForeignKey(t=>t.UpdateBy);
            builder.HasOne(t => t.AmiyaDepartment).WithMany(t => t.AmiyaPositionInfoList).HasForeignKey(t=>t.DepartmentId);
        }
    }
}
