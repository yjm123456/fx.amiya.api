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
    public class IntegrationGenerateRecordConfiguration : IEntityTypeConfiguration<IntegrationGenerateRecord>
    {
        public void Configure(EntityTypeBuilder<IntegrationGenerateRecord> builder)
        {
            builder.ToTable("tbl_integration_generate_record");
            builder.HasKey(e=>e.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("bigint").IsRequired();
            builder.Property(t => t.Date).HasColumnName("date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.CustomerId).HasColumnName("customer_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.Type).HasColumnName("type").HasColumnType("tinyint").IsRequired();
            builder.Property(t => t.Quantity).HasColumnName("quantity").HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(t => t.OrderId).HasColumnName("order_id").HasColumnType("varchar(100)").IsRequired(false);
            builder.Property(t => t.AmountOfConsumption).HasColumnName("amount_of_consumption").HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(t => t.Percents).HasColumnName("percents").HasColumnType("decimal(4,3)").IsRequired();
            builder.Property(t => t.ProviderId).HasColumnName("provider_id").HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(t => t.ExpiredDate).HasColumnName("expired_date").HasColumnType("date").IsRequired(false);
            builder.Property(t => t.StockQuantity).HasColumnName("stock_quantity").HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(t => t.AccountBalance).HasColumnName("account_balance").HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(t => t.HandleBy).HasColumnName("handle_by").HasColumnType("int").IsRequired(false);
        }
    }
}
