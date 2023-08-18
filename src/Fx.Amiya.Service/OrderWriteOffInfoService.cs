using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.OrderWriteOffIno;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Infrastructure.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class OrderWriteOffInfoService: IOrderWriteOffInfoService
    {
        private IDalOrderWriteOff _dalOrderWriteOffInfo;
        private IUnitOfWork _unitOfWork;
        private ILogger<OrderService> _logger;
        public OrderWriteOffInfoService(IDalOrderWriteOff dalOrderWriteOffInfo,
            IUnitOfWork unitOfWork,
            ILogger<OrderService> logger)
        {
            _dalOrderWriteOffInfo = dalOrderWriteOffInfo;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        /// <summary>
        /// 新增核销信息
        /// </summary>
        /// <param name="orderWriteOffInfo"></param>
        /// <returns></returns>
        public async Task AddOrderWriteOffInfoAsync(OrderWriteOffInfoAddDto orderWriteOffInfo)
        {
            try
            {
                OrderWriteOffInfo orderWriteOffAddInfo = new OrderWriteOffInfo();
                orderWriteOffAddInfo.Id = Guid.NewGuid().ToString();
                orderWriteOffAddInfo.CreateDate = DateTime.UtcNow;
                orderWriteOffAddInfo.WriteOffOrderId = orderWriteOffInfo.WriteOffOrderId;
                orderWriteOffAddInfo.WriteOffAmount = orderWriteOffInfo.WriteOffAmount;
                orderWriteOffAddInfo.OrderLeaseAmount = orderWriteOffInfo.OrderLeaseAmount;
                orderWriteOffAddInfo.WriteOffGoods = orderWriteOffInfo.WriteOffGoods;
                orderWriteOffAddInfo.HospitalId = orderWriteOffInfo.HospitalId;
                await _dalOrderWriteOffInfo.AddAsync(orderWriteOffAddInfo, true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
