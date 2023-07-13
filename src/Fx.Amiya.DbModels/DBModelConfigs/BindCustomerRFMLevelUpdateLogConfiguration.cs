using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class BindCustomerRFMLevelUpdateLogConfiguration : IEntityTypeConfiguration<BindCustomerRFMLevelUpdateLog>
    {
        public void Configure(EntityTypeBuilder<BindCustomerRFMLevelUpdateLog> builder)
        {
            builder.ToTable("tbl_bind_customer_rfm_level_update_log");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.BindCustomerServiceId).HasColumnName("bind_customer_service_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.CustomerServiceId).HasColumnName("customer_service_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.From).HasColumnName("from").HasColumnType("int").IsRequired();
            builder.Property(t => t.To).HasColumnName("to").HasColumnType("int").IsRequired();

            builder.HasOne(t => t.BindCustomerService).WithMany(t => t.BindCustomerRFMLevelUpdateLogList).HasForeignKey(t => t.BindCustomerServiceId);
            builder.HasOne(t => t.CustomerServiceInfo).WithMany(t => t.BindCustomerRFMLevelUpdateLogList).HasForeignKey(t => t.CustomerServiceId);
        }
    }
}
