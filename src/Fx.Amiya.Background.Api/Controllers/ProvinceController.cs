using Fx.Amiya.Background.Api.Vo.Province;
using Fx.Amiya.Dto.Province;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 省份管理功能接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class ProvinceController : ControllerBase
    {
        private IProvinceService _provinceService;
        public ProvinceController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }


        /// <summary>
        /// 获取省份列表（分页）
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<ProvinceVo>>> GetListWithPageAsync(int pageNum, int pageSize)
        {
            var q = await _provinceService.GetListWithPageAsync(pageNum, pageSize);

            var province = from d in q.List
                       select new ProvinceVo
                       {
                           Id = d.Id,
                           Name = d.Name,
                           Valid = d.Valid,
                       };
            FxPageInfo<ProvinceVo> provincePageInfo = new FxPageInfo<ProvinceVo>();
            provincePageInfo.TotalCount = q.TotalCount;
            provincePageInfo.List = province;
            return ResultData<FxPageInfo<ProvinceVo>>.Success().AddData("province", provincePageInfo);
        }

        /// <summary>
        /// 获取所有省份列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("allList")]
        public async Task<ResultData<List<ProvinceVo>>> GetListAsync(string name)
        {
            var provinces = from d in await _provinceService.GetListAsync(name, null)
                        select new ProvinceVo
                        {
                            Id = d.Id,
                            Name = d.Name,
                            Valid = d.Valid
                        };
            return ResultData<List<ProvinceVo>>.Success().AddData("provinces", provinces.ToList());
        }



        /// <summary>
        /// 获取有效的省份列表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("validList")]
        public async Task<ResultData<List<ProvinceVo>>> GetValidListAsync(string name)
        {
            var provinces = from d in await _provinceService.GetListAsync(name, true)
                        select new ProvinceVo
                        {
                            Id = d.Id,
                            Name = d.Name,
                            Valid = d.Valid
                        };
            return ResultData<List<ProvinceVo>>.Success().AddData("provinces", provinces.ToList());
        }



        /// <summary>
        /// 添加省份
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddProvinceVo addVo)
        {
            AddProvinceDto addDto = new AddProvinceDto();
            addDto.Name = addVo.Name;
            await _provinceService.AddAsync(addDto);
            return ResultData.Success();
        }


        /// <summary>
        /// 根据编号获取省份
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<ProvinceVo>> GetByIdAsync(string id)
        {

            var province = await _provinceService.GetByIdAsync(id);
            ProvinceVo cooperativeHospitalCityVo = new ProvinceVo();
            cooperativeHospitalCityVo.Id = province.Id;
            cooperativeHospitalCityVo.Name = province.Name;
            cooperativeHospitalCityVo.Valid = province.Valid;

            return ResultData<ProvinceVo>.Success().AddData("province", cooperativeHospitalCityVo);
        }

        /// <summary>
        /// 修改省份
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateProvinceVo updateVo)
        {
            UpdateProvinceDto updateDto = new UpdateProvinceDto();
            updateDto.Id = updateVo.Id;
            updateDto.Name = updateVo.Name;
            updateDto.Valid = updateVo.Valid;
            await _provinceService.UpdateAsync(updateDto);
            return ResultData.Success();
        }



        /// <summary>
        /// 删除省份
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync([FromRoute] string id)
        {
            await _provinceService.DeleteAsync(id);
            return ResultData.Success();
        }
    }
}
