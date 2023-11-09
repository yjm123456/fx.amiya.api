using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class ReceiveGiftConfiguration : IEntityTypeConfiguration<ReceiveGift>
    {
        public void Configure(EntityTypeBuilder<ReceiveGift> builder)
        {
            builder.ToTable("tbl_receive_gift");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t => t.GiftId).HasColumnName("gift_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.CustomerId).HasColumnName("customer_id").HasColumnType("varchar(50)").IsRequired(false); 
            builder.Property(t => t.Date).HasColumnName("date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.Address).HasColumnName("address").HasColumnType("varchar(200)").IsRequired(false);
            builder.Property(t => t.Quantity).HasColumnName("quantity").HasColumnType("int").IsRequired();
            builder.Property(t => t.IsSendGoods).HasColumnName("is_send_goods").HasColumnType("bit").IsRequired();
            builder.Property(t => t.SendGoodsBy).HasColumnName("send_goods_by").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.SendGoodsDate).HasColumnName("send_goods_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.ReceiveName).HasColumnName("receive_name").HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(t => t.ReceivePhone).HasColumnName("receive_phone").HasColumnType("varchar(20)").IsRequired(false);
            builder.Property(t => t.CourierNumber).HasColumnName("courier_number").HasColumnType("varchar(100)").IsRequired(false);
            builder.Property(t => t.ExpressId).HasColumnName("express_id").HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(t => t.OrderId).HasColumnName("order_id").HasColumnType("varchar(100)").IsRequired(false);
            builder.Property(t => t.AddressId).HasColumnName("address_id").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.CreateBy).HasColumnName("create_by").HasColumnType("int").IsRequired(false);
            builder.Property(t=>t.SendType).HasColumnName("send_type").HasColumnType("int").IsRequired().HasDefaultValue(0);
            builder.HasOne(t=>t.GiftInfo).WithMany(t=>t.ReceiveGiftList).HasForeignKey(t=>t.GiftId);
            builder.HasOne(t=>t.CustomerInfo).WithMany(t=>t.ReceiveGiftList).HasForeignKey(t=>t.CustomerId);
            builder.HasOne(t=>t.AmiyaEmployee).WithMany(t=>t.ReceiveGiftList).HasForeignKey(t=>t.SendGoodsBy);
            builder.HasOne(t=>t.OrderInfo).WithOne(t=>t.ReceiveGift).HasForeignKey<ReceiveGift>(t=>t.OrderId);
            builder.HasOne(t=>t.AddressInfo).WithMany(t=>t.ReceiveGiftList).HasForeignKey(t=>t.AddressId);
        }
    }
}
