using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.IService;
using Fx.Amiya.Partner.Api.Vo.Hospital;
using Fx.Infrastructure;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.Partner.Api.Controllers
{
    [Route("partner/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private IHospitalEmployeeService hospitalEmployeeService;
        private IHospitalInfoService hospitalInfoService;
        public HospitalController(IHospitalEmployeeService hospitalEmployeeService,
            IHospitalInfoService hospitalInfoService)
        {
            this.hospitalEmployeeService = hospitalEmployeeService;
            this.hospitalInfoService = hospitalInfoService;
        }


        /// <summary>
        /// 获取医院信息列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("infoListWithPage")]
        public async Task<ResultData<FxPageInfo<HospitalInfoVo>>> GetInfoListWithPageAsync(string keyword, int pageNum, int pageSize)
        {
            var q = await hospitalInfoService.GetListWithPageAsync(keyword, pageNum, pageSize, true);
            var hospital = from d in q.List
                           select new HospitalInfoVo
                           {
                               Id = d.Id,
                               Name = d.Name,
                               Address = d.Address,
                               Longitude = d.Longitude,
                               Latitude = d.Latitude,
                               Phone = d.Phone,
                               Valid = d.Valid,
                               ThumbPicUrl = d.ThumbPicUrl
                           };
            FxPageInfo<HospitalInfoVo> hospitalPageInfo = new FxPageInfo<HospitalInfoVo>();
            hospitalPageInfo.TotalCount = q.TotalCount;
            hospitalPageInfo.List = hospital;
            return ResultData<FxPageInfo<HospitalInfoVo>>.Success().AddData("hospitalInfo", hospitalPageInfo);
        }


        /// <summary>
        /// 根据医院编号获取医院信息
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        [HttpGet("byId/{hospitalId}")]
        public async Task<ResultData<HospitalInfoVo>> GetBaseByIdAsync(int hospitalId)
        {
            var hospital = await hospitalInfoService.GetBaseByIdAsync(hospitalId);
            HospitalInfoVo hospitalInfoVo = new HospitalInfoVo();
            hospitalInfoVo.Id = hospital.Id;
            hospitalInfoVo.Name = hospital.Name;
            hospitalInfoVo.ThumbPicUrl = hospital.ThumbPicUrl;
            hospitalInfoVo.Address = hospital.Address;
            hospitalInfoVo.Longitude = hospital.Longitude;
            hospitalInfoVo.Latitude = hospital.Latitude;
            hospitalInfoVo.Phone = hospital.Phone;
            hospitalInfoVo.Valid = hospital.Valid;

            return ResultData<HospitalInfoVo>.Success().AddData("hospitalInfo",hospitalInfoVo);
        }


        /// <summary>
        /// 获取医院账户列表
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("accountListWithPage")]
        public async Task<ResultData<FxPageInfo<HospitalAccountVo>>> GetAccountListWithPageAsync(int? hospitalId, string keyword, int pageNum, int pageSize)
        {
            var q = await hospitalEmployeeService.GetListWithPageAsync(hospitalId, keyword, pageNum, pageSize,true);
            var hospitalAccount = from d in q.List
                                  select new HospitalAccountVo
                                  {
                                      Id = d.Id,
                                      Name = d.Name,
                                      UserName = d.UserName,
                                      Valid = d.Valid,
                                      HospitalId = d.HospitalId,
                                      HospitalName = d.HospitalName,
                                      IsCreateSubAccount = d.IsCreateSubAccount,
                                      HospitalPositionId = d.HospitalPositionId,
                                      HospitalPositionName = d.HospitalPositionName,
                                      IsCustomerService = d.IsCustomerService,
                                  };

            FxPageInfo<HospitalAccountVo> accountPageInfo = new FxPageInfo<HospitalAccountVo>();
            accountPageInfo.TotalCount = q.TotalCount;
            accountPageInfo.List = hospitalAccount;
            return ResultData<FxPageInfo<HospitalAccountVo>>.Success().AddData("hospitalAccount",accountPageInfo);
        }
    }
}