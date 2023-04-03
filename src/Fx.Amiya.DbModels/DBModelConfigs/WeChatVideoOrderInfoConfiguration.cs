using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class WeChatVideoOrderInfoConfiguration : IEntityTypeConfiguration<WeChatVideoOrderInfo>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<WeChatVideoOrderInfo> builder)
        {
            builder.ToTable("tbl_wechatvideo_order_info");
            builder.HasKey(e => e.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t => t.GoodsName).HasColumnName("goods_name").HasColumnType("varchar(500)").IsRequired();
            builder.Property(t => t.GoodsId).HasColumnName("goods_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.Phone).HasColumnName("phone").HasColumnType("varchar(20)").IsRequired(false);
            builder.Property(t => t.StatusCode).HasColumnName("status_code").HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(t => t.ActualPayment).HasColumnName("actual_payment").HasColumnType("decimal(10,2)").IsRequired(false);
            builder.Property(t => t.AccountReceivable).HasColumnName("account_receivable").HasColumnType("decimal(10,2)").IsRequired(false);
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);        
            builder.Property(t => t.ThumbPicUrl).HasColumnName("thumb_pic_url").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.BuyerNick).HasColumnName("buyer_nick").HasColumnType("varchar(225)").IsRequired(false);
            builder.Property(t => t.OrderType).HasColumnName("order_type").HasColumnType("bigint").IsRequired(false);          
            builder.Property(t => t.Quantity).HasColumnName("quantity").HasColumnType("int").IsRequired(false);                   
            builder.Property(t => t.BelongEmpId).HasColumnName("belong_emp_id").HasColumnType("int").IsRequired();
            builder.Property(e => e.CheckState).HasColumnName("check_state").HasColumnType("int").IsRequired(false);
            builder.Property(e => e.CheckPrice).HasColumnName("check_price").HasColumnType("DECIMAL").IsRequired(false);
            builder.Property(e => e.CheckDate).HasColumnName("check_date").HasColumnType("DATETIME").IsRequired(false);
            builder.Property(e => e.SettlePrice).HasColumnName("settle_price").HasColumnType("DECIMAL").IsRequired(false);
            builder.Property(e => e.CheckBy).HasColumnName("check_by").HasColumnType("int").IsRequired(false);
            builder.Property(e => e.CheckRemark).HasColumnName("check_remark").HasColumnType("VARCHAR(300)").IsRequired(false);
            builder.Property(t => t.IsReturnBackPrice).HasColumnName("is_return_back_price").HasColumnType("bit").IsRequired();
            builder.Property(e => e.ReturnBackPrice).HasColumnName("return_back_price").HasColumnType("DECIMAL(12,2)").IsRequired(false);
            builder.Property(e => e.ReturnBackDate).HasColumnName("return_back_date").HasColumnType("DATETIME").IsRequired(false);
            builder.Property(e => e.BelongLiveAnchorId).HasColumnName("belong_live_anchor_id").HasColumnType("int").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
        }
    }
}
