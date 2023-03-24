using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.AestheticsDesignReport.Input;
using Fx.Amiya.Background.Api.Vo.AestheticsDesignReport.Output;
using Fx.Amiya.Dto.AestheticsDesign;
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
    /// 美学设计报告
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class AestheticsDesignReportController : ControllerBase
    {
        private readonly IAestheticsDesignReportService aestheticsDesignReportService;
        private readonly IAestheticsDesignService aestheticsDesignService;

        public AestheticsDesignReportController(IAestheticsDesignReportService aestheticsDesignReportService, IAestheticsDesignService aestheticsDesignService)
        {
            this.aestheticsDesignReportService = aestheticsDesignReportService;
            this.aestheticsDesignService = aestheticsDesignService;
        }
        /// <summary>
        /// 分页获取美学设计报告列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<FxPageInfo<AestheticsDesignReportVo>>> GetListByPageAsync([FromQuery]QueryAestheticsDesignReportVo query) {
             var pageList= await aestheticsDesignReportService.GetListByPage(query.StartDate,query.EndDate,query.KeyWord,null,query.Status,query.PageNum,query.PageSize);
            FxPageInfo<AestheticsDesignReportVo> result = new FxPageInfo<AestheticsDesignReportVo>();
            result.TotalCount = pageList.TotalCount;
            result.List = pageList.List.Select(e => new AestheticsDesignReportVo
            {
                Id = e.Id,
                CreateDate = e.CreateDate,
                Name = e.Name,
                BirthDay = e.BirthDay,
                Phone = e.Phone,
                City = e.City,
                HasAestheticMedicineHistory = e.HasAestheticMedicineHistory,
                WhetherAcceptOperation=e.WhetherAcceptOperation,
                WhetherAllergyOrOtherDisease=e.WhetherAllergyOrOtherDisease,
                Budget=e.Budget,
                FrontPicture=e.FrontPicture,
                SidePicture=e.SidePicture,
                Status=e.Status,
                StatusText=e.StatusText
            });
            return ResultData<FxPageInfo<AestheticsDesignReportVo>>.Success().AddData("list",result);
        }
        /// <summary>
        /// 添加美学设计
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("addAestheticsDesign")]
        public async Task<ResultData> AddAestheticsDesignAsync(AddAestheticsDesignVo addVo) {
            AddAestheticsDesignDto addDto = new AddAestheticsDesignDto();
            addDto.AestheticsDesignReportId = addVo.AestheticsDesignReportId;
            addDto.Design = addVo.Design;
            addDto.HospitalId = addVo.HospitalId;
            addDto.RecommendDoctor = addVo.RecommendDoctor;
            addDto.SidePicture = addVo.SidePicture;
            addDto.FrontPicture = addVo.FrontPicture;
            addDto.PictureTags = addVo.PictireTags;
            await aestheticsDesignService.AddAestheticsDesignAsync(addDto);
            return ResultData.Success();
        }
        /// <summary>
        /// 根据美学设计报告id,获取美学设计
        /// </summary>
        /// <param name="reportId">美学设计报告id</param>
        /// <returns></returns>
        [HttpGet("getDesignByReportId")]
        public async Task<ResultData<AestheticsDesignReportDetailVo>> GetAestheticsDesignByReportIdAsync(string reportId) {
            AestheticsDesignReportDetailVo detailVo = new AestheticsDesignReportDetailVo();
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
            var design= await aestheticsDesignService.GetByReportIdAsync(reportId);
            AestheticsDesign designVo = new AestheticsDesign();
            if (design != null)
            {
                designVo.Id = design.Id;
                designVo.HospitalId = design.HospitalId;
                designVo.SimpleHospitalName = design.SimpleHospitalName;
                designVo.Design = design.Design;
                designVo.RecommendDoctor = design.RecommendDoctor;
                designVo.PictureTags = design.PictureTags.Select(e=>e.Key).ToList();
                designVo.SidePicture = design.SidePicture;
                designVo.FrontPicture = design.FrontPicture;
                detailVo.AestheticsDesign = designVo;
            }
            else {
                detailVo.AestheticsDesign = null;
            }
            
            return ResultData<AestheticsDesignReportDetailVo>.Success().AddData("info", detailVo);
        }
        /// <summary>
        /// 更新美学设计
        /// </summary>
        /// <returns></returns>
        [HttpPut("updateDesign")]
        public async Task<ResultData> UpdateAestheticsDesignAsync(UpdateAestheticsDesignVo updateVo)
        {
            UpdateAestheticsDesgnDto updateDto = new UpdateAestheticsDesgnDto();
            updateDto.Id = updateVo.Id;
            updateDto.Design = updateVo.Design;
            updateDto.HospitalId = updateVo.HospitalId;
            updateDto.RecommendDoctor = updateVo.RecommendDoctor;
            updateDto.PictureTags = updateVo.PictureTags;
            updateDto.SidePicture = updateVo.SidePicture;
            updateDto.FrontPicture = updateVo.FrontPicture;
            await aestheticsDesignService.UpdateAestheticsDesignAsync(updateDto);
            return ResultData.Success();
        }
        /// <summary>
        /// 美学设计报告状态名称列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("statuList")]
        public async Task<ResultData<List<BaseIdAndNameVo<int>>>> GetRequestSourceNameListAsync()
        {
            var nameList = await aestheticsDesignReportService.GetStatusListAsync();
            var result = nameList.Select(e => new BaseIdAndNameVo<int>
            {
                Id = e.Key,
                Name = e.Value
            }).ToList();
            return ResultData<List<BaseIdAndNameVo<int>>>.Success().AddData("statuList", result);
        }
        

    }
}
