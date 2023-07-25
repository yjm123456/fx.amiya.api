using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class SupplierCategoryConfiguration : IEntityTypeConfiguration<SupplierCategory>
    {
        public void Configure(EntityTypeBuilder<SupplierCategory> builder)
        {
            builder.ToTable("tbl_supplier_category");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("DateTime").IsRequired();
            builder.Property(t => t.UpdateDate).HasColumnName("update_date").HasColumnType("DateTime").IsRequired(false);
            builder.Property(t => t.DeleteDate).HasColumnName("delete_date").HasColumnType("DateTime").IsRequired(false);
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("BIT(1)").IsRequired();
            builder.Property(t => t.CategoryName).HasColumnName("category_name").HasColumnType("varchar(100)").IsRequired(false);
            builder.Property(t => t.BrandId).HasColumnName("brand_id").HasColumnType("varchar(50)").IsRequired(false);
            builder.HasOne(e => e.SupplierBrand).WithMany(e => e.SupplierCategoryList).HasForeignKey(e => e.BrandId);
        }
    }
}
