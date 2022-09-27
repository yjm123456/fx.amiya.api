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
    public class IndicatorSendHospitalConfiguration : IEntityTypeConfiguration<IndicatorSendHospital>
    {
        public void Configure(EntityTypeBuilder<IndicatorSendHospital> builder)
        {
            builder.ToTable("tbl_indicator_send_hospital");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.IndicatorId).HasColumnName("indicator_id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.Property(e => e.SubmitStatus).HasColumnName("submit_status").HasColumnType("bit").IsRequired();
            builder.Property(e => e.RemarkStatus).HasColumnName("remark_status").HasColumnType("bit").IsRequired();
            builder.HasOne(e => e.HospitalOperationalIndicator).WithMany(h => h.IndicatorSendHospitalList).HasForeignKey(e => e.IndicatorId);
            builder.HasOne(e => e.HospitalInfo).WithMany(h => h.IndicatorSendHospitalList).HasForeignKey(e => e.HospitalId);
        }

    }
}
