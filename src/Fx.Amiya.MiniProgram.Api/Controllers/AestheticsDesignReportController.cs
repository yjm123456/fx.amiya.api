using Fx.Amiya.Dto.AestheticsDesignReport;
using Fx.Amiya.IService;
using Fx.Amiya.MiniProgram.Api.Filters;
using Fx.Amiya.MiniProgram.Api.Vo.AestheticsDesignReport.Input;
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

        public AestheticsDesignReportController(IAestheticsDesignReportService aestheticsDesignReportService, TokenReader tokenReader, IMiniSessionStorage sessionStorage)
        {
            this.aestheticsDesignReportService = aestheticsDesignReportService;
            _tokenReader = tokenReader;
            _sessionStorage = sessionStorage;
        }
        /// <summary>
        /// 添加美学设计报告
        /// </summary>
        /// <returns></returns>
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
            addDto.Picture1 = add.Picture1;
            addDto.Picture2 = add.Picture2;
            await aestheticsDesignReportService.AddAestheticsDesignReportAsync(addDto);
            return ResultData.Success();
        }
    }
}
