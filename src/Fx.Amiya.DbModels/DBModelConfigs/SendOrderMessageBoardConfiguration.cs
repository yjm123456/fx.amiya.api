using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class SendOrderMessageBoardConfiguration : IEntityTypeConfiguration<SendOrderMessageBoard>
    {
        public void Configure(EntityTypeBuilder<SendOrderMessageBoard> builder)
        {
            builder.ToTable("tbl_send_order_message_board");
            builder.HasKey(t => t.Id);
            builder.Property(t=>t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t=>t.Date).HasColumnName("date").HasColumnType("datetime").IsRequired();
            builder.Property(t=>t.Type).HasColumnName("type").HasColumnType("tinyint").IsRequired();
            builder.Property(t=>t.SendOrderInfoId).HasColumnName("send_order_info_id").HasColumnType("int").IsRequired();
            builder.Property(t=>t.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.Property(t=>t.AmiyaEmployeeId).HasColumnName("amiya_employee_id").HasColumnType("id").IsRequired(false);
            builder.Property(t=>t.HospitalEmployeeId).HasColumnName("hospital_employee_id").HasColumnType("id").IsRequired(false);
            builder.Property(t=>t.Content).HasColumnName("content").HasColumnType("varchar(500)").IsRequired();

            builder.HasOne(t => t.SendOrderInfo).WithMany(t => t.SendOrderMessageBoardList).HasForeignKey(t=> t.SendOrderInfoId);
            builder.HasOne(t => t.HospitalInfo).WithMany(t => t.SendOrderMessageBoardList).HasForeignKey(t=> t.HospitalId);
            builder.HasOne(t => t.AmiyaEmployee).WithMany(t => t.SendOrderMessageBoardList).HasForeignKey(t=> t.AmiyaEmployeeId);
            builder.HasOne(t => t.HospitalEmployee).WithMany(t => t.SendOrderMessageBoardList).HasForeignKey(t=> t.HospitalEmployeeId);
        }
    }
}
