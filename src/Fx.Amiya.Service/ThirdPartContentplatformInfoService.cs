using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.AmiyaEmployee;
using Fx.Amiya.Dto.ThirdPartContentplatformInfo.Input;
using Fx.Amiya.Dto.ThirdPartContentplatformInfo.Result;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class ThirdPartContentplatformInfoService : IThirdPartContentplatformInfoService
    {
        private readonly IDalThirdPartContentplatformInfo dalThirdPartContentplatformInfo;
        private readonly IAmiyaEmployeeService amiyaEmployeeService;
        public ThirdPartContentplatformInfoService(IDalThirdPartContentplatformInfo dalThirdPartContentplatformInfo, IAmiyaEmployeeService amiyaEmployeeService)
        {
            this.dalThirdPartContentplatformInfo = dalThirdPartContentplatformInfo;
            this.amiyaEmployeeService = amiyaEmployeeService;
        }



        /// <summary>
        /// 根据条件获取三方平台信息信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<ThirdPartContentplatformInfoDto>> GetListAsync(QueryThirdPartContentplatformInfoDto query)
        {
            AmiyaEmployeeDto employeeInfo = new AmiyaEmployeeDto();
            var thirdPartContentplatformInfos = from d in dalThirdPartContentplatformInfo.GetAll()
                                                where (string.IsNullOrEmpty(query.KeyWord) || d.Name.Contains(query.KeyWord))
                                                && (d.Valid == query.Valid)
                                                select new ThirdPartContentplatformInfoDto
                                                {
                                                    Id = d.Id,
                                                    CreateDate = d.CreateDate,
                                                    UpdateDate = d.UpdateDate,
                                                    Valid = d.Valid,
                                                    DeleteDate = d.DeleteDate,
                                                    Name = d.Name,
                                                    ApiUrl = d.ApiUrl,
                                                    Sign = d.Sign,
                                                };
            FxPageInfo<ThirdPartContentplatformInfoDto> thirdPartContentplatformInfoPageInfo = new FxPageInfo<ThirdPartContentplatformInfoDto>();
            thirdPartContentplatformInfoPageInfo.TotalCount = await thirdPartContentplatformInfos.CountAsync();
            thirdPartContentplatformInfoPageInfo.List = await thirdPartContentplatformInfos.OrderByDescending(x => x.CreateDate).Skip((query.PageNum.Value - 1) * query.PageSize.Value).Take(query.PageSize.Value).ToListAsync();
            return thirdPartContentplatformInfoPageInfo;
        }


        /// <summary>
        /// 添加三方平台信息
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddAsync(AddThirdPartContentplatformInfoDto addDto)
        {
            try
            {
                ThirdPartContentplatformInfo thirdPartContentplatformInfo = new ThirdPartContentplatformInfo();
                thirdPartContentplatformInfo.Id = Guid.NewGuid().ToString();
                thirdPartContentplatformInfo.CreateDate = DateTime.Now;
                thirdPartContentplatformInfo.Valid = true;
                thirdPartContentplatformInfo.Name = addDto.Name;
                thirdPartContentplatformInfo.ApiUrl = addDto.ApiUrl;
                thirdPartContentplatformInfo.Sign = addDto.Sign;
                await dalThirdPartContentplatformInfo.AddAsync(thirdPartContentplatformInfo, true);

            }
            catch (Exception err)
            {
                throw new Exception(err.ToString());
            }
        }



        public async Task<ThirdPartContentplatformInfoDto> GetByIdAsync(string id)
        {
            var result = await dalThirdPartContentplatformInfo.GetAll().Where(x => x.Id == id && x.Valid == true).FirstOrDefaultAsync();
            if (result == null)
            {
                return new ThirdPartContentplatformInfoDto();
            }

            ThirdPartContentplatformInfoDto returnResult = new ThirdPartContentplatformInfoDto();
            returnResult.Id = result.Id;
            returnResult.CreateDate = result.CreateDate;
            returnResult.Valid = result.Valid;
            returnResult.Name = result.Name;
            returnResult.ApiUrl = result.ApiUrl;
            returnResult.Sign = result.Sign;
            return returnResult;
        }

        public async Task<ThirdPartContentplatformInfoDto> GetByNameAsync(string name)
        {
            var result = await dalThirdPartContentplatformInfo.GetAll().Where(x => x.Name == name && x.Valid == true).FirstOrDefaultAsync();
            if (result == null)
            {
                return new ThirdPartContentplatformInfoDto();
            }

            ThirdPartContentplatformInfoDto returnResult = new ThirdPartContentplatformInfoDto();
            returnResult.Id = result.Id;
            returnResult.CreateDate = result.CreateDate;
            returnResult.Valid = result.Valid;
            returnResult.Name = result.Name;
            returnResult.ApiUrl = result.ApiUrl;
            returnResult.Sign = result.Sign;
            return returnResult;
        }



        /// <summary>
        /// 修改三方平台信息
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateThirdPartContentplatformInfoDto updateDto)
        {
            var result = await dalThirdPartContentplatformInfo.GetAll().Where(x => x.Id == updateDto.Id && x.Valid == true).FirstOrDefaultAsync();
            if (result == null)
                throw new Exception("未找到三方平台信息信息");

            result.ApiUrl = updateDto.ApiUrl;
            result.Sign = updateDto.Sign;
            result.Name = updateDto.Name;
            result.UpdateDate = DateTime.Now;
            await dalThirdPartContentplatformInfo.UpdateAsync(result, true);
        }

        /// <summary>
        /// 作废三方平台信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(string id)
        {
            try
            {
                var result = await dalThirdPartContentplatformInfo.GetAll().SingleOrDefaultAsync(e => e.Id == id && e.Valid == true);
                if (result == null)
                    throw new Exception("未找到三方平台信息信息");
                result.Valid = false;
                result.DeleteDate = DateTime.Now;
                await dalThirdPartContentplatformInfo.UpdateAsync(result, true);

            }
            catch (Exception er)
            {
                throw new Exception(er.Message.ToString());
            }
        }


        /// <summary>
        /// 获取有效的三方平台信息信息（下拉框使用）
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<List<BaseKeyValueDto>> GetValidListAsync()
        {
            var thirdPartContentplatformInfos = from d in dalThirdPartContentplatformInfo.GetAll()
                                                where (d.Valid == true)
                                                select new BaseKeyValueDto
                                                {
                                                    Key = d.Id,
                                                    Value = d.Name
                                                };
            List<BaseKeyValueDto> thirdPartContentplatformInfoPageInfo = new List<BaseKeyValueDto>();
            thirdPartContentplatformInfoPageInfo = await thirdPartContentplatformInfos.ToListAsync();
            return thirdPartContentplatformInfoPageInfo;
        }
    }
}
