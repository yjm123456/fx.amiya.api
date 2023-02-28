using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class LiveAnchorBaseInfoConfiguration : IEntityTypeConfiguration<LiveAnchorBaseInfo>
    {
        public void Configure(EntityTypeBuilder<LiveAnchorBaseInfo> builder)
        {
            builder.ToTable("tbl_live_anchor_base_info");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.LiveAnchorName).HasColumnName("live_anchor_name").HasColumnType("varchar(100)").IsRequired(false);
            builder.Property(t => t.ThumbPicture).HasColumnName("thumb_picture").HasColumnType("varchar(300)").IsRequired(false);
            builder.Property(t => t.NickName).HasColumnName("nick_name").HasColumnType("varchar(45)").IsRequired(false);
            builder.Property(t => t.IndividualitySignature).HasColumnName("individuality_signature").HasColumnType("varchar(200)").IsRequired(false);
            builder.Property(t => t.Description).HasColumnName("description").HasColumnType("varchar(400)").IsRequired(false);
            builder.Property(t => t.DetailPicture).HasColumnName("detail_picture").HasColumnType("varchar(300)").IsRequired(false);
            builder.Property(t => t.VideoUrl).HasColumnName("video_url").HasColumnType("varchar(300)").IsRequired(false);
            builder.Property(t => t.ContractUrl).HasColumnName("contract_url").HasColumnType("varchar(300)").IsRequired(false);
            builder.Property(t => t.IsMain).HasColumnName("is_main").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.DueTime).HasColumnName("due_time").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(t => t.IsSelfLivevAnchor).HasColumnName("is_self_live_anchor").HasColumnType("bit").IsRequired();
        }
    }
}
