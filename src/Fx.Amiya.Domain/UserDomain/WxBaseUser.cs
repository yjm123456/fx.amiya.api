using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Domain.UserDomain
{
    public abstract class WxBaseUser
    {
        public string Id { get; protected set; }
        public string OpenId { get; protected set; }
        public string UnionId { get; protected set; }
        public string NickName { get; protected set; }
        public byte Gender { get; protected set; }
        public string Avatar { get; protected set; }
        public string Language { get; protected set; }
        public string City { get; protected set; }
        public string Province { get; protected set; }
        public string Country { get; protected set; }
        public string AppId { get; protected set; }

        public DateTime CreateDate { get; protected set; }


        public FxUser FxUser { get; protected set; }

        public WxBaseUser()
        {

        }

        public void ChangeNickName(string nickName)
        {
            NickName = nickName;
        }
        public void ChangeCountry(string country)
        {
            Country = country;
        }

        public void ChangeCity(string city)
        {
            City = city;
        }

        public void ChangeProvince(string province)
        {
            Province = province;
        }

        public void ChangeAvatar(string avatar)
        {
            Avatar = avatar;
        }
        public void ChangeLanguage(string language)
        {
            Language = language;
        }

        public void ChangeGender(byte gender)
        {
            Gender = gender;
        }
    }
}
