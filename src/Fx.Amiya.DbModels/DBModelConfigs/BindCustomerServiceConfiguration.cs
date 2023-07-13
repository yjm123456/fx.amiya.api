using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class BindCustomerServiceConfiguration : IEntityTypeConfiguration<BindCustomerService>
    {
        public void Configure(EntityTypeBuilder<BindCustomerService> builder)
        {
            builder.ToTable("tbl_bind_customer_service");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t => t.CustomerServiceId).HasColumnName("customer_service_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.BuyerPhone).HasColumnName("tmall_buyer_phone").HasColumnType("varchar(20)").IsRequired();
            builder.Property(t => t.UserId).HasColumnName("user_id").HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.CreateBy).HasColumnName("create_by").HasColumnType("int").IsRequired();
            builder.Property(t => t.FirstProjectDemand).HasColumnName("first_project_demand").HasColumnType("varchar(200)").IsRequired(false);
            builder.Property(t => t.FirstConsumptionDate).HasColumnName("first_consumption_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.NewConsumptionDate).HasColumnName("new_consumption_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.NewConsumptionContentPlatform).HasColumnName("new_consumption_content_platform").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.NewContentPlatForm).HasColumnName("new_content_platform").HasColumnType("varchar(45)").IsRequired(false);
            builder.Property(t => t.AllPrice).HasColumnName("all_price").HasColumnType("decimal(12,2)").IsRequired(false);
            builder.Property(t => t.AllOrderCount).HasColumnName("all_order_count").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.NewLiveAnchor).HasColumnName("new_live_anchor").HasColumnType("varchar(200)").IsRequired(false);
            builder.Property(t => t.NewWechatNo).HasColumnName("new_wechat_no").HasColumnType("varchar(200)").IsRequired(false);
            builder.Property(t => t.RfmType).HasColumnName("rfm_type").HasColumnType("int").IsRequired();

            builder.HasOne(t => t.CustomerServiceAmiyaEmployee).WithMany(t => t.CustoemrServiceBindCustomerServiceList).HasForeignKey(t => t.CustomerServiceId);
            builder.HasOne(t => t.CreateByAmiyaEmployee).WithMany(t => t.CreateByBindCustomerServiceList).HasForeignKey(t => t.CreateBy);
        }
    }
}
