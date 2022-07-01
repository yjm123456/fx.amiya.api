using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class WaitTrackCustomerConfiguration : IEntityTypeConfiguration<WaitTrackCustomer>
    {
        public void Configure(EntityTypeBuilder<WaitTrackCustomer> builder)
        {
            builder.ToTable("tbl_wait_track_customer"); 
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t => t.Phone).HasColumnName("phone").HasColumnType("varchar(20)").IsRequired();
            builder.Property(t => t.PlanTrackDate).HasColumnName("plan_track_date").HasColumnType("date").IsRequired();
            builder.Property(t => t.TrackTheme).HasColumnName("track_theme").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.TrackTypeId).HasColumnName("track_type_id").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.TrackPlan).HasColumnName("track_plan").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.TrackThemeId).HasColumnName("track_theme_id").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.CreateBy).HasColumnName("create_by").HasColumnType("int").IsRequired();
            builder.Property(t => t.Status).HasColumnName("status").HasColumnType("bit").IsRequired();
            builder.Property(t => t.TrackRecordId).HasColumnName("track_record_id").HasColumnType("bit").IsRequired(false);
            builder.Property(t => t.PlanTrackEmployeeId).HasColumnName("plan_track_employee_id").HasColumnType("int").IsRequired();

            builder.HasOne(t=>t.CreateEmployee).WithMany(t=>t.CreateWaitTrackCustomerList).HasForeignKey(t=>t.CreateBy);
            builder.HasOne(t=>t.PlanTrackEmployee).WithMany(t=>t.PlanTrackWaitTrackCustomerList).HasForeignKey(t=>t.PlanTrackEmployeeId);
            builder.HasOne(t=>t.TrackType).WithMany(t=>t.WaitTrackCustomerList).HasForeignKey(t=>t.TrackTypeId);
            builder.HasOne(t=>t.TrackThemeInfo).WithMany(t=>t.WaitTrackCustomerList).HasForeignKey(t=>t.TrackThemeId);
            builder.HasOne(t=>t.TrackRecord).WithOne(t=>t.WaitTrackCustomer).HasForeignKey<WaitTrackCustomer>(t=>t.TrackRecordId);
        }
    }
}
