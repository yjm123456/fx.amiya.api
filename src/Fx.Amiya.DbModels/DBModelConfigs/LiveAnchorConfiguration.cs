using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class LiveAnchorConfiguration : IEntityTypeConfiguration<LiveAnchor>
    {
        public void Configure(EntityTypeBuilder<LiveAnchor> builder)
        {
            builder.ToTable("tbl_live_anchor");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t => t.Name).HasColumnName("name").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.HostAccountName).HasColumnName("host_account_name").HasColumnType("varchar(45)").IsRequired(false);
            builder.Property(t => t.ContentPlateFormId).HasColumnName("content_plateform_id").HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
        }
    }
}
