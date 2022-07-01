using Fx.Amiya.Modules.MemberCard.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Modules.MemberCard.Infrastructure.Repositories
{
     public static class DbModelConfigurations
    {
        public static void Configuration(IFreeSql freeSql)
        {
            freeSql.CodeFirst.Entity<MemberRankInfoDbModel>(entity => {
                entity.ToTable("tbl_member_rank_info");
                entity.HasKey(t => t.ID);
                entity.Property(t => t.ID).HasColumnName("id").HasColumnType("tinyint").IsRequired();
                entity.Property(t => t.Name).HasColumnName("name").HasColumnType("varchar(50)").IsRequired();
                entity.Property(t => t.MinAmount).HasColumnName("min_amount").HasColumnType("decimal(18,2)").IsRequired();
                entity.Property(t => t.MaxAmount).HasColumnName("max_amount").HasColumnType("decimal(18,2)").IsRequired();
                entity.Property(t => t.Sconto).HasColumnName("sconto").HasColumnType("decimal(3,2)").IsRequired();
                entity.Property(t => t.GenerateIntegrationPercent).HasColumnName("generate_integration_percent").HasColumnType("decimal(3,2)").IsRequired();
                entity.Property(t => t.ReferralsIntegrationPercent).HasColumnName("referrals_integration_percent").HasColumnType("decimal(3,2)").IsRequired();
                entity.Property(t => t.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
                entity.Property(t => t.Description).HasColumnName("description").HasColumnType("varchar(500)");
                entity.Property(t => t.Default).HasColumnName("default").HasColumnType("bit").IsRequired();
                entity.Property(t => t.ImageUrl).HasColumnName("image_url").HasColumnType("varchar(500)").IsRequired();
                entity.Property(t => t.RankCode).HasColumnName("rank_code").HasColumnType("varchar(5)").IsRequired();
               
            });

            freeSql.CodeFirst.Entity<MemberCardSendRecordDbModel>(entity => {
                entity.ToTable("tbl_member_card_send_record");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Id).HasColumnName("id").HasColumnType("int").IsRequired();
                entity.Property(t => t.CustomerId).HasColumnName("customer_id").HasColumnType("varchar(50)").IsRequired();
                entity.Property(t => t.Date).HasColumnName("date").HasColumnType("datetime").IsRequired();
                entity.Property(t => t.MemberCardNum).HasColumnName("member_card_num").HasColumnType("varchar(20)").IsRequired();
                entity.Property(t => t.MemberRankId).HasColumnName("member_rank_id").HasColumnType("tinyint").IsRequired();
                entity.Property(t => t.HandleBy).HasColumnName("handle_by").HasColumnType("int");

                entity.HasOne(t => t.MemberRankInfo).WithMany(t => t.MemberCardSendRecordList).HasForeignKey(t=>t.MemberRankId);
            });

            freeSql.CodeFirst.Entity<MemberCardHandleDbModel>(entity => {
                entity.ToTable("tbl_member_card_handle");
                entity.HasKey(t => t.MemberCardNum);
                entity.Property(t => t.MemberCardNum).HasColumnName("member_card_num").HasColumnType("varchar(20)").IsRequired();
                entity.Property(t => t.CustomerId).HasColumnName("customer_id").HasColumnType("varchar(50)").IsRequired();
                entity.Property(t => t.Date).HasColumnName("date").HasColumnType("datetime").IsRequired();
                entity.Property(t => t.MemberRankId).HasColumnName("member_rank_id").HasColumnType("tinyint").IsRequired();
                entity.Property(t => t.Valid).HasColumnName("valid").HasColumnType("bit").IsRequired();
                entity.Property(t => t.HandleBy).HasColumnName("handle_by").HasColumnType("int");

                entity.HasOne(t => t.MemberRankInfo).WithMany(t => t.MemberCardHandleList).HasForeignKey(t => t.MemberRankId);
            });

      
        }
    }
}
