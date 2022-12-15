﻿using Fx.Amiya.Domain;
using Fx.Amiya.Domain.IRepository;
using Fx.Amiya.Domain.UserDomain;
using Fx.Amiya.Dto.UserInfo;
using Fx.Amiya.Dto.WxAppConfig;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Fx.Common.Utils;
using Fx.Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class UserService : IUserService
    {
        private IDalUserInfo dalUserInfo;
        private IWxMiniUserRepository wxMiniUserRepository;
        private IUserRepository userRepository;
        private IDalWxMpUserInfo dalWxMpUserInfo;
        private IWxMpUserRepository _wxMpUserRepository;
        private IDalConfig dalConfig;
        private IDalCustomerInfo dalCustomerInfo;
        private IDalUserInfoUpdateRecord dalUserInfoUpdateRecord;
        private IDockingHospitalCustomerInfoService dockingHospitalCustomerInfoService;
        public UserService(IDalUserInfo dalUserInfo,
            IWxMiniUserRepository wxMiniUserRepository,
            IUserRepository userRepository,
            IDalWxMpUserInfo dalWxMpUserInfo,
            IWxMpUserRepository wxMpUserRepository,
            IDalConfig dalConfig,
            IDalCustomerInfo dalCustomerInfo,
            IDalUserInfoUpdateRecord dalUserInfoUpdateRecord, IDockingHospitalCustomerInfoService dockingHospitalCustomerInfoService)
        {
            this.dalUserInfo = dalUserInfo;
            this.wxMiniUserRepository = wxMiniUserRepository;
            this.userRepository = userRepository;
            this.dalWxMpUserInfo = dalWxMpUserInfo;
            _wxMpUserRepository = wxMpUserRepository;
            this.dalConfig = dalConfig;
            this.dalCustomerInfo = dalCustomerInfo;
            this.dalUserInfoUpdateRecord = dalUserInfoUpdateRecord;
            this.dockingHospitalCustomerInfoService = dockingHospitalCustomerInfoService;
        }
        public async Task<WxMiniUserDto> AddUnauthorizedWxMiniUserAsync(UnauthorizedWxMiniUserAddDto miniUserAddDto)
        {
            try
            {
                var fxUser = await userRepository.GetFxUserByUnionIdAsync(miniUserAddDto.UnionId);
                var wxMiniUser = await wxMiniUserRepository.GetByOpenIdAsync(miniUserAddDto.OpenId);
                if (wxMiniUser == null)
                {
                    wxMiniUser = new WxMiniUser
                    (
                         id: GuidUtil.NewGuidShortString(),
                         openid: miniUserAddDto.OpenId,
                         unionid: miniUserAddDto.UnionId,
                         appid: miniUserAddDto.AppId,
                         appPath: miniUserAddDto.AppPath,
                         scene: miniUserAddDto.Scene,
                         nickName: null,
                         gender: 0,
                         createDate: DateTime.Now,
                         country: null,
                         province: null,
                         city: null,
                         avatar: null,
                         language: null,
                         fxUser: fxUser
                    );
                    await wxMiniUserRepository.AddAsync(wxMiniUser);
                }


                return new WxMiniUserDto()
                {
                    Id = wxMiniUser.Id,
                    UserId = wxMiniUser.FxUser.Id,
                    CustomerId = wxMiniUser.FxUser.CustomerId,
                };
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



        public async Task<string> GetCustomerIdAsync(string fxUserId)
        {
            FxUser fxUser = await userRepository.GetByIdAsync(fxUserId);
            return fxUser.CustomerId;
        }

        public async Task<bool> UpdateUserInfoByWxMiniUserAsync(WxMiniUserEditDto miniUserEditDto)
        {
            try
            {
                var wxMiniUser = await wxMiniUserRepository.GetByOpenIdAsync(miniUserEditDto.OpenId);
                wxMiniUser.ChangeAvatar(miniUserEditDto.AvatarUrl);
                wxMiniUser.ChangeCity(miniUserEditDto.City);
                wxMiniUser.ChangeCountry(miniUserEditDto.Country);
                wxMiniUser.ChangeGender(miniUserEditDto.Gender);
                wxMiniUser.ChangeLanguage(miniUserEditDto.Language);
                wxMiniUser.ChangeNickName(miniUserEditDto.NickName);
                wxMiniUser.ChangeProvince(miniUserEditDto.Province);

                await wxMiniUserRepository.UpdateAsync(wxMiniUser);
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public async Task<bool> UpdateUserInfo(UserInfoEditDto userInfoEditDto)
        {
            try {
                var userInfo = dalUserInfo.GetAll().SingleOrDefault(e => e.Id == userInfoEditDto.Id);
                if (userInfo != null)
                {
                    userInfo.Province = userInfoEditDto.Province;
                    userInfo.City = userInfoEditDto.City;
                    userInfo.Gender = userInfoEditDto.Gender;
                    userInfo.NickName = userInfoEditDto.NickName;
                    userInfo.Name = userInfoEditDto.Name;
                    userInfo.Area = userInfoEditDto.Area;
                    userInfo.BirthDay = userInfoEditDto.BirthDay;
                    userInfo.PersonalSignature = userInfoEditDto.PersonalSignature;
                    if (!string.IsNullOrEmpty(userInfoEditDto.Avatar)) {
                        userInfo.Avatar = userInfoEditDto.Avatar;
                    }
                    await dalUserInfo.UpdateAsync(userInfo, true);
                    return true;
                }
                return false;
            }
            catch (Exception ex) {
                throw ex;
            }
        }



        public async Task<bool> UpdateUserWxBindPhoneAsync(string userId, string phone)
        {
            try
            {
                var user = await dalUserInfo.GetAll().SingleOrDefaultAsync(e => e.Id == userId);
                if (user != null)
                {
                    if (user.WxBindPhone == null || user.WxBindPhone != phone)
                    {
                        user.WxBindPhone = phone;
                        await dalUserInfo.UpdateAsync(user, true);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<WxMiniUserDto> AddAuthorizedWxMiniUserAsync(AuthorizedWxMiniUserAddDto miniUserAddDto)
        {
            try
            {

                var fxUser = await userRepository.GetFxUserByUnionIdAsync(miniUserAddDto.UnionId);
                var wxMiniUser = await wxMiniUserRepository.GetByOpenIdAsync(miniUserAddDto.OpenId);
                if (wxMiniUser == null)
                {
                    wxMiniUser = new WxMiniUser
                    (
                         id: GuidUtil.NewGuidShortString(),
                         openid: miniUserAddDto.OpenId,
                         unionid: miniUserAddDto.UnionId,
                         appid: miniUserAddDto.AppId,
                         appPath: miniUserAddDto.AppPath,
                         scene: miniUserAddDto.Scene,
                         nickName: miniUserAddDto.NickName,
                         gender: miniUserAddDto.Gender,
                         createDate: DateTime.Now,
                         country: miniUserAddDto.Country,
                         province: miniUserAddDto.Province,
                         city: miniUserAddDto.City,
                         avatar: miniUserAddDto.AvatarUrl,
                         language: miniUserAddDto.Language,
                         fxUser: fxUser
                    );
                    await wxMiniUserRepository.AddAsync(wxMiniUser);
                }


                return new WxMiniUserDto()
                {
                    Id = wxMiniUser.Id,
                    UserId = wxMiniUser.FxUser.Id,
                    CustomerId = wxMiniUser.FxUser.CustomerId,
                };

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
   
        private async Task<CallCenterConfigDto> GetCallCenterConfig()
        {
            var config = await dalConfig.GetAll().SingleOrDefaultAsync();
            return JsonConvert.DeserializeObject<WxAppConfigDto>(config.ConfigJson).CallCenterConfig;
        }
        public async Task<List<UserNickNameDto>> GetNickNameList(List<string> userIds)
        {
            try
            {
                List<UserNickNameDto> userNickNameDtos = new List<UserNickNameDto>();
                var config = await GetCallCenterConfig();
                foreach (var userid in userIds)
                {
                    var userInfo = await dalUserInfo.GetAll().SingleOrDefaultAsync(e => e.Id == userid);
                    if (userInfo == null)
                        continue;
                    var customer = await dalCustomerInfo.GetAll().SingleOrDefaultAsync(e => e.UserId == userid);
                    UserNickNameDto userNickNameDto = new UserNickNameDto();
                    if (customer != null)
                    {
                        userNickNameDto.EncryptPhone = ServiceClass.Encrypt(customer.Phone, config.PhoneEncryptKey);
                        userNickNameDto.Phone = config.EnablePhoneEncrypt == true ? ServiceClass.GetIncompletePhone(customer.Phone) : customer.Phone;
                    }
                    else
                    {
                        userNickNameDto.EncryptPhone = ServiceClass.Encrypt(userInfo?.WxBindPhone, config.PhoneEncryptKey);
                        userNickNameDto.Phone = config.EnablePhoneEncrypt == true ? ServiceClass.GetIncompletePhone(userInfo?.WxBindPhone) : userInfo?.WxBindPhone;

                    }

                    userNickNameDto.UserId = userInfo.Id;
                    userNickNameDto.NickName = userInfo.NickName;
                    userNickNameDto.Avatar = userInfo.Avatar;

                    userNickNameDtos.Add(userNickNameDto);

                }
                return userNickNameDtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> GetFxUserIdByMpUserOpenIdAsync(string openid)
        {
            return (await dalWxMpUserInfo.GetAll().SingleOrDefaultAsync(t => t.OpenId == openid))?.UserId;

        }

        public async Task<WxMpUserInfoDto> WxMpUserSubscribeAsync(WxMpUserInfoDto wxMpUserDto)
        {
            var fxUser = await userRepository.GetFxUserByUnionIdAsync(wxMpUserDto.Unionid);
            WxMpUser wxMpUser = await _wxMpUserRepository.GetByOpenIdAsync(wxMpUserDto.Openid);
            if (wxMpUser == null)
            {
                wxMpUser = new WxMpUser
                    (
                        id: GuidUtil.NewGuidShortString(),
                        openid: wxMpUserDto.Openid,
                        unionid: wxMpUserDto.Unionid,
                        appid: wxMpUserDto.AppId,
                        nickName: wxMpUserDto.Nickname,
                        gender: wxMpUserDto.Sex,
                        country: wxMpUserDto.Country,
                        province: wxMpUserDto.Province,
                        city: wxMpUserDto.City,
                        avatar: wxMpUserDto.Avatar,
                        language: wxMpUserDto.Language,
                        createDate: DateTime.Now,
                        subscribeTime: wxMpUserDto.SubscribeTime,
                        subscribeScene: wxMpUserDto.SubscribeScene,
                        subscribeCount: 0,
                        isSubscribed: wxMpUserDto.Subscribe == 1,
                        groupid: wxMpUserDto.GroupId,
                        tagidList: wxMpUserDto.TagidList,
                        qrScene: wxMpUserDto.QrScene,
                        qrSceneStr: wxMpUserDto.QrSceneStr,
                        remark: wxMpUserDto.Remark,
                        fxUser: fxUser

                    );
                wxMpUser.Subscribe();
                await _wxMpUserRepository.AddAsync(wxMpUser);

            }
            else
            {
                wxMpUser.Subscribe();
                await _wxMpUserRepository.UpdateAsync(wxMpUser);

            }
            return new WxMpUserInfoDto() { Openid = wxMpUser.OpenId, SubscribeCount = wxMpUser.SubscribeCount };

        }


        public async Task WxMpUserUnsubscribeAsync(string openid)
        {
            WxMpUser wxMpUser = await _wxMpUserRepository.GetByOpenIdAsync(openid);
            if (wxMpUser != null)
            {
                wxMpUser.Unsubscribe();
                await _wxMpUserRepository.UpdateAsync(wxMpUser);
            }
        }


        /// <summary>
        /// 根据userId获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserInfoDto> GetUserInfoByUserIdAsync(string userId)
        {
            var userInfo = await dalUserInfo.GetAll().SingleOrDefaultAsync(e => e.Id == userId);
            UserInfoDto user = new UserInfoDto();
            user.Id = userInfo.Id;
            user.CreateDate = userInfo.CreateDate;
            user.NickName = userInfo.NickName;
            user.Phone = userInfo.WxBindPhone;
            user.City = userInfo.City;
            user.Avatar = userInfo.Avatar;
            user.Province = userInfo.Province;
            user.Language = userInfo.Language;
            user.Country = userInfo.Country;
            user.UnionId = userInfo.UnionId;
            user.Gender = userInfo.Gender;
            user.Sex = sexDict[userInfo.Gender];
            user.SuperiorId = userInfo.SuperiorId;
            user.PersonalSignature = userInfo.PersonalSignature;
            user.Name = userInfo.Name;
            user.Area = userInfo.Area;
            user.BirthDay = userInfo.BirthDay;
            var userInfoUpdateRecord = await dalUserInfoUpdateRecord.GetAll().SingleOrDefaultAsync(e => e.UserId == userId);
            if (userInfoUpdateRecord == null)
            {
                user.IsAuthorizationUserInfo = true;
            }
            else
            {
                if ((DateTime.Now - userInfoUpdateRecord.LatestUpdateDate).Days > 100)
                {
                    user.IsAuthorizationUserInfo = true;
                }
                else
                {
                    user.IsAuthorizationUserInfo = false;
                }
            }

            return user;
        }
        /// <summary>
        /// 根据userid获取分享二维码
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<string> GetUserQrCode(string userId,string avatar)
        {
            var appInfo =await dockingHospitalCustomerInfoService.GetMiniProgramAccessTokenInfo(2);
            var requestUrl = $"https://api.weixin.qq.com/wxa/getwxacodeunlimit?access_token={appInfo.AccessToken}";
            var data = new { scene = userId, page = "pages/index/index", width =640, env_version= "release" };
            var res = await HttpUtil.HttpJsonPostForOriginStreamAsync(requestUrl, JsonConvert.SerializeObject(data));
            //string result = Convert.ToBase64String(res);
            var str = WxQrCodeDemo(res,avatar);
            string result = Convert.ToBase64String(str);
            return result;
        }
        /// <summary>
        /// 更换小程序码中间的logo
        /// </summary>
        /// <param name="wxQrCodePath">微信接口返回生成的小程序码路径</param>
        /// <param name="storeLogo">拼接进去的图片路径</param>
        /// <param name="savePath">保存路径</param>
        /// <returns></returns>
        private byte[] WxQrCodeDemo(Stream wxQrCodePath, string storeLogo)
        {
            MemoryStream memoryStream = new MemoryStream();
            Image mImage = Image.FromStream(wxQrCodePath);
            using (Bitmap bitmap = new Bitmap(mImage))
            {
                Rectangle rec = new Rectangle();
                rec.X = 75;
                rec.Y = 75;
                rec.Width = 10;
                rec.Height = 10;
                bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                
            }
            mImage.Dispose();
            Image regionImage = Image.FromStream(memoryStream);//模板文件
            Image addImg = Image.FromStream(GetBytesFromUrl(storeLogo));//需要拼接进去的图片
            Image lastImg = CombinImage(regionImage, addImg, 280);//拼接图片（设置固定的135px-可根据需要改）
            Bitmap lastmap = new Bitmap(lastImg);            
            var imgBytes = BitmapToBytes(lastmap);
            addImg.Dispose();
            lastmap.Dispose();
            regionImage.Dispose();
            lastImg.Dispose();
            return imgBytes;

        }
        public static Stream GetBytesFromUrl(string url)
        {
            byte[] b;
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url);
            WebResponse myResp = myReq.GetResponse();
            Stream stream = myResp.GetResponseStream();                      
            return stream;

        }

        private byte[] BitmapToBytes(Bitmap bitmap)
        {
            // 1.先将BitMap转成内存流
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Bmp);
            ms.Seek(0, SeekOrigin.Begin);
            // 2.再将内存流转成byte[]并返回
            byte[] bytes = new byte[ms.Length];
            ms.Read(bytes, 0, bytes.Length);
            ms.Dispose();
            return bytes;
        }
        /// <summary> 
        /// 根据普通矩形得到圆角矩形的路径 
        /// </summary> 
        /// <param name="rectangle">原始矩形</param> 
        /// <param name="r">半径</param> 
        /// <returns>图形路径</returns> 
        private static GraphicsPath GetRoundRectangle(Rectangle rectangle, int r)
        {
            int l = 2 * r;
            // 把圆角矩形分成八段直线、弧的组合，依次加到路径中 
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(new Point(rectangle.X + r, rectangle.Y), new Point(rectangle.Right - r, rectangle.Y));
            gp.AddArc(new Rectangle(rectangle.Right - l, rectangle.Y, l, l), 270F, 90F);

            gp.AddLine(new Point(rectangle.Right, rectangle.Y + r), new Point(rectangle.Right, rectangle.Bottom - r));
            gp.AddArc(new Rectangle(rectangle.Right - l, rectangle.Bottom - l, l, l), 0F, 90F);

            gp.AddLine(new Point(rectangle.Right - r, rectangle.Bottom), new Point(rectangle.X + r, rectangle.Bottom));
            gp.AddArc(new Rectangle(rectangle.X, rectangle.Bottom - l, l, l), 90F, 90F);

            gp.AddLine(new Point(rectangle.X, rectangle.Bottom - r), new Point(rectangle.X, rectangle.Y + r));
            gp.AddArc(new Rectangle(rectangle.X, rectangle.Y, l, l), 180F, 90F);
            return gp;
        }
        /// <summary>
        /// 获取缩小后的图片
        /// </summary>
        /// <param name="bm">要缩小的图片</param>
        /// <param name="times">要缩小的倍数</param>
        /// <returns></returns>
        private Bitmap GetSmall(Bitmap bm, double times)
        {
            int nowWidth = (int)(bm.Width / times);
            int nowHeight = (int)(bm.Height / times);
            Bitmap newbm = new Bitmap(nowWidth, nowHeight);//新建一个放大后大小的图片

            if (times >= 1 && times <= 1.1)
            {
                newbm = bm;
            }
            else
            {
                Graphics g = Graphics.FromImage(newbm);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.DrawImage(bm, new Rectangle(0, 0, nowWidth, nowHeight), new Rectangle(0, 0, bm.Width, bm.Height), GraphicsUnit.Pixel);
                g.Dispose();
            }
            return newbm;

        }



        /// <summary>
        /// 调用此函数后使此两种图片合并，类似相册，有个
        /// 背景图，中间贴自己的目标图片
        /// </summary>
        /// <param name="imgBack">粘贴的源图片</param>
        /// <param name="destImg">粘贴的目标图片</param>
        private Image CombinImage(Image imgBack, Image img, int r)
        {
            Bitmap imgMap = new Bitmap(img);
            double smallTimes = imgMap.Width/(double)r;//缩小图片倍数
            img = GetSmall(imgMap, smallTimes);//进行图片缩小
            if ((img.Width < r || img.Height < r))
            {
                if (img.Width > img.Height)
                {
                    r = img.Height;
                }
                else
                {
                    r = img.Width;
                }
            }
            //使用传入的大小
            img = CutEllipse(img, new Rectangle(0, 0, r, r), new Size(r, r));
            Graphics g = Graphics.FromImage(imgBack);
            g.DrawImage(imgBack, 0, 0, imgBack.Width, imgBack.Height);
            g.DrawImage(img, imgBack.Width / 2 - img.Width / 2, imgBack.Width / 2 - img.Width / 2, img.Width, img.Height);
            GC.Collect();
            g.Dispose();
            img.Dispose();
            return imgBack;
        }
        /// <summary>
        /// 图片处理为圆形
        /// </summary>
        /// <param name="img"></param>
        /// <param name="rec"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static Image CutEllipse(Image img, Rectangle rec, Size size)
        {
            Bitmap bitmap = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                using (TextureBrush br = new TextureBrush(img, System.Drawing.Drawing2D.WrapMode.Clamp, rec))
                {
                    br.ScaleTransform(bitmap.Width / (float)rec.Width, bitmap.Height / (float)rec.Height);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.FillEllipse(br, new Rectangle(Point.Empty, size));
                }
            }
            return bitmap;
        }
        /// <summary>
        /// 添加用户上级
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="superiorId">上级id</param>
        /// <returns></returns>
        public async Task<bool> AddSuperiorAsync(string userId, string superiorId)
        {
            if (userId.Equals(superiorId, StringComparison.OrdinalIgnoreCase)) return false;
            var userInfo =await dalUserInfo.GetAll().Where(e=>e.Id==userId).SingleOrDefaultAsync();
            var isSubordinate=await this.IsSubordinate(userId,superiorId);
            if (isSubordinate) throw new Exception("上级用户不能是下级");
            if (userInfo == null) throw new Exception("用户不存在");
            if (userInfo.SuperiorId != null) throw new Exception("已绑定其他用户");
            var superiorInfo = dalUserInfo.GetAll().Where(e=>e.Id==superiorId);
            if (superiorId == null) throw new Exception("用户不存在");
            userInfo.SuperiorId = superiorId;
            await dalUserInfo.UpdateAsync(userInfo,true);
            return true;
        }

        public async Task<FxPageInfo<SubordinateUserDto>> GetSubordinateUserListAsync(string userId, int pageNum, int pageSize)
        {
            FxPageInfo<SubordinateUserDto> fxPageInfo = new FxPageInfo<SubordinateUserDto>();
            var list= dalUserInfo.GetAll().Where(e=>e.SuperiorId==userId).Include(e=>e.CustomerInfo).Select(e=>new SubordinateUserDto { 
                NickName=e.NickName,
                AvatarUrl=e.Avatar,
                CreateDate=e.CreateDate,
                CustomerId=e.CustomerInfo.Id
            });
            fxPageInfo.TotalCount =await list.CountAsync();
            fxPageInfo.List = list.Skip((pageNum - 1) * pageSize).Take(pageSize);
            return fxPageInfo;
        }
        /// <summary>
        /// 判断一个用户是否是下级用户
        /// </summary>
        /// <param name="userId">当前用户id</param>
        /// <param name="subordinateUserId">下级用户id</param>
        /// <returns></returns>
        public async Task<bool> IsSubordinate(string userId, string subordinateUserId)
        {
            var user= await dalUserInfo.GetAll().Where(e=>e.SuperiorId==userId&&e.Id==subordinateUserId).FirstOrDefaultAsync();
            if (user == null) return false;
            return true;
        }

        Dictionary<byte, string> sexDict = new Dictionary<byte, string>()
        {
            { 0,"未知"},
            { 1,"男"},
            { 2,"女"}
        };
    }
}
