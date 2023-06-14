using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    /// <summary>
    /// 录单申请列表基础类
    /// </summary>
    public class ContentPlatFormOrderAddWork : BaseDbModel
    {
        /// <summary>
        /// 创建人
        /// </summary>
        public int CreateBy { get; set; }

        /// <summary>
        /// 接收人
        /// </summary>
        public int AcceptBy { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 申请类型
        /// </summary>
        public int AddWorkType { get; set; }

        /// <summary>
        /// 医院编号
        /// </summary>
        public int HospitalId { get; set; }

        /// <summary>
        /// 申请理由
        /// </summary>
        public string SendRemark { get; set; }

        /// <summary>
        /// 归属客服
        /// </summary>
        public int? BelongCustomerServiceId { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        public int CheckState { get; set; }

        /// <summary>
        /// 审核备注
        /// </summary>
        public string CheckRemark { get; set; }

        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? CheckDate { get; set; }

        public AmiyaEmployee CreateEmployee { get; set; }
        public AmiyaEmployee AcceptEmployee { get; set; }

        public HospitalInfo HospitalInfo { get; set; }
    }
}
