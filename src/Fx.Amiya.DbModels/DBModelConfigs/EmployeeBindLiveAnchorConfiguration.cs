using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class EmployeeBindLiveAnchorConfiguration : IEntityTypeConfiguration<EmployeeBindLiveAnchor>
    {
        public void Configure(EntityTypeBuilder<EmployeeBindLiveAnchor> builder)
        {
            builder.ToTable("tbl_employee_bind_liveanchor");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.EmployeeId).HasColumnName("employee_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.LiveAnchorId).HasColumnName("live_anchor_id").HasColumnType("int").IsRequired();
        }
    }
}
