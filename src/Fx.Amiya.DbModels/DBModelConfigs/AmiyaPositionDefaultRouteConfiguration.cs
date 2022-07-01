using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class AmiyaPositionDefaultRouteConfiguration : IEntityTypeConfiguration<AmiyaPositionDefaultRoute>
    {
        public void Configure(EntityTypeBuilder<AmiyaPositionDefaultRoute> builder)
        {
            builder.ToTable("tbl_amiya_position_default_route");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t => t.AmiyaPositionId).HasColumnName("amiya_position_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.Route).HasColumnName("route").HasColumnType("varchar(100)").IsRequired();


            builder.HasOne(t => t.AmiyaPositionInfo).WithMany(t => t.PositionDefaultRouteList).HasForeignKey(t=>t.AmiyaPositionId);
        }
    }
}
