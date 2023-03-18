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
    public class OperationLogConfiguration : IEntityTypeConfiguration<OperationLog>
    {
        public void Configure(EntityTypeBuilder<OperationLog> builder)
        {
            builder.ToTable("tbl_system_operation_log");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.RouteAddress).HasColumnName("route_address").HasColumnType("varchar(500)").IsRequired();
            builder.Property(t => t.RequestType).HasColumnName("request_type").HasColumnType("int").IsRequired();
            builder.Property(t => t.Code).HasColumnName("code").HasColumnType("int").IsRequired();
            builder.Property(t => t.Parameters).HasColumnName("parameters").HasColumnType("varchar(5000)").IsRequired(false);
            builder.Property(t => t.Message).HasColumnName("message").HasColumnType("varchar(5000)").IsRequired(false);
            builder.Property(t => t.OperationBy).HasColumnName("operation_by").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.Sounrce).HasColumnName("source").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("BIT(1)").IsRequired();
            builder.Property(t => t.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
        }
    }
}
