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
    public class DiaryWechatConfiguration : IEntityTypeConfiguration<DiaryWechat>
    {
        public void Configure(EntityTypeBuilder<DiaryWechat> builder)
        {
            builder.ToTable("tbl_diary_wechat");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.ContentUrl).HasColumnName("content_url").HasColumnType("varchar(500)").IsRequired();
            builder.Property(e => e.PicPath).HasColumnName("pic_path").HasColumnType("varchar(500)").IsRequired();
            builder.Property(e => e.Title).HasColumnName("title").HasColumnType("varchar(500)").IsRequired();            
        }
    }
}
