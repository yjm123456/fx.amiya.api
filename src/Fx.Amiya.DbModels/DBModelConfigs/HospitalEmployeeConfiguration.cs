using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class HospitalEmployeeConfiguration : IEntityTypeConfiguration<HospitalEmployee>
    {
        public void Configure(EntityTypeBuilder<HospitalEmployee> builder)
        {
            builder.ToTable("tbl_hospital_employee");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t => t.Name).HasColumnName("name").HasColumnType("varchar(150)").IsRequired();
            builder.Property(t => t.UserName).HasColumnName("user_name").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.Password).HasColumnName("password").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(t => t.IsCreateSubAccount).HasColumnName("is_create_sub_account").HasColumnType("bit").IsRequired();
            builder.Property(t => t.HospitalPositionId).HasColumnName("hospital_position_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.IsCustomerService).HasColumnName("is_customer_service").HasColumnType("bit").IsRequired();


            builder.HasOne(t => t.HospitalInfo).WithMany(t => t.HospitalEmployeeList).HasForeignKey(t => t.HospitalId);
            builder.HasOne(t => t.HospitalPositionInfo).WithMany(t => t.HospitalEmployeeList).HasForeignKey(t => t.HospitalPositionId);
        }
    }
}
