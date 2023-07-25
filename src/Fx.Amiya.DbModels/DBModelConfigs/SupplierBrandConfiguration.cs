using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class SupplierBrandConfiguration : IEntityTypeConfiguration<SupplierBrand>
    {
        public void Configure(EntityTypeBuilder<SupplierBrand> builder)
        {
            builder.ToTable("tbl_supplier_brand");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("DateTime").IsRequired();
            builder.Property(t => t.UpdateDate).HasColumnName("update_date").HasColumnType("DateTime").IsRequired(false);
            builder.Property(t => t.DeleteDate).HasColumnName("delete_date").HasColumnType("DateTime").IsRequired(false);
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("BIT(1)").IsRequired();
            builder.Property(t => t.BrandName).HasColumnName("brand_name").HasColumnType("varchar(100)").IsRequired(false);
        }
    }
}
