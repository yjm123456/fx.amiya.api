using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("tbl_address");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t => t.CustomerId).HasColumnName("customer_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.Province).HasColumnName("province").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.ProvinceCode).HasColumnName("province_code").HasColumnType("varchar(10)").IsRequired();
            builder.Property(t => t.City).HasColumnName("city").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.CityCode).HasColumnName("city_code").HasColumnType("varchar(10)").IsRequired();
            builder.Property(t => t.District).HasColumnName("district").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.DistrictCode).HasColumnName("district_code").HasColumnType("varchar(10)").IsRequired();
            builder.Property(t => t.Other).HasColumnName("other").HasColumnType("varchar(500)").IsRequired();
            builder.Property(t => t.Phone).HasColumnName("phone").HasColumnType("varchar(20)").IsRequired();
            builder.Property(t => t.Contact).HasColumnName("contact").HasColumnType("varchar(20)").IsRequired();
            builder.Property(t => t.IsDefault).HasColumnName("is_default").HasColumnType("bit").IsRequired();
            builder.Property(t => t.IsDelete).HasColumnName("is_delete").HasColumnType("bit").IsRequired();
            builder.Property(t => t.CreateDate).HasColumnName("crete_date").HasColumnType("datetime").IsRequired();

            builder.HasOne(t => t.CustomerInfo).WithMany(t => t.AddressList).HasForeignKey(t => t.CustomerId);
        }
    }
}
