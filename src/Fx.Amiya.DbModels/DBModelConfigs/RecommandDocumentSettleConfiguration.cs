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
            builder.Property(e => e.OrderPrice).HasColumnName("order_price").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(e => e.RecolicationPrice).HasColumnName("recolication_price").HasColumnType("decimal(12,2)").IsRequired(false);
            builder.Property(e => e.IsOldCustomer).HasColumnName("is_oldcustomer").HasColumnType("bit").IsRequired();
            builder.Property(e => e.CustomerServiceSettlePrice).HasColumnName("customer_service_settle_price").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(e => e.ReturnBackPrice).HasColumnName("return_back_price").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.SettleDate).HasColumnName("settle_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.IsSettle).HasColumnName("is_settle").HasColumnType("bit").IsRequired();

            builder.Property(e => e.BelongLiveAnchorAccount).HasColumnName("belong_live_anchor_account").HasColumnType("int").IsRequired(false);
            builder.Property(e => e.BelongEmpId).HasColumnName("belong_emp_id").HasColumnType("int").IsRequired(false);
            builder.Property(e => e.CreateEmpId).HasColumnName("create_emp_id").HasColumnType("int").IsRequired(false);
            builder.Property(e => e.CreateBy).HasColumnName("create_by").HasColumnType("int").IsRequired();
            builder.Property(e => e.AccountType).HasColumnName("account_type").HasColumnType("bit").IsRequired();
            builder.Property(e => e.AccountPrice).HasColumnName("account_price").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(e => e.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.HasOne(e => e.AmiyaEmployee).WithMany(e => e.RecommandDocumentSettleList).HasForeignKey(e => e.CreateBy);
            builder.Property(e => e.CompensationCheckState).HasColumnName("compensation_check_state").HasColumnType("int").IsRequired();
            builder.Property(e => e.CheckBy).HasColumnName("check_by").HasColumnType("int").IsRequired(false);
            builder.Property(e => e.CheckDate).HasColumnName("check_date").HasColumnType("DATETIME").IsRequired(false);
            builder.Property(e => e.CheckRemark).HasColumnName("check_remark").HasColumnType("varchar(1000)").IsRequired(false);
            builder.Property(e => e.CheckBelongEmpId).HasColumnName("check_belong_empid").HasColumnType("int").IsRequired(false);
            builder.Property(e => e.CustomerServiceCompensationId).HasColumnName("customer_service_compensation_id").HasColumnType("varchar(50)").IsRequired(false);
            //builder.HasOne(e => e.ReconciliationDocuments).WithMany(e => e.RecommandDocumentSettleList).HasForeignKey(e => e.RecommandDocumentId);
        }
    }
}
