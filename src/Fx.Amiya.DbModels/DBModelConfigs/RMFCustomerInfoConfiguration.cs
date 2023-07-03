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
    public class RMFCustomerInfoConfiguration:IEntityTypeConfiguration<RMFCustomerInfo>
    {
        public void Configure(EntityTypeBuilder<RMFCustomerInfo> builder)
        {
            builder.ToTable("tbl_rmf_customerinfo");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.CustomerServiceId).HasColumnName("customer_service_id").HasColumnType("int").IsRequired(false);
            builder.Property(e => e.Phone).HasColumnName("phone").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.LastDealDate).HasColumnName("last_deal_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired(false);
            builder.Property(e => e.DealPrice).HasColumnName("deal_price").HasColumnType("deciaml(10,2)").IsRequired();
            builder.Property(e => e.TotalDealPrice).HasColumnName("total_deal_price").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(e => e.ConsumptionFrequency).HasColumnName("consumption_frequency").HasColumnType("int").IsRequired();
            builder.Property(e => e.RecencyDate).HasColumnName("recency_date").HasColumnType("int").IsRequired();
            builder.Property(e => e.Recency).HasColumnName("recency").HasColumnType("int").IsRequired();
            builder.Property(e => e.Frequency).HasColumnName("frequency").HasColumnType("int").IsRequired();
            builder.Property(e => e.Monetary).HasColumnName("monetary").HasColumnType("int").IsRequired();
            builder.Property(e => e.RFMTag).HasColumnName("rfm_tag").HasColumnType("int").IsRequired();
            builder.Property(e => e.LiveAnchorWechatNo).HasColumnName("live_anchor_wechatno").HasColumnType("varchar(100)").IsRequired(false);
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
        }
    }
}
