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
    public class TikTokShortVideoDataConfiguration : IEntityTypeConfiguration<TikTokShortVideoData>
    {
        public void Configure(EntityTypeBuilder<TikTokShortVideoData> builder)
        {
            builder.ToTable("tbl_tiktok_short_video_data");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.PlayNum).HasColumnName("play_num").HasColumnType("int").IsRequired(false);
            builder.Property(e => e.Title).HasColumnName("title").HasColumnType("varchar(200)").IsRequired(false);
            builder.Property(e => e.Like).HasColumnName("like").HasColumnType("int").IsRequired(false);
            builder.Property(e => e.VideoId).HasColumnName("video_id").HasColumnType("varchar(200)").IsRequired(false);
            builder.Property(e => e.Comments).HasColumnName("comments").HasColumnType("int").IsRequired(false);
            builder.Property(e => e.BelongLiveAnchorId).HasColumnName("belong_live_anchor_id").HasColumnType("int").IsRequired(false);
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
        }
    }
}
