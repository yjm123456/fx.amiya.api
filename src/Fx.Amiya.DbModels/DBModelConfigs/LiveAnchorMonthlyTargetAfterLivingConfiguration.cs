using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class LiveAnchorMonthlyTargetAfterLivingConfiguration : IEntityTypeConfiguration<LiveAnchorMonthlyTargetAfterLiving>
    {
        public void Configure(EntityTypeBuilder<LiveAnchorMonthlyTargetAfterLiving> builder)
        {
            builder.ToTable("tbl_liveanchor_monthly_target_after_living");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(120)").IsRequired();
            builder.Property(t => t.Year).HasColumnName("year").HasColumnType("int").IsRequired();
            builder.Property(t => t.Month).HasColumnName("month").HasColumnType("int").IsRequired();
            builder.Property(t => t.MonthlyTargetName).HasColumnName("monthly_target_name").HasColumnType("varchar(200)").IsRequired(false);
            builder.Property(t => t.LiveAnchorId).HasColumnName("live_anchor_id").HasColumnType("int").IsRequired();

            builder.Property(t => t.AddWechatTarget).HasColumnName("add_wechat_target").HasColumnType("int").IsRequired();
            builder.Property(t => t.CumulativeAddWechat).HasColumnName("cumulative_add_wechat").HasColumnType("int").IsRequired();
            builder.Property(t => t.AddWechatCompleteRate).HasColumnName("add_wechat_complete_rate").HasColumnType("decimal(12,2)").IsRequired();

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


            builder.Property(t => t.NewCustomerVisitTarget).HasColumnName("new_customer_visit_target").HasColumnType("int").IsRequired();
            builder.Property(t => t.CumulativeNewCustomerVisit).HasColumnName("cumulative_new_customer_visit").HasColumnType("int").IsRequired();
            builder.Property(t => t.NewCustomerVisitCompleteRate).HasColumnName("new_customer_visit_complete_rate").HasColumnType("decimal(12,2)").IsRequired();

            builder.Property(t => t.OldCustomerVisitTarget).HasColumnName("old_customer_visit_target").HasColumnType("int").IsRequired();
            builder.Property(t => t.CumulativeOldCustomerVisit).HasColumnName("cumulative_old_customer_visit").HasColumnType("int").IsRequired();
            builder.Property(t => t.OldCustomerVisitCompleteRate).HasColumnName("old_customer_visit_complete_rate").HasColumnType("decimal(12,2)").IsRequired();

            builder.Property(t => t.VisitTarget).HasColumnName("visit_target").HasColumnType("int").IsRequired();
            builder.Property(t => t.CumulativeVisit).HasColumnName("cumulative_visit").HasColumnType("int").IsRequired();
            builder.Property(t => t.VisitCompleteRate).HasColumnName("visit_complete_rate").HasColumnType("decimal(12,2)").IsRequired();

            builder.Property(t => t.NewCustomerDealTarget).HasColumnName("new_customer_deal_target").HasColumnType("int").IsRequired();
            builder.Property(t => t.CumulativeNewCustomerDealTarget).HasColumnName("cumulative_new_customer_deal").HasColumnType("int").IsRequired();
            builder.Property(t => t.NewCustomerDealRate).HasColumnName("new_customer_deal_complete_rate").HasColumnType("decimal(12,2)").IsRequired();


            builder.Property(t => t.OldCustomerDealTarget).HasColumnName("old_customer_deal_target").HasColumnType("int").IsRequired();
            builder.Property(t => t.CumulativeOldCustomerDealTarget).HasColumnName("cumulative_old_customer_deal").HasColumnType("int").IsRequired();
            builder.Property(t => t.OldCustomerDealRate).HasColumnName("old_customer_deal_complete_rate").HasColumnType("decimal(12,2)").IsRequired();


            builder.Property(t => t.DealTarget).HasColumnName("deal_target").HasColumnType("int").IsRequired();
            builder.Property(t => t.CumulativeDealTarget).HasColumnName("cumulative_deal_target").HasColumnType("int").IsRequired();
            builder.Property(t => t.DealRate).HasColumnName("deal_rate").HasColumnType("decimal(12,2)").IsRequired();

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

            builder.Property(t => t.EffectivePerformanceTarget).HasColumnName("effective_performance").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(t => t.CumulativeEffectivePerformance).HasColumnName("cumulative_effective_performance").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(t => t.EffectivePerformanceCompleteRate).HasColumnName("effective_performance_complete_rate").HasColumnType("decimal(10,2)").IsRequired();

            builder.Property(t => t.PotentialPerformanceTarget).HasColumnName("potential_performance").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(t => t.CumulativePotentialPerformance).HasColumnName("cumulative_potential_performance").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(t => t.PotentialPerformanceCompleteRate).HasColumnName("potential_performance_completeRate").HasColumnType("decimal(10,2)").IsRequired();

            builder.Property(t => t.DistributeConsulationTarget).HasColumnName("distribute_consulation_target").HasColumnType("int").IsRequired();
            builder.Property(t => t.CumulativeDistributeConsulation).HasColumnName("cumulative_distribute_consulation").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(t => t.DistributeConsulationCompleteRate).HasColumnName("distribute_consulation_completeRate").HasColumnType("decimal(10,2)").IsRequired();


            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();


            builder.HasOne(e => e.LiveAnchor).WithMany(e => e.LiveAnchorMonthlyTargetAfterLivings).HasForeignKey(e => e.LiveAnchorId);
        }
    }
}
