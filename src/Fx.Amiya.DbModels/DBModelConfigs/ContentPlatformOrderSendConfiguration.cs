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
    public class ContentPlatformOrderSendConfiguration : IEntityTypeConfiguration<ContentPlatformOrderSend>
    {
        public void Configure(EntityTypeBuilder<ContentPlatformOrderSend> builder)
        {
            builder.ToTable("tbl_content_platform_order_send");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(e => e.ContentPlatformOrderId).HasColumnName("content_platform_order_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.Property(e => e.Sender).HasColumnName("sender").HasColumnType("int").IsRequired();
            builder.Property(e => e.SendDate).HasColumnName("send_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.IsUncertainDate).HasColumnName("is_uncertain_date").HasColumnType("bit").IsRequired();
            builder.Property(e => e.AppointmentDate).HasColumnName("appointment_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Remark).HasColumnName("remark").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(e => e.HospitalRemark).HasColumnName("hospital_remark").HasColumnType("varchar(100000)").IsRequired(false);

            builder.HasOne(e => e.ContentPlatformOrder).WithMany(e => e.ContentPlatformOrderSendList).HasForeignKey(e => e.ContentPlatformOrderId);
            builder.HasOne(e => e.AmiyaEmployee).WithMany(e => e.ContentPlatformOrderSendList).HasForeignKey(e => e.Sender);

            builder.HasOne(t => t.HospitalInfo).WithMany(t => t.ContentPlatformOrderSendList).HasForeignKey(t => t.HospitalId);
        }
    }
}
