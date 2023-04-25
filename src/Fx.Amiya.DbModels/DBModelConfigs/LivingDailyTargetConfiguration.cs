using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class LivingDailyTargetConfiguration : IEntityTypeConfiguration<LivingDailyTarget>
    {
        public void Configure(EntityTypeBuilder<LivingDailyTarget> builder)
        {
            builder.ToTable("tbl_living_daily_target");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.LiveAnchorMonthlyTargetId).HasColumnName("live_anchor_monthly_target_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.OperationEmpId).HasColumnName("operation_empId").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.LivingRoomFlowInvestmentNum).HasColumnName("living_room_flow_investment_num").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(e => e.Consultation).HasColumnName("consultation").HasColumnType("int").IsRequired();
            builder.Property(e => e.Consultation2).HasColumnName("consultation2").HasColumnType("int").IsRequired();
            builder.Property(e => e.CargoSettlementCommission).HasColumnName("cargo_settlement_commission").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(e => e.RecordDate).HasColumnName("record_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
            builder.HasOne(e => e.LiveAnchorMonthlyTargetLiving).WithMany(e => e.livingDailyTarget).HasForeignKey(e => e.LiveAnchorMonthlyTargetId);
            builder.HasOne(e => e.AmiyaEmployee).WithMany(e => e.livingDailyTarget).HasForeignKey(e => e.OperationEmpId);
        }
    }
}
