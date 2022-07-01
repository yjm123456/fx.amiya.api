using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.CustomerInfo
{
    public class BindTrackCustomerInfoDto
    {
        public string Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string UserId { get; set; }
        public string BasePhone { get; set; }
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

        /// <summary>
        /// 是否回访过id（1：已回访过，2：未回访过）
        /// </summary>
        public int IsTrackId { get; set; }
        /// <summary>
        /// 是否回访过
        /// </summary>
        public string IsTrack { get; set; }
        /// <summary>
        /// 最近回访时间
        /// </summary>
        public DateTime? LatestTrackTime { get; set; }
    }
}
