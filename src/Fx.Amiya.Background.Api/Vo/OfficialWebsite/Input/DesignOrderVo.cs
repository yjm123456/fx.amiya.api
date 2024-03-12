using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OfficialWebsite.Input
{
    public class DesignOrderVo
    {
        /// <summary>
        /// 客户昵称(最大10个字符)
        /// </summary>
        [Required]
        [MaxLength(10, ErrorMessage = "昵称不能大于10个字符")]
        public string NickName { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [Required]
        [RegularExpression("^1[345789]\\d{9}$", ErrorMessage = "手机号格式错误")]
        public string Phone { get; set; }
        /// <summary>
        /// 性别(1:男,2:女)
        /// </summary>
        [Required]
        [MaxLength(1)]
        public string Gender { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        //[RegularExpression(@"((([0-9]{3}[1-9]|[0-9]{2}[1-9][0-9]{1}|[0-9]{1}[1-9][0-9]{2}|[1-9][0-9]{3})-(((0[13578]|1[02])-(0[1-9]|[12][0-9]|3[01]))|((0[469]|11)-(0[1-9]|[12][0-9]|30))|(02-(0[1-9]|[1][0-9]|2[0-8]))))|((([0-9]{2})(0[48]|[2468][048]|[13579][26])|((0[48]|[2468][048]|[3579][26])00))-02-29))", ErrorMessage = "生日日期格式错误")]
        public DateTime? BirthDay { get; set; }
        /// <summary>
        /// 职业(最大20字符)
        /// </summary>
        [MaxLength(20, ErrorMessage = "职业描述不能大于20个字符")]
        public string Profession { get; set; }
        /// <summary>
        /// 微信号备注(最大50字符)
        /// </summary>
        [MaxLength(50, ErrorMessage = "微信备注不能大于50个字符")]
        public string WechatRemark { get; set; }
        /// <summary>
        /// 所在城市(最大50字符)
        /// </summary>
        [MaxLength(50, ErrorMessage = "城市信息不能大于50个字符")]
        public string City { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        [Required(ErrorMessage ="签名不能为空")]
        public string Sign { get; set; }
    }
}
