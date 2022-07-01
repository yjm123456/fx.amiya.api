using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class TrackRecordConfiguration : IEntityTypeConfiguration<TrackRecord>
    {
        public void Configure(EntityTypeBuilder<TrackRecord> builder)
        {
            builder.ToTable("tbl_track_record");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t => t.Phone).HasColumnName("phone").HasColumnType("varchar(20)").IsRequired();
            builder.Property(t => t.TrackDate).HasColumnName("track_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.TrackContent).HasColumnName("track_content").HasColumnType("varchar(500)").IsRequired();
            builder.Property(t => t.TrackPlan).HasColumnName("track_plan").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.TrackTheme).HasColumnName("track_theme").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.TrackTypeId).HasColumnName("track_type_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.TrackThemeId).HasColumnName("track_theme_id").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.TrackToolId).HasColumnName("track_tool_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.EmployeeId).HasColumnName("employee_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(t => t.CallRecordId).HasColumnName("call_record_id").HasColumnType("varchar(50)").IsRequired(false);

           
            builder.HasOne(t => t.TrackType).WithMany(t => t.TrackRecordList).HasForeignKey(t=>t.TrackTypeId);
            builder.HasOne(t => t.TrackTool).WithMany(t => t.TrackRecordList).HasForeignKey(t=>t.TrackToolId);
            builder.HasOne(t => t.AmiyaEmployee).WithMany(t => t.TrackRecordList).HasForeignKey(t=>t.EmployeeId);
            builder.HasOne(t => t.TrackThemeInfo).WithMany(t => t.TrackRecordList).HasForeignKey(t=>t.TrackThemeId);
            
        }
    }
}
