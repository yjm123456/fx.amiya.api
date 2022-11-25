using Fx.Amiya.Background.Api.Vo.ImproveAndRemark;
using Fx.Amiya.Dto.ImprovePlanAndRemark;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
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
    /// 提升计划
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [FxInternalOrTenantAuthroize]
    public class ImprovePlanAndRemarkController : ControllerBase
    {
        private readonly IImprovePlanAndRemarkService improvePlanAndRemarkService;

        public ImprovePlanAndRemarkController(IImprovePlanAndRemarkService improvePlanAndRemarkService)
        {
            this.improvePlanAndRemarkService = improvePlanAndRemarkService;
        }

        /// <summary>
        /// 添加机构运营分析与提升计划
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<ResultData> AddAsync(List<AddImprovePlanAndRemarkVo> addVo)
        {
            try
            {
                var first = addVo.FirstOrDefault();               
                if (first == null) {
                    throw new Exception("至少添加一条数据");
                }
                else
                {
                    await improvePlanAndRemarkService.DeleteAsync(first.IndicatorId, first.HospitalId);
                }
                var groupList = addVo.GroupBy(e => e.Type);
                foreach (var item in groupList)
                {
                    var sortList = item.Select(e => new AddImprovePlanAndRemarkVo
                    {
                        IndicatorId = e.IndicatorId,
                        HospitalId = e.HospitalId,
                        Type = e.Type,
                        Sort = e.Sort,
                        Content=e.Content,
                    }).OrderBy(e => e.Sort).ToList();
                    int sort = 1;
                    foreach (var item2 in sortList)
                    {
                        AddImprovePlanAndRemarkDto addDto = new AddImprovePlanAndRemarkDto
                        {
                            IndicatorId = item2.IndicatorId,
                            HospitalId = item2.HospitalId,
                            Type = item2.Type,
                            Sort = sort,
                            Content=item2.Content,                           
                        };
                        await improvePlanAndRemarkService.AddAsync(addDto);
                        sort++;
                    }
                }
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据指标id和医院id获取机构运营分析与提升计划
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResultData<List<object>>> GetByIdAsync(string indicatorId, int hospitalId)
        {
            try
            {
                List<object> list1 = new List<object>();                    
                var plan = await improvePlanAndRemarkService.GetImproveAndRemark(indicatorId, hospitalId);
                foreach (var item in plan)
                {
                    var list = item.Value.Select(e => new ImprovePlanAndRemarkVo
                    {                       
                        IndicatorId = e.IndicatorId,
                        HospitalId = e.HospitalId,
                        Type = e.Type,
                        Sort = e.Sort,
                        Content=e.Content,
                    }).ToList();
                    
                    list1.Add(new  { Type=item.Key,Data=list});
                }
                return ResultData<List<object>>.Success().AddData("improvePlan", list1);
            }
            catch (Exception ex)
            {
                return ResultData<List<object>>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改机构提升计划信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]       
        public async Task<ResultData> UpdateAsync(List<UpdateImprovePlanAndRemarkVo> updateVo)
        {
            try
            {
                var first = updateVo.FirstOrDefault();
                if (first == null) {
                    throw new Exception("至少添加一条数据");
                } else {
                    await improvePlanAndRemarkService.DeleteAsync(first.IndicatorId,first.HospitalId);
                }                
                var groupList = updateVo.GroupBy(e => e.Type);
                foreach (var item in groupList)
                {
                    var sortList = item.Select(e => new UpdateImprovePlanAndRemarkVo
                    {
                        IndicatorId = e.IndicatorId,
                        HospitalId = e.HospitalId,
                        Type = e.Type,
                        Sort = e.Sort,
                        Content=e.Content,
                    }).OrderBy(e => e.Sort).ToList();
                    int sort = 1;
                    foreach (var item2 in sortList)
                    {
                        UpdateImprovePlanAndRemarkDto updateDto = new UpdateImprovePlanAndRemarkDto
                        {
                            IndicatorId = item2.IndicatorId,
                            HospitalId = item2.HospitalId,
                            Type = item2.Type,
                            Sort = sort,
                            Content=item2.Content,
                        };
                        await improvePlanAndRemarkService.UpdateImproveAndRemark(updateDto);
                        sort++;
                    }
                }
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
    }
}
