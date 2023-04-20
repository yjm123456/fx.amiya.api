using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class HomepageCarouselImageConfiguration : IEntityTypeConfiguration<HomepageCarouselImage>
    {
        public void Configure(EntityTypeBuilder<HomepageCarouselImage> builder)
        {
            builder.ToTable("tbl_homepage_carousel_image");
            builder.HasKey(t => t.Id);
            builder.Property(t=>t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t=>t.PicUrl).HasColumnName("pic_url").HasColumnType("varchar(500)").IsRequired();
            builder.Property(t=>t.DisplayIndex).HasColumnName("display_index").HasColumnType("tinyint").IsRequired();
            builder.Property(t=>t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.LinkUrl).HasColumnName("link_url").HasColumnType("varchar(200)").IsRequired();
            builder.Property(t => t.AppId).HasColumnName("appid").HasColumnType("varchar(100)").IsRequired(false);
        }
    }
}
