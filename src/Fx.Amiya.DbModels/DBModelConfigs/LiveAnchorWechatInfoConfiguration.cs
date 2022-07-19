using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class LiveAnchorWechatInfoConfiguration : IEntityTypeConfiguration<LiveAnchorWeChatInfo>
    {
        public void Configure(EntityTypeBuilder<LiveAnchorWeChatInfo> builder)
        {
            builder.ToTable("tbl_live_anchor_wechat_info");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(t => t.LiveAnchorId).HasColumnName("live_anchor_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.WeChatNo).HasColumnName("wechat_no").HasColumnType("VARCHAR(100)").IsRequired(false);
            builder.Property(t => t.NickName).HasColumnName("nick_name").HasColumnType("varchar(200)").IsRequired(false);
            builder.Property(t => t.Remark).HasColumnName("remark").HasColumnType("varchar(300)").IsRequired(false);
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();

            builder.HasOne(e => e.LiveAnchor).WithMany(e => e.LiveAnchorWeChatInfo).HasForeignKey(e => e.LiveAnchorId);
        }
    }
}
