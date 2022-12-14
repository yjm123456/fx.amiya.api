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
    public class MessageRecieveConfiguration : IEntityTypeConfiguration<MessageRecieve>
    {
        public void Configure(EntityTypeBuilder<MessageRecieve> builder)
        {
            builder.ToTable("tbl_message_recieve");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.Property(e => e.HospitalEmployeeId).HasColumnName("hospital_employee_id").HasColumnType("int").IsRequired(false);
            builder.Property(e => e.IsBindWechat).HasColumnName("is_bind_wechat").HasColumnType("bit").IsRequired();
            builder.Property(e => e.IsBindOfficialAccounts).HasColumnName("is_bind_official_accounts").HasColumnType("bit").IsRequired();
            builder.Property(e => e.IsReceive).HasColumnName("is_receive").HasColumnType("bit").IsRequired();
            builder.Property(e => e.StartTime).HasColumnName("start_time").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.EndTime).HasColumnName("end_time").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
        }
    }
}
