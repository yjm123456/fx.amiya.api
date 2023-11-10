using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class SendOrderInfoConfiguration : IEntityTypeConfiguration<SendOrderInfo>
    {
        public void Configure(EntityTypeBuilder<SendOrderInfo> builder)
        {
            builder.ToTable("tbl_send_order_info");
            builder.HasKey(t => t.Id);
            builder.Property(t=>t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t=>t.OrderId).HasColumnName("order_id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t=>t.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.Property(t=>t.SendBy).HasColumnName("send_by").HasColumnType("int").IsRequired();
            builder.Property(t=>t.SendDate).HasColumnName("send_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.PurchaseNum).HasColumnName("purchase_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.PurchaseSinglePrice).HasColumnName("purchase_single_price").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(t=>t.AppointmentDate).HasColumnName("appointment_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t=>t.TimeType).HasColumnName("time_type").HasColumnType("tinyint").IsRequired(false);
            builder.Property(t => t.IsUncertainDate).HasColumnName("is_uncertain_date").HasColumnType("bit").IsRequired();
            builder.Property(t => t.IsMainHospital).HasColumnName("is_main_hospital").HasColumnType("bit").IsRequired();

            builder.HasOne(t => t.OrderInfo).WithMany(t => t.SendOrderInfoList).HasForeignKey(t => t.OrderId);
            builder.HasOne(t => t.HospitalInfo).WithMany(t => t.SendOrderInfoList).HasForeignKey(t => t.HospitalId);
            builder.HasOne(t => t.AmiyaEmployee).WithMany(t => t.SendOrderInfoList).HasForeignKey(t=>t.SendBy);
        }
    }
}
