using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class HospitalCustomerInfoConfiguration : IEntityTypeConfiguration<HospitalCustomerInfo>
    {
        public void Configure(EntityTypeBuilder<HospitalCustomerInfo> builder)
        {
            builder.ToTable("tbl_hospital_customer_info");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.CustomerPhone).HasColumnName("customer_phone").HasColumnType("varchar(20)").IsRequired();
            builder.Property(t => t.ConfirmOrderDate).HasColumnName("confirm_order_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.hospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.NewGoodsDemand).HasColumnName("new_gooods_demand").HasColumnType("varchar(300)").IsRequired(false);
            builder.Property(e => e.SendAmount).HasColumnName("send_amount").HasColumnType("int").IsRequired();
            builder.Property(e => e.DealAmount).HasColumnName("deal_amount").HasColumnType("int").IsRequired();
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
        }
    }
}
