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
    public class BillReturnBackPriceDataConfiguration : IEntityTypeConfiguration<BillReturnBackPriceData>
    {
        public void Configure(EntityTypeBuilder<BillReturnBackPriceData> builder)
        {
            builder.ToTable("tbl_bill_return_back_price_data");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.Property(e => e.CompanyId).HasColumnName("company_id").HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(e => e.BillId).HasColumnName("bill_id").HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(e => e.BillPrice).HasColumnName("bill_price").HasColumnType("DECIMAL(12,2)").IsRequired();
            builder.Property(e => e.OtherPrice).HasColumnName("other_price").HasColumnType("DECIMAL(12,2)").IsRequired(false);
            builder.Property(e => e.ReturnBackState).HasColumnName("return_back_state").HasColumnType("INT").IsRequired();
            builder.Property(e => e.ReturnBackPrice).HasColumnName("return_back_price").HasColumnType("DECIMAL(12,2)").IsRequired();
            builder.Property(e => e.ReturnBackDate).HasColumnName("return_back_date").HasColumnType("DATETIME").IsRequired();
            builder.Property(e => e.Remark).HasColumnName("remark").HasColumnType("VARCHAR(500)").IsRequired(false);

            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("DATETIME").IsRequired();
            builder.Property(e => e.CreateBy).HasColumnName("create_by").HasColumnType("INT").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("DATETIME").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("BIT(1)").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("DATETIME").IsRequired(false);

            builder.HasOne(t => t.AmiyaEmployee).WithMany(t => t.BillReturnBackPriceDataList).HasForeignKey(t => t.CreateBy);
            builder.HasOne(t => t.HospitalInfo).WithMany(t => t.BillReturnBackPriceDataList).HasForeignKey(t => t.HospitalId);
            builder.HasOne(t => t.CompanyBaseInfo).WithMany(t => t.BillReturnBackPriceDataList).HasForeignKey(t => t.CompanyId);
            builder.HasOne(t => t.BillInfo).WithMany(t => t.BillReturnBackPriceDataList).HasForeignKey(t => t.BillId);
        }
    }
}
