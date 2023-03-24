using Fx.Amiya.BusinessWechat.Api.Vo.Login;
using Fx.Amiya.Common;
using Fx.Amiya.IService;
using Fx.Authentication.Jwt;
using Fx.Identity.Core;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Fx.Common.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Core.Interfaces.MemberCard;
using Fx.Amiya.Core.Interfaces.Integration;
using Fx.Authorization.Attributes;
using Fx.Amiya.BusinessWeChat.Api.Vo.CustomerInfo;
using Fx.Amiya.BusinessWeChat.Api.Vo.Base;

namespace Fx.Amiya.BusinessWechat.Api.Controllers
{
    /// <summary>
    /// 医院数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class HospitalInfoController : ControllerBase
    {

        private IHospitalInfoService hospitalInfoService;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hospitalInfoService"></param>
        public HospitalInfoController(IHospitalInfoService hospitalInfoService)
        {
            this.hospitalInfoService = hospitalInfoService;
        }



        /// <summary>
        /// 获取有效医院名称列表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("nameList")]
        public async Task<ResultData<List<BaseKeyAndValueVo>>> GetHospitalNameListAsync(string name)
        {
            try
            {
                var hospital = from d in await hospitalInfoService.GetHospitalNameListAsync(true, name)
                               select new BaseKeyAndValueVo
                               {
                                   Id = d.Id.ToString(),
                                   Name = d.Name
                               };

                return ResultData<List<BaseKeyAndValueVo>>.Success().AddData("hospitalInfo", hospital.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<BaseKeyAndValueVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取有效医院简称列表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("simpleNameList")]
        public async Task<ResultData<List<BaseKeyAndValueVo>>> GetHospitalSimpleNameListAsync()
        {
            try
            {
                var hospital = from d in await hospitalInfoService.GetHospitalSimpleNameListAsync(true)
                               select new BaseKeyAndValueVo
                               {
                                   Id = d.Id.ToString(),
                                   Name = d.Name
                               };

                return ResultData<List<BaseKeyAndValueVo>>.Success().AddData("simpleNameList", hospital.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<BaseKeyAndValueVo>>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 获取资料审核通过医院名称列表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("checkPassedNameList")]
        public async Task<ResultData<List<BaseKeyAndValueVo>>> GetCheckPassedNameListAsync(string name)
        {
            try
            {
                var hospital = from d in await hospitalInfoService.GetCheckPassedHospitalNameListAsync(null, name)
                               select new BaseKeyAndValueVo
                               {
                                   Id = d.Id.ToString(),
                                   Name = d.Name
                               };

                return ResultData<List<BaseKeyAndValueVo>>.Success().AddData("hospitalInfo", hospital.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<BaseKeyAndValueVo>>.Fail(ex.Message);
            }
        }
    }
}
