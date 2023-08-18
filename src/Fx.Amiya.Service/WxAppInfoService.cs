using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.WxAppInfo;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
   public class WxAppInfoService: IWxAppInfoService
    {
        private IDalWxAppInfo dalWxAppInfo;
        public WxAppInfoService(IDalWxAppInfo dalWxAppInfo)
        {
            this.dalWxAppInfo = dalWxAppInfo;
        }

        public async Task<bool> AddAsync(WxAppInfoAddDto addDto)
        {
            try
            {
                WxAppInfo model = new WxAppInfo()
                {
                    AppName = addDto.WxAppName,
                    AppSecret = addDto.WxAppSecret,
                    Description = addDto.Description,
                    GrantType = addDto.GrantType,

                    Type = addDto.Type,
                    Valid = true,
                    WxAppId = addDto.WxAppId,
                    AccountId = addDto.AccountId
                };
                await dalWxAppInfo.AddAsync(model, true);
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task EditAsync(WxAppInfoEditDto editDto)
        {
            try
            {
                var appInfo = await dalWxAppInfo.GetAll().SingleOrDefaultAsync(t => t.WxAppId == editDto.WxAppId);
                appInfo.AppSecret = editDto.WxAppSecret;
                appInfo.Description = editDto.Description;
                appInfo.AppName = editDto.WxAppName;
                appInfo.Type = editDto.Type;
                appInfo.Valid = editDto.Valid;
                appInfo.AccountId = editDto.AccountId;
                appInfo.GrantType = editDto.GrantType;

                await dalWxAppInfo.UpdateAsync(appInfo, true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<WxAppInfoDto> GetByIdAsync(string appid)
        {
            try
            {
                var appInfo = await dalWxAppInfo.GetAll().SingleOrDefaultAsync(t => t.WxAppId == appid);
                if (appInfo == null)
                    return null;
                WxAppInfoDto model = new WxAppInfoDto()
                {
                    Description = appInfo.Description,
                    GrantType = appInfo.GrantType,
                    AccountId = appInfo.AccountId,
                    Type = appInfo.Type,
                    Valid = appInfo.Valid,
                    WxAppId = appInfo.WxAppId,
                    WxAppName = appInfo.AppName,
                    WxAppSecret = appInfo.AppSecret
                };
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        public async Task<List<WxAppInfoDto>> GetWxAppInfosAsync(bool? valid)
        {
            try
            {
                IQueryable<WxAppInfo> query;
                if (valid != null)
                {
                    query = dalWxAppInfo.GetAll().Where(t => t.Valid == valid);
                }
                else
                {
                    query = dalWxAppInfo.GetAll();
                }
                var all = from t in query
                          select new WxAppInfoDto
                          {
                              Description = t.Description,
                              GrantType = t.GrantType,
                              AccountId = t.AccountId,
                              Type = t.Type,
                              Valid = t.Valid,
                              WxAppId = t.WxAppId,
                              WxAppName = t.AppName,
                              WxAppSecret = t.AppSecret
                          };

                return await all.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
