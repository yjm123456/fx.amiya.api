using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class LivingDailyTakeGoodsConfiguration : IEntityTypeConfiguration<LivingDailyTakeGoods>
    {
        public void Configure(EntityTypeBuilder<LivingDailyTakeGoods> builder)
        {
            builder.ToTable("tbl_living_daily_take_goods");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("DateTime").IsRequired();
            builder.Property(t => t.CreatBy).HasColumnName("create_by").HasColumnType("INT").IsRequired();
            builder.Property(t => t.UpdateDate).HasColumnName("update_date").HasColumnType("DateTime").IsRequired(false);
            builder.Property(t => t.DeleteDate).HasColumnName("delete_date").HasColumnType("DateTime").IsRequired(false);
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("BIT(1)").IsRequired();

            builder.Property(t => t.TakeGoodsDate).HasColumnName("take_goods_date").HasColumnType("DateTime").IsRequired(false);
            builder.Property(t => t.BrandId).HasColumnName("brand_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.CategoryId).HasColumnName("category_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.ContentPlatFormId).HasColumnName("content_plat_form_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.LiveAnchorId).HasColumnName("live_anchor_id").HasColumnType("INT").IsRequired();
            builder.Property(t => t.ItemId).HasColumnName("item_id").HasColumnType("INT").IsRequired();
            builder.Property(t => t.SinglePrice).HasColumnName("single_price").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.TakeGoodsQuantity).HasColumnName("take_goods_quantity").HasColumnType("INT").IsRequired();
            builder.Property(t => t.TotalPrice).HasColumnName("total_price").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.TakeGoodsType).HasColumnName("take_goods_type").HasColumnType("INT").IsRequired();
            builder.Property(t => t.Remark).HasColumnName("remark").HasColumnType("varchar(500)").IsRequired(false);

            builder.HasOne(e => e.AmiyaEmployee).WithMany(e => e.LivingDailyTakeGoodsList).HasForeignKey(e => e.CreatBy);
            builder.HasOne(e => e.SupplierBrand).WithMany(e => e.LivingDailyTakeGoodsList).HasForeignKey(e => e.BrandId);
            builder.HasOne(e => e.SupplierCategory).WithMany(e => e.LivingDailyTakeGoodsList).HasForeignKey(e => e.CategoryId);
            builder.HasOne(e => e.Contentplatform).WithMany(e => e.LivingDailyTakeGoodsList).HasForeignKey(e => e.ContentPlatFormId);
            builder.HasOne(e => e.LiveAnchor).WithMany(e => e.LivingDailyTakeGoodsList).HasForeignKey(e => e.LiveAnchorId);
            builder.HasOne(e => e.ItemInfo).WithMany(e => e.LivingDailyTakeGoodsList).HasForeignKey(e => e.ItemId);
        }
    }
}
