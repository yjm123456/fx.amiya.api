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
    public class MiniProgramAutoSendMessageConfiguration : IEntityTypeConfiguration<MiniProgramAutoSendMessage>
    {
        public void Configure(EntityTypeBuilder<MiniProgramAutoSendMessage> builder)
        {
            builder.ToTable("tbl_miniprogram_auto_send_message");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.Message).HasColumnName("message").HasColumnType("varchar(3000)").IsRequired();
        }
    }
}
