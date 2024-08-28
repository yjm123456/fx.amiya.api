using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.HospitalContentplatformCode.Input;
using Fx.Amiya.Dto.HospitalContentplatformCode.Result;
using Fx.Amiya.Dto.OperationLog;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class HospitalContentplatformCodeService : IHospitalContentplatformCodeService
    {
        private readonly IDalHospitalContentplatformCode dalHospitalContentplatformCode;
        public HospitalContentplatformCodeService(IDalHospitalContentplatformCode dalHospitalContentplatformCode)
        {
            this.dalHospitalContentplatformCode = dalHospitalContentplatformCode;
        }



        /// <summary>
        /// 根据条件获取三方平台医院编码信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<HospitalContentplatformCodeDto>> GetListAsync(QueryHospitalContentplatformCodeDto query)
        {
            var hospitalContentplatformCodes = from d in dalHospitalContentplatformCode.GetAll().Include(x => x.HospitalInfo).Include(x => x.ThirdPartContentplatformInfo)
                                               where (d.Valid == true && d.HospitalId == query.HospitalId && d.ThirdPartContentplatformInfoId == query.ThirdPartContentplatformInfoId)
                                               && (string.IsNullOrEmpty(query.KeyWord) || d.Code.Contains(query.KeyWord))
                                               select new HospitalContentplatformCodeDto
                                               {
                                                   Id = d.Id,
                                                   CreateDate = d.CreateDate,
                                                   UpdateDate = d.UpdateDate,
                                                   Valid = d.Valid,
                                                   DeleteDate = d.DeleteDate,
                                                   ThirdPartContentplatformInfoId = d.ThirdPartContentplatformInfoId,
                                                   ThirdPartContentplatformInfoName = d.ThirdPartContentplatformInfo.Name,
                                                   HospitalId = d.HospitalId,
                                                   HospitalName = d.HospitalInfo.Name,
                                               };
            FxPageInfo<HospitalContentplatformCodeDto> hospitalContentplatformCodePageInfo = new FxPageInfo<HospitalContentplatformCodeDto>();
            hospitalContentplatformCodePageInfo.TotalCount = await hospitalContentplatformCodes.CountAsync();
            hospitalContentplatformCodePageInfo.List = await hospitalContentplatformCodes.OrderByDescending(x => x.CreateDate).Skip((query.PageNum.Value - 1) * query.PageSize.Value).Take(query.PageSize.Value).ToListAsync();
            return hospitalContentplatformCodePageInfo;
        }



        /// <summary>
        /// 添加三方平台医院编码
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddAsync(AddHospitalContentplatformCodeDto addDto)
        {

            try
            {
                //查询是否存在该条Code
                var isExist = await dalHospitalContentplatformCode.GetAll()
                               .Where(d => d.Valid == true && d.HospitalId == addDto.HospitalId && d.ThirdPartContentplatformInfoId == addDto.ThirdPartContentplatformInfoId).ToListAsync();
                if (isExist.Count() > 0)
                {
                    throw new Exception("该平台已存在相同医院数据，请重新确认后添加！");
                }

                HospitalContentplatformCode hospitalContentplatformCode = new HospitalContentplatformCode();
                hospitalContentplatformCode.Id = Guid.NewGuid().ToString();
                hospitalContentplatformCode.CreateDate = DateTime.Now;
                hospitalContentplatformCode.Valid = true;
                hospitalContentplatformCode.HospitalId = addDto.HospitalId;
                hospitalContentplatformCode.ThirdPartContentplatformInfoId = addDto.ThirdPartContentplatformInfoId;
                hospitalContentplatformCode.Code = addDto.Code;
                await dalHospitalContentplatformCode.AddAsync(hospitalContentplatformCode, true);

            }
            catch (Exception err)
            {
                throw new Exception(err.ToString());
            }
        }


        public async Task<HospitalContentplatformCodeDto> GetByIdAsync(string id)
        {
            var result = await dalHospitalContentplatformCode.GetAll().Include(x => x.HospitalInfo).Include(x => x.ThirdPartContentplatformInfo).Where(x => x.Id == id && x.Valid == true).FirstOrDefaultAsync();
            if (result == null)
            {
                return new HospitalContentplatformCodeDto();
            }

            HospitalContentplatformCodeDto returnResult = new HospitalContentplatformCodeDto();
            returnResult.Id = result.Id;
            returnResult.CreateDate = result.CreateDate;
            returnResult.Valid = result.Valid;
            returnResult.HospitalId = result.HospitalId;
            returnResult.ThirdPartContentplatformInfoId = result.ThirdPartContentplatformInfoId;
            returnResult.Code = result.Code;
            return returnResult;
        }


        public async Task<HospitalContentplatformCodeDto> GetByHospitalIdAndThirdPartContentPlatformIdAsync(int hospitalId, string ThirdPartContentPlatFormId)
        {
            var result = await dalHospitalContentplatformCode.GetAll().Include(x => x.HospitalInfo).Include(x => x.ThirdPartContentplatformInfo).Where(x => x.HospitalId == hospitalId && x.ThirdPartContentplatformInfoId == ThirdPartContentPlatFormId && x.Valid == true).FirstOrDefaultAsync();
            if (result == null)
            {
                throw new Exception("未找到'" + result.ThirdPartContentplatformInfo.Name + "'平台的'" + result.HospitalInfo.Name + "'配置信息!");
            }

            HospitalContentplatformCodeDto returnResult = new HospitalContentplatformCodeDto();
            returnResult.Id = result.Id;
            returnResult.CreateDate = result.CreateDate;
            returnResult.Valid = result.Valid;
            returnResult.HospitalId = result.HospitalId;
            returnResult.ThirdPartContentplatformInfoId = result.ThirdPartContentplatformInfoId;
            returnResult.Code = result.Code;
            return returnResult;
        }



        /// <summary>
        /// 修改三方平台医院编码
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateHospitalContentplatformCodeDto updateDto)
        {
            var result = await dalHospitalContentplatformCode.GetAll().Where(x => x.Id == updateDto.Id && x.Valid == true).FirstOrDefaultAsync();
            if (result == null)
                throw new Exception("未找到三方平台医院编码信息");
            var isExist = await dalHospitalContentplatformCode.GetAll()
                           .Where(d => d.Valid == true && d.HospitalId == updateDto.HospitalId && d.ThirdPartContentplatformInfoId == updateDto.ThirdPartContentplatformInfoId).ToListAsync();
            if (isExist.Count() > 0)
            {
                throw new Exception("该平台已存在相同医院数据，请重新确认后添加！");
            }
            result.ThirdPartContentplatformInfoId = updateDto.ThirdPartContentplatformInfoId;
            result.HospitalId = updateDto.HospitalId;
            result.Code = updateDto.Code;
            result.UpdateDate = DateTime.Now;
            await dalHospitalContentplatformCode.UpdateAsync(result, true);
        }
        /// <summary>
        /// 作废三方平台医院编码
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task DeleteAsync(string id, int employeeId)
        {
            try
            {
                var result = await dalHospitalContentplatformCode.GetAll().SingleOrDefaultAsync(e => e.Id == id && e.Valid == true);
                if (result == null)
                    throw new Exception("未找到三方平台医院编码信息");
                result.Valid = false;
                result.DeleteDate = DateTime.Now;
                await dalHospitalContentplatformCode.UpdateAsync(result, true);

            }
            catch (Exception er)
            {
                throw new Exception(er.Message.ToString());
            }
        }



    }
}
