using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class AmiyaOutWarehouseConfiguration : IEntityTypeConfiguration<AmiyaOutWarehouse>
    {
        public void Configure(EntityTypeBuilder<AmiyaOutWarehouse> builder)
        {
            builder.ToTable("tbl_amiya_out_warehouse");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(t => t.WareHouseId).HasColumnName("warehouse_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(t => t.SinglePrice).HasColumnName("single_price").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.Num).HasColumnName("num").HasColumnType("int").IsRequired();
            builder.Property(t => t.AllPrice).HasColumnName("all_price").HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(t => t.CreateBy).HasColumnName("create_by").HasColumnType("int").IsRequired();
            builder.Property(t => t.EmployeeId).HasColumnName("use_employee_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.DepartmentId).HasColumnName("department_id").HasColumnType("int").IsRequired();
            builder.Property(t => t.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.Remark).HasColumnName("remark").HasColumnType("varchar(500)").IsRequired(false);

            builder.HasOne(e => e.WareHouseInfo).WithMany(e => e.AmiyaOutWarehouseList).HasForeignKey(e => e.WareHouseId);
            builder.HasOne(e => e.Employee).WithMany(e => e.AmiyaOutWarehouse).HasForeignKey(e => e.CreateBy);
            builder.HasOne(e => e.UseEmployee).WithMany(e => e.AmiyaOutWarehouseUsing).HasForeignKey(e => e.EmployeeId);
            builder.HasOne(e => e.Department).WithMany(e => e.UseDepartmentInfoList).HasForeignKey(e => e.DepartmentId);
        }
    }
}
