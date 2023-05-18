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
    public class HealthValueConfigration : IEntityTypeConfiguration<HealthValue>
    {
        public void Configure(EntityTypeBuilder<HealthValue> builder)
        {
            builder.ToTable("tbl_heath_value");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.Name).HasColumnName("name").HasColumnType("varchar(200)").IsRequired();
            builder.Property(e => e.Code).HasColumnName("code").HasColumnType("varchar(200)").IsRequired();
            builder.Property(e => e.Value).HasColumnName("value").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
        }
    }
}
