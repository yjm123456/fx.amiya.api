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
    public class LiveReplayInteractionlDataConfiguration : IEntityTypeConfiguration<LiveReplayInteractionlData>
    {
        public void Configure(EntityTypeBuilder<LiveReplayInteractionlData> builder)
        {
            builder.ToTable("tbl_live_replay_interactionl_data");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.LiveReplayId).HasColumnName("live_replay_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.ReplayTarget).HasColumnName("replay_target").HasColumnType("VARCHAR(100)").IsRequired(false);
            builder.Property(e => e.DataTarget).HasColumnName("data_target").HasColumnType("DECIMAL(12,2)").IsRequired();
            builder.Property(e => e.LastLivingData).HasColumnName("last_living_data").HasColumnType("DECIMAL(12,2)").IsRequired();
            builder.Property(e => e.LastLivingCompare).HasColumnName("last_living_compare").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(e => e.QuestionAnalize).HasColumnName("question_analize").HasColumnType("varchar(3000)").IsRequired(false);
            builder.Property(e => e.LaterPeriodSolution).HasColumnName("later_period_solution").HasColumnType("varchar(3000)").IsRequired(false);
            builder.Property(e => e.Sort).HasColumnName("sort").HasColumnType("int").IsRequired();

            builder.HasOne(e => e.LiveReplay).WithMany(e => e.LiveReplayInteractionlDataList).HasForeignKey(e => e.LiveReplayId);
        }
    }
}
