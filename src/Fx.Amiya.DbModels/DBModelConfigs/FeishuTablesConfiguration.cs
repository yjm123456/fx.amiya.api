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
    public class FeishuTablesConfiguration : IEntityTypeConfiguration<FeishuTables>
    {
        public void Configure(EntityTypeBuilder<FeishuTables> builder)
        {
            builder.ToTable("tbl_feishu_table");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.AppToken).HasColumnName("app_token").HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.TableId).HasColumnName("table_id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.BelongAppId).HasColumnName("belong_app_id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.TableType).HasColumnName("table_type").HasColumnType("int").IsRequired();
            builder.Property(e => e.LiveAnchorId).HasColumnName("live_anchorId").HasColumnType("int").IsRequired();

            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
        }
    }
}
