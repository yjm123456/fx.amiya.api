using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class HospitalFeedBackConfiguration : IEntityTypeConfiguration<HospitalFeedBack>
    {
        public void Configure(EntityTypeBuilder<HospitalFeedBack> builder)
        {
            builder.ToTable("tbl_hospital_feedback");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.Title).HasColumnName("title").HasColumnType("varchar(100)").IsRequired(false);
            builder.Property(t => t.Content).HasColumnName("content").HasColumnType("varchar(2000)").IsRequired(false);
            builder.Property(t => t.Level).HasColumnName("level").HasColumnType("int").IsRequired();
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.CreateHospital).HasColumnName("create_hospital_id").HasColumnType("int").IsRequired();
        }
    }
}
