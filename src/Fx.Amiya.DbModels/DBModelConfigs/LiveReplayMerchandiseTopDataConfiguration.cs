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
    public class LiveReplayMerchandiseTopDataConfiguration : IEntityTypeConfiguration<LiveReplayMerchandiseTopData>
    {
        public void Configure(EntityTypeBuilder<LiveReplayMerchandiseTopData> builder)
        {
            builder.ToTable("tbl_live_replay_merchandise_top_data");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.LiveReplayId).HasColumnName("live_replay_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.Sort).HasColumnName("sort").HasColumnType("int").IsRequired();
            builder.Property(e => e.ItemId).HasColumnName("item_id").HasColumnType("int").IsRequired();
            builder.Property(e => e.Gmv).HasColumnName("gmv").HasColumnType("DECIMAL(12,2)").IsRequired();
            builder.Property(e => e.MerchandiseShowNum).HasColumnName("merchandise_show_num").HasColumnType("int").IsRequired();
            builder.Property(e => e.MerchandiseVisitNum).HasColumnName("merchandise_visit_num").HasColumnType("int").IsRequired();
            builder.Property(e => e.MerchandiseShowVisitRate).HasColumnName("merchandise_show_visit_rate").HasColumnType("DECIMAL(12,2)").IsRequired();
            builder.Property(e => e.MerchandiseCreateOrderNum).HasColumnName("merchandise_create_order_num").HasColumnType("int").IsRequired();
            builder.Property(e => e.MerchandiseVisitCreateOrderRate).HasColumnName("merchandise_visit_create_order_rate").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(e => e.MerchandiseDealNum).HasColumnName("merchandise_deal_num").HasColumnType("int").IsRequired();
            builder.Property(e => e.MerchandiseCreateOrderDealRate).HasColumnName("merchandise_create_order_deal_rate").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(e => e.MerchandiseQuestion).HasColumnName("merchandise_question").HasColumnType("VARCHAR(500)").IsRequired(false);

            builder.HasOne(e => e.LiveReplay).WithMany(e => e.LiveReplayMerchandiseTopDataList).HasForeignKey(e => e.LiveReplayId);
            builder.HasOne(e => e.ItemInfo).WithMany(e => e.LiveReplayMerchandiseTopDataList).HasForeignKey(e => e.ItemId);
        }
    }
}
