﻿using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class LiveAnchorDailyTargetConfiguration : IEntityTypeConfiguration<AfterLiveAnchorDailyTarget>
    {
        public void Configure(EntityTypeBuilder<AfterLiveAnchorDailyTarget> builder)
        {
            builder.ToTable("tbl_liveanchor_daily_target");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.LiveanchorMonthlyTargetId).HasColumnName("liveanchor_monthly_target_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.RecordDate).HasColumnName("record_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.LivingTrackingEmployeeId).HasColumnName("living_tracking_employee_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.NetWorkConsultingEmployeeId).HasColumnName("network_consulting_employee_id").HasColumnType("int").IsRequired();

            builder.Property(t => t.TikTokOperationEmployeeId).HasColumnName("tik_tok_operation_employee_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.TikTokSendNum).HasColumnName("tiktok_send_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.TikTokFlowInvestmentNum).HasColumnName("tiktok_flow_investment_num").HasColumnType("decimal(12,2)").IsRequired();

            builder.Property(t => t.ZhihuOperationEmployeeId).HasColumnName("zhihu_operation_employee_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.ZhihuSendNum).HasColumnName("zhihu_send_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.ZhihuFlowInvestmentNum).HasColumnName("zhihu_flow_investment_num").HasColumnType("decimal(12,2)").IsRequired();

            builder.Property(t => t.XiaoHongShuOperationEmployeeId).HasColumnName("xiaohongshu_operation_employee_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.XiaoHongShuSendNum).HasColumnName("xiaohongshu_send_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.XiaoHongShuFlowInvestmentNum).HasColumnName("xiaohongshu_flow_investment_num").HasColumnType("decimal(12,2)").IsRequired();

            builder.Property(t => t.VideoOperationEmployeeId).HasColumnName("video_operation_employee_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.VideoSendNum).HasColumnName("video_send_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.VideoFlowInvestmentNum).HasColumnName("video_flow_investment_num").HasColumnType("decimal(12,2)").IsRequired();

            builder.Property(t => t.SinaWeiBoOperationEmployeeId).HasColumnName("sina_weibo_operation_employee_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.SinaWeiBoSendNum).HasColumnName("sinaweibo_send_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.SinaWeiBoFlowInvestmentNum).HasColumnName("sinaweibo_flow_investment_num").HasColumnType("decimal(12,2)").IsRequired();

            builder.Property(t => t.TodaySendNum).HasColumnName("today_send_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.FlowInvestmentNum).HasColumnName("flow_investment_num").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.LivingRoomFlowInvestmentNum).HasColumnName("livingroomflow_investment_num").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.CluesNum).HasColumnName("clue_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.AddFansNum).HasColumnName("add_fans_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.AddWechatNum).HasColumnName("add_wechat_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.Consultation).HasColumnName("consultation_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.Consultation2).HasColumnName("consultation_num2").HasColumnType("int").IsRequired();
            builder.Property(t => t.ConsultationCardConsumed).HasColumnName("consultation_card_consumed").HasColumnType("int").IsRequired();
            builder.Property(t => t.ConsultationCardConsumed2).HasColumnName("consultation_card_consumed2").HasColumnType("int").IsRequired();
            builder.Property(t => t.ActivateHistoricalConsultation).HasColumnName("activate_historical_consultation").HasColumnType("int").IsRequired();
            builder.Property(t => t.SendOrderNum).HasColumnName("send_order_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.NewVisitNum).HasColumnName("new_visit_nun").HasColumnType("int").IsRequired();
            builder.Property(t => t.VisitNum).HasColumnName("visit_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.SubsequentVisitNum).HasColumnName("subsequent_visit_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.OldCustomerVisitNum).HasColumnName("old_customer_visit_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.NewDealNum).HasColumnName("new_deal_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.SubsequentDealNum).HasColumnName("subsequent_deal_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.OldCustomerDealNum).HasColumnName("old_customer_deal_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.DealNum).HasColumnName("deal_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.CargoSettlementCommission).HasColumnName("cargosettlementcommission").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.NewPerformanceNum).HasColumnName("new_performance_num").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.SubsequentPerformanceNum).HasColumnName("subsequent_performance_num").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.NewCustomerPerformanceCountNum).HasColumnName("new_customer_performance_count_num").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.MiniVanBadReviews).HasColumnName("mini_van_bad_reviews").HasColumnType("int").IsRequired();
            builder.Property(t => t.MinivanRefund).HasColumnName("mini_van_refund").HasColumnType("int").IsRequired();
            builder.Property(t => t.OldCustomerPerformanceNum).HasColumnName("old_customer_performance_num").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.PerformanceNum).HasColumnName("performance_num").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.TikTokUpdateDate).HasColumnName("tiktok_update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.LivingUpdateDate).HasColumnName("living_update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.AfterLivingUpdateDate).HasColumnName("after_living_update_date").HasColumnType("datetime").IsRequired(false);

            builder.HasOne(e => e.LiveAnchorMonthlyTarget).WithMany(e => e.LiveAnchorDailyTargets).HasForeignKey(e => e.LiveanchorMonthlyTargetId);
        }
    }
}
