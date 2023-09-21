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
    public class HospitalContractConfiguration : IEntityTypeConfiguration<HospitalContract>
    {
        public void Configure(EntityTypeBuilder<HospitalContract> builder)
        {
            builder.ToTable("tbl_hospital_contract");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired();
            builder.Property(e=>e.Name).HasColumnName("name").HasColumnType("varchar(500)").IsRequired();
            builder.Property(e => e.ContractUrl).HasColumnName("contract_url").HasColumnType("varchar(500)").IsRequired();
            builder.Property(e => e.StartDate).HasColumnName("start_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.ExpireDate).HasColumnName("expire_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
        }
    }
}
