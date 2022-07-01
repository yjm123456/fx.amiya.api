using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class HospitalEnvironmentPictureConfiguration : IEntityTypeConfiguration<HospitalEnvironmentPicture>
    {
        public void Configure(EntityTypeBuilder<HospitalEnvironmentPicture> builder)
        {
            builder.ToTable("tbl_hospital_environment_picture");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.HospitalEnvironmentId).HasColumnName("hospital_environment_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.PictureUrl).HasColumnName("picture_url").HasColumnType("varchar(300)").IsRequired();
        }
    }
}
