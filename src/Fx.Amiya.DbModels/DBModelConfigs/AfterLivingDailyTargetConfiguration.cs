using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class AfterLivingDailyTargetConfiguration : IEntityTypeConfiguration<AfterLivingDailyTarget>
    {
        public void Configure(EntityTypeBuilder<AfterLivingDailyTarget> builder)
        {
            builder.ToTable("tbl_after_living_daily_target");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.LiveAnchorMonthlyTargetId).HasColumnName("live_anchor_monthly_target_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.OperationEmpId).HasColumnName("operation_empId").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.AddWechatNum).HasColumnName("add_wechat_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.ConsultationCardConsumed).HasColumnName("consultation_card_consumed").HasColumnType("int").IsRequired();
            builder.Property(t => t.ConsultationCardConsumed2).HasColumnName("consultation_card_consumed2").HasColumnType("int").IsRequired();
            builder.Property(t => t.ActivateHistoricalConsultation).HasColumnName("activate_historical_consultation").HasColumnType("int").IsRequired();
            builder.Property(t => t.SendOrderNum).HasColumnName("send_order_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.NewVisitNum).HasColumnName("new_visit_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.VisitNum).HasColumnName("visit_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.SubsequentVisitNum).HasColumnName("subsequent_visit_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.OldCustomerVisitNum).HasColumnName("old_customer_visit_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.NewDealNum).HasColumnName("new_deal_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.SubsequentDealNum).HasColumnName("subsequent_deal_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.OldCustomerDealNum).HasColumnName("old_customer_deal_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.DealNum).HasColumnName("deal_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.NewPerformanceNum).HasColumnName("new_performance_num").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.SubsequentPerformanceNum).HasColumnName("subsequent_performance_num").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.NewCustomerPerformanceCountNum).HasColumnName("new_customer_performance_count_num").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.MiniVanBadReviews).HasColumnName("mini_van_bad_reviews").HasColumnType("int").IsRequired();
            builder.Property(t => t.MinivanRefund).HasColumnName("mini_van_refund").HasColumnType("int").IsRequired();
            builder.Property(t => t.OldCustomerPerformanceNum).HasColumnName("old_customer_performance_num").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.PerformanceNum).HasColumnName("performance_num").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.EffectivePerformance).HasColumnName("effective_performance").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(t => t.PotentialPerformance).HasColumnName("potential_performance").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(t => t.DistributeConsulation).HasColumnName("distribute_consulation").HasColumnType("int").IsRequired();
            builder.Property(e => e.RecordDate).HasColumnName("record_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
            builder.HasOne(e => e.LiveAnchorMonthlyTargetAfterLiving).WithMany(e => e.AfterLivingDailyTarget).HasForeignKey(e => e.LiveAnchorMonthlyTargetId);
            builder.HasOne(e => e.AmiyaEmployee).WithMany(e => e.afterLivingDailyTarget).HasForeignKey(e => e.OperationEmpId);
        }
    }
}
