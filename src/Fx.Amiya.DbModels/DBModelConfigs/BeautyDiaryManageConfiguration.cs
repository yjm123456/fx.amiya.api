using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class BeautyDiaryManageConfiguration : IEntityTypeConfiguration<BeautyDiaryManage>
    {
        public void Configure(EntityTypeBuilder<BeautyDiaryManage> builder)
        {
            builder.ToTable("tbl_beauty_diary_manage");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.CoverTitle).HasColumnName("cover_title").HasColumnType("varchar(300)").IsRequired(false);
            builder.Property(t => t.DetailsTitle).HasColumnName("details_title").HasColumnType("varchar(300)").IsRequired(false);
            builder.Property(t => t.ReleaseState).HasColumnName("release_state").HasColumnType("bit").IsRequired();
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.Views).HasColumnName("views").HasColumnType("int").IsRequired();
            builder.Property(t => t.GivingLikes).HasColumnName("giving_likes").HasColumnType("int").IsRequired();
            builder.Property(t => t.ThumbPictureUrl).HasColumnName("thumb_picture_url").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.VideoUrl).HasColumnName("video_url").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.DetailsDescription).HasColumnName("details_description").HasColumnType("varchar(9999)").IsRequired(false);

        }
    }
}
