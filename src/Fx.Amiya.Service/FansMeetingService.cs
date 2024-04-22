using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.FansMeeting.Input;
using Fx.Amiya.Dto.FansMeeting.Result;
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
    public class FansMeetingService : IFansMeetingService
    {
        private readonly IDalFansMeeting dalFansMeeting;
        public FansMeetingService(IDalFansMeeting dalFansMeeting)
        {
            this.dalFansMeeting = dalFansMeeting;
        }



        /// <summary>
        /// 根据条件获取粉丝见面会信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<FansMeetingDto>> GetListAsync(QueryFansMeetingDto query)
        {
            var fansMeetings = from d in dalFansMeeting.GetAll().Include(x => x.HospitalInfo)
                               where (d.Valid == true)
                               && (!query.HospitalId.HasValue || d.HospitalId == query.HospitalId.Value)
                               && (!query.StartDate.HasValue || d.CreateDate >= query.StartDate.Value)
                               && (!query.EndDate.HasValue || d.CreateDate < query.EndDate.Value.AddDays(1).AddMilliseconds(-1))
                               && (string.IsNullOrEmpty(query.KeyWord) || d.Name.Contains(query.KeyWord))
                               select new FansMeetingDto
                               {
                                   Id = d.Id,
                                   CreateDate = d.CreateDate,
                                   UpdateDate = d.UpdateDate,
                                   Valid = d.Valid,
                                   DeleteDate = d.DeleteDate,
                                   Name = d.Name,
                                   StartDate = d.StartDate,
                                   EndDate = d.EndDate,
                                   HospitalId = d.HospitalId,
                                   HospitalName = d.HospitalInfo.Name,
                               };
            FxPageInfo<FansMeetingDto> fansMeetingPageInfo = new FxPageInfo<FansMeetingDto>();
            fansMeetingPageInfo.TotalCount = await fansMeetings.CountAsync();
            fansMeetingPageInfo.List = await fansMeetings.OrderByDescending(x => x.CreateDate).Skip((query.PageNum.Value - 1) * query.PageSize.Value).Take(query.PageSize.Value).ToListAsync();
            return fansMeetingPageInfo;
        }


        /// <summary>
        /// 添加粉丝见面会
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddAsync(AddFansMeetingDto addDto)
        {
            try
            {
                FansMeeting fansMeeting = new FansMeeting();
                fansMeeting.Id = Guid.NewGuid().ToString();
                fansMeeting.CreateDate = DateTime.Now;
                fansMeeting.Valid = true;
                fansMeeting.Name = addDto.Name;
                fansMeeting.StartDate = addDto.StartDate;
                fansMeeting.EndDate = addDto.EndDate;
                fansMeeting.HospitalId = addDto.HospitalId;
                await dalFansMeeting.AddAsync(fansMeeting, true);

            }
            catch (Exception err)
            {
                throw new Exception(err.ToString());
            }
        }



        public async Task<FansMeetingDto> GetByIdAsync(string id)
        {
            var result = await dalFansMeeting.GetAll().Include(x => x.HospitalInfo).Where(x => x.Id == id && x.Valid == true).FirstOrDefaultAsync();
            if (result == null)
            {
                return new FansMeetingDto();
            }

            FansMeetingDto returnResult = new FansMeetingDto();
            returnResult.Id = result.Id;
            returnResult.CreateDate = result.CreateDate;
            returnResult.Valid = result.Valid;
            returnResult.Name = result.Name;
            returnResult.StartDate = result.StartDate;
            returnResult.EndDate = result.EndDate;
            returnResult.HospitalId = result.HospitalId;
            returnResult.HospitalName = result.HospitalInfo.Name;

            return returnResult;
        }



        /// <summary>
        /// 修改粉丝见面会
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateFansMeetingDto updateDto)
        {
            var result = await dalFansMeeting.GetAll().Where(x => x.Id == updateDto.Id && x.Valid == true).FirstOrDefaultAsync();
            if (result == null)
                throw new Exception("未找到粉丝见面会信息");

            result.Name = updateDto.Name;
            result.StartDate = updateDto.StartDate;
            result.EndDate = updateDto.EndDate;
            result.HospitalId = updateDto.HospitalId;
            result.UpdateDate = DateTime.Now;
            await dalFansMeeting.UpdateAsync(result, true);
        }

        /// <summary>
        /// 作废粉丝见面会
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(string id)
        {
            try
            {
                var result = await dalFansMeeting.GetAll().SingleOrDefaultAsync(e => e.Id == id && e.Valid == true);
                if (result == null)
                    throw new Exception("未找到粉丝见面会信息");
                result.Valid = false;
                result.DeleteDate = DateTime.Now;
                await dalFansMeeting.UpdateAsync(result, true);

            }
            catch (Exception er)
            {
                throw new Exception(er.Message.ToString());
            }
        }


        /// <summary>
        /// 获取有效的粉丝见面会信息（下拉框使用）
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<List<BaseKeyValueDto>> GetValidListAsync()
        {
            var fansMeetings = from d in dalFansMeeting.GetAll().Include(x => x.HospitalInfo)
                               where (d.Valid == true)
                               select new BaseKeyValueDto
                               {
                                   Key = d.Id,
                                   Value = d.Name
                               };
            List<BaseKeyValueDto> fansMeetingPageInfo = new List<BaseKeyValueDto>();
            fansMeetingPageInfo= await fansMeetings.ToListAsync();
            return fansMeetingPageInfo;
        }
    }
}
