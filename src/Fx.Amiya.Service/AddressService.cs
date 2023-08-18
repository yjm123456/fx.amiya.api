using Fx.Amiya.Dto.Address;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Fx.Amiya.DbModels.Model;

namespace Fx.Amiya.Service
{
    public class AddressService : IAddressService
    {
        private IDalAddress dalAddress;
        public AddressService(IDalAddress dalAddress)
        {
            this.dalAddress = dalAddress;
        }

        /// <summary>
        /// 根据客户编号获取收货地址列表
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<List<AddressDto>> GetListByCustomerIdAsync(string customerId)
        {
            try
            {
                var address = from d in dalAddress.GetAll()
                              where d.CustomerId == customerId && d.IsDelete == false
                              select new AddressDto
                              {
                                  Id = d.Id,
                                  Province = d.Province,
                                  ProvinceCode = d.ProvinceCode,
                                  City = d.City,
                                  CityCode = d.CityCode,
                                  District = d.District,
                                  DistrictCode = d.DistrictCode,
                                  Other = d.Other,
                                  Phone = d.Phone,
                                  Contact = d.Contact,
                                  IsDefault = d.IsDefault,
                                  CreateDate = d.CreateDate
                              };

                return await address.OrderByDescending(e => e.IsDefault).ThenByDescending(e => e.CreateDate).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }




        /// <summary>
        /// 根据地址编号获取收货地址信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AddressDto> GetByIdAsync(int id)
        {
            try
            {
                var address = await dalAddress.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (address == null)
                    throw new Exception("收货地址编号错误");

                AddressDto addressDto = new AddressDto();
                addressDto.Id = address.Id;
                addressDto.Province = address.Province;
                addressDto.ProvinceCode = address.ProvinceCode;
                addressDto.City = address.City;
                addressDto.CityCode = address.CityCode;
                addressDto.District = address.District;
                addressDto.DistrictCode = address.DistrictCode;
                addressDto.Other = address.Other;
                addressDto.Contact = address.Contact;
                addressDto.Phone = address.Phone;
                addressDto.IsDefault = address.IsDefault;

                return addressDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        /// <summary>
        /// 根据客户编号获取是否存在收货地址
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<bool> GetIsExistByCustomrId(string customerId)
        {
            var addressCount = await dalAddress.GetAll().CountAsync(e => e.CustomerId == customerId && e.IsDelete == false);
            if (addressCount > 0)
                return true;
            return false;
        }




        /// <summary>
        /// 根据客户编号获取单条收货地址
        /// </summary>
        /// <returns></returns>
        public async Task<AddressDto> GetSingleByCustomerIdAsync(string customerId)
        {
            var address = await dalAddress.GetAll()
                .OrderByDescending(e => e.IsDefault == true).ThenByDescending(e => e.CreateDate)
                .FirstOrDefaultAsync(e => e.CustomerId == customerId && e.IsDelete == false);

            if (address == null)
                return new AddressDto();

            AddressDto addressDto = new AddressDto();
            addressDto.Id = address.Id;
            addressDto.Province = address.Province;
            addressDto.ProvinceCode = address.ProvinceCode;
            addressDto.City = address.City;
            addressDto.CityCode = address.CityCode;
            addressDto.District = address.District;
            addressDto.DistrictCode = address.DistrictCode;
            addressDto.Other = address.Other;
            addressDto.Contact = address.Contact;
            addressDto.Phone = address.Phone;
            addressDto.IsDefault = address.IsDefault;
            return addressDto;
        }




        /// <summary>
        /// 添加收货地址
        /// </summary>
        /// <param name="addDto"></param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<int> AddAsync(AddAddressDto addDto, string customerId)
        {
            try
            {

                if (addDto.IsDefault)
                {
                    var addressInfo = await dalAddress.GetAll().SingleOrDefaultAsync(e => e.IsDefault == true && e.CustomerId == customerId);
                    if (addressInfo != null)
                    {
                        addressInfo.IsDefault = false;
                        await dalAddress.UpdateAsync(addressInfo, true);
                    }

                }
                Address address = new Address();
                address.Province = addDto.Province;
                address.ProvinceCode = addDto.ProvinceCode;
                address.City = addDto.City;
                address.CityCode = addDto.CityCode;
                address.District = addDto.District;
                address.DistrictCode = addDto.DistrictCode;
                address.Other = addDto.Other;
                address.Contact = addDto.Contact;
                address.Phone = addDto.Phone;
                address.IsDefault = addDto.IsDefault;
                address.IsDelete = false;
                address.CustomerId = customerId;
                address.CreateDate = DateTime.Now;

                await dalAddress.AddAsync(address, true);
                return address.Id;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }



        /// <summary>
        /// 修改收货地址
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateAddressDto updateDto, string customerId)
        {
            try
            {
                var address = await dalAddress.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (updateDto.IsDefault && address.IsDefault != true)
                {
                    var adddressInfo = await dalAddress.GetAll().SingleOrDefaultAsync(e => e.IsDefault == true && e.CustomerId == customerId);
                    if (adddressInfo != null)
                    {
                        adddressInfo.IsDefault = false;
                        await dalAddress.UpdateAsync(adddressInfo, true);
                    }
                }

                address.Province = updateDto.Province;
                address.ProvinceCode = updateDto.ProvinceCode;
                address.City = updateDto.City;
                address.CityCode = updateDto.CityCode;
                address.District = updateDto.District;
                address.DistrictCode = updateDto.DistrictCode;
                address.Other = updateDto.Other;
                address.Contact = updateDto.Contact;
                address.Phone = updateDto.Phone;
                address.IsDefault = updateDto.IsDefault;

                await dalAddress.UpdateAsync(address, true);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }



        /// <summary>
        /// 删除收货地址
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            try
            {
                var address = await dalAddress.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (address == null)
                    throw new Exception("收货地址编号错误");

                if (address.IsDefault == true)
                    address.IsDefault = false;
                address.IsDelete = true;
                await dalAddress.UpdateAsync(address, true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

    }
}
