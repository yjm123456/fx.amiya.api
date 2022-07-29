using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ContentPlateFormOrder
{
    public class ContentPlateFormOrderUpdateDto
    {
        public string Id { get; set; }
        
        /// <summary>
        /// 订单类型(1：咨询:2：定金)
        /// </summary>
        
        public int OrderType { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>

        public string OrderTypeText { get; set; }

        /// <summary>
        /// 内容平台id（下单平台）
        /// </summary>

        public string  ContentPlateFormId { get; set; }
        /// <summary>
        /// 下单平台
        /// </summary>
        public string ContentPlateFormName { get; set; }

        /// <summary>
        /// 主播账号id
        /// </summary>

        public int LiveAnchorId { get; set; }

        /// <summary>
        /// 主播
        /// </summary>
        public string LiveAnchorName { get; set; }
        /// <summary>
        /// 主播微信号
        /// </summary>
        public string LiveAnchorWeChatNo { get; set; }
        /// <summary>
        /// 客户姓名
        /// </summary>

        public string CustomerName { get; set; }
        /// <summary>
        /// 面诊员
        /// </summary>
        public int ConsultationEmpId { get; set; }
        /// <summary>
        /// 面诊员名字
        /// </summary>
        public string ConsultationEmpName { get; set; }

        /// <summary>
        /// 面诊状态
        /// </summary>
        public int ConsultationType { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>

        public string Phone { get; set; }

        /// <summary>
        /// 预约日期
        /// </summary>
        public DateTime? AppointmentDate { get; set; }

        /// <summary>
        /// 预约门店
        /// </summary>
        
        public int AppointmentHospitalId { get; set; }

        /// <summary>
        /// 定金金额
        /// </summary>
        public decimal? DepositAmount { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public DateTime? SendDate { get; set; }

        public int? SendBy { get; set; }
        public string SendByName { get; set; }
        /// <summary>
        /// 成交时间
        /// </summary>
        public DateTime? DealDate { get; set; }

        /// <summary>
        /// 成交金额
        /// </summary>
        public decimal? DealAmount { get; set; }
        /// <summary>
        /// 预约医院
        /// </summary>
        public string AppointmentHospitalName { get; set; }
        /// <summary>
        /// 派单医院
        /// </summary>
        public string SendHospitalName { get; set; }

        /// <summary>
        /// 派单医院logo
        /// </summary>
        public string SendHospitaPicture { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>

        public string GoodsId { get; set; }

        /// <summary>
        /// 商品
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 商品图片
        /// </summary>
        public string ThumbPicture { get; set; }
        /// <summary>
        /// 医院科室id
        /// </summary>
        public string HospitalDepartmentId { get; set; }
        /// <summary>
        /// 医院科室
        /// </summary>
        public string HospitalDepartmentName { get; set; }
        /// <summary>
        /// 咨询内容
        /// </summary>
        public string ConsultingContent { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 后期项目铺垫
        /// </summary>
        public string LateProjectStage { get; set; }

        public int EmployeeId { get; set; }
        public int? CheckBy { get; set; }
        public DateTime? CheckDate { get; set; }
        public string CheckByName { get; set; }
        public int? CheckState { get; set; }

        public string CheckStateText { get; set; }

        public decimal? CheckPrice { get; set; }
        public bool IsToHospital { get; set; }

        public int ToHospitalType { get; set; }

        public string ToHospitalTypeText { get; set; }
        /// <summary>
        /// 到院时间（最新）
        /// </summary>
        public DateTime? ToHospitalDate { get; set; }
        public bool IsReturnBackPrice { get; set; }
        public decimal? ReturnBackPrice { get; set; }
        public DateTime? ReturnBackDate { get; set; }

        public decimal? SettlePrice { get; set; }
        public int? BelongEmpId { get; set; }

        /// <summary>
        /// 归属客服
        /// </summary>
        public string BelongEmpName { get; set; }

        /// <summary>
        /// 订单来源（1：面诊卡，2：非面诊卡）
        /// </summary>
        public int? OrderSource { get; set; }
        /// <summary>
        /// 订单来源文本
        /// </summary>
        public string OrderSourceText { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public int OrderStatus { get; set; }
        public string OrderStatusText { get; set; }

        /// <summary>
        /// 未派单原因
        /// </summary>
        public string UnSendReason { get; set; }

        /// <summary>
        /// 院方接诊人员
        /// </summary>
        public string AcceptConsulting { get; set; }
        /// <summary>
        /// 最终成交医院id
        /// </summary>
        public int? LastDealHospitalId { get; set; }
        /// <summary>
        /// 最终成交医院
        /// </summary>
        public string LastDealHospitalName { get; set; }
        /// <summary>
        /// 三方订单号
        /// </summary>
        public string OtherContentPlatFormOrderId { get; set; }

        /// <summary>
        /// 顾客照片（最多上传5张）
        /// </summary>
        public List<string> CustomerPictures { get; set; }
        /// <summary>
        /// 未成交截图url
        /// </summary>
        public string UnDealPictureUrl { get; set; }
        /// <summary>
        /// 成交凭证
        /// </summary>
        public string DealPictureUrl { get; set; }

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
    }
}
