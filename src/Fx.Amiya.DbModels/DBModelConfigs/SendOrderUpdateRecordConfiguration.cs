using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class SendOrderUpdateRecordConfiguration : IEntityTypeConfiguration<SendOrderUpdateRecord>
    {
        public void Configure(EntityTypeBuilder<SendOrderUpdateRecord> builder)
        {
            builder.ToTable("tbl_send_order_update_record");
            builder.HasKey(t => t.Id);
            builder.Property(t=>t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t=>t.OrderId).HasColumnName("order_id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t=>t.OldHospitalId).HasColumnName("old_hospital_id").HasColumnType("int").IsRequired();
            builder.Property(t=>t.NewHospitalId).HasColumnName("new_hospital_id").HasColumnType("int").IsRequired();
            builder.Property(t=>t.UpdateBy).HasColumnName("update_by").HasColumnType("int").IsRequired();
            builder.Property(t=>t.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired();

            builder.HasOne(t => t.OldHospitalInfo).WithMany(t => t.OldSendOrderUpdateRecordList).HasForeignKey(t=>t.OldHospitalId);
            builder.HasOne(t => t.NewHospitalInfo).WithMany(t => t.NewSendOrderUpdateRecordList).HasForeignKey(t=>t.NewHospitalId);
            builder.HasOne(t => t.AmiyaEmployee).WithMany(t => t.SendOrderUpdateRecordList).HasForeignKey(t=>t.UpdateBy);
        }
    }
}
