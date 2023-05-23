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
    public class CustomerHospitalDealInfoConfiguration : IEntityTypeConfiguration<CustomerHospitalDealInfo>
    {
        public void Configure(EntityTypeBuilder<CustomerHospitalDealInfo> builder)
        {
            builder.ToTable("tbl_customer_hospital_deal_info");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.Property(e => e.Type).HasColumnName("type").HasColumnType("int").IsRequired();
            builder.Property(e => e.CustomerName).HasColumnName("customer_name").HasColumnType("varchar(45)").IsRequired();
            builder.Property(e => e.CustomerPhone).HasColumnName("customer_phone").HasColumnType("varchar(30)").IsRequired();
            builder.Property(e => e.Date).HasColumnName("date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.TotalCashAmount).HasColumnName("total_amount").HasColumnType("DECIMAL(12,2)").IsRequired();
            builder.Property(e => e.ConsumptionType).HasColumnName("consumption_type").HasColumnType("int").IsRequired(false);
            builder.Property(e => e.RefundType).HasColumnName("refund_type").HasColumnType("int").IsRequired(false);
            builder.Property(e => e.MsgId).HasColumnName("msg_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.HasOne(t => t.HospitalInfoData).WithMany(t => t.CustomerHospitalDealInfoList).HasForeignKey(t => t.HospitalId);
        }
    }
}
