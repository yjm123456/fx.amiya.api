using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalInfo
{
    public class HospitalCheckInfoVo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ThumbPicUrl { get; set; }


        /// <summary>
        /// 审核状态（0-未审核；1-：审核不通过；2-审核通过）
        /// </summary>
        public int CheckState { get; set; }

        /// <summary>
        /// 审核状态文本
        /// </summary>
        public string CheckStateText { get; set; }

        /// <summary>
        /// 审核人id
        /// </summary>
        public int? CheckBy { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        public string CheckEmpName { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? CheckDate { get; set; }

        /// <summary>
        /// 审核备注
        /// </summary>
        public string CheckRemark { get; set; }

        /// <summary>
        /// 提交状态（0-未提交；1-已提交）
        /// </summary>
        public int SubmitState { get; set; }

        /// <summary>
        /// 提交状态文本
        /// </summary>
        public string SubmitStateText { get; set; }


    }
}
