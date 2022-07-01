using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class HospitalPositionDefaultRouteConfiguration : IEntityTypeConfiguration<HospitalPositionDefaultRoute>
    {
        public void Configure(EntityTypeBuilder<HospitalPositionDefaultRoute> builder)
        {
            builder.ToTable("tbl_hospital_position_default_route");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t => t.HospitalPositionId).HasColumnName("hospital_position_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.Route).HasColumnName("route").HasColumnType("varchar(100)").IsRequired();


            builder.HasOne(t => t.HospitalPositionInfo).WithMany(t => t.HospitalPositionDefaultRouteList).HasForeignKey(t => t.HospitalPositionId);
        }
    }
}
