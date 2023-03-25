
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.UnCheckOrder;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Fx.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class UnCheckOrderService : IUnCheckOrderService
    {
        private IDalUnCheckOrder _dalUnCheckOrder;
        private IHospitalInfoService hospitalInfoService;
        private IUnitOfWork unitOfWork;
        public UnCheckOrderService(IDalUnCheckOrder dalUnCheckOrder,
            IHospitalInfoService hospitalInfoService,
            IUnitOfWork unitOfWork)
        {
            _dalUnCheckOrder = dalUnCheckOrder;
            this.hospitalInfoService = hospitalInfoService;
            this.unitOfWork = unitOfWork;
        }
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="startDate">创建开始时间</param>
        /// <param name="endDate">创建结束时间</param>
        /// <param name="isSubmitReconciliationDocuments">是否上传对账单</param>
        /// <param name="orderFrom">订单来源</param>
        /// <param name="hospitalId">指派医院</param>
        /// <param name="keyword">关键字（订单号，手机号）</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<UnCheckOrderDto>> GetListByPageAsync(DateTime? startDate, DateTime? endDate, bool? isSubmitReconciliationDocuments, int? orderFrom, int? hospitalId, string keyword, int pageNum, int pageSize)
        {
            if (endDate.HasValue)
            {
                endDate = endDate.Value.Date.AddDays(1);
            }
            var record = _dalUnCheckOrder.GetAll().Include(x => x.UnCheckOrderCreateBy)
                .Where(e => (string.IsNullOrEmpty(keyword) || e.Phone.Contains(keyword) || e.OrderId.Contains(keyword)))
                .Where(e => !isSubmitReconciliationDocuments.HasValue || e.IsSubmitReconciliationDocuments == isSubmitReconciliationDocuments.Value)
                .Where(e => !startDate.HasValue || e.CreateDate >= startDate)
                .Where(e => !endDate.HasValue || e.CreateDate <= endDate.Value.AddDays(1))
                .Where(e => !orderFrom.HasValue || e.OrderFrom == orderFrom.Value)
                .Where(e => !hospitalId.HasValue || e.SendHospital == hospitalId.Value)
                .OrderByDescending(x => x.CreateDate)
                .Where(e => e.Valid == true)
                .Select(e => new UnCheckOrderDto
                {
                    Id = e.Id,
                    OrderId = e.OrderId,
                    OrderFrom = e.OrderFrom,
                    OrderFromText = ServiceClass.GetOrderFromText(e.OrderFrom),
                    Phone = e.Phone,
                    DealDate = e.DealDate,
                    DealPrice = e.DealPrice,
                    InformationPricePercent = e.InformationPricePercent,
                    SystemUpdatePercent = e.SystemUpdatePercent,
                    InformationPrice = e.InformationPrice,
                    SystemUpdatePrice = e.SystemUpdatePrice,
                    ReturnBackPrice = e.ReturnBackPrice,
                    IsSubmitReconciliationDocuments = e.IsSubmitReconciliationDocuments,
                    IsSubmitReconciliationDocumentsText = e.IsSubmitReconciliationDocuments == true ? "已上传" : "未上传",
                    SendHospital = e.SendHospital,
                    CreateBy = e.CreateBy,
                    CreateDate = e.CreateDate,
                    CreateByName = e.UnCheckOrderCreateBy.Name,
                });
            FxPageInfo<UnCheckOrderDto> fxPageInfo = new FxPageInfo<UnCheckOrderDto>();
            fxPageInfo.TotalCount = await record.CountAsync();
            fxPageInfo.List = await record.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            foreach (var x in fxPageInfo.List)
            {
                if (x.SendHospital.HasValue)
                {
                    var hospitalInfo = await hospitalInfoService.GetByIdAsync(x.SendHospital.Value);
                    x.SendHospitalName = hospitalInfo.Name;
                }
            }
            return fxPageInfo;
        }

        public async Task AddListAsync(List<AddUnCheckOrderDto> addUnCheckOrderDtoList)
        {
            unitOfWork.BeginTransaction();
            try
            {

                foreach (var addUnCheckOrderDto in addUnCheckOrderDtoList)
                {
                    UnCheckOrder unCheckOrder = new UnCheckOrder();
                    unCheckOrder.Id = Guid.NewGuid().ToString();
                    unCheckOrder.OrderId = addUnCheckOrderDto.OrderId;
                    unCheckOrder.OrderFrom = addUnCheckOrderDto.OrderFrom;
                    unCheckOrder.Phone = addUnCheckOrderDto.Phone;
                    unCheckOrder.DealDate = addUnCheckOrderDto.DealDate;
                    unCheckOrder.DealPrice = addUnCheckOrderDto.DealPrice;
                    unCheckOrder.InformationPricePercent = addUnCheckOrderDto.InformationPricePercent;
                    unCheckOrder.SystemUpdatePercent = addUnCheckOrderDto.SystemUpdatePercent;
                    unCheckOrder.InformationPrice = addUnCheckOrderDto.InformationPrice;
                    unCheckOrder.SystemUpdatePrice = addUnCheckOrderDto.SystemUpdatePrice;
                    unCheckOrder.ReturnBackPrice = addUnCheckOrderDto.ReturnBackPrice;
                    unCheckOrder.IsSubmitReconciliationDocuments = false;
                    unCheckOrder.CreateBy = addUnCheckOrderDto.CreateBy;
                    unCheckOrder.Valid = true;
                    unCheckOrder.CreateDate = DateTime.Now;
                    await _dalUnCheckOrder.AddAsync(unCheckOrder, true);
                }
                unitOfWork.Commit();
            }
            catch (Exception err)
            {
                unitOfWork.RollBack();
                throw err;
            }
        }

        public async Task<UnCheckOrderDto> GetByIdAsync(string id)
        {
            var selectResult = await _dalUnCheckOrder.GetAll().Where(x => x.Id == id).FirstOrDefaultAsync();
            if (selectResult == null)
            {
                throw new Exception("未找到未上传订单数据，请重新获取！");
            }
            UnCheckOrderDto result = new UnCheckOrderDto();
            result.Id = selectResult.Id;
            result.OrderId = selectResult.OrderId;
            result.OrderFrom = selectResult.OrderFrom;
            result.Phone = selectResult.Phone;
            result.DealDate = selectResult.DealDate;
            result.DealPrice = selectResult.DealPrice;
            result.InformationPricePercent = selectResult.InformationPricePercent;
            result.SystemUpdatePercent = selectResult.SystemUpdatePercent;
            result.InformationPrice = selectResult.InformationPrice;
            result.SystemUpdatePrice = selectResult.SystemUpdatePrice;
            result.ReturnBackPrice = selectResult.ReturnBackPrice;
            result.IsSubmitReconciliationDocuments = selectResult.IsSubmitReconciliationDocuments;
            return result;
        }


        public async Task<List<UnCheckOrderDto>> GetByPhoneAsync(string phone, int sendHospital)
        {
            List<UnCheckOrderDto> unCheckOrderDtos = new List<UnCheckOrderDto>();
            var selectResult = await _dalUnCheckOrder.GetAll().Where(x => x.Phone == phone && x.Valid == true && x.SendHospital == sendHospital && x.IsSubmitReconciliationDocuments == false).ToListAsync();
            if (selectResult == null)
            {
                return unCheckOrderDtos;
            }
            foreach (var x in selectResult)
            {

                UnCheckOrderDto result = new UnCheckOrderDto();
                result.Id = x.Id;
                result.OrderId = x.OrderId;
                result.OrderFrom = x.OrderFrom;
                result.Phone = x.Phone;
                result.DealDate = x.DealDate;
                result.DealPrice = x.DealPrice;
                result.InformationPricePercent = x.InformationPricePercent;
                result.SystemUpdatePercent = x.SystemUpdatePercent;
                result.InformationPrice = x.InformationPrice;
                result.SystemUpdatePrice = x.SystemUpdatePrice;
                result.ReturnBackPrice = x.ReturnBackPrice;
                unCheckOrderDtos.Add(result);
            }
            return unCheckOrderDtos;
        }

        public async Task UpdateAsync(UpdateUnCheckOrderDto updateUnCheckOrderDto)
        {
            var result = await _dalUnCheckOrder.GetAll().Where(x => x.Id == updateUnCheckOrderDto.Id).FirstOrDefaultAsync();
            if (result == null)
            {
                throw new Exception("未找到未上传订单数据，请重新获取！");
            }
            result.InformationPricePercent = updateUnCheckOrderDto.InformationPricePercent;
            result.SystemUpdatePercent = updateUnCheckOrderDto.SystemUpdatePercent;
            result.InformationPrice = updateUnCheckOrderDto.InformationPrice;
            result.SystemUpdatePrice = updateUnCheckOrderDto.SystemUpdatePrice;
            result.ReturnBackPrice = updateUnCheckOrderDto.ReturnBackPrice;
            result.IsSubmitReconciliationDocuments = updateUnCheckOrderDto.IsSubmitReconciliationDocuments;
            result.UpdateDate = DateTime.Now;
            await _dalUnCheckOrder.UpdateAsync(result, true);
        }


        /// <summary>
        /// 根据id集合指派医院
        /// </summary>
        /// <param name="unCheckOrderSendToHospitalDto"></param>
        /// <returns></returns>
        public async Task SendToHospitalByIdListAsync(UnCheckOrderSendToHospitalDto unCheckOrderSendToHospitalDto)
        {
            unitOfWork.BeginTransaction();
            try
            {
                foreach (var k in unCheckOrderSendToHospitalDto.idList)
                {

                    var result = await _dalUnCheckOrder.GetAll().Where(x => x.Id == k).FirstOrDefaultAsync();

                    result.SendHospital = unCheckOrderSendToHospitalDto.HospitalId;
                    await _dalUnCheckOrder.UpdateAsync(result, true);
                }
                unitOfWork.Commit();
            }
            catch (Exception err)
            {
                unitOfWork.RollBack();
                throw err;
            }
        }

        /// <summary>
        /// 医院上传对账单时更新未上传对账单数据
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public async Task UpdateIsSubmitByIdListAsync(List<string> idList)
        {
            try
            {
                foreach (var k in idList)
                {

                    var result = await _dalUnCheckOrder.GetAll().Where(x => x.Id == k).ToListAsync();
                    if (result.Count() == 0)
                    {
                        continue;
                    }
                    foreach (var u in result)
                    {
                        u.IsSubmitReconciliationDocuments = true;
                        await _dalUnCheckOrder.UpdateAsync(u, true);
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public async Task DeleteAsync(List<string> idList)
        {
            unitOfWork.BeginTransaction();
            try
            {
                foreach (var k in idList)
                {

                    var result = await _dalUnCheckOrder.GetAll().Where(x => x.Id == k).FirstOrDefaultAsync();
                    if (result == null)
                    {
                        continue;
                    }
                    result.Valid = false;
                    await _dalUnCheckOrder.UpdateAsync(result, true);
                }
                unitOfWork.Commit();
            }
            catch (Exception err)
            {
                unitOfWork.RollBack();
                throw err;
            }
        }
    }
}
