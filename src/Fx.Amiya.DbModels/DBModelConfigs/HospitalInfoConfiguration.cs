using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class HospitalInfoConfiguration : IEntityTypeConfiguration<HospitalInfo>
    {
        public void Configure(EntityTypeBuilder<HospitalInfo> builder)
        {
            builder.ToTable("tbl_hospital_info");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t => t.Name).HasColumnName("name").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t => t.Address).HasColumnName("address").HasColumnType("varchar(200)").IsRequired();
            builder.Property(t => t.Longitude).HasColumnName("longitude").HasColumnType("decimal(10,6)").IsRequired();
            builder.Property(t => t.Latitude).HasColumnName("latitude").HasColumnType("decimal(10,6)").IsRequired();
            builder.Property(t => t.Phone).HasColumnName("phone").HasColumnType("varchar(20)").IsRequired(false);
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(t => t.ThumbPicUrl).HasColumnName("thumb_pic_url").HasColumnType("varchar(500)").IsRequired();
            builder.Property(t => t.CreateBy).HasColumnName("create_by").HasColumnType("int").IsRequired();
            builder.Property(t => t.HospitalCreateTime).HasColumnName("hospital_create_time").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.UpdateBy).HasColumnName("update_by").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.DueTime).HasColumnName("due_time").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.CityId).HasColumnName("city_id").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.BusinessHours).HasColumnName("business_hours").HasColumnType("varchar(50)");
            builder.Property(t => t.ContractUrl).HasColumnName("contract_url").HasColumnType("varchar(300)");
            builder.Property(t => t.IndustryHonors).HasColumnName("industry_honors").HasColumnType("varchar(200)");
            builder.Property(t => t.ProfileRank).HasColumnName("profile_rank").HasColumnType("varchar(200)");
            builder.Property(t => t.DescriptionPicture).HasColumnName("description_picture").HasColumnType("varchar(300)");
            builder.Property(t => t.Description).HasColumnName("description").HasColumnType("varchar(2000)");
            builder.Property(t => t.Area).HasColumnName("area").HasColumnType("decimal(12,2)").IsRequired(false);
            builder.Property(t => t.CheckRemark).HasColumnName("check_remark").HasColumnType("varchar(300)");
            builder.Property(t => t.CheckState).HasColumnName("check_state").HasColumnType("int").IsRequired();
            builder.Property(t => t.CheckBy).HasColumnName("check_by").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.SubmitState).HasColumnName("submit_state").HasColumnType("int").IsRequired();
            builder.Property(t => t.CheckDate).HasColumnName("check_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.BelongCompany).HasColumnName("belong_company").HasColumnType("varchar(200)").IsRequired(false);
            builder.Property(t => t.IsShareInMiniProgram).HasColumnName("is_share_in_miniprogram").HasColumnType("bit").IsRequired();
            builder.Property(t => t.SimpleName).HasColumnName("simple_name").HasColumnType("varchar(100)").IsRequired(false);
            builder.Property(t => t.Sort).HasColumnName("sort").HasColumnType("int").IsRequired();
            builder.Property(t => t.SendOrder).HasColumnName("send_order").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.NewCustomerCommissionRatio).HasColumnName("new_customer_commission_ratio").HasColumnType("decimal(10,2)").IsRequired(false);
            builder.Property(t => t.OldCustomerCommissionRatio).HasColumnName("old_customer_commission_ratio").HasColumnType("decimal(10,2)").IsRequired(false);
            builder.Property(t => t.RepeatOrderRule).HasColumnName("repeat_order_rule").HasColumnType("varchar(1000)").IsRequired(false);
            builder.Property(t => t.YearServiceFee).HasColumnName("year_service_fee").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.SecurityDeposit).HasColumnName("security_deposit").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.YearServiceMoney).HasColumnName("year_service_money").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(t => t.SecurityDepositMoney).HasColumnName("security_deposit_money").HasColumnType("decimal(10,2)").IsRequired();

            builder.HasOne(t => t.CreateByAmiyaEmployee).WithMany(t => t.CreateByHospitalInfoList).HasForeignKey(t=>t.CreateBy);
            builder.HasOne(t => t.UpdateByAmiyaEmployee).WithMany(t => t.UpdateByHospitalInfoList).HasForeignKey(t=>t.UpdateBy);
            builder.HasOne(t => t.CooperativeHospitalCity).WithMany(t => t.HospitalInfoList).HasForeignKey(t=>t.CityId);
            
        }
    }
}
