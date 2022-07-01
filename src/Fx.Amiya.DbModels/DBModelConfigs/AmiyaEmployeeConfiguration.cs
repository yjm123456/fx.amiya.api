using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class AmiyaEmployeeConfiguration : IEntityTypeConfiguration<AmiyaEmployee>
    {
        public void Configure(EntityTypeBuilder<AmiyaEmployee> builder)
        {
            builder.ToTable("tbl_amiya_employee");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t => t.Name).HasColumnName("name").HasColumnType("varchar(150)").IsRequired();
            builder.Property(t => t.UserName).HasColumnName("user_name").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.Password).HasColumnName("password").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(t => t.AmiyaPositionId).HasColumnName("amiya_position_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.IsCustomerService).HasColumnName("is_customer_service").HasColumnType("bit").IsRequired();
            builder.Property(t => t.Email).HasColumnName("e_mail").HasColumnType("varchar(100)").IsRequired();

            builder.HasOne(t => t.AmiyaPositionInfo).WithMany(t => t.AmiyaEmployeeList).HasForeignKey(t=>t.AmiyaPositionId);

        }
    }
}
