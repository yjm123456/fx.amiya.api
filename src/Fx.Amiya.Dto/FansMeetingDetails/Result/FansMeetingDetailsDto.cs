using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.FansMeetingDetails.Result
{
    public class FansMeetingDetailsDto:BaseDto
    {
        /// <summary>
        /// 粉丝见面会id
        /// </summary>
        public string FansMeetingId { get; set; }

        /// <summary>
        /// 粉丝见面会名称
        /// </summary>
        public string FansMeetingName { get; set; }

        /// <summary>
        /// 订单号（可空）
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 预约时间
        /// </summary>
        public DateTime? AppointmentDate { get; set; }

        /// <summary>
        /// 详细时间
        /// </summary>
        public string AppointmentDetailsDate { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 客户手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 客户质量（0：一般；1：优质）
        /// </summary>
        public int CustomerQuantity { get; set; }

        /// <summary>
        /// 顾客质量名称
        /// </summary>
        public string CustomerQuantityText { get; set; }
        /// <summary>
        /// 新/老客
        /// </summary>
        public bool IsOldCustomer { get; set; }
        /// <summary>
        /// 啊美雅助理id
        /// </summary>
        public int AmiyaConsulationId { get; set; }

        /// <summary>
        /// 啊美雅助理名称
        /// </summary>
        public string AmiyaConsulationName { get; set; }
        /// <summary>
        /// 医院现场咨询
        /// </summary>
        public string HospitalConsulationName { get; set; }
        /// <summary>
        /// 客户所在城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 行程信息
        /// </summary>
        public string TravelInformation { get; set; }

        /// <summary>
        /// 是否接车
        /// </summary>
        public bool IsNeedDriver { get; set; }
        /// <summary>
        /// 酒店安排
        /// </summary>
        public string HotelPlan { get; set; }

        /// <summary>
        /// 预估消费
        /// </summary>
        public decimal PlanConsumption { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 顾客照片
        /// </summary>
        public string CustomerPictureUrl { get; set; }
    }
}
