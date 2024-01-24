using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class BeforeLivingXiaoHongShuDailyTragetConfiguration : IEntityTypeConfiguration<BeforeLivingXiaoHongShuDailyTarget>
    {
        public void Configure(EntityTypeBuilder<BeforeLivingXiaoHongShuDailyTarget> builder)
        {
            builder.ToTable("tbl_beforeliving_xiaohongshu_daily_target");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.LiveAnchorMonthlyTargetId).HasColumnName("live_anchor_monthly_target_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.OperationEmpId).HasColumnName("operation_empId").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.FlowInvestmentNum).HasColumnName("flow_investment_num").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(e => e.SendNum).HasColumnName("send_num").HasColumnType("int").IsRequired();
            builder.Property(e => e.RecordDate).HasColumnName("record_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.XiaoHongShuClues).HasColumnName("xiaohongshu_clues").HasColumnType("int").IsRequired();
            builder.Property(t => t.XiaoHongShuIncreaseFans).HasColumnName("xiaohongshu_increase_fans").HasColumnType("int").IsRequired();
            builder.Property(t => t.XiaoHongShuIncreaseFansFees).HasColumnName("xiaohongshu_increase_fans_fees").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.XiaoHongShuIncreaseFansFeesCost).HasColumnName("xiaohongshu_increase_fans_fees_cost").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.XiaoHongShuShowcaseIncome).HasColumnName("xiaohongshu_showcase_income").HasColumnType("decimal(12, 2)").IsRequired();
            builder.Property(t => t.XiaoHongShuShowCaseFee).HasColumnName("xiaohongshu_showcase_fee").HasColumnType("decimal(12,2)").IsRequired();
            builder.HasOne(e => e.LiveAnchorMonthlyTargetBeforeLiving).WithMany(e => e.beforeLivingXiaoHongShuDailyTraget).HasForeignKey(e => e.LiveAnchorMonthlyTargetId);
            builder.HasOne(e => e.AmiyaEmployee).WithMany(e => e.beforeLivingXiaoHongShuDailyTragets).HasForeignKey(e => e.OperationEmpId);
        }
    }
}
