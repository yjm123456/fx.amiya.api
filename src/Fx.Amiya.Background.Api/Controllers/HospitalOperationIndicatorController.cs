using Fx.Amiya.Background.Api.Vo.HospitalOperationIndicator;
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

        public HospitalOperationIndicatorController(
            // IGreatHospitalOperationHealthService greatHospitalOperationHealthService
            )
        {
            //this.greatHospitalOperationHealthService = greatHospitalOperationHealthService;
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
        public async Task<ResultData<FxPageInfo<HospitalOperationIndicatorVo>>> GetListWithPageAsync(string keyword, bool valid, int pageNum, int pageSize)
        {
            try
            {
                FxPageInfo<HospitalOperationIndicatorVo> fxPageInfo = new FxPageInfo<HospitalOperationIndicatorVo>();
                //  var q = await greatHospitalOperationHealthService.GetListAsync(keyword, indicatorsId);

                //var greatHospitalOperationHealth = from d in q.List
                //              select new GreatHospitalOperationHealthVo
                //              {
                //                  Id = d.Id,
                //                  ExpressCode = d.ExpressCode,
                //                  ExpressName = d.ExpressName,
                //                  Valid = d.Valid
                //              };

                List <HospitalOperationIndicatorVo> hospitalOperationIndicatorPageInfo = new List<HospitalOperationIndicatorVo>();
                HospitalOperationIndicatorVo hospitalOperationIndicatorVo = new HospitalOperationIndicatorVo {
                    Id = "1234567",
                    Name = "9月机构运营指标",
                    Describe = "运营指标",
                    StartDate = DateTime.Now.AddDays(-1),
                    EndDate=DateTime.Now.AddDays(1),
                    ExcellentHospital="优秀机构",
                    SubmitStatus=false,
                    RemarkStatus=false,
                    CreateDate= DateTime.Now.AddDays(-2),
                };
                fxPageInfo.TotalCount = 1;
                fxPageInfo.List = hospitalOperationIndicatorPageInfo;
                hospitalOperationIndicatorPageInfo.Add(hospitalOperationIndicatorVo);
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
                //AddExpressDto addDto = new AddExpressDto();
                //addDto.ExpressCode = addVo.ExpressCode;
                //addDto.ExpressName = addVo.ExpressName;
                //addDto.Valid = addVo.Valid;

                //await greatHospitalOperationHealthService.AddAsync(addDto);
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
                //var greatHospitalOperationHealth = await greatHospitalOperationHealthService.GetByIdAsync(id);
                HospitalOperationIndicatorVo hospitalOperationIndicatorVo = new HospitalOperationIndicatorVo();
                //greatHospitalOperationHealthVo.Id = greatHospitalOperationHealth.Id;
                //greatHospitalOperationHealthVo.ExpressCode = greatHospitalOperationHealth.ExpressCode;
                //greatHospitalOperationHealthVo.ExpressName = greatHospitalOperationHealth.ExpressName;
                //greatHospitalOperationHealthVo.Valid = greatHospitalOperationHealth.Valid;

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
                //UpdateExpressDto updateDto = new UpdateExpressDto();
                //updateDto.Id = updateVo.Id;
                //updateDto.ExpressName = updateVo.ExpressName;
                //updateDto.ExpressCode = updateVo.ExpressCode;
                //updateDto.Valid = updateVo.Valid;
                //await greatHospitalOperationHealthService.UpdateAsync(updateDto);
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
                //await greatHospitalOperationHealthService.DeleteAsync(id);
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
                List<IndicatorNameVo> indicatorNameList = new List<IndicatorNameVo>();
                indicatorNameList.Add(new IndicatorNameVo { 
                    Id= "1234567",
                    Name= "9月机构运营指标"
                });
                return ResultData<List<IndicatorNameVo>>.Success().AddData("indicatorNameList", indicatorNameList);
            }
            catch (Exception ex)
            {
                return ResultData<List<IndicatorNameVo>>.Fail(ex.Message);
            }
        }
    }
}
