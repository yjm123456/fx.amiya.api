using System;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo.HospitalContentplatformCode.Input;
using Fx.Amiya.Background.Api.Vo.HospitalContentplatformCode.Result;
using Fx.Amiya.Background.Api.Vo.ThirdPartContentplatformInfo.Input;
using Fx.Amiya.Dto.HospitalContentplatformCode.Input;
using Fx.Amiya.Dto.OperationLog;
using Fx.Amiya.IService;
using Fx.Amiya.Service;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Common.Utils;
using Fx.Open.Infrastructure.Web;
using Jd.Api.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 三方平台医院编码
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class HospitalContentplatformCodeController : ControllerBase
    {
        private IHospitalContentplatformCodeService hospitalContentplatformCodeService;
        private readonly IContentPlateFormOrderService contentPlateFormOrderService;
        private readonly ICustomerService customerService;
        private readonly IWxAppConfigService _wxAppConfigService;
        private IHttpContextAccessor _httpContextAccessor;
        private IPermissionService permissionService;
        private IOperationLogService operationLogService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hospitalContentplatformCodeService"></param>
        /// <param name="contentPlateFormOrderService"></param>
        /// <param name="customerService"></param>
        /// <param name="wxAppConfigService"></param>
        public HospitalContentplatformCodeController(IHospitalContentplatformCodeService hospitalContentplatformCodeService, IContentPlateFormOrderService contentPlateFormOrderService, ICustomerService customerService, IHttpContextAccessor httpContextAccessor, IPermissionService permissionService, IWxAppConfigService wxAppConfigService, IOperationLogService operationLogService)
        {
            this.hospitalContentplatformCodeService = hospitalContentplatformCodeService;
            this.contentPlateFormOrderService = contentPlateFormOrderService;
            this.customerService = customerService;
            this._wxAppConfigService = wxAppConfigService;
            this._httpContextAccessor = httpContextAccessor;
            this.permissionService = permissionService;
            this.operationLogService = operationLogService;
        }

        /// <summary>
        /// 管理端根据条件获取三方平台医院编码信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<FxPageInfo<HospitalContentplatformCodeVo>>> GetListWithPageAsync([FromQuery] QueryHospitalContentplatformCodeVo query)
        {
            try
            {
                QueryHospitalContentplatformCodeDto queryDto = new QueryHospitalContentplatformCodeDto();
                queryDto.StartDate = query.StartDate;
                queryDto.EndDate = query.EndDate;
                queryDto.PageNum = query.PageNum;
                queryDto.KeyWord = query.KeyWord;
                queryDto.PageSize = query.PageSize;


                queryDto.ThirdPartContentplatformInfoId = query.ThirdPartContentplatformInfoId;
                queryDto.HospitalId = query.HospitalId;
                var q = await hospitalContentplatformCodeService.GetListAsync(queryDto);
                var hospitalContentplatformCode = from d in q.List
                                                  select new HospitalContentplatformCodeVo
                                                  {
                                                      Id = d.Id,
                                                      CreateDate = d.CreateDate,
                                                      UpdateDate = d.UpdateDate,
                                                      Valid = d.Valid,
                                                      DeleteDate = d.DeleteDate,
                                                      ThirdPartContentplatformInfoId = d.ThirdPartContentplatformInfoId,
                                                      ThirdPartContentplatformInfoName = d.ThirdPartContentplatformInfoName,
                                                      HospitalId = d.HospitalId,
                                                      HospitalName = d.HospitalName,
                                                  };

                FxPageInfo<HospitalContentplatformCodeVo> pageInfo = new FxPageInfo<HospitalContentplatformCodeVo>();
                pageInfo.TotalCount = q.TotalCount;
                pageInfo.List = hospitalContentplatformCode;

                return ResultData<FxPageInfo<HospitalContentplatformCodeVo>>.Success().AddData("hospitalContentplatformCode", pageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<HospitalContentplatformCodeVo>>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 添加三方平台医院编码
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("add")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> AddAsync(AddHospitalContentplatformCodeVo addVo)
        {

            try
            {
                AddHospitalContentplatformCodeDto addDto = new AddHospitalContentplatformCodeDto();
                addDto.HospitalId = addVo.HospitalId;
                addDto.ThirdPartContentplatformInfoId = addVo.ThirdPartContentplatformInfoId;
                addDto.Code = addVo.Code;
                await hospitalContentplatformCodeService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 根据三方平台医院编码编号获取三方平台医院编码信息
        /// </summary>
        /// <param name="id">三方平台医院编码编号</param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<HospitalContentplatformCodeVo>> GetByIdAsync(string id)
        {
            try
            {
                var hospitalContentplatformCode = await hospitalContentplatformCodeService.GetByIdAsync(id);
                HospitalContentplatformCodeVo hospitalContentplatformCodeVo = new HospitalContentplatformCodeVo();
                hospitalContentplatformCodeVo.Id = hospitalContentplatformCode.Id;
                hospitalContentplatformCodeVo.CreateDate = hospitalContentplatformCode.CreateDate;
                hospitalContentplatformCodeVo.Valid = hospitalContentplatformCode.Valid;
                hospitalContentplatformCodeVo.HospitalId = hospitalContentplatformCode.HospitalId;
                hospitalContentplatformCodeVo.HospitalName = hospitalContentplatformCode.HospitalName;
                hospitalContentplatformCodeVo.ThirdPartContentplatformInfoId = hospitalContentplatformCode.ThirdPartContentplatformInfoId;
                hospitalContentplatformCodeVo.ThirdPartContentplatformInfoName = hospitalContentplatformCode.ThirdPartContentplatformInfoName;
                hospitalContentplatformCodeVo.Code = hospitalContentplatformCode.Code;
                return ResultData<HospitalContentplatformCodeVo>.Success().AddData("hospitalContentplatformCode", hospitalContentplatformCodeVo);
            }
            catch (Exception ex)
            {
                return ResultData<HospitalContentplatformCodeVo>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 修改三方平台医院编码信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> UpdateAsync(UpdateHospitalContentplatformCodeVo updateVo)
        {
            try
            {
                UpdateHospitalContentplatformCodeDto updateDto = new UpdateHospitalContentplatformCodeDto();
                updateDto.Id = updateVo.Id;
                updateDto.HospitalId = updateVo.HospitalId;
                updateDto.ThirdPartContentplatformInfoId = updateVo.ThirdPartContentplatformInfoId;
                updateDto.Code = updateVo.Code;
                await hospitalContentplatformCodeService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 作废三方平台医院编码
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int empId = Convert.ToInt32(employee.Id);
                await hospitalContentplatformCodeService.DeleteAsync(id, empId);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 管理端根据医院id和三方平台id进行查重-朗姿
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("getIsRepeateByHospitalIdAndThirdPartIdToLangZi")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<ThirdPartContentPlatformInfoToLangZiResultVo>> GetIsRepeateByHospitalIdAndThirdPartIdToLangZiAsync([FromQuery] QueryIsRepeateByHospitalIdAndThirdPartIdVo query)
        {
            try
            {
                var url = "https://ymp9.lancygroup.com/out/PIC_1019/210";
                QuerySendOrderDataByLangZiVo queryData = new QuerySendOrderDataByLangZiVo();
                queryData.FWSID = "E-31-31446";
                queryData.USERID = "INTAMY";
                var hospitalContentPlatformCode = await hospitalContentplatformCodeService.GetByHospitalIdAndThirdPartContentPlatformIdAsync(query.HospitalId, query.ThirdPartContentplatformInfoId);
                queryData.JGBM = hospitalContentPlatformCode.Code;
                var data = JsonConvert.SerializeObject(queryData);
                var getResult = await HttpUtil.HTTPJsonGetHasBodyAsync(url, data);
                var result = JsonConvert.DeserializeObject<ThirdPartContentPlatformInfoToLangZiResultVo>(getResult);
                return ResultData<ThirdPartContentPlatformInfoToLangZiResultVo>.Success().AddData("hospitalContentplatformCode", result);
            }
            catch (Exception ex)
            {
                return ResultData<ThirdPartContentPlatformInfoToLangZiResultVo>.Fail(ex.Message);
            }
        }



    }
}