using Fx.Amiya.Background.Api.Vo.HospitalEnvironment;
using Fx.Amiya.Dto.HospitalEnvironment;
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
    /// 医院环境数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class HospitalEnvironmentController : ControllerBase
    {
        private IHospitalEnvironmentService _hospitalEnvironmentService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hospitalEnvironmentService"></param>
        public HospitalEnvironmentController(IHospitalEnvironmentService hospitalEnvironmentService)
        {
            _hospitalEnvironmentService = hospitalEnvironmentService;
        }


        /// <summary>
        /// 获取医院环境信息列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<HospitalEnvironmentVo>>> GetListWithPageAsync(string keyword, int pageNum, int pageSize)
        {
            try
            {
                var q = await _hospitalEnvironmentService.GetListWithPageAsync(keyword, pageNum, pageSize);

                var hospitalEnvironment = from d in q.List
                              select new HospitalEnvironmentVo
                              {
                                  Id = d.Id,
                                  Name = d.Name,
                                  Valid = d.Valid
                              };

                FxPageInfo<HospitalEnvironmentVo> hospitalEnvironmentPageInfo = new FxPageInfo<HospitalEnvironmentVo>();
                hospitalEnvironmentPageInfo.TotalCount = q.TotalCount;
                hospitalEnvironmentPageInfo.List = hospitalEnvironment;

                return ResultData<FxPageInfo<HospitalEnvironmentVo>>.Success().AddData("hospitalEnvironmentInfo", hospitalEnvironmentPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<HospitalEnvironmentVo>>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 获取医院环境id和名称
        /// </summary>
        /// <returns></returns>
        [HttpGet("getHospitalEnvironmentList")]
        [FxInternalOrTenantAuthroize]

        public async Task<ResultData<List<HospitalEnvironmentIdAndNameVo>>> getHospitalEnvironmentList()
        {
            try
            {
                var q = await _hospitalEnvironmentService.GetIdAndNames();

                var hospitalEnvironment = from d in q
                              select new HospitalEnvironmentIdAndNameVo
                              {
                                  Id = d.Id,
                                  Name = d.Name
                              };

                return ResultData<List<HospitalEnvironmentIdAndNameVo>>.Success().AddData("HospitalEnvironmentList", hospitalEnvironment.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<HospitalEnvironmentIdAndNameVo>>.Fail().AddData("HospitalEnvironmentList", new List<HospitalEnvironmentIdAndNameVo>());
            }
        }


        /// <summary>
        /// 添加医院环境信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        [FxInternalAuthorize]
        public async Task<ResultData> AddAsync(HospitalEnvironmentAddVo addVo)
        {
            try
            {
                HospitalEnvironmentAddDto addDto = new HospitalEnvironmentAddDto();
                addDto.Name = addVo.Name;
                addDto.Valid = addVo.Valid;

                await _hospitalEnvironmentService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据医院环境编号获取医院环境信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData<HospitalEnvironmentVo>> GetByIdAsync(string id)
        {
            try
            {
                var hospitalEnvironment = await _hospitalEnvironmentService.GetByIdAsync(id);
                HospitalEnvironmentVo hospitalEnvironmentVo = new HospitalEnvironmentVo();
                hospitalEnvironmentVo.Id = hospitalEnvironment.Id;
                hospitalEnvironmentVo.Name = hospitalEnvironment.Name;
                hospitalEnvironmentVo.Valid = hospitalEnvironment.Valid;

                return ResultData<HospitalEnvironmentVo>.Success().AddData("hospitalEnvironmentInfo", hospitalEnvironmentVo);
            }
            catch (Exception ex)
            {
                return ResultData<HospitalEnvironmentVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改医院环境信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        [FxInternalAuthorize]
        public async Task<ResultData> UpdateAsync(HospitalEnvironmentUpdateVo updateVo)
        {
            try
            {
                HospitalEnvironmentUpdateDto updateDto = new HospitalEnvironmentUpdateDto();
                updateDto.Id = updateVo.Id;
                updateDto.Name = updateVo.Name;
                updateDto.Valid = updateVo.Valid;
                await _hospitalEnvironmentService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除医院环境信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await _hospitalEnvironmentService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
