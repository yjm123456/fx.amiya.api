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
    public class GrowthPointsRecordConfiguration : IEntityTypeConfiguration<GrowthPointsRecord>
    {
        public void Configure(EntityTypeBuilder<GrowthPointsRecord> builder)
        {
            builder.ToTable("tbl_growth_points_record");
            builder.HasKey(g=>g.Id);
            builder.Property(g => g.Id).HasColumnName("id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(g => g.Quantity).HasColumnName("quantity").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(g => g.Type).HasColumnName("type").HasColumnType("int").IsRequired();
            builder.Property(g => g.CustomerId).HasColumnName("customer_id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(g => g.OrderId).HasColumnName("order_id").HasColumnType("varchar(100)").IsRequired(false);
            builder.Property(g => g.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(g=>g.ExpireDate).HasColumnName("expire_date").HasColumnType("datetime").IsRequired();
            builder.Property(g => g.IsExpire).HasColumnName("is_expire").HasColumnType("bit").IsRequired();
            builder.Property(g => g.AccountBalance).HasColumnName("account_balance").HasColumnType("decimal(10,2)").IsRequired();
        }
    }
}
