using Fx.Amiya.Dto.AestheticsDesignReport;
using Fx.Amiya.IService;
using Fx.Amiya.MiniProgram.Api.Filters;
using Fx.Amiya.MiniProgram.Api.Vo;
using Fx.Amiya.MiniProgram.Api.Vo.AestheticsDesignReport.Input;
using Fx.Amiya.MiniProgram.Api.Vo.AestheticsDesignReport.Output;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Controllers
{
    [Route("amiya/wxmini/[controller]")]
    [ApiController]
    [FxAmiyaApiUserTypeAuthorization(UserType.Customer)]
    public class AestheticsDesignReportController : ControllerBase
    {
        private readonly IAestheticsDesignReportService aestheticsDesignReportService;
        private TokenReader _tokenReader;
        private IMiniSessionStorage _sessionStorage;
        private readonly IAestheticsDesignService aestheticsDesignService;

        public AestheticsDesignReportController(IAestheticsDesignReportService aestheticsDesignReportService, TokenReader tokenReader, IMiniSessionStorage sessionStorage, IAestheticsDesignService aestheticsDesignService)
        {
            this.aestheticsDesignReportService = aestheticsDesignReportService;
            _tokenReader = tokenReader;
            _sessionStorage = sessionStorage;
            this.aestheticsDesignService = aestheticsDesignService;
        }
        /// <summary>
        /// 添加美学设计报告
        /// </summary>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<ResultData> AddAestheticsDesignReport(AddAestheticsDesignReportVo add) {
            string token = _tokenReader.GetToken();
            var sessionInfo = _sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;
            AddAestheticsDesignReportDto addDto = new AddAestheticsDesignReportDto();
            addDto.CustomerId = customerId;
            addDto.Name = add.Name;
            addDto.BirthDay = add.BirthDay;
            addDto.Phone = add.Phone;
            addDto.City = add.City;
            addDto.HasAestheticMedicineHistory = add.HasAestheticMedicineHistory;
            addDto.HistoryDescribe1 = add.HistoryDescribe1;
            addDto.HistoryDescribe2 = add.HistoryDescribe2;
            addDto.HistoryDescribe3 = add.HistoryDescribe3;
            addDto.WhetherAcceptOperation = add.WhetherAcceptOperation;
            addDto.WhetherAllergyOrOtherDisease = add.WhetherAllergyOrOtherDisease;
            addDto.AllergyOrOtherDiseaseDescribe = add.AllergyOrOtherDiseaseDescribe;
            addDto.BeautyDemand = add.BeautyDemand;
            addDto.Budget = add.Budget;
            addDto.FrontPicture = add.FrontPicture;
            addDto.SidePicture = add.SidePicture;
            await aestheticsDesignReportService.AddAestheticsDesignReportAsync(addDto);
            return ResultData.Success();
        }
        /// <summary>
        /// 获取美学设计报告列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<FxPageInfo<AestheticsDesignReportSimpleInfoVo>>> GetListByPageAsync([FromQuery] QueryAestheticsDesignListVo query) {
            string token = _tokenReader.GetToken();
            var sessionInfo = _sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;
            var list = await aestheticsDesignReportService.GetListByPage(null, null, null, customerId, null, query.PageNum, query.PageSize);
            FxPageInfo<AestheticsDesignReportSimpleInfoVo> fxPageInfo = new FxPageInfo<AestheticsDesignReportSimpleInfoVo>();
            fxPageInfo.TotalCount = list.TotalCount;
            fxPageInfo.List = list.List.Select(e => new AestheticsDesignReportSimpleInfoVo {
                Id=e.Id,
                CreateDate=e.CreateDate.Value,
                FrontPicture=e.FrontPicture,
                SidePicture=e.SidePicture,
                StatusText=e.StatusText
            });
            return ResultData<FxPageInfo<AestheticsDesignReportSimpleInfoVo>>.Success().AddData("list",fxPageInfo);
        }
        /// <summary>
        /// 根据美学设计报告id获取美学设计详情
        /// </summary>
        /// <param name="reportId"></param>
        /// <returns></returns>
        [HttpGet("getByid/{reportId}")]
        public async Task<ResultData<AestheticsDesignReportDetailInfoVo>> GetByIdAsync(string reportId) {
            AestheticsDesignReportDetailInfoVo detailVo = new AestheticsDesignReportDetailInfoVo();
            var designReport = await aestheticsDesignReportService.GetByIdAsync(reportId);
            detailVo.Id = designReport.Id;
            detailVo.CreateDate = designReport.CreateDate;
            detailVo.Name = designReport.Name;
            detailVo.BirthDay = designReport.BirthDay;
            detailVo.Phone = designReport.Phone;
            detailVo.City = designReport.City;
            detailVo.HasAestheticMedicineHistory = designReport.HasAestheticMedicineHistory;
            detailVo.HistoryDescribe1 = designReport.HistoryDescribe1;
            detailVo.HistoryDescribe2 = designReport.HistoryDescribe2;
            detailVo.HistoryDescribe3 = designReport.HistoryDescribe3;
            detailVo.WhetherAcceptOperation = designReport.WhetherAcceptOperation;
            detailVo.WhetherAllergyOrOtherDisease = designReport.WhetherAllergyOrOtherDisease;
            detailVo.AllergyOrOtherDiseaseDescribe = designReport.AllergyOrOtherDiseaseDescribe;
            detailVo.BeautyDemand = designReport.BeautyDemand;
            detailVo.Budget = designReport.Budget;
            detailVo.FrontPicture = designReport.FrontPicture;
            detailVo.SidePicture = designReport.SidePicture;
            var design = await aestheticsDesignService.GetByReportIdAsync(reportId);
            DesignInfoVo designVo = new DesignInfoVo();
            if (design != null)
            {
                designVo.SimpleHospitalName = design.SimpleHospitalName;
                designVo.Design = design.Design;
                designVo.RecommendDoctor = design.RecommendDoctor;
                designVo.PictureTags = design.PictureTags.Select(e => new BaseIdAndNameVo { 
                    Id=e.Key,
                    Name=e.Value
                }).ToList();
                designVo.SidePicture = design.SidePicture;
                designVo.FrontPicture = design.FrontPicture;
                detailVo.Design = designVo;
            }
            else
            {
                detailVo.Design = null;
            }

            return ResultData<AestheticsDesignReportDetailInfoVo>.Success().AddData("info", detailVo);
        }
    }
}
