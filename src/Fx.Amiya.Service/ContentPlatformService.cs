using Fx.Amiya.Dto.ContentPlatform;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Fx.Amiya.DbModels.Model;
using Fx.Common;
using Fx.Amiya.Core.Interfaces.GoodsHospitalPrice;

namespace Fx.Amiya.Service
{
    public class ContentPlatformService : IContentPlatformService
    {
        private IDalContentplatform dalContentPlatform;
        public ContentPlatformService(IDalContentplatform dalContentPlatform)
        {
            this.dalContentPlatform = dalContentPlatform;
        }


        /// <summary>
        /// 获取内容平台列表（分页）
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<ContentPlatformDto>> GetListWithPageAsync(int pageNum, int pageSize)
        {
            var contentPlatform = from d in dalContentPlatform.GetAll()
                       select new ContentPlatformDto
                       {
                           Id = d.Id,
                           ContentPlatformName = d.ContentPlatformName,
                           Valid = d.Valid,
                       };
            FxPageInfo<ContentPlatformDto> cityPageInfo = new FxPageInfo<ContentPlatformDto>();
            cityPageInfo.TotalCount = await contentPlatform.CountAsync();
            cityPageInfo.List = await contentPlatform.OrderBy(z=>z.ContentPlatformName).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return cityPageInfo;
        }



        /// <summary>
        /// 获取内容平台列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<ContentPlatformDto>> GetListAsync(string name, bool? valid)
        {
            var citys = from d in dalContentPlatform.GetAll()
                        where (string.IsNullOrWhiteSpace(name) || d.ContentPlatformName.Contains(name))
                        && (valid == null || d.Valid == valid)
                        select new ContentPlatformDto
                        {
                            Id = d.Id,
                            ContentPlatformName = d.ContentPlatformName,
                            Valid = d.Valid
                        };
            return await citys.ToListAsync();
        }




        /// <summary>
        /// 获取有效的内容平台列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<ContentPlatformDto>> GetValidListAsync()
        {
            var contentPlatform = from d in dalContentPlatform.GetAll()
                       where d.Valid
                       select new ContentPlatformDto
                       {
                           Id = d.Id,
                           ContentPlatformName = d.ContentPlatformName,
                           Valid = d.Valid
                       };

            return await contentPlatform.OrderBy(z=>z.ContentPlatformName).ToListAsync();
        }



        /// <summary>
        /// 添加内容平台
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddAsync(AddContentPlatformDto addDto)
        {
            var cityCount = await dalContentPlatform.GetAll().CountAsync(e => e.ContentPlatformName == addDto.ContentPlatformName);
            if (cityCount > 0)
                throw new Exception("已存在该内容平台");

            Contentplatform cooperativeHospitalCity = new Contentplatform();
            cooperativeHospitalCity.Id = Guid.NewGuid().ToString();
            cooperativeHospitalCity.ContentPlatformName = addDto.ContentPlatformName;
            cooperativeHospitalCity.Valid = true;
            await dalContentPlatform.AddAsync(cooperativeHospitalCity, true);
        }



        public async Task<ContentPlatformDto> GetByIdAsync(string id)
        {
            var contentPlatform = await dalContentPlatform.GetAll().SingleOrDefaultAsync(e => e.Id == id);
            if (contentPlatform == null)
            {
                return new ContentPlatformDto()
                {
                    ContentPlatformName = "",
                    Id = "",
                    Valid = false
                };
            }

            ContentPlatformDto cooperativeHospitalCityDto = new ContentPlatformDto();
            cooperativeHospitalCityDto.Id = contentPlatform.Id;
            cooperativeHospitalCityDto.ContentPlatformName = contentPlatform.ContentPlatformName;
            cooperativeHospitalCityDto.Valid = contentPlatform.Valid;

            return cooperativeHospitalCityDto;
        }


        /// <summary>
        /// 修改合作内容平台
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateContentPlatformDto updateDto)
        {
            var cityCount = await dalContentPlatform.GetAll().CountAsync(e => e.Id != updateDto.Id && e.ContentPlatformName == updateDto.ContentPlatformName);
            if (cityCount > 0)
                throw new Exception("已存在该内容平台");

            var contentPlatform = await dalContentPlatform.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
            contentPlatform.ContentPlatformName = updateDto.ContentPlatformName;
            contentPlatform.Valid = updateDto.Valid;

            await dalContentPlatform.UpdateAsync(contentPlatform, true);
        }



        /// <summary>
        /// 删除内容平台
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(string id)
        {
            var contentPlatform = await dalContentPlatform.GetAll().SingleOrDefaultAsync(e => e.Id == id);
            await dalContentPlatform.DeleteAsync(contentPlatform, true);
        }
    }
}
