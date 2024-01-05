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
            builder.Property(t => t.Avatar).HasColumnName("avatar").HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(t => t.Name).HasColumnName("name").HasColumnType("varchar(150)").IsRequired();
            builder.Property(t => t.UserName).HasColumnName("user_name").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.Password).HasColumnName("password").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(t => t.AmiyaPositionId).HasColumnName("amiya_position_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.IsCustomerService).HasColumnName("is_customer_service").HasColumnType("bit").IsRequired();
            builder.Property(t => t.Email).HasColumnName("e_mail").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t => t.UserId).HasColumnName("user_id").HasColumnType("varchar(600)").IsRequired(false);
            builder.Property(t => t.Code).HasColumnName("code").HasColumnType("varchar(600)").IsRequired(false);
            builder.Property(t => t.CodeExpireDate).HasColumnName("code_expire_date").HasColumnType("DATETIME").IsRequired(false);
            builder.Property(t => t.LiveAnchorBaseId).HasColumnName("bind_base_live_anchor_id").HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(t => t.NewCustomerCommission).HasColumnName("new_customer_commission").HasColumnType("decimal(10,2)").IsRequired(false);
            builder.Property(t => t.OldCustomerCommission).HasColumnName("old_customer_commission").HasColumnType("decimal(10,2)").IsRequired(false);
            builder.Property(t=>t.InspectionCommission).HasColumnName("inspection_commission").HasColumnType("decimal(10,2)").IsRequired(false);
            builder.HasOne(t => t.AmiyaPositionInfo).WithMany(t => t.AmiyaEmployeeList).HasForeignKey(t => t.AmiyaPositionId);

        }
    }
}
