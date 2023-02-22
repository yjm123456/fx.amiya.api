using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.CompanyBaseInfo;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class CompanyBaseInfoService : ICompanyBaseInfoService
    {
        private IDalCompanyBaseInfo dalCompanyBaseInfo;

        public CompanyBaseInfoService(IDalCompanyBaseInfo dalCompanyBaseInfo)
        {
            this.dalCompanyBaseInfo = dalCompanyBaseInfo;
        }

        public async Task AddAsync(AddCompanyBaseInfoDto addCompanyBaseInfoDto)
        {
            CompanyBaseInfo companyBaseInfo = new CompanyBaseInfo();
            companyBaseInfo.Id = Guid.NewGuid().ToString().Replace("-","");
            companyBaseInfo.Name = addCompanyBaseInfoDto.Name;
            companyBaseInfo.RegisterDate = addCompanyBaseInfoDto.RegisterDate;
            companyBaseInfo.RegisterAddress = addCompanyBaseInfoDto.RegisterAddress;
            companyBaseInfo.CompanyCode = addCompanyBaseInfoDto.CompanyCode;
            companyBaseInfo.Corporation = addCompanyBaseInfoDto.Corporation;
            companyBaseInfo.BusinessScope = addCompanyBaseInfoDto.BusinessScope;
            companyBaseInfo.ContactEmail = addCompanyBaseInfoDto.ContactEmail;
            companyBaseInfo.CreateDate = DateTime.Now;
            companyBaseInfo.Valid = true;
            await dalCompanyBaseInfo.AddAsync(companyBaseInfo, true);
        }


        /// <summary>
        /// 获取公司名称列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<BaseKeyValueDto>> GetCompanyNameListAsync()
        {
            return  dalCompanyBaseInfo.GetAll().Where(e=>e.Valid==true).OrderByDescending(e => e.CreateDate).Select(e => new BaseKeyValueDto
            {
                Key = e.Id,
                Value = e.Name
            }).ToList();
        }

        public async Task<FxPageInfo<CompanyBaseInfoDto>> GetListWithPageAsync(string keyword, int pageNum, int pageSize)
        {
            var companyList = dalCompanyBaseInfo.GetAll().Where(e => string.IsNullOrEmpty(keyword) || (e.Name.Contains(keyword) || e.Corporation.Contains(keyword))).OrderByDescending(e => e.CreateDate).Select(e => new CompanyBaseInfoDto
            {
                Id=e.Id,
                Name=e.Name,
                RegisterDate=e.RegisterDate,
                RegisterAddress=e.RegisterAddress,
                CompanyCode=e.CompanyCode,
                Corporation=e.Corporation,
                BusinessScope=e.BusinessScope,
                ContactEmail=e.ContactEmail,
                Valid=e.Valid
            });
            FxPageInfo<CompanyBaseInfoDto> fxPageInfo = new FxPageInfo<CompanyBaseInfoDto>();
            fxPageInfo.TotalCount = companyList.Count();
            fxPageInfo.List = companyList.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            return fxPageInfo;
        }

        public async Task UpdateAsync(UpdateCompanyBaseInfoDto updateCompanyBaseInfoDto)
        {
            var company = dalCompanyBaseInfo.GetAll().Where(e=>e.Id== updateCompanyBaseInfoDto.Id).SingleOrDefault();
            company.Name = updateCompanyBaseInfoDto.Name;
            company.RegisterDate = updateCompanyBaseInfoDto.RegisterDate;
            company.RegisterAddress = updateCompanyBaseInfoDto.RegisterAddress;
            company.CompanyCode = updateCompanyBaseInfoDto.CompanyCode;
            company.Corporation = updateCompanyBaseInfoDto.Corporation;
            company.BusinessScope = updateCompanyBaseInfoDto.BusinessScope;
            company.ContactEmail = updateCompanyBaseInfoDto.ContactEmail;
            company.Valid = updateCompanyBaseInfoDto.Valid;
            company.UpdateDate = DateTime.Now;
            await dalCompanyBaseInfo.UpdateAsync(company, true);
        }
        /// <summary>
        /// 根据id获取公司信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CompanyBaseInfoDto> GetByIdAsync(string id) {
            return dalCompanyBaseInfo.GetAll().Where(e => e.Id == id).Select(e=>new CompanyBaseInfoDto
            { 
                Id=e.Id,
                Name=e.Name,
                RegisterDate=e.RegisterDate,
                RegisterAddress=e.RegisterAddress,
                CompanyCode=e.CompanyCode,
                Corporation=e.Corporation,
                BusinessScope=e.BusinessScope,
                ContactEmail=e.ContactEmail,
                Valid=e.Valid
            }).SingleOrDefault();         
        }
        /// <summary>
        /// 删除公司信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(string id)
        {
            var comapny = dalCompanyBaseInfo.GetAll().Where(e => e.Id == id).SingleOrDefault();
            comapny.Valid = false;
            await dalCompanyBaseInfo.UpdateAsync(comapny,true);
        }
    }
}
