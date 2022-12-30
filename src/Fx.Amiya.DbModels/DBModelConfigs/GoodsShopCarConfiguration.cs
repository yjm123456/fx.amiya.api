using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class GoodsShopCarConfiguration : IEntityTypeConfiguration<GoodsShopCar>
    {
        public void Configure(EntityTypeBuilder<GoodsShopCar> builder)
        {
            builder.ToTable("tbl_goods_shopcar");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(t => t.GoodsId).HasColumnName("goods_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.CustomerId).HasColumnName("customer_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.Num).HasColumnName("num").HasColumnType("int").IsRequired();
            builder.Property(t => t.Status).HasColumnName("status").HasColumnType("int").IsRequired();
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.CityId).HasColumnName("city_id").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.HospitalId).HasColumnName("hosiptal_id").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.SelectStandards).HasColumnName("select_standards").HasColumnType("varchar(50)").IsRequired(false);

            builder.HasOne(e => e.GoodsInfo).WithMany(e => e.GoodsShopCars).HasForeignKey(e => e.GoodsId);
            builder.HasOne(e => e.CustomerInfo).WithMany(e => e.GoodsShopCar).HasForeignKey(e => e.CustomerId);
            builder.HasOne(e => e.City).WithMany(e => e.GoodsShopCar).HasForeignKey(e => e.CityId);
            builder.HasOne(e => e.HospitalInfo).WithMany(e => e.GoodsShopCar).HasForeignKey(e => e.HospitalId);
        }
    }
}
