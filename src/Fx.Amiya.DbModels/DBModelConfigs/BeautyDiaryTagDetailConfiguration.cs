using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class BeautyDiaryTagDetailConfiguration : IEntityTypeConfiguration<BeautyDiaryTagDetail>
    {
        public void Configure(EntityTypeBuilder<BeautyDiaryTagDetail> builder)
        {
            builder.ToTable("tbl_beauty_diary_tag_detail");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.BeautyDiaryId).HasColumnName("beauty_diary_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.TagId).HasColumnName("tag_id").HasColumnType("varchar(50)").IsRequired();

            builder.HasOne(t => t.BeautyDiaryManage).WithMany(t => t.BeautyDiaryTagDetailList).HasForeignKey(t => t.BeautyDiaryId);
            builder.HasOne(t => t.BeautyDiaryTagInfo).WithMany(t => t.BeautyDiaryTagDetail).HasForeignKey(t => t.TagId);
        }
    }
}
