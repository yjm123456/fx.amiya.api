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
    public class GoodsHospitalPriceConfiguration : IEntityTypeConfiguration<GoodsHospitalPrice>
    {
        public void Configure(EntityTypeBuilder<GoodsHospitalPrice> builder)
        {
            builder.ToTable("tbl_goods_hospital_price");
            builder.HasKey(t => t.GoodsId);
            builder.Property(t => t.GoodsId).HasColumnName("goods_id").HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(t => t.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.Price).HasColumnName("price").HasColumnType("decimal(10,2)").IsRequired();
        }
    }
}

