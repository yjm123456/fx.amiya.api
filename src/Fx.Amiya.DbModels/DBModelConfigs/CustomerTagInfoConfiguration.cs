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
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.UpdateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.DeleteDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
        }
    }
}
