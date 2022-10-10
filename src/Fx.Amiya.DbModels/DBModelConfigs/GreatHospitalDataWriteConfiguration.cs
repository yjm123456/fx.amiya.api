using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class GreatHospitalDataWriteConfiguration : IEntityTypeConfiguration<GreatHospitalDataWrite>
    {
        public void Configure(EntityTypeBuilder<GreatHospitalDataWrite> builder)
        {
            builder.ToTable("tbl_great_hospital_data_write");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.IndicatorId).HasColumnName("indicator_id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("BIT(1)").IsRequired();
            builder.Property(t => t.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);


            builder.Property(t => t.OperationName).HasColumnName("operation_name").HasColumnType("varchar(100)").IsRequired(false);
            builder.Property(t => t.OperationValue).HasColumnName("operation_value").HasColumnType("varchar(200)").IsRequired(false);


            builder.HasOne(t => t.HospitalOperationalIndicator).WithMany(t => t.GreatHospitalDataWriteList).HasForeignKey(t => t.IndicatorId);
        }
    }
}
