using Fx.Amiya.Background.Api.Vo.HospitalDealGoodsOperation;
using Fx.Amiya.Dto.Doctor;
using Fx.Amiya.Dto.GreatHospitalOperationHealth;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IHospitalDealItemService
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<List<HospitalDealItemOperationDto>> GetListAsync(string keyword, string indicatorsId);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddAsync(AddHospitalDealItemOperationDto addDto);



        /// <summary>
        /// 根据编号获取信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<HospitalDealItemOperationDto> GetByIdAsync(string id);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateAsync(UpdateHospitalDealItemOperationDto updateDto);

        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(string id);

        /// <summary>
        /// 数据库删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteDataAsync(string id);
    }
}
