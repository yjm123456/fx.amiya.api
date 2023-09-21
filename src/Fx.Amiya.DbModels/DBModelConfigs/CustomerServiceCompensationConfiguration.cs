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
    public class CustomerServiceCompensationConfiguration : IEntityTypeConfiguration<CustomerServiceCompensation>
    {
        public void Configure(EntityTypeBuilder<CustomerServiceCompensation> builder)
        {
            builder.ToTable("tbl_customer_service_compensation");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.OtherPrice).HasColumnName("other_price").HasColumnType("DECIMAL(12,2)").IsRequired();
            builder.Property(e => e.Name).HasColumnName("name").HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(e => e.BelongEmpId).HasColumnName("belong_emp_id").HasColumnType("INT").IsRequired();
            builder.Property(e => e.TotalPrice).HasColumnName("total_price").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(e => e.OtherPrice).HasColumnName("other_price").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(e => e.Remark).HasColumnName("remark").HasColumnType("VARCHAR(1000)").IsRequired(false);
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("DATETIME").IsRequired();
            builder.Property(e => e.CreateBy).HasColumnName("create_by").HasColumnType("INT").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("DATETIME").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("BIT(1)").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("DATETIME").IsRequired(false);

            builder.HasOne(t => t.CreateByEmployee).WithMany(t => t.CustomerServiceCompensationCreateByList).HasForeignKey(t => t.CreateBy);
            builder.HasOne(t => t.BelongEmployee).WithMany(t => t.CustomerServiceCompensationBelongEmpList).HasForeignKey(t => t.BelongEmpId);
        }
    }
}
