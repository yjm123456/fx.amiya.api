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
    /// 商品需求数据板块接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class AmiyaGoodsDemandController : ControllerBase
    {

        private IAmiyaGoodsDemandService amiyaGoodsDemandService;
        private IAmiyaHospitalDepartmentService _amiyaHospitalDepartmentService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="amiyaGoodsDemandService"></param>
        public AmiyaGoodsDemandController(IAmiyaGoodsDemandService amiyaGoodsDemandService, IAmiyaHospitalDepartmentService amiyaHospitalDepartmentService)
        {
            this.amiyaGoodsDemandService = amiyaGoodsDemandService;
            _amiyaHospitalDepartmentService = amiyaHospitalDepartmentService;
        }

        /// <summary>
        /// 获取商品需求id和名称（下拉框使用）【可根据科室id进行筛选】
        /// </summary>
        /// <param name="hospitalDepartmentId"></param>
        /// <returns></returns>
        [HttpGet("getAmiyaGoodsDemandList")]
        public async Task<ResultData<List<BaseKeyAndValueVo>>> getAmiyaGoodsDemandList(string hospitalDepartmentId)
        {
            try
            {
                var q = await amiyaGoodsDemandService.GetIdAndNames(hospitalDepartmentId);

                var amiyaGoodsDemand = from d in q
                                       select new BaseKeyAndValueVo
                                       {
                                           Id = d.Id,
                                           Name = d.ProjectNname
                                       };

                return ResultData<List<BaseKeyAndValueVo>>.Success().AddData("AmiyaGoodsDemandList", amiyaGoodsDemand.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<BaseKeyAndValueVo>>.Fail().AddData("AmiyaGoodsDemandList", new List<BaseKeyAndValueVo>());
            }
        }
    }
}
