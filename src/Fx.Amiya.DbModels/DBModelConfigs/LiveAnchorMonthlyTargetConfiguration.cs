using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class LiveAnchorMonthlyTargetConfiguration : IEntityTypeConfiguration<LiveAnchorMonthlyTarget>
    {
        public void Configure(EntityTypeBuilder<LiveAnchorMonthlyTarget> builder)
        {
            builder.ToTable("tbl_liveanchor_monthly_target");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.Year).HasColumnName("year").HasColumnType("int").IsRequired();
            builder.Property(t => t.Month).HasColumnName("month").HasColumnType("int").IsRequired();
            builder.Property(t => t.MonthlyTargetName).HasColumnName("monthly_target_name").HasColumnType("varchar(200)").IsRequired(false);
            builder.Property(t => t.LiveAnchorId).HasColumnName("live_anchor_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.ReleaseTarget).HasColumnName("release_target").HasColumnType("int").IsRequired();
            builder.Property(t => t.CumulativeRelease).HasColumnName("cumulative_release").HasColumnType("int").IsRequired();
            builder.Property(t => t.ReleaseCompleteRate).HasColumnName("release_complete_rate").HasColumnType("decimal(5,2)").IsRequired();
            builder.Property(t => t.FlowInvestmentTarget).HasColumnName("flow_investment_target").HasColumnType("int").IsRequired();
            builder.Property(t => t.CumulativeFlowInvestment).HasColumnName("cumulative_flow_investment").HasColumnType("int").IsRequired();
            builder.Property(t => t.FlowInvestmentCompleteRate).HasColumnName("flow_investment_complete_rate").HasColumnType("decimal(5,2)").IsRequired();
            builder.Property(t => t.LivingRoomFlowInvestmentTarget).HasColumnName("livingroomflow_investment_target").HasColumnType("int").IsRequired();
            builder.Property(t => t.LivingRoomCumulativeFlowInvestment).HasColumnName("cumulative_livingroomflow_investment").HasColumnType("int").IsRequired();
            builder.Property(t => t.LivingRoomFlowInvestmentCompleteRate).HasColumnName("livingroomflow_investment_complete_rate").HasColumnType("decimal(12,2)").IsRequired();

            builder.Property(t => t.CluesTarget).HasColumnName("clues_target").HasColumnType("int").IsRequired();
            builder.Property(t => t.CumulativeClues).HasColumnName("cumulative_clues").HasColumnType("int").IsRequired();
            builder.Property(t => t.CluesCompleteRate).HasColumnName("clues_complete_rate").HasColumnType("decimal(12,2)").IsRequired();

            builder.Property(t => t.AddFansTarget).HasColumnName("add_fans_target").HasColumnType("int").IsRequired();
            builder.Property(t => t.CumulativeAddFans).HasColumnName("cumulative_add_fans").HasColumnType("int").IsRequired();
            builder.Property(t => t.AddFansCompleteRate).HasColumnName("add_fans_complete_rate").HasColumnType("decimal(12,2)").IsRequired();

            builder.Property(t => t.AddWechatTarget).HasColumnName("add_wechat_target").HasColumnType("int").IsRequired();
            builder.Property(t => t.CumulativeAddWechat).HasColumnName("cumulative_add_wechat").HasColumnType("int").IsRequired();
            builder.Property(t => t.AddWechatCompleteRate).HasColumnName("add_wechat_complete_rate").HasColumnType("decimal(5,2)").IsRequired();

            builder.Property(t => t.ConsultationTarget).HasColumnName("consultation_target").HasColumnType("int").IsRequired();
            builder.Property(t => t.CumulativeConsultation).HasColumnName("cumulative_consultation").HasColumnType("int").IsRequired();
            builder.Property(t => t.ConsultationCompleteRate).HasColumnName("consultation_complete_rate").HasColumnType("decimal(12,2)").IsRequired();


            builder.Property(t => t.ConsultationTarget2).HasColumnName("consultation_target2").HasColumnType("int").IsRequired();
            builder.Property(t => t.CumulativeConsultation2).HasColumnName("cumulative_consultation2").HasColumnType("int").IsRequired();
            builder.Property(t => t.ConsultationCompleteRate2).HasColumnName("consultation_complete_rate2").HasColumnType("decimal(12,2)").IsRequired();

            builder.Property(t => t.ConsultationCardConsumedTarget).HasColumnName("consultation_card_consumed_target").HasColumnType("int").IsRequired();
            builder.Property(t => t.CumulativeConsultationCardConsumed).HasColumnName("cumulative_consultation_card_consumed").HasColumnType("int").IsRequired();
            builder.Property(t => t.ConsultationCardConsumedCompleteRate).HasColumnName("consultation_card_consumed_complete_rate").HasColumnType("decimal(12,2)").IsRequired();

            builder.Property(t => t.ConsultationCardConsumedTarget2).HasColumnName("consultation_card_consumed_target2").HasColumnType("int").IsRequired();
            builder.Property(t => t.CumulativeConsultationCardConsumed2).HasColumnName("cumulative_consultation_card_consumed2").HasColumnType("int").IsRequired();
            builder.Property(t => t.ConsultationCardConsumedCompleteRate2).HasColumnName("consultation_card_consumed_complete_rate2").HasColumnType("decimal(12,2)").IsRequired();


            builder.Property(t => t.ActivateHistoricalConsultationTarget).HasColumnName("activate_historical_consultation_target").HasColumnType("int").IsRequired();
            builder.Property(t => t.CumulativeActivateHistoricalConsultation).HasColumnName("cumulative_activate_historical_consultation").HasColumnType("int").IsRequired();
            builder.Property(t => t.ActivateHistoricalConsultationCompleteRate).HasColumnName("activate_historical_consultation_complete_rate").HasColumnType("decimal(12,2)").IsRequired();

            builder.Property(t => t.SendOrderTarget).HasColumnName("send_order_target").HasColumnType("int").IsRequired();
            builder.Property(t => t.CumulativeSendOrder).HasColumnName("cumulative_send_order").HasColumnType("int").IsRequired();
            builder.Property(t => t.SendOrderCompleteRate).HasColumnName("send_order_complete_rate").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.VisitTarget).HasColumnName("visit_target").HasColumnType("int").IsRequired();
            builder.Property(t => t.CumulativeVisit).HasColumnName("cumulative_visit").HasColumnType("int").IsRequired();
            builder.Property(t => t.VisitCompleteRate).HasColumnName("visit_complete_rate").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.DealTarget).HasColumnName("deal_target").HasColumnType("int").IsRequired();
            builder.Property(t => t.CumulativeDealTarget).HasColumnName("cumulative_deal_target").HasColumnType("int").IsRequired();
            builder.Property(t => t.DealRate).HasColumnName("deal_rate").HasColumnType("decimal(12,2)").IsRequired();

            builder.Property(t => t.CargoSettlementCommissionTarget).HasColumnName("cargosettlementcommission_target").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.CumulativeCargoSettlementCommission).HasColumnName("cumulation_cargosettlementcommission").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.CargoSettlementCommissionCompleteRate).HasColumnName("cargosettlementcommission_complete_rate").HasColumnType("decimal(5,2)").IsRequired();


            builder.Property(t => t.NewCustomerPerformanceTarget).HasColumnName("new_customer_performance_target").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.CumulativeNewCustomerPerformance).HasColumnName("cumulative_new_customer_performance").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.NewCustomerPerformanceCompleteRate).HasColumnName("new_customer_performance_complete_rate").HasColumnType("decimal(12,2)").IsRequired();

            builder.Property(t => t.SubsequentPerformanceTarget).HasColumnName("subsequent_performance_target").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.CumulativeSubsequentPerformance).HasColumnName("cumulative_subsequent_performance").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.SubsequentPerformanceCompleteRate).HasColumnName("subsequent_performance_complete_rate").HasColumnType("decimal(12,2)").IsRequired();

            builder.Property(t => t.OldCustomerPerformanceTarget).HasColumnName("old_customer_performance_target").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.CumulativeOldCustomerPerformance).HasColumnName("cumulative_old_customer_performance").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.OldCustomerPerformanceCompleteRate).HasColumnName("old_customer_performance_complete_rate").HasColumnType("decimal(12,2)").IsRequired();

            builder.Property(t => t.PerformanceTarget).HasColumnName("performance_target").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.CumulativePerformance).HasColumnName("cumulative_performance").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.PerformanceCompleteRate).HasColumnName("performance_complete_rate").HasColumnType("decimal(12,2)").IsRequired();

            builder.Property(t => t.MinivanRefundTarget).HasColumnName("minivan_refund_target").HasColumnType("int").IsRequired();
            builder.Property(t => t.CumulativeMinivanRefund).HasColumnName("cumulative_minivan_refund").HasColumnType("int").IsRequired();
            builder.Property(t => t.MinivanRefundCompleteRate).HasColumnName("minivan_refund_complete_rate").HasColumnType("decimal(12,2)").IsRequired();

            builder.Property(t => t.MiniVanBadReviewsTarget).HasColumnName("mini_van_bad_reviews_target").HasColumnType("int").IsRequired();
            builder.Property(t => t.CumulativeMiniVanBadReviews).HasColumnName("cumulative_mini_van_bad_reviews").HasColumnType("int").IsRequired();
            builder.Property(t => t.MiniVanBadReviewsCompleteRate).HasColumnName("mini_van_bad_reviews_complete_rate").HasColumnType("decimal(12,2)").IsRequired();

            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();


            builder.HasOne(e => e.LiveAnchor).WithMany(e => e.liveAnchorMonthlyTargets).HasForeignKey(e => e.LiveAnchorId);
        }
    }
}
