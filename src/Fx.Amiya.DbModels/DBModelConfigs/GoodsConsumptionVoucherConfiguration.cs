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
    public class GoodsConsumptionVoucherConfiguration : IEntityTypeConfiguration<GoodsConsumptionVoucher>
    {
        public void Configure(EntityTypeBuilder<GoodsConsumptionVoucher> builder)
        {
            builder.ToTable("tbl_goods_consumption_voucher");
            builder.HasKey(e=>e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.GoodsId).HasColumnName("goods_id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.ConsumptionVoucherId).HasColumnName("consumption_voucher_id").HasColumnType("varchar(100)").IsRequired();
        }
    }
}
