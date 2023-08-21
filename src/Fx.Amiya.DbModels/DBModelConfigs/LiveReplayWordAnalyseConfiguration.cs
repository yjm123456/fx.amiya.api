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
    public class LiveReplayWordAnalyseConfiguration : IEntityTypeConfiguration<LiveReplayWordAnalyse>
    {
        public void Configure(EntityTypeBuilder<LiveReplayWordAnalyse> builder)
        {
            builder.ToTable("tbl_live_replay_word_analyse");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.LiveReplayId).HasColumnName("live_replay_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.ReplayContent).HasColumnName("replay_content").HasColumnType("varchar(500)").IsRequired();
            builder.Property(e => e.WordManifestation).HasColumnName("word_manifestation").HasColumnType("varchar(500)").IsRequired();
            builder.Property(e => e.ProblemAnalysis).HasColumnName("problem_analysis").HasColumnType("varchar(500)").IsRequired();
            builder.Property(e => e.LaterSolution).HasColumnName("later_solution").HasColumnType("varchar(500)").IsRequired();
            builder.Property(e => e.Sort).HasColumnName("sort").HasColumnType("int").IsRequired();

            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
        }
    }
}
