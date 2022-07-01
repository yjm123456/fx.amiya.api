using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class TmallGoodsSkuConfiguration : IEntityTypeConfiguration<TmallGoodsSku>
    {
        public void Configure(EntityTypeBuilder<TmallGoodsSku> builder)
        {
            builder.ToTable("tbl_tmall_goods_sku");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.GoodsId).HasColumnName("goods_id").HasColumnType("varchar(12)").IsRequired(false);
            builder.Property(t => t.SkuName).HasColumnName("sku_name").HasColumnType("varchar(300)").IsRequired(false);
            builder.Property(t => t.Price).HasColumnName("price").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.AllCount).HasColumnName("all_count").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.CreateHospital).HasColumnName("create_hospital").HasColumnType("varchar(100)").IsRequired(false);
        }
    }
}
