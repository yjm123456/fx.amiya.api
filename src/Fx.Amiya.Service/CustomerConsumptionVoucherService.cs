using Fx.Amiya.Core.Dto.Goods;
using Fx.Amiya.Core.Dto.MemberCard;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.ConsumptionVoucher;
using Fx.Amiya.Dto.GoodsConsumptionVoucher;
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
    /// <summary>
    /// 用户抵用券
    /// </summary>
    public class CustomerConsumptionVoucherService : ICustomerConsumptionVoucherService
    {
        private readonly IDalCustomerConsumptionVoucher dalCustomerConsumptionVoucher;
        private readonly IDalConsumptionVoucher dalConsumptionVoucher;
        private readonly IConsumptionVoucherService consumptionVoucherService;
        private readonly IMemberCardHandleService memberCardHandleService;
        private readonly IDalGoodsConsumptionVoucher dalGoodsConsumptionVoucher;

        private readonly IUnitOfWork unitOfWork;

        public CustomerConsumptionVoucherService(IDalCustomerConsumptionVoucher dalCustomerConsumptionVoucher, IDalConsumptionVoucher dalConsumptionVoucher, IConsumptionVoucherService consumptionVoucherService, IUnitOfWork unitOfWork, IMemberCardHandleService memberCardHandleService, IDalGoodsConsumptionVoucher dalGoodsConsumptionVoucher)
        {
            this.dalCustomerConsumptionVoucher = dalCustomerConsumptionVoucher;
            this.dalConsumptionVoucher = dalConsumptionVoucher;
            this.consumptionVoucherService = consumptionVoucherService;
            this.unitOfWork = unitOfWork;
            this.memberCardHandleService = memberCardHandleService;
            this.dalGoodsConsumptionVoucher = dalGoodsConsumptionVoucher;
        }
        /// <summary>
        /// 给用户添加新的抵用券
        /// </summary>
        /// <param name="addCustomerConsumption"></param>
        /// <returns></returns>
        public async Task AddAsyn(AddCustomerConsumptionVoucherDto addCustomerConsumption)
        {
            var voucher = await consumptionVoucherService.GetConsumptionVoucherByCodeAsync(addCustomerConsumption.ConsumptionVoucherCode);
            if (voucher == null) throw new Exception("抵用券不存在");
            CustomerConsumptionVoucher customerConsumptionVoucher = new CustomerConsumptionVoucher
            {
                Id = CreateOrderIdHelper.GetNextNumber(),
                CustomerId = addCustomerConsumption.CustomerId,
                ConsumptionVoucherId = voucher.Id,
                ExpireDate = DateTime.Now.AddDays((double)voucher.EffectiveTime),
                IsUsed = false,
                IsExpire = false,
                CreateDate = DateTime.Now,
                UseDate = null,
                WriteOfCode = addCustomerConsumption.WriteOfCode,
                Source = addCustomerConsumption.Source
            };
            await dalCustomerConsumptionVoucher.AddAsync(customerConsumptionVoucher, true);
        }

        /// <summary>
        /// 分页获取用户抵用券列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="customerId"></param>
        /// <param name="isUsed">筛选是否已用</param>
        /// <returns></returns>

        public async Task<FxPageInfo<CustomerConsumptioVoucherInfoDto>> GetCustomerConsumptionVoucherListAsync(int pageNum, int pageSize, string customerId, int? type)
        {
            FxPageInfo<CustomerConsumptioVoucherInfoDto> fxPageInfo = new FxPageInfo<CustomerConsumptioVoucherInfoDto>();
            var list = from ccv in dalCustomerConsumptionVoucher.GetAll()
                       join cv in dalConsumptionVoucher.GetAll() on ccv.ConsumptionVoucherId equals cv.Id
                       where ccv.CustomerId == customerId
                       orderby cv.Type, cv.DeductMoney, ccv.CreateDate descending
                       select new CustomerConsumptioVoucherInfoDto
                       {
                           Id = ccv.Id,
                           CustomerId = ccv.CustomerId,
                           ConsumptionVoucherName = cv.Name,
                           DeductMoney = cv.DeductMoney,
                           IsShare = cv.IsShare,
                           IsSpecifyProduct = cv.IsSpecifyProduct,
                           ConsumptionVoucherId = ccv.ConsumptionVoucherId,
                           IsUsed = ccv.IsUsed,
                           CreateDate = ccv.CreateDate,
                           Source = ccv.Source,
                           Type = cv.Type,
                           WriteOfCode = ccv.WriteOfCode,
                           IsExpire = ccv.IsExpire,
                           ExpireDate = ccv.ExpireDate,
                           Remark=cv.Remark
                       };
            //未使用
            if (type == 1)
            {
                list = list.Where(e => e.IsUsed == false && e.IsExpire == false && e.ExpireDate > DateTime.Now);
            }
            //已使用
            if (type == 2)
            {
                list = list.Where(e => e.IsUsed == true);
            }
            //已过期
            if (type == 3)
            {
                list = list.Where(e => e.IsExpire == true || e.ExpireDate < DateTime.Now);
            }
            fxPageInfo.TotalCount = await list.CountAsync();
            fxPageInfo.List = list.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            return fxPageInfo;
        }
        /// <summary>
        /// 获取当前商品可用的抵用券
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="isUsed">是否使用</param>
        /// <param name="goodsId">商品id</param>
        /// <returns></returns>
        public async Task<List<CustomerConsumptioVoucherInfoDto>> GetAllCustomerConsumptionVoucherListAsync(string customerId, bool? isUsed, string goodsId)
        {
            FxPageInfo<CustomerConsumptioVoucherInfoDto> fxPageInfo = new FxPageInfo<CustomerConsumptioVoucherInfoDto>();
            var list = from ccv in dalCustomerConsumptionVoucher.GetAll()
                       join cv in dalConsumptionVoucher.GetAll() on ccv.ConsumptionVoucherId equals cv.Id
                       join gv in dalGoodsConsumptionVoucher.GetAll() on cv.Id equals gv.ConsumptionVoucherId 
                       where ccv.CustomerId == customerId && (isUsed == null || ccv.IsUsed == isUsed) && (cv.Type == 0||cv.Type==4) && ccv.IsExpire == false && ccv.ExpireDate > DateTime.Now && ccv.ConsumptionVoucherId == gv.ConsumptionVoucherId && gv.GoodsId == goodsId 
                       orderby cv.DeductMoney descending
                       select new CustomerConsumptioVoucherInfoDto
                       {
                           Id = ccv.Id,
                           CustomerId = ccv.CustomerId,
                           ConsumptionVoucherName = cv.Name,
                           DeductMoney = cv.DeductMoney,
                           IsShare = cv.IsShare,
                           IsSpecifyProduct = cv.IsSpecifyProduct,
                           ConsumptionVoucherId = ccv.ConsumptionVoucherId,
                           IsUsed = ccv.IsUsed,
                           CreateDate = ccv.CreateDate,
                           Source = ccv.Source,
                           Type = cv.Type,
                           WriteOfCode = ccv.WriteOfCode
                       };
            return await list.ToListAsync();
        }


        /// <summary>
        /// 白金会员发放抵用券
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="source">抵用券来源 0会员赠送,1分享,2每月领取</param>
        /// <returns></returns>
        public async Task MEIYAWhiteCardMemberSendVoucherAsync(string customerId, int source)
        {
            try
            {
                AddCustomerConsumptionVoucherDto thirty = new AddCustomerConsumptionVoucherDto
                {
                    CustomerId = customerId,
                    ConsumptionVoucherCode = ConsumptionVoucherCode.ThirtyDeductVoucher,
                    ExpireDate = DateTimeUtil.GetNextMonthFirstDay(),
                    Source = source
                };
                AddCustomerConsumptionVoucherDto fifty = new AddCustomerConsumptionVoucherDto
                {
                    CustomerId = customerId,
                    ConsumptionVoucherCode = ConsumptionVoucherCode.FiftyDeductVoucher,
                    ExpireDate = DateTimeUtil.GetNextMonthFirstDay(),
                    Source = source
                };
                //如果是会员赠送,赠送面诊抵用券,否则不赠送
                if (source == 0)
                {
                    Random random = new Random();
                    AddCustomerConsumptionVoucherDto photoFaceToFace = new AddCustomerConsumptionVoucherDto
                    {
                        CustomerId = customerId,
                        ConsumptionVoucherCode = ConsumptionVoucherCode.PhotoFaceToFace,
                        WriteOfCode = random.Next().ToString().Substring(0, 8),
                        ExpireDate = DateTime.Now.AddYears(1)
                    };
                    await AddAsyn(photoFaceToFace);
                }
                for (int i = 0; i < 3; i++)
                {
                    await AddAsyn(thirty);
                }
                for (int i = 0; i < 3; i++)
                {
                    await AddAsyn(fifty);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("赠送抵用券失败");
            }
        }

        /// <summary>
        /// 用户绑定赠送抵用券
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="source">抵用券来源 0会员赠送,1分享,2每月领取,3新用户赠送</param>
        /// <returns></returns>
        public async Task NewCustomerSendVoucherAsync(string customerId)
        {
            try
            {
                //50元优惠券
                AddCustomerConsumptionVoucherDto fifty = new AddCustomerConsumptionVoucherDto
                {
                    CustomerId = customerId,
                    ConsumptionVoucherCode = ConsumptionVoucherCode.FiftyDeductVoucher,
                    ExpireDate = DateTime.Now.AddDays(30),
                    Source = 3
                };
                /*AddCustomerConsumptionVoucherDto twenty = new AddCustomerConsumptionVoucherDto
                {
                    CustomerId = customerId,
                    ConsumptionVoucherCode = ConsumptionVoucherCode.TwentyDeductVoucher,
                    ExpireDate = DateTimeUtil.GetNextMonthFirstDay(),
                    Source = 3
                };*/
                await AddAsyn(fifty);
            }
            catch (Exception ex)
            {
                throw new Exception("赠送抵用券失败");
            }
        }

        /// <summary>
        /// 普通会员发放抵用券
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="source">抵用券来源 0会员赠送,1分享,2每月领取</param>
        /// <returns></returns>
        public async Task OrdinaryMemberSendVoucherAsync(string customerId, int source)
        {
            try
            {
                AddCustomerConsumptionVoucherDto ten = new AddCustomerConsumptionVoucherDto
                {
                    CustomerId = customerId,
                    ConsumptionVoucherCode = ConsumptionVoucherCode.ThirtyDeductVoucher,
                    ExpireDate = DateTimeUtil.GetNextMonthFirstDay(),
                    Source = source
                };
                AddCustomerConsumptionVoucherDto twenty = new AddCustomerConsumptionVoucherDto
                {
                    CustomerId = customerId,
                    ConsumptionVoucherCode = ConsumptionVoucherCode.TwentyDeductVoucher,
                    ExpireDate = DateTimeUtil.GetNextMonthFirstDay(),
                    Source = source
                };
                await AddAsyn(ten);
                await AddAsyn(twenty);
            }
            catch (Exception ex)
            {
                throw new Exception("赠送抵用券失败");
            }
        }

        /// <summary>
        /// 黑金会员发放抵用券
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="source">抵用券来源 0会员赠送,1分享,2每月领取</param>
        /// <returns></returns>
        public async Task BlackCardMemberSendVoucherAsync(string customerId, int source)
        {
            try
            {

                AddCustomerConsumptionVoucherDto fifty = new AddCustomerConsumptionVoucherDto
                {
                    CustomerId = customerId,
                    ConsumptionVoucherCode = ConsumptionVoucherCode.FiftyDeductVoucher,
                    ExpireDate = DateTimeUtil.GetNextMonthFirstDay(),
                    Source = source
                };
                AddCustomerConsumptionVoucherDto oneHundred = new AddCustomerConsumptionVoucherDto
                {
                    CustomerId = customerId,
                    ConsumptionVoucherCode = ConsumptionVoucherCode.OneHundredDeductVoucher,
                    ExpireDate = DateTimeUtil.GetNextMonthFirstDay(),
                    Source = source
                };
                //如果是会员赠送,赠送面诊抵用券,否则不赠送
                if (source == 0)
                {
                    Random random = new Random();
                    AddCustomerConsumptionVoucherDto videoFaceToFace = new AddCustomerConsumptionVoucherDto
                    {
                        CustomerId = customerId,
                        ConsumptionVoucherCode = ConsumptionVoucherCode.VideoFaceToFace,
                        WriteOfCode = random.Next().ToString().Substring(0, 8),
                        ExpireDate = DateTime.Now.AddYears(1)
                    };
                    await AddAsyn(videoFaceToFace);
                }

                for (int i = 0; i < 3; i++)
                {
                    await AddAsyn(fifty);
                }
                for (int i = 0; i < 3; i++)
                {
                    await AddAsyn(oneHundred);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("赠送抵用券失败");
            }
        }

        public async Task ShareCustomerConsumptionVoucherAsync(ShareCustomerConsumptionVoucherDto shareCustomerConsumption)
        {

            try
            {
                unitOfWork.BeginTransaction();
                var customerVoucher = await dalCustomerConsumptionVoucher.GetAll().Where(e => e.Id == shareCustomerConsumption.CustomerConsumptionVocherId).SingleOrDefaultAsync();
                var voucher = await dalConsumptionVoucher.GetAll().Where(e => e.Id == customerVoucher.ConsumptionVoucherId).SingleOrDefaultAsync();
                if (customerVoucher.Source == 1) throw new Exception("抵用券不能多次分享");
                if (!voucher.IsShare) throw new Exception("该抵用券不能够被分享");
                if (voucher == null) throw new Exception("抵用券不存在");
                if (shareCustomerConsumption.CustomerId == customerVoucher.CustomerId) throw new Exception("自己不能领取自己分享的抵用券");
                if (customerVoucher.IsUsed == true) throw new Exception("该抵用券已被使用,无法领取!");
                if (customerVoucher.IsExpire || customerVoucher.ExpireDate <= DateTime.Now) throw new Exception("该抵用券已过期");
                //修改被分享抵用券状态
                UpdateCustomerConsumptionVoucherDto updateCustomerConsumption = new UpdateCustomerConsumptionVoucherDto
                {
                    CustomerVoucherId = customerVoucher.Id,
                    IsUsed = true,
                    UseDate = DateTime.Now
                };
                await UpdateCustomerConsumptionVoucherUseStatusAsync(updateCustomerConsumption);
                AddCustomerConsumptionVoucherDto addCustomerVoucher = new AddCustomerConsumptionVoucherDto
                {
                    CustomerId = shareCustomerConsumption.CustomerId,
                    ConsumptionVoucherCode = voucher.ConsumptionVoucherCode,
                    ExpireDate = DateTimeUtil.GetNextMonthFirstDay(),
                    ShareBy = shareCustomerConsumption.ShareCustomerId
                };
                //领取人添加新抵用券
                await ReceiveShareConsumptionVoucherAsync(addCustomerVoucher);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;

            }

        }

        public async Task UpdateCustomerConsumptionVoucherUseStatusAsync(UpdateCustomerConsumptionVoucherDto updateUseStateDto)
        {
            var customerVoucher = await dalCustomerConsumptionVoucher.GetAll().Where(e => e.Id == updateUseStateDto.CustomerVoucherId).SingleOrDefaultAsync();
            if (customerVoucher == null) throw new Exception("抵用券不存在");
            if (!customerVoucher.IsUsed || !updateUseStateDto.IsUsed)
            {
                customerVoucher.IsUsed = updateUseStateDto.IsUsed;
                customerVoucher.UseDate = updateUseStateDto.UseDate;
                await dalCustomerConsumptionVoucher.UpdateAsync(customerVoucher, true);
            }
            else
            {
                throw new Exception("该抵用券已被使用");
            }
        }
        /// <summary>
        /// 用户领取分享的抵用券
        /// </summary>
        /// <param name="customerId">领取人id</param>
        /// <param name="voucherCode">抵用券编码</param>
        /// <param name="shareBy">分享人</param>
        /// <returns></returns>
        public async Task ReceiveShareConsumptionVoucherAsync(AddCustomerConsumptionVoucherDto addCustomerConsumptionVoucher)
        {
            var voucher = await consumptionVoucherService.GetConsumptionVoucherByCodeAsync(addCustomerConsumptionVoucher.ConsumptionVoucherCode);
            if (voucher == null) throw new Exception("抵用券不存在");
            CustomerConsumptionVoucher customerConsumptionVoucher = new CustomerConsumptionVoucher
            {
                Id = CreateOrderIdHelper.GetNextNumber(),
                CustomerId = addCustomerConsumptionVoucher.CustomerId,
                ConsumptionVoucherId = voucher.Id,
                IsUsed = false,
                ExpireDate = addCustomerConsumptionVoucher.ExpireDate,
                IsExpire = false,
                CreateDate = DateTime.Now,
                UseDate = null,
                ShareBy = addCustomerConsumptionVoucher.ShareBy,
                Source = 1
            };
            await dalCustomerConsumptionVoucher.AddAsync(customerConsumptionVoucher, true);
        }
        /// <summary>
        /// 根据用户id和抵用券id获取指定的抵用券信息
        /// </summary>
        /// <param name="customrtid"></param>
        /// <param name="voucherid"></param>
        /// <returns></returns>
        public async Task<CustomerConsumptioVoucherInfoDto> GetVoucherByCustomerIdAndVoucherIdAsync(string customerid, string voucherid)
        {
            return await (from ccv in dalCustomerConsumptionVoucher.GetAll()
                          join cv in dalConsumptionVoucher.GetAll() on ccv.ConsumptionVoucherId equals cv.Id
                          where ccv.CustomerId == customerid && (cv.Type==0 || cv.Type==4) && ccv.Id == voucherid
                          select new CustomerConsumptioVoucherInfoDto
                          {
                              Id = ccv.Id,
                              DeductMoney = cv.DeductMoney,
                              IsSpecifyProduct = cv.IsSpecifyProduct,
                              IsUsed = ccv.IsUsed,
                              IsNeedMinPrice = cv.IsNeedMinFee,
                              MinPrice = cv.MinPrice,
                              Type=cv.Type
                          }).SingleOrDefaultAsync();
        }
        /// <summary>
        /// 用户每月领取会员卡
        /// </summary>
        /// <returns></returns>
        public async Task MemberRecieveCardAsync(string customerId)
        {
            var member = await memberCardHandleService.GetMemberCardByCustomeridAsync(customerId);
            if (member == null) return;
            var isRecive = await this.IsReciveVoucherThisMonthAsync(customerId);
            if (!isRecive)
            {
                if (member.MemberRankCode == MemberRankCode.OrdinaryMember)
                {
                    await this.OrdinaryMemberSendVoucherAsync(customerId, 2);
                };
                if (member.MemberRankCode == MemberRankCode.MEIYAWhiteCardMember)
                {
                    await this.MEIYAWhiteCardMemberSendVoucherAsync(customerId, 2);
                }
                if (member.MemberRankCode == MemberRankCode.BlackCardMember)
                {
                    await this.BlackCardMemberSendVoucherAsync(customerId, 2);
                }
            }

        }
        /// <summary>
        /// 当前月是否已领取过抵用券
        /// </summary>
        /// <param name="customerId">用户id</param>
        /// <returns></returns>
        public async Task<bool> IsReciveVoucherThisMonthAsync(string customerId)
        {
            var currentMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var member = await memberCardHandleService.GetMemberCardByCustomeridAsync(customerId);
            if (member == null) return true;
            var list = await dalCustomerConsumptionVoucher.GetAll().Where(e => e.CreateDate >= currentMonth && e.CreateDate <= currentMonth.AddMonths(1) && e.Source != 1 && e.CustomerId == customerId).ToListAsync();
            return list.Any() ? true : false;
        }
        /// <summary>
        /// 判断最近30天有没有领取过会员赠送券,没有则返回可领取的抵用券列表,有则返回null
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<List<MemberRecieveConsumptionVoucherDto>> IsReciveVoucherThisMonthThisWeekAsync(string customerId)
        {
            var startDate = DateTime.Now.AddDays(-30);
            var member = await memberCardHandleService.GetMemberCardByCustomeridAsync(customerId);
            if (member == null) return null;
            //最近7天的所有优惠券
            var list = await dalCustomerConsumptionVoucher.GetAll().Where(e => e.CreateDate >= startDate && e.Source == 0 && e.CustomerId == customerId).ToListAsync();
            if (list.Any())
            {
                return null;
            }
            else
            {
                 var voucher = dalConsumptionVoucher.GetAll().Where(e => e.MemberRankCode == member.MemberRankCode&&e.IsMemberVoucher==true).Select(e=>new MemberRecieveConsumptionVoucherDto { 
                    DeductMoney=e.Type==0? e.DeductMoney:e.DeductMoney*10,
                    VoucherName=e.Name,
                    VoucherType=e.Type,
                    VoucherCode=e.ConsumptionVoucherCode,
                    Remark=e.Remark

                 }).ToList();
                return voucher;
                /*var voucherCode = member.MemberRankCode + "voucher";
                var voucher = dalConsumptionVoucher.GetAll().Where(e=>e.ConsumptionVoucherCode==voucherCode).SingleOrDefault();
                return new MemberRecieveConsumptionVoucherDto
                {
                    DeductMoney = voucher.DeductMoney * 10,
                    VoucherName=voucher.Name
                };*/
                //未领取添加新的优惠券
                /*AddCustomerConsumptionVoucherDto voucher = new AddCustomerConsumptionVoucherDto
                {
                    CustomerId = customerId,
                    ConsumptionVoucherCode = member.MemberRankCode + "voucher",
                    ExpireDate = DateTimeUtil.GetNextMonthFirstDay(),
                    Source = 0
                };
                await AddAsyn(voucher);*/
            }

        }
        /// <summary>
        /// 获取当前可用的预约叫车抵用券
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="isUsed">是否使用</param>
        /// <param name="goodsId">商品id</param>
        /// <returns></returns>
        public async Task<List<CustomerConsumptioVoucherInfoDto>> GetAllCustomerConsumptionCarVoucherListAsync(string customerId)
        {
            var list = from ccv in dalCustomerConsumptionVoucher.GetAll()
                       join cv in dalConsumptionVoucher.GetAll() on ccv.ConsumptionVoucherId equals cv.Id
                       where ccv.CustomerId == customerId
                       orderby cv.Type, cv.DeductMoney, ccv.CreateDate descending
                       select new CustomerConsumptioVoucherInfoDto
                       {
                           Id = ccv.Id,
                           CustomerId = ccv.CustomerId,
                           ConsumptionVoucherName = cv.Name,
                           DeductMoney = cv.DeductMoney,
                           IsShare = cv.IsShare,
                           IsSpecifyProduct = cv.IsSpecifyProduct,
                           ConsumptionVoucherId = ccv.ConsumptionVoucherId,
                           IsUsed = ccv.IsUsed,
                           CreateDate = ccv.CreateDate,
                           Source = ccv.Source,
                           Type = cv.Type,
                           WriteOfCode = ccv.WriteOfCode,
                           IsExpire = ccv.IsExpire,
                           ExpireDate = ccv.ExpireDate
                       };
            var carList = list.Where(e => e.IsUsed == false && e.IsExpire == false && e.ExpireDate > DateTime.Now&&e.Type==(int)ConsumptionVoucherType.AppointmentCar).ToList();
            return carList;
        }

        public async Task<CustomerConsumptioVoucherInfoDto> GetCarVoucherByCustomerIdAndVoucherIdAsync(string customerid, string voucherid)
        {
            return await(from ccv in dalCustomerConsumptionVoucher.GetAll()
                         join cv in dalConsumptionVoucher.GetAll() on ccv.ConsumptionVoucherId equals cv.Id
                         where ccv.CustomerId == customerid && cv.Type == (int)ConsumptionVoucherType.AppointmentCar && ccv.Id == voucherid
                         select new CustomerConsumptioVoucherInfoDto
                         {
                             Id = ccv.Id,
                             DeductMoney = cv.DeductMoney,
                             IsSpecifyProduct = cv.IsSpecifyProduct,
                             IsUsed = ccv.IsUsed,
                             IsNeedMinPrice = cv.IsNeedMinFee,
                             MinPrice = cv.MinPrice,
                             VoucherCode=cv.ConsumptionVoucherCode
                         }).SingleOrDefaultAsync();
        }

        public async Task<CustomerConsumptioVoucherInfoDto> GetCarTypeVoucherByCustomerIdAndVoucherIdAsync(string customerid, string carType)
        {
            return await(from ccv in dalCustomerConsumptionVoucher.GetAll()
                         join cv in dalConsumptionVoucher.GetAll() on ccv.ConsumptionVoucherId equals cv.Id
                         where ccv.CustomerId == customerid && cv.Type == (int)ConsumptionVoucherType.AppointmentCar &&cv.ConsumptionVoucherCode==carType && ccv.IsUsed==false orderby cv.DeductMoney descending
                         select new CustomerConsumptioVoucherInfoDto
                         {
                             Id = ccv.Id,
                             DeductMoney = cv.DeductMoney,
                             IsSpecifyProduct = cv.IsSpecifyProduct,
                             IsUsed = ccv.IsUsed,
                             IsNeedMinPrice = cv.IsNeedMinFee,
                             MinPrice = cv.MinPrice,
                             VoucherCode = cv.ConsumptionVoucherCode,
       
                         }).FirstOrDefaultAsync();
        }

        public async Task MemberRecieveCardWeekAsync(string customerId,string voucherCode)
        {
            var startDate = DateTime.Now.AddDays(-30);
            var member = await memberCardHandleService.GetMemberCardByCustomeridAsync(customerId);
            if (member == null) return;
            //最近7天的所有优惠券
            var list = await dalCustomerConsumptionVoucher.GetAll().Where(e => e.CreateDate >= startDate && e.Source == 0 && e.CustomerId == customerId).ToListAsync();
            if (list.Any())
            {
                throw new Exception("本月已领取过会员抵用券,请勿重复领取");
            }
            else {
                var voucherInfo = consumptionVoucherService.GetConsumptionVoucherByCodeAsync(voucherCode);
                if (voucherInfo == null) throw new Exception("抵用券编码错误");
                AddCustomerConsumptionVoucherDto voucher = new AddCustomerConsumptionVoucherDto
                {
                    CustomerId = customerId,
                    ConsumptionVoucherCode = voucherCode,
                    ExpireDate = DateTimeUtil.GetNextMonthFirstDay(),
                    Source = 0
                };
                await AddAsyn(voucher);
            }
        }
        /// <summary>
        /// 获取用户可用于全局商品的抵用券
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="isUsed"></param>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        public async Task<List<CustomerConsumptioVoucherInfoDto>> GetOverAllCustomerConsumptionVoucherListAsync(string customerId, bool? isUsed, string goodsId)
        {
            
            var voucher = from ccv in dalCustomerConsumptionVoucher.GetAll() where ccv.CustomerId==customerId
                       join cv in dalConsumptionVoucher.GetAll() on ccv.ConsumptionVoucherId equals cv.Id                      
                       where  cv.IsSpecifyProduct==false && (isUsed == null || ccv.IsUsed == isUsed) && (cv.Type == 0 || cv.Type == 4) && ccv.IsExpire == false && ccv.ExpireDate > DateTime.Now 
                       orderby cv.DeductMoney descending
                       select new CustomerConsumptioVoucherInfoDto
                       {
                           Id = ccv.Id,                           
                           ConsumptionVoucherName = cv.Name,
                           DeductMoney = cv.DeductMoney,
                           IsShare = cv.IsShare,
                           IsSpecifyProduct = cv.IsSpecifyProduct,
                           ConsumptionVoucherId = ccv.ConsumptionVoucherId,
                           IsUsed = ccv.IsUsed,
                           CreateDate = ccv.CreateDate,
                           Source = ccv.Source,
                           Type = cv.Type,
                           WriteOfCode = ccv.WriteOfCode
                       };
            return await voucher.ToListAsync();
        }

        public async Task<List<SimpleVoucherInfoDto>> GetCustomerAllVoucher(string customerId)
        {
            var voucherList = from cv in dalCustomerConsumptionVoucher.GetAll().Where(e => e.CustomerId == customerId && e.IsUsed == false && e.IsExpire == false && e.ExpireDate < DateTime.Now)
                              join c in dalConsumptionVoucher.GetAll() on cv.ConsumptionVoucherId equals c.Id
                              where (c.Type==0||c.Type==4)
                              select new SimpleVoucherInfoDto { 
                                CustomerVoucherId=cv.Id,
                                VoucherName=c.Name,
                                IsSpecifyProduct=c.IsSpecifyProduct,
                                Type=c.Type,
                                IsNeedMinFee=c.IsNeedMinFee,
                                MinPrice=c.MinPrice.Value,
                                VoucherId=cv.ConsumptionVoucherId,
                                Remark=c.Remark,
                                DeductMoney=c.DeductMoney
                              };
            return await voucherList.ToListAsync();
    }
    }
}
