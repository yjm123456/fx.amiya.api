using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class HospitalBrandApplyConfiguration : IEntityTypeConfiguration<HospitalBrandApply>
    {
        public void Configure(EntityTypeBuilder<HospitalBrandApply> builder)
        {
            builder.ToTable("tbl_hospital_brand_apply");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.HospitalName).HasColumnName("hospital_name").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t => t.BusinessLicenseName).HasColumnName("business_license_name").HasColumnType("varchar(100)").IsRequired(false);
            builder.Property(t => t.HospitalLinkMan).HasColumnName("hospital_link_man").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.HospitalLinkManPhone).HasColumnName("hospital_link_man_phone").HasColumnType("varchar(45)").IsRequired();
            builder.Property(t => t.GoodsId).HasColumnName("goods_id").HasColumnType("varchar(12)").IsRequired(false);
            builder.Property(t => t.GoodsType).HasColumnName("goods_type").HasColumnType("varchar(45)").IsRequired(false);
            builder.Property(t => t.GoodsUrl).HasColumnName("goods_url").HasColumnType("varchar（300）").IsRequired(false);
            builder.Property(t => t.AllSaleNum).HasColumnName("all_sale_num").HasColumnType("int）").IsRequired(false);
            builder.Property(t => t.ExceededReason).HasColumnName("exceeded_reason").HasColumnType("varchar（600）").IsRequired(false);
        }
    }
}
