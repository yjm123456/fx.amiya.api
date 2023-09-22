using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class CustomerConsumptionCredentialsConfiguration : IEntityTypeConfiguration<CustomerConsumptionCredentials>
    {
        public void Configure(EntityTypeBuilder<CustomerConsumptionCredentials> builder)
        {
            builder.ToTable("tbl_customer_consumption_credentials");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.CustomerId).HasColumnName("customer_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.CustomerName).HasColumnName("customer_name").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.ToHospitalPhone).HasColumnName("to_hospital_phone").HasColumnType("varchar(20)").IsRequired();
            builder.Property(e => e.ConsumeDate).HasColumnName("consume_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.BaseLiveAnchorId).HasColumnName("base_livenchor_id").HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(e => e.AssistantId).HasColumnName("assistant_id").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.PayVoucherPicture1).HasColumnName("pay_voucher_picture1").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.PayVoucherPicture2).HasColumnName("pay_voucher_picture2").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.PayVoucherPicture3).HasColumnName("pay_voucher_picture3").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.PayVoucherPicture4).HasColumnName("pay_voucher_picture4").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.PayVoucherPicture5).HasColumnName("pay_voucher_picture5").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(e => e.CheckState).HasColumnName("check_state").HasColumnType("int").IsRequired();
            builder.Property(e => e.CheckBy).HasColumnName("check_by").HasColumnType("int").IsRequired(false);
            builder.Property(e => e.CheckDate).HasColumnName("check_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.CheckRemark).HasColumnName("check_remark").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
            builder.HasOne(e => e.AmiyaEmployee).WithMany(e => e.CustomerConsumptionCredentialsList).HasForeignKey(e => e.CheckBy);
        }
    }
}
