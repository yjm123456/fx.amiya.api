using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class LeaveMessageConfiguration : IEntityTypeConfiguration<LeaveMessage>
    {
        public void Configure(EntityTypeBuilder<LeaveMessage> builder)
        {
            builder.ToTable("tbl_leave_message");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t => t.UserId).HasColumnName("user_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.Date).HasColumnName("date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.Content).HasColumnName("content").HasColumnType("varchar(5000)").IsRequired();
            builder.Property(t => t.MsgType).HasColumnName("msg_type").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.FromAppId).HasColumnName("from_app_id").HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(t => t.MsgId).HasColumnName("msg_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.Type).HasColumnName("type").HasColumnType("tinyint").IsRequired();
            builder.Property(t => t.IsReply).HasColumnName("is_reply").HasColumnType("bit").IsRequired(false);
            builder.Property(t => t.EmployeeId).HasColumnName("employeeId").HasColumnType("int").IsRequired(false);

            builder.HasOne(t => t.UserInfo).WithMany(t => t.LeaveMessageList).HasForeignKey(t => t.UserId);
            builder.HasOne(t => t.AmiyaEmployee).WithMany(t => t.LeaveMessageList).HasForeignKey(t => t.EmployeeId);
        }
    }
}
