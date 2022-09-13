
using Fx.Amiya.Modules.Goods.DbModel;
using Fx.Amiya.Modules.Goods.Domin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.Goods.Infrastructure.Repositories
{
    public class DbModelConfigurations
    {
        public static void Configuration(IFreeSql freeSql)
        {
            freeSql.CodeFirst.Entity<GoodsCategoryDbModel>(entity =>
            {
                entity.ToTable("tbl_goods_category");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
                entity.Property(t => t.Name).HasColumnName("name").HasColumnType("varchar(150)").IsRequired();
                entity.Property(t => t.SimpleCode).HasColumnName("simple_code").HasColumnType("varchar(150)").IsRequired();
                entity.Property(t => t.ShowDirectionType).HasColumnName("show_direction_type").HasColumnType("int");
                entity.Property(t => t.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
                entity.Property(t => t.CreateBy).HasColumnName("create_by").HasColumnType("int").IsRequired();
                entity.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
                entity.Property(t => t.UpdateBy).HasColumnName("update_by").HasColumnType("int");
                entity.Property(t => t.UpdateDate).HasColumnName("update_date").HasColumnType("datetime");
                entity.Property(t => t.Sort).HasColumnName("sort").HasColumnType("int");

            });
            freeSql.CodeFirst.Entity<GoodsDetailDbModel>(entity =>
            {
                entity.ToTable("tbl_goods_detail");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
                entity.Property(t => t.GoodsDetailHtml).HasColumnName("goods_detail_html").HasColumnType("varchar(8000)").IsRequired();
                entity.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
                entity.Property(t => t.CreateBy).HasColumnName("create_by").HasColumnType("int").IsRequired();
                entity.Property(t => t.UpdateDate).HasColumnName("update_date").HasColumnType("datetime");
                entity.Property(t => t.UpdateBy).HasColumnName("update_by").HasColumnType("int");
            });

            freeSql.CodeFirst.Entity<GoodsInfoDbModel>(entity =>
            {
                entity.ToTable("tbl_goods_info");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
                entity.Property(t => t.Name).HasColumnName("name").HasColumnType("varchar(100)").IsRequired();
                entity.Property(t => t.SimpleCode).HasColumnName("simple_code").HasColumnType("varchar(100)").IsRequired();
                entity.Property(t => t.Description).HasColumnName("description").HasColumnType("varchar(500)");
                entity.Property(t => t.Standard).HasColumnName("standard").HasColumnType("varchar(100)").IsRequired();
                entity.Property(t => t.Unit).HasColumnName("unit").HasColumnType("varchar(50)");
                entity.Property(t => t.SalePrice).HasColumnName("sale_price").HasColumnType("decimal(10,2)");
                entity.Property(t => t.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
                entity.Property(t => t.InventoryQuantity).HasColumnName("inventory_quantity").HasColumnType("int");
                entity.Property(t => t.ExchangeType).HasColumnName("exchange_type").HasColumnType("tinyint").IsRequired();
                entity.Property(t => t.IntegrationQuantity).HasColumnName("integration_quantity").HasColumnType("decimal(18,2)");
                entity.Property(t => t.ThumbPicUrl).HasColumnName("thumb_pic_url").HasColumnType("varchar(500)").IsRequired();
                entity.Property(t => t.IsMaterial).HasColumnName("is_material").HasColumnType("bit").IsRequired();
                entity.Property(t => t.GoodsType).HasColumnName("goods_type").HasColumnType("tinyint").IsRequired();
                entity.Property(t => t.IsLimitBuy).HasColumnName("is_limit_buy").HasColumnType("bit").IsRequired();
                entity.Property(t => t.LimitBuyQuantity).HasColumnName("limit_buy_quantity").HasColumnType("int");
                entity.Property(t => t.CategoryId).HasColumnName("category_id").HasColumnType("int").IsRequired();
                entity.Property(t => t.GoodsDetailId).HasColumnName("goods_detail_id").HasColumnType("int");
                entity.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
                entity.Property(t => t.CreateBy).HasColumnName("create_by").HasColumnType("int").IsRequired();
                entity.Property(t => t.UpdateBy).HasColumnName("update_by").HasColumnType("int");
                entity.Property(t => t.UpdatedDate).HasColumnName("updated_date").HasColumnType("datetime");
                entity.Property(t => t.Version).HasColumnName("version").HasColumnType("int").IsRequired();
                entity.Property(t => t.DetailsDescription).HasColumnName("details_description").HasColumnType("varchar(500)");
                entity.Property(t => t.MaxShowPrice).HasColumnName("max_show_price").HasColumnType("decimal(10,2)");
                entity.Property(t => t.MinShowPrice).HasColumnName("min_show_price").HasColumnType("decimal(10,2)");
                entity.Property(t => t.VisitCount).HasColumnName("visit_count").HasColumnType("int");
                entity.Property(t => t.SaleCount).HasColumnName("sale_count").HasColumnType("int");
                entity.Property(t => t.ShowSaleCount).HasColumnName("show_sale_count").HasColumnType("int");

                entity.HasOne(t => t.GoodsCategory).WithMany(t => t.GoodsInfoList).HasForeignKey(t => t.CategoryId);
                entity.HasOne(t => t.GoodsDetail).WithMany(t => t.GoodsInfoList).HasForeignKey(t => t.GoodsDetailId);
            });

            freeSql.CodeFirst.Entity<GoodsInfoCarouselImageDbModel>(entity =>
            {
                entity.ToTable("tbl_goods_info_carousel_image");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
                entity.Property(t => t.GoodsInfoId).HasColumnName("goods_info_id").HasColumnType("varchar(50)").IsRequired();
                entity.Property(t => t.PicUrl).HasColumnName("pic_url").HasColumnType("varchar(500)").IsRequired();
                entity.Property(t => t.DisplayIndex).HasColumnName("display_index").HasColumnType("tinyint").IsRequired();
                entity.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
                entity.Property(t => t.UpdateDate).HasColumnName("update_date").HasColumnType("datetime");

                entity.HasOne(t => t.GoodsInfo).WithMany(e => e.GoodsInfoCarouselImageList).HasForeignKey(e => e.GoodsInfoId);
            });

            freeSql.CodeFirst.Entity<GoodsMemberRankPriceDbModel>(entity =>
            {
                entity.ToTable("goods_member_rank_price");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
                entity.Property(t => t.GoodsId).HasColumnName("goods_id").HasColumnType("varchar(50)").IsRequired();
                entity.Property(t => t.MemberRankId).HasColumnName("member_rank_id").HasColumnType("tinyint").IsRequired();
                entity.Property(t => t.Price).HasColumnName("price").HasColumnType("decimal(12,2)").IsRequired();
                entity.HasOne(t => t.GoodsInfo).WithMany(e => e.GoodsMemberRankPriceList).HasForeignKey(e => e.GoodsId);
            });

        }

    }
}
