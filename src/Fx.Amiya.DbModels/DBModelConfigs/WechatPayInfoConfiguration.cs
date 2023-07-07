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
    public class WechatPayInfoConfiguration : IEntityTypeConfiguration<WechatPayInfo>
    {
        public void Configure(EntityTypeBuilder<WechatPayInfo> builder)
        {
            builder.ToTable("tbl_wechat_payinfo");
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.AppId).HasColumnName("app_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.AppSecret).HasColumnName("app_secret").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.PartnerId).HasColumnName("partner_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.PartnerKey).HasColumnName("partner_key").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.EnableSP).HasColumnName("enablesp").HasColumnType("bit").IsRequired();
            builder.Property(e => e.SubAppId).HasColumnName("sub_app_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.SubMchId).HasColumnName("sub_mch_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.PrivateKey).HasColumnName("private_key").HasColumnType("varchar(5000)").IsRequired(false);
            builder.Property(e => e.PublickKey).HasColumnName("public_key").HasColumnType("varchar(5000)").IsRequired(false);
            builder.Property(e => e.CertificateName).HasColumnName("certificate_name").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(e => e.StoreId).HasColumnName("store_id").HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(e => e.Remark).HasColumnName("remark").HasColumnType("varchar(200)").IsRequired();
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
        }
    }
}
