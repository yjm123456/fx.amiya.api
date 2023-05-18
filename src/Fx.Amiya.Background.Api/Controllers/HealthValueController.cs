using Fx.Amiya.Background.Api.Vo.HealthValue;
using Fx.Amiya.Dto.HealthValue;
using Fx.Amiya.IService;
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
    /// 健康值基础数据
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class HealthValueController : ControllerBase
    {
        private IHealthValueService healthValueService;

        public HealthValueController(IHealthValueService healthValueService)
        {
            this.healthValueService = healthValueService;
        }
        /// <summary>
        /// 添加健康值
        /// </summary>
        /// <param name="addHealthValueVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddHealthValueVo addHealthValueVo) {
            AddHealthValueDto addHealthValueDto = new AddHealthValueDto();
            addHealthValueDto.Name = addHealthValueVo.Name;
            addHealthValueDto.Code = addHealthValueVo.Code;
            addHealthValueDto.Value = addHealthValueVo.Value;
            await healthValueService.AddAsync(addHealthValueDto);
            return ResultData.Success();
        }

        /// <summary>
        /// 修改健康值
        /// </summary>
        /// <param name="updateHealthValueVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateHealthValueVo updateHealthValueVo)
        {
            UpdateHealthValueDto updateHealthValueDto = new UpdateHealthValueDto();
            updateHealthValueDto.Name = updateHealthValueVo.Name;
            updateHealthValueDto.Code = updateHealthValueVo.Code;
            updateHealthValueDto.Value = updateHealthValueVo.Value;
            updateHealthValueDto.Valid = updateHealthValueVo.Valid;
            updateHealthValueDto.Id = updateHealthValueVo.Id;
            await healthValueService.UpdateAsync(updateHealthValueDto);
            return ResultData.Success();
        }
        /// <summary>
        /// 删除健康值
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ResultData> DeleteAsync(string id) {
            await healthValueService.DeleteAsync(id);
            return ResultData.Success();
        }
        /// <summary>
        /// 根据id获取健康值详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getById/{id}")]
        public async Task<ResultData<HealthValueVo>> GetByIdAsync(string id) {
            var result= await healthValueService.GetByIdAsync(id);
            HealthValueVo healthValueVo = new HealthValueVo();
            healthValueVo.Id = result.Id;
            healthValueVo.Name = result.Name;
            healthValueVo.Value = result.Value;
            healthValueVo.Code = result.Code;
            healthValueVo.Valid = result.Valid;
            return ResultData<HealthValueVo>.Success().AddData("info", healthValueVo);
        }
        /// <summary>
        /// 分页获取健康值列表
        /// </summary>
        /// <param name="keyWord">关键字</param>
        /// <param name="valid">是否有效</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<FxPageInfo<HealthValueVo>>> GetWithPageAsync(string keyWord,bool? valid,int pageNum,int pageSize) {
            var list= await healthValueService.GetListWithPageAsync(valid,keyWord,pageSize,pageNum);
            FxPageInfo<HealthValueVo> fxPageInfo = new FxPageInfo<HealthValueVo>();
            fxPageInfo.TotalCount = list.TotalCount;
            fxPageInfo.List = list.List.Select(e => new HealthValueVo
            {
                Id = e.Id,
                Name = e.Name,
                Code = e.Code,
                Value = e.Value,
                Valid = e.Valid,
            });
            return ResultData<FxPageInfo<HealthValueVo>>.Success().AddData("list", fxPageInfo);
        }


    }
}
