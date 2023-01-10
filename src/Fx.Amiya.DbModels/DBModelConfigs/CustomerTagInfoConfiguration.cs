using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class CustomerTagInfoConfiguration : IEntityTypeConfiguration<CustomerTagInfo>
    {
        public void Configure(EntityTypeBuilder<CustomerTagInfo> builder)
        {
            builder.ToTable("tbl_customer_tag_info");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.TagName).HasColumnName("tag_name").HasColumnType("varchar(45)").IsRequired();
            builder.Property(t => t.TagCategory).HasColumnName("tag_category").HasColumnType("int").IsRequired(false);
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
        }
    }
}
