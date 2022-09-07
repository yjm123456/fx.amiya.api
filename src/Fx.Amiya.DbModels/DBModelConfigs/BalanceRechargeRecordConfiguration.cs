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
    public class BalanceRechargeRecordConfiguration : IEntityTypeConfiguration<BalanceRechargeRecord>
    {
        public void Configure(EntityTypeBuilder<BalanceRechargeRecord> builder)
        {
            builder.ToTable("tbl_customer_balance_recharge_record");
            builder.HasKey(b=>b.Id);
            builder.HasIndex(b => b.OrderId).IsUnique();
            builder.Property(b=>b.Id).HasColumnName("id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(b => b.CustomerId).HasColumnName("customer_id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(b => b.ExchangeType).HasColumnName("exchage_type").HasColumnType("int").IsRequired();
            builder.Property(b => b.RechargeAmount).HasColumnName("recharge_amount").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(b=>b.OrderId).HasColumnName("order_id").HasColumnType("varchar(100)").IsRequired(false);
            builder.Property(b => b.RechargeDate).HasColumnName("recharge_date").HasColumnType("datetime").IsRequired();
            builder.Property(b => b.Balance).HasColumnName("balance").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(b => b.Status).HasColumnName("status").HasColumnType("int").IsRequired().IsConcurrencyToken();
            builder.Property(b => b.CompleteDate).HasColumnName("complete_date").HasColumnType("datetime").IsRequired(false);
        }
    }
}
