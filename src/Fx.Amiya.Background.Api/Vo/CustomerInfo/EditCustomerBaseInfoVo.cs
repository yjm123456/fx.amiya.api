using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.CustomerInfo
{
    public class EditCustomerBaseInfoVo
    {
        /// <summary>
        /// 加密电话号
        /// </summary>
       [Required(ErrorMessage = "加密电话号不能为空")]
        public string EncryptPhone { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 职业
        /// </summary>
        public string Occupation { get; set; }

        /// <summary>
        /// 微信号
        /// </summary>
        public string WechatNumber { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }
    }
}
