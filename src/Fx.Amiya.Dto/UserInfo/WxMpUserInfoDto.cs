using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.UserInfo
{
    /// <summary>
    /// 微信公众号用户
    /// </summary>
    public class WxMpUserInfoDto
    {
        public int Subscribe { get; set; }
        public string Openid { get; set; }
        public string Nickname { get; set; }
        public byte Sex { get; set; }
        public string Language { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string Avatar { get; set; }
        public int SubscribeTime { get; set; }
        public string Unionid { get; set; }
        public string Remark { get; set; }
        public int GroupId { get; set; }
        public int[] TagidList { get; set; }
        public string SubscribeScene { get; set; }
        public int QrScene { get; set; }
        public string QrSceneStr { get; set; }

        public string AppId { get; set; }

        public int SubscribeCount { get; set; }
    }
}
