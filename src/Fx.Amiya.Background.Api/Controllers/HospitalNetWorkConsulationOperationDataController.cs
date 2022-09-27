﻿using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.ExpressInfo;
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
    /// 机构网咨运营数据分析板块数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class HospitalNetWorkConsulationOperationDataController : ControllerBase
    {
        //private IHospitalNetWorkConsulationOperationDataService hospitalOperationDataService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hospitalOperationDataService"></param>
        public HospitalNetWorkConsulationOperationDataController(
            // IHospitalNetWorkConsulationOperationDataService hospitalOperationDataService
            )
        {
            //this.hospitalOperationDataService = hospitalOperationDataService;
        }


        /// <summary>
        /// 获取机构网咨运营数据分析信息列表
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <param name="indicatorsId">归属指标id</param>
        /// <returns></returns>
        [HttpGet("list")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<List<HospitalNetWorkConsulationOperationDataVo>>> GetListAsync(string keyword, string indicatorsId)
        {
            try
            {
                //  var q = await hospitalOperationDataService.GetListAsync(keyword, indicatorsId);

                //var hospitalOperationData = from d in q.List
                //              select new HospitalNetWorkConsulationOperationDataVo
                //              {
                //                  Id = d.Id,
                //                  ExpressCode = d.ExpressCode,
                //                  ExpressName = d.ExpressName,
                //                  Valid = d.Valid
                //              };

                List<HospitalNetWorkConsulationOperationDataVo> hospitalOperationDataPageInfo = new List<HospitalNetWorkConsulationOperationDataVo>();
                HospitalNetWorkConsulationOperationDataVo re = new HospitalNetWorkConsulationOperationDataVo();
                re.Id = "123";
                re.CreateDate = DateTime.Now;
                re.Valid = true;
                re.IndicatorId = "1aisdhjfahsujdhfhjsf";
                re.HospitalId = 1;
                re.ConsulationName = "张三";
                re.SendOrderNum = 1;
                re.NewCustomerVisitNum = 1;
                re.NewCustomerVisitRate = 100;
                hospitalOperationDataPageInfo.Add(re);

                HospitalNetWorkConsulationOperationDataVo re2 = new HospitalNetWorkConsulationOperationDataVo();
                re2.Id = "124";
                re2.CreateDate = DateTime.Now;
                re2.Valid = true;
                re2.IndicatorId = "pojkiojoijoasnd";
                re2.HospitalId = 1;
                re2.ConsulationName = "李四";
                re2.SendOrderNum = 2;
                re2.NewCustomerVisitNum = 1;
                re2.NewCustomerVisitRate = 50;
                hospitalOperationDataPageInfo.Add(re2);

                return ResultData<List<HospitalNetWorkConsulationOperationDataVo>>.Success().AddData("hospitalOperationDataInfo", hospitalOperationDataPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<List<HospitalNetWorkConsulationOperationDataVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 添加机构网咨运营数据分析信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [FxTenantAuthorize]
        [HttpPost]
        public async Task<ResultData> AddAsync(AddHospitalNetWorkConsulationOperationDataVo addVo)
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
        /// 根据机构网咨运营数据分析编号获取机构网咨运营数据分析信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        [FxTenantAuthorize]
        public async Task<ResultData<HospitalNetWorkConsulationOperationDataVo>> GetByIdAsync(string id)
        {
            try
            {
                //var hospitalOperationData = await hospitalOperationDataService.GetByIdAsync(id);
                HospitalNetWorkConsulationOperationDataVo hospitalOperationDataVo = new HospitalNetWorkConsulationOperationDataVo();
                //hospitalOperationDataVo.Id = hospitalOperationData.Id;
                //hospitalOperationDataVo.ExpressCode = hospitalOperationData.ExpressCode;
                //hospitalOperationDataVo.ExpressName = hospitalOperationData.ExpressName;
                //hospitalOperationDataVo.Valid = hospitalOperationData.Valid;

                return ResultData<HospitalNetWorkConsulationOperationDataVo>.Success().AddData("hospitalOperationDataInfo", hospitalOperationDataVo);
            }
            catch (Exception ex)
            {
                return ResultData<HospitalNetWorkConsulationOperationDataVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改机构网咨运营数据分析信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        [FxTenantAuthorize]
        public async Task<ResultData> UpdateAsync(UpdateHospitalNetWorkConsulationOperationDataVo updateVo)
        {
            try
            {
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
        /// 删除机构网咨运营数据分析信息
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
