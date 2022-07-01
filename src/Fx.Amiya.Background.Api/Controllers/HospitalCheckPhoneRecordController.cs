using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo.HospitalCheckPhoneRecord;
using Fx.Amiya.Dto.HospitalCheckPhoneRecord;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Infrastructure;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.Background.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HospitalCheckPhoneRecordController : ControllerBase
    {
        private IHospitalCheckPhoneRecordService hospitalCheckPhoneRecordService;
        private IHttpContextAccessor httpContextAccessor;
        public HospitalCheckPhoneRecordController(IHospitalCheckPhoneRecordService hospitalCheckPhoneRecordService,
            IHttpContextAccessor httpContextAccessor)
        {
            this.hospitalCheckPhoneRecordService = hospitalCheckPhoneRecordService;
            this.httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// 获取医院查看电话记录列表
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<HospitalCheckPhoneRecordVo>>> GetListWithPageAsync(int? hospitalId, int pageNum, int pageSize)
        {
            var q = await hospitalCheckPhoneRecordService.GetListWithPageAsync(hospitalId, pageNum, pageSize);
            var record = from d in q.List
                         select new HospitalCheckPhoneRecordVo
                         {
                             Id = d.Id,
                             HospitalId = d.HospitalId,
                             HospitalName = d.HospitalName,
                             HospitalEmployeeId = d.HospitalEmployeeId,
                             HospitalEmployeeName = d.HospitalEmployeeName,
                             Date = d.Date,
                             OrderId = d.OrderId
                         };
            FxPageInfo<HospitalCheckPhoneRecordVo> recordPageInfo = new FxPageInfo<HospitalCheckPhoneRecordVo>();
            recordPageInfo.TotalCount = q.TotalCount;
            recordPageInfo.List = record;
            return ResultData<FxPageInfo<HospitalCheckPhoneRecordVo>>.Success().AddData("checkRecord", recordPageInfo);
        }


        /// <summary>
        /// 添加正常交易订单的查看电话记录
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        [FxTenantAuthorize]
        public async Task<ResultData<string>> AddAsync(AddHospitalCheckPhoneRecordVo addVo)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaHospitalEmployeeIdentity;
            int hospitalId = employee.HospitalId;
            int employeeId = Convert.ToInt32(employee.Id);

            AddHospitalCheckPhoneRecordDto addDto = new AddHospitalCheckPhoneRecordDto();
            addDto.OrderId = addVo.OrderId;

            string phone = await hospitalCheckPhoneRecordService.AddAsync(addDto, hospitalId, employeeId);

            return ResultData<string>.Success().AddData("phone", phone);

        }


        /// <summary>
        /// 添加内容平台订单的查看电话记录
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("contentPlatform")]
        [FxTenantAuthorize]
        public async Task<ResultData<string>> AddContentPlatformOrderCheckPhoneRecordAsync(AddHospitalCheckPhoneRecordVo addVo)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaHospitalEmployeeIdentity;
            int hospitalId = employee.HospitalId;
            int employeeId = Convert.ToInt32(employee.Id);

            AddHospitalCheckPhoneRecordDto addDto = new AddHospitalCheckPhoneRecordDto();
            addDto.OrderId = addVo.OrderId;

            string phone = await hospitalCheckPhoneRecordService.AddContentPlatformOrderCheckPhoneRecordAsync(addDto, hospitalId, employeeId);

            return ResultData<string>.Success().AddData("phone", phone);
        }
    }
}