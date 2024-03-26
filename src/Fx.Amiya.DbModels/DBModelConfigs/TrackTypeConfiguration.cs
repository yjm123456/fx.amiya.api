using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class TrackTypeConfiguration : IEntityTypeConfiguration<TrackType>
    {
        public void Configure(EntityTypeBuilder<TrackType> builder)
        {
            builder.ToTable("tbl_track_type");
            builder.Property(t=>t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t=>t.Name).HasColumnName("name").HasColumnType("varchar(150)").IsRequired();
            builder.Property(t=>t.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(t => t.HasModel).HasColumnName("has_model").HasColumnType("bit").IsRequired();
            builder.Property(t => t.IsOldCustomer).HasColumnName("is_old_customer").HasColumnType("bit").IsRequired();
        }
    }
}
