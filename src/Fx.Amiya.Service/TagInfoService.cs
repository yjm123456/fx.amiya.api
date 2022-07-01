using Fx.Amiya.Dto.TagInfo;
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
    public class TagInfoService : ITagInfoService
    {
        private IDalTagInfo dalTagInfo;
        public TagInfoService(IDalTagInfo dalTagInfo)
        {
            this.dalTagInfo = dalTagInfo;
        }


        /// <summary>
        /// 获取标签列表（分页）
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<TagInfoDto>> GetListWithPageAsync(byte? type, string name, int pageNum, int pageSize)
        {
            try
            {
                var tagInfo = from d in dalTagInfo.GetAll()
                              where name == null || d.Name.Contains(name)
                              select d;

                if (type == 0)
                {
                    tagInfo = from d in tagInfo
                              where d.Type == (byte)TagType.ScaleTag
                              select d;
                }

                if (type == 1)
                {
                    tagInfo = from d in tagInfo
                              where d.Type == (byte)TagType.FacilityTag
                              select d;
                }

                var tagInfoDto = from d in tagInfo
                                 select new TagInfoDto
                                 {
                                     Id = d.Id,
                                     Name = d.Name,
                                     Type = d.Type,
                                     TypeName = d.Type == 0 ? "级别" : "设施",
                                     Valid = d.Valid
                                 };

                FxPageInfo<TagInfoDto> tagPageInfo = new FxPageInfo<TagInfoDto>();
                tagPageInfo.TotalCount = await tagInfoDto.CountAsync();
                tagPageInfo.List = await tagInfoDto.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();

                return tagPageInfo;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 根据类型获取标签列表
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<List<TagNameDto>> GetNameListAsync(byte? type)
        {
            try
            {
                var tagInfo = from d in dalTagInfo.GetAll()
                              where d.Valid
                              select d;

                if (type == 0)
                {
                    tagInfo = from d in tagInfo
                              where d.Type == (byte)TagType.ScaleTag
                              select d;
                }

                if (type == 1)
                {
                    tagInfo = from d in tagInfo
                              where d.Type == (byte)TagType.FacilityTag
                              select d;
                }

                var tagInfoDto = from d in tagInfo
                                 select new TagNameDto
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






        public async Task AddAsync(AddTagInfoDto addDto)
        {
            try
            {
                TagInfo tagInfo = new TagInfo();
                tagInfo.Name = addDto.Name;
                tagInfo.Valid = true;
                if (addDto.Type == 0)
                {
                    tagInfo.Type = (byte)TagType.ScaleTag;
                }else
                {
                    tagInfo.Type = (byte)TagType.FacilityTag;
                }
                await dalTagInfo.AddAsync(tagInfo, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public async Task<TagInfoDto> GetByIdAsync(int id)
        {
            try
            {
                var tagInfo = await dalTagInfo.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (tagInfo == null)
                    throw new Exception("标签编号错误");

                TagInfoDto tagInfoDto = new TagInfoDto();
                tagInfoDto.Id = tagInfo.Id;
                tagInfoDto.Name = tagInfo.Name;
                tagInfoDto.Type = tagInfo.Type;
                tagInfoDto.TypeName = tagInfo.Type==0 ? "级别" : "设施";
                tagInfoDto.Valid = tagInfo.Valid;

                return tagInfoDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public async Task UpdateAsync(UpdateTagInfoDto updateDto)
        {
            try
            {
                var tagInfo = await dalTagInfo.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (tagInfo == null)
                    throw new Exception("标签编号错误");

                tagInfo.Name = updateDto.Name;
                tagInfo.Type = updateDto.Type;
                tagInfo.Valid = updateDto.Valid;

                await dalTagInfo.UpdateAsync(tagInfo, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


       
        public async Task DeleteAsync(int id)
        {
            try
            {
                var tagInfo = await dalTagInfo.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (tagInfo == null)
                    throw new Exception("标签编号错误");

                await dalTagInfo.DeleteAsync(tagInfo,true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
