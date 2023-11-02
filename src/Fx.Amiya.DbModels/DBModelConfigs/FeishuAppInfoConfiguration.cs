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
    public class FeishuAppInfoConfiguration : IEntityTypeConfiguration<FeishuAppInfo>
    {
        public void Configure(EntityTypeBuilder<FeishuAppInfo> builder)
        {
            builder.ToTable("tbl_feishu_app_info");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.Code).HasColumnName("code").HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.AppId).HasColumnName("app_id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(e=>e.AppSecret).HasColumnName("app_secret").HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.AppToken).HasColumnName("app_token").HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.TableId).HasColumnName("table_id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.AccessToken).HasColumnName("access_token").HasColumnType("varchar(100)").IsRequired(false);
            builder.Property(e => e.ExpireDate).HasColumnName("expire_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.BelongLiveAnchorId).HasColumnName("belong_live_anchor_id").HasColumnType("int").IsRequired();
            builder.Property(e => e.Remark).HasColumnName("remark").HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
        }
    }
}
