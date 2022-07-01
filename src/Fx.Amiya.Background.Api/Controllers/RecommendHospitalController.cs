using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo.RecommendHospital;
using Fx.Amiya.Dto.RecommendHospital;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Infrastructure;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 医院推荐 API
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class RecommendHospitalController : ControllerBase
    {
        private IRecommendHospitalService recommendHospitalService;
        private IHttpContextAccessor httpContextAccessor;

        public RecommendHospitalController(IRecommendHospitalService recommendHospitalService
            , IHttpContextAccessor httpContextAccessor)
        {
            this.recommendHospitalService = recommendHospitalService;
            this.httpContextAccessor = httpContextAccessor;
        }



        /// <summary>
        /// 获取推荐医院列表
        /// </summary>
        /// <param name="hospitalName"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>

        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<RecommendHospitalInfoVo>>> GetListWithPageAsync(string hospitalName, DateTime? startDate, DateTime? endDate, int pageNum, int pageSize)
        {
            try
            {
                var q = await recommendHospitalService.GetListWithPageAsync(hospitalName, startDate, endDate, pageNum, pageSize);

                var recommendHospital = from d in q.List
                                        select new RecommendHospitalInfoVo
                                        {
                                            Id = d.Id,
                                            HospitalId = d.HospitalId,
                                            HospitalName = d.HospitalName,
                                            RecommendIndex = d.RecommendIndex,
                                            StartDate = d.StartDate,
                                            EndDate = d.EndDate,
                                            Valid = d.Valid,
                                            CreateDate = d.CreateDate,
                                            CreateBy = d.CreateBy,
                                            CreateName = d.CreateName,
                                            UpdateBy = d.UpdateBy,
                                            UpdateName = d.UpdateName
                                        };

                FxPageInfo<RecommendHospitalInfoVo> recommendPageInfo = new FxPageInfo<RecommendHospitalInfoVo>();
                recommendPageInfo.TotalCount = q.TotalCount;
                recommendPageInfo.List = recommendHospital;

                return ResultData<FxPageInfo<RecommendHospitalInfoVo>>.Success().AddData("recommendHospitalInfo", recommendPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<RecommendHospitalInfoVo>>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 添加医院推荐
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddRecommendHospitalInfoVo addVo)
        {
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);

                AddRecommendHospitalInfoDto addDto = new AddRecommendHospitalInfoDto();
                addDto.HospitalId = addVo.HospitalId;
                addDto.RecommendIndex = addVo.RecommendIndex;
                addDto.StartDate = addVo.StartDate;
                addDto.EndDate = addVo.EndDate;

                await recommendHospitalService.AddAsync(addDto, employeeId);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }




        /// <summary>
        /// 根据编号获取医院推荐信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<RecommendHospitalInfoVo>> GetByIdAsync(int id)
        {
            try
            {
                var recommendHospital = await recommendHospitalService.GetByIdAsync(id);

                RecommendHospitalInfoVo recommendHospitalInfo = new RecommendHospitalInfoVo();
                recommendHospitalInfo.Id = recommendHospital.Id;
                recommendHospitalInfo.HospitalId = recommendHospital.HospitalId;
                recommendHospitalInfo.HospitalName = recommendHospital.HospitalName;
                recommendHospitalInfo.RecommendIndex = recommendHospital.RecommendIndex;
                recommendHospitalInfo.StartDate = recommendHospital.StartDate;
                recommendHospitalInfo.EndDate = recommendHospital.EndDate;
                recommendHospitalInfo.Valid = recommendHospital.Valid;
                recommendHospitalInfo.CreateDate = recommendHospital.CreateDate;
                recommendHospitalInfo.CreateBy = recommendHospital.CreateBy;
                recommendHospitalInfo.CreateName = recommendHospital.CreateName;
                recommendHospitalInfo.UpdateBy = recommendHospital.UpdateBy;
                recommendHospitalInfo.UpdateName = recommendHospital.UpdateName;

                return ResultData<RecommendHospitalInfoVo>.Success().AddData("recommendHospitalInfo", recommendHospitalInfo);
            }
            catch (Exception ex)
            {
                return ResultData<RecommendHospitalInfoVo>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 修改医院推荐信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateRecommendHospitalInfoVo updateVo)
        {
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);

                UpdateRecommendHospitalInfoDto updateDto = new UpdateRecommendHospitalInfoDto();
                updateDto.Id = updateVo.Id;
                updateDto.RecommendIndex = updateVo.RecommendIndex;
                updateDto.StartDate = updateVo.StartDate;
                updateDto.EndDate = updateVo.EndDate;
                updateDto.Valid = updateVo.Valid;

                await recommendHospitalService.UpdateAsync(updateDto, employeeId);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 医院推荐信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(int id)
        {
            try
            {
                await recommendHospitalService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
    }
}