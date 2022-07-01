using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class HospitalSurplusAppointmentConfiguration : IEntityTypeConfiguration<HospitalSurplusAppointment>
    {
        public void Configure(EntityTypeBuilder<HospitalSurplusAppointment> builder)
        {
            builder.ToTable("tbl_hospital_surplus_appointment");
            builder.HasKey(t => t.Id);
            builder.Property(t=>t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t=>t.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.Property(t=>t.ItemId).HasColumnName("item_id").HasColumnType("int").IsRequired();
            builder.Property(t=>t.ForenoonSurplusQuantity).HasColumnName("forenoon_surplus_quantity").HasColumnType("int").IsRequired();
            builder.Property(t=>t.AfternoonSurplusQuantity).HasColumnName("afternoon_surplus_quantity").HasColumnType("int").IsRequired();
            builder.Property(t=>t.Date).HasColumnName("date").HasColumnType("date").IsRequired();
            builder.Property(t => t.Version).HasColumnName("version").HasColumnType("int").IsRequired().IsConcurrencyToken();


            builder.HasOne(t => t.HospitalInfo).WithMany(t => t.HospitalSurplusAppointmentList).HasForeignKey(t=>t.HospitalId);
        }
    }
}
