
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;
using Newtonsoft.Json;
using Fx.Infrastructure.Utils;
using Fx.Common.Utils;
using Newtonsoft.Json.Linq;
using Fx.Amiya.Dto.DockingHospitalCustomerInfo;
using Fx.Common;
using Fx.Amiya.Dto.HospitalCustomerInfo;
using Fx.Amiya.Dto;

namespace Fx.Amiya.Service
{
    public class DockingHospitalCustomerInfoService : IDockingHospitalCustomerInfoService
    {
        private IDalDockingHospitalCustomerInfo dalDockingHospitalCustomerInfo;
        private IHospitalInfoService hospitalInfoService;
        public DockingHospitalCustomerInfoService(IDalDockingHospitalCustomerInfo dalDockingHospitalCustomerInfo, IHospitalInfoService hospitalInfoService)
        {
            this.dalDockingHospitalCustomerInfo = dalDockingHospitalCustomerInfo;
            this.hospitalInfoService = hospitalInfoService;
        }

        /// <summary>
        /// 根据医院id获取绑定证书
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task<DockingHospitalCustomerInfoDto> GetDockingHospitalInfo(int hospitalId)
        {
            var appInfo = await dalDockingHospitalCustomerInfo.GetAll().FirstOrDefaultAsync(e => e.HospitalId == hospitalId);
            if (appInfo == null)
                throw new Exception("该医院应用证书信息为空");
            DateTime date = DateTime.Now;
            if (appInfo.ExpireDate.Value <= date)
            {
                string url = $"{appInfo.BaseUrl}{appInfo.TokenUrl}?appKey={appInfo.AppKey}&appSecret={appInfo.AppSecret}";
                var res = await HttpUtil.HTTPJsonGetAsync(url);
                JObject requestObject = JsonConvert.DeserializeObject(res) as JObject;
                if (requestObject["code"].ToString() != "0")
                    throw new Exception(requestObject["msg"].ToString());
                JObject data = JsonConvert.DeserializeObject(requestObject["data"].ToString()) as JObject;
                JObject account = JsonConvert.DeserializeObject(data["account"].ToString()) as JObject;
                string token = account["token"].ToString();
                string refreshToken = account["refreshToken"].ToString();
                double expires_in = Convert.ToDouble(account["expiresIn"].ToString());
                appInfo.AccessToken = token;
                appInfo.RefreshToken = refreshToken;
                appInfo.ExpireDate = date.AddMinutes(expires_in);
                appInfo.AuthorizeDate = date;
                await dalDockingHospitalCustomerInfo.UpdateAsync(appInfo, true);
            }

            DockingHospitalCustomerInfoDto dockingHospitalCustomerInfo = new DockingHospitalCustomerInfoDto();
            dockingHospitalCustomerInfo.Id = appInfo.Id;
            dockingHospitalCustomerInfo.AppKey = appInfo.AppKey;
            dockingHospitalCustomerInfo.AppSecret = appInfo.AppSecret;
            dockingHospitalCustomerInfo.AccessToken = appInfo.AccessToken;
            dockingHospitalCustomerInfo.AuthorizeDate = appInfo.AuthorizeDate;
            dockingHospitalCustomerInfo.ExpireDate = appInfo.ExpireDate;
            dockingHospitalCustomerInfo.RefreshToken = appInfo.RefreshToken;
            dockingHospitalCustomerInfo.HospitalId = appInfo.HospitalId;
            dockingHospitalCustomerInfo.BaseUrl = appInfo.BaseUrl;
            dockingHospitalCustomerInfo.TokenUrl = appInfo.TokenUrl;
            dockingHospitalCustomerInfo.GetCustomerOrderUrl = appInfo.GetCustomerOrderUrl;
            dockingHospitalCustomerInfo.GetCustomerUrl = appInfo.GetCustomerUrl;
            dockingHospitalCustomerInfo.GetOrderUrl = appInfo.GetOrderUrl;
            return dockingHospitalCustomerInfo;
        }
        /// <summary>
        /// 根据医院id获取绑定证书
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task<DockingHospitalCustomerInfoDto> GetBeautyDiaryTokenInfo(int hospitalId)
        {
            var appInfo = await dalDockingHospitalCustomerInfo.GetAll().FirstOrDefaultAsync(e => e.HospitalId == hospitalId);
            if (appInfo == null)
                throw new Exception("美丽日记应用证书信息为空");
            DateTime date = DateTime.Now;
            if (appInfo.ExpireDate.Value <= date)
            {
                string url = $"{appInfo.BaseUrl}{appInfo.TokenUrl}?grant_type=client_credential&appid={appInfo.AppKey}&secret={appInfo.AppSecret}";
                var res = await HttpUtil.HTTPJsonGetAsync(url);
                if (res.Contains("errorcode"))
                    throw new Exception(res);
                JObject requestObject = JsonConvert.DeserializeObject(res) as JObject;
                string token = requestObject["access_token"].ToString();
                double expires_in = Convert.ToDouble(requestObject["expires_in"].ToString());
                appInfo.AccessToken = token;
                appInfo.ExpireDate = date.AddSeconds(expires_in - 400);
                appInfo.AuthorizeDate = date;
                await dalDockingHospitalCustomerInfo.UpdateAsync(appInfo, true);
            }

            DockingHospitalCustomerInfoDto dockingHospitalCustomerInfo = new DockingHospitalCustomerInfoDto();
            dockingHospitalCustomerInfo.Id = appInfo.Id;
            dockingHospitalCustomerInfo.AppKey = appInfo.AppKey;
            dockingHospitalCustomerInfo.AppSecret = appInfo.AppSecret;
            dockingHospitalCustomerInfo.AccessToken = appInfo.AccessToken;
            dockingHospitalCustomerInfo.AuthorizeDate = appInfo.AuthorizeDate;
            dockingHospitalCustomerInfo.ExpireDate = appInfo.ExpireDate;
            dockingHospitalCustomerInfo.RefreshToken = appInfo.RefreshToken;
            dockingHospitalCustomerInfo.HospitalId = appInfo.HospitalId;
            dockingHospitalCustomerInfo.BaseUrl = appInfo.BaseUrl;
            dockingHospitalCustomerInfo.TokenUrl = appInfo.TokenUrl;
            dockingHospitalCustomerInfo.GetCustomerOrderUrl = appInfo.GetCustomerOrderUrl;
            dockingHospitalCustomerInfo.GetCustomerUrl = appInfo.GetCustomerUrl;
            dockingHospitalCustomerInfo.GetOrderUrl = appInfo.GetOrderUrl;
            return dockingHospitalCustomerInfo;
        }

        public async Task<FxPageInfo<HospitalCustomerInfoDto>> GetListAsync(DateTime startDate, DateTime endDate, string customerName, string customerPhone, int hospitalId, int pageNum, int pageSize)
        {
            var dockingHospitalCustomerInfo = await this.GetDockingHospitalInfo(hospitalId);
            string url = $"{dockingHospitalCustomerInfo.BaseUrl}{dockingHospitalCustomerInfo.GetCustomerUrl}?startDate={startDate}&endDate={endDate}&customerName={customerName}&customerPhone={customerPhone}&pageNum={pageNum}&pageSize={pageSize}";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Authorization", dockingHospitalCustomerInfo.AccessToken);
            var res = await HttpUtil.HTTPJsonGetAsync(url, headers);
            JObject requestObject = JsonConvert.DeserializeObject(res) as JObject;
            if (requestObject["code"].ToString() != "0")
                throw new Exception(requestObject["msg"].ToString());
            JObject data = JsonConvert.DeserializeObject(requestObject["data"].ToString()) as JObject;
            JObject customerList = JsonConvert.DeserializeObject(data["customerList"].ToString()) as JObject;
            FxPageInfo<HospitalCustomerInfoDto> pageInfo = new FxPageInfo<HospitalCustomerInfoDto>();
            pageInfo.TotalCount = Convert.ToInt32(customerList["totalCount"].ToString());
            pageInfo.PageSize = Convert.ToInt32(customerList["pageSize"].ToString());
            pageInfo.PageCount = Convert.ToInt32(customerList["pageCount"].ToString());
            pageInfo.CurrentPageIndex = Convert.ToInt32(customerList["currentPageIndex"].ToString());
            pageInfo.List = JsonConvert.DeserializeObject<List<HospitalCustomerInfoDto>>(customerList["list"].ToString());
            return pageInfo;
        }

        public async Task<FxPageInfo<HospitalCustomerOrderInfoDto>> GetCustomerOrderListAsync(string customerId, int hospitalId, int pageNum, int pageSize)
        {
            var dockingHospitalCustomerInfo = await this.GetDockingHospitalInfo(hospitalId);
            string url = $"{dockingHospitalCustomerInfo.BaseUrl}{dockingHospitalCustomerInfo.GetCustomerOrderUrl}?customerId={customerId}&pageNum={pageNum}&pageSize={pageSize}";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Authorization", dockingHospitalCustomerInfo.AccessToken);
            var res = await HttpUtil.HTTPJsonGetAsync(url, headers);
            JObject requestObject = JsonConvert.DeserializeObject(res) as JObject;
            if (requestObject["code"].ToString() != "0")
                throw new Exception(requestObject["msg"].ToString());
            JObject data = JsonConvert.DeserializeObject(requestObject["data"].ToString()) as JObject;
            JObject customerList = JsonConvert.DeserializeObject(data["customerConsumptionRecords"].ToString()) as JObject;
            FxPageInfo<HospitalCustomerOrderInfoDto> pageInfo = new FxPageInfo<HospitalCustomerOrderInfoDto>();
            pageInfo.TotalCount = Convert.ToInt32(customerList["totalCount"].ToString());
            pageInfo.PageSize = Convert.ToInt32(customerList["pageSize"].ToString());
            pageInfo.PageCount = Convert.ToInt32(customerList["pageCount"].ToString());
            pageInfo.CurrentPageIndex = Convert.ToInt32(customerList["currentPageIndex"].ToString());
            pageInfo.List = JsonConvert.DeserializeObject<List<HospitalCustomerOrderInfoDto>>(customerList["list"].ToString());
            return pageInfo;
        }

        public async Task<FxPageInfo<HospitalCustomerOrderInfoDto>> GetOrderListAsync(DateTime startDate, DateTime endDate, string customerName, string customerPhone, int hospitalId, int pageNum, int pageSize)
        {
            var dockingHospitalCustomerInfo = await this.GetDockingHospitalInfo(hospitalId);
            string url = $"{dockingHospitalCustomerInfo.BaseUrl}{dockingHospitalCustomerInfo.GetOrderUrl}?startDate={startDate}&endDate={endDate}&customerName={customerName}&customerPhone={customerPhone}&pageNum={pageNum}&pageSize={pageSize}";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Authorization", dockingHospitalCustomerInfo.AccessToken);
            var res = await HttpUtil.HTTPJsonGetAsync(url, headers);
            JObject requestObject = JsonConvert.DeserializeObject(res) as JObject;
            if (requestObject["code"].ToString() != "0")
                throw new Exception(requestObject["msg"].ToString());
            JObject data = JsonConvert.DeserializeObject(requestObject["data"].ToString()) as JObject;
            JObject customerList = JsonConvert.DeserializeObject(data["consumptionRecords"].ToString()) as JObject;
            FxPageInfo<HospitalCustomerOrderInfoDto> pageInfo = new FxPageInfo<HospitalCustomerOrderInfoDto>();
            pageInfo.TotalCount = Convert.ToInt32(customerList["totalCount"].ToString());
            pageInfo.PageSize = Convert.ToInt32(customerList["pageSize"].ToString());
            pageInfo.PageCount = Convert.ToInt32(customerList["pageCount"].ToString());
            pageInfo.CurrentPageIndex = Convert.ToInt32(customerList["currentPageIndex"].ToString());
            pageInfo.List = JsonConvert.DeserializeObject<List<HospitalCustomerOrderInfoDto>>(customerList["list"].ToString());
            return pageInfo;
        }

        public async Task<List<BaseIdAndNameDto>> GetDockingHospitalIdAndName()
        {
            var appInfo = await dalDockingHospitalCustomerInfo.GetAll().ToListAsync();
            List<BaseIdAndNameDto> returnResult = new List<BaseIdAndNameDto>();
            foreach (var x in appInfo)
            {
                BaseIdAndNameDto baseIdAndNameDto = new BaseIdAndNameDto();
                baseIdAndNameDto.Id = x.HospitalId.ToString();
                var hospitalInfo = await hospitalInfoService.GetBaseByIdAsync(x.HospitalId);
                baseIdAndNameDto.Name = hospitalInfo.Name;
                returnResult.Add(baseIdAndNameDto);
            }

            return returnResult;
        }
        /// <summary>
        /// 获取小程序accesstoken
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task<DockingHospitalCustomerInfoDto> GetMiniProgramAccessTokenInfo(int hospitalId)
        {
            var appInfo = await dalDockingHospitalCustomerInfo.GetAll().FirstOrDefaultAsync(e => e.HospitalId == hospitalId);
            if (appInfo == null)
                throw new Exception("小程序应用证书信息为空");
            DateTime date = DateTime.Now;
            if (appInfo.ExpireDate.Value <= date)
            {
                string url = $"{appInfo.BaseUrl}{appInfo.TokenUrl}?grant_type=client_credential&appid={appInfo.AppKey}&secret={appInfo.AppSecret}";
                var res = await HttpUtil.HTTPJsonGetAsync(url);
                if (res.Contains("errorcode"))
                    throw new Exception(res);
                JObject requestObject = JsonConvert.DeserializeObject(res) as JObject;
                string token = requestObject["access_token"].ToString();
                double expires_in = Convert.ToDouble(requestObject["expires_in"].ToString());
                appInfo.AccessToken = token;
                appInfo.ExpireDate = date.AddSeconds(expires_in - 400);
                appInfo.AuthorizeDate = date;
                await dalDockingHospitalCustomerInfo.UpdateAsync(appInfo, true);
            }

            DockingHospitalCustomerInfoDto dockingHospitalCustomerInfo = new DockingHospitalCustomerInfoDto();
            dockingHospitalCustomerInfo.Id = appInfo.Id;
            dockingHospitalCustomerInfo.AppKey = appInfo.AppKey;
            dockingHospitalCustomerInfo.AppSecret = appInfo.AppSecret;
            dockingHospitalCustomerInfo.AccessToken = appInfo.AccessToken;
            dockingHospitalCustomerInfo.AuthorizeDate = appInfo.AuthorizeDate;
            dockingHospitalCustomerInfo.ExpireDate = appInfo.ExpireDate;
            dockingHospitalCustomerInfo.RefreshToken = appInfo.RefreshToken;
            dockingHospitalCustomerInfo.HospitalId = appInfo.HospitalId;
            dockingHospitalCustomerInfo.BaseUrl = appInfo.BaseUrl;
            dockingHospitalCustomerInfo.TokenUrl = appInfo.TokenUrl;
            dockingHospitalCustomerInfo.GetCustomerOrderUrl = appInfo.GetCustomerOrderUrl;
            dockingHospitalCustomerInfo.GetCustomerUrl = appInfo.GetCustomerUrl;
            dockingHospitalCustomerInfo.GetOrderUrl = appInfo.GetOrderUrl;
            return dockingHospitalCustomerInfo;
        }
    }
}
