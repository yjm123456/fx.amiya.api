using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class BeautyDiaryBannerImageConfiguration : IEntityTypeConfiguration<BeautyDiaryBannerImage>
    {
        public void Configure(EntityTypeBuilder<BeautyDiaryBannerImage> builder)
        {
            builder.ToTable("tbl_beauty_diary_banner_image");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.BeautyDiaryId).HasColumnName("beauty_diary_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.PicUrl).HasColumnName("pic_url").HasColumnType("varchar(500)").IsRequired();
            builder.Property(t => t.DisplayIndex).HasColumnName("display_index").HasColumnType("tinyint").IsRequired();
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.UpdateDate).HasColumnName("update_date").HasColumnType("datetime");

            builder.HasOne(t => t.BeautyDiary).WithMany(e => e.BannerImages).HasForeignKey(e => e.BeautyDiaryId);
        }
    }
}
