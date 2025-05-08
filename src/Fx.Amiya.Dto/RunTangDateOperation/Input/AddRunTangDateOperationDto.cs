using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.RunTangDateOperation.Input
{
    public class AddRunTangDateOperationDto
    {
        /// <summary>
        /// 登记日期
        /// </summary>
        public DateTime RecordDate { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public int CreateBy { get; set; }

        /// <summary>
        /// 基础主播ID
        /// </summary>
        public string LiveAnchorBaseId { get; set; }

        /// <summary>
        /// 主动添加（客户）
        /// </summary>
        public int CustomerAddNum { get; set; }
        /// <summary>
        /// 被动添加（我们）
        /// </summary>
        public int CompanyAddNum { get; set; }

        /// <summary>
        /// 当日添加总数
        /// </summary>
        public int TotalAddNum { get; set; }

        /// <summary>
        /// 有效沟通
        /// </summary>
        public int EffictiveCommunicationNum { get; set; }

        /// <summary>
        /// 有效沟通率
        /// </summary>
        public decimal EffictiveCommunicationRate { get; set; }


        /// <summary>
        /// 无效客资
        /// </summary>
        public int InvalidCustomerNum { get; set; }

        /// <summary>
        /// 有效客资
        /// </summary>
        public int EffictiveCustomerNum { get; set; }

        /// <summary>
        /// 客资有效率
        /// </summary>
        public decimal EffictiveCustomerRate { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
