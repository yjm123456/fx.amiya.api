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
    public class TagDetailInfoConfiguration: IEntityTypeConfiguration<TagDetailInfo>
    {
        public void Configure(EntityTypeBuilder<TagDetailInfo> builder)
        {
            builder.ToTable("tbl_tag_detail_info");
            builder.HasKey(e=>new { e.CustomerGoodsId,e.TagId});
            builder.Property(e=>e.CustomerGoodsId).HasColumnName("customer_goods_id").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.TagId).HasColumnName("tag_id").HasColumnType("varchar(50)").IsRequired();            
        }
    }
}
