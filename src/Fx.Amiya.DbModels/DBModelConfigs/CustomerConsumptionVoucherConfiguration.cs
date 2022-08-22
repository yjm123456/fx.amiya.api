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
    public class CustomerConsumptionVoucherConfiguration : IEntityTypeConfiguration<CustomerConsumptionVoucher>
    {
        public void Configure(EntityTypeBuilder<CustomerConsumptionVoucher> builder)
        {
            builder.ToTable("tbl_customer_consumption_voucher");
            builder.HasKey(c=>c.Id);
            builder.Property(c => c.Id).HasColumnName("id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(c=>c.CustomerId).HasColumnName("customer_id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(c => c.ConsumptionVoucherId).HasColumnName("consumption_voucher_id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(c => c.IsUsed).HasColumnName("is_used").HasColumnType("bit").IsRequired();
            builder.Property(c => c.ExpireDate).HasColumnName("expire_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(c => c.IsExpire).HasColumnName("is_expire").HasColumnType("bit").IsRequired();
            builder.Property(c => c.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(c => c.UseDate).HasColumnName("use_date").HasColumnType("datetime").IsRequired(false);
        }
    }
}
