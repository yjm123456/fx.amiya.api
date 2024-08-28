using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class HospitalContentplatformCodeConfiguration : IEntityTypeConfiguration<HospitalContentplatformCode>
    {
        public void Configure(EntityTypeBuilder<HospitalContentplatformCode> builder)
        {
            builder.ToTable("tbl_hospital_contentplatform_code");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.HospitalId).HasColumnName("hospital_id").HasColumnType("INT").IsRequired();
            builder.Property(e => e.ThirdPartContentplatformInfoId).HasColumnName("third_part_contentplatform").HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(e => e.Code).HasColumnName("code").HasColumnType("VARCHAR(45)").IsRequired(false);

            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("DATETIME").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("DATETIME").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("BIT(1)").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("DATETIME").IsRequired(false);


            builder.HasOne(t => t.HospitalInfo).WithMany(t => t.HospitalContentplatformCodeList).HasForeignKey(t => t.HospitalId);
            builder.HasOne(t => t.ThirdPartContentplatformInfo).WithMany(t => t.HospitalContentplatformCodeList).HasForeignKey(t => t.ThirdPartContentplatformInfoId);
        }
    }
}
