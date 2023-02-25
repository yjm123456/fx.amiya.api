using Fx.Amiya.Dto.FinancialBoard;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class FinancialboardService : IFinancialboardService
    {
        private readonly IContentPlateFormOrderService contentPlateFormOrderService;
        private readonly IOrderService orderService;
        private readonly ICustomerHospitalConsumeService customerHospitalConsumeService;
        private readonly IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService;
        private readonly IDalAmiyaEmployee _dalAmiyaEmployee;
        public FinancialboardService(IContentPlateFormOrderService contentPlateFormOrderService, IOrderService orderService, ICustomerHospitalConsumeService customerHospitalConsumeService, IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService, IDalAmiyaEmployee dalAmiyaEmployee)
        {
            this.contentPlateFormOrderService = contentPlateFormOrderService;
            this.orderService = orderService;
            this.customerHospitalConsumeService = customerHospitalConsumeService;
            this.contentPlatFormOrderDealInfoService = contentPlatFormOrderDealInfoService;
            _dalAmiyaEmployee = dalAmiyaEmployee;
        }

        /// <summary>
        /// 财务看板产出板块主播业绩数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="liveAnchorId"></param>
        /// <returns></returns>
        public async Task<List<LiveAnchorBoardDataDto>> GetBoardLiveAnchorDataAsync(DateTime? startDate, DateTime? endDate, List<int> liveAnchorId)
        {
            startDate = startDate == null ? DateTime.Now.Date : startDate.Value.Date;
            endDate = endDate == null ? DateTime.Now.AddDays(1).Date : endDate.Value.AddDays(1).Date;
            var orderDataList = await orderService.GetLiveAnchorPriceByLiveAnchorIdAsync(startDate, endDate, liveAnchorId);
            var contentPlatFormOrderDealInfoDataList = await contentPlatFormOrderDealInfoService.GetLiveAnchorPriceByLiveAnchorIdAsync(startDate, endDate, liveAnchorId);
            var customerHospitalConsumeDataList = await customerHospitalConsumeService.GetLiveAnchorPriceByLiveAnchorIdAsync(startDate, endDate, liveAnchorId);
            List<LiveAnchorBoardDataDto> liveAnchorBoardDataList = new List<LiveAnchorBoardDataDto>();
            liveAnchorBoardDataList.AddRange(orderDataList);
            liveAnchorBoardDataList.AddRange(contentPlatFormOrderDealInfoDataList);
            liveAnchorBoardDataList.AddRange(customerHospitalConsumeDataList);
            var dataList = liveAnchorBoardDataList.GroupBy(e => new { e.LiveAnchorName, e.CompanyName }).Select(e => new LiveAnchorBoardDataDto
            {
                CompanyName = e.Key.CompanyName,
                LiveAnchorName = e.Key.LiveAnchorName,
                DealPrice = e.Sum(item => item.DealPrice),
                TotalServicePrice = e.Sum(item => item.TotalServicePrice),
                NewCustomerPrice = e.Sum(item => item.NewCustomerPrice),
                NewCustomerServicePrice = e.Sum(item => item.NewCustomerServicePrice),
                OldCustomerPrice = e.Sum(item => item.OldCustomerPrice),
                OldCustomerServicePrice = e.Sum(item => item.OldCustomerServicePrice),
            }).ToList();
            return dataList;
        }
        /// <summary>
        /// 财务看板产出板块客服业绩数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="liveAnchorId"></param>
        /// <returns></returns>
        public async Task<List<CustomerServiceBoardDataDto>> GetBoardCustomerServiceDataAsync(DateTime? startDate, DateTime? endDate, int? customerServiceId)
        {
            startDate = startDate == null ? DateTime.Now.Date : startDate.Value.Date;
            endDate = endDate == null ? DateTime.Now.AddDays(1).Date : endDate.Value.AddDays(1).Date;
            List<CustomerServiceBoardDataDto> liveAnchorBoardDataList = new List<CustomerServiceBoardDataDto>();
            var customerServiceIdList = _dalAmiyaEmployee.GetAll().Where(e => e.IsCustomerService).Select(e => e.Id).ToList();
            foreach (var id in customerServiceIdList)
            {
                var orderData = await orderService.GetCustomerServiceBoardDataByCustomerServiceIdAsync(startDate, endDate, id);
                var contentPlatFormOrderData = await contentPlatFormOrderDealInfoService.GetCustomerServiceBoardDataByCustomerServiceIdAsync(startDate, endDate, id);
                var customerHospitalConsumeData = await customerHospitalConsumeService.GetCustomerServiceBoardDataByCustomerServiceIdAsync(startDate, endDate, id);
                if (orderData != null)
                    liveAnchorBoardDataList.Add(orderData);
                if (contentPlatFormOrderData != null)
                    liveAnchorBoardDataList.Add(contentPlatFormOrderData);
                if (customerHospitalConsumeData != null)
                    liveAnchorBoardDataList.Add(customerHospitalConsumeData);
            }
            var dataList = liveAnchorBoardDataList.GroupBy(e => e.CustomerServiceName).Select(e => new CustomerServiceBoardDataDto
            {
                CustomerServiceName = e.Key,
                DealPrice = e.Sum(item => item.DealPrice),
                TotalServicePrice = e.Sum(item => item.TotalServicePrice),
                NewCustomerPrice = e.Sum(item => item.NewCustomerPrice),
                NewCustomerServicePrice = e.Sum(item => item.NewCustomerServicePrice),
                OldCustomerPrice = e.Sum(item => item.OldCustomerPrice),
                OldCustomerServicePrice = e.Sum(item => item.OldCustomerServicePrice),
            }).ToList();
            return dataList;
        }
        /// <summary>
        /// 财务看板产出板块归属客服业绩数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="liveAnchorId"></param>
        /// <returns></returns>
        public async Task<List<CustomerServiceBoardDataDto>> GetBoardCustomerServiceBelongDataAsync(DateTime? startDate, DateTime? endDate, int? customerServiceId)
        {
            startDate = startDate == null ? DateTime.Now.Date : startDate.Value.Date;
            endDate = endDate == null ? DateTime.Now.AddDays(1).Date : endDate.Value.AddDays(1).Date;
            List<CustomerServiceBoardDataDto> liveAnchorBoardDataList = new List<CustomerServiceBoardDataDto>();
            var customerServiceIdList = _dalAmiyaEmployee.GetAll().Where(e => e.IsCustomerService).Select(e => e.Id).ToList();
            foreach (var id in customerServiceIdList)
            {
                var orderData = await orderService.GetCustomerServiceBoardDataByCustomerServiceIdAsync(startDate, endDate, id);
                var contentPlatFormOrderData = await contentPlatFormOrderDealInfoService.GetCustomerServiceBelongBoardDataByCustomerServiceIdAsync(startDate, endDate, id);
                var customerHospitalConsumeData = await customerHospitalConsumeService.GetCustomerServiceBoardDataByCustomerServiceIdAsync(startDate, endDate, id);
                if (orderData != null)
                    liveAnchorBoardDataList.Add(orderData);
                if (contentPlatFormOrderData != null)
                    liveAnchorBoardDataList.Add(contentPlatFormOrderData);
                if (customerHospitalConsumeData != null)
                    liveAnchorBoardDataList.Add(customerHospitalConsumeData);
            }
            var dataList = liveAnchorBoardDataList.GroupBy(e => e.CustomerServiceName).Select(e => new CustomerServiceBoardDataDto
            {
                CustomerServiceName = e.Key,
                DealPrice = e.Sum(item => item.DealPrice),
                TotalServicePrice = e.Sum(item => item.TotalServicePrice),
                NewCustomerPrice = e.Sum(item => item.NewCustomerPrice),
                NewCustomerServicePrice = e.Sum(item => item.NewCustomerServicePrice),
                OldCustomerPrice = e.Sum(item => item.OldCustomerPrice),
                OldCustomerServicePrice = e.Sum(item => item.OldCustomerServicePrice),
            }).ToList();
            return dataList;
        }
    }
}
