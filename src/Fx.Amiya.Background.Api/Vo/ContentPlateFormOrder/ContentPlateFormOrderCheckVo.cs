using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ContentPlateFormOrder
{
    public class ContentPlateFormOrderCheckVo
    {

        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        public string Id { get; set; }

        /// <summary>
        /// 成交情况id
        /// </summary>
        public string OrderDealInfoId { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        [Required]
        public int CheckState { get; set; }
        /// <summary>
        /// 审核金额
        /// </summary>

        public decimal CheckPrice { get; set; }
        /// <summary>
        /// 结算金额
        /// </summary>

        public decimal SettlePrice { get; set; }
        /// <summary>
        /// 审核信息
        /// </summary>
        public string CheckRemark { get; set; }

        /// <summary>
        /// 审核图片
        /// </summary>
        public List<string> CheckPicture { get; set; }
    }
}
