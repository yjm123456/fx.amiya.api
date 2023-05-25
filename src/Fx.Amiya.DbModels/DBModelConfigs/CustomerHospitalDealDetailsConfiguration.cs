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
    public class CustomerHospitalDealDetailsConfiguration : IEntityTypeConfiguration<CustomerHospitalDealDetails>
    {
        public void Configure(EntityTypeBuilder<CustomerHospitalDealDetails> builder)
        {
            builder.ToTable("tbl_customer_hospital_deal_details");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.CustomerHospitalDealId).HasColumnName("customer_hospital_deal_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.ItemName).HasColumnName("item_name").HasColumnType("varchar(300)").IsRequired(false);
            builder.Property(e => e.ItemStandard).HasColumnName("item_standard").HasColumnType("varchar(400)").IsRequired(false);
            builder.Property(e => e.Quantity).HasColumnName("quantity").HasColumnType("decimal(12,2)").IsRequired(false);
            builder.Property(e => e.CashAmount).HasColumnName("cash_amount").HasColumnType("decimal(12,2)").IsRequired(false);
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.HasOne(t => t.CustomerHospitalDealInfo).WithMany(t => t.CustomerHospitalDealDetailsList).HasForeignKey(t => t.CustomerHospitalDealId);
        }
    }
}
