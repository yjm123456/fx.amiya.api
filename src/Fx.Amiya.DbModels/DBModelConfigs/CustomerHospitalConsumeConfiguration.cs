using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class CustomerHospitalConsumeConfiguration : IEntityTypeConfiguration<CustomerHospitalConsume>
    {
        public void Configure(EntityTypeBuilder<CustomerHospitalConsume> builder)
        {
            builder.ToTable("tbl_customer_hospital_consume");
            builder.HasKey(t => t.Id);
            builder.Property(t=>t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t => t.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.Property(t=>t.ConsumeId).HasColumnName("consume_id").HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(t=>t.Phone).HasColumnName("phone").HasColumnType("varchar(20)").IsRequired();
            builder.Property(t=>t.ItemName).HasColumnName("item_name").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t=>t.Price).HasColumnName("price").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(t=>t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t=>t.ConsumeType).HasColumnName("consume_type").HasColumnType("tinyint").IsRequired();
            builder.Property(t => t.AddedBy).HasColumnName("added_by").HasColumnType("int");
            builder.Property(t => t.Channel).HasColumnName("channel").HasColumnType("int").IsRequired(false);
            builder.Property(t=>t.NickName).HasColumnName("nick_name").HasColumnType("varchar(20)").IsRequired(false);
            builder.Property(t => t.IsAddedOrder).HasColumnName("is_added_order").HasColumnType("bit").IsRequired();
            builder.Property(t => t.OrderId).HasColumnName("order_id").HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(t => t.WriteOffDate).HasColumnName("write_off_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.IsCconsultationCard).HasColumnName("is_consultation_card").HasColumnType("bit").IsRequired();
            builder.Property(t => t.BuyAgainType).HasColumnName("buy_again_type").HasColumnType("int").IsRequired();
            builder.Property(t => t.IsSelfLiving).HasColumnName("is_self_living").HasColumnType("bit").IsRequired();
            builder.Property(t => t.BuyAgainTime).HasColumnName("buy_again_time").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.HasBuyagainEvidence).HasColumnName("has_buyagain_evidence").HasColumnType("bit").IsRequired();
            builder.Property(t => t.BuyagainEvidencePic).HasColumnName("buyagain_evidence_pic").HasColumnType("varchar(200)").IsRequired(false);
            builder.Property(t => t.IsCheckToHospital).HasColumnName("is_checktohospital").HasColumnType("bit").IsRequired();
            builder.Property(t => t.CheckToHospitalPic).HasColumnName("checktohospital_pic").HasColumnType("varchar(200)").IsRequired(false);
            builder.Property(t => t.PersonTime).HasColumnName("person_time").HasColumnType("int").IsRequired();
            builder.Property(t => t.IsReceiveAdditionalPurchase).HasColumnName("is_receive_additional_purchase").HasColumnType("bit").IsRequired();
            builder.Property(t => t.CheckBuyAgainPrice).HasColumnName("check_buy_again_price").HasColumnType("decimal(10,2)").IsRequired(false);
            builder.Property(t => t.CheckSettlePrice).HasColumnName("check_settle_price").HasColumnType("decimal(10,2)").IsRequired(false);
            builder.Property(t => t.CheckDate).HasColumnName("check_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.CheckState).HasColumnName("check_state").HasColumnType("int").IsRequired();
            builder.Property(t => t.CheckBy).HasColumnName("check_by").HasColumnType("int").IsRequired();
            builder.Property(t => t.Remark).HasColumnName("remark").HasColumnType("varchar(300)").IsRequired(false);
            builder.Property(t => t.CheckRemark).HasColumnName("check_remark").HasColumnType("varchar(300)").IsRequired(false);
            builder.Property(t => t.LiveAnchorId).HasColumnName("live_anchor_id").HasColumnType("int");
            builder.Property(t => t.IsReturnBackPrice).HasColumnName("is_return_back_price").HasColumnType("bit").IsRequired();
            builder.Property(e => e.ReturnBackPrice).HasColumnName("return_back_price").HasColumnType("DECIMAL(12,2)").IsRequired(false);
            builder.Property(e => e.ReturnBackDate).HasColumnName("return_back_date").HasColumnType("DATETIME").IsRequired(false);
            builder.Property(t => t.OtherContentPlatFormOrderId).HasColumnName("other_content_platform_order_id").HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(t => t.IsConfirmOrder).HasColumnName("is_confirm_order").HasColumnType("bit").IsRequired();

            builder.HasOne(t => t.HospitalInfo).WithMany(t => t.CustomerHospitalConsumeList).HasForeignKey(t=>t.HospitalId);
        }
    }
}
