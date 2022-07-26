using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class TrackTypeThemeModelConfiguration : IEntityTypeConfiguration<TrackTypeThemeModel>
    {
        public void Configure(EntityTypeBuilder<TrackTypeThemeModel> builder)
        {
            builder.ToTable("tbl_track_type_theme_model");
            builder.HasKey(t => t.Id);
            builder.Property(t=>t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.TrackTypeId).HasColumnName("track_type_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.TrackThemeId).HasColumnName("track_theme_id").HasColumnType("int").IsRequired();
            builder.Property(t=>t.DaysLater).HasColumnName("days_later").HasColumnType("days_later").IsRequired();
            builder.Property(t => t.TrackPlan).HasColumnName("track_plan").HasColumnType("varchar(100)").IsRequired(false);
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();

            builder.HasOne(t => t.TrackType).WithMany(t => t.TrackTypeModel).HasForeignKey(t=>t.TrackTypeId);
            builder.HasOne(t => t.TrackTheme).WithMany(t => t.TrackThemeModel).HasForeignKey(t => t.TrackThemeId);
        }
    }
}
