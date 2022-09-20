using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class ShootingAndClipConfiguration : IEntityTypeConfiguration<ShootingAndClip>
    {
        public void Configure(EntityTypeBuilder<ShootingAndClip> builder)
        {
            builder.ToTable("tbl_shooting_and_clip");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.ShootingEmpId).HasColumnName("shooting_empid").HasColumnType("int").IsRequired();
            builder.Property(t => t.ClipEmpId).HasColumnName("clip_empid").HasColumnType("int").IsRequired();
            builder.Property(t => t.LiveAnchorId).HasColumnName("live_anchor_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.Title).HasColumnName("title").HasColumnType("varchar(1000)").IsRequired();
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.RecordDate).HasColumnName("record_date").HasColumnType("datetime").IsRequired();

            builder.HasOne(t => t.LiveAnchor).WithMany(t => t.ShootingAndClips).HasForeignKey(t => t.LiveAnchorId);
            builder.HasOne(t => t.ClipEmoloyee).WithMany(t => t.ClipInfo).HasForeignKey(t => t.ClipEmpId);
            builder.HasOne(t => t.ShootingEmoloyee).WithMany(t => t.ShootingInfo).HasForeignKey(t => t.ShootingEmpId);
        }
    }
}
