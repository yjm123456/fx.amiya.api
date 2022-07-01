using Fx.Amiya.Modules.Integration.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.Integration.Infrastructure.Repositories
{
   public class DbModelConfigurations
    {
        public static void Configuration(IFreeSql freeSql)
        {
            
            freeSql.CodeFirst.Entity<IntegrationAccountDbModel>(entity=> {
                entity.ToTable("tbl_integration_account");
                entity.HasKey(t=>t.CustomerId);
                entity.Property(t => t.CustomerId).HasColumnName("customer_id").HasColumnType("varchar(50)").IsRequired();
                entity.Property(t => t.Balance).HasColumnName("balance").HasColumnType("decimal(18,2)").IsRequired();
                entity.Property(t => t.Version).HasColumnName("version").HasColumnType("int").IsRequired().IsRowVersion();
            });

            freeSql.CodeFirst.Entity<IntegrationGenerateRecordDbModel>(entity => {
                entity.ToTable("tbl_integration_generate_record");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Id).HasColumnName("id").HasColumnType("bigint").IsRequired();
                entity.Property(t => t.Date).HasColumnName("date").HasColumnType("datetime").IsRequired();
                entity.Property(t => t.CustomerId).HasColumnName("customer_id").HasColumnType("varchar(50)").IsRequired();
                entity.Property(t => t.Type).HasColumnName("type").HasColumnType("tinyint").IsRequired();
                entity.Property(t => t.Quantity).HasColumnName("quantity").HasColumnType("decimal(18,2)").IsRequired();
                entity.Property(t => t.OrderId).HasColumnName("order_id").HasColumnType("varchar(100)");
                entity.Property(t => t.AmountOfConsumption).HasColumnName("amount_of_consumption").HasColumnType("decimal(18,2)").IsRequired();
                entity.Property(t => t.Percents).HasColumnName("percents").HasColumnType("decimal(3,2)").IsRequired();
                entity.Property(t => t.ProviderId).HasColumnName("provider_id").HasColumnType("varchar(50)");
                entity.Property(t => t.ExpiredDate).HasColumnName("expired_date").HasColumnType("date");
                entity.Property(t => t.StockQuantity).HasColumnName("stock_quantity").HasColumnType("decimal(18,2)").IsRequired();
                entity.Property(t => t.AccountBalance).HasColumnName("account_balance").HasColumnType("decimal(18,2)").IsRequired();
                entity.Property(t => t.HandleBy).HasColumnName("handle_by").HasColumnType("int");
            });

            freeSql.CodeFirst.Entity<IntegrationUseRecordDbModel>(entity => {
                entity.ToTable("tbl_integration_use_record");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Id).HasColumnName("id").HasColumnType("bigint").IsRequired();
                entity.Property(t => t.Date).HasColumnName("date").HasColumnType("datetime").IsRequired();
                entity.Property(t => t.CustomerId).HasColumnName("customer_id").HasColumnType("varchar(50)").IsRequired();
                entity.Property(t => t.UseQuantity).HasColumnName("use_quantity").HasColumnType("decimal(18,2)").IsRequired();
                entity.Property(t => t.UseType).HasColumnName("use_type").HasColumnType("tinyint").IsRequired();
                entity.Property(t => t.AccountBalance).HasColumnName("account_balance").HasColumnType("decimal(18,2)").IsRequired();
                entity.Property(t => t.HandleBy).HasColumnName("handle_by").HasColumnType("int");
                entity.Property(t => t.OrderId).HasColumnName("order_id").HasColumnType("varchar(50)");

            });

            freeSql.CodeFirst.Entity<IntegrationUseDetailRecordDbModel>(entity => {
                entity.ToTable("tbl_integration_use_detail_record");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Id).HasColumnName("id").HasColumnType("bigint").IsRequired();
                entity.Property(t => t.UseRecordId).HasColumnName("use_record_id").HasColumnType("bigint").IsRequired();
                entity.Property(t => t.UseQuantity).HasColumnName("use_quantity").HasColumnType("decimal(18,2)").IsRequired();
                entity.Property(t => t.GenerateRecordId).HasColumnName("generate_record_id").HasColumnType("bigint");

                entity.HasOne(t => t.IntegrationUseRecord).WithMany(t => t.IntegrationUseDetailRecordList).HasForeignKey(t => t.UseRecordId);
                entity.HasOne(t => t.IntegrationGenerateRecord).WithMany(t => t.IntegrationUseDetailRecordList).HasForeignKey(t=>t.GenerateRecordId);
            });
            
        }
    }
}
