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
    public class MemberCardSendRecordConfiguration : IEntityTypeConfiguration<MemberCardSendRecord>
    {
        public void Configure(EntityTypeBuilder<MemberCardSendRecord> builder)
        {
            builder.ToTable("tbl_member_card_send_record");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t => t.CustomerId).HasColumnName("customer_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.Date).HasColumnName("date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.MemberCardNum).HasColumnName("member_card_num").HasColumnType("varchar(20)").IsRequired();
            builder.Property(t => t.MemberRankId).HasColumnName("member_rank_id").HasColumnType("tinyint").IsRequired();
            builder.Property(t => t.HandleBy).HasColumnName("handle_by").HasColumnType("int");
        }
    }
}
