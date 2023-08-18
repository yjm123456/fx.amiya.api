using Fx.Amiya.Background.Api.Vo.ConsumptionLevel;
using Fx.Amiya.Dto.ConsumptionLevel;
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
    /// 消费等级数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class ConsumptionLevelController : ControllerBase
    {
        private IConsumptionLevelService _consumptionLevelService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="consumptionLevelService"></param>
        public ConsumptionLevelController(IConsumptionLevelService consumptionLevelService)
        {
            _consumptionLevelService = consumptionLevelService;
        }


        /// <summary>
        /// 获取消费等级信息列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<ConsumptionLevelVo>>> GetListWithPageAsync(string keyword, int pageNum, int pageSize)
        {
            try
            {
                var q = await _consumptionLevelService.GetListWithPageAsync(keyword, pageNum, pageSize);

                var consumptionLevel = from d in q.List
                              select new ConsumptionLevelVo
                              {
                                  Id = d.Id,
                                  Name = d.Name,
                                  MinPrice = d.MinPrice,
                                  MaxPrice = d.MaxPrice,
                                  Valid = d.Valid
                              };

                FxPageInfo<ConsumptionLevelVo> consumptionLevelPageInfo = new FxPageInfo<ConsumptionLevelVo>();
                consumptionLevelPageInfo.TotalCount = q.TotalCount;
                consumptionLevelPageInfo.List = consumptionLevel;

                return ResultData<FxPageInfo<ConsumptionLevelVo>>.Success().AddData("consumptionLevelInfo", consumptionLevelPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<ConsumptionLevelVo>>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 获取消费等级id和名称（下拉框使用）
        /// </summary>
        /// <returns></returns>
        [HttpGet("getConsumptionLevelList")]
        public async Task<ResultData<List<ConsumptionLevelIdAndNameVo>>> getConsumptionLevelList()
        {
            try
            {
                var q = await _consumptionLevelService.GetIdAndNames();

                var consumptionLevel = from d in q
                              select new ConsumptionLevelIdAndNameVo
                              {
                                  Id = d.Id,
                                  Name = d.Name
                              };

                return ResultData<List<ConsumptionLevelIdAndNameVo>>.Success().AddData("ConsumptionLevelList", consumptionLevel.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<ConsumptionLevelIdAndNameVo>>.Fail().AddData("ConsumptionLevelList", new List<ConsumptionLevelIdAndNameVo>());
            }
        }


        /// <summary>
        /// 添加消费等级信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(ConsumptionLevelAddVo addVo)
        {
            try
            {
                if (addVo.MaxPrice < addVo.MinPrice)
                    throw new Exception("最大订单总额不能小于最小订单总额");
                ConsumptionLevelAddDto addDto = new ConsumptionLevelAddDto();
                addDto.Name = addVo.Name;
                addDto.MinPrice = addVo.MinPrice;
                addDto.MaxPrice = addVo.MaxPrice;
                addDto.Valid = addVo.Valid;

                await _consumptionLevelService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据消费等级编号获取消费等级信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<ConsumptionLevelVo>> GetByIdAsync(string id)
        {
            try
            {
                var consumptionLevel = await _consumptionLevelService.GetByIdAsync(id);
                ConsumptionLevelVo consumptionLevelVo = new ConsumptionLevelVo();
                consumptionLevelVo.Id = consumptionLevel.Id;
                consumptionLevelVo.Name = consumptionLevel.Name;
                consumptionLevelVo.MinPrice = consumptionLevel.MinPrice;
                consumptionLevelVo.MaxPrice = consumptionLevel.MaxPrice;
                consumptionLevelVo.Valid = consumptionLevel.Valid;

                return ResultData<ConsumptionLevelVo>.Success().AddData("consumptionLevelInfo", consumptionLevelVo);
            }
            catch (Exception ex)
            {
                return ResultData<ConsumptionLevelVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改消费等级信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(ConsumptionLevelUpdateVo updateVo)
        {
            try
            {
                if (updateVo.MaxPrice < updateVo.MinPrice)
                    throw new Exception("最大订单总额不能小于最小订单总额");
                ConsumptionLevelUpdateDto updateDto = new ConsumptionLevelUpdateDto();
                updateDto.Id = updateVo.Id;
                updateDto.Name = updateVo.Name;
                updateDto.MinPrice = updateVo.MinPrice;
                updateDto.MaxPrice = updateVo.MaxPrice;
                updateDto.Valid = updateVo.Valid;
                await _consumptionLevelService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除消费等级信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await _consumptionLevelService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
