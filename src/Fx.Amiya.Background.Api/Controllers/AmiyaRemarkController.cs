using Fx.Amiya.Background.Api.Vo.AmiyaRemark;
using Fx.Amiya.Background.Api.Vo.ImproveAndRemark;
using Fx.Amiya.Background.Api.Vo.Remark;
using Fx.Amiya.Dto.AmiyaRemark;
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
    /// 啊美雅批注
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [FxInternalOrTenantAuthroize]
    public class AmiyaRemarkController : ControllerBase
    {
        private readonly IAmiyaRemarkService amiyaRemarkService;

        public AmiyaRemarkController(IAmiyaRemarkService AmiyaRemarkService)
        {
            this.amiyaRemarkService = AmiyaRemarkService;
        }

        /// <summary>
        /// 添加啊美雅批注
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<ResultData> AddAsync(List<AddAmeiyaRemarkVo> addVo)
        {
            try
            {
                var first = addVo.FirstOrDefault();               
                if (first == null) {
                    throw new Exception("至少添加一条数据");
                }
                else
                {
                    await amiyaRemarkService.DeleteAsync(first.IndicatorId, first.HospitalId);
                }
                var groupList = addVo.GroupBy(e => e.Type);
                foreach (var item in groupList)
                {
                    var sortList = item.Select(e => new AddAmeiyaRemarkVo
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
                        AddAmeiyRemarkDto addDto = new AddAmeiyRemarkDto
                        {
                            IndicatorId = item2.IndicatorId,
                            HospitalId = item2.HospitalId,
                            Type = item2.Type,
                            Sort = sort,
                            Content=item2.Content,                           
                        };
                        await amiyaRemarkService.AddAsync(addDto);
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
        /// 根据指标id和医院id获取啊美雅批注
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
                Dictionary<string, List<AmeiyaRemarkVo>> dic = new Dictionary<string, List<AmeiyaRemarkVo>>();
                var plan = await amiyaRemarkService.GetImproveAndRemark(indicatorId, hospitalId);
                foreach (var item in plan)
                {
                    var list = item.Value.Select(e => new AmeiyaRemarkVo
                    {                       
                        IndicatorId = e.IndicatorId,
                        HospitalId = e.HospitalId,
                        Type = e.Type,
                        Sort = e.Sort,
                        Content=e.Content,
                    }).ToList();
                    list1.Add(new  {Type=item.Key,Data=list });                    
                }
                return ResultData<List<object>>.Success().AddData("remark", list1);
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
        public async Task<ResultData> UpdateAsync(List<UpdateAmeiyaRemarkVo> updateVo)
        {
            try
            {
                var first = updateVo.FirstOrDefault();
                if (first == null) {
                    throw new Exception("至少添加一条数据");
                } else {
                    await amiyaRemarkService.DeleteAsync(first.IndicatorId,first.HospitalId);
                }                
                var groupList = updateVo.GroupBy(e => e.Type);
                foreach (var item in groupList)
                {
                    var sortList = item.Select(e => new UpdateAmeiyaRemarkVo
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
                        UpdateAmeiyRemarkDto updateDto = new UpdateAmeiyRemarkDto
                        {
                            IndicatorId = item2.IndicatorId,
                            HospitalId = item2.HospitalId,
                            Type = item2.Type,
                            Sort = sort,
                            Content=item2.Content,
                        };
                        await amiyaRemarkService.UpdateImproveAndRemark(updateDto);
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
