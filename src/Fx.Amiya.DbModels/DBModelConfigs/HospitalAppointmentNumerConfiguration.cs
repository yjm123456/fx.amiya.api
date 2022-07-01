using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class HospitalAppointmentNumerConfiguration : IEntityTypeConfiguration<HospitalAppointmentNumer>
    {
        public void Configure(EntityTypeBuilder<HospitalAppointmentNumer> builder)
        {
            builder.ToTable("tbl_hospital_appointment_numer");
            builder.HasKey(t => t.Id);
            builder.Property(t=>t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t=>t.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.Property(t=>t.ForenoonCanAppointmentNumer).HasColumnName("forenoon_can_appointment_numer").HasColumnType("int").IsRequired();
            builder.Property(t=>t.AfternoonCanAppointmentNumer).HasColumnName("afternoon_can_appointment_numer").HasColumnType("int").IsRequired();

            builder.HasOne(t => t.HospitalInfo).WithMany(t => t.HospitalAppointmentNumerList).HasForeignKey(t=>t.HospitalId);
        }
    }
}
