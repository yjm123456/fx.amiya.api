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
    public class BalanceUseRecordConfiguration : IEntityTypeConfiguration<BalanceUseRecord>
    {
        public void Configure(EntityTypeBuilder<BalanceUseRecord> builder)
        {
            builder.ToTable("tbl_customer_balance_use_record");
            builder.HasKey(u=>u.Id);
            builder.Property(u => u.Id).HasColumnName("id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(u => u.CustomerId).HasColumnName("customer_id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(u => u.Amount).HasColumnName("amount").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(u => u.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(u => u.OrderId).HasColumnName("order_id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(u => u.Balance).HasColumnName("balance").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(u=>u.UseType).HasColumnName("use_type").HasColumnType("int").IsRequired().HasDefaultValue(0);
        }
    }
}
