using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.UserInfo
{
    public class UserInfoVo
    {
        public string Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string NickName { get; set; }
        public string Phone { get; set; }
        /// <summary>
        /// 性别编号
        /// </summary>
        public byte Gender { get; set; }

        /// <summary>
        /// 性别文本
        /// </summary>
        public string Sex { get; set; }
        public string AvatarUrl { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Area { get; set; }
        public string PersonalSignature { get; set; }
        public string DetailAddress { get; set; }
        /// <summary>
        /// 是否需要授权用户信息
        /// </summary>
        public bool IsAuthorizationUserInfo { get; set; }
    }
}
