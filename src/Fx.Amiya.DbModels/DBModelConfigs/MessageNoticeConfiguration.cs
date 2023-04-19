using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class MessageNoticeConfiguration : IEntityTypeConfiguration<MessageNotice>
    {
        public void Configure(EntityTypeBuilder<MessageNotice> builder)
        {
            builder.ToTable("tbl_message_notice");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.AcceptBy).HasColumnName("accept_by").HasColumnType("int").IsRequired();
            builder.Property(e => e.IsRead).HasColumnName("is_read").HasColumnType("bit").IsRequired();
            builder.Property(e => e.NoticeContent).HasColumnName("notice_content").HasColumnType("varchar(500)").IsRequired();
            builder.Property(e => e.NoticeType).HasColumnName("notice_type").HasColumnType("int").IsRequired();
            builder.HasOne(t => t.AmiyaEmployeeInfo).WithMany(t => t.MessageNoticeList).HasForeignKey(t => t.AcceptBy);

        }
    }
}
