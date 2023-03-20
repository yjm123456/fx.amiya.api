using Fx.Amiya.Dto.CooperativeHospitalCity;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ICooperativeHospitalCityService
    {
        /// <summary>
        /// 获取合作医院城市列表（分页）
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<CooperativeHospitalCityDto>> GetListWithPageAsync(string provinceId, int pageNum, int pageSize);


        /// <summary>
        /// 获取合作医院城市列表
        /// </summary>
        /// <returns></returns>
       Task<List<CooperativeHospitalCityDto>> GetListAsync(string name, bool? valid);



        /// <summary>
        /// 获取有效的合作医院城市列表
        /// </summary>
        /// <returns></returns>
        Task<List<CooperativeHospitalCityDto>> GetValidListAsync();


        /// <summary>
        /// 根据省份获取有效的合作医院城市列表
        /// </summary>
        /// <returns></returns>
        Task<List<CooperativeHospitalCityDto>> GetValidListByProvinceIdAsync(string provinceId);


        /// <summary>
        /// 获取热门城市列表
        /// </summary>
        /// <returns></returns>
        Task<List<CooperativeHospitalCityDto>> GetHotListAsync();



        /// <summary>
        /// 根据商品id获取有效的合作医院城市列表
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        Task<List<CooperativeHospitalCityDto>> GetValidListByGoodsIdAsync(string goodsId);

        /// <summary>
        /// 添加合作医院城市
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddAsync(AddCooperativeHospitalCityDto addDto);



        /// <summary>
        /// 根据编号获取合作医院城市
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CooperativeHospitalCityDto> GetByIdAsync(int id);

        /// <summary>
        /// 修改合作城市
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateAsync(UpdateCooperativeHospitalCityDto updateDto);



        /// <summary>
        /// 删除合作医院城市
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);

    }
}
