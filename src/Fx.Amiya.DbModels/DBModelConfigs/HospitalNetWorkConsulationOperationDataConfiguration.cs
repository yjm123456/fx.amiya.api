using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class HospitalNetWorkConsulationOperationDataConfiguration : IEntityTypeConfiguration<HospitalNetWorkConsulationOperationData>
    {
        public void Configure(EntityTypeBuilder<HospitalNetWorkConsulationOperationData> builder)
        {
            builder.ToTable("tbl_great_hospital_operation_health");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.IndicatorId).HasColumnName("indicator_id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t => t.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("BIT(1)").IsRequired();
            builder.Property(t => t.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.ConsulationName).HasColumnName("consulation_name").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t => t.SendOrderNum).HasColumnName("send_order_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.NewCustomerVisitNum).HasColumnName("new_customer_visit_num").HasColumnType("int").IsRequired();
            builder.Property(t => t.NewCustomerVisitRate).HasColumnName("new_customer_visit_rate").HasColumnType("decimal(12,2)").IsRequired();


            builder.HasOne(t => t.HospitalInfo).WithMany(t => t.HospitalNetWorkConsulationOperationDataList).HasForeignKey(t => t.HospitalId);
            builder.HasOne(t => t.HospitalOperationalIndicator).WithMany(t => t.HospitalNetWorkConsulationOperationDataList).HasForeignKey(t => t.IndicatorId);
        }
    }
}
