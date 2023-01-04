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
    public class GiftCategoryConfiguration : IEntityTypeConfiguration<GiftCategory>
    {
        public void Configure(EntityTypeBuilder<GiftCategory> builder)
        {
            builder.ToTable("tbl_gift_category");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.Name).HasColumnName("name").HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.SimpleCode).HasColumnName("simple_code").HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.CreateBy).HasColumnName("create_by").HasColumnType("int").IsRequired();
            builder.Property(e => e.UpdateBy).HasColumnName("update_by").HasColumnType("int").IsRequired(false);
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
        }
    }
}
