using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class HospitalBindCustomerServiceConfiguration : IEntityTypeConfiguration<HospitalBindCustomerService>
    {
        public void Configure(EntityTypeBuilder<HospitalBindCustomerService> builder)
        {
            builder.ToTable("tbl_hospital_bind_customer_service");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.HospitalEmployeeId).HasColumnName("hospital_emp_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.CustomerPhone).HasColumnName("customer_phone").HasColumnType("varchar(30)").IsRequired();
            builder.Property(t => t.UserId).HasColumnName("user_id").HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.CreateBy).HasColumnName("create_by").HasColumnType("int").IsRequired();
            builder.Property(t => t.FirstProjectDemand).HasColumnName("first_project_demand").HasColumnType("varchar(200)").IsRequired(false);
            builder.Property(t => t.FirstConsumptionDate).HasColumnName("first_consumption_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.NewConsumptionDate).HasColumnName("new_consumption_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.NewConsumptionContentPlatform).HasColumnName("new_consumption_content_platform").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.NewContentPlatForm).HasColumnName("new_content_platform").HasColumnType("varchar(45)").IsRequired(false);
            builder.Property(t => t.AllPrice).HasColumnName("all_price").HasColumnType("decimal(12,2)").IsRequired(false);
            builder.Property(t => t.AllOrderCount).HasColumnName("all_order_count").HasColumnType("int").IsRequired(false);

            builder.HasOne(t => t.HospitalCustomerServiceHospitalEmployee).WithMany(t => t.HospitalBindCustomerServiceList).HasForeignKey(t => t.HospitalEmployeeId);
            builder.HasOne(t => t.CreateByHospitalEmployee).WithMany(t => t.CreateByHospitalBindCustomerServiceList).HasForeignKey(t => t.CreateBy);
        }
    }
}
