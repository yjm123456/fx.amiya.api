using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class ActivityInfoConfiguration : IEntityTypeConfiguration<ActivityInfo>
    {
        public void Configure(EntityTypeBuilder<ActivityInfo> builder)
        {
            builder.ToTable("tbl_activity_info");
            builder.HasKey(t => t.Id);
            builder.Property(t=>t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(t=>t.Name).HasColumnName("name").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t=>t.Description).HasColumnName("description").HasColumnType("varchar(1000)").IsRequired(false);
            builder.Property(t=>t.StartDate).HasColumnName("start_date").HasColumnType("date").IsRequired();
            builder.Property(t=>t.EndDate).HasColumnName("end_date").HasColumnType("date").IsRequired();
            builder.Property(t=>t.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(t=>t.CreateBy).HasColumnName("create_by").HasColumnType("int").IsRequired();
            builder.Property(t=>t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t=>t.UpdateBy).HasColumnName("update_by").HasColumnType("int").IsRequired(false);
            builder.Property(t=>t.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);

            builder.HasOne(t => t.CreateByAmiyaEmployee).WithMany(t=>t.CreateByActivityInfoList).HasForeignKey(t=>t.CreateBy);
            builder.HasOne(t => t.UpdateByAmiyaEmployee).WithMany(t=>t.UpdateByActivityInfoList).HasForeignKey(t=>t.UpdateBy);
        }
    }
}
