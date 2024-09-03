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
    public class ThirdPartContentplatformInfoConfiguration : IEntityTypeConfiguration<ThirdPartContentplatformInfo>
    {
        public void Configure(EntityTypeBuilder<ThirdPartContentplatformInfo> builder)
        {
            builder.ToTable("tbl_third_part_contentplatform_info");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.Name).HasColumnName("name").HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(e => e.ApiUrl).HasColumnName("api_url").HasColumnType("VARCHAR(300)").IsRequired(false);
            builder.Property(e => e.Sign).HasColumnName("sign").HasColumnType("VARCHAR(100)").IsRequired(false);

            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("DATETIME").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("DATETIME").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("BIT(1)").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("DATETIME").IsRequired(false);

        }
    }
}
