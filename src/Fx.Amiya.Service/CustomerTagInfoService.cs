using Fx.Amiya.DbModels.Model;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fx.Infrastructure.DataAccess;
using jos_sdk_net.Util;
using Fx.Amiya.Dto.WareHouse.WareHouseInfo;
using Fx.Amiya.Dto.WareHouse.InventoryList;
using Fx.Amiya.Dto.WareHouse.OutWareHouse;
using Fx.Amiya.Dto.WareHouse.InWareHouse;
using Fx.Amiya.Dto.CustomerTagInfo;
using Fx.Amiya.Dto;

namespace Fx.Amiya.Service
{
    public class CustomerTagInfoService : ICustomerTagInfoService
    {
        private IDalCustomerTagInfo dalCustomerTagInfoService;
        private IInventoryListService inventoryListService;
        private IUnitOfWork unitOfWork;
        private IAmiyaOutWareHouseService amiyaOutWareHouseService;
        private IAmiyaInWareHouseService amiyaInWareHouseService;
        private IDalTagDetailInfo dalTagDetailInfo;
        public CustomerTagInfoService(IDalCustomerTagInfo dalCustomerTagInfoService,
            IInventoryListService inventoryListService,
            IAmiyaInWareHouseService inWareHouseService,
            IAmiyaOutWareHouseService amiyaOutWareHouseService,
            IUnitOfWork unitofWork, IDalTagDetailInfo dalTagDetailInfo)
        {
            this.dalCustomerTagInfoService = dalCustomerTagInfoService;
            this.inventoryListService = inventoryListService;
            this.amiyaOutWareHouseService = amiyaOutWareHouseService;
            this.amiyaInWareHouseService = inWareHouseService;
            this.unitOfWork = unitofWork;
            this.dalTagDetailInfo = dalTagDetailInfo;
        }



        public async Task<FxPageInfo<CustomerTagInfoDto>> GetListWithPageAsync(string keyword,  int pageNum, int pageSize)
        {
            try
            {
                var customerTagInfoService = from d in dalCustomerTagInfoService.GetAll()
                                             where (keyword == null || d.TagName.Contains(keyword))
                                             && (d.Valid == true)
                                             select new CustomerTagInfoDto
                                             {
                                                 Id = d.Id,
                                                 TagName = d.TagName,
                                                 CreateDate = d.CreateDate,
                                                 UpdateDate = d.UpdateDate,
                                                 DeleteDate = d.DeleteDate,
                                                 TagCategory = d.TagCategory,
                                                 TagCategoryName = d.TagCategory==null?"": ServiceClass.GetTagCategoryType(d.TagCategory.Value),
                                                 Valid = d.Valid,
                                             };
                FxPageInfo<CustomerTagInfoDto> customerTagInfoServicePageInfo = new FxPageInfo<CustomerTagInfoDto>();
                customerTagInfoServicePageInfo.TotalCount = await customerTagInfoService.CountAsync();
                customerTagInfoServicePageInfo.List = await customerTagInfoService.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
                return customerTagInfoServicePageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task AddAsync(AddCustomerTagInfoDto addDto)
        {
            try
            {
                CustomerTagInfo customerTagInfoService = new CustomerTagInfo();
                customerTagInfoService.Id = Guid.NewGuid().ToString();
                customerTagInfoService.TagName = addDto.TagName;
                customerTagInfoService.TagCategory = addDto.TagCategory;
                customerTagInfoService.Valid = true;
                customerTagInfoService.CreateDate = DateTime.Now;

                await dalCustomerTagInfoService.AddAsync(customerTagInfoService, true);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CustomerTagInfoDto> GetByIdAsync(string id)
        {
            try
            {
                var customerTagInfoService = await dalCustomerTagInfoService.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (customerTagInfoService == null)
                {
                    return new CustomerTagInfoDto();
                }

                CustomerTagInfoDto customerTagInfoServiceDto = new CustomerTagInfoDto();
                customerTagInfoServiceDto.Id = customerTagInfoService.Id;
                customerTagInfoServiceDto.TagName = customerTagInfoService.TagName;
                customerTagInfoServiceDto.Valid = customerTagInfoService.Valid;
                customerTagInfoServiceDto.CreateDate = customerTagInfoService.CreateDate;
                customerTagInfoServiceDto.UpdateDate = customerTagInfoService.UpdateDate;
                customerTagInfoServiceDto.DeleteDate = customerTagInfoService.DeleteDate;
                customerTagInfoServiceDto.TagCategory = customerTagInfoService.TagCategory;
                customerTagInfoServiceDto.TagCategoryName = customerTagInfoService.TagCategory == null ? "" : ServiceClass.GetTagCategoryType(customerTagInfoService.TagCategory.Value);

                return customerTagInfoServiceDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task UpdateAsync(UpdateCustomerTagInfoDto updateDto)
        {
            try
            {
                var customerTagInfoService = await dalCustomerTagInfoService.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (customerTagInfoService == null)
                    throw new Exception("标签编号错误！");

                customerTagInfoService.TagName = updateDto.TagName;
                customerTagInfoService.UpdateDate = updateDto.UpdateDate;
                customerTagInfoService.Valid = updateDto.Valid;
                customerTagInfoService.TagCategory = updateDto.TagCategory;
                if (updateDto.Valid == false)
                {
                    customerTagInfoService.DeleteDate = DateTime.Now;
                }
                await dalCustomerTagInfoService.UpdateAsync(customerTagInfoService, true);


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
                var customerTagInfoService = await dalCustomerTagInfoService.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (customerTagInfoService == null)
                    throw new Exception("标签编号错误");
                var tag = dalTagDetailInfo.GetAll().Where(e=>e.TagId==id).FirstOrDefault();
                if (tag != null) throw new Exception("该标签已关联商品或用户不能删除");
                await dalCustomerTagInfoService.DeleteAsync(customerTagInfoService, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 获取标签类型列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<BaseKeyValueDto>> GetTagCategoryNameListAsync()
        {
            var consumptionVoucherTypes = Enum.GetValues(typeof(TagCategory));

            List<BaseKeyValueDto> consumptionVoucherTypeList = new List<BaseKeyValueDto>();
            foreach (var item in consumptionVoucherTypes)
            {
                BaseKeyValueDto baseKeyValueDto = new BaseKeyValueDto();
                baseKeyValueDto.Key = Convert.ToInt32(item).ToString();
                baseKeyValueDto.Value = ServiceClass.GetTagCategoryType(Convert.ToInt32(item));
                consumptionVoucherTypeList.Add(baseKeyValueDto);
            }
            return consumptionVoucherTypeList;
        }
        /// <summary>
        /// 获取用户标签名称列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<BaseKeyValueDto>> GetCustomerTagNameList()
        {
            var list = dalCustomerTagInfoService.GetAll().Where(e => e.TagCategory == (int)TagCategory.UserTag&&e.Valid==true).Select(e => new BaseKeyValueDto
            {
                Key = e.Id,
                Value=e.TagName
            }).ToList();
            return list;
        }

        public async Task<List<BaseKeyValueDto>> GetGoodsTagNameListAsync()
        {
            var list = dalCustomerTagInfoService.GetAll().Where(e => e.TagCategory == (int)TagCategory.GoodsTag && e.Valid == true).Select(e => new BaseKeyValueDto
            {
                Key = e.Id,
                Value = e.TagName
            }).ToList();
            return list;
        }
    }
}
