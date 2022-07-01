using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fx.Amiya.DbModels.DBModelConfigs
{
    public class AmiyaWareHouseNameManageConfiguration : IEntityTypeConfiguration<AmiyaWareHouseNameManage>
    {
        public void Configure(EntityTypeBuilder<AmiyaWareHouseNameManage> builder)
        {
            builder.ToTable("tbl_amiya_warehouse_name_manage");
            builder.Property(t => t.Id).HasColumnName("id").HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(t => t.Name).HasColumnName("name").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t => t.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
        }
    }
}
