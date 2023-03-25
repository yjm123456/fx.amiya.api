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
    public class ContentPlatFormOrderAddWorkConfiguration : IEntityTypeConfiguration<ContentPlatFormOrderAddWork>
    {
        public void Configure(EntityTypeBuilder<ContentPlatFormOrderAddWork> builder)
        {
            builder.ToTable("tbl_content_pat_form_order_add_work");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("DATETIME").IsRequired();
            builder.Property(e => e.CreateBy).HasColumnName("create_by").HasColumnType("INT").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("DATETIME").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("BIT(1)").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("DATETIME").IsRequired(false);
            builder.Property(e => e.AcceptBy).HasColumnName("accept_by").HasColumnType("INT").IsRequired();
            builder.Property(e => e.Phone).HasColumnName("phone").HasColumnType("VARCHAR(11)").IsRequired();
            builder.Property(e => e.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.Property(e => e.SendRemark).HasColumnName("send_remark").HasColumnType("VARCHAR(300)").IsRequired(false);
            builder.Property(e => e.BelongCustomerServiceId).HasColumnName("belong_customer_service_id").HasColumnType("INT").IsRequired(false);
            builder.Property(e => e.CheckState).HasColumnName("check_state").HasColumnType("INT").IsRequired();
            builder.Property(e => e.CheckRemark).HasColumnName("check_remark").HasColumnType("VARCHAR(300)").IsRequired(false);
            builder.Property(e => e.CheckDate).HasColumnName("check_date").HasColumnType("DATETIME").IsRequired(false);

            builder.HasOne(t => t.CreateEmployee).WithMany(t => t.ContentPlatFormOrderAddWorkCreateBy).HasForeignKey(t => t.CreateBy);
            builder.HasOne(t => t.HospitalInfo).WithMany(t => t.ContentPlatFormOrderAddWork).HasForeignKey(t => t.HospitalId);
            builder.HasOne(t => t.AcceptEmployee).WithMany(t => t.ContentPlatFormOrderAddWorkAcceptBy).HasForeignKey(t => t.AcceptBy);
        }
    }
}
