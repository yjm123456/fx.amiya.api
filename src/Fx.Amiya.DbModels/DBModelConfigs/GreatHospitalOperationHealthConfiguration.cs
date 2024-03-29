﻿using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class GreatHospitalOperationHealthConfiguration : IEntityTypeConfiguration<GreatHospitalOperationHealth>
    {
        public void Configure(EntityTypeBuilder<GreatHospitalOperationHealth> builder)
        {
            builder.ToTable("tbl_great_hospital_operation_health");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.IndicatorId).HasColumnName("indicator_id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t => t.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("BIT(1)").IsRequired();
            builder.Property(t => t.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);


            builder.Property(t => t.LastNewCustomerVisitRate).HasColumnName("last_new_customer_visit_rate").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.ThisNewCustomerVisitRate).HasColumnName("this_new_customer_visit_rate").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.NewCustomerVisitChainRatio).HasColumnName("new_customer_visit_chain_ratio").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.LastNewCustomerDealRate).HasColumnName("last_new_customer_deal_rate").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.ThisNewCustomerDealRate).HasColumnName("this_new_customer_deal_rate").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.NewCustomerDealChainRatio).HasColumnName("new_customer_deal_chain_ratio").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.LastNewCustomerUnitPrice).HasColumnName("last_new_customer_unit_price").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.ThisNewCustomerUnitPrice).HasColumnName("this_new_customer_unit_price").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.NewCustomerUnitPriceChainRatio).HasColumnName("new_customer_unit_price_chain_ratio").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.LastOldCustomerRepurchaseRate).HasColumnName("last_old_customer_repurchase_rate").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.ThisOldCustomerRepurchaseRate).HasColumnName("this_old_customer_repurchase_rate").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.OldCustomerRepurchaseChainRatio).HasColumnName("old_customer_repurchase_chain_ratio").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.LastOldCustomerUnitPrice).HasColumnName("last_old_customer_unit_price").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.ThisOldCustomerUnitPrice).HasColumnName("this_old_customer_unit_price").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.OldCustomerUnitPriceChainRatio).HasColumnName("old_customer_unit_price_chain_ratio").HasColumnType("decimal(12,2)").IsRequired();

            builder.HasOne(t => t.HospitalInfo).WithMany(t => t.GreatHospitalOperationHealthList).HasForeignKey(t => t.HospitalId);
            builder.HasOne(t => t.HospitalOperationalIndicator).WithMany(t => t.GreatHospitalOperationHealthList).HasForeignKey(t => t.IndicatorId);
        }
    }
}
