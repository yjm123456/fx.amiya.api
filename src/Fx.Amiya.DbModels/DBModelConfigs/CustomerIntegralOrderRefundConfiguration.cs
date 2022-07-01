using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class CustomerIntegralOrderRefundConfiguration : IEntityTypeConfiguration<CustomerIntegralOrderRefund>
    {
        public void Configure(EntityTypeBuilder<CustomerIntegralOrderRefund> builder)
        {
            builder.ToTable("tbl_customer_integral_order_refund");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.OrderId).HasColumnName("order_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.CustomerId).HasColumnName("customer_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.RefundReasong).HasColumnName("refund_reason").HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.CheckState).HasColumnName("check_state").HasColumnType("int").IsRequired();
            builder.Property(t => t.CheckDate).HasColumnName("check_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.CheckBy).HasColumnName("chech_by").HasColumnType("int").IsRequired();
            builder.Property(t => t.CheckReason).HasColumnName("check_reason").HasColumnType("varchar(300)").IsRequired(false);
        }
    }
}
