using Fx.Amiya.Dto.Address;
using Fx.Amiya.IService;
using Fx.Amiya.MiniProgram.Api.Filters;
using Fx.Amiya.MiniProgram.Api.Vo.Address;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Controllers
{
    [Route("amiya/wxmini/[controller]")]
    [ApiController]
    [FxAmiyaApiUserTypeAuthorization(UserType.Customer)]
    public class AddressController : ControllerBase
    {
        private IAddressService addressService;
        private TokenReader _tokenReader;
        private IMiniSessionStorage _sessionStorage;
        public AddressController(IAddressService addressService, TokenReader tokenReader, IMiniSessionStorage sessionStorage)
        {
            this.addressService = addressService;
            _tokenReader = tokenReader;
            _sessionStorage = sessionStorage;
        }

        /// <summary>
        /// 获取收货地址列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<List<AddressVo>>> GetListByCustomerIdAsync()
        {
            try
            {
                string token = _tokenReader.GetToken();
                var sessionInfo = _sessionStorage.GetSession(token);
                string customerId = sessionInfo.FxCustomerId;

                var address = from d in await addressService.GetListByCustomerIdAsync(customerId)
                              select new AddressVo
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
                                  IsDefault = d.IsDefault
                              };

                return ResultData<List<AddressVo>>.Success().AddData("addressList", address.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<AddressVo>>.Fail(ex.Message);
            }
        }




        /// <summary>
        /// 根据地址编号获取收货地址信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<AddressVo>> GetByIdAsync(int id)
        {
            try
            {
                var address = await addressService.GetByIdAsync(id);
                AddressVo addressVo = new AddressVo();
                addressVo.Id = address.Id;
                addressVo.Province = address.Province;
                addressVo.ProvinceCode = address.ProvinceCode;
                addressVo.City = address.City;
                addressVo.CityCode = address.CityCode;
                addressVo.District = address.District;
                addressVo.DistrictCode = address.DistrictCode;
                addressVo.Other = address.Other;
                addressVo.Contact = address.Contact;
                addressVo.Phone = address.Phone;
                addressVo.IsDefault = address.IsDefault;

                return ResultData<AddressVo>.Success().AddData("addressInfo", addressVo);
            }
            catch (Exception ex)
            {
                return ResultData<AddressVo>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据客户编号获取是否存在收货地址
        /// </summary>
        /// <returns></returns>
        [HttpGet("isExist")]
        public async Task<ResultData<bool>> GetIsExistByCustomrId()
        {
            string token = _tokenReader.GetToken();
            var sessionInfo = _sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;
            var isExistAddress = await addressService.GetIsExistByCustomrId(customerId);
            return ResultData<bool>.Success().AddData("isExistAddress", isExistAddress);
        }



        /// <summary>
        /// 获取单条收货地址
        /// </summary>
        /// <returns></returns>
        [HttpGet("single")]
        public async Task<ResultData<AddressVo>> GetSingleByCustomerIdAsync()
        {
            string token = _tokenReader.GetToken();
            var sessionInfo = _sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;

            var address = await addressService.GetSingleByCustomerIdAsync(customerId);

            AddressVo addressVo = new AddressVo();
            addressVo.Id = address.Id;
            addressVo.Province = address.Province;
            addressVo.ProvinceCode = address.ProvinceCode;
            addressVo.City = address.City;
            addressVo.CityCode = address.CityCode;
            addressVo.District = address.District;
            addressVo.DistrictCode = address.DistrictCode;
            addressVo.Other = address.Other;
            addressVo.Contact = address.Contact;
            addressVo.Phone = address.Phone;
            addressVo.IsDefault = address.IsDefault;
            return ResultData<AddressVo>.Success().AddData("address", addressVo);
        }


        /// <summary>
        /// 添加收货地址
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData<int>> AddAsync(AddAddressVo addVo)
        {
            try
            {
                string token = _tokenReader.GetToken();
                var sessionInfo = _sessionStorage.GetSession(token);
                string customerId = sessionInfo.FxCustomerId;

                AddAddressDto addDto = new AddAddressDto();
                addDto.Province = addVo.Province;
                addDto.ProvinceCode = addVo.ProvinceCode;
                addDto.City = addVo.City;
                addDto.CityCode = addVo.CityCode;
                addDto.District = addVo.District;
                addDto.DistrictCode = addVo.DistrictCode;
                addDto.Other = addVo.Other;
                addDto.Contact = addVo.Contact;
                addDto.Phone = addVo.Phone;
                addDto.IsDefault = addVo.IsDefault;

              int addressId=  await addressService.AddAsync(addDto, customerId);
                return ResultData<int>.Success().AddData("addressId", addressId);

            }
            catch (Exception ex)
            {
                return ResultData<int>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 修改收货地址
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateAddressVo updateVo)
        {
            try
            {
                string token = _tokenReader.GetToken();
                var sessionInfo = _sessionStorage.GetSession(token);
                UpdateAddressDto updateDto = new UpdateAddressDto();
                updateDto.Id = updateVo.Id;
                updateDto.Province = updateVo.Province;
                updateDto.ProvinceCode = updateVo.ProvinceCode;
                updateDto.City = updateVo.City;
                updateDto.CityCode = updateVo.CityCode;
                updateDto.District = updateVo.District;
                updateDto.DistrictCode = updateVo.DistrictCode;
                updateDto.Other = updateVo.Other;
                updateDto.Contact = updateVo.Contact;
                updateDto.Phone = updateVo.Phone;
                updateDto.IsDefault = updateVo.IsDefault;

                await addressService.UpdateAsync(updateDto, sessionInfo.FxCustomerId);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除收货地址
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(int id)
        {
            try
            {
                await addressService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
    }
}
