using Fx.Amiya.IService;
using Fx.Amiya.MiniProgram.Api.Filters;
using Fx.Amiya.MiniProgram.Api.Vo.GoodsDemand;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Controllers
{
    /// <summary>
    /// 项目需求接口
    /// </summary>
    [Route("amiya/wxmini/[controller]")]
    [ApiController]
    [FxAmiyaApiUserTypeAuthorization(UserType.Customer)]
    public class GoodsDemandController : ControllerBase
    {

        private IAmiyaGoodsDemandService amiyaGoodsDemandService;
        private IAmiyaHospitalDepartmentService amiyaHospitalDepartmentService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="amiyaGoodsDemandService"></param>
        public GoodsDemandController(IAmiyaGoodsDemandService amiyaGoodsDemandService, IAmiyaHospitalDepartmentService amiyaHospitalDepartmentService)
        {
            this.amiyaGoodsDemandService = amiyaGoodsDemandService;
            this.amiyaHospitalDepartmentService = amiyaHospitalDepartmentService;
        }
        /// <summary>
        /// 获取商品需求id和名称（下拉框使用）【可根据科室id进行筛选】
        /// </summary>
        /// <param name="hospitalDepartmentId"></param>
        /// <returns></returns>
        [HttpGet("getAmiyaGoodsDemandList")]
        public async Task<ResultData<List<AmiyaGoodsDemandIdAndNameVo>>> getAmiyaGoodsDemandList(string hospitalDepartmentId)
        {
            try
            {
                var q = await amiyaGoodsDemandService.GetIdAndNames(hospitalDepartmentId);

                var amiyaGoodsDemand = from d in q
                                       select new AmiyaGoodsDemandIdAndNameVo
                                       {
                                           Id = d.Id,
                                           ProjectName = d.ProjectNname
                                       };

                return ResultData<List<AmiyaGoodsDemandIdAndNameVo>>.Success().AddData("AmiyaGoodsDemandList", amiyaGoodsDemand.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<AmiyaGoodsDemandIdAndNameVo>>.Fail().AddData("AmiyaGoodsDemandList", new List<AmiyaGoodsDemandIdAndNameVo>());
            }
        }


        /// <summary>
        /// 获取医院科室id和名称（下拉框使用）
        /// </summary>
        /// <returns></returns>
        [HttpGet("getAmiyaHospitalDepartmentList")]
        public async Task<ResultData<List<AmiyaHospitalDepartmentIdAndNameVo>>> getAmiyaHospitalDepartmentList()
        {
            try
            {
                var q = await amiyaHospitalDepartmentService.GetIdAndNames();

                var amiyaHospitalDepartment = from d in q
                                              select new AmiyaHospitalDepartmentIdAndNameVo
                                              {
                                                  Id = d.Id,
                                                  DepartmentName = d.DepartmentName
                                              };

                return ResultData<List<AmiyaHospitalDepartmentIdAndNameVo>>.Success().AddData("AmiyaHospitalDepartmentList", amiyaHospitalDepartment.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<AmiyaHospitalDepartmentIdAndNameVo>>.Fail().AddData("AmiyaHospitalDepartmentList", new List<AmiyaHospitalDepartmentIdAndNameVo>());
            }
        }

        /// <summary>
        /// 获取医院科室和项目名称信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("getAmiyaHospitalDepartmentAndGoodsDemandList")]
        public async Task<ResultData<List<AmiyaHospitalDepartmentIdAndNameVo>>> getAmiyaHospitalDepartmentAndGoodsDemandList()
        {
            try
            {
                var q = await amiyaHospitalDepartmentService.GetIdAndNames();
                var k = await amiyaGoodsDemandService.GetAll();
                var amiyaHospitalDepartment = from d in q
                                              select new AmiyaHospitalDepartmentIdAndNameVo
                                              {
                                                  Id = d.Id,
                                                  DepartmentName = d.DepartmentName
                                              };
                var result = amiyaHospitalDepartment.ToList();
                foreach (var x in result)
                {
                    var res = from z in k.Where(l => l.HospitalDepartmentId == x.Id)
                              select new AmiyaGoodsDemandIdAndNameVo
                              {
                                  Id = z.Id,
                                  ProjectName = z.ProjectNname
                              };
                    x.GoodsDemandList = res.ToList();
                }
                return ResultData<List<AmiyaHospitalDepartmentIdAndNameVo>>.Success().AddData("AmiyaHospitalDepartmentList", result);
            }
            catch (Exception ex)
            {
                return ResultData<List<AmiyaHospitalDepartmentIdAndNameVo>>.Fail().AddData("AmiyaHospitalDepartmentList", new List<AmiyaHospitalDepartmentIdAndNameVo>());
            }
        }
    }
}
