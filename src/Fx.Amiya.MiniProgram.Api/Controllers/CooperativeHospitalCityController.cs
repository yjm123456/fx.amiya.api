using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.IService;
using Fx.Amiya.MiniProgram.Api.Vo.CooperativeHospitalCity;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.MiniProgram.Api.Controllers
{
    [Route("amiya/wxmini/[controller]")]
    [ApiController]
    public class CooperativeHospitalCityController : ControllerBase
    {
        private ICooperativeHospitalCityService cooperativeHospitalCityService;
        private IProvinceService _provinceService;
        public CooperativeHospitalCityController(ICooperativeHospitalCityService cooperativeHospitalCityService, IProvinceService provinceService)
        {
            this.cooperativeHospitalCityService = cooperativeHospitalCityService;
            _provinceService = provinceService;
        }

        /// <summary>
        /// 获取合作医院城市列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<List<CooperativeHospitalCityVo>>> GetListAsync()
        {
            var city = from d in await cooperativeHospitalCityService.GetValidListAsync()
                       select new CooperativeHospitalCityVo
                       {
                           Id = d.Id,
                           Name = d.Name
                       };
            return ResultData<List<CooperativeHospitalCityVo>>.Success().AddData("cityList", city.OrderBy(z => z.Name).ToList());
        }
        /// <summary>
        /// 根据商品信息获取有效的合作城市列表
        /// </summary>
        /// <param name="goodsId">商品id</param>
        /// <returns></returns>
        [HttpGet("getListByGoodsId")]
        public async Task<ResultData<List<CooperativeHospitalCityVo>>> GetListByGoodsIdAsync(string goodsId)
        {
            var city = from d in await cooperativeHospitalCityService.GetValidListByGoodsIdAsync(goodsId)
                       select new CooperativeHospitalCityVo
                       {
                           Id = d.Id,
                           Name = d.Name
                       };
            return ResultData<List<CooperativeHospitalCityVo>>.Success().AddData("cityList", city.OrderBy(z => z.Name).ToList());
        }

        /// <summary>
        /// 获取热门城市
        /// </summary>
        /// <returns></returns>

        [HttpGet("hotCity")]
        public async Task<ResultData<List<CooperativeHospitalCityVo>>> GetHotListAsync()
        {
            var city = from d in await cooperativeHospitalCityService.GetHotListAsync()
                       select new CooperativeHospitalCityVo
                       {
                           Id = d.Id,
                           Name = d.Name
                       };
            return ResultData<List<CooperativeHospitalCityVo>>.Success().AddData("cityList", city.OrderBy(z => z.Name).ToList());
        }
        /// <summary>
        /// 获取合作医院省份城市列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("provinceAndCityList")]
        public async Task<ResultData<List<ProvinceAndCityVo>>> GetProvinceAndCityListAsync()
        {

            var province = from d in await _provinceService.GetValidListAsync()
                       select new ProvinceAndCityVo
                       {
                           Id = d.Id,
                           ProvinceName = d.Name
                       };
            var result = province.OrderBy(z => z.ProvinceName).ToList();
            foreach (var x in result)
            {
                var city = from c in await cooperativeHospitalCityService.GetValidListByProvinceIdAsync(x.Id)
                           select new CooperativeHospitalCityVo
                           {
                               Id = c.Id,
                               Name = c.Name
                           };
                x.City = city.OrderBy(x => x.Name).ToList();
            }
            return ResultData<List<ProvinceAndCityVo>>.Success().AddData("cityList", result);
        }

    }
}