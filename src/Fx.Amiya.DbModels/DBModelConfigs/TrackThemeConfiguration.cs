using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class TrackThemeConfiguration : IEntityTypeConfiguration<TrackTheme>
    {
        public void Configure(EntityTypeBuilder<TrackTheme> builder)
        {
            builder.ToTable("tbl_track_theme");
            builder.HasKey(t => t.Id);
            builder.Property(t=>t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t=>t.Name).HasColumnName("name").HasColumnType("varchar(150)").IsRequired();
            builder.Property(t=>t.TrackTypeId).HasColumnName("track_type_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();

            builder.HasOne(t => t.TrackType).WithMany(t => t.TrackThemeList).HasForeignKey(t=>t.TrackTypeId);
        }
    }
}
