using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class HospitalOperationDataConfiguration : IEntityTypeConfiguration<HospitalOperationData>
    {
        public void Configure(EntityTypeBuilder<HospitalOperationData> builder)
        {
            builder.ToTable("tbl_hospital_operation_data");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.IndicatorsId).HasColumnName("indicator_id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t => t.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("BIT(1)").IsRequired();
            builder.Property(t => t.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);

            builder.Property(t => t.OperationName).HasColumnName("operation_name").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t => t.LastMonthData).HasColumnName("last_month_data").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.BeforeMonthData).HasColumnName("before_month_data").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.ChainRatio).HasColumnName("chain_ratio").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.GreatHospital).HasColumnName("great_hospital").HasColumnType("varchar(100)").IsRequired(false);


            builder.HasOne(t => t.HospitalInfo).WithMany(t => t.HospitalOperationDataList).HasForeignKey(t => t.HospitalId);
            builder.HasOne(t => t.HospitalOperationalIndicator).WithMany(t => t.HospitalOperationDataList).HasForeignKey(t => t.IndicatorsId);
        }
    }
}
