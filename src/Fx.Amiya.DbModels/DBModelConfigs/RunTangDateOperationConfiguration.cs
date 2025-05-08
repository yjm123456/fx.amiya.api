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
    public class RunTangDateOperationConfiguration : IEntityTypeConfiguration<RunTangDateOperation>
    {
        public void Configure(EntityTypeBuilder<RunTangDateOperation> builder)
        {
            builder.ToTable("tbl_runtang_date_operation");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.CreateBy).HasColumnName("create_by").HasColumnType("INT").IsRequired();
            builder.Property(e => e.LiveAnchorBaseId).HasColumnName("live_anchor_base_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.CustomerAddNum).HasColumnName("customer_add_num").HasColumnType("int").IsRequired();
            builder.Property(e => e.CompanyAddNum).HasColumnName("company_add_num").HasColumnType("int").IsRequired();
            builder.Property(e => e.TotalAddNum).HasColumnName("total_add_num").HasColumnType("int").IsRequired();
            builder.Property(e => e.EffictiveCommunicationNum).HasColumnName("effictive_communication_num").HasColumnType("int").IsRequired();
            builder.Property(e => e.EffictiveCommunicationRate).HasColumnName("effictive_communication_rate").HasColumnType("DECIMAL(12,2)").IsRequired();
            builder.Property(e => e.InvalidCustomerNum).HasColumnName("invalid_customer_num").HasColumnType("int").IsRequired();
            builder.Property(e => e.EffictiveCustomerNum).HasColumnName("effictive_customer_num").HasColumnType("int").IsRequired();
            builder.Property(e => e.EffictiveCustomerRate).HasColumnName("effictive_customer_rate").HasColumnType("DECIMAL(12,2)").IsRequired();
            builder.Property(e => e.Remark).HasColumnName("remark").HasColumnType("varchar(500)").IsRequired();
            builder.Property(e => e.RecordDate).HasColumnName("record_date").HasColumnType("datetime").IsRequired();

            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);


            builder.HasOne(t => t.AmiyaEmployee).WithMany(t => t.RunTangDateOperationList).HasForeignKey(t => t.CreateBy);
            builder.HasOne(t => t.LiveAnchorBaseInfo).WithMany(t => t.RunTangDateOperationList).HasForeignKey(t => t.LiveAnchorBaseId);
        }
    }
}
