using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class DockingHospitalCustomerInfoConfiguration : IEntityTypeConfiguration<DockingHospitalCustomerInfo>
    {
        public void Configure(EntityTypeBuilder<DockingHospitalCustomerInfo> builder)
        {
         
            builder.ToTable("tbl_docking_hospital_customer_info");
            builder.HasKey(t => t.Id);
            builder.Property(t=>t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t=>t.AppKey).HasColumnName("app_key").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t=>t.AppSecret).HasColumnName("app_secret").HasColumnType("varchar(5000)").IsRequired();
            builder.Property(t=>t.AccessToken).HasColumnName("token").HasColumnType("varchar(5000)").IsRequired(false);
            builder.Property(t=>t.AuthorizeDate).HasColumnName("authorize_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.ExpireDate).HasColumnName("expire_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.RefreshToken).HasColumnName("refresh_token").HasColumnType("varchar(3000)").IsRequired(false);
            builder.Property(t => t.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.BaseUrl).HasColumnName("base_url").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.TokenUrl).HasColumnName("token_url").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.GetCustomerUrl).HasColumnName("get_customer_url").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.GetCustomerOrderUrl).HasColumnName("get_customer_order_url").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.GetOrderUrl).HasColumnName("get_order_url").HasColumnType("varchar(500)").IsRequired(false);

            builder.HasOne(t => t.HospitalInfo).WithMany(t => t.HospitalDockingHospitalCustomerInfo).HasForeignKey(t => t.HospitalId);
        }
    }
}
