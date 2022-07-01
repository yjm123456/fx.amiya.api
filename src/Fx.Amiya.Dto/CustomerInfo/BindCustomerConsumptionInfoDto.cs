using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.CustomerInfo
{
    public class BindCustomerConsumptionInfoDto
    {
        public string Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string UserId { get; set; }
        public string Phone { get; set; }
        public string EncryptPhone { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string NickName { get; set; }
        public string Avatar { get; set; }
        public int? CustomerServiceId { get; set; }
        public string CustomerServiceName { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }

        // --新增
        /// <summary>
        /// 最新消费平台平台id（1：下单平台，2：内容平台）
        /// </summary>
        public int NewConsumptionPlatFormId { get; set; }
        /// <summary>
        /// 最新消费平台（下单平台/内容平台）
        /// </summary>
        public string NewConsumptionPlatForm { get; set; }

        /// <summary>
        /// 最新消费渠道
        /// </summary>
        public string NewConsumptionPlatFormAppTypeText { get; set; }
        /// <summary>
        /// 最新消费时间
        /// </summary>
        public DateTime? NewConsumptionTime { get; set; }

        /// <summary>
        /// 累计消费
        /// </summary>
        public decimal AllConsumptionPrice { get; set; }

        /// <summary>
        /// 总单数
        /// </summary>
        public int CreatedOrderNum { get; set; }

        /// <summary>
        /// 首次项目需求（科室+产品/项目）
        /// </summary>
        public string FirstOrderInfo { get; set; }

        /// <summary>
        /// 首次消费时间
        /// </summary>
        public DateTime? FirstOrderCreateDate { get; set; }
    }
}
