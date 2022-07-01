using Fx.Amiya.IDal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Fx.Amiya.Dto.HospitalCheckPhoneRecord;
using Fx.Infrastructure;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.IService;
using Fx.Common;

namespace Fx.Amiya.Service
{
    public class HospitalCheckPhoneRecordService : IHospitalCheckPhoneRecordService
    {
        private IDalHospitalCheckPhoneRecord dalHospitalCheckPhoneRecord;
        private IDalOrderInfo dalOrderInfo;
        private IDalContentPlatformOrder _dalContentPlatformOrder;
        public HospitalCheckPhoneRecordService(IDalHospitalCheckPhoneRecord dalHospitalCheckPhoneRecord,
            IDalOrderInfo dalOrderInfo,
            IDalContentPlatformOrder dalContentPlatformOrder)
        {
            this.dalHospitalCheckPhoneRecord = dalHospitalCheckPhoneRecord;
            this.dalOrderInfo = dalOrderInfo;
            _dalContentPlatformOrder = dalContentPlatformOrder;
        }

        public async Task<FxPageInfo<HospitalCheckPhoneRecordDto>> GetListWithPageAsync(int? hospitalId, int pageNum, int pageSize)
        {
            var q = from d in dalHospitalCheckPhoneRecord.GetAll()
                    where hospitalId == null || d.HospitalId == hospitalId
                    select new HospitalCheckPhoneRecordDto
                    {
                        Id = d.Id,
                        HospitalId = d.HospitalId,
                        HospitalName = d.HospitalInfo.Name,
                        HospitalEmployeeId = d.HospitalEmployeeId,
                        HospitalEmployeeName = d.HospitalEmployee.Name,
                        OrderId = d.OrderId,
                        Date = d.Date
                    };

            FxPageInfo<HospitalCheckPhoneRecordDto> recordPageInfo = new FxPageInfo<HospitalCheckPhoneRecordDto>();
            recordPageInfo.TotalCount = await q.CountAsync();
            recordPageInfo.List = await q.OrderByDescending(e => e.Date).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return recordPageInfo;
        }



        /// <summary>
        /// 添加正常交易订单的查看电话记录
        /// </summary>
        /// <param name="addDto"></param>
        /// <param name="hospitaId"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task<string> AddAsync(AddHospitalCheckPhoneRecordDto addDto, int hospitaId, int employeeId)
        {
            var order = await dalOrderInfo.GetAll().SingleOrDefaultAsync(e => e.Id == addDto.OrderId);
            if (order == null)
                throw new Exception("订单编号错误");

            var q = await dalHospitalCheckPhoneRecord.GetAll()
                .Where(e => e.HospitalId == hospitaId && e.OrderId == addDto.OrderId)
                .Where(e => e.OrderPlatformType == (byte)CheckPhoneRecordOrderType.TradeOrder)
                .SingleOrDefaultAsync();
            if (q == null)
            {
                HospitalCheckPhoneRecord record = new HospitalCheckPhoneRecord();
                record.OrderId = addDto.OrderId;
                record.Phone = order.Phone;
                record.HospitalId = hospitaId;
                record.HospitalEmployeeId = employeeId;
                record.Date = DateTime.Now;
                record.OrderPlatformType = (byte)CheckPhoneRecordOrderType.TradeOrder;
                await dalHospitalCheckPhoneRecord.AddAsync(record, true);
            }
            return order.Phone;
        }

        /// <summary>
        /// 添加内容平台订单的查看电话记录
        /// </summary>
        /// <param name="addDto"></param>
        /// <param name="hospitaId"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task<string> AddContentPlatformOrderCheckPhoneRecordAsync(AddHospitalCheckPhoneRecordDto addDto, int hospitaId, int employeeId)
        {
            var order = await _dalContentPlatformOrder.GetAll().SingleOrDefaultAsync(e => e.Id == addDto.OrderId);
            if (order == null)
                throw new Exception("内容平台订单编号错误！");

            var q = await dalHospitalCheckPhoneRecord.GetAll()
                .Where(e => e.HospitalId == hospitaId && e.OrderId == addDto.OrderId)
                .Where(e => e.OrderPlatformType == (byte)CheckPhoneRecordOrderType.ContentPlatformOrder)
                .SingleOrDefaultAsync();
            if (q == null)
            {
                HospitalCheckPhoneRecord record = new HospitalCheckPhoneRecord();
                record.OrderId = addDto.OrderId;
                record.Phone = order.Phone;
                record.HospitalId = hospitaId;
                record.HospitalEmployeeId = employeeId;
                record.Date = DateTime.Now;
                record.OrderPlatformType = (byte)CheckPhoneRecordOrderType.ContentPlatformOrder;
                await dalHospitalCheckPhoneRecord.AddAsync(record, true);
            }
            //if (order.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && order.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder))
            //{ 
            //    return order.Phone;
            //}
            //else
            //{
            //    return ServiceClass.GetIncompletePhone(order.Phone);
            //}
            return order.Phone;
        }

    }
}
