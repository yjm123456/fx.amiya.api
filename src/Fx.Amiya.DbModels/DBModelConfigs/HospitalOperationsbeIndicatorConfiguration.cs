﻿using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class HospitalOperationsbeIndicatorConfiguration : IEntityTypeConfiguration<HospitalOperationsbeIndicator>
    {
        public void Configure(EntityTypeBuilder<HospitalOperationsbeIndicator> builder)
        {
            builder.ToTable("tbl_hospital_operationsbe_indicator");
            builder.HasKey(e=>e.Id);
            builder.Property(e=>e.Id).HasColumnName("id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.Name).HasColumnName("name").HasColumnType("varchar(500)").IsRequired();
            builder.Property(e => e.Describe).HasColumnName("describe").HasColumnType("varchar(500)").IsRequired();
            builder.Property(e => e.StartDate).HasColumnName("start_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.EndDate).HasColumnName("end_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.ExcellentHospital).HasColumnName("excellent_hospital").HasColumnType("varchar(500)").IsRequired();
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateTime).HasColumnName("update_time").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);           
        }
    }
}
