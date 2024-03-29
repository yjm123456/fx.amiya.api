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
    public class GoodsStandardsPriceConfiguration : IEntityTypeConfiguration<GoodsStandardsPrice>
    {
        public void Configure(EntityTypeBuilder<GoodsStandardsPrice> builder)
        {
        //    builder.ToTable("tbl_goods_standards_price");
        //    //builder.HasKey(t => t.GoodsId);
        //    builder.Property(t => t.GoodsId).HasColumnName("goods_id").HasColumnType("VARCHAR(50)").IsRequired();
        //    builder.Property(t => t.Standards).HasColumnName("standards").HasColumnType("varchar(500)").IsRequired();
        //    builder.Property(t => t.Price).HasColumnName("price").HasColumnType("decimal(10,2)").IsRequired();


            builder.ToTable("tbl_goods_standards_price");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.StandardsImg).HasColumnName("standards_img").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.GoodsId).HasColumnName("goods_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.Standards).HasColumnName("standards").HasColumnType("varchar(500)").IsRequired();
            builder.Property(t => t.Price).HasColumnName("price").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(t => t.IntegralAmount).HasColumnName("integral_amount").HasColumnType("decimal(10,2)").IsRequired(false);
        }
    }
}

