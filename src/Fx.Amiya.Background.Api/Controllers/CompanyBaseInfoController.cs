using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.CompanyBaseInfo;
using Fx.Amiya.Dto.CompanyBaseInfo;
using Fx.Amiya.IService;
using Fx.Amiya.Service;
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
    /// 公司基本信息
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class CompanyBaseInfoController : ControllerBase
    {
        private readonly ICompanyBaseInfoService companyBaseInfoService;

        public CompanyBaseInfoController(ICompanyBaseInfoService companyBaseInfoService)
        {
            this.companyBaseInfoService = companyBaseInfoService;
        }
        /// <summary>
        /// 获取公司信息列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<FxPageInfo<CompanyBaseInfoVo>>> GetListWithPageAsync(string keyword,int pageNum,int pageSize) {
            var list=await companyBaseInfoService.GetListWithPageAsync(keyword,pageNum,pageSize);
            FxPageInfo<CompanyBaseInfoVo> fxPageInfo = new FxPageInfo<CompanyBaseInfoVo>();
            fxPageInfo.TotalCount = list.TotalCount;
            fxPageInfo.List = from d in list.List select new CompanyBaseInfoVo { 
                Id=d.Id,
                Name=d.Name,
                RegisterDate=d.RegisterDate,
                RegisterAddress=d.RegisterAddress,
                CompanyCode=d.CompanyCode,
                Corporation=d.Corporation,
                BusinessScope=d.BusinessScope,
                ContactEmail=d.ContactEmail,
                Valid=d.Valid
            };
            return ResultData<FxPageInfo<CompanyBaseInfoVo>>.Success().AddData("list",fxPageInfo);
        }
        /// <summary>
        /// 修改公司信息
        /// </summary>
        /// <param name="updateCompanyBaseInfoVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateCompanyBaseInfoAsync(UpdateCompanyBaseInfoVo updateCompanyBaseInfoVo) {
            UpdateCompanyBaseInfoDto updateCompanyBaseInfoDto = new UpdateCompanyBaseInfoDto();
            updateCompanyBaseInfoDto.Id = updateCompanyBaseInfoVo.Id;
            updateCompanyBaseInfoDto.Name = updateCompanyBaseInfoVo.Name;
            updateCompanyBaseInfoDto.RegisterDate = updateCompanyBaseInfoVo.RegisterDate;
            updateCompanyBaseInfoDto.RegisterAddress = updateCompanyBaseInfoVo.RegisterAddress;
            updateCompanyBaseInfoDto.CompanyCode = updateCompanyBaseInfoVo.CompanyCode;
            updateCompanyBaseInfoDto.Corporation = updateCompanyBaseInfoVo.Corporation;
            updateCompanyBaseInfoDto.BusinessScope = updateCompanyBaseInfoVo.BusinessScope;
            updateCompanyBaseInfoDto.ContactEmail = updateCompanyBaseInfoVo.ContactEmail;
            updateCompanyBaseInfoDto.Valid = updateCompanyBaseInfoVo.Valid;
            await companyBaseInfoService.UpdateAsync(updateCompanyBaseInfoDto);
            return ResultData.Success();
        }
        /// <summary>
        /// 根据id获取公司信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getById/{id}")]
        public async Task<ResultData<CompanyBaseInfoVo>> GetById(string id) {
             var company= await companyBaseInfoService.GetByIdAsync(id);
            CompanyBaseInfoVo companyInfo = new CompanyBaseInfoVo();
            companyInfo.Id = company.Id;
            companyInfo.Name = company.Name;
            companyInfo.RegisterDate = company.RegisterDate;
            companyInfo.RegisterAddress = company.RegisterAddress;
            companyInfo.CompanyCode = company.CompanyCode;
            companyInfo.Corporation = company.Corporation;
            companyInfo.BusinessScope = company.BusinessScope;
            companyInfo.ContactEmail = company.ContactEmail;
            companyInfo.Valid = company.Valid;
            return ResultData<CompanyBaseInfoVo>.Success().AddData("companyInfo", companyInfo);
        }
        /// <summary>
        /// 添加公司
        /// </summary>
        /// <param name="addCompanyBaseInfoVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddCompany(AddCompanyBaseInfoVo addCompanyBaseInfoVo) {
            AddCompanyBaseInfoDto addCompanyBaseInfoDto = new AddCompanyBaseInfoDto();
            addCompanyBaseInfoDto.Name = addCompanyBaseInfoVo.Name;
            addCompanyBaseInfoDto.RegisterDate = addCompanyBaseInfoVo.RegisterDate;
            addCompanyBaseInfoDto.RegisterAddress = addCompanyBaseInfoVo.RegisterAddress;
            addCompanyBaseInfoDto.CompanyCode = addCompanyBaseInfoVo.CompanyCode;
            addCompanyBaseInfoDto.Corporation = addCompanyBaseInfoVo.Corporation;
            addCompanyBaseInfoDto.BusinessScope = addCompanyBaseInfoVo.BusinessScope;
            addCompanyBaseInfoDto.ContactEmail = addCompanyBaseInfoVo.ContactEmail;
            await companyBaseInfoService.AddAsync(addCompanyBaseInfoDto);
            return ResultData.Success();
        }
        /// <summary>
        /// 获取公司名称列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("nameList")]
        public async Task<ResultData<List<BaseIdAndNameVo>>> GetCompanyNameList() {
            var nameList= (await companyBaseInfoService.GetCompanyNameListAsync()).Select(e=>new BaseIdAndNameVo { 
                Id=e.Key,
                Name=e.Value
            }).ToList();
            return ResultData<List<BaseIdAndNameVo>>.Success().AddData("nameList",nameList);
        }
        /// <summary>
        /// 删除公司信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(string id) {
            await companyBaseInfoService.DeleteAsync(id);
            return ResultData.Success();
        }
    }
}
