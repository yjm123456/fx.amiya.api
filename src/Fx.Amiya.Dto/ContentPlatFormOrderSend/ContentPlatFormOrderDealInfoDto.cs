using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ContentPlatFormOrderSend
{
    /// <summary>
    /// 内容平台派单处理情况
    /// </summary>
    public class ContentPlatFormOrderDealInfoDto
    {

        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string ContentPlatFormOrderId { get; set; }

        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime OrderCreateDate { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 派单时间
        /// </summary>
        public DateTime? SendDate { get; set; }


        /// <summary>
        /// 平台
        public string ContentPlatFormName { get; set; }
        /// <summary>
        /// 主播
        /// </summary>
        public string LiveAnchorName { get; set; }

        /// <summary>
        /// 项目
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 客户昵称
        /// </summary>
        public string CustomerNickName { get; set; }

        /// <summary>
        /// 客户手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 是否到院
        /// </summary>
        public bool IsToHospital { get; set; }

        /// <summary>
        /// 到院类型
        /// </summary>
        public int ToHospitalType { get; set; }

        /// <summary>
        /// 到院类型文本
        /// </summary>
        public string ToHospitalTypeText { get; set; }

        /// <summary>
        /// 到院时间
        /// </summary>
        public DateTime? ToHospitalDate { get; set; }

        /// <summary>
        /// 是否成交
        /// </summary>
        public bool IsDeal { get; set; }
        /// <summary>
        /// 最终成交医院id
        /// </summary>
        public int? LastDealHospitalId { get; set; }
        public string LastDealHospital { get; set; }

        /// <summary>
        /// 截图
        /// </summary>
        public string DealPicture { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 成交时间
        /// </summary>
        public DateTime? DealDate { get; set; }

        /// <summary>
        /// 三方订单号
        /// </summary>
        public string OtherAppOrderId { get; set; }

        /// <summary>
        /// 新客/老客
        /// </summary>
        public bool IsOldCustomer { get; set; }

        /// <summary>
        /// 是否陪诊
        /// </summary>
        public bool IsAcompanying { get; set; }

        /// <summary>
        /// 佣金比例
        /// </summary>
        public decimal CommissionRatio { get; set; }


        /// <summary>
        /// 审核状态
        /// </summary>
        public int? CheckState { get; set; }

        /// <summary>
        /// 审核状态文本
        /// </summary>
        public string CheckStateText { get; set; }
        /// <summary>
        /// 审核金额
        /// </summary>

        public decimal? CheckPrice { get; set; }
        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? CheckDate { get; set; }
        /// <summary>
        /// 结算金额
        /// </summary>

        public decimal? SettlePrice { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        public int? CheckBy { get; set; }

        /// <summary>
        /// 审核人名称
        /// </summary>
        public string CheckByEmpName { get; set; }
        /// <summary>
        /// 审核备注
        /// </summary>
        public string CheckRemark { get; set; }
        /// <summary>
        /// 是否回款
        /// </summary>

        public bool IsReturnBackPrice { get; set; }
        /// <summary>
        /// 回款金额
        /// </summary>

        public decimal? ReturnBackPrice { get; set; }
        /// <summary>
        /// 回款日期
        /// </summary>
        public DateTime? ReturnBackDate { get; set; }

        /// <summary>
        /// 面诊员id
        /// </summary>
        public int? ConsultationEmpId { get; set; }
        /// <summary>
        /// 面诊员
        /// </summary>
        public string ConsultationEmpName { get; set; }

        /// <summary>
        /// 创建人（0为医院）
        /// </summary>
        public int CreateBy { get; set; }

        /// <summary>
        /// 创建人名称
        /// </summary>
        public string CreateByEmpName { get; set; }
    }
}
