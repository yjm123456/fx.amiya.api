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
    public class AmiyaRemarkConfiguration : IEntityTypeConfiguration<AmiyaRemark>
    {
        public void Configure(EntityTypeBuilder<AmiyaRemark> builder)
        {
            builder.ToTable("tbl_amiya_remark");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.Property(e => e.IndicatorId).HasColumnName("indicator_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.Type).HasColumnName("type").HasColumnType("varchar(200)").IsRequired();
            builder.Property(e => e.Content).HasColumnName("content").HasColumnType("varchar(1000)").IsRequired(false);
            builder.Property(e => e.Sort).HasColumnName("sort").HasColumnType("int").IsRequired();
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
        }
    }
}
