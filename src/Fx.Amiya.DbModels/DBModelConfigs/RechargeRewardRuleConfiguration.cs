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
    public class RechargeRewardRuleConfiguration : IEntityTypeConfiguration<RechargeRewardRule>
    {
        public void Configure(EntityTypeBuilder<RechargeRewardRule> builder)
        {
            builder.ToTable("tbl_recharge_reward_rule");
            builder.HasKey(e=>e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.MinAmount).HasColumnName("min_amount").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(e => e.GiveIntegration).HasColumnName("give_integration").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(e => e.GiveMoney).HasColumnName("give_money").HasColumnType("decimal(10,2)").IsRequired();
        }
    }
}
