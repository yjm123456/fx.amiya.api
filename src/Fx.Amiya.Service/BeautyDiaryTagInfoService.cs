using Fx.Amiya.Dto.BeautyDiaryTagInfo;
using Fx.Amiya.IDal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Fx.Infrastructure;
using Fx.Amiya.IService;
using Fx.Amiya.DbModels.Model;
using Fx.Common;

namespace Fx.Amiya.Service
{
    public class BeautyDiaryBeautyDiaryTagInfoService : IBeautyDiaryTagInfoService
    {
        private IDalBeautyDiaryTagInfo dalBeautyDiaryTagInfo;
        public BeautyDiaryBeautyDiaryTagInfoService(IDalBeautyDiaryTagInfo dalBeautyDiaryTagInfo)
        {
            this.dalBeautyDiaryTagInfo = dalBeautyDiaryTagInfo;
        }


        /// <summary>
        /// 获取标签列表（分页）
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<BeautyDiaryTagInfoDto>> GetListWithPageAsync(string name, int pageNum, int pageSize)
        {
            try
            {
                var beautyDiaryTagInfo = from d in dalBeautyDiaryTagInfo.GetAll()
                              where name == null || d.Name.Contains(name)
                              select d;

                var beautyDiaryTagInfoDto = from d in beautyDiaryTagInfo
                                 select new BeautyDiaryTagInfoDto
                                 {
                                     Id = d.Id,
                                     Name = d.Name,
                                     Valid = d.Valid
                                 };

                FxPageInfo<BeautyDiaryTagInfoDto> tagPageInfo = new FxPageInfo<BeautyDiaryTagInfoDto>();
                tagPageInfo.TotalCount = await beautyDiaryTagInfoDto.CountAsync();
                tagPageInfo.List = await beautyDiaryTagInfoDto.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();

                return tagPageInfo;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取标签列表(id和name)
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<List<BeautyDiaryTagNameDto>> GetNameListAsync()
        {
            try
            {
                var tagInfo = from d in dalBeautyDiaryTagInfo.GetAll()
                              where d.Valid
                              select d;

                var tagInfoDto = from d in tagInfo
                                 select new BeautyDiaryTagNameDto
                                 {
                                     Id = d.Id,
                                     Name = d.Name,
                                 };

                return await tagInfoDto.ToListAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddAsync(AddBeautyDiaryTagInfoDto addDto)
        {
            try
            {
                BeautyDiaryTagInfo beautyDiaryTagInfo = new BeautyDiaryTagInfo();
                beautyDiaryTagInfo.Id = Guid.NewGuid().ToString();
                beautyDiaryTagInfo.Name = addDto.Name;
                beautyDiaryTagInfo.Valid = true;
                await dalBeautyDiaryTagInfo.AddAsync(beautyDiaryTagInfo, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public async Task<BeautyDiaryTagInfoDto> GetByIdAsync(string id)
        {
            try
            {
                var beautyDiaryTagInfo = await dalBeautyDiaryTagInfo.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (beautyDiaryTagInfo == null)
                    throw new Exception("标签编号错误");

                BeautyDiaryTagInfoDto beautyDiaryTagInfoDto = new BeautyDiaryTagInfoDto();
                beautyDiaryTagInfoDto.Id = beautyDiaryTagInfo.Id;
                beautyDiaryTagInfoDto.Name = beautyDiaryTagInfo.Name;
                beautyDiaryTagInfoDto.Valid = beautyDiaryTagInfo.Valid;

                return beautyDiaryTagInfoDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public async Task UpdateAsync(UpdateBeautyDiaryTagInfoDto updateDto)
        {
            try
            {
                var beautyDiaryTagInfo = await dalBeautyDiaryTagInfo.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (beautyDiaryTagInfo == null)
                    throw new Exception("标签编号错误");

                beautyDiaryTagInfo.Name = updateDto.Name;
                beautyDiaryTagInfo.Valid = updateDto.Valid;

                await dalBeautyDiaryTagInfo.UpdateAsync(beautyDiaryTagInfo, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


       
        public async Task DeleteAsync(string id)
        {
            try
            {
                var beautyDiaryTagInfo = await dalBeautyDiaryTagInfo.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (beautyDiaryTagInfo == null)
                    throw new Exception("标签编号错误");

                await dalBeautyDiaryTagInfo.DeleteAsync(beautyDiaryTagInfo,true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
