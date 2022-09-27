using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.ExpressInfo;
using Fx.Amiya.Background.Api.Vo.HospitalDealGoodsOperation;
using Fx.Amiya.Background.Api.Vo.HospitalDoctorOperation;
using Fx.Amiya.Background.Api.Vo.HospitalNetWorkConsulationOperationData;
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
    /// 机构成交品项分析板块数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class HospitalDealItemOperationController : ControllerBase
    {
        //private IHospitalNetWorkConsulationOperationDataService hospitalOperationDataService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hospitalOperationDataService"></param>
        public HospitalDealItemOperationController(
            // IHospitalNetWorkConsulationOperationDataService hospitalOperationDataService
            )
        {
            //this.hospitalOperationDataService = hospitalOperationDataService;
        }


        /// <summary>
        /// 获取机构成交品项分析信息列表
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <param name="indicatorsId">归属指标id</param>
        /// <returns></returns>
        [HttpGet("list")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<List<HospitalDealItemOperationVo>>> GetListAsync(string keyword, string indicatorsId)
        {
            try
            {
                //  var q = await hospitalOperationDataService.GetListAsync(keyword, indicatorsId);

                //var hospitalOperationData = from d in q.List
                //              select new HospitalDealItemOperationVo
                //              {
                //                  Id = d.Id,
                //                  ExpressCode = d.ExpressCode,
                //                  ExpressName = d.ExpressName,
                //                  Valid = d.Valid
                //              };

                List<HospitalDealItemOperationVo> hospitalOperationDataPageInfo = new List<HospitalDealItemOperationVo>();
                HospitalDealItemOperationVo re = new HospitalDealItemOperationVo();
                
                

                return ResultData<List<HospitalDealItemOperationVo>>.Success().AddData("hospitalDealItemData", hospitalOperationDataPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<List<HospitalDealItemOperationVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 添加机构成交品项分析信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [FxTenantAuthorize]
        [HttpPost]
        public async Task<ResultData> AddAsync(AddHospitalDealItemOperationVo addVo)
        {
            try
            {
                //AddExpressDto addDto = new AddExpressDto();
                //addDto.ExpressCode = addVo.ExpressCode;
                //addDto.ExpressName = addVo.ExpressName;
                //addDto.Valid = addVo.Valid;

                //await hospitalOperationDataService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据机构成交品项分析编号获取机构成交品项分析信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        [FxTenantAuthorize]
        public async Task<ResultData<HospitalDealItemOperationVo>> GetByIdAsync(string id)
        {
            try
            {
                //var hospitalOperationData = await hospitalOperationDataService.GetByIdAsync(id);
                HospitalDealItemOperationVo hospitalOperationDataVo = new HospitalDealItemOperationVo();
                //hospitalOperationDataVo.Id = hospitalOperationData.Id;
                //hospitalOperationDataVo.ExpressCode = hospitalOperationData.ExpressCode;
                //hospitalOperationDataVo.ExpressName = hospitalOperationData.ExpressName;
                //hospitalOperationDataVo.Valid = hospitalOperationData.Valid;

                return ResultData<HospitalDealItemOperationVo>.Success().AddData("hospitalDealItemOperationInfo", hospitalOperationDataVo);
            }
            catch (Exception ex)
            {
                return ResultData<HospitalDealItemOperationVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改机构成交品项分析信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        [FxTenantAuthorize]
        public async Task<ResultData> UpdateAsync(HospitalDealItemOperationVo updateVo)
        {
            try { 
            
                //UpdateExpressDto updateDto = new UpdateExpressDto();
                //updateDto.Id = updateVo.Id;
                //updateDto.ExpressName = updateVo.ExpressName;
                //updateDto.ExpressCode = updateVo.ExpressCode;
                //updateDto.Valid = updateVo.Valid;
                //await hospitalOperationDataService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除机构成交品项分析信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [FxTenantAuthorize]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                //await hospitalOperationDataService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
