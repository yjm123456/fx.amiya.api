using Ardalis.GuardClauses;
using Fx.Amiya.Domain.UserDomain.Events;
using Fx.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Domain.UserDomain
{
    /// <summary>
    /// 微信公众号用户
    /// </summary>
    public class WxMpUser: WxBaseUser, IEntity
    {
        public List<DomainEvent> DomainEvents { get; private set; }
        public WxMpUserSubscribeDetail SubscribeDetail { get; private set; }
        public WxMpUser(
            string id,
            string openid,
            string unionid,
            string appid,
            string nickName,
            byte gender,
            string country,
            string province,
            string city,
            string avatar,
            string language,
            DateTime createDate,
            int subscribeTime,
            string subscribeScene,
            int subscribeCount,
            bool isSubscribed,
            int? groupid,
            int[] tagidList,
            int? qrScene,
            string qrSceneStr,
            string remark,
            FxUser fxUser
            )
        {
            Guard.Against.NullOrWhiteSpace(id, nameof(id));
            Guard.Against.NullOrWhiteSpace(openid, nameof(openid));
            Guard.Against.NullOrWhiteSpace(unionid, nameof(unionid));
            Id = id;
            OpenId = openid;
            UnionId = unionid;
            AppId = appid;
            NickName = nickName;
            Gender = gender;
            Country = country;
            Province = province;
            City = city;
            Avatar = avatar;
            Language = language;
            CreateDate = createDate;
            SubscribeTime = subscribeTime;
            SubscribeScene = subscribeScene;
            SubscribeCount = subscribeCount;
            IsSubscribed = isSubscribed;
            GroupId = groupid;
            TagidList = tagidList;
            QrScene = qrScene;
            QrSceneStr = qrSceneStr;
            Remark = remark;
            if (fxUser == null)
            {
                FxUser = new FxUser(
                     id: Guid.NewGuid().ToString().Replace("-", ""),
                     createDate: CreateDate,
                     createFromType: FxUserType.Mp
                    );
            }
            else
            {
                FxUser = fxUser;
            }
            DomainEvents = new List<DomainEvent>();
        }
        public string QrSceneStr { get; private set; }
        public bool IsSubscribed { get; private set; }
        public int? QrScene { get; private set; }
        public int[] TagidList { get; private set; }
        public int? GroupId { get; private set; }
        public int SubscribeTime { get; private set; }
        public string Remark { get; private set; }
        public string SubscribeScene { get; private set; }

        public int SubscribeCount { get; set; }


        /// <summary>
        /// 关注
        /// </summary>
        public void Subscribe()
        {
            IsSubscribed = true;
            SubscribeCount++;
            SubscribeDetail = new WxMpUserSubscribeDetail()
            {
                AppId = this.AppId,
                Date = DateTime.Now,
                MpUserId = this.Id,
                Subscribe = true
            };
            //生成一个用户关注的领域事件
            MpUserSubscribeDomainEvent subscribeEvent = new MpUserSubscribeDomainEvent(this);
            DomainEvents.Add(subscribeEvent);
        }

        /// <summary>
        /// 取消关注
        /// </summary>
        public void Unsubscribe()
        {
            this.IsSubscribed = false;
            SubscribeDetail = new WxMpUserSubscribeDetail()
            {
                AppId = this.AppId,
                Date = DateTime.Now,
                MpUserId = this.Id,
                Subscribe = false
            };
            MpUserUnsubscribeDomainEvent unsubscribeEvent = new MpUserUnsubscribeDomainEvent(this);
            DomainEvents.Add(unsubscribeEvent);
        }
    }
}
