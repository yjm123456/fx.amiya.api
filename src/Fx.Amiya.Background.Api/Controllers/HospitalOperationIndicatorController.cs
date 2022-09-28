using Fx.Amiya.Background.Api.Vo.HospitalOperationIndicator;
using Fx.Amiya.Dto.HospitalOperationIndicator;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 机构运营指标数据
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class HospitalOperationIndicatorController : ControllerBase
    {
        private IHospitalOperationIndicatorService hospitalOperationIndicatorService;
        public HospitalOperationIndicatorController(IHospitalOperationIndicatorService hospitalOperationIndicatorService)
        {
            this.hospitalOperationIndicatorService = hospitalOperationIndicatorService;
        }


        /// <summary>
        /// 分页获取机构运营指标
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="valid">是否有效</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<HospitalOperationIndicatorVo>>> GetListWithPageAsync(string keyword, bool? valid, int pageNum, int pageSize)
        {
            try
            {
                FxPageInfo<HospitalOperationIndicatorVo> fxPageInfo = new FxPageInfo<HospitalOperationIndicatorVo>();
                var q = await hospitalOperationIndicatorService.GetListAsync(keyword, valid, pageNum, pageSize);

                var hospitalOperationIndicatorList = from d in q.List
                                                     select new HospitalOperationIndicatorVo
                                                     {
                                                         Id = d.Id,
                                                         Name = d.Name,
                                                         Describe = d.Describe,
                                                         StartDate = d.StartDate,
                                                         EndDate = d.EndDate,
                                                         ExcellentHospital = d.ExcellentHospital,
                                                         SubmitStatus = d.SubmitStatus,
                                                         RemarkStatus = d.RemarkStatus,
                                                         CreateDate = d.CreateDate,
                                                         Valid = d.Valid
                                                     };
                fxPageInfo.TotalCount = q.TotalCount;
                fxPageInfo.List = hospitalOperationIndicatorList;
                return ResultData<FxPageInfo<HospitalOperationIndicatorVo>>.Success().AddData("hospitalOperationIndicatorListInfo", fxPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<HospitalOperationIndicatorVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 添加机构指标数据
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddHospitalOperationIndicatorVo addVo)
        {
            try
            {
                AddHospitalOperationIndicatorDto addHospitalOperationIndicatorVo = new AddHospitalOperationIndicatorDto()
                {
                    Name = addVo.Name,
                    Describe = addVo.Describe,
                    StartDate = addVo.StartDate,
                    EndDate = addVo.EndDate,
                    ExcellentHospital = addVo.ExcellentHospital,
                    Valid = addVo.Valid,
                    SendHospital = addVo.IndicatorIds.Select(e => new HospitalNameListDto { HospitalId = e }).ToList()
                };
                await hospitalOperationIndicatorService.AddAsync(addHospitalOperationIndicatorVo);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据机构指标id获取指标信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<HospitalOperationIndicatorVo>> GetByIdAsync(string id)
        {
            try
            {

                HospitalOperationIndicatorVo hospitalOperationIndicatorVo = new HospitalOperationIndicatorVo();
                var info = await hospitalOperationIndicatorService.GetByIdAsync(id);
                hospitalOperationIndicatorVo.Id = info.Id;
                hospitalOperationIndicatorVo.Name = info.Name;
                hospitalOperationIndicatorVo.Describe = info.Describe;
                hospitalOperationIndicatorVo.StartDate = info.StartDate;
                hospitalOperationIndicatorVo.EndDate = info.EndDate;
                hospitalOperationIndicatorVo.ExcellentHospital = info.ExcellentHospital;
                hospitalOperationIndicatorVo.Valid = info.Valid;
                hospitalOperationIndicatorVo.SendHospital = info.SendHospital.Select(e => new HospitalNameList { HospitalId = e.HospitalId, HospitalName = e.HospitalName }).ToList();
                return ResultData<HospitalOperationIndicatorVo>.Success().AddData("hospitalOperationIndicatorInfo", hospitalOperationIndicatorVo);
            }
            catch (Exception ex)
            {
                return ResultData<HospitalOperationIndicatorVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改机构运营指标数据
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateHospitalOperationIndicatorVo updateVo)
        {
            try
            {
                UpdateHospitalOperationIndicatorDto addHospitalOperationIndicatorDto = new UpdateHospitalOperationIndicatorDto()
                {
                    Id = updateVo.Id,
                    Name = updateVo.Name,
                    Describe = updateVo.Describe,
                    StartDate = updateVo.StartDate,
                    EndDate = updateVo.EndDate,
                    ExcellentHospital = updateVo.ExcellentHospital,
                    Valid = updateVo.Valid,
                    SendHospital = updateVo.IndicatorIds.Select(e => new HospitalNameListDto { HospitalId = e }).ToList()
                };
                await hospitalOperationIndicatorService.UpdateAsync(addHospitalOperationIndicatorDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除机构运营指标
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await hospitalOperationIndicatorService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                return ResultData.Fail(ex.Message);
            }
        }
        /// <summary>
        /// 获取机构运营指标名称列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("nameList")]
        public async Task<ResultData<List<IndicatorNameVo>>> IndicatorNAmeList()
        {
            try
            {
                var list = await hospitalOperationIndicatorService.GetIndicatorListAsync();
                return ResultData<List<IndicatorNameVo>>.Success().AddData("indicatorNameList", list.Select(e => new IndicatorNameVo { Id = e.Id, Name = e.IndicatorName }).ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<IndicatorNameVo>>.Fail(ex.Message);
            }
        }
    }
}
