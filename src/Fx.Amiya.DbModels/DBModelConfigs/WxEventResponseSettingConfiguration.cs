using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class WxEventResponseSettingConfiguration : IEntityTypeConfiguration<WxEventResponseSetting>
    {
        public void Configure(EntityTypeBuilder<WxEventResponseSetting> builder)
        {
            builder.ToTable("tbl_wxevent_response_setting");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t => t.IsValid).HasColumnName("is_valid").HasColumnType("bit").IsRequired();
            builder.Property(t => t.Title).HasColumnName("title").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t => t.RspMsgXml).HasColumnName("rsp_msg_xml").HasColumnType("varchar(2000)").IsRequired();
            builder.Property(t => t.EventType).HasColumnName("event_type").HasColumnType("tinyint").IsRequired();
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.UpdateDate).HasColumnName("updated_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.RspMsgType).HasColumnName("rsp_msg_type").HasColumnType("tinyint").IsRequired();

          }
    }
}
