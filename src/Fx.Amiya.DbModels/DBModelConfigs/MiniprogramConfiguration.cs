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
    class MiniprogramConfiguration:IEntityTypeConfiguration<Miniprogram>
    {
        public void Configure(EntityTypeBuilder<Miniprogram> builder)
        {
            builder.ToTable("tbl_miniprogram");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.Name).HasColumnName("name").HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.AppId).HasColumnName("appid").HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.IsMain).HasColumnName("is_main").HasColumnType("bit").IsRequired();
            builder.Property(e => e.BelongLiveAnchorId).HasColumnName("belong_live_anchor_id").HasColumnType("int").IsRequired(false);
            builder.Property(e => e.BelongMiniprogramAppId).HasColumnName("belong_appId").HasColumnType("varchar(100)").IsRequired(false);

            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
        }
    }
}
