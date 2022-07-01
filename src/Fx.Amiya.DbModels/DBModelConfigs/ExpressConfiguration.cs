using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class ExpressConfiguration : IEntityTypeConfiguration<AmiyaExpress>
    {
        public void Configure(EntityTypeBuilder<AmiyaExpress> builder)
        {
            builder.ToTable("tbl_amiya_express");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.ExpressName).HasColumnName("express_name").HasColumnType("varchar(45)").IsRequired();
            builder.Property(t => t.ExpressCode).HasColumnName("express_code").HasColumnType("varchar(100)").IsRequired(false);
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
        }
    }
}
