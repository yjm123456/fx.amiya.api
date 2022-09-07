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
    public class MemberCardHandleConfiguration : IEntityTypeConfiguration<MemberCardHandle>
    {
        public void Configure(EntityTypeBuilder<MemberCardHandle> builder)
        {
            builder.ToTable("tbl_member_card_handle");
            builder.HasKey(t => t.MemberCardNum);
            builder.Property(t => t.MemberCardNum).HasColumnName("member_card_num").HasColumnType("varchar(20)").IsRequired();
            builder.Property(t => t.CustomerId).HasColumnName("customer_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.Date).HasColumnName("date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.MemberRankId).HasColumnName("member_rank_id").HasColumnType("tinyint").IsRequired().IsConcurrencyToken();
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(t => t.HandleBy).HasColumnName("handle_by").HasColumnType("int");

            builder.HasOne(t => t.MemberRankInfo).WithMany(t => t.MemberCardhandleList).HasForeignKey(t=>t.MemberRankId);
        }
    }
}
