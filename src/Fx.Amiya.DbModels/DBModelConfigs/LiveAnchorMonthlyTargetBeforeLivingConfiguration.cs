using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class LiveAnchorMonthlyTargetBeforeLivingConfiguration : IEntityTypeConfiguration<LiveAnchorMonthlyTargetBeforeLiving>
    {
        public void Configure(EntityTypeBuilder<LiveAnchorMonthlyTargetBeforeLiving> builder)
        {
            builder.ToTable("tbl_liveanchor_monthly_target_before_living");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(120)").IsRequired();
            builder.Property(t => t.Year).HasColumnName("year").HasColumnType("int").IsRequired();
            builder.Property(t => t.Month).HasColumnName("month").HasColumnType("int").IsRequired();
            builder.Property(t => t.MonthlyTargetName).HasColumnName("monthly_target_name").HasColumnType("varchar(200)").IsRequired(false);
            builder.Property(t => t.LiveAnchorId).HasColumnName("live_anchor_id").HasColumnType("int").IsRequired();

            builder.Property(t => t.ZhihuReleaseTarget).HasColumnName("zhihu_release_target").HasColumnType("int").IsRequired();
            builder.Property(t => t.CumulativeZhihuRelease).HasColumnName("cumulative_zhihu_release").HasColumnType("int").IsRequired();
            builder.Property(t => t.ZhihuReleaseCompleteRate).HasColumnName("zhihu_release_complete_rate").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.ZhihuFlowinvestmentTarget).HasColumnName("zhihu_flow_investment_target").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.CumulativeZhihuFlowinvestment).HasColumnName("cumulative_zhihu_flow_investment").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.ZhihuFlowinvestmentCompleteRate).HasColumnName("zhihu_flow_investment_complete_rate").HasColumnType("decimal(12,2)").IsRequired();

            builder.Property(t => t.SinaWeiBoReleaseTarget).HasColumnName("sina_weibo_release_target").HasColumnType("int").IsRequired();
            builder.Property(t => t.CumulativeSinaWeiBoRelease).HasColumnName("cumulative_sina_weibo_release").HasColumnType("int").IsRequired();
            builder.Property(t => t.SinaWeiBoReleaseCompleteRate).HasColumnName("sina_weibo_release_complete_rate").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.SinaWeiBoFlowinvestmentTarget).HasColumnName("sina_weibo_flow_investment_target").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.CumulativeSinaWeiBoFlowinvestment).HasColumnName("cumulative_sina_weibo_flow_investment").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.SinaWeiBoFlowinvestmentCompleteRate).HasColumnName("sina_weibo_flow_investment_complete_rate").HasColumnType("decimal(12,2)").IsRequired();

            builder.Property(t => t.TikTokReleaseTarget).HasColumnName("tiktok_release_target").HasColumnType("int").IsRequired();
            builder.Property(t => t.CumulativeTikTokRelease).HasColumnName("cumulative_tiktok_release").HasColumnType("int").IsRequired();
            builder.Property(t => t.TikTokReleaseCompleteRate).HasColumnName("tiktok_release_complete_rate").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.TikTokFlowinvestmentTarget).HasColumnName("tik_tok_flow_investment_target").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.CumulativeTikTokFlowinvestment).HasColumnName("cumulative_tik_tok_flow_investment").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.TikTokFlowinvestmentCompleteRate).HasColumnName("tik_tok_flow_investment_complete_rate").HasColumnType("decimal(12,2)").IsRequired();

            builder.Property(t => t.XiaoHongShuReleaseTarget).HasColumnName("xiaohongshu_release_target").HasColumnType("int").IsRequired();
            builder.Property(t => t.CumulativeXiaoHongShuRelease).HasColumnName("cumulative_xiaohongshu_release").HasColumnType("int").IsRequired();
            builder.Property(t => t.XiaoHongShuReleaseCompleteRate).HasColumnName("xiaohongshu_release_complete_rate").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.XiaoHongShuFlowinvestmentTarget).HasColumnName("xiaohongshu_flow_investment_target").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.CumulativeXiaoHongShuFlowinvestment).HasColumnName("cumulative_xiaohongshu_flow_investment").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.XiaoHongShuFlowinvestmentCompleteRate).HasColumnName("xiaohongshu_flow_investment_complete_rate").HasColumnType("decimal(12,2)").IsRequired();

            builder.Property(t => t.VideoReleaseTarget).HasColumnName("video_release_target").HasColumnType("int").IsRequired();
            builder.Property(t => t.CumulativeVideoRelease).HasColumnName("cumulative_video_release").HasColumnType("int").IsRequired();
            builder.Property(t => t.VideoReleaseCompleteRate).HasColumnName("video_release_complete_rate").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.VideoFlowinvestmentTarget).HasColumnName("video_flow_investment_target").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.CumulativeVideoFlowinvestment).HasColumnName("cumulative_video_flow_investment").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.VideoFlowinvestmentCompleteRate).HasColumnName("video_flow_investment_complete_rate").HasColumnType("decimal(12,2)").IsRequired();

            builder.Property(t => t.ReleaseTarget).HasColumnName("release_target").HasColumnType("int").IsRequired();
            builder.Property(t => t.CumulativeRelease).HasColumnName("cumulative_release").HasColumnType("int").IsRequired();
            builder.Property(t => t.ReleaseCompleteRate).HasColumnName("release_complete_rate").HasColumnType("decimal(12,2)").IsRequired();

            builder.Property(t => t.FlowInvestmentTarget).HasColumnName("flow_investment_target").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.CumulativeFlowInvestment).HasColumnName("cumulative_flow_investment").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.FlowInvestmentCompleteRate).HasColumnName("flow_investment_complete_rate").HasColumnType("decimal(12,2)").IsRequired();


            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.HasOne(e => e.LiveAnchor).WithMany(e => e.LiveAnchorMonthlyTargetBeforeLivings).HasForeignKey(e => e.LiveAnchorId);
        }
    }
}
