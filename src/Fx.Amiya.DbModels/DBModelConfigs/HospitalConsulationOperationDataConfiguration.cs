﻿using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class HospitalConsulationOperationDataConfiguration : IEntityTypeConfiguration<HospitalConsulationOperationData>
    {
        public void Configure(EntityTypeBuilder<HospitalConsulationOperationData> builder)
        {
            builder.ToTable("tbl_hospital_consulation_operation_data");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.IndicatorId).HasColumnName("indicator_id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t => t.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("BIT(1)").IsRequired();
            builder.Property(t => t.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.ConsulationName).HasColumnName("consulation_name").HasColumnType("varchar(100)").IsRequired(false);
            builder.Property(t => t.SendOrderNum).HasColumnName("send_order_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.NewCustomerVisitNum).HasColumnName("new_customer_visit_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.NewCustomerVisitRate).HasColumnName("new_customer_visit_rate").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.NewCustomerDealNum).HasColumnName("new_customer_deal_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.NewCustomerDealRate).HasColumnName("new_customer_deal_rate").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.NewCustomerDealPrice).HasColumnName("new_customer_deal_price").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.NewCustomerUnitPrice).HasColumnName("new_customer_unit_price").HasColumnType("decimal(12,2)").IsRequired();

            builder.Property(t => t.OldCustomerVisitNum).HasColumnName("old_customer_visit_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.OldCustomerDealNum).HasColumnName("old_customer_deal_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.OldCustomerDealRate).HasColumnName("old_customer_deal_rate").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.OldCustomerDealPrice).HasColumnName("old_customer_deal_price").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.OldCustomerUnitPrice).HasColumnName("old_customer_unit_price").HasColumnType("decimal(12,2)").IsRequired();

            builder.Property(t => t.OldCustomerAchievementRate).HasColumnName("old_customer_achievement_rate").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.LasttMonthTotalAchievement).HasColumnName("last_month_total_achievement").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t=>t.SectionOffice).HasColumnName("section_office").HasColumnType("varchar(200)").IsRequired();

            builder.HasOne(t => t.HospitalInfo).WithMany(t => t.HospitalConsulationOperationDataList).HasForeignKey(t => t.HospitalId);
            builder.HasOne(t => t.HospitalOperationalIndicator).WithMany(t => t.HospitalConsulationOperationDataList).HasForeignKey(t => t.IndicatorId);
        }
    }
}
