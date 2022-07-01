using Fx.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.MemberCard.Domain
{
    public class MemberRankInfo : IEntity
    {
        public byte ID { get; set; }
        /// <summary>
        /// 会员卡名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 最低消费金额（预留）
        /// </summary>
        public decimal MinAmount { get; set; }
        /// <summary>
        /// 最高消费金额（预留）
        /// </summary>
        public decimal MaxAmount { get; set; }
        /// <summary>
        /// 享受折扣（预留）
        /// </summary>
        public decimal Sconto { get; set; }
        /// <summary>
        /// 本人产生积分比例（预留）
        /// </summary>
        public decimal GenerateIntegrationPercent { get; set; }
        /// <summary>
        /// 本人消费介绍人产生积分比例（预留）
        /// </summary>
        public decimal ReferralsIntegrationPercent { get; set; }
        public bool Valid { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 是否默认(默认只能有一个）
        /// </summary>
        public bool Default { get; set; }
        public string ImageUrl { get; set; }

        /// <summary>
        /// 会员等级代码 
        /// </summary>
        public string RankCode { get; set; }



        public  MemberCardHandle CreateMemberCard(string latestMemberCardNum,string inputMemberCardNum)
        {
            DateTime date = DateTime.Now;

            string memberCardNum = "";
            if (!string.IsNullOrWhiteSpace(inputMemberCardNum))
            {
                memberCardNum = inputMemberCardNum;
            }
            else
            {
                if (string.IsNullOrEmpty(latestMemberCardNum))
                {
                    memberCardNum = "01030";
                }
                else
                {
                    memberCardNum = latestMemberCardNum.Substring(RankCode.Length + 2);
                }
                memberCardNum = (Convert.ToInt32(memberCardNum) + 1).ToString().PadLeft(memberCardNum.Length, '0');

                string year = date.Year.ToString().Substring(date.Year.ToString().Length - 2);
                memberCardNum = RankCode + year + memberCardNum;
            }
            
           
            return new MemberCardHandle()
            {
                MemberCardNum = memberCardNum,
                Date = date,
                MemberRankId = ID,
                Valid=true,

            };
        }

        public MemberCardHandle CreateMemberCardSendToCustomer(string customerId, string latestMemberCardNum, string inputMemberCardNum,int?  handleBy)
        {
            var memberCard = CreateMemberCard(latestMemberCardNum, inputMemberCardNum);
            memberCard.HandleBy = handleBy;
            memberCard.SendToCustomer(customerId);
            return memberCard;
        }
    }
}
