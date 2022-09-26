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
    public class OperationsbeIndicatorToHospitalConfiguration : IEntityTypeConfiguration<OperationsbeIndicatorToHospital>
    {
        public void Configure(EntityTypeBuilder<OperationsbeIndicatorToHospital> builder)
        {
            builder.ToTable("tbl_operationsbe_indicator_to_hospital");
            builder.HasKey(e=>e.Id);
            builder.Property(e=>e.Id).HasColumnName("id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.OperationsbeIndicatorId).HasColumnName("indicator_id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.HasOne(e => e.HospitalOperationsbeIndicator).WithMany(h => h.OperationsbeIndicatorToHospitalList).HasForeignKey(e=>e.OperationsbeIndicatorId);
            builder.HasOne(e => e.HospitalInfo).WithMany(h => h.OperationsbeIndicatorToHospital).HasForeignKey(e=>e.HospitalId);
        }
    }
}
