using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class ReconciliationDocumentsConfiguration : IEntityTypeConfiguration<ReconciliationDocuments>
    {
        public void Configure(EntityTypeBuilder<ReconciliationDocuments> builder)
        {
            builder.ToTable("tbl_reconciliation_documents");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.Property(e => e.CustomerName).HasColumnName("customer_name").HasColumnType("varchar(100)").IsRequired(false);
            builder.Property(e => e.CustomerPhone).HasColumnName("customer_phone").HasColumnType("varchar(45)").IsRequired(false);
            builder.Property(e => e.DealDate).HasColumnName("deal_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.DealGoods).HasColumnName("deal_goods").HasColumnType("varchar(300)").IsRequired(false);
            builder.Property(e => e.TotalDealPrice).HasColumnName("total_deal_price").HasColumnType("decimal(12,2)").IsRequired(false);
            builder.Property(e => e.ReturnBackPricePercent).HasColumnName("return_back_price_percent").HasColumnType("decimal(4,2)").IsRequired(false);
            builder.Property(e => e.SystemUpdatePricePercent).HasColumnName("system_update_price_percent").HasColumnType("decimal(4,2)").IsRequired(false);

            builder.Property(e => e.QuestionReason).HasColumnName("question_reason").HasColumnType("varchar(1000)").IsRequired(false);
            builder.Property(e => e.Remark).HasColumnName("remark").HasColumnType("varchar(1000)").IsRequired(false);
            builder.Property(e => e.ReconciliationState).HasColumnName("reconciliation_state").HasColumnType("int").IsRequired();
            builder.Property(e => e.CreateBy).HasColumnName("create_by").HasColumnType("int").IsRequired();
            builder.HasOne(e => e.HospitalInfo).WithMany(e => e.ReconciliationDocumentsList).HasForeignKey(e => e.HospitalId);
            builder.HasOne(e => e.HospitalEmployee).WithMany(e => e.ReconciliationDocumentsList).HasForeignKey(e => e.CreateBy);
        }
    }
}
