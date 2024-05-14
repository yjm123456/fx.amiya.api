using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.FansMeeting.Input;
using Fx.Amiya.Background.Api.Vo.FansMeeting.Result;
using Fx.Amiya.Dto.FansMeeting.Input;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 粉丝见面会
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class FansMeetingController : ControllerBase
    {
        private IFansMeetingService fansMeetingService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fansMeetingService"></param>
        public FansMeetingController(IFansMeetingService fansMeetingService)
        {
            this.fansMeetingService = fansMeetingService;
        }



        /// <summary>
        /// 根据条件获取粉丝见面会信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<FxPageInfo<FansMeetingVo>>> GetListWithPageAsync([FromQuery] QueryFansMeetingVo query)
        {
            try
            {
                QueryFansMeetingDto queryDto = new QueryFansMeetingDto();
                queryDto.StartDate = query.StartDate;
                queryDto.EndDate = query.EndDate;
                queryDto.PageNum = query.PageNum;
                queryDto.PageSize = query.PageSize;
                queryDto.HospitalId = query.HospitalId;
                queryDto.KeyWord = query.KeyWord;
                var q = await fansMeetingService.GetListAsync(queryDto);
                var fansMeeting = from d in q.List
                                  select new FansMeetingVo
                                  {
                                      Id = d.Id,
                                      CreateDate = d.CreateDate,
                                      UpdateDate = d.UpdateDate,
                                      Valid = d.Valid,
                                      DeleteDate = d.DeleteDate,
                                      Name = d.Name,
                                      StartDate = d.StartDate,
                                      EndDate = d.EndDate,
                                      HospitalId = d.HospitalId,
                                      HospitalName = d.HospitalName,
                                  };

                FxPageInfo<FansMeetingVo> pageInfo = new FxPageInfo<FansMeetingVo>();
                pageInfo.TotalCount = q.TotalCount;
                pageInfo.List = fansMeeting;

                return ResultData<FxPageInfo<FansMeetingVo>>.Success().AddData("fansMeeting", pageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<FansMeetingVo>>.Fail(ex.Message);
            }
        }




        /// <summary>
        /// 添加粉丝见面会
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("add")]
        [FxInternalAuthorize]
        public async Task<ResultData> AddAsync(AddFansMeetingVo addVo)
        {
            try
            {
                AddFansMeetingDto addDto = new AddFansMeetingDto();
                addDto.Name = addVo.Name;
                addDto.StartDate = addVo.StartDate;
                addDto.EndDate = addVo.EndDate;
                addDto.HospitalId = addVo.HospitalId;
                addDto.BaseLiveAnchorId = addVo.BaseLiveAnchorId;
                await fansMeetingService.AddAsync(addDto);

                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 根据粉丝见面会编号获取粉丝见面会信息
        /// </summary>
        /// <param name="id">粉丝见面会编号</param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData<FansMeetingVo>> GetByIdAsync(string id)
        {
            try
            {
                var fansMeeting = await fansMeetingService.GetByIdAsync(id);
                FansMeetingVo fansMeetingVo = new FansMeetingVo();
                fansMeetingVo.Id = fansMeeting.Id;
                fansMeetingVo.CreateDate = fansMeeting.CreateDate;
                fansMeetingVo.Valid = fansMeeting.Valid;
                fansMeetingVo.Name = fansMeeting.Name;
                fansMeetingVo.StartDate = fansMeeting.StartDate;
                fansMeetingVo.EndDate = fansMeeting.EndDate;
                fansMeetingVo.HospitalId = fansMeeting.HospitalId;
                fansMeetingVo.HospitalName = fansMeeting.HospitalName;
                fansMeetingVo.BaseLiveAnchorId = fansMeeting.BaseLiveAnchorId;
                return ResultData<FansMeetingVo>.Success().AddData("fansMeeting", fansMeetingVo);
            }
            catch (Exception ex)
            {
                return ResultData<FansMeetingVo>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 修改粉丝见面会信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        [FxInternalAuthorize]
        public async Task<ResultData> UpdateAsync(UpdateFansMeetingVo updateVo)
        {
            try
            {
                UpdateFansMeetingDto updateDto = new UpdateFansMeetingDto();
                updateDto.Id = updateVo.Id;
                updateDto.Name = updateVo.Name;
                updateDto.StartDate = updateVo.StartDate;
                updateDto.EndDate = updateVo.EndDate;
                updateDto.HospitalId = updateVo.HospitalId;
                updateDto.BaseLiveAnchorId = updateVo.BaseLiveAnchorId;
                await fansMeetingService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 作废粉丝见面会
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await fansMeetingService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 获取有效的粉丝见面会信息（下拉框使用）
        /// </summary>
        /// <returns></returns>
        [HttpGet("ValidKeyAndValue")]
        [FxInternalAuthorize]
        public async Task<ResultData<List<BaseIdAndNameVo>>> GetValidByKeyAndValueAsync()
        {
            try
            {
                var q = await fansMeetingService.GetValidListAsync();
                var fansMeeting = from d in q
                                  select new BaseIdAndNameVo
                                  {
                                      Id = d.Key,
                                      Name = d.Value,
                                  };

                return ResultData<List<BaseIdAndNameVo>>.Success().AddData("fansMeeting", fansMeeting.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<BaseIdAndNameVo>>.Fail(ex.Message);
            }
        }
    }
}