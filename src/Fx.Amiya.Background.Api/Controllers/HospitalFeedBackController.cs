using Fx.Amiya.Background.Api.Vo.HospitalFeedBack;
using Fx.Amiya.Dto.HospitalFeedBack;
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
    /// 医院投诉与反馈数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class HospitalFeedBackController : ControllerBase
    {
        private IHospitalFeedBackService _hospitalFeedBackService;
        private IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hospitalFeedBackService"></param>
        public HospitalFeedBackController(IHospitalFeedBackService hospitalFeedBackService,

            IHttpContextAccessor httpContextAccessor)
        {
            _hospitalFeedBackService = hospitalFeedBackService;
            this.httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// 获取医院投诉与反馈信息列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<HospitalFeedBackVo>>> GetListWithPageAsync(DateTime? startDate, DateTime? endDate, int? hospitalId, string keyword, int pageNum, int pageSize)
        {
            try
            {
                var q = await _hospitalFeedBackService.GetListWithPageAsync(startDate, endDate, hospitalId,keyword, pageNum, pageSize);

                var hospitalFeedBack = from d in q.List
                              select new HospitalFeedBackVo
                              {
                                  Id = d.Id,
                                  Title = d.Title,
                                  Content = d.Content,
                                  Level = d.Level,
                                  CreateDate = d.CreateDate,
                                  Hospital = d.Hospital,
                              };

                FxPageInfo<HospitalFeedBackVo> hospitalFeedBackPageInfo = new FxPageInfo<HospitalFeedBackVo>();
                hospitalFeedBackPageInfo.TotalCount = q.TotalCount;
                hospitalFeedBackPageInfo.List = hospitalFeedBack;

                return ResultData<FxPageInfo<HospitalFeedBackVo>>.Success().AddData("hospitalFeedBackInfo", hospitalFeedBackPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<HospitalFeedBackVo>>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 添加医院投诉与反馈信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> AddAsync(AddHospitalFeedBackVo addVo)
        {
            try
            {
                int hospitalId = 0;
                if (httpContextAccessor.HttpContext.User is FxAmiyaHospitalEmployeeIdentity tenant)
                    hospitalId = tenant.HospitalId;

                if (hospitalId == 0)
                    throw new Exception("医院编号不能为空");
                AddHospitalFeedBackDto addDto = new AddHospitalFeedBackDto();
                addDto.Title = addVo.Title;
                addDto.Content = addVo.Content;
                addDto.Level = addVo.Level;
                addDto.CreateHospital = hospitalId;
                await _hospitalFeedBackService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据医院投诉与反馈编号获取医院投诉与反馈信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<HospitalFeedBackVo>> GetByIdAsync(string id)
        {
            try
            {
                var hospitalFeedBack = await _hospitalFeedBackService.GetByIdAsync(id);
                HospitalFeedBackVo hospitalFeedBackVo = new HospitalFeedBackVo();
                hospitalFeedBackVo.Id = hospitalFeedBack.Id;
                hospitalFeedBackVo.Title = hospitalFeedBack.Title;
                hospitalFeedBackVo.Content = hospitalFeedBack.Content;
                hospitalFeedBackVo.Level = hospitalFeedBack.Level;
                hospitalFeedBackVo.CreateHospital = hospitalFeedBack.CreateHospital;
                hospitalFeedBackVo.CreateDate = hospitalFeedBack.CreateDate;
                return ResultData<HospitalFeedBackVo>.Success().AddData("hospitalFeedBackInfo", hospitalFeedBackVo);
            }
            catch (Exception ex)
            {
                return ResultData<HospitalFeedBackVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改医院投诉与反馈信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> UpdateAsync(UpdateHospitalFeedBackVo updateVo)
        {
            try
            {
                UpdateHospitalFeedBackDto updateDto = new UpdateHospitalFeedBackDto();
                updateDto.Id = updateVo.Id;
                updateDto.Title = updateVo.Title;
                updateDto.Content = updateVo.Content;
                updateDto.Level = updateVo.Level;
                await _hospitalFeedBackService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除医院投诉与反馈信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await _hospitalFeedBackService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
