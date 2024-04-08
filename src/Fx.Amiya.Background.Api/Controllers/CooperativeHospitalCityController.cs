using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo.CooperativeHospitalCity;
using Fx.Amiya.Dto.CooperativeHospitalCity;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Infrastructure;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.Background.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
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
        /// 获取合作医院城市列表（分页）
        /// </summary>
        /// <param name="provinceId">省份id</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<CooperativeHospitalCityVo>>> GetListWithPageAsync(string provinceId, int pageNum, int pageSize)
        {
            var q = await cooperativeHospitalCityService.GetListWithPageAsync(provinceId, pageNum, pageSize);

            var city = from d in q.List
                       select new CooperativeHospitalCityVo
                       {
                           Id = d.Id,
                           Name = d.Name,
                           Valid = d.Valid,
                           ProvinceId = d.ProvinceId,
                           ProvinceName = (d.ProvinceId != "0") ? _provinceService.GetByIdAsync(d.ProvinceId).Result.Name.ToString() : "",
                           IsHot = d.IsHot,
                           Sort = d.Sort
                       };
            FxPageInfo<CooperativeHospitalCityVo> cityPageInfo = new FxPageInfo<CooperativeHospitalCityVo>();
            cityPageInfo.TotalCount = q.TotalCount;
            cityPageInfo.List = city;
            return ResultData<FxPageInfo<CooperativeHospitalCityVo>>.Success().AddData("city", cityPageInfo);
        }

        /// <summary>
        /// 获取所有合作医院城市列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("allList")]
        public async Task<ResultData<List<CooperativeHospitalCityVo>>> GetListAsync(string name)
        {
            var citys = from d in await cooperativeHospitalCityService.GetListAsync(name, null)
                        select new CooperativeHospitalCityVo
                        {
                            Id = d.Id,
                            Name = d.Name,
                            Valid = d.Valid
                        };
            return ResultData<List<CooperativeHospitalCityVo>>.Success().AddData("citys", citys.ToList());
        }



        /// <summary>
        /// 获取有效的合作医院城市列表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("validList")]
        public async Task<ResultData<List<CooperativeHospitalCityVo>>> GetValidListAsync(string name)
        {
            var citys = from d in await cooperativeHospitalCityService.GetListAsync(name, true)
                        select new CooperativeHospitalCityVo
                        {
                            Id = d.Id,
                            Name = d.Name,
                            Valid = d.Valid,
                            Sort = d.Sort
                        };
            return ResultData<List<CooperativeHospitalCityVo>>.Success().AddData("citys", citys.ToList());
        }



        /// <summary>
        /// 添加合作医院城市
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddCooperativeHospitalCityVo addVo)
        {
            AddCooperativeHospitalCityDto addDto = new AddCooperativeHospitalCityDto();
            addDto.Name = addVo.Name;
            addDto.ProvinceId = addVo.ProvinceId;
            addDto.IsHot = addVo.IsHot;
            addDto.Sort = addVo.Sort;
            await cooperativeHospitalCityService.AddAsync(addDto);
            return ResultData.Success();
        }


        /// <summary>
        /// 根据编号获取合作医院城市
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<CooperativeHospitalCityVo>> GetByIdAsync(int id)
        {

            var city = await cooperativeHospitalCityService.GetByIdAsync(id);
            CooperativeHospitalCityVo cooperativeHospitalCityVo = new CooperativeHospitalCityVo();
            cooperativeHospitalCityVo.Id = city.Id;
            cooperativeHospitalCityVo.Name = city.Name;
            cooperativeHospitalCityVo.Valid = city.Valid;
            cooperativeHospitalCityVo.ProvinceId = city.ProvinceId;
            cooperativeHospitalCityVo.IsHot = city.IsHot;
            cooperativeHospitalCityVo.Sort = city.Sort;
            return ResultData<CooperativeHospitalCityVo>.Success().AddData("city", cooperativeHospitalCityVo);
        }

        /// <summary>
        /// 修改合作医院城市
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateCooperativeHospitalCityVo updateVo)
        {
            UpdateCooperativeHospitalCityDto updateDto = new UpdateCooperativeHospitalCityDto();
            updateDto.Id = updateVo.Id;
            updateDto.Name = updateVo.Name;
            updateDto.Valid = updateVo.Valid;
            updateDto.ProvinceId = updateVo.ProvinceId;
            updateDto.IsHot = updateVo.IsHot;
            updateDto.Sort = updateVo.Sort;
            await cooperativeHospitalCityService.UpdateAsync(updateDto);
            return ResultData.Success();
        }



        /// <summary>
        /// 删除合作医院城市
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync([FromRoute] int id)
        {
            await cooperativeHospitalCityService.DeleteAsync(id);
            return ResultData.Success();
        }
    }
}