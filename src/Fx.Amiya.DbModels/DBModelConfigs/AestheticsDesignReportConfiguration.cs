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
    public class AestheticsDesignReportConfiguration : IEntityTypeConfiguration<AestheticsDesignReport>
    {
        public void Configure(EntityTypeBuilder<AestheticsDesignReport> builder)
        {
            builder.ToTable("tbl_aesthetics_design_report");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.CustomerId).HasColumnName("customer_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.Name).HasColumnName("name").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.BirthDay).HasColumnName("birth_day").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.Phone).HasColumnName("phone").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.HasAestheticMedicineHistory).HasColumnName("has_aesthetic_history").HasColumnType("bit").IsRequired();
            builder.Property(e => e.HistoryDescribe1).HasColumnName("history_describe1").HasColumnType("varchar(5000)").IsRequired(false);
            builder.Property(e => e.HistoryDescribe2).HasColumnName("history_describe2").HasColumnType("varchar(5000)").IsRequired(false);
            builder.Property(e => e.HistoryDescribe3).HasColumnName("history_describe3").HasColumnType("varchar(5000)").IsRequired(false);
            builder.Property(e => e.WhetherAcceptOperation).HasColumnName("whether_accept_operation").HasColumnType("bit").IsRequired();
            builder.Property(e => e.WhetherAllergyOrOtherDisease).HasColumnName("whether_allergy").HasColumnType("bit").IsRequired();
            builder.Property(e => e.AllergyOrOtherDiseaseDescribe).HasColumnName("allergy_describe").HasColumnType("varchar(5000)").IsRequired(false);
            builder.Property(e => e.BeautyDemand).HasColumnName("beauty_demand").HasColumnType("varchar(5000)").IsRequired();
            builder.Property(e => e.Budget).HasColumnName("budge").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(e => e.Picture1).HasColumnName("pictrue1").HasColumnType("varchar(500)").IsRequired();
            builder.Property(e => e.Picture2).HasColumnName("pictrue2").HasColumnType("varchar(500)").IsRequired();
            builder.Property(e => e.Status).HasColumnName("status").HasColumnType("int").IsRequired();
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
        }
    }
}
