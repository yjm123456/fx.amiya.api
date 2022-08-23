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
    public class GrowthPointsAccountConfiguration : IEntityTypeConfiguration<GrowthPointsAccount>
    {
        public void Configure(EntityTypeBuilder<GrowthPointsAccount> builder)
        {
            builder.ToTable("tbl_growth_points_account");
            builder.HasKey(g=>g.CustomerId);
            builder.Property(g => g.CustomerId).HasColumnName("customer_id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(g => g.Balance).HasColumnName("balance").HasColumnType("decimal(10,2)").IsRequired().IsConcurrencyToken();
        }
    }
}
