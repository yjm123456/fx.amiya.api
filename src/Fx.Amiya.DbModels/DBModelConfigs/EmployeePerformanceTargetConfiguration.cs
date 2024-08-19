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
    public class EmployeePerformanceTargetConfiguration : IEntityTypeConfiguration<EmployeePerformanceTarget>
    {
        public void Configure(EntityTypeBuilder<EmployeePerformanceTarget> builder)
        {
            builder.ToTable("tbl_employee_performance_target");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.BelongYear).HasColumnName("belong_year").HasColumnType("int").IsRequired();
            builder.Property(e => e.BelongMonth).HasColumnName("belong_month").HasColumnType("int").IsRequired();
            builder.Property(e => e.EmployeeId).HasColumnName("employee_id").HasColumnType("int").IsRequired();
            builder.Property(e => e.EffectiveAddWechatTarget).HasColumnName("effective_add_wechat_target").HasColumnType("int").IsRequired();
            builder.Property(e => e.PotentialAddWechatTarget).HasColumnName("potential_add_wechat_target").HasColumnType("int").IsRequired();
            builder.Property(e => e.EffectiveConsulationCardTarget).HasColumnName("effective_consulation_card_target").HasColumnType("int").IsRequired();
            builder.Property(e => e.PotentialConsulationCardTarget).HasColumnName("potential_consulation_card_target").HasColumnType("int").IsRequired();
            builder.Property(e => e.SendOrderTarget).HasColumnName("send_order_target").HasColumnType("int").IsRequired();
            builder.Property(e => e.OldCustomerVisitTarget).HasColumnName("old_customer_visit_target").HasColumnType("int").IsRequired();
            builder.Property(e => e.NewCustomerVisitTarget).HasColumnName("new_customer_visit_target").HasColumnType("int").IsRequired();
            builder.Property(e => e.NewCustomerDealTarget).HasColumnName("new_customer_deal_target").HasColumnType("int").IsRequired();
            builder.Property(e => e.OldCustomerDealTarget).HasColumnName("old_customer_deal_target").HasColumnType("int").IsRequired();
            builder.Property(e => e.NewCustomerPerformanceTarget).HasColumnName("new_customer_performance_target").HasColumnType("DECIMAL(12,2)").IsRequired();
            builder.Property(e => e.OldCustomerPerformanceTarget).HasColumnName("old_customer_performance_target").HasColumnType("DECIMAL(12,2)").IsRequired();
            builder.Property(e => e.PerformanceTarget).HasColumnName("performance_target").HasColumnType("DECIMAL(12,2)").IsRequired();
            builder.Property(e => e.CluesRegisterTarget).HasColumnName("clues_register_target").HasColumnType("int").IsRequired().HasDefaultValue(0);

            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("DATETIME").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("DATETIME").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("BIT(1)").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("DATETIME").IsRequired(false);

            builder.HasOne(t => t.AmiyaEmployee).WithMany(t => t.EmployeePerformanceTargetList).HasForeignKey(t => t.EmployeeId);
        }
    }
}
