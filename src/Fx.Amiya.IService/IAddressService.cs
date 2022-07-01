using Fx.Amiya.Dto.Address;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IAddressService
    {
        /// <summary>
        /// 根据客户编号获取收货地址列表
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<List<AddressDto>> GetListByCustomerIdAsync(string customerId);


        /// <summary>
        /// 根据地址编号获取收货地址信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AddressDto> GetByIdAsync(int id);



        /// <summary>
        /// 根据客户编号获取是否存在收货地址
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<bool> GetIsExistByCustomrId(string customerId);


        /// <summary>
        /// 根据客户编号获取单条收货地址
        /// </summary>
        /// <returns></returns>
        Task<AddressDto> GetSingleByCustomerIdAsync(string customerId);

        /// <summary>
        /// 添加收货地址
        /// </summary>
        /// <param name="addDto"></param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<int> AddAsync(AddAddressDto addDto, string customerId);

        /// <summary>
        /// 修改收货地址
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateAsync(UpdateAddressDto updateDto, string customerId);

        /// <summary>
        /// 删除收货地址
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);
    }
}
