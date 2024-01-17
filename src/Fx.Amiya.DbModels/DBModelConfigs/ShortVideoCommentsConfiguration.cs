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
    public class ShortVideoCommentsConfiguration : IEntityTypeConfiguration<ShortVideoComments>
    {
        public void Configure(EntityTypeBuilder<ShortVideoComments> builder)
        {
            builder.ToTable("tbl_short_video_comments");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.CommentsId).HasColumnName("comments_id").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(e => e.CommentsUserId).HasColumnName("comments_user_id").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(e => e.CommentsUserName).HasColumnName("comments_user_name").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(e => e.LikeCount).HasColumnName("like_count").HasColumnType("int").IsRequired();
            builder.Property(e => e.Comments).HasColumnName("comments").HasColumnType("varchar(1000)").IsRequired(false);
            builder.Property(e => e.CommentsDate).HasColumnName("comments_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.BelongLiveAnchorId).HasColumnName("belong_live_anchor_id").HasColumnType("int").IsRequired(false);

            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
        }
    }
}
