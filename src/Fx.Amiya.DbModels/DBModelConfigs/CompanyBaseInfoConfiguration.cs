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
    public class CompanyBaseInfoConfiguration : IEntityTypeConfiguration<CompanyBaseInfo>
    {
        public void Configure(EntityTypeBuilder<CompanyBaseInfo> builder)
        {
            builder.ToTable("tbl_company_base_info");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Name).HasColumnName("name").HasColumnType("var(200)").IsRequired();
            builder.Property(e => e.RegisterDate).HasColumnName("register_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.RegisterAddress).HasColumnName("register_address").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(e => e.CompanyCode).HasColumnName("company_code").HasColumnType("varchar(100)").IsRequired(false);
            builder.Property(e => e.Corporation).HasColumnName("corporation").HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(e => e.BusinessScope).HasColumnName("business_scope").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(e => e.ContactEmail).HasColumnName("contact_email").HasColumnType("varchar(50)").IsRequired(false);
        }
    }
}
