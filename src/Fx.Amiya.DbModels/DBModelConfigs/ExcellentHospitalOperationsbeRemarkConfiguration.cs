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
    class ExcellentHospitalOperationsbeRemarkConfiguration : IEntityTypeConfiguration<ExcellentHospitalOperationsbeRemark>
    {
        public void Configure(EntityTypeBuilder<ExcellentHospitalOperationsbeRemark> builder)
        {
            builder.ToTable("tbl_excellent_hospital_perationsbe_remark");
            builder.HasKey(e=>e.Id);
            builder.Property(e=>e.Id).HasColumnName("id").HasColumnType("varchar(100)");
            builder.Property(e => e.Remark).HasColumnName("remark").HasColumnType("varchar(1000)").IsRequired();
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
        }
    }
}
