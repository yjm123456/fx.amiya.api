using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.ExpressInfo;
using Fx.Amiya.Background.Api.Vo.GreatHospitalOperationHealth;
using Fx.Amiya.Dto.GreatHospitalOperationHealth;
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
    /// 优秀机构运营健康指标板块数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class GreatHospitalOperationHealthController : ControllerBase
    {
        //private IGreatHospitalOperationHealthService greatHospitalOperationHealthService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="greatHospitalOperationHealthService"></param>
        public GreatHospitalOperationHealthController(
           // IGreatHospitalOperationHealthService greatHospitalOperationHealthService
            )
        {
            //this.greatHospitalOperationHealthService = greatHospitalOperationHealthService;
        }


        /// <summary>
        /// 获取优秀机构运营健康指标信息列表
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <param name="indicatorsId">归属指标id</param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<List<GreatHospitalOperationHealthVo>>> GetListWithPageAsync(string keyword,string indicatorsId)
        {
            try
            {
                //  var q = await greatHospitalOperationHealthService.GetListAsync(keyword, indicatorsId);

                //var greatHospitalOperationHealth = from d in q.List
                //              select new GreatHospitalOperationHealthVo
                //              {
                //                  Id = d.Id,
                //                  ExpressCode = d.ExpressCode,
                //                  ExpressName = d.ExpressName,
                //                  Valid = d.Valid
                //              };

                List<GreatHospitalOperationHealthVo> greatHospitalOperationHealthPageInfo = new List<GreatHospitalOperationHealthVo>();

                return ResultData<List<GreatHospitalOperationHealthVo>>.Success().AddData("greatHospitalOperationHealthInfo", greatHospitalOperationHealthPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<List<GreatHospitalOperationHealthVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 添加优秀机构运营健康指标信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddGreatHospitalOperationHealthVo addVo)
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
        /// 根据优秀机构运营健康指标编号获取优秀机构运营健康指标信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<GreatHospitalOperationHealthVo>> GetByIdAsync(string id)
        {
            try
            {
                //var greatHospitalOperationHealth = await greatHospitalOperationHealthService.GetByIdAsync(id);
                GreatHospitalOperationHealthVo greatHospitalOperationHealthVo = new GreatHospitalOperationHealthVo();
                //greatHospitalOperationHealthVo.Id = greatHospitalOperationHealth.Id;
                //greatHospitalOperationHealthVo.ExpressCode = greatHospitalOperationHealth.ExpressCode;
                //greatHospitalOperationHealthVo.ExpressName = greatHospitalOperationHealth.ExpressName;
                //greatHospitalOperationHealthVo.Valid = greatHospitalOperationHealth.Valid;

                return ResultData<GreatHospitalOperationHealthVo>.Success().AddData("greatHospitalOperationHealthInfo", greatHospitalOperationHealthVo);
            }
            catch (Exception ex)
            {
                return ResultData<GreatHospitalOperationHealthVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改优秀机构运营健康指标信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateGreatHospitalOperationHealthVo updateVo)
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
        /// 删除优秀机构运营健康指标信息
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

                throw ex;
            }
        }
    }
}
