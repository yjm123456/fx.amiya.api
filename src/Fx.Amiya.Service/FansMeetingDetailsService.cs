﻿using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.FansMeetingDetails.Input;
using Fx.Amiya.Dto.FansMeetingDetails.Result;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class FansMeetingDetailsService : IFansMeetingDetailsService
    {
        private readonly IDalFansMeetingDetails dalFansMeetingDetails;
        public FansMeetingDetailsService(IDalFansMeetingDetails dalFansMeetingDetails)
        {
            this.dalFansMeetingDetails = dalFansMeetingDetails;
        }



        /// <summary>
        /// 根据条件获取粉丝见面会详情信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<FansMeetingDetailsDto>> GetListAsync(QueryFansMeetingDetailsDto query)
        {
            var fansMeetingDetailss = from d in dalFansMeetingDetails.GetAll().Include(x => x.FansMeetingInfo).Include(x => x.AmiyaEmployeeInfo)
                                      where (d.Valid == true && d.FansMeetingId == query.FansMeetingId)
                                      && (string.IsNullOrEmpty(query.KeyWord) || d.Phone.Contains(query.KeyWord))
                                      && (!query.StartDate.HasValue || d.CreateDate >= query.StartDate.Value)
                                      && (!query.EndDate.HasValue || d.CreateDate < query.EndDate.Value.AddDays(1).AddMilliseconds(-1))
                                      select new FansMeetingDetailsDto
                                      {
                                          Id = d.Id,
                                          CreateDate = d.CreateDate,
                                          AmiyaConsulationId = d.AmiyaConsulationId,
                                          AmiyaConsulationName = d.AmiyaEmployeeInfo.Name,
                                          UpdateDate = d.UpdateDate,
                                          Valid = d.Valid,
                                          DeleteDate = d.DeleteDate,
                                          FansMeetingId = d.FansMeetingId,
                                          FansMeetingName = d.FansMeetingInfo.Name,
                                          OrderId = d.OrderId,
                                          AppointmentDate = d.AppointmentDate,
                                          AppointmentDetailsDate = d.AppointmentDetailsDate,
                                          CustomerName = d.CustomerName,
                                          Phone = d.Phone,
                                          CustomerQuantity = d.CustomerQuantity,
                                          CustomerQuantityText = ServiceClass.CustomerQuantityText(d.CustomerQuantity),
                                          IsOldCustomer = d.IsOldCustomer,
                                          HospitalConsulationName = d.HospitalConsulationName,
                                          City = d.City,
                                          TravelInformation = d.TravelInformation,
                                          IsNeedDriver = d.IsNeedDriver,
                                          HotelPlan = d.HotelPlan,
                                          PlanConsumption = d.PlanConsumption,
                                          Remark = d.Remark,
                                          CustomerPictureUrl = d.CustomerPictureUrl,
                                      };
            FxPageInfo<FansMeetingDetailsDto> fansMeetingDetailsPageInfo = new FxPageInfo<FansMeetingDetailsDto>();
            fansMeetingDetailsPageInfo.TotalCount = await fansMeetingDetailss.CountAsync();
            fansMeetingDetailsPageInfo.List = await fansMeetingDetailss.OrderByDescending(x => x.CreateDate).Skip((query.PageNum.Value - 1) * query.PageSize.Value).Take(query.PageSize.Value).ToListAsync();
            return fansMeetingDetailsPageInfo;
        }


        /// <summary>
        /// 添加粉丝见面会详情
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddAsync(AddFansMeetingDetailsDto addDto)
        {
            try
            {
                //查询是否存在该条手机号
                var isExist = await dalFansMeetingDetails.GetAll()
                               .Where(d => d.Valid == true && d.FansMeetingId == addDto.FansMeetingId && d.Phone == addDto.Phone).ToListAsync();
                if (isExist.Count() > 0)
                {
                    throw new Exception("粉丝见面会中已存在该手机号，请重新确认后再添加，手机号：" + addDto.Phone + "！");
                }

                FansMeetingDetails fansMeetingDetails = new FansMeetingDetails();
                fansMeetingDetails.Id = Guid.NewGuid().ToString();
                fansMeetingDetails.CreateDate = DateTime.Now;
                fansMeetingDetails.AmiyaConsulationId = addDto.AmiyaConsulationId;
                fansMeetingDetails.Valid = true;
                fansMeetingDetails.FansMeetingId = addDto.FansMeetingId;
                fansMeetingDetails.OrderId = addDto.OrderId;
                fansMeetingDetails.AppointmentDate = addDto.AppointmentDate;
                fansMeetingDetails.AppointmentDetailsDate = addDto.AppointmentDetailsDate;
                fansMeetingDetails.CustomerName = addDto.CustomerName;
                fansMeetingDetails.Phone = addDto.Phone;
                fansMeetingDetails.CustomerQuantity = addDto.CustomerQuantity;
                fansMeetingDetails.IsOldCustomer = addDto.IsOldCustomer;
                //如果啊美雅助理字段为空则归属给客户池客服
                fansMeetingDetails.AmiyaConsulationId = addDto.AmiyaConsulationId == 0 ? 188 : addDto.AmiyaConsulationId;
                fansMeetingDetails.HospitalConsulationName = addDto.HospitalConsulationName;
                fansMeetingDetails.City = addDto.City;
                fansMeetingDetails.TravelInformation = addDto.TravelInformation;
                fansMeetingDetails.IsNeedDriver = addDto.IsNeedDriver;
                fansMeetingDetails.HotelPlan = addDto.HotelPlan;
                fansMeetingDetails.PlanConsumption = addDto.PlanConsumption;
                fansMeetingDetails.Remark = addDto.Remark;
                fansMeetingDetails.CustomerPictureUrl = addDto.CustomerPictureUrl;
                await dalFansMeetingDetails.AddAsync(fansMeetingDetails, true);

            }
            catch (Exception err)
            {
                throw new Exception(err.ToString());
            }
        }


        public async Task<FansMeetingDetailsDto> GetByIdAsync(string id)
        {
            var result = await dalFansMeetingDetails.GetAll().Include(x => x.FansMeetingInfo).Include(x => x.AmiyaEmployeeInfo).Where(x => x.Id == id && x.Valid == true).FirstOrDefaultAsync();
            if (result == null)
            {
                return new FansMeetingDetailsDto();
            }

            FansMeetingDetailsDto returnResult = new FansMeetingDetailsDto();
            returnResult.Id = result.Id;
            returnResult.CreateDate = result.CreateDate;
            returnResult.AmiyaConsulationId = result.AmiyaConsulationId;
            returnResult.AmiyaConsulationName = result.AmiyaEmployeeInfo.Name;
            returnResult.Valid = result.Valid;
            returnResult.FansMeetingId = result.FansMeetingId;
            returnResult.OrderId = result.OrderId;
            returnResult.AppointmentDate = result.AppointmentDate;
            returnResult.AppointmentDetailsDate = result.AppointmentDetailsDate;
            returnResult.CustomerName = result.CustomerName;
            returnResult.Phone = result.Phone;
            returnResult.CustomerQuantity = result.CustomerQuantity;
            returnResult.IsOldCustomer = result.IsOldCustomer;
            returnResult.AmiyaConsulationId = result.AmiyaConsulationId;
            returnResult.HospitalConsulationName = result.HospitalConsulationName;
            returnResult.City = result.City;
            returnResult.TravelInformation = result.TravelInformation;
            returnResult.IsNeedDriver = result.IsNeedDriver;
            returnResult.HotelPlan = result.HotelPlan;
            returnResult.PlanConsumption = result.PlanConsumption;
            returnResult.Remark = result.Remark;
            returnResult.CustomerPictureUrl = result.CustomerPictureUrl;

            return returnResult;
        }



        /// <summary>
        /// 修改粉丝见面会详情
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateFansMeetingDetailsDto updateDto)
        {
            var result = await dalFansMeetingDetails.GetAll().Where(x => x.Id == updateDto.Id && x.Valid == true).FirstOrDefaultAsync();
            if (result == null)
                throw new Exception("未找到粉丝见面会详情信息");
            var isExist = await dalFansMeetingDetails.GetAll()
                              .Where(d => d.Valid == true && d.FansMeetingId == updateDto.FansMeetingId && d.Phone == updateDto.Phone && d.Id != updateDto.Id).ToListAsync();
            if (isExist.Count() > 0)
            {
                throw new Exception("粉丝见面会中已存在该手机号，请重新确认后再添加！手机号：" + updateDto.Phone);
            }
            result.FansMeetingId = updateDto.FansMeetingId;
            result.OrderId = updateDto.OrderId;
            result.AppointmentDate = updateDto.AppointmentDate;
            result.AppointmentDetailsDate = updateDto.AppointmentDetailsDate;
            result.CustomerName = updateDto.CustomerName;
            result.Phone = updateDto.Phone;
            result.CustomerQuantity = updateDto.CustomerQuantity;
            result.IsOldCustomer = updateDto.IsOldCustomer;
            result.AmiyaConsulationId = updateDto.AmiyaConsulationId;
            result.HospitalConsulationName = updateDto.HospitalConsulationName;
            result.City = updateDto.City;
            result.TravelInformation = updateDto.TravelInformation;
            result.IsNeedDriver = updateDto.IsNeedDriver;
            result.HotelPlan = updateDto.HotelPlan;
            result.PlanConsumption = updateDto.PlanConsumption;
            result.Remark = updateDto.Remark;
            result.CustomerPictureUrl = updateDto.CustomerPictureUrl;
            result.UpdateDate = DateTime.Now;
            await dalFansMeetingDetails.UpdateAsync(result, true);
        }

        /// <summary>
        /// 作废粉丝见面会详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(string id)
        {
            try
            {
                var result = await dalFansMeetingDetails.GetAll().SingleOrDefaultAsync(e => e.Id == id && e.Valid == true);
                if (result == null)
                    throw new Exception("未找到粉丝见面会详情信息");
                result.Valid = false;
                result.DeleteDate = DateTime.Now;
                await dalFansMeetingDetails.UpdateAsync(result, true);

            }
            catch (Exception er)
            {
                throw new Exception(er.Message.ToString());
            }
        }

    }
}