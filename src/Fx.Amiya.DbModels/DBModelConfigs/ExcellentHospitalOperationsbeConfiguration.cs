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
    public class ExcellentHospitalOperationsbeConfiguration : IEntityTypeConfiguration<ExcellentHospitalOperationsbe>
    {
        public void Configure(EntityTypeBuilder<ExcellentHospitalOperationsbe> builder)
        {
            builder.ToTable("tbl_excellent_hospital_operationsbe");
            builder.HasKey(e=>e.Id);
            builder.Property(e=>e.Id).HasColumnName("id").HasColumnType("varchar(100)");
            builder.Property(e => e.HospitalName).HasColumnName("hospital_name").HasColumnType("varchar(100)");
            builder.Property(e => e.LastMonthNewCustomerToHospitalRate).HasColumnName("lastmonth_newcustomer_tohospitalrate").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(e => e.CurrentMonthNewCustomerToHospitalRate).HasColumnName("currentmonth_newcustomer_tohospitalrate").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(e => e.NewCustomerToHospitalChainRatio).HasColumnName("newcustomer_tohospital_chainratio").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(e => e.LastMonthNewCustomerDealRate).HasColumnName("lastmonth_newcustomer_dealrate").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(e => e.CurrentMonthNewCustomerDealRate).HasColumnName("currentmonth_newcustomer_dealrate").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(e => e.NewCustomerDealChainRation).HasColumnName("newcustomer_deal_chainration").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(e => e.LastMonthNewCustomerOrderPrice).HasColumnName("lastmonth_newcustomer_orderprice").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(e => e.CurrentMonthNewCustomerOrderPrice).HasColumnName("currentmonth_newcustomer_orderprice").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(e => e.NewCustomerOrderPriceChainRation).HasColumnName("newcustomer_orderprice_chainration").HasColumnType("decimal(10,2)").IsRequired();
        }
    }
}
