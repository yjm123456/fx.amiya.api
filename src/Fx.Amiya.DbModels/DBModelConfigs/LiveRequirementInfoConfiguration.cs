using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class LiveRequirementInfoConfiguration : IEntityTypeConfiguration<LiveRequirementInfo>
    {
        public void Configure(EntityTypeBuilder<LiveRequirementInfo> builder)
        {
            builder.ToTable("tbl_live_requirement_info");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.CreateBy).HasColumnName("create_by").HasColumnType("int").IsRequired();
            builder.Property(t => t.LiveAnchorId).HasColumnName("live_anchor_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.LiveTypeId).HasColumnName("live_type_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.RequirementTypeId).HasColumnName("requirement_type_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.FansInfo).HasColumnName("fans_info").HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(t => t.Description).HasColumnName("description").HasColumnType("varchar(500)").IsRequired();
            builder.Property(t => t.DepartmentId).HasColumnName("department_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.PriorityLevel).HasColumnName("priority_level").HasColumnType("tinyint").IsRequired();
            builder.Property(t => t.Status).HasColumnName("status").HasColumnType("tinyint").IsRequired();
            builder.Property(t => t.ResponseDate).HasColumnName("response_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.ResponseRemark).HasColumnName("response_remark").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.ResponseBy).HasColumnName("response_by").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.DecideDate).HasColumnName("decide_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.DecideBy).HasColumnName("decide_by").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.DecideRemark).HasColumnName("decide_remark").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.ExecuteDate).HasColumnName("execute_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.ExecuteRemark).HasColumnName("execute_remark").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.ExecuteBy).HasColumnName("execute_by").HasColumnType("int").IsRequired(false);

            builder.HasOne(t => t.LiveAnchor).WithMany(t => t.LiveRequirementInfoList).HasForeignKey(t => t.LiveAnchorId);
            builder.HasOne(t => t.LiveType).WithMany(t => t.LiveRequirementInfoList).HasForeignKey(t => t.LiveTypeId);
            builder.HasOne(t => t.RequirementType).WithMany(t => t.LiveRequirementInfoList).HasForeignKey(t => t.RequirementTypeId);
            builder.HasOne(t => t.AmiyaDepartment).WithMany(t => t.LiveRequirementInfoList).HasForeignKey(t => t.DepartmentId);
            builder.HasOne(t => t.CreateAmiyaEmployee).WithMany(t => t.CreateLiveRequirementInfoList).HasForeignKey(t => t.CreateBy);
            builder.HasOne(t => t.ResponseEmployee).WithMany(t => t.ResponseLiveRequirementInfoList).HasForeignKey(t => t.ResponseBy);
            builder.HasOne(t => t.DecideEmployee).WithMany(t => t.DecideLiveRequirementInfoList).HasForeignKey(t => t.DecideBy);
            builder.HasOne(t => t.ExecuteEmployee).WithMany(t => t.ExecuteLiveRequirementInfoList).HasForeignKey(t => t.ExecuteBy);
        }
    }
}
