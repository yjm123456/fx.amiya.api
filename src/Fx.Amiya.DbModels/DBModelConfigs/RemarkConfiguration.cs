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
    public class RemarkConfiguration : IEntityTypeConfiguration<Remark>
    {
        public void Configure(EntityTypeBuilder<Remark> builder)
        {
            builder.ToTable("tbl_remark");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired(false);
            builder.Property(e => e.IndicatorId).HasColumnName("indicator_id").HasColumnName("varchar(100)").IsRequired();
            builder.Property(e => e.AmiyaRemark).HasColumnName("amiya_remark").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(e => e.HospitalOperationRemark).HasColumnName("hospital_operation_remark").HasColumnName("varchar(500)").IsRequired(false);
            builder.Property(e => e.HospitalOnlineConsultRemark).HasColumnName("hospital_onlineconsult_remark").HasColumnName("varchar(500)").IsRequired(false);
            builder.Property(e => e.HospitalConsultRemark).HasColumnName("hospital_consult_remark").HasColumnName("varchar(500)").IsRequired(false);
            builder.Property(e => e.HospitalDoctorRemark).HasColumnName("hospital_doctor_remark").HasColumnName("varchar(500)").IsRequired(false);
            builder.Property(e => e.HospitalDealRemark).HasColumnName("hospital_deal_remark").HasColumnName("varchar(500)").IsRequired(false);
            builder.Property(e => e.AmiyaOperationRemark).HasColumnName("amiya_operation_remark").IsRequired(false);
            builder.Property(e => e.AmiyaOnlineConsultRemark).HasColumnName("amiya_onlineconsult_remark").IsRequired(false);
            builder.Property(e => e.AmiyaConsultRemark).HasColumnName("amiya_consult_remark").IsRequired(false);
            builder.Property(e => e.AmiyaDoctorRemark).HasColumnName("amiya_doctor_remark").IsRequired(false);
            builder.Property(e => e.AmiyaDealRemark).HasColumnName("amiya_deal_remark").IsRequired(false);
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
        }
    }
}
