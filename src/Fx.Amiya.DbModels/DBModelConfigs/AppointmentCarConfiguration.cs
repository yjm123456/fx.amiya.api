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
    public class AppointmentCarConfiguration : IEntityTypeConfiguration<AppointmentCar>
    {
        public void Configure(EntityTypeBuilder<AppointmentCar> builder)
        {
            builder.ToTable("tbl_appointment_car");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.CustomerId).HasColumnName("customer_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.Name).HasColumnName("name").HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.Phone).HasColumnName("phone").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.AppointmentDate).HasColumnName("appointment_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.Address).HasColumnName("address").HasColumnType("varchar(500)").IsRequired();
            builder.Property(e => e.Hospital).HasColumnName("hospital").HasColumnType("varchar(500)").IsRequired();
            builder.Property(e => e.CarType).HasColumnName("car_type").HasColumnType("int").IsRequired();
            builder.Property(e => e.ExchangeType).HasColumnName("exchange_type").HasColumnType("int").IsRequired();
            builder.Property(e => e.Status).HasColumnName("status").HasColumnType("int").IsRequired();
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
        }
    }
}
