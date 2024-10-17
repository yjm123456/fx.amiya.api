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
    public class CustomerServiceCheckPerformanceConfiguration : IEntityTypeConfiguration<CustomerServiceCheckPerformance>
    {
        public void Configure(EntityTypeBuilder<CustomerServiceCheckPerformance> builder)
        {
            builder.ToTable("tbl_customer_service_check_performance");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.DealInfoId).HasColumnName("deal_info_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.OrderId).HasColumnName("order_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.OrderFrom).HasColumnName("order_from").HasColumnType("int").IsRequired();
            builder.Property(e => e.DealPrice).HasColumnName("deal_price").HasColumnType("DECIMAL(12,2)").IsRequired();
            builder.Property(e => e.DealCreateDate).HasColumnName("deal_create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.PerformanceType).HasColumnName("performance_type").HasColumnType("int").IsRequired();
            builder.Property(e => e.BelongEmpId).HasColumnName("belong_emp_id").HasColumnType("int").IsRequired();
            builder.Property(e => e.Point).HasColumnName("point").HasColumnType("DECIMAL(12,2)").IsRequired();
            builder.Property(e => e.CheckEmpId).HasColumnName("check_emp_id").HasColumnType("int").IsRequired(false);
            builder.Property(e => e.Remark).HasColumnName("remark").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(e => e.BillId).HasColumnName("bill_id").HasColumnType("VARCHAR(50)").IsRequired(false);
            builder.Property(e => e.CheckBillId).HasColumnName("check_bill_id").HasColumnType("VARCHAR(50)").IsRequired(false);
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
        }
    }
}
