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
    /// 医院科室数据板块接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class AmiyaHospitalDepartmentController : ControllerBase
    {

        private IAmiyaHospitalDepartmentService amiyaHospitalDepartmentService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="amiyaHospitalDepartmentService"></param>
        public AmiyaHospitalDepartmentController(IAmiyaHospitalDepartmentService amiyaHospitalDepartmentService)
        {
            this.amiyaHospitalDepartmentService = amiyaHospitalDepartmentService;
        }



        /// <summary>
        /// 获取医院科室id和名称（下拉框使用）
        /// </summary>
        /// <returns></returns>
        [HttpGet("getAmiyaHospitalDepartmentList")]
        public async Task<ResultData<List<BaseKeyAndValueVo>>> getAmiyaHospitalDepartmentList()
        {
            try
            {
                var q = await amiyaHospitalDepartmentService.GetIdAndNames();

                var amiyaHospitalDepartment = from d in q
                                              select new BaseKeyAndValueVo
                                              {
                                                  Id = d.Id,
                                                  Name = d.DepartmentName
                                              };

                return ResultData<List<BaseKeyAndValueVo>>.Success().AddData("AmiyaHospitalDepartmentList", amiyaHospitalDepartment.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<BaseKeyAndValueVo>>.Fail().AddData("AmiyaHospitalDepartmentList", new List<BaseKeyAndValueVo>());
            }
        }
    }
}
