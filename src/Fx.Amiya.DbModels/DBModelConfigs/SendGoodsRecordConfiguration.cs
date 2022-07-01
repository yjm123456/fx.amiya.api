using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class SendGoodsRecordConfiguration : IEntityTypeConfiguration<SendGoodsRecord>
    {
        public void Configure(EntityTypeBuilder<SendGoodsRecord> builder)
        {
            builder.ToTable("tbl_send_goods_record");
            builder.HasKey(t => t.Id);
            builder.Property(t=>t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t=>t.TradeId).HasColumnName("trade_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t=>t.Date).HasColumnName("date").HasColumnType("datetime").IsRequired();
            builder.Property(t=>t.HandleBy).HasColumnName("handle_by").HasColumnType("int").IsRequired();
            builder.Property(t=>t.CourierNumber).HasColumnName("courier_number").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t => t.ExpressId).HasColumnName("express_id").HasColumnType("varchar(50)").IsRequired(false);

            builder.HasOne(t => t.OrderTrade).WithOne(t => t.SendGoodsRecord).HasForeignKey<SendGoodsRecord>(t=>t.TradeId);
            builder.HasOne(t => t.AmiyaEmployee).WithMany(t => t.SendGoodsRecordList).HasForeignKey(t=>t.HandleBy);
        }
    }
}
