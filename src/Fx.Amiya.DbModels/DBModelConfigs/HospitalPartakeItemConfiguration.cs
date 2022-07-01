using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class HospitalPartakeItemConfiguration : IEntityTypeConfiguration<HospitalPartakeItem>
    {
        public void Configure(EntityTypeBuilder<HospitalPartakeItem> builder)
        {
            builder.ToTable("tbl_hospital_partake_item");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("int").IsRequired() ;
            builder.Property(t => t.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired() ;
            builder.Property(t => t.ActivityId).HasColumnName("activity_id").HasColumnType("int").IsRequired() ;
            builder.Property(t => t.ItemId).HasColumnName("item_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.IsAgreeLivingPrice).HasColumnName("is_agree_living_price").HasColumnType("BIT(1)").IsRequired();
            builder.Property(t => t.HospitalPrice).HasColumnName("hospital_price").HasColumnType("DECIMAL(10,2)").IsRequired();
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired() ;
            builder.Property(t => t.ForenoonCanAppointmentQuantity).HasColumnName("forenoon_can_appointment_quantity").HasColumnType("int").IsRequired() ;
            builder.Property(t => t.AfternoonCanAppointmentQuantity).HasColumnName("afternoon_can_appointment_quantity").HasColumnType("int").IsRequired() ;
       
            builder.HasOne(t => t.HospitalInfo).WithMany(t => t.HospitalPartakeItemList).HasForeignKey(t => t.HospitalId);
            builder.HasOne(t => t.ActivityInfo).WithMany(t => t.HospitalPartakeItemList).HasForeignKey(t => t.ActivityId);
            builder.HasOne(t => t.ItemInfo).WithMany(t => t.HospitalPartakeItemList).HasForeignKey(t=>t.ItemId);
        }
    }
}
