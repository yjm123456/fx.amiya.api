using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class UnCheckOrderConfiguration : IEntityTypeConfiguration<UnCheckOrder>
    {
        public void Configure(EntityTypeBuilder<UnCheckOrder> builder)
        {
            builder.ToTable("tbl_uncheck_order");
            builder.Property(t => t.OrderId).HasColumnName("order_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.OrderFrom).HasColumnName("order_from").HasColumnType("INT").IsRequired();
            builder.Property(t => t.Phone).HasColumnName("phone").HasColumnType("varchar(11)").IsRequired();
            builder.Property(t => t.DealDate).HasColumnName("deal_date").HasColumnType("DATETIME").IsRequired();
            builder.Property(t => t.DealPrice).HasColumnName("deal_price").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.InformationPricePercent).HasColumnName("information_price_percent").HasColumnType("decimal(4,2)").IsRequired();
            builder.Property(t => t.SystemUpdatePercent).HasColumnName("system_update_percent").HasColumnType("decimal(4,2)").IsRequired();
            builder.Property(t => t.InformationPrice).HasColumnName("information_price").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.SystemUpdatePrice).HasColumnName("system_update_price").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.ReturnBackPrice).HasColumnName("return_back_price").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.IsSubmitReconciliationDocuments).HasColumnName("is_submit_reconciliation_documents").HasColumnType("bit").IsRequired();
            builder.Property(t => t.SendHospital).HasColumnName("send_hospital").HasColumnType("INT").IsRequired(false);
            builder.Property(t => t.CreateBy).HasColumnName("create_by").HasColumnType("INT").IsRequired();

            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("DATETIME").IsRequired();
            builder.Property(t => t.UpdateDate).HasColumnName("update_date").HasColumnType("DATETIME").IsRequired(false);
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(t => t.DeleteDate).HasColumnName("delete_date").HasColumnType("DATETIME").IsRequired(false);

            builder.HasOne(t => t.UnCheckOrderCreateBy).WithMany(t => t.UnCheckOrderList).HasForeignKey(t => t.CreateBy);
        }
    }
}
