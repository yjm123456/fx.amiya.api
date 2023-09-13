using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class OrderTradeConfiguration : IEntityTypeConfiguration<OrderTrade>
    {
        public void Configure(EntityTypeBuilder<OrderTrade> builder)
        {
            builder.ToTable("tbl_order_trade");
            builder.HasKey(t => t.TradeId);
            builder.Property(t => t.TradeId).HasColumnName("trade_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.CustomerId).HasColumnName("customer_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.AddressId).HasColumnName("address_id").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.TotalAmount).HasColumnName("total_amount").HasColumnType("decimal(18,2)").IsRequired(false);
            builder.Property(t => t.TotalIntegration).HasColumnName("total_integration").HasColumnType("decimal(18,2)").IsRequired(false);
            builder.Property(t => t.Remark).HasColumnName("remark").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.StatusCode).HasColumnName("status_code").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.IsAdminAdd).HasColumnName("is_admin_add").HasColumnType("bit").IsRequired();
            builder.Property(t => t.TransNo).HasColumnName("trans_no").HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(t => t.ChanelOrderNo).HasColumnName("chanel_order_no").HasColumnType("varchar(100)").IsRequired(false);

            builder.HasOne(t => t.CustomerInfo).WithMany(t => t.OrderTradeList).HasForeignKey(t=>t.CustomerId);
            builder.HasOne(t => t.Address).WithMany(t => t.OrderTradeList).HasForeignKey(t=>t.AddressId);
        }
    }
}

