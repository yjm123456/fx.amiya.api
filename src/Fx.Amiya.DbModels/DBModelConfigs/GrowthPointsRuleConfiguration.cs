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
    public class GrowthpointsRuleConfiguration : IEntityTypeConfiguration<GrowthPointsRule>
    {
        public void Configure(EntityTypeBuilder<GrowthPointsRule> builder)
        {
            builder.ToTable("tbl_growth_points_rule");
            builder.HasKey(p=>p.Id);
            builder.Property(p => p.Id).HasColumnName("id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(p => p.Name).HasColumnName("name").HasColumnType("varchar(100)").IsRequired();
            builder.Property(p => p.TaskCode).HasColumnName("task_code").HasColumnType("varchar(100)").IsRequired();
            builder.Property(p => p.Type).HasColumnName("type").HasColumnType("int").IsRequired();
            builder.Property(p => p.RewardQuantity).HasColumnName("reward_quantity").HasColumnType("decimal(10,2)").HasDefaultValue(0).IsRequired();
            builder.Property(p => p.RewardQuantityPercent).HasColumnName("reward_quantity_percent").HasColumnType("decimal(10,2)").IsRequired().HasDefaultValue(0);

        }
    }
}
