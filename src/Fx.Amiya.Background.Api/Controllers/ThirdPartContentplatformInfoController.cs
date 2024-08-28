using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.ThirdPartContentplatformInfo.Input;
using Fx.Amiya.Background.Api.Vo.ThirdPartContentplatformInfo.Result;
using Fx.Amiya.Dto.ThirdPartContentplatformInfo.Input;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 三方平台信息
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ThirdPartContentplatformInfoController : ControllerBase
    {
        private IThirdPartContentplatformInfoService thirdPartContentplatformInfoService;
        private IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="thirdPartContentplatformInfoService"></param>
        public ThirdPartContentplatformInfoController(IHttpContextAccessor httpContextAccessor, IThirdPartContentplatformInfoService thirdPartContentplatformInfoService)
        {
            this.thirdPartContentplatformInfoService = thirdPartContentplatformInfoService;
            this._httpContextAccessor = httpContextAccessor;
        }



        /// <summary>
        /// 根据条件获取三方平台信息信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<FxPageInfo<ThirdPartContentplatformInfoVo>>> GetListWithPageAsync([FromQuery] QueryThirdPartContentplatformInfoVo query)
        {
            try
            {
                QueryThirdPartContentplatformInfoDto queryDto = new QueryThirdPartContentplatformInfoDto();
                queryDto.StartDate = query.StartDate;
                queryDto.EndDate = query.EndDate;
                queryDto.PageNum = query.PageNum;
                queryDto.PageSize = query.PageSize;
                queryDto.Valid = query.Valid;
                queryDto.KeyWord = query.KeyWord;
                var q = await thirdPartContentplatformInfoService.GetListAsync(queryDto);
                var thirdPartContentplatformInfo = from d in q.List
                                  select new ThirdPartContentplatformInfoVo
                                  {
                                      Id = d.Id,
                                      CreateDate = d.CreateDate,
                                      UpdateDate = d.UpdateDate,
                                      Valid = d.Valid,
                                      DeleteDate = d.DeleteDate,
                                      Name = d.Name,
                                  };

                FxPageInfo<ThirdPartContentplatformInfoVo> pageInfo = new FxPageInfo<ThirdPartContentplatformInfoVo>();
                pageInfo.TotalCount = q.TotalCount;
                pageInfo.List = thirdPartContentplatformInfo;

                return ResultData<FxPageInfo<ThirdPartContentplatformInfoVo>>.Success().AddData("thirdPartContentplatformInfo", pageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<ThirdPartContentplatformInfoVo>>.Fail(ex.Message);
            }
        }




        /// <summary>
        /// 添加三方平台信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("add")]
        [FxInternalAuthorize]
        public async Task<ResultData> AddAsync(AddThirdPartContentplatformInfoVo addVo)
        {
            try
            {
                AddThirdPartContentplatformInfoDto addDto = new AddThirdPartContentplatformInfoDto();
                addDto.Name = addVo.Name;
                await thirdPartContentplatformInfoService.AddAsync(addDto);

                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 根据三方平台信息编号获取三方平台信息信息
        /// </summary>
        /// <param name="id">三方平台信息编号</param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData<ThirdPartContentplatformInfoVo>> GetByIdAsync(string id)
        {
            try
            {
                var thirdPartContentplatformInfo = await thirdPartContentplatformInfoService.GetByIdAsync(id);
                ThirdPartContentplatformInfoVo thirdPartContentplatformInfoVo = new ThirdPartContentplatformInfoVo();
                thirdPartContentplatformInfoVo.Id = thirdPartContentplatformInfo.Id;
                thirdPartContentplatformInfoVo.CreateDate = thirdPartContentplatformInfo.CreateDate;
                thirdPartContentplatformInfoVo.Valid = thirdPartContentplatformInfo.Valid;
                thirdPartContentplatformInfoVo.Name = thirdPartContentplatformInfo.Name;
                return ResultData<ThirdPartContentplatformInfoVo>.Success().AddData("thirdPartContentplatformInfo", thirdPartContentplatformInfoVo);
            }
            catch (Exception ex)
            {
                return ResultData<ThirdPartContentplatformInfoVo>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 修改三方平台信息信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        [FxInternalAuthorize]
        public async Task<ResultData> UpdateAsync(UpdateThirdPartContentplatformInfoVo updateVo)
        {
            try
            {
                UpdateThirdPartContentplatformInfoDto updateDto = new UpdateThirdPartContentplatformInfoDto();
                updateDto.Id = updateVo.Id;
                updateDto.Name = updateVo.Name;
                await thirdPartContentplatformInfoService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 作废三方平台信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await thirdPartContentplatformInfoService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 获取有效的三方平台信息信息（下拉框使用）
        /// </summary>
        /// <returns></returns>
        [HttpGet("ValidKeyAndValue")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<List<BaseIdAndNameVo>>> GetValidByKeyAndValueAsync()
        {
            try
            {
                var q = await thirdPartContentplatformInfoService.GetValidListAsync();
                var thirdPartContentplatformInfo = from d in q
                                  select new BaseIdAndNameVo
                                  {
                                      Id = d.Key,
                                      Name = d.Value,
                                  };

                return ResultData<List<BaseIdAndNameVo>>.Success().AddData("thirdPartContentplatformInfo", thirdPartContentplatformInfo.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<BaseIdAndNameVo>>.Fail(ex.Message);
            }
        }
    }
}