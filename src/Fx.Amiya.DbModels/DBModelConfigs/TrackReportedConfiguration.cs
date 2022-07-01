using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class TrackReportedConfiguration : IEntityTypeConfiguration<TrackReported>
    {
        public void Configure(EntityTypeBuilder<TrackReported> builder)
        {
            builder.ToTable("tbl_track_reported");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.Phone).HasColumnName("phone").HasColumnType("varchar(11)").IsRequired();
            builder.Property(t => t.SendStatus).HasColumnName("send_status").HasColumnType("int").IsRequired();
            builder.Property(t => t.SendContent).HasColumnName("send_content").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.SendHospitalId).HasColumnName("send_hospital_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.HospitalContent).HasColumnName("hospital_content").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.SendDate).HasColumnName("send_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.SendBy).HasColumnName("send_by").HasColumnType("int").IsRequired();
            builder.Property(t => t.TrackRecordId).HasColumnName("track_record_id").HasColumnType("INT").IsRequired(false);
        }
    }
}
