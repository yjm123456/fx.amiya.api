﻿using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class ConsumptionVoucherConfiguration : IEntityTypeConfiguration<ConsumptionVoucher>
    {
        public void Configure(EntityTypeBuilder<ConsumptionVoucher> builder)
        {
            builder.ToTable("tbl_consumption_voucher");
            builder.HasKey(c=>c.Id);
            builder.Property(c=>c.Id).HasColumnName("id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(c => c.Name).HasColumnName("name").HasColumnType("varchar(100)").IsRequired();
            builder.Property(c => c.DeductMoney).HasColumnName("deduct_money").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(c=>c.IsSpecifyProduct).HasColumnName("is_specify_product").HasColumnType("bit").IsRequired();
            builder.Property(c => c.IsAccumulate).HasColumnName("is_accumulate").HasColumnType("bit").IsRequired();
            builder.Property(c => c.IsShare).HasColumnName("is_share").HasColumnType("bit").IsRequired();
            builder.Property(c => c.EffectiveTime).HasColumnName("effective_time").HasColumnType("int").HasDefaultValue(0).IsRequired();
            builder.Property(c=>c.Type).HasColumnName("type").HasColumnType("int").HasDefaultValue(0).IsRequired();
            builder.Property(c => c.Remark).HasColumnName("remark").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(c => c.IsNeedMinFee).HasColumnName("is_need_min_fee").HasColumnType("bit").IsRequired();
            builder.Property(c => c.MinPrice).HasColumnName("min_price").HasColumnType("decimal(10,2)").IsRequired(false);
            builder.Property(c => c.ExpireDate).HasColumnName("expire_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(c => c.IsValid).HasColumnName("is_valid").HasColumnType("bit").IsRequired();
            builder.Property(c => c.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(c=>c.UpdateDate).HasColumnName("update_time").HasColumnType("datetime").IsRequired(false);
            builder.Property(c => c.ConsumptionVoucherCode).HasColumnName("consumption_voucher_code").HasColumnType("varchar(100)").IsRequired();
            builder.Property(c => c.IsMemberVoucher).HasColumnName("is_member_voucher").HasColumnType("bit").IsRequired();
            builder.Property(c => c.MemberRankCode).HasColumnName("member_rank_code").HasColumnType("varchar(50)").IsRequired(false);
            builder.Ignore(c=>c.Valid);
            builder.Ignore(c=>c.DeleteDate);
    }
    }
}
