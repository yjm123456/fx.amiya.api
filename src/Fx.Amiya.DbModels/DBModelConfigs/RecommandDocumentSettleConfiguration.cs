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
    public class RecommandDocumentSettleConfiguration : IEntityTypeConfiguration<RecommandDocumentSettle>
    {
        public void Configure(EntityTypeBuilder<RecommandDocumentSettle> builder)
        {
            builder.ToTable("tbl_recommand_document_settle");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.RecommandDocumentId).HasColumnName("recommand_document_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.OrderId).HasColumnName("order_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.DealInfoId).HasColumnName("deal_info_id").HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(e => e.OrderFrom).HasColumnName("order_from").HasColumnType("int").IsRequired();
            builder.Property(e => e.ReturnBackPrice).HasColumnName("return_back_price").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.SettleDate).HasColumnName("settle_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.IsSettle).HasColumnName("is_settle").HasColumnType("bit").IsRequired();
        }
    }
}
