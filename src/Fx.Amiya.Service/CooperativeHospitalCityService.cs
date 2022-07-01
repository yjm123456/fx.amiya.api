using Fx.Amiya.Dto.CooperativeHospitalCity;
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
    public class CooperativeHospitalCityService : ICooperativeHospitalCityService
    {
        private IDalCooperativeHospitalCity dalCooperativeHospitalCity;
        private IGoodsHospitalsPrice _goodsHospitalsPrice;
        private IHospitalInfoService _hospitalInfoService;
        public CooperativeHospitalCityService(IDalCooperativeHospitalCity dalCooperativeHospitalCity,
            IGoodsHospitalsPrice goodsHospitalsPrice,
            IHospitalInfoService hospitalInfoService)
        {
            this.dalCooperativeHospitalCity = dalCooperativeHospitalCity;
            _goodsHospitalsPrice = goodsHospitalsPrice;
            _hospitalInfoService = hospitalInfoService;
        }


        /// <summary>
        /// 获取合作医院城市列表（分页）
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<CooperativeHospitalCityDto>> GetListWithPageAsync(int pageNum, int pageSize)
        {
            var city = from d in dalCooperativeHospitalCity.GetAll()
                       select new CooperativeHospitalCityDto
                       {
                           Id = d.Id,
                           Name = d.Name,
                           Valid = d.Valid,
                           ProvinceId=d.ProvinceId,
                           IsHot=d.IsHot
                       };
            FxPageInfo<CooperativeHospitalCityDto> cityPageInfo = new FxPageInfo<CooperativeHospitalCityDto>();
            cityPageInfo.TotalCount = await city.CountAsync();
            cityPageInfo.List = await city.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return cityPageInfo;
        }



        /// <summary>
        /// 获取合作医院城市列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<CooperativeHospitalCityDto>> GetListAsync(string name, bool? valid)
        {
            var citys = from d in dalCooperativeHospitalCity.GetAll()
                        where (string.IsNullOrWhiteSpace(name) || d.Name.Contains(name))
                        && (valid == null || d.Valid == valid)
                        select new CooperativeHospitalCityDto
                        {
                            Id = d.Id,
                            Name = d.Name,
                            Valid = d.Valid
                        };
            return await citys.ToListAsync();
        }




        /// <summary>
        /// 获取有效的合作医院城市列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<CooperativeHospitalCityDto>> GetValidListAsync()
        {
            var city = from d in dalCooperativeHospitalCity.GetAll()
                       where d.Valid
                       select new CooperativeHospitalCityDto
                       {
                           Id = d.Id,
                           Name = d.Name,
                           Valid = d.Valid
                       };

            return await city.ToListAsync();
        }


        /// <summary>
        /// 根据省份获取有效的合作医院城市列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<CooperativeHospitalCityDto>> GetValidListByProvinceIdAsync(string provinceId)
        {
            var city = from d in dalCooperativeHospitalCity.GetAll()
                       where d.Valid
                       &&d.ProvinceId==provinceId
                       select new CooperativeHospitalCityDto
                       {
                           Id = d.Id,
                           Name = d.Name,
                           Valid = d.Valid
                       };

            return await city.ToListAsync();
        }


        /// <summary>
        /// 获取热门城市列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<CooperativeHospitalCityDto>> GetHotListAsync()
        {
            var city = from d in dalCooperativeHospitalCity.GetAll()
                       where d.Valid
                       &&d.IsHot
                       select new CooperativeHospitalCityDto
                       {
                           Id = d.Id,
                           Name = d.Name,
                           Valid = d.Valid
                       };

            return await city.OrderBy(z=>z.Name).ToListAsync();
        }

        /// <summary>
        /// 根据商品id获取有效的合作医院城市列表
        /// </summary>
        /// <param name="goodsId">商品id</param>
        /// <returns></returns>
        public async Task<List<CooperativeHospitalCityDto>> GetValidListByGoodsIdAsync(string goodsId)
        {
            var city = from d in dalCooperativeHospitalCity.GetAll()
                       where d.Valid
                       select new CooperativeHospitalCityDto
                       {
                           Id = d.Id,
                           Name = d.Name,
                           Valid = d.Valid
                       };

            var goodsHospitalPrice = await _goodsHospitalsPrice.GetByGoodsId(goodsId);
            List<int> goodsCityList = new List<int>();
            foreach (var z in goodsHospitalPrice)
            {
                var hospitalInfo = await _hospitalInfoService.GetByIdAsync(z.HospitalId);
                goodsCityList.Add(hospitalInfo.CityId.Value);
            }
            var result = await city.ToListAsync();
            foreach (var x in city)
            {
                if (!goodsCityList.Exists(z=>z== x.Id))
                {
                   result.RemoveAll((z)=>z.Id==x.Id);
                }
            }
            return  result;
        }



        /// <summary>
        /// 添加合作医院城市
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddAsync(AddCooperativeHospitalCityDto addDto)
        {
            var cityCount = await dalCooperativeHospitalCity.GetAll().CountAsync(e => e.Name == addDto.Name);
            if (cityCount > 0)
                throw new Exception("已存在该城市");

            CooperativeHospitalCity cooperativeHospitalCity = new CooperativeHospitalCity();
            cooperativeHospitalCity.Name = addDto.Name;
            cooperativeHospitalCity.Valid = true;
            cooperativeHospitalCity.IsHot = addDto.IsHot;
            cooperativeHospitalCity.ProvinceId = addDto.ProvinceId;
            await dalCooperativeHospitalCity.AddAsync(cooperativeHospitalCity, true);
        }



        public async Task<CooperativeHospitalCityDto> GetByIdAsync(int id)
        {
            var city = await dalCooperativeHospitalCity.GetAll().SingleOrDefaultAsync(e => e.Id == id);
            if (city == null)
                throw new Exception("编号错误");

            CooperativeHospitalCityDto cooperativeHospitalCityDto = new CooperativeHospitalCityDto();
            cooperativeHospitalCityDto.Id = city.Id;
            cooperativeHospitalCityDto.Name = city.Name;
            cooperativeHospitalCityDto.Valid = city.Valid;
            cooperativeHospitalCityDto.ProvinceId = city.ProvinceId;
            cooperativeHospitalCityDto.IsHot = city.IsHot;
            return cooperativeHospitalCityDto;
        }


        /// <summary>
        /// 修改合作城市
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateCooperativeHospitalCityDto updateDto)
        {
            var cityCount = await dalCooperativeHospitalCity.GetAll().CountAsync(e => e.Id != updateDto.Id && e.Name == updateDto.Name);
            if (cityCount > 0)
                throw new Exception("已存在该城市");

            var city = await dalCooperativeHospitalCity.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
            city.ProvinceId = updateDto.ProvinceId;
            city.Name = updateDto.Name;
            city.IsHot = updateDto.IsHot;
            city.Valid = updateDto.Valid;

            await dalCooperativeHospitalCity.UpdateAsync(city, true);
        }



        /// <summary>
        /// 删除合作医院城市
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            var city = await dalCooperativeHospitalCity.GetAll().SingleOrDefaultAsync(e => e.Id == id);
            await dalCooperativeHospitalCity.DeleteAsync(city, true);
        }
    }
}
