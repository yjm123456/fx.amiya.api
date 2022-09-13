using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class GoodsMemberRankPriceConfiguration : IEntityTypeConfiguration<GoodsMemberRankPrice>
    {
        public void Configure(EntityTypeBuilder<GoodsMemberRankPrice> builder)
        {
            builder.ToTable("goods_member_rank_price");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.GoodsId).HasColumnName("goods_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.MemberRankId).HasColumnName("member_rank_id").HasColumnType("tinyint").IsRequired();
            builder.Property(t => t.Price).HasColumnName("price").HasColumnType("decimal(12,2)").IsRequired();
            builder.HasOne(e => e.GoodsInfo).WithMany(e => e.GoodsMemberRankPrice).HasForeignKey(e => e.GoodsId);
            builder.HasOne(e => e.MemberCardRankInfo).WithMany(e => e.GoodsMemberRankPrice).HasForeignKey(e => e.MemberRankId);
        }
    }
}
