using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class AppointmentInfoConfiguration : IEntityTypeConfiguration<AppointmentInfo>
    {
        public void Configure(EntityTypeBuilder<AppointmentInfo> builder)
        {
            builder.ToTable("tbl_appointment_info");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t => t.AppointmentDate).HasColumnName("appointment_date").HasColumnType("date").IsRequired();
            builder.Property(t => t.Week).HasColumnName("week").HasColumnType("varchar(10)").IsRequired();
            builder.Property(t => t.Time).HasColumnName("time").HasColumnType("varchar(10)").IsRequired();
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.SubmitDate).HasColumnName("submit_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.CustomerName).HasColumnName("customer_name").HasColumnType("varchar(200)").IsRequired();
            builder.Property(t => t.CustomerId).HasColumnName("customer_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.Phone).HasColumnName("phone").HasColumnType("varchar(20)").IsRequired();
            builder.Property(t => t.Remark).HasColumnName("remark").HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(t => t.Status).HasColumnName("status").HasColumnType("tinyint").IsRequired();
            builder.Property(t => t.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.AppointArea).HasColumnName("appoint_area").HasColumnType("varchar(200)").IsRequired();
            builder.Property(t => t.ItemInfoName).HasColumnName("item_info_name").HasColumnType("varchar(200)").IsRequired();
            builder.Property(t => t.Address).HasColumnName("address").HasColumnType("varchar(500)").IsRequired(false);

            builder.HasOne(t => t.CustomerInfo).WithMany(t => t.AppointmentInfoList).HasForeignKey(t => t.CustomerId);
            builder.HasOne(t => t.HospitalInfo).WithMany(t => t.AppointmentInfoList).HasForeignKey(t => t.HospitalId);
        }
    } 
}
