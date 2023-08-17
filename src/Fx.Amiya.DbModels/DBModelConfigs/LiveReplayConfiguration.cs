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
    public class LiveReplayConfiguration : IEntityTypeConfiguration<LiveReplay>
    {
        public void Configure(EntityTypeBuilder<LiveReplay> builder)
        {
            builder.ToTable("tbl_live_replay");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.ContentPlatformId).HasColumnName("content_platform_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.LiveAnchorId).HasColumnName("liveanchor_id").HasColumnType("int").IsRequired();
            builder.Property(e => e.LiveDate).HasColumnName("live_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.LiveDuration).HasColumnName("live_duration").HasColumnType("int").IsRequired();
            builder.Property(e => e.GMV).HasColumnName("gmv").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(e => e.LivePersonnel).HasColumnName("live_personnel").HasColumnType("varchar(500)").IsRequired();
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
            

            builder.HasOne(e => e.LiveAnchor).WithMany(e => e.LiveReplayList).HasForeignKey(e => e.LiveAnchorId);
            builder.HasOne(e => e.Contentplatform).WithMany(e => e.LiveReplayList).HasForeignKey(e => e.ContentPlatformId);
        }
    }
}
