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
    public class LivingTakeGoodsOrderConfiguration : IEntityTypeConfiguration<LivingTakeGoodsOrder>
    {
        public void Configure(EntityTypeBuilder<LivingTakeGoodsOrder> builder)
        {
            builder.ToTable("tbl_living_take_goods_order");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.GoodsId).HasColumnName("goods_id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.GoodsName).HasColumnName("goods_name").HasColumnType("varchar(500)").IsRequired();
            builder.Property(e => e.OrderStatus).HasColumnName("order_status").HasColumnType("int").IsRequired();
            builder.Property(e => e.LiveanchorName).HasColumnName("live_anchor_name").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.DealPrice).HasColumnName("deal_price").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(e=>e.GoodsCount).HasColumnName("goods_count").HasColumnType("int").IsRequired();

            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
        }
    }
}
