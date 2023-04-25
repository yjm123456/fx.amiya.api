﻿using Fx.Amiya.DbModels.Model;
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
using Fx.Amiya.Dto.CustomerAppointmentSchedule.Result;
using Fx.Amiya.Dto.CustomerAppointmentSchedule.Input;
using Fx.Amiya.Dto;

namespace Fx.Amiya.Service
{
    public class CustomerAppointmentScheduleService : ICustomerAppointmentScheduleService
    {
        private IDalCustomerAppointmentSchedule dalCustomerAppointmentScheduleService;
        private IInventoryListService inventoryListService;
        private IUnitOfWork unitOfWork;
        private IAmiyaOutWareHouseService amiyaOutWareHouseService;
        private IDalAmiyaEmployee _dalAmiyaEmployee;
        private IAmiyaInWareHouseService amiyaInWareHouseService;
        private IDalTagDetailInfo dalTagDetailInfo;
        private IDalHospitalInfo dalHospitalInfo;
        public CustomerAppointmentScheduleService(IDalCustomerAppointmentSchedule dalCustomerAppointmentScheduleService,
            IInventoryListService inventoryListService,
            IAmiyaInWareHouseService inWareHouseService,
           IDalAmiyaEmployee dalAmiyaEmployee,
            IAmiyaOutWareHouseService amiyaOutWareHouseService,
            IUnitOfWork unitofWork, IDalTagDetailInfo dalTagDetailInfo, IDalHospitalInfo dalHospitalInfo)
        {
            this.dalCustomerAppointmentScheduleService = dalCustomerAppointmentScheduleService;
            this.inventoryListService = inventoryListService;
            this.amiyaOutWareHouseService = amiyaOutWareHouseService;
            this.amiyaInWareHouseService = inWareHouseService;
            _dalAmiyaEmployee = dalAmiyaEmployee;
            this.unitOfWork = unitofWork;
            this.dalTagDetailInfo = dalTagDetailInfo;
            this.dalHospitalInfo = dalHospitalInfo;
        }



        public async Task<FxPageInfo<CustomerAppointmentScheduleDto>> GetListWithPageAsync(QueryCustomerAppointSchedulePageListDto query)
        {
            try
            {
                bool selectByCreateEmpInfo = false;
                var employee = await _dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).SingleOrDefaultAsync(e => e.Id == query.CreateBy);
                //非管理员角色只能看到自己的数据
                if (!employee.AmiyaPositionInfo.IsDirector)
                {
                    selectByCreateEmpInfo = true;
                }
                var customerAppointmentScheduleService = from d in dalCustomerAppointmentScheduleService.GetAll().Include(x => x.AmiyaEmployeeInfo).OrderByDescending(x => x.AppointmentDate).ThenByDescending(x => x.ImportantType)
                                                         where (query.KeyWord == null || d.Phone.Contains(query.KeyWord) || d.CustomerName.Contains(query.KeyWord))
                                                         && (selectByCreateEmpInfo == false || d.CreateBy == query.CreateBy)
                                                         && (!query.ImportantType.HasValue || d.ImportantType == query.ImportantType.Value)
                                                         && (!query.AppointmentType.HasValue || d.AppointmentType == query.AppointmentType.Value)
                                                         && (!query.IsFinish.HasValue || d.IsFinish == query.IsFinish.Value)
                                                         && (!query.StartDate.HasValue || d.AppointmentDate >= query.StartDate.Value)
                                                         && (!query.EndDate.HasValue || d.AppointmentDate <= query.EndDate.Value.AddDays(1).AddMilliseconds(-1))
                                                         && (d.Valid == true)
                                                         select new CustomerAppointmentScheduleDto
                                                         {
                                                             Id = d.Id,
                                                             CreateBy = d.CreateBy,
                                                             CreateDate = d.CreateDate,
                                                             UpdateDate = d.UpdateDate,
                                                             DeleteDate = d.DeleteDate,
                                                             Valid = d.Valid,
                                                             CustomerName = d.CustomerName,
                                                             Phone = ServiceClass.GetIncompletePhone(d.Phone),
                                                             AppointmentType = d.AppointmentType,
                                                             AppointmentTypeText = ServiceClass.GetAppointmentTypeText(d.AppointmentType),
                                                             AppointmentDate = d.AppointmentDate,
                                                             IsFinish = d.IsFinish,
                                                             ImportantType = d.ImportantType,
                                                             ImportantTypeText = ServiceClass.GetShopCartRegisterEmergencyLevelText(d.ImportantType),
                                                             Remark = d.Remark,
                                                             CreateByEmpName = d.AmiyaEmployeeInfo.Name,
                                                             AppointmentHospitalId = d.AppointmentHospitalId,
                                                             AppointmentHospitalName = dalHospitalInfo.GetAll().Where(e => e.Id == d.AppointmentHospitalId).Select(e=>e.Name).SingleOrDefault() ?? "",
                                                             Consultation=d.Consultation
                                                         };
                FxPageInfo<CustomerAppointmentScheduleDto> customerAppointmentScheduleServicePageInfo = new FxPageInfo<CustomerAppointmentScheduleDto>();
                customerAppointmentScheduleServicePageInfo.TotalCount = await customerAppointmentScheduleService.CountAsync();
                customerAppointmentScheduleServicePageInfo.List = new List<CustomerAppointmentScheduleDto>();
                if (customerAppointmentScheduleServicePageInfo.TotalCount > 0)
                {
                    customerAppointmentScheduleServicePageInfo.List = await customerAppointmentScheduleService.Skip((query.PageNum.Value - 1) * query.PageSize.Value).Take(query.PageSize.Value).ToListAsync();
                }
                return customerAppointmentScheduleServicePageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<CustomerAppointmentScheduleDto>> GetTodayImportantScheduleAsync()
        {
            try
            {
                DateTime startDate = DateTime.Now.Date;
                DateTime endDate = DateTime.Now.Date.AddDays(1).AddMilliseconds(-1);
                var customerAppointmentScheduleService = from d in dalCustomerAppointmentScheduleService.GetAll()
                                                         where (d.AppointmentDate >= startDate)
                                                         && (d.AppointmentDate <= endDate)
                                                         && (d.ImportantType == (int)EmergencyLevel.Important)
                                                         && (d.Valid == true)
                                                         && (d.IsFinish == false)
                                                         select new CustomerAppointmentScheduleDto
                                                         {
                                                             Id = d.Id,
                                                             CreateBy = d.CreateBy,
                                                             CustomerName = d.CustomerName,
                                                             Phone = ServiceClass.GetIncompletePhone(d.Phone),
                                                             AppointmentTypeText = ServiceClass.GetAppointmentTypeText(d.AppointmentType),
                                                             AppointmentHospitalName = dalHospitalInfo.GetAll().Where(e => e.Id == d.AppointmentHospitalId).Select(e => e.Name).SingleOrDefault() ?? "",
                                                             Consultation=d.Consultation
                                                         };
                List<CustomerAppointmentScheduleDto> customerAppointmentScheduleServicePageInfo = new List<CustomerAppointmentScheduleDto>();
                customerAppointmentScheduleServicePageInfo = await customerAppointmentScheduleService.ToListAsync();
                return customerAppointmentScheduleServicePageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<CustomerAppointmentScheduleDto>> GetListByCalendarAsync(QueryCustomerAppointSchedulePageListDto query)
        {
            try
            {
                bool selectByCreateEmpInfo = false;
                var employee = await _dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).SingleOrDefaultAsync(e => e.Id == query.CreateBy);
                //非管理员角色只能看到自己的数据
                if (!employee.AmiyaPositionInfo.IsDirector)
                {
                    selectByCreateEmpInfo = true;
                }
                var customerAppointmentScheduleService = from d in dalCustomerAppointmentScheduleService.GetAll().Include(x => x.AmiyaEmployeeInfo).OrderBy(x => x.AppointmentDate).ThenByDescending(x => x.ImportantType)
                                                         where (!query.StartDate.HasValue || d.AppointmentDate >= query.StartDate.Value)
                                                         && (!query.EndDate.HasValue || d.AppointmentDate <= query.EndDate.Value.AddDays(1))
                                                         && (selectByCreateEmpInfo == false || d.CreateBy == query.CreateBy)
                                                         && (d.Valid == true)
                                                         select new CustomerAppointmentScheduleDto
                                                         {
                                                             Id = d.Id,
                                                             CreateBy = d.CreateBy,
                                                             CreateDate = d.CreateDate,
                                                             UpdateDate = d.UpdateDate,
                                                             DeleteDate = d.DeleteDate,
                                                             Valid = d.Valid,
                                                             CustomerName = d.CustomerName,
                                                             Phone = ServiceClass.GetIncompletePhone(d.Phone),
                                                             AppointmentType = d.AppointmentType,
                                                             AppointmentTypeText = ServiceClass.GetAppointmentTypeText(d.AppointmentType),
                                                             AppointmentDate = d.AppointmentDate,
                                                             IsFinish = d.IsFinish,
                                                             ImportantType = d.ImportantType,
                                                             ImportantTypeText = ServiceClass.GetShopCartRegisterEmergencyLevelText(d.ImportantType),
                                                             Remark = d.Remark,
                                                             CreateByEmpName = d.AmiyaEmployeeInfo.Name,
                                                             AppointmentHospitalName = dalHospitalInfo.GetAll().Where(e => e.Id == d.AppointmentHospitalId).Select(e => e.Name).SingleOrDefault() ?? "",
                                                             Consultation=d.Consultation
                                                         };


                List<CustomerAppointmentScheduleDto> customerAppointmentScheduleServicePageInfo = new List<CustomerAppointmentScheduleDto>();
                customerAppointmentScheduleServicePageInfo = await customerAppointmentScheduleService.ToListAsync();
                return customerAppointmentScheduleServicePageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task AddAsync(AddCustomerAppointmentScheduleDto addDto)
        {
            try
            {
                CustomerAppointmentSchedule customerAppointmentScheduleService = new CustomerAppointmentSchedule();
                customerAppointmentScheduleService.Id = Guid.NewGuid().ToString();
                customerAppointmentScheduleService.CustomerName = addDto.CustomerName;
                customerAppointmentScheduleService.Phone = addDto.Phone;
                customerAppointmentScheduleService.AppointmentType = addDto.AppointmentType;
                customerAppointmentScheduleService.AppointmentDate = addDto.AppointmentDate;
                customerAppointmentScheduleService.IsFinish = addDto.IsFinish;
                customerAppointmentScheduleService.ImportantType = addDto.ImportantType;
                customerAppointmentScheduleService.Remark = addDto.Remark;
                customerAppointmentScheduleService.Valid = true;
                customerAppointmentScheduleService.CreateDate = DateTime.Now;
                customerAppointmentScheduleService.CreateBy = addDto.CreateBy;
                customerAppointmentScheduleService.AppointmentHospitalId = addDto.AppointmentHospitalId;
                customerAppointmentScheduleService.Consultation = addDto.Consultation;

                await dalCustomerAppointmentScheduleService.AddAsync(customerAppointmentScheduleService, true);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CustomerAppointmentScheduleDto> GetByIdAsync(string id)
        {
            try
            {
                var customerAppointmentScheduleService = await dalCustomerAppointmentScheduleService.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (customerAppointmentScheduleService == null)
                {
                    return new CustomerAppointmentScheduleDto();
                }

                CustomerAppointmentScheduleDto customerAppointmentScheduleServiceDto = new CustomerAppointmentScheduleDto();
                customerAppointmentScheduleServiceDto.Id = customerAppointmentScheduleService.Id;
                customerAppointmentScheduleServiceDto.CustomerName = customerAppointmentScheduleService.CustomerName;
                customerAppointmentScheduleServiceDto.Phone = customerAppointmentScheduleService.Phone;
                customerAppointmentScheduleServiceDto.AppointmentType = customerAppointmentScheduleService.AppointmentType;
                customerAppointmentScheduleServiceDto.AppointmentDate = customerAppointmentScheduleService.AppointmentDate;
                customerAppointmentScheduleServiceDto.IsFinish = customerAppointmentScheduleService.IsFinish;
                customerAppointmentScheduleServiceDto.ImportantType = customerAppointmentScheduleService.ImportantType;
                customerAppointmentScheduleServiceDto.Remark = customerAppointmentScheduleService.Remark;
                customerAppointmentScheduleServiceDto.Valid = customerAppointmentScheduleService.Valid;
                customerAppointmentScheduleServiceDto.CreateDate = customerAppointmentScheduleService.CreateDate;
                customerAppointmentScheduleServiceDto.AppointmentHospitalId = customerAppointmentScheduleService.AppointmentHospitalId;
                customerAppointmentScheduleServiceDto.Consultation = customerAppointmentScheduleService.Consultation;
                customerAppointmentScheduleServiceDto.AppointmentHospitalName = dalHospitalInfo.GetAll().Where(e => e.Id == customerAppointmentScheduleService.AppointmentHospitalId).Select(e => e.Name).SingleOrDefault() ?? "";

                return customerAppointmentScheduleServiceDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task UpdateAsync(UpdateCustomerAppointmentScheduleDto updateDto)
        {
            try
            {
                var customerAppointmentScheduleService = await dalCustomerAppointmentScheduleService.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (customerAppointmentScheduleService == null)
                    throw new Exception("客户预约日程编号错误！");

                customerAppointmentScheduleService.CustomerName = updateDto.CustomerName;
                customerAppointmentScheduleService.Phone = updateDto.Phone;
                customerAppointmentScheduleService.AppointmentType = updateDto.AppointmentType;
                customerAppointmentScheduleService.AppointmentDate = updateDto.AppointmentDate;
                customerAppointmentScheduleService.IsFinish = updateDto.IsFinish;
                customerAppointmentScheduleService.ImportantType = updateDto.ImportantType;
                customerAppointmentScheduleService.Remark = updateDto.Remark;
                customerAppointmentScheduleService.UpdateDate = DateTime.Now;
                customerAppointmentScheduleService.AppointmentHospitalId = updateDto.AppointmentHospitalId;
                customerAppointmentScheduleService.Consultation = updateDto.Consultation;
                await dalCustomerAppointmentScheduleService.UpdateAsync(customerAppointmentScheduleService, true);


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
                var customerAppointmentScheduleService = await dalCustomerAppointmentScheduleService.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (customerAppointmentScheduleService == null)
                    throw new Exception("客户预约日程编号错误");
                await dalCustomerAppointmentScheduleService.DeleteAsync(customerAppointmentScheduleService, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public List<BaseIdAndNameDto> GetAppointmentTypeList()
        {
            var appointmentTypes = Enum.GetValues(typeof(AppointmentType));
            List<BaseIdAndNameDto> appointmentTypeList = new List<BaseIdAndNameDto>();
            foreach (var item in appointmentTypes)
            {
                BaseIdAndNameDto appointmentType = new BaseIdAndNameDto();
                appointmentType.Id = Convert.ToInt32(item).ToString();
                appointmentType.Name = ServiceClass.GetAppointmentTypeText(Convert.ToByte(item));
                appointmentTypeList.Add(appointmentType);
            }
            return appointmentTypeList;
        }
        /// <summary>
        /// 完成客户预约日程
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="type">预约类型</param>
        /// <returns></returns>
        public async Task UpdateAppointmentCompleteStatusAsync(string phone, int type)
        {
            var list= dalCustomerAppointmentScheduleService.GetAll().Where(e => e.Phone == phone && e.AppointmentType == type).ToList();
            foreach (var item in list)
            {
                item.IsFinish = true;
                dalCustomerAppointmentScheduleService.Update(item, true);
            }

        }
    }
}
