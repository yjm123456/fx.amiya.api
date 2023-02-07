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
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("tbl_bill");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.Property(e => e.BillPrice).HasColumnName("bill_price").HasColumnType("DECIMAL(12,2)").IsRequired();
            builder.Property(e => e.TaxRate).HasColumnName("tax_rate").HasColumnType("DECIMAL(3,2)").IsRequired();
            builder.Property(e => e.TaxPrice).HasColumnName("tax_price").HasColumnType("DECIMAL(12,2)").IsRequired();
            builder.Property(e => e.NotInTaxPrice).HasColumnName("not_in_tax_price").HasColumnType("DECIMAL(12,2)").IsRequired();
            builder.Property(e => e.OtherPrice).HasColumnName("other_price").HasColumnType("DECIMAL(12,2)").IsRequired(false);
            builder.Property(e => e.OtherPriceRemark).HasColumnName("other_price_remark").HasColumnType("VARCHAR(300)").IsRequired(false);
            builder.Property(e => e.CollectionCompanyId).HasColumnName("collecting_company_id").HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(e => e.BelongStartTime).HasColumnName("belong_start_time").HasColumnType("DATETIME").IsRequired();
            builder.Property(e => e.BelongEndTime).HasColumnName("belong_end_time").HasColumnType("DATETIME").IsRequired();
            builder.Property(e => e.BillType).HasColumnName("bill_type").HasColumnType("INT").IsRequired();
            builder.Property(e => e.CreateBillReason).HasColumnName("create_bill_reason").HasColumnType("VARCHAR(300)").IsRequired(false);
            builder.Property(e => e.ReturnBackState).HasColumnName("return_back_state").HasColumnType("INT").IsRequired();
            builder.Property(e => e.ReturnBackPrice).HasColumnName("return_back_price").HasColumnType("DECIMAL(12,2)").IsRequired(false);
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("DATETIME").IsRequired();
            builder.Property(e => e.CreateBy).HasColumnName("create_by").HasColumnType("INT").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("DATETIME").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("BIT(1)").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("DATETIME").IsRequired(false);

            builder.HasOne(t => t.AmiyaEmployee).WithMany(t => t.BillList).HasForeignKey(t => t.CreateBy);
            builder.HasOne(t => t.HospitalInfo).WithMany(t => t.BillList).HasForeignKey(t => t.HospitalId);
            builder.HasOne(t => t.CompanyBaseInfo).WithMany(t => t.BillList).HasForeignKey(t => t.CollectionCompanyId);
        }
    }
}
