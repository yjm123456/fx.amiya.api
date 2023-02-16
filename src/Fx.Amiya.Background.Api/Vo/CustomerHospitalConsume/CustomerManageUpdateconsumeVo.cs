using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.CustomerHospitalConsume
{
    public class CustomerManageUpdateconsumeVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        [Required(ErrorMessage = "编号不能为空")]
        public int Id { get; set; }

        /// <summary>
        /// 升单订单号
        /// </summary>
        public string ConsumeId { get; set; }
        /// <summary>
        /// 医院编号
        /// </summary>
        [Required(ErrorMessage = "请选择医院")]
        public int HospitalId { get; set; }
        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }
        /// <summary>
        /// 电话文本
        /// </summary>
        [Required(ErrorMessage = "电话文本不能为空")]
        public string Phone { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        [Required(ErrorMessage = "项目名称不能为空")]
        public string ItemName { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 消费类型：0=当天其他消费,1=再消费
        /// </summary>
        public byte ConsumeType { get; set; }
        //--新增
        /// <summary>
        /// 渠道
        /// </summary>
        public int? Channel { get; set; }
        /// <summary>
        /// 渠道名称
        /// </summary>
        public string ChannelText { get; set; }
        /// <summary>
        /// 三方订单号
        /// </summary>
        public string OtherContentPlatFormOrderId { get; set; }

        /// <summary>
        /// 主播账号ID
        /// </summary>
        public int LiveAnchorId { get; set; }
        /// <summary>
        /// 归属主播IP
        /// </summary>
        public string LiveAnchorName { get; set; }
        /// <summary>
        /// 客户昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 是否携带订单
        /// </summary>
        public bool IsAddedOrder { get; set; }
        /// <summary>
        /// 订单号，多个请用逗号隔开
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 核销日期
        /// </summary>
        public DateTime? WriteOffDate { get; set; }
        /// <summary>
        /// 是否为面诊卡
        /// </summary>
        public bool IsCconsultationCard { get; set; }

        /// <summary>
        /// 升单类型
        /// </summary>
        public int BuyAgainType { get; set; }
        /// <summary>
        /// 升单类型名称
        /// </summary>
        public string BuyAgainTypeText { get; set; }
        /// <summary>
        /// 归属自播/外播
        /// </summary>
        public bool IsSelfLiving { get; set; }

        /// <summary>
        /// 升单日期
        /// </summary>
        public DateTime? BuyAgainTime { get; set; }
        /// <summary>
        /// 是否有升单证明
        /// </summary>
        public bool HasBuyagainEvidence { get; set; }
        /// <summary>
        /// 升单证明截图
        /// </summary>
        public string BuyagainEvidencePic { get; set; }
        /// <summary>
        /// 是否与医院确认
        /// </summary>
        public bool IsCheckToHospital { get; set; }
        /// <summary>
        /// 医院确认截图
        /// </summary>
        public string CheckToHospitalPic { get; set; }
        /// <summary>
        /// 人次
        /// </summary>
        public int PersonTime { get; set; }

        /// <summary>
        /// 是否领取加购礼
        /// </summary>
        public bool IsReceiveAdditionalPurchase { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 审核升单金额
        /// </summary>
        public decimal? CheckBuyAgainPrice { get; set; }
        /// <summary>
        /// 审核结算金额
        /// </summary>
        public decimal? CheckSettlePrice { get; set; }
        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? CheckDate { get; set; }
        /// <summary>
        /// 审核人员名称
        /// </summary>
        public string CheckByEmpName { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public string CheckState { get; set; }

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
        /// 是否确认升单
        /// </summary>
        public bool IsConfirmOrder { get; set; }
        /// <summary>
        /// 登记日期
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 是否开票
        /// </summary>
        public bool IsCreateBill { get; set; }
        /// <summary>
        /// 开票公司
        /// </summary>
        public string CreateBillCompany { get; set; }
    }
}
