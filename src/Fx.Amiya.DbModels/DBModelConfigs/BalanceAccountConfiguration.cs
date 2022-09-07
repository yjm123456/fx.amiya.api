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
    public class BalanceAccountConfiguration : IEntityTypeConfiguration<BalanceAccount>
    {
        public void Configure(EntityTypeBuilder<BalanceAccount> builder)
        {
            builder.ToTable("tbl_customer_balance_account");
            builder.HasKey(b=>b.CustomerId);
            builder.Property(b => b.CustomerId).HasColumnName("customer_id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(b => b.Balance).HasColumnName("balance").HasColumnType("decimal(10,2)").IsRequired().IsConcurrencyToken();
        }
    }
}
