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
    public class RechargeAmountConfiguration : IEntityTypeConfiguration<RechargeAmount>
    {
        public void Configure(EntityTypeBuilder<RechargeAmount> builder)
        {
            builder.ToTable("tbl_recharge_amount");
            builder.HasKey(e=>e.Id);
            builder.Property(e=>e.Id).HasColumnName("id").HasColumnType("varchar(100)");
            builder.Property(e => e.Amount).HasColumnName("amount").HasColumnType("decimal(10,2)");
        }
    }
}
