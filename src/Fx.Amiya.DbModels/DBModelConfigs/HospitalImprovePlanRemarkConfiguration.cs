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
    public class HospitalImprovePlanRemarkConfiguration : IEntityTypeConfiguration<HospitalImprovePlanRemark>
    {
        public void Configure(EntityTypeBuilder<HospitalImprovePlanRemark> builder)
        {
            builder.ToTable("tbl_hospital_improve_plan_remark");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.IndicatorId).HasColumnName("indicator_id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t => t.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("BIT(1)").IsRequired();
            builder.Property(t => t.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.HospitalImprovePlan).HasColumnName("hospital_improve_plan").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.AmiyaImprovePlanRemark).HasColumnName("amiya_improve_plan_remark").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.HospitalShareSuccessCase).HasColumnName("hospital_share_success_case").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.AmiyaShareSuccessCase).HasColumnName("amiya_share_success_case").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.ImproveSuggestionToAmiya).HasColumnName("improve_suggestion_to_amiya").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.AmiyaImproveSuggestionRemark).HasColumnName("amiya_improve_suggestion_remark").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.ImproveDemandToAmiya).HasColumnName("improve_demand_to_Amiya").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.AmiyaImproveDemandRemark).HasColumnName("amiya_improve_demand_remark").HasColumnType("varchar(500)").IsRequired(false);

            builder.HasOne(t=>t.HospitalInfo).WithMany(e=>e.HospitalImprovePlanRemarkList).HasForeignKey(e=>e.HospitalId);
            builder.HasOne(t => t.HospitalOperationalIndicator).WithMany(e =>e.HospitalImprovePlanRemarkList).HasForeignKey(e => e.IndicatorId);

        }
    }
}
