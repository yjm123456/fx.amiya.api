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
    public class ConsumptionVoucherConfiguration : IEntityTypeConfiguration<ConsumptionVoucher>
    {
        public void Configure(EntityTypeBuilder<ConsumptionVoucher> builder)
        {
            builder.ToTable("tbl_consumption_voucher");
            builder.HasKey(c=>c.Id);
            builder.Property(c=>c.Id).HasColumnName("id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(c => c.Name).HasColumnName("name").HasColumnType("varchar(100)").IsRequired();
            builder.Property(c => c.DeductMoney).HasColumnName("deduct_money").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(c=>c.IsSpecifyProduct).HasColumnName("is_specify_product").HasColumnType("bit").IsRequired();
            builder.Property(c => c.IsAccumulate).HasColumnName("is_accumulate").HasColumnType("bit").IsRequired();
            builder.Property(c => c.IsShare).HasColumnName("is_share").HasColumnType("bit").IsRequired();
            builder.Property(c => c.EffectiveTime).HasColumnName("effective_time").HasColumnType("bigint").IsRequired(false);
            builder.Property(c=>c.Type).HasColumnName("type").HasColumnType("int").HasDefaultValue(0).IsRequired();
            builder.Property(c => c.ExpireDate).HasColumnName("expire_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(c => c.IsValid).HasColumnName("is_valid").HasColumnType("bit").IsRequired();
            builder.Property(c => c.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(c=>c.UpdateTime).HasColumnName("update_time").HasColumnType("datetime").IsRequired(false);
    }
    }
}
