using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OfficialWebsite.Input
{
    public class GetDesignOrderSignVo
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
        
        public string Phone { get; set; }
        /// <summary>
        /// 性别(男,女)
        /// </summary>
        [Required]
        [MaxLength(1)]
        public string Gender { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        //[RegularExpression("^(19|20)\\d\\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])$", ErrorMessage ="生日日期格式错误")]
        public DateTime? BirthDay { get; set; }
        /// <summary>
        /// 职业(最大20字符)
        /// </summary>
        [MaxLength(20,ErrorMessage = "职业描述不能大于20个字符")]
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
    }
}
