using Fx.Amiya.Dto.Province;
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
    public class ProvinceService : IProvinceService
    {
        private IDalProvince dalProvince;
        private IGoodsHospitalsPrice _goodsHospitalsPrice;
        private IHospitalInfoService _hospitalInfoService;
        public ProvinceService(IDalProvince dalProvince,
            IGoodsHospitalsPrice goodsHospitalsPrice,
            IHospitalInfoService hospitalInfoService)
        {
            this.dalProvince = dalProvince;
            _goodsHospitalsPrice = goodsHospitalsPrice;
            _hospitalInfoService = hospitalInfoService;
        }


        /// <summary>
        /// 获取省份列表（分页）
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<ProvinceDto>> GetListWithPageAsync(int pageNum, int pageSize)
        {
            var city = from d in dalProvince.GetAll()
                       select new ProvinceDto
                       {
                           Id = d.Id,
                           Name = d.Name,
                           Valid = d.Valid,
                       };
            FxPageInfo<ProvinceDto> cityPageInfo = new FxPageInfo<ProvinceDto>();
            cityPageInfo.TotalCount = await city.CountAsync();
            cityPageInfo.List = await city.OrderBy(z=>z.Name).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return cityPageInfo;
        }



        /// <summary>
        /// 获取省份列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProvinceDto>> GetListAsync(string name, bool? valid)
        {
            var citys = from d in dalProvince.GetAll()
                        where (string.IsNullOrWhiteSpace(name) || d.Name.Contains(name))
                        && (valid == null || d.Valid == valid)
                        select new ProvinceDto
                        {
                            Id = d.Id,
                            Name = d.Name,
                            Valid = d.Valid
                        };
            return await citys.ToListAsync();
        }




        /// <summary>
        /// 获取有效的省份列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProvinceDto>> GetValidListAsync()
        {
            var city = from d in dalProvince.GetAll()
                       where d.Valid
                       select new ProvinceDto
                       {
                           Id = d.Id,
                           Name = d.Name,
                           Valid = d.Valid
                       };

            return await city.OrderBy(z=>z.Name).ToListAsync();
        }



        /// <summary>
        /// 添加省份
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddAsync(AddProvinceDto addDto)
        {
            var cityCount = await dalProvince.GetAll().CountAsync(e => e.Name == addDto.Name);
            if (cityCount > 0)
                throw new Exception("已存在该省份");

            Province cooperativeHospitalCity = new Province();
            cooperativeHospitalCity.Id = Guid.NewGuid().ToString();
            cooperativeHospitalCity.Name = addDto.Name;
            cooperativeHospitalCity.Valid = true;
            await dalProvince.AddAsync(cooperativeHospitalCity, true);
        }



        public async Task<ProvinceDto> GetByIdAsync(string id)
        {
            var city = await dalProvince.GetAll().SingleOrDefaultAsync(e => e.Id == id);
            if (city == null)
            {
                return new ProvinceDto()
                {
                    Name = "",
                    Id = "",
                    Valid = false
                };
            }

            ProvinceDto cooperativeHospitalCityDto = new ProvinceDto();
            cooperativeHospitalCityDto.Id = city.Id;
            cooperativeHospitalCityDto.Name = city.Name;
            cooperativeHospitalCityDto.Valid = city.Valid;

            return cooperativeHospitalCityDto;
        }


        /// <summary>
        /// 修改合作省份
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateProvinceDto updateDto)
        {
            var cityCount = await dalProvince.GetAll().CountAsync(e => e.Id != updateDto.Id && e.Name == updateDto.Name);
            if (cityCount > 0)
                throw new Exception("已存在该省份");

            var city = await dalProvince.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
            city.Name = updateDto.Name;
            city.Valid = updateDto.Valid;

            await dalProvince.UpdateAsync(city, true);
        }



        /// <summary>
        /// 删除省份
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(string id)
        {
            var city = await dalProvince.GetAll().SingleOrDefaultAsync(e => e.Id == id);
            await dalProvince.DeleteAsync(city, true);
        }
    }
}
