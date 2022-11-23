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
    public class IndicatorOrderDataConfiguration : IEntityTypeConfiguration<IndicatorOrderData>
    {
        public void Configure(EntityTypeBuilder<IndicatorOrderData> builder)
        {
            builder.ToTable("tbl_indicator_order_data");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.HospitalId).HasColumnName("hospital_id").HasColumnType("int").IsRequired(false);
            builder.Property(e => e.IndicatorId).HasColumnName("indicator_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.AllSendorderCount).HasColumnName("all_sendorder_count").HasColumnType("int").IsRequired();
            builder.Property(e => e.LocalSendorderCount).HasColumnName("local_sendorder_count").HasColumnType("int").IsRequired();
            builder.Property(e => e.OtherPlaceSendorderCount).HasColumnName("other_place_sendorder_count").HasColumnType("int").IsRequired();
            builder.Property(e => e.InvalidSendorderCount).HasColumnName("invalid_sendorder_count").HasColumnType("int").IsRequired();
            builder.Property(e => e.EpidemicCount).HasColumnName("epidemic_count").HasColumnType("int").IsRequired();
            builder.Property(e => e.OtherQuestion).HasColumnName("other_question").HasColumnType("varchar(500)").IsRequired();
            builder.Property(e => e.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UpdateDate).HasColumnName("update_date").HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date").HasColumnType("datetime").IsRequired(false);
        }
    }
}
