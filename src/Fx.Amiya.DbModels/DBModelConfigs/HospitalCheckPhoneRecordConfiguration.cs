using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class HospitalCheckPhoneRecordConfiguration : IEntityTypeConfiguration<HospitalCheckPhoneRecord>
    {
        public void Configure(EntityTypeBuilder<HospitalCheckPhoneRecord> builder)
        {
            builder.ToTable("tbl_hospital_check_phone_record");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t => t.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.HospitalEmployeeId).HasColumnName("hospital_employee_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.OrderPlatformType).HasColumnName("order_platformn_type").HasColumnType("tinyint").IsRequired();
            builder.Property(t => t.OrderId).HasColumnName("order_id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t => t.Phone).HasColumnName("phone").HasColumnType("varchar(20)").IsRequired();
            builder.Property(t => t.Date).HasColumnName("date").HasColumnType("datetime").IsRequired();

            builder.HasOne(t => t.HospitalInfo).WithMany(t => t.HospitalCheckPhoneRecordList).HasForeignKey(t=>t.HospitalId);
            builder.HasOne(t => t.HospitalEmployee).WithMany(t => t.HospitalCheckPhoneRecordList).HasForeignKey(t=>t.HospitalEmployeeId);
           
        }
    }
}
