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
    public class ShortVideoFansDataConfiguration : IEntityTypeConfiguration<ShortVideoFansData>
    {
        public void Configure(EntityTypeBuilder<ShortVideoFansData> builder)
        {
            builder.ToTable("tbl_short_video_fans_data");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.StatsDate).HasColumnName("stats_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.NewFansCount).HasColumnName("new_fans_count").HasColumnType("int").IsRequired();
            builder.Property(e => e.TotalFansCount).HasColumnName("total_fans_count").HasColumnType("int").IsRequired();
            builder.Property(e => e.BelongLiveAnchorId).HasColumnName("belong_live_anchor_id").HasColumnType("int").IsRequired(false);

            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
        }
    }
}
