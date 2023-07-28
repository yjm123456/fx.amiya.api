using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class ItemInfoConfiguration : IEntityTypeConfiguration<ItemInfo>
    {
        public void Configure(EntityTypeBuilder<ItemInfo> builder)
        {
            builder.ToTable("tbl_item_info");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t => t.Name).HasColumnName("name").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t => t.HospitalDepartmentId).HasColumnName("hospital_department_id").HasColumnType("varchar(45)").IsRequired(false);
            builder.Property(t => t.ThumbPicUrl).HasColumnName("thumb_pic_url").HasColumnType("varchar(500)").IsRequired();
            builder.Property(t => t.Description).HasColumnName("description").HasColumnType("varchar(200)").IsRequired();
            builder.Property(t => t.Standard).HasColumnName("standard").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t => t.Parts).HasColumnName("parts").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t => t.SalePrice).HasColumnName("sale_price").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(t => t.LivePrice).HasColumnName("live_price").HasColumnType("decimal(10,2)").IsRequired(false);
            builder.Property(t => t.AppType).HasColumnName("app_type").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t => t.BrandId).HasColumnName("brand_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.CategoryId).HasColumnName("category_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.IsLimitBuy).HasColumnName("is_limit_buy").HasColumnType("bit").IsRequired();
            builder.Property(t => t.LimitBuyQuantity).HasColumnName("limit_buy_quantity").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.Commitment).HasColumnName("commitment").HasColumnType("varchar(150)").IsRequired(false);
            builder.Property(t => t.Guarantee).HasColumnName("guarantee").HasColumnType("varchar(150)").IsRequired(false);
            builder.Property(t => t.AppointmentNotice).HasColumnName("appointment_notice").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.CreateBy).HasColumnName("create_by").HasColumnType("int").IsRequired();
            builder.Property(t => t.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.UpdateBy).HasColumnName("update_by").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(t => t.ItemDetailId).HasColumnName("item_detail_id").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.OtherAppItemId).HasColumnName("other_app_item_id").HasColumnType("varchar(100)").IsRequired(false);
            builder.Property(t => t.Remark).HasColumnName("remark").HasColumnType("varchar(200)").IsRequired(false);

            builder.HasOne(t => t.CreateEmployee).WithMany(t => t.CreateByItemInfoList).HasForeignKey(t=>t.CreateBy);
            builder.HasOne(t => t.UpdateEmployee).WithMany(t => t.UpdateByItemInfoList).HasForeignKey(t=>t.UpdateBy);
           
        }
    }
}
