//using Fx.Amiya.DbModels.Model;
//using Fx.Amiya.Dto;
//using Fx.Amiya.Dto.AmiyaEmployee;
//using Fx.Amiya.Dto.CustomerServiceCheckPerformance.Input;
//using Fx.Amiya.Dto.CustomerServiceCheckPerformance.Result;
//using Fx.Amiya.IDal;
//using Fx.Amiya.IService;
//using Fx.Common;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Fx.Amiya.Service
//{
//    public class CustomerServiceCheckPerformanceService : ICustomerServiceCheckPerformanceService
//    {
//        private readonly IDalCustomerServiceCheckPerformance dalCustomerServiceCheckPerformance;
//        private readonly IAmiyaEmployeeService amiyaEmployeeService;
//        public CustomerServiceCheckPerformanceService(IDalCustomerServiceCheckPerformance dalCustomerServiceCheckPerformance, IAmiyaEmployeeService amiyaEmployeeService)
//        {
//            this.dalCustomerServiceCheckPerformance = dalCustomerServiceCheckPerformance;
//            this.amiyaEmployeeService = amiyaEmployeeService;
//        }



//        /// <summary>
//        /// 根据条件获取助理业绩提点阶梯信息
//        /// </summary>
//        /// <param name="query"></param>
//        /// <returns></returns>
//        public async Task<FxPageInfo<CustomerServiceCheckPerformanceDto>> GetListAsync(QueryCustomerServiceCheckPerformanceDto query)
//        {
//            AmiyaEmployeeDto employeeInfo = new AmiyaEmployeeDto();
//            var customerServiceCheckPerformances = from d in dalCustomerServiceCheckPerformance.GetAll()
//                                                where (string.IsNullOrEmpty(query.KeyWord) || d.Remark.Contains(query.KeyWord))
//                                                && (d.Valid == query.Valid)
//                                                select new CustomerServiceCheckPerformanceDto
//                                                {
//                                                    Id = d.Id,
//                                                    CreateDate = d.CreateDate,
//                                                    UpdateDate = d.UpdateDate,
//                                                    Valid = d.Valid,
//                                                    DeleteDate = d.DeleteDate,
//                                                    CustomerServiceId = d.CustomerServiceId,
//                                                    IsPersonalConfig = d.IsPersonalConfig,
//                                                    PerformanceLowerLimit = d.PerformanceLowerLimit,
//                                                    PerformanceUpperLimit = d.PerformanceUpperLimit,
//                                                    BasePerformance = d.BasePerformance,
//                                                    Year = d.Year,
//                                                    Month = d.Month,
//                                                    Point = d.Point,
//                                                    Remark = d.Remark,
//                                                };
//            FxPageInfo<CustomerServiceCheckPerformanceDto> customerServiceCheckPerformancePageInfo = new FxPageInfo<CustomerServiceCheckPerformanceDto>();
//            customerServiceCheckPerformancePageInfo.TotalCount = await customerServiceCheckPerformances.CountAsync();
//            customerServiceCheckPerformancePageInfo.List = await customerServiceCheckPerformances.OrderByDescending(x => x.CreateDate).Skip((query.PageNum.Value - 1) * query.PageSize.Value).Take(query.PageSize.Value).ToListAsync();
//            foreach (var x in customerServiceCheckPerformancePageInfo.List)
//            {
//                if (x.CustomerServiceId.HasValue)
//                {
//                    var empInfo = await amiyaEmployeeService.GetByIdAsync(x.CustomerServiceId.Value);
//                    x.CustomerServiceName = empInfo.Name;
//                }
//            }
//            return customerServiceCheckPerformancePageInfo;
//        }


//        /// <summary>
//        /// 添加助理业绩提点阶梯
//        /// </summary>
//        /// <param name="addDto"></param>
//        /// <returns></returns>
//        public async Task AddAsync(AddCustomerServiceCheckPerformanceDto addDto)
//        {
//            try
//            {
//                CustomerServiceCheckPerformance customerServiceCheckPerformance = new CustomerServiceCheckPerformance();
//                customerServiceCheckPerformance.Id = Guid.NewGuid().ToString();
//                customerServiceCheckPerformance.CreateDate = DateTime.Now;
//                customerServiceCheckPerformance.Valid = true;
//                customerServiceCheckPerformance.CustomerServiceId = addDto.CustomerServiceId;
//                customerServiceCheckPerformance.IsPersonalConfig = addDto.IsPersonalConfig;
//                customerServiceCheckPerformance.PerformanceLowerLimit = addDto.PerformanceLowerLimit;
//                customerServiceCheckPerformance.PerformanceUpperLimit = addDto.PerformanceUpperLimit;
//                customerServiceCheckPerformance.BasePerformance = addDto.BasePerformance;
//                customerServiceCheckPerformance.Year = addDto.Year;
//                customerServiceCheckPerformance.Month = addDto.Month;
//                customerServiceCheckPerformance.Remark = addDto.Remark;
//                customerServiceCheckPerformance.Point = addDto.Point;
//                await dalCustomerServiceCheckPerformance.AddAsync(customerServiceCheckPerformance, true);

//            }
//            catch (Exception err)
//            {
//                throw new Exception(err.ToString());
//            }
//        }



//        public async Task<CustomerServiceCheckPerformanceDto> GetByIdAsync(string id)
//        {
//            var result = await dalCustomerServiceCheckPerformance.GetAll().Where(x => x.Id == id && x.Valid == true).FirstOrDefaultAsync();
//            if (result == null)
//            {
//                return new CustomerServiceCheckPerformanceDto();
//            }

//            CustomerServiceCheckPerformanceDto returnResult = new CustomerServiceCheckPerformanceDto();
//            returnResult.Id = result.Id;
//            returnResult.CreateDate = result.CreateDate;
//            returnResult.Valid = result.Valid;
//            returnResult.CustomerServiceId = result.CustomerServiceId;
//            returnResult.IsPersonalConfig = result.IsPersonalConfig;
//            returnResult.PerformanceLowerLimit = result.PerformanceLowerLimit;
//            returnResult.PerformanceUpperLimit = result.PerformanceUpperLimit;
//            returnResult.BasePerformance = result.BasePerformance;
//            returnResult.Year = result.Year;
//            returnResult.Month = result.Month;
//            returnResult.Remark = result.Remark;
//            returnResult.Point = result.Point;
//            return returnResult;
//        }

//        /// <summary>
//        /// 修改助理业绩提点阶梯
//        /// </summary>
//        /// <param name="updateDto"></param>
//        /// <returns></returns>
//        public async Task UpdateAsync(UpdateCustomerServiceCheckPerformanceDto updateDto)
//        {
//            var result = await dalCustomerServiceCheckPerformance.GetAll().Where(x => x.Id == updateDto.Id && x.Valid == true).FirstOrDefaultAsync();
//            if (result == null)
//                throw new Exception("未找到助理业绩提点阶梯信息");

//            result.CustomerServiceId = updateDto.CustomerServiceId;
//            result.IsPersonalConfig = updateDto.IsPersonalConfig;
//            result.PerformanceLowerLimit = updateDto.PerformanceLowerLimit;
//            result.PerformanceUpperLimit = updateDto.PerformanceUpperLimit;
//            result.BasePerformance = updateDto.BasePerformance;
//            result.Year = updateDto.Year;
//            result.Month = updateDto.Month;
//            result.Remark = updateDto.Remark;
//            result.Point = updateDto.Point;
//            result.UpdateDate = DateTime.Now;
//            await dalCustomerServiceCheckPerformance.UpdateAsync(result, true);
//        }

//        /// <summary>
//        /// 作废助理业绩提点阶梯
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        public async Task DeleteAsync(string id)
//        {
//            try
//            {
//                var result = await dalCustomerServiceCheckPerformance.GetAll().SingleOrDefaultAsync(e => e.Id == id && e.Valid == true);
//                if (result == null)
//                    throw new Exception("未找到助理业绩提点阶梯信息");
//                result.Valid = false;
//                result.DeleteDate = DateTime.Now;
//                await dalCustomerServiceCheckPerformance.UpdateAsync(result, true);

//            }
//            catch (Exception er)
//            {
//                throw new Exception(er.Message.ToString());
//            }
//        }


//        /// <summary>
//        /// 获取有效的助理业绩提点阶梯信息（下拉框使用）
//        /// </summary>
//        /// <param name="query"></param>
//        /// <returns></returns>
//        public async Task<List<BaseKeyValueDto>> GetValidListAsync()
//        {
//            var customerServiceCheckPerformances = from d in dalCustomerServiceCheckPerformance.GetAll()
//                                                where (d.Valid == true)
//                                                select new BaseKeyValueDto
//                                                {
//                                                    Key = d.Id,
//                                                    Value = d.Remark
//                                                };
//            List<BaseKeyValueDto> customerServiceCheckPerformancePageInfo = new List<BaseKeyValueDto>();
//            customerServiceCheckPerformancePageInfo = await customerServiceCheckPerformances.ToListAsync();
//            return customerServiceCheckPerformancePageInfo;
//        }
//    }
//}
