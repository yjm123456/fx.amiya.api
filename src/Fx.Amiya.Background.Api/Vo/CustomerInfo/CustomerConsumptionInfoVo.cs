using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.CustomerInfo
{
    public class CustomerConsumptionInfoVo
    {
        public string Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string UserId { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }

        public string EncryptPhone { get; set; }

        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }


        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// 绑定客服编号
        /// </summary>
        public int? CustomerServiceId { get; set; }

        /// <summary>
        /// 绑定客服名称
        /// </summary>
        public string CustomerServiceName { get; set; }


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
