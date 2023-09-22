using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.CustomerConsumptionCredentials
{
    public class AddCustomerConsumptionCredentialsVo
    {
        /// <summary>
        /// 小程序绑定手机号
        /// </summary>
        public string BindPhone { get; set; }
        /// <summary>
        /// 基础主播id
        /// </summary>
        public string BaseLiveAnchorId { get; set; }
        /// <summary>
        /// 助理id(选填)
        /// </summary>
        public int? AssistantId { get; set; }
        /// <summary>
        /// 客户姓名
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 留院电话
        /// </summary>
        public string ToHospitalPhone { get; set; }
        /// <summary>
        /// 消费时间
        /// </summary>

        public DateTime ConsumeDate { get; set; }
        /// <summary>
        /// 消费凭证截图1
        /// </summary>

        public string PayVoucherPicture1 { get; set; }
        /// <summary>
        /// 消费凭证截图2
        /// </summary>
        public string PayVoucherPicture2 { get; set; }
        /// <summary>
        /// 消费凭证截图3
        /// </summary>
        public string PayVoucherPicture3 { get; set; }
        /// <summary>
        /// 消费凭证截图4
        /// </summary>
        public string PayVoucherPicture4 { get; set; }
        /// <summary>
        /// 消费凭证截图5
        /// </summary>
        public string PayVoucherPicture5 { get; set; }
        
    }
}
