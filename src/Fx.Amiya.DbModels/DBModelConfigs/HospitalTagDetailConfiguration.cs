using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class HospitalTagDetailConfiguration : IEntityTypeConfiguration<HospitalTagDetail>
    {
        public void Configure(EntityTypeBuilder<HospitalTagDetail> builder)
        {
            builder.ToTable("tbl_hospital_tag_detail");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t => t.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.TagId).HasColumnName("tag_id").HasColumnType("int").IsRequired();

            builder.HasOne(t => t.HospitalInfo).WithMany(t => t.HospitalTagDetailList).HasForeignKey(t => t.HospitalId);
            builder.HasOne(t => t.TagInfo).WithMany(t => t.HospitalTagDetailList).HasForeignKey(t => t.TagId);
        }
    }
}
