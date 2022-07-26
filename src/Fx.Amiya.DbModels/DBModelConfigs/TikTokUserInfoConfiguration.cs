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
    public class TikTokUserInfoConfiguration : IEntityTypeConfiguration<TikTokUserInfo>
    {
        public void Configure(EntityTypeBuilder<TikTokUserInfo> builder)
        {
            builder.ToTable("tbl_tiktok_userinfo");
            builder.Property(x=>x.Id).HasColumnName("id").HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Phone).HasColumnName("phone").HasColumnType("varchar(50)");
            builder.Property(x => x.Name).HasColumnName("name").HasColumnType("varchar(50)");
            builder.Property(x => x.CipherName).HasColumnName("cipher_name").HasColumnType("varchar(500)");
            builder.Property(x => x.CipherPhone).HasColumnName("cipher_phone").HasColumnType("varchar(500)");
        }
    }
}
