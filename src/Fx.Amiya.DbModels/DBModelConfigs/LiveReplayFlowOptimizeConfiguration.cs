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
    public class LiveReplayFlowOptimizeConfiguration : IEntityTypeConfiguration<LiveReplayFlowOptimize>
    {
        public void Configure(EntityTypeBuilder<LiveReplayFlowOptimize> builder)
        {
            builder.ToTable("tbl_live_replay_flow_optimize");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.LiveReplayId).HasColumnName("live_replay_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.FlowSource).HasColumnName("flow_source").HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.Proportion).HasColumnName("proportion").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(e => e.DrainageCount).HasColumnName("drainage_count").HasColumnType("int").IsRequired();
            builder.Property(e => e.LastDrainageCount).HasColumnName("last_drainage_count").HasColumnType("int").IsRequired();
            builder.Property(e => e.LastDrainageProportion).HasColumnName("last_drainage_proportion").HasColumnType("decimal(10,2)").IsRequired();           
            builder.Property(e => e.ProblemAnalysis).HasColumnName("problem_analysis").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(e => e.LaterSolution).HasColumnName("later_solution").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(e => e.Sort).HasColumnName("sort").HasColumnType("int").IsRequired();

            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
        }
    }
}
