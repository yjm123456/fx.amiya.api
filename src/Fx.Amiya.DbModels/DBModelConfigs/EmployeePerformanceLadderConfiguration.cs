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
    public class EmployeePerformanceLadderConfiguration : IEntityTypeConfiguration<EmployeePerformanceLadder>
    {
        public void Configure(EntityTypeBuilder<EmployeePerformanceLadder> builder)
        {
            builder.ToTable("tbl_employee_performance_ladder");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.CustomerServiceId).HasColumnName("customer_service_id").HasColumnType("int").IsRequired(false);
            builder.Property(e => e.IsPersonalConfig).HasColumnName("is_personal_config").HasColumnType("bit").IsRequired();
            builder.Property(e => e.PerformanceLowerLimit).HasColumnName("performance_lower_limit").HasColumnType("DECIMAL(12,2)").IsRequired();
            builder.Property(e => e.PerformanceUpperLimit).HasColumnName("performance_upper_limit").HasColumnType("DECIMAL(12,2)").IsRequired();
            builder.Property(e => e.BasePerformance).HasColumnName("base_performance").HasColumnType("DECIMAL(12,2)").IsRequired();
            builder.Property(e => e.Point).HasColumnName("point").HasColumnType("DECIMAL(12,2)").IsRequired();
            builder.Property(e => e.Year).HasColumnName("year").HasColumnType("int").IsRequired();
            builder.Property(e => e.Month).HasColumnName("month").HasColumnType("int").IsRequired();
            builder.Property(e => e.Remark).HasColumnName("remark").HasColumnType("VARCHAR(500)").IsRequired(false);
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
        }
    }
}
