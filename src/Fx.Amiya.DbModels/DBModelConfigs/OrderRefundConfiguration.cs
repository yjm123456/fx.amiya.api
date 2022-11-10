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
    public class OrderRefundConfiguration : IEntityTypeConfiguration<OrderRefund>
    {
        public void Configure(EntityTypeBuilder<OrderRefund> builder)
        {
            builder.ToTable("tbl_order_refund");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.CustomerId).HasColumnName("customer_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.OrderId).HasColumnName("order_id").HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(e => e.TradeId).HasColumnName("trade_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.GoodsName).HasColumnName("goods_name").HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.Remark).HasColumnName("remark").HasColumnType("varchar(500)").IsRequired();
            builder.Property(e => e.CheckState).HasColumnName("check_state").HasColumnType("int").IsRequired();
            builder.Property(e => e.UncheckReason).HasColumnName("uncheck_reason").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(e => e.RefundState).HasColumnName("refund_state").HasColumnType("int").IsRequired();
            builder.Property(e => e.RefundFailReason).HasColumnName("refund_fail_reason").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(e => e.IsPartial).HasColumnName("is_partial").HasColumnType("bit").IsRequired();
            builder.Property(e => e.ExchangeType).HasColumnName("exchange_type").HasColumnType("int").IsRequired();
            builder.Property(e => e.PayDate).HasColumnName("pay_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.CheckDate).HasColumnName("check_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.RefundAmount).HasColumnName("refund_amount").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(e => e.ActualPayAmount).HasColumnName("actual_pay_amount").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(e => e.RefundStartDate).HasColumnName("refund_start_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.RefundResultDate).HasColumnName("refund_result_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.RefundTradeNo).HasColumnName("refund_trade_no").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e=>e.CheckBy).HasColumnName("check_by").HasColumnType("int").IsRequired(false); ;
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
        }
    }
}
