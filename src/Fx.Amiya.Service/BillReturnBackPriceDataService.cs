using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.Bill;
using Fx.Amiya.Dto.ReconciliationDocuments;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Fx.Infrastructure.DataAccess;
using jos_sdk_net.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class BillReturnBackPriceDataService : IBillReturnBackPriceDataService
    {
        private readonly IDalBillReturnBackPriceData dalBillReturnBackPriceData;

        public BillReturnBackPriceDataService(IDalBillReturnBackPriceData dalBillReturnBackPriceData)
        {
            this.dalBillReturnBackPriceData = dalBillReturnBackPriceData;
        }




        /// <summary>
        /// 根据条件获取发票回款记录信息
        /// </summary>
        /// <param name="startDate">回款时间（起）</param>
        /// <param name="endDate">回款时间（止）</param>
        /// <param name="keyWord">关键词（支持模糊搜索票据单，备注）</param>
        /// <param name="hospitalId">客户id</param>
        /// <param name="returnBackState"></param>
        /// <param name="companyId">回款状态（未回款/回款中/已回款）</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<BillReturnBackPriceDataDto>> GetListAsync(DateTime? startDate, DateTime? endDate, int? hospitalId, int? returnBackState, string companyId, string keyWord, int pageNum, int pageSize)
        {

            var billReturnBackPriceDatas = from d in dalBillReturnBackPriceData.GetAll().Include(x => x.AmiyaEmployee).Include(x => x.HospitalInfo).Include(x => x.CompanyBaseInfo).Include(x => x.BillInfo)
                                           where (string.IsNullOrWhiteSpace(keyWord) || d.BillId.Contains(keyWord) || d.Remark.Contains(keyWord))
                                           && (!hospitalId.HasValue || d.HospitalId == hospitalId.Value)
                                           && (string.IsNullOrEmpty(companyId) || d.CompanyId == companyId)
                                           && (!returnBackState.HasValue || d.ReturnBackState == returnBackState.Value)
                                           && (!startDate.HasValue || d.ReturnBackDate >= startDate.Value)
                                           && (!endDate.HasValue || d.ReturnBackDate < endDate.Value.Date.AddDays(1))
                                           && (d.Valid == true)
                                           select new BillReturnBackPriceDataDto
                                           {
                                               Id = d.Id,
                                               HospitalId = d.HospitalId,
                                               HospitalName = d.HospitalInfo.Name,
                                               CompanyId = d.CompanyId,
                                               CompanyName = d.CompanyBaseInfo.Name,
                                               BillId = d.BillId,
                                               BillPrice = d.BillPrice,
                                               OtherPrice = d.OtherPrice,
                                               ReturnBackPrice = d.ReturnBackPrice,
                                               ReturnBackDate = d.ReturnBackDate,
                                               ReturnBackState = d.ReturnBackState,
                                               ReturnBackStateText = ServiceClass.GetBillReturnBackStateText(d.ReturnBackState),
                                               CreateDate = d.CreateDate,
                                               CreateBy = d.CreateBy,
                                               CreateByEmployeeName = d.AmiyaEmployee.Name,
                                               UpdateDate = d.UpdateDate,
                                               Valid = d.Valid,
                                               Remark = d.Remark,
                                               DeleteDate = d.DeleteDate,
                                           };
            FxPageInfo<BillReturnBackPriceDataDto> billReturnBackPriceDataPageInfo = new FxPageInfo<BillReturnBackPriceDataDto>();
            billReturnBackPriceDataPageInfo.TotalCount = await billReturnBackPriceDatas.CountAsync();
            billReturnBackPriceDataPageInfo.List = await billReturnBackPriceDatas.OrderByDescending(x => x.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return billReturnBackPriceDataPageInfo;
        }

        /// <summary>
        /// 根据条件导出发票回款记录信息
        /// </summary>
        /// <param name="keyWord">关键词（支持模糊搜索票据单，备注）</param>
        /// <param name="hospitalId">客户id</param>
        /// <param name="returnBackState"></param>
        /// <param name="companyId">回款状态（未回款/回款中/已回款）</param>
        /// <returns></returns>
        public async Task<List<BillReturnBackPriceDataDto>> ExportListAsync(DateTime? startDate, DateTime? endDate, int? hospitalId, int? returnBackState, string companyId, string keyWord)
        {

            var billReturnBackPriceDatas = from d in dalBillReturnBackPriceData.GetAll().Include(x => x.AmiyaEmployee).Include(x => x.HospitalInfo).Include(x => x.CompanyBaseInfo).Include(x => x.BillInfo)
                                           where (string.IsNullOrWhiteSpace(keyWord) || d.BillId.Contains(keyWord) || d.Remark.Contains(keyWord))
                                           && (!hospitalId.HasValue || d.HospitalId == hospitalId.Value)
                                           && (string.IsNullOrEmpty(companyId) || d.CompanyId == companyId)
                                           && (!returnBackState.HasValue || d.ReturnBackState == returnBackState.Value)
                                           && (!startDate.HasValue || d.ReturnBackDate >= startDate.Value)
                                           && (!endDate.HasValue || d.ReturnBackDate < endDate.Value.Date.AddDays(1))
                                           && (d.Valid == true)
                                           select new BillReturnBackPriceDataDto
                                           {
                                               Id = d.Id,
                                               HospitalId = d.HospitalId,
                                               HospitalName = d.HospitalInfo.Name,
                                               CompanyId = d.CompanyId,
                                               CompanyName = d.CompanyBaseInfo.Name,
                                               BillId = d.BillId,
                                               BillPrice = d.BillPrice,
                                               OtherPrice = d.OtherPrice,
                                               ReturnBackPrice = d.ReturnBackPrice,
                                               ReturnBackDate = d.ReturnBackDate,
                                               ReturnBackState = d.ReturnBackState,
                                               ReturnBackStateText = ServiceClass.GetBillReturnBackStateText(d.ReturnBackState),
                                               CreateDate = d.CreateDate,
                                               CreateBy = d.CreateBy,
                                               CreateByEmployeeName = d.AmiyaEmployee.Name,
                                               UpdateDate = d.UpdateDate,
                                               Valid = d.Valid,
                                               Remark = d.Remark,
                                               DeleteDate = d.DeleteDate,
                                           };
            List<BillReturnBackPriceDataDto> billReturnBackPriceDataPageInfo = new List<BillReturnBackPriceDataDto>();
            billReturnBackPriceDataPageInfo = await billReturnBackPriceDatas.OrderByDescending(x => x.CreateDate).ToListAsync();
            return billReturnBackPriceDataPageInfo;
        }


        /// <summary>
        /// 添加发票回款记录
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddAsync(AddBillReturnBackPriceDataDto addDto)
        {
            try
            {
                BillReturnBackPriceData billReturnBackPriceData = new BillReturnBackPriceData();
                billReturnBackPriceData.Id = Guid.NewGuid().ToString();
                billReturnBackPriceData.HospitalId = addDto.HospitalId;
                billReturnBackPriceData.CompanyId = addDto.CompanyId;
                billReturnBackPriceData.BillId = addDto.BillId;
                billReturnBackPriceData.BillPrice = addDto.BillPrice;
                billReturnBackPriceData.OtherPrice = addDto.OtherPrice;
                billReturnBackPriceData.ReturnBackPrice = addDto.ReturnBackPrice;
                billReturnBackPriceData.ReturnBackDate = addDto.ReturnBackDate;
                billReturnBackPriceData.ReturnBackState = addDto.ReturnBackState;
                billReturnBackPriceData.CreateBy = addDto.CreateBy;
                billReturnBackPriceData.Remark = addDto.Remark;
                billReturnBackPriceData.CreateDate = DateTime.Now;
                billReturnBackPriceData.Valid = true;
                await dalBillReturnBackPriceData.AddAsync(billReturnBackPriceData, true);
            }
            catch (Exception err)
            {
                throw new Exception(err.ToString());
            }
        }



    }
}
