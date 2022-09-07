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
    public class MemberCardRankInfoConfiguration : IEntityTypeConfiguration<MemberCardRankInfo>
    {
        public void Configure(EntityTypeBuilder<MemberCardRankInfo> builder)
        {
            builder.ToTable("tbl_member_rank_info");
            builder.HasKey(t => t.ID);
            builder.Property(t => t.ID).HasColumnName("id").HasColumnType("tinyint").IsRequired();
            builder.Property(t => t.Name).HasColumnName("name").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.MinAmount).HasColumnName("min_amount").HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(t => t.MaxAmount).HasColumnName("max_amount").HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(t => t.Sconto).HasColumnName("sconto").HasColumnType("decimal(3,2)").IsRequired();
            builder.Property(t => t.GenerateIntegrationPercent).HasColumnName("generate_integration_percent").HasColumnType("decimal(4,3)").IsRequired();
            builder.Property(t => t.ReferralsIntegrationPercent).HasColumnName("referrals_integration_percent").HasColumnType("decimal(3,2)").IsRequired();
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(t => t.Description).HasColumnName("description").HasColumnType("varchar(500)");
            builder.Property(t => t.Default).HasColumnName("default").HasColumnType("bit").IsRequired();
            builder.Property(t => t.ImageUrl).HasColumnName("image_url").HasColumnType("varchar(500)").IsRequired();
            builder.Property(t => t.RankCode).HasColumnName("rank_code").HasColumnType("varchar(5)").IsRequired();
        }
    }
}
