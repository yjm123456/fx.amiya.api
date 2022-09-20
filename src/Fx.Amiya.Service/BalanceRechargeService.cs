using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.Balance;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class BalanceRechargeService : IBalanceRechargeService
    {
        private readonly IDalBalanceRechargeRecord dalBalanceRechargeRecord;

        public BalanceRechargeService(IDalBalanceRechargeRecord dalBalanceRechargeRecord)
        {
            this.dalBalanceRechargeRecord = dalBalanceRechargeRecord;
        }
        /// <summary>
        /// 添加充值记录
        /// </summary>
        /// <param name="rechargeRecordDto"></param>
        /// <returns></returns>
        public async Task<string> AddRechargeRecordAsync(CreateBalanceRechargeRecordDto rechargeRecordDto)
        {
            BalanceRechargeRecord rechargeRecord = new BalanceRechargeRecord {
                Id=rechargeRecordDto.Id,
                CustomerId=rechargeRecordDto.CustomerId,
                ExchangeType=rechargeRecordDto.ExchangeType,
                RechargeAmount=rechargeRecordDto.RechargeAmount,
                Balance=rechargeRecordDto.Balance,
                RechargeDate=rechargeRecordDto.RechargeDate,
                Status=rechargeRecordDto.Status
            };
            await dalBalanceRechargeRecord.AddAsync(rechargeRecord,true);
            return rechargeRecordDto.Id;
        }

      

        /// <summary>
        /// 取消超时未支付的充值订单
        /// </summary>
        /// <returns></returns>
        public async Task CancelUnPayREchargeOrderAsync()
        {
            var list = dalBalanceRechargeRecord.GetAll().Where(e => e.Status == 0 && DateTime.Now > e.RechargeDate.AddMinutes(15)).ToList();
            foreach (var item in list)
            {
                UpdateRechargeRecordStatusDto updateRechargeRecordStatusDto = new UpdateRechargeRecordStatusDto {
                    Id = item.Id,
                    Status = (int)RechargeStatus.Cacncel,
                    OrderId = null,
                    CompleteDate = DateTime.Now
                };
                await UpdateRechargeRecordStatusAsync(updateRechargeRecordStatusDto);
            }
        }

        public async Task<decimal> GetAllAmountAsync(string customerId)
        {
            return dalBalanceRechargeRecord.GetAll().Where(e => e.CustomerId == customerId && e.Status == 1).Sum(e => e.RechargeAmount);
        }

        public async Task<decimal> GetAllRechargeAmountAsync(string customerId)
        {
            return dalBalanceRechargeRecord.GetAll().Where(e=>e.CustomerId==customerId&&e.ExchangeType!=2&&e.Status==1).Sum(e=>e.RechargeAmount);
        }

        /// <summary>
        /// 分页获取充值记录
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="customerid"></param>
        /// <param name="type">1:获取三方支付记录,2:获取退款记录</param>
        /// <returns></returns>
        public async Task<FxPageInfo<BalanceRechargeRecordDto>> GetBalanceRechargeRecordListAsync(int pageNum, int pageSize, string customerid,int? type)
        {
            FxPageInfo<BalanceRechargeRecordDto> fxPageInfo = new FxPageInfo<BalanceRechargeRecordDto>();
            var list = dalBalanceRechargeRecord.GetAll().Where(b => b.CustomerId == customerid);
            if (type==null) {
                list = list.OrderByDescending(b => b.RechargeDate);
            }
            if (type == 1) { 
                list=list.Where(e=>e.ExchangeType!=2).OrderByDescending(b => b.RechargeDate);
            }
            if (type==2) {
                list = list.Where(e => e.ExchangeType == 2).OrderByDescending(b => b.RechargeDate);
            }
            fxPageInfo.TotalCount = list.Count();
            fxPageInfo.List = list.Skip((pageNum - 1) * pageSize).Take(pageSize).Select(b=>new BalanceRechargeRecordDto {
                Id=b.Id,
                ExchageType=b.ExchangeType,
                ExchageTypeText=ServiceClass.GetRechargeExchangeTypeText(b.ExchangeType),
                RechargeAmount=b.RechargeAmount,
                OrderId=b.OrderId,
                RechargeDate=b.RechargeDate,
                StatusText=ServiceClass.GetRechargeStatusText(b.Status),
                Status=b.Status
                
            }).ToList();
            return fxPageInfo;
        }
        /// <summary>
        /// 获取指定支付类型的储值记录
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<List<BalanceRechargeRecordDto>> GetRechargeRecordByExchangeTypeAsync(string customerId,int exchangeType)
        {
            return dalBalanceRechargeRecord.GetAll().Where(e=>e.CustomerId==customerId&&e.Status==1&&e.ExchangeType==exchangeType).Select(b=>new BalanceRechargeRecordDto { 
                RechargeAmount=b.RechargeAmount
            }).ToList();
        }

        /// <summary>
        /// 根据记录id获取充值记录
        /// </summary>
        /// <returns></returns>
        public async Task<BalanceRechargeRecordDto> GetRechargeRecordByIdAsync(string recorId)
        {
            return dalBalanceRechargeRecord.GetAll().Where(e => e.Id == recorId).Select(e => new BalanceRechargeRecordDto {
                Id=e.Id,
                CustomerId=e.CustomerId,
                RechargeAmount=e.RechargeAmount,
                Status=e.Status
            }).SingleOrDefault();
        }
        /// <summary>
        /// 根据充值记录id和用户id获取充值记录
        /// </summary>
        /// <param name="customerid">客户id</param>
        /// <param name="recordid">充值记录id</param>
        /// <returns></returns>
        public async Task<BalanceRechargeRecordDto> GetRechargeRecordByRecordIdAndCustomerIdAsync(string customerid, string recordid)
        {
            return dalBalanceRechargeRecord.GetAll().Where(e => e.CustomerId == customerid && e.Id == recordid).Select(e=>new BalanceRechargeRecordDto { 
                Id=e.Id,
                CustomerId=e.CustomerId,
                ExchageType=e.ExchangeType,
                RechargeAmount=e.RechargeAmount,
                OrderId=e.OrderId,
                RechargeDate=e.RechargeDate,
                Status=e.Status
            }).SingleOrDefault();
        }
        /// <summary>
        /// 获取用户处于正在处理中的充值记录
        /// </summary>
        /// <param name="customerid"></param>
        /// <returns></returns>
        public async Task<BalanceRechargeRecordDto> GetRechargeRecordingAsync(string customerid)
        {
            return dalBalanceRechargeRecord.GetAll().Where(e => e.CustomerId == customerid && e.Status == (int)RechargeStatus.PendingPayment).Select(e=>new BalanceRechargeRecordDto
            { 
                Id=e.Id,
            }).SingleOrDefault();

        }
        /// <summary>
        /// 更新充值记录状态
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        public async Task UpdateRechargeRecordStatusAsync(UpdateRechargeRecordStatusDto update)
        {
            var record = dalBalanceRechargeRecord.GetAll().Where(e=>e.Id==update.Id&&e.OrderId==null).SingleOrDefault();
            if (record == null) throw new Exception("充值状态异常");
            record.Status = update.Status;
            record.OrderId = update.OrderId;
            record.CompleteDate = update.CompleteDate;
            await dalBalanceRechargeRecord.UpdateAsync(record,true);
        }


    }
}
