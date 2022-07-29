using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class ShoppingCartRegistrationConfiguration : IEntityTypeConfiguration<ShoppingCartRegistration>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartRegistration> builder)
        {
            builder.ToTable("tbl_shopping_cart_registration");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.RecordDate).HasColumnName("record_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.ContentPlatFormId).HasColumnName("content_plat_form_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.LiveAnchorId).HasColumnName("live_anchor_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.LiveAnchorWechatNo).HasColumnName("live_anchor_wechat_no").HasColumnType("varchar(100)").IsRequired(false);
            builder.Property(t => t.CustomerNickName).HasColumnName("customer_nick_name").HasColumnType("varchar(200)").IsRequired(false);
            builder.Property(t => t.Phone).HasColumnName("phone").HasColumnType("varchar(11)").IsRequired();
            builder.Property(t => t.Price).HasColumnName("price").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.ConsultationType).HasColumnName("consultation_type").HasColumnType("int").IsRequired();
            builder.Property(t => t.IsAddWeChat).HasColumnName("is_add_wechat").HasColumnType("bit").IsRequired();
            builder.Property(t => t.IsWriteOff).HasColumnName("is_write_off").HasColumnType("bit").IsRequired();
            builder.Property(t => t.IsConsultation).HasColumnName("is_consultation").HasColumnType("bit").IsRequired();
            builder.Property(t => t.IsReturnBackPrice).HasColumnName("is_return_back_price").HasColumnType("bit").IsRequired();
            builder.Property(t => t.Remark).HasColumnName("remark").HasColumnType("varchar(300)").IsRequired(false);
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.CreateBy).HasColumnName("create_by").HasColumnType("int").IsRequired();
            builder.Property(t => t.RefundDate).HasColumnName("refund_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.RefundReason).HasColumnName("refund_reason").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.BadReviewDate).HasColumnName("badreview_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.BadReviewContent).HasColumnName("badreview_content").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.BadReviewReason).HasColumnName("badreview_reason").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.IsReContent).HasColumnName("is_recontent").HasColumnType("bit(1)").IsRequired();
            builder.Property(t => t.ReContent).HasColumnName("recontent").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.AdmissionId).HasColumnName("admission_id").HasColumnType("int").IsRequired();
    }
    }
}
