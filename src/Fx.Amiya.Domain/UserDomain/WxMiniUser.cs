
using System;
using System.Collections.Generic;
using System.Text;


namespace Fx.Amiya.Domain.UserDomain
{
   public class WxMiniUser: WxBaseUser
    {
        public WxMiniUser(
           string id,
           string openid,
           string unionid,
           string appid,
           string appPath,
           int scene,
           string nickName,
           byte gender,
           DateTime createDate,
           string country,
           string province,
           string city,
           string avatar,
           string language,
           FxUser fxUser)
        {
            //Guard.Against.NullOrWhiteSpace(openid, nameof(openid));
            //Guard.Against.NullOrWhiteSpace(unionid, nameof(unionid));
            //Guard.Against.NullOrWhiteSpace(appid, nameof(appid));
            //Guard.Against.NullOrWhiteSpace(appPath, nameof(appPath));
            OpenId = openid;
            UnionId = unionid;
            AppId = appid;
            Id = id;
            AppPath = appPath;
            Scene = scene;
            NickName = nickName;
            Gender = gender;
            CreateDate = createDate;

            Country = country;
            Province = province;
            City = city;
            Avatar = avatar;
            Language = language;

            if (fxUser == null)
            {
                FxUser = new FxUser
                    (
                        id: Guid.NewGuid().ToString().Replace("-", ""),
                        createDate: createDate,
                        createFromType: FxUserType.Mini
                    );
            }
            else
            {
                FxUser = fxUser;
            }

        }
        /// <summary>
        /// 首次打开小程序的路径
        /// </summary>
        public string AppPath { get; private set; }
        /// <summary>
        /// 首次打开小程序的场景值
        /// </summary>
        public int Scene { get; private set; }

    }
}
