using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class CustomerAppointmentScheduleConfiguration : IEntityTypeConfiguration<CustomerAppointmentSchedule>
    {
        public void Configure(EntityTypeBuilder<CustomerAppointmentSchedule> builder)
        {
            builder.ToTable("tbl_customer_appointment_schedule");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.CreateBy).HasColumnName("create_by").HasColumnType("int").IsRequired();
            builder.Property(e => e.CustomerName).HasColumnName("customer_name").HasColumnType("varchar(100)").IsRequired(false);
            builder.Property(e => e.Phone).HasColumnName("phone").HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(e => e.AppointmentType).HasColumnName("appointment_type").HasColumnType("int").IsRequired();
            builder.Property(e => e.AppointmentDate).HasColumnName("appointment_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.IsFinish).HasColumnName("is_finish").HasColumnType("bit").IsRequired();
            builder.Property(e => e.ImportantType).HasColumnName("important_type").HasColumnType("int").IsRequired();
            builder.Property(e => e.Remark).HasColumnName("remark").HasColumnType("varchar(300)").IsRequired(false);
            builder.HasOne(t => t.AmiyaEmployeeInfo).WithMany(t => t.CustomerAppointmentScheduleList).HasForeignKey(t => t.CreateBy);

        }
    }
}
