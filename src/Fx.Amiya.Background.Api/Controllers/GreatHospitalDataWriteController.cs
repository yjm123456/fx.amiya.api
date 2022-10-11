using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.ExpressInfo;
using Fx.Amiya.Background.Api.Vo.GreatHospitalDataWrite;
using Fx.Amiya.Dto.GreatHospitalDataWrite;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using jos_sdk_net.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 优秀机构数据填报板块数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class GreatHospitalDataWriteController : ControllerBase
    {
        private IGreatHospitalDataWriteService greatHospitalDataWriteService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="greatHospitalDataWriteService"></param>
        public GreatHospitalDataWriteController(
            IGreatHospitalDataWriteService greatHospitalDataWriteService
            )
        {
            this.greatHospitalDataWriteService = greatHospitalDataWriteService;
        }


        /// <summary>
        /// 获取优秀机构数据填报信息列表
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <param name="indicatorsId">归属指标id</param>
        /// <returns></returns>
        [HttpGet("list")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<List<GreatHospitalDataWriteVo>>> GetListAsync(string keyword, string indicatorsId)
        {
            try
            {
                var q = await greatHospitalDataWriteService.GetListAsync(keyword, indicatorsId);

                var greatHospitalDataWrite = from d in q
                                             select new GreatHospitalDataWriteVo
                                             {
                                                 Id = d.Id,
                                                 IndicatorId = d.IndicatorId,
                                                 IndicatorName = d.IndicatorName,
                                                 GreatHospitalName = d.GreatHospitalName,
                                                 OperationName = d.OperationName,
                                                 OperationValue = d.OperationValue,
                                             };

                List<GreatHospitalDataWriteVo> greatHospitalDataWriteResult = new List<GreatHospitalDataWriteVo>();
                greatHospitalDataWriteResult = greatHospitalDataWrite.ToList();
                return ResultData<List<GreatHospitalDataWriteVo>>.Success().AddData("greatHospitalDataWriteInfo", greatHospitalDataWriteResult);
            }
            catch (Exception ex)
            {
                return ResultData<List<GreatHospitalDataWriteVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 添加优秀机构数据填报信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [FxInternalAuthorize]
        [HttpPost]
        public async Task<ResultData> AddAsync(List<AddGreatHospitalDataWriteVo> addVo)
        {
            try
            {
                List<AddGreatHospitalDataWriteDto> addList = new List<AddGreatHospitalDataWriteDto>();
                foreach (var x in addVo)
                {

                    AddGreatHospitalDataWriteDto addDto = new AddGreatHospitalDataWriteDto();
                    addDto.IndicatorId = x.IndicatorId;
                    addDto.OperationValue = x.OperationValue;
                    addDto.OperationName = x.OperationName;
                    addList.Add(addDto);
                }

                await greatHospitalDataWriteService.AddAsync(addList);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据优秀机构数据填报编号获取优秀机构数据填报信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData<GreatHospitalDataWriteVo>> GetByIdAsync(string id)
        {
            try
            {
                var greatHospitalDataWrite = await greatHospitalDataWriteService.GetByIdAsync(id);
                GreatHospitalDataWriteVo greatHospitalDataWriteVo = new GreatHospitalDataWriteVo();
                greatHospitalDataWriteVo.Id = greatHospitalDataWrite.Id;
                greatHospitalDataWriteVo.CreateDate = greatHospitalDataWrite.CreateDate;
                greatHospitalDataWriteVo.UpdateDate = greatHospitalDataWrite.UpdateDate;
                greatHospitalDataWriteVo.DeleteDate = greatHospitalDataWrite.DeleteDate;
                greatHospitalDataWriteVo.Valid = greatHospitalDataWrite.Valid;
                greatHospitalDataWriteVo.IndicatorId = greatHospitalDataWrite.IndicatorId;
                greatHospitalDataWriteVo.OperationValue = greatHospitalDataWrite.OperationValue;
                greatHospitalDataWriteVo.OperationName = greatHospitalDataWrite.OperationName;

                return ResultData<GreatHospitalDataWriteVo>.Success().AddData("greatHospitalDataWriteInfo", greatHospitalDataWriteVo);
            }
            catch (Exception ex)
            {
                return ResultData<GreatHospitalDataWriteVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改优秀机构数据填报信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        [FxInternalAuthorize]
        public async Task<ResultData> UpdateAsync(UpdateGreatHospitalDataWriteVo updateVo)
        {
            try
            {
                UpdateGreatHospitalDataWriteDto updateDto = new UpdateGreatHospitalDataWriteDto();
                updateDto.Id = updateVo.Id;
                updateDto.IndicatorId = updateVo.IndicatorId;
                updateDto.OperationValue = updateVo.OperationValue;
                updateDto.OperationName = updateVo.OperationName;
                await greatHospitalDataWriteService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除优秀机构数据填报信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await greatHospitalDataWriteService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
