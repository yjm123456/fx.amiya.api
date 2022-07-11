using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class GoodsInfoConfiguration : IEntityTypeConfiguration<GoodsInfo>
    {
        public void Configure(EntityTypeBuilder<GoodsInfo> builder)
        {
            builder.ToTable("tbl_goods_info");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.Name).HasColumnName("name").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t => t.SimpleCode).HasColumnName("simple_code").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t => t.Description).HasColumnName("description").HasColumnType("varchar(500)");
            builder.Property(t => t.Standard).HasColumnName("standard").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t => t.Unit).HasColumnName("unit").HasColumnType("varchar(50)");
            builder.Property(t => t.SalePrice).HasColumnName("sale_price").HasColumnType("decimal(10,2)");
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(t => t.InventoryQuantity).HasColumnName("inventory_quantity").HasColumnType("int");
            builder.Property(t => t.ExchangeType).HasColumnName("exchange_type").HasColumnType("tinyint").IsRequired();
            builder.Property(t => t.IntegrationQuantity).HasColumnName("integration_quantity").HasColumnType("decimal(18,2)");
            builder.Property(t => t.ThumbPicUrl).HasColumnName("thumb_pic_url").HasColumnType("varchar(500)").IsRequired();
            builder.Property(t => t.IsMaterial).HasColumnName("is_material").HasColumnType("bit").IsRequired();
            builder.Property(t => t.GoodsType).HasColumnName("goods_type").HasColumnType("tinyint").IsRequired();
            builder.Property(t => t.IsLimitBuy).HasColumnName("is_limit_buy").HasColumnType("bit").IsRequired();
            builder.Property(t => t.LimitBuyQuantity).HasColumnName("limit_buy_quantity").HasColumnType("int");
            builder.Property(t => t.CategoryId).HasColumnName("category_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.GoodsDetailId).HasColumnName("goods_detail_id").HasColumnType("int");
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.CreateBy).HasColumnName("create_by").HasColumnType("int").IsRequired();
            builder.Property(t => t.UpdateBy).HasColumnName("update_by").HasColumnType("int");
            builder.Property(t => t.UpdatedDate).HasColumnName("updated_date").HasColumnType("datetime");
            builder.Property(t => t.Version).HasColumnName("version").HasColumnType("int").IsRequired();
            builder.Property(t => t.DetailsDescription).HasColumnName("details_description").HasColumnType("varchar(500)");
            builder.Property(t => t.MaxShowPrice).HasColumnName("max_show_price").HasColumnType("decimal(10,2)");
            builder.Property(t => t.MinShowPrice).HasColumnName("min_show_price").HasColumnType("decimal(10,2)");
            builder.Property(t => t.VisitCount).HasColumnName("visit_count").HasColumnType("int");
            builder.Property(t => t.SaleCount).HasColumnName("sale_count").HasColumnType("int");
            builder.Property(t => t.ShowSaleCount).HasColumnName("show_sale_count").HasColumnType("int");

        }
    }
}
