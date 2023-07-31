using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class LiveAnchorMonthlyTargetLivingConfiguration : IEntityTypeConfiguration<LiveAnchorMonthlyTargetLiving>
    {
        public void Configure(EntityTypeBuilder<LiveAnchorMonthlyTargetLiving> builder)
        {
            builder.ToTable("tbl_liveanchor_monthly_target_living");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(120)").IsRequired();
            builder.Property(t => t.Year).HasColumnName("year").HasColumnType("int").IsRequired();
            builder.Property(t => t.Month).HasColumnName("month").HasColumnType("int").IsRequired();
            builder.Property(t => t.MonthlyTargetName).HasColumnName("monthly_target_name").HasColumnType("varchar(200)").IsRequired(false);
            builder.Property(t => t.LiveAnchorId).HasColumnName("live_anchor_id").HasColumnType("int").IsRequired();

            builder.Property(t => t.LivingRoomFlowInvestmentTarget).HasColumnName("livingroomflow_investment_target").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.LivingRoomCumulativeFlowInvestment).HasColumnName("cumulative_livingroomflow_investment").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.LivingRoomFlowInvestmentCompleteRate).HasColumnName("livingroomflow_investment_complete_rate").HasColumnType("decimal(12,2)").IsRequired();

            builder.Property(t => t.ConsultationTarget).HasColumnName("consultation_target").HasColumnType("int").IsRequired();
            builder.Property(t => t.CumulativeConsultation).HasColumnName("cumulative_consultation").HasColumnType("int").IsRequired();
            builder.Property(t => t.ConsultationCompleteRate).HasColumnName("consultation_complete_rate").HasColumnType("decimal(12,2)").IsRequired();


            builder.Property(t => t.ConsultationTarget2).HasColumnName("consultation_target2").HasColumnType("int").IsRequired();
            builder.Property(t => t.CumulativeConsultation2).HasColumnName("cumulative_consultation2").HasColumnType("int").IsRequired();
            builder.Property(t => t.ConsultationCompleteRate2).HasColumnName("consultation_complete_rate2").HasColumnType("decimal(12,2)").IsRequired();

            builder.Property(t => t.CargoSettlementCommissionTarget).HasColumnName("cargosettlementcommission_target").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.CumulativeCargoSettlementCommission).HasColumnName("cumulation_cargosettlementcommission").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.CargoSettlementCommissionCompleteRate).HasColumnName("cargosettlementcommission_complete_rate").HasColumnType("decimal(12,2)").IsRequired();

            builder.Property(t => t.LivingRefundCardTarget).HasColumnName("living_refund_card").HasColumnType("int").IsRequired();
            builder.Property(t => t.CumulativeLivingRefundCard).HasColumnName("cumulative_living_refund_card").HasColumnType("int").IsRequired();
            builder.Property(t => t.LivingRefundCardCompleteRate).HasColumnName("living_refund_card_complete_rate").HasColumnType("decimal(10,2)").IsRequired();

            builder.Property(t => t.GMVTarget).HasColumnName("gmv").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(t => t.CumulativeGMV).HasColumnName("cumulative_gmv").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(t => t.GMVTargetCompleteRate).HasColumnName("gmv_target_complete_rate").HasColumnType("decimal(10,2)").IsRequired();

            builder.Property(t => t.EliminateCardGMVTarget).HasColumnName("eliminate_card_gmv").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(t => t.CumulativeEliminateCardGMV).HasColumnName("cumulative_eliminate_card_gmv").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(t => t.EliminateCardGMVTargetCompleteRate).HasColumnName("eliminate_card_gmv_target_complete_rate").IsRequired();

            builder.Property(t => t.RefundGMVTarget).HasColumnName("refund_gmv_target").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(t => t.RefundGMVTargetCompleteRate).HasColumnName("refund_gmv_target_completerate").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(t => t.CumulativeRefundGMV).HasColumnName("cumulative_refund_gmv").HasColumnType("decimal(10,2)").IsRequired();

            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();

            
            builder.HasOne(e => e.LiveAnchor).WithMany(e => e.LiveAnchorMonthlyTargetLivings).HasForeignKey(e => e.LiveAnchorId);
        }
    }
}
