using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class HospitalDealItemConfiguration : IEntityTypeConfiguration<HospitalDealItem>
    {
        public void Configure(EntityTypeBuilder<HospitalDealItem> builder)
        {
            builder.ToTable("tbl_hospital_deal_item");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.IndicatorId).HasColumnName("indicator_id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t => t.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("BIT(1)").IsRequired();
            builder.Property(t => t.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);

            builder.Property(t => t.ItemName).HasColumnName("item_name").HasColumnType("varchar(100)").IsRequired(false);
            builder.Property(t => t.DealCount).HasColumnName("deal_count").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.DealPrice).HasColumnName("deal_price").HasColumnType("decimal(10,2)").IsRequired(false);
            builder.Property(t => t.PerformanceRatio).HasColumnName("performance_ratio").HasColumnType("decimal(10,2)").IsRequired(false);
            builder.Property(t => t.DealUnitPrice).HasColumnName("deal_unit_price").HasColumnType("decimal(10,2)").IsRequired(false);

            builder.HasOne(t => t.HospitalInfo).WithMany(t => t.HospitalDealItemList).HasForeignKey(e=>e.HospitalId);
            builder.HasOne(t => t.HospitalOperationalIndicator).WithMany(t => t.HospitalDealItemList).HasForeignKey(e => e.IndicatorId);
        }
    }
}
