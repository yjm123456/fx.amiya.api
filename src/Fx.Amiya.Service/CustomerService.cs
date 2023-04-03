using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.CustomerInfo;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Fx.Infrastructure;
using Newtonsoft.Json;
using Fx.Amiya.Dto.WxAppConfig;
using Fx.Common;
using Fx.Common.Utils;
using Fx.Infrastructure.DataAccess;
using Fx.Amiya.Dto.TagDetailInfo;
using Fx.Amiya.Dto;

namespace Fx.Amiya.Service
{
    public class CustomerService : ICustomerService
    {
        private IDalCustomerInfo dalCustomerInfo;
        private IDalUserInfo dalUserInfo;
        private IDalBindCustomerService dalBindCustomerService;
        private IDalAmiyaEmployee dalAmiyaEmployee;
        private IDalConfig dalConfig;
        private IItemInfoService _itemInfoService;
        private IAmiyaHospitalDepartmentService _amiyaHospitalDepartmentService;
        private IDalOrderInfo dalOrderInfo;
        private IUnitOfWork unitOfWork;
        private IContentPlateFormOrderService _contentPlateFormOrderService;
        private IDalAmiyaPositionInfo dalAmiyaPositionInfo;
        private IDalCustomerBaseInfo dalCustomerBaseInfo;
        private ICustomerHospitalConsumeService _customerHospitalConsumeService;
        private IDalSendOrderInfo dalSendOrderInfo;
        private IDalTrackRecord dalTrackRecord;
        private IConsumptionLevelService _consumptionLevelService;
        private IDalTagDetailInfo dalTagDetailInfo;
        private ITagDetailInfoService tagDetailInfoService;
        private IDalCustomerTagInfo dalCustomerTagInfo;
        public CustomerService(IDalCustomerInfo dalCustomerInfo,
            IDalUserInfo dalUserInfo,
            IDalBindCustomerService dalBindCustomerService,
            IDalAmiyaEmployee dalAmiyaEmployee,
            IItemInfoService itemInfoService,
            IUnitOfWork unitOfWork,
            IContentPlateFormOrderService contentPlateFormOrderService,
            IDalConfig dalConfig,
            ICustomerHospitalConsumeService customerHospitalConsumeService,
            IDalOrderInfo dalOrderInfo,
            IAmiyaHospitalDepartmentService amiyaHospitalDepartmentService,
            IDalAmiyaPositionInfo dalAmiyaPositionInfo,
            IDalCustomerBaseInfo dalCustomerBaseInfo,
            IDalSendOrderInfo dalSendOrderInfo,
            IConsumptionLevelService consumptionLevelService,
            IDalTrackRecord dalTrackRecord, IDalTagDetailInfo dalTagDetailInfo, ITagDetailInfoService tagDetailInfoService, IDalCustomerTagInfo dalCustomerTagInfo)
        {
            this.dalCustomerInfo = dalCustomerInfo;
            this.dalUserInfo = dalUserInfo;
            this.dalBindCustomerService = dalBindCustomerService;
            this.dalAmiyaEmployee = dalAmiyaEmployee;
            this.dalConfig = dalConfig;
            this.dalOrderInfo = dalOrderInfo;
            this.dalAmiyaPositionInfo = dalAmiyaPositionInfo;
            this.dalCustomerBaseInfo = dalCustomerBaseInfo;
            this.dalSendOrderInfo = dalSendOrderInfo;
            this.dalTrackRecord = dalTrackRecord;
            this.unitOfWork = unitOfWork;
            _consumptionLevelService = consumptionLevelService;
            _contentPlateFormOrderService = contentPlateFormOrderService;
            _customerHospitalConsumeService = customerHospitalConsumeService;
            _itemInfoService = itemInfoService;
            _amiyaHospitalDepartmentService = amiyaHospitalDepartmentService;
            this.dalTagDetailInfo = dalTagDetailInfo;
            this.tagDetailInfoService = tagDetailInfoService;
            this.dalCustomerTagInfo = dalCustomerTagInfo;
        }
        public async Task<string> BindCustomerAsync(string fxUserId, string phoneNumber,string appId= null)
        {
            try
            {
                CustomerInfo customerInfo = null;
                if (string.IsNullOrEmpty(appId))
                {
                    customerInfo = await dalCustomerInfo.GetAll().FirstOrDefaultAsync(t => t.Phone == phoneNumber);
                }
                else {
                    customerInfo = await dalCustomerInfo.GetAll().FirstOrDefaultAsync(t => t.Phone == phoneNumber&&t.AppId==appId );
                }
                
                if (customerInfo != null)
                    throw new Exception("此电话号码已经被绑定到其他账号！");
                customerInfo = new CustomerInfo();
                customerInfo.Id = GuidUtil.NewGuidShortString();
                customerInfo.CreateDate = DateTime.Now;
                customerInfo.UserId = fxUserId;
                customerInfo.Phone = phoneNumber;
                customerInfo.AppId = appId;
                await dalCustomerInfo.AddAsync(customerInfo, true);
                return customerInfo.Id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> GetPhoneByCustomerIdAsync(string customerId)
        {
            try
            {
                var customerInfo = await dalCustomerInfo.GetAll().SingleOrDefaultAsync(t => t.Id == customerId);
                if (customerInfo == null)
                    return null;
                return customerInfo.Phone;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }





        public async Task<CustomerInfoDto> GetByIdAsync(string customerId)
        {
            try
            {
                var customer = await dalCustomerInfo.GetAll()
                    .Include(e => e.UserInfo)
                    .SingleOrDefaultAsync(e => e.Id == customerId);

                if (customer == null)
                    throw new Exception("客户编号错误");

                var config = await GetCallCenterConfig();
                CustomerInfoDto customerInfoDto = new CustomerInfoDto();
                customerInfoDto.Id = customer.Id;
                customerInfoDto.CreateDate = customer.CreateDate;
                customerInfoDto.UserId = customer.UserId;
                customerInfoDto.Phone = config.EnablePhoneEncrypt == true ? ServiceClass.GetIncompletePhone(customer.Phone) : customer.Phone;
                customerInfoDto.EncryptPhone = ServiceClass.Encrypt(customer.Phone, config.PhoneEncryptKey);
                customerInfoDto.Province = customer.UserInfo.Province;
                customerInfoDto.City = customer.UserInfo.City;
                customerInfoDto.NickName = customer.UserInfo.NickName;
                customerInfoDto.Avatar = customer.UserInfo.Avatar;

                return customerInfoDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 根据电话号查询客户信息
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public async Task<BindCustomerInfoDto> GetByPhoneAsync(string phone)
        {
            var customer = await dalCustomerInfo.GetAll().Include(e => e.UserInfo).SingleOrDefaultAsync(e => e.Phone == phone);
            if (customer == null)
                return new BindCustomerInfoDto();


            var config = await GetCallCenterConfig();
            BindCustomerInfoDto bindCustomerInfoDto = new BindCustomerInfoDto();
            bindCustomerInfoDto.Id = customer.Id;
            bindCustomerInfoDto.CreateDate = customer.CreateDate;
            bindCustomerInfoDto.UserId = customer.UserId;
            bindCustomerInfoDto.Phone = config.EnablePhoneEncrypt == true ? ServiceClass.GetIncompletePhone(customer.Phone) : customer.Phone;
            bindCustomerInfoDto.EncryptPhone = ServiceClass.Encrypt(customer.Phone, config.PhoneEncryptKey);
            bindCustomerInfoDto.Province = customer.UserInfo.Province;
            bindCustomerInfoDto.City = customer.UserInfo.City;
            bindCustomerInfoDto.NickName = customer.UserInfo.NickName;
            bindCustomerInfoDto.Avatar = customer.UserInfo.Avatar;
            var bindCustomerService = await dalBindCustomerService.GetAll().Include(e => e.CustomerServiceAmiyaEmployee).SingleOrDefaultAsync(e => e.UserId == customer.UserId);
            if (bindCustomerService != null)
            {
                bindCustomerInfoDto.CreateDate = bindCustomerService.CreateDate;
                bindCustomerInfoDto.CustomerServiceId = bindCustomerService.CustomerServiceId;
                bindCustomerInfoDto.CustomerServiceName = bindCustomerService.CustomerServiceAmiyaEmployee.Name;
            }


            return bindCustomerInfoDto;
        }


        public async Task<CustomerInfoDto> GetByUserIdAsync(string userId)
        {
            try
            {
                var userInfo = await dalUserInfo.GetAll().SingleOrDefaultAsync(e => e.Id == userId);
                if (userInfo == null)
                    throw new Exception("用户编号错误");
                var customer = await dalCustomerInfo.GetAll().Include(e => e.UserInfo).SingleOrDefaultAsync(e => e.UserId == userId);

                string phone = "";
                if (customer != null)
                {
                    phone = customer.Phone;
                }
                else
                {
                    phone = userInfo.WxBindPhone;
                }
                var config = await GetCallCenterConfig();
                CustomerInfoDto customerInfoDto = new CustomerInfoDto();
                customerInfoDto.Id = userInfo.Id;
                customerInfoDto.CreateDate = userInfo.CreateDate;
                customerInfoDto.UserId = userInfo.Id;
                customerInfoDto.Phone = config.EnablePhoneEncrypt == true ? ServiceClass.GetIncompletePhone(userInfo.WxBindPhone) : userInfo.WxBindPhone;
                customerInfoDto.EncryptPhone = ServiceClass.Encrypt(userInfo.WxBindPhone, config.PhoneEncryptKey);
                customerInfoDto.Province = userInfo.Province;
                customerInfoDto.City = userInfo.City;
                customerInfoDto.Avatar = userInfo.Avatar;
                customerInfoDto.NickName = userInfo.NickName;


                return customerInfoDto;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// 根据客户编号修改客户手机号
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public async Task UpdatePhoneByIdAsync(string customerId, string phone, string appId = null)
        {
            try
            {
                unitOfWork.BeginTransaction();
                var customer = await dalCustomerInfo.GetAll().SingleOrDefaultAsync(e => e.Id == customerId);
                if (customer == null) throw new Exception("客户编号错误");
                var customerPhone = await dalCustomerInfo.GetAll().SingleOrDefaultAsync(e =>e.AppId==appId&&e.Phone==phone);
                if (customerPhone != null) throw new Exception("该手机号已绑定其他账号！");
                customer.Phone = phone;
                await dalCustomerInfo.UpdateAsync(customer, true);

                var userInfo = await dalUserInfo.GetAll().SingleOrDefaultAsync(z => z.Id == customer.UserId);
                userInfo.WxBindPhone = phone;
                await dalUserInfo.UpdateAsync(userInfo, true);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }

        }
        public async Task<CustomerQuantityDto> GetCustomerQuantityAsync()
        {
            DateTime date = DateTime.Now;
            var bindCustomerService = await dalBindCustomerService.GetAll().ToListAsync();

            CustomerQuantityDto customerDataDto = new CustomerQuantityDto();
            customerDataDto.BindCustomerServiceTotalQuantity = bindCustomerService.Count();
            customerDataDto.TodayBindCustomerServiceQuantity = bindCustomerService.Count(e => e.CreateDate.Date == date.Date);
            customerDataDto.MiniProgramCustomerTotalQuantity = bindCustomerService.Count(e => e.UserId != null);
            customerDataDto.UnMiniProgramCustomerTotalQuantity = bindCustomerService.Count(e => e.UserId == null);

            return customerDataDto;

        }


        /// <summary>
        /// 获取微信客户列表
        /// </summary>
        /// <param name="searchCustomerParam"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<CustomerInfoDto>> GetWxCustomerListAsync(CustomerSearchParamDto customerSearchParam)
        {
            try
            {
                var config = await GetCallCenterConfig();
                var customerInfos = dalCustomerInfo.GetAll();
                if (customerSearchParam.MemberRankId == -1) //-1普通客户,非会员
                {
                    customerInfos = customerInfos.Where(e => customerSearchParam.MemberCustomerIds.Contains(e.Id) == false);
                }
                else if (customerSearchParam.MemberRankId != null)//会员
                {
                    customerInfos = customerInfos.Where(e => customerSearchParam.MemberCustomerIds.Contains(e.Id));
                }


                if (customerSearchParam.StartDate != null && customerSearchParam.EndDate != null)
                {
                    DateTime startrq = ((DateTime)customerSearchParam.StartDate).Date;
                    DateTime endrq = ((DateTime)customerSearchParam.EndDate).Date.AddDays(1);
                    customerInfos = customerInfos.Where(e => e.CreateDate >= startrq && e.CreateDate < endrq);
                }
                if (customerSearchParam.BirthMonth.HasValue)
                {
                    // (todo; )
                    var customerBaseInfo = await dalCustomerBaseInfo.GetAll().Where(e => e.Birthday.HasValue).ToListAsync();
                    var customerPhones = customerBaseInfo.Where(x => x.Birthday.Value.Month == customerSearchParam.BirthMonth).Select(x => x.Phone).ToList();
                    customerInfos = customerInfos.Where(e => customerPhones.Contains(e.Phone));
                }


                //未回访的客户
                if (customerSearchParam.IsUnTrack == true)
                {
                    if (customerSearchParam.UnTrackStartDate != null && customerSearchParam.UnTrackEndDate != null)
                    {
                        //时间段内未回访的客户
                        DateTime unTrackStartrq = ((DateTime)customerSearchParam.UnTrackStartDate).Date;
                        DateTime unTrackEndrq = ((DateTime)customerSearchParam.UnTrackEndDate).Date.AddDays(1);
                        var trackPhones = await dalTrackRecord.GetAll().Where(e => e.TrackDate >= unTrackStartrq && e.TrackDate < unTrackEndrq).Select(e => e.Phone).ToListAsync();
                        trackPhones = trackPhones.Distinct().ToList();
                        customerInfos = from d in customerInfos
                                        where trackPhones.Contains(d.Phone) == false
                                        select d;
                    }
                    else
                    {
                        var trackPhones = await dalTrackRecord.GetAll().Select(e => e.Phone).ToListAsync();
                        trackPhones = trackPhones.Distinct().ToList();

                        //所有未回访的客户
                        customerInfos = from d in customerInfos
                                        where trackPhones.Contains(d.Phone) == false
                                        select d;
                    }
                }


                if (customerSearchParam.MinAmount != null || customerSearchParam.MaxAmount != null)
                {
                    if (customerSearchParam.MaxAmount < customerSearchParam.MinAmount)
                        throw new Exception("最大订单总额不能小于最小订单总额");
                    if (customerSearchParam.AmountType == 0)
                    {
                        var order = from d in dalOrderInfo.GetAll()
                                    group d by d.Phone into g
                                    select new
                                    {
                                        g.Key,
                                        Sum = g.Sum(e => e.ActualPayment)
                                    };

                        var phones = await order.Where(e => e.Sum >= customerSearchParam.MinAmount && e.Sum <= customerSearchParam.MaxAmount).Select(e => e.Key).ToListAsync();

                        //根据下单总额
                        customerInfos = from d in customerInfos
                                            //where customerSearchParam.MinAmount <= dalOrderInfo.GetAll().Where(e => e.Phone == d.Phone).Sum(e => e.ActualPayment)
                                            //&& dalOrderInfo.GetAll().Where(e => e.Phone == d.Phone).Sum(e => e.ActualPayment) <= customerSearchParam.MaxAmount
                                        where phones.Contains(d.Phone)
                                        select d;
                    }
                    else
                    {
                        //根据核销总额

                        var order = from d in dalOrderInfo.GetAll()
                                    where d.StatusCode == OrderStatusCode.TRADE_FINISHED
                                    group d by d.Phone into g
                                    select new
                                    {
                                        g.Key,
                                        Sum = g.Sum(e => e.ActualPayment)
                                    };

                        var phones = await order.Where(e => e.Sum >= customerSearchParam.MinAmount && e.Sum <= customerSearchParam.MaxAmount).Select(e => e.Key).ToListAsync();
                        customerInfos = from d in customerInfos
                                            // where customerSearchParam.MinAmount <= dalOrderInfo.GetAll().Where(e => e.Phone == d.Phone && e.StatusCode == OrderStatusCode.TRADE_FINISHED).Sum(e => e.ActualPayment)
                                            //&& dalOrderInfo.GetAll().Where(e => e.Phone == d.Phone && e.StatusCode == OrderStatusCode.TRADE_FINISHED).Sum(e => e.ActualPayment) <= customerSearchParam.MaxAmount
                                        where phones.Contains(d.Phone)
                                        select d;
                    }
                }

                var customers = from c in customerInfos
                                join b in dalCustomerBaseInfo.GetAll() on c.Phone equals b.Phone into cb
                                from b in cb.DefaultIfEmpty()
                                join bcs in dalBindCustomerService.GetAll() on c.Phone equals bcs.BuyerPhone into cbcs
                                from bcs in cbcs.DefaultIfEmpty()
                                where (string.IsNullOrWhiteSpace(customerSearchParam.Keyword) || c.UserInfo.NickName.Contains(customerSearchParam.Keyword) || c.Phone.Contains(customerSearchParam.Keyword))
                                && (customerSearchParam.EmployeeId == -1 || bcs.CustomerServiceId == customerSearchParam.EmployeeId)
                                select new CustomerInfoDto
                                {
                                    Id = c.Id,
                                    CreateDate = c.CreateDate,
                                    UserId = c.UserId,
                                    Phone = config.EnablePhoneEncrypt == true ? ServiceClass.GetIncompletePhone(c.Phone) : c.Phone,
                                    EncryptPhone = ServiceClass.Encrypt(c.Phone, config.PhoneEncryptKey),
                                    Province = c.UserInfo.Province,
                                    City = c.UserInfo.City,
                                    NickName = c.UserInfo.NickName,
                                    Avatar = c.UserInfo.Avatar,
                                    Name = b.Name,
                                    Sex = b.Sex,
                                    CustomerServiceId = bcs.CustomerServiceId,
                                    CustomerServiceName = bcs.CustomerServiceAmiyaEmployee.Name

                                };

                int pageNum = customerSearchParam.PageNum;
                int pageSize = customerSearchParam.PageSize;
                FxPageInfo<CustomerInfoDto> customerPageInfo = new FxPageInfo<CustomerInfoDto>();
                customerPageInfo.TotalCount = await customers.CountAsync();
                customerPageInfo.List = await customers.OrderByDescending(e => e.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
                return customerPageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        /// <summary>
        /// 获取绑定了客服的客户列表
        /// </summary>
        /// <returns></returns>
        public async Task<FxPageInfo<BindCustomerInfoDto>> GetBindCustomerServiceListAsync(CustomerSearchParamDto customerSearchParam)
        {
            var bindCustomerSerices = from d in dalBindCustomerService.GetAll()
                                      where customerSearchParam.EmployeeId == -1 || d.CustomerServiceId == customerSearchParam.EmployeeId
                                      select d;
            if (customerSearchParam.StartDate != null && customerSearchParam.EndDate != null)
            {
                DateTime startrq = ((DateTime)customerSearchParam.StartDate).Date;
                DateTime endrq = ((DateTime)customerSearchParam.EndDate).AddDays(1).Date;
                bindCustomerSerices = bindCustomerSerices.Where(e => e.CreateDate >= startrq && e.CreateDate < endrq);

            }
            if (customerSearchParam.CustomerType == 1) //客户已注册小程序
            {
                bindCustomerSerices = bindCustomerSerices.Where(e => e.UserId != null);
            }
            if (customerSearchParam.CustomerType == 2) //客户未注册小程序
            {
                bindCustomerSerices = bindCustomerSerices.Where(e => e.UserId == null);
            }


            //未回访的客户
            if (customerSearchParam.IsUnTrack == true)
            {
                if (customerSearchParam.UnTrackStartDate != null && customerSearchParam.UnTrackEndDate != null)
                {
                    //时间段内未回访的客户
                    DateTime unTrackStartrq = ((DateTime)customerSearchParam.UnTrackStartDate).Date;
                    DateTime unTrackEndrq = ((DateTime)customerSearchParam.UnTrackEndDate).Date.AddDays(1);
                    var trackPhones = await dalTrackRecord.GetAll().Where(e => e.TrackDate >= unTrackStartrq && e.TrackDate < unTrackEndrq).Select(e => e.Phone).ToListAsync();
                    trackPhones = trackPhones.Distinct().ToList();

                    bindCustomerSerices = from d in bindCustomerSerices
                                          where trackPhones.Contains(d.BuyerPhone) == false
                                          select d;
                }
                else
                {
                    //所有未回访的客户
                    var trackPhones = await dalTrackRecord.GetAll().Select(e => e.Phone).ToListAsync();
                    trackPhones = trackPhones.Distinct().ToList();

                    bindCustomerSerices = from d in bindCustomerSerices
                                          where trackPhones.Contains(d.BuyerPhone) == false
                                          select d;
                }
            }


            if (customerSearchParam.MinAmount != null || customerSearchParam.MaxAmount != null)
            {
                if (customerSearchParam.MaxAmount < customerSearchParam.MinAmount)
                    throw new Exception("最大订单总额不能小于最小订单总额");
                if (customerSearchParam.AmountType == 0)
                {
                    //根据下单总额
                    var order = from d in dalOrderInfo.GetAll()
                                group d by d.Phone into g
                                select new
                                {
                                    g.Key,
                                    Sum = g.Sum(e => e.ActualPayment)
                                };

                    var phones = await order.Where(e => e.Sum >= customerSearchParam.MinAmount && e.Sum <= customerSearchParam.MaxAmount).Select(e => e.Key).ToListAsync();
                    bindCustomerSerices = from d in bindCustomerSerices
                                          where phones.Contains(d.BuyerPhone)
                                          select d;
                }
                else
                {
                    //根据核销总额

                    var order = from d in dalOrderInfo.GetAll()
                                where d.StatusCode == OrderStatusCode.TRADE_FINISHED
                                group d by d.Phone into g
                                select new
                                {
                                    g.Key,
                                    Sum = g.Sum(e => e.ActualPayment)
                                };

                    var phones = await order.Where(e => e.Sum >= customerSearchParam.MinAmount && e.Sum <= customerSearchParam.MaxAmount).Select(e => e.Key).ToListAsync();
                    bindCustomerSerices = from d in bindCustomerSerices
                                          where phones.Contains(d.BuyerPhone)
                                          select d;
                }
            }




            var config = await GetCallCenterConfig();

            var bindCustomers = from d in bindCustomerSerices
                                join c in dalCustomerInfo.GetAll() on d.BuyerPhone equals c.Phone into cd
                                from c in cd.DefaultIfEmpty()
                                join cbi in dalCustomerBaseInfo.GetAll() on d.BuyerPhone equals cbi.Phone into cb
                                from cbi in cb.DefaultIfEmpty()
                                where (string.IsNullOrWhiteSpace(customerSearchParam.Keyword) || c.UserInfo.NickName.Contains(customerSearchParam.Keyword)
                                || c.Phone.Contains(customerSearchParam.Keyword) || d.BuyerPhone.Contains(customerSearchParam.Keyword))
                                select new BindCustomerInfoDto
                                {
                                    Id = c.Id,
                                    CreateDate = d.CreateDate,
                                    UserId = c.UserId,
                                    Phone = config.EnablePhoneEncrypt == true ? ServiceClass.GetIncompletePhone(d.BuyerPhone) : d.BuyerPhone,
                                    EncryptPhone = ServiceClass.Encrypt(d.BuyerPhone, config.PhoneEncryptKey),
                                    Province = c.UserInfo.Province,
                                    City = c.UserInfo.City,
                                    NickName = c.UserInfo.NickName,
                                    Avatar = c.UserInfo.Avatar,
                                    CustomerServiceId = d.CustomerServiceId,
                                    CustomerServiceName = d.CustomerServiceAmiyaEmployee.Name,
                                    Name = cbi.Name,
                                    Sex = cbi.Sex
                                };

            int pageNum = customerSearchParam.PageNum;
            int pageSize = customerSearchParam.PageSize;
            FxPageInfo<BindCustomerInfoDto> customerPageInfo = new FxPageInfo<BindCustomerInfoDto>();
            customerPageInfo.TotalCount = await bindCustomers.CountAsync();
            customerPageInfo.List = await bindCustomers.OrderByDescending(e => e.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return customerPageInfo;
        }



        /// <summary>
        /// 获取绑定了客服的客户消费列表
        /// </summary>
        /// <returns></returns>
        public async Task<FxPageInfo<BindCustomerConsumptionInfoDto>> GetBindCustomerConsumptionServiceListAsync(CustomerCunsumptionSearchParamDto customerSearchParam)
        {
            decimal MinPrice = 0.00M;
            decimal MaxPrice = 0.00M;
            if (!string.IsNullOrEmpty(customerSearchParam.ConsumptionLevelId))
            {
                var consumptionInfo = await _consumptionLevelService.GetByIdAsync(customerSearchParam.ConsumptionLevelId);
                MinPrice = consumptionInfo.MinPrice;
                MaxPrice = consumptionInfo.MaxPrice;
            }
            if (!string.IsNullOrEmpty(customerSearchParam.OrderId))
            {
                var orderInfoResult = await dalOrderInfo.GetAll().Where(e => e.Id == customerSearchParam.OrderId).FirstOrDefaultAsync();
                if (orderInfoResult != null)
                {
                    customerSearchParam.Keyword = orderInfoResult.Phone;
                }
                else
                {
                    var contentPlatOrderInfoResult = await _contentPlateFormOrderService.GetByOrderIdAsync(customerSearchParam.OrderId);
                    if (contentPlatOrderInfoResult != null)
                    { customerSearchParam.Keyword = contentPlatOrderInfoResult.Phone; }
                    else
                    {
                        var customerHospitalConsumeInfo = await _customerHospitalConsumeService.GetByConsumeIdAsync(customerSearchParam.OrderId);
                        if (customerHospitalConsumeInfo != null)
                        {
                            customerSearchParam.Keyword = customerHospitalConsumeInfo.Phone;
                        }
                        else
                        {
                            throw new Exception("订单号输入有误，请重新确认订单号后查询！");
                        }
                    }
                }
            }
            DateTime startrq = ((DateTime)customerSearchParam.StartDate).Date;
            DateTime endrq = ((DateTime)customerSearchParam.EndDate).AddDays(1).Date;
            var config = await GetCallCenterConfig();
            var bindCustomers = from d in dalBindCustomerService.GetAll()
                                where (customerSearchParam.EmployeeId == -1 || d.CustomerServiceId == customerSearchParam.EmployeeId)
                                && (string.IsNullOrWhiteSpace(customerSearchParam.Keyword) || d.BuyerPhone.Contains(customerSearchParam.Keyword))
                                && (customerSearchParam.Channel == 0 || d.NewConsumptionContentPlatform == customerSearchParam.Channel)
                                && (string.IsNullOrEmpty(customerSearchParam.ConsumptionLevelId) || d.AllPrice >= MinPrice && d.AllPrice <= MaxPrice)
                                && (customerSearchParam.StartDate == null && customerSearchParam.EndDate == null || d.CreateDate >= startrq && d.CreateDate < endrq)
                                select new BindCustomerConsumptionInfoDto
                                {
                                    CreateDate = d.CreateDate,
                                    Phone = config.EnablePhoneEncrypt == true ? ServiceClass.GetIncompletePhone(d.BuyerPhone) : d.BuyerPhone,
                                    EncryptPhone = ServiceClass.Encrypt(d.BuyerPhone, config.PhoneEncryptKey),
                                    NewConsumptionPlatFormId = d.NewConsumptionContentPlatform.Value,
                                    CustomerServiceId = d.CustomerServiceId,
                                    CustomerServiceName = d.CustomerServiceAmiyaEmployee.Name,
                                    FirstOrderCreateDate = d.FirstConsumptionDate.Value,
                                    FirstOrderInfo = d.FirstProjectDemand,
                                    NewConsumptionTime = d.NewConsumptionDate,
                                    NewConsumptionPlatForm = d.NewConsumptionContentPlatform.HasValue ? ServiceClass.GetOrderFromText(d.NewConsumptionContentPlatform.Value) : "未知",
                                    NewConsumptionPlatFormAppTypeText = d.NewContentPlatForm,
                                    AllConsumptionPrice = d.AllPrice.HasValue ? d.AllPrice.Value : 0.00M,
                                    CreatedOrderNum = d.AllOrderCount.HasValue ? d.AllOrderCount.Value : 0,
                                    NewLiveAnchorName=d.NewLiveAnchor,
                                    NewWechatNo=d.NewWechatNo
                                };
            int pageNum = customerSearchParam.PageNum;
            int pageSize = customerSearchParam.PageSize;
            FxPageInfo<BindCustomerConsumptionInfoDto> customerPageInfo = new FxPageInfo<BindCustomerConsumptionInfoDto>();
            var bindCustomerInfos = await bindCustomers.OrderByDescending(x => x.CreateDate).ToListAsync();
            customerPageInfo.TotalCount = bindCustomerInfos.Count();
            customerPageInfo.List = bindCustomerInfos.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            return customerPageInfo;
        }

        public async Task<List<BindCustomerConsumptionInfoDto>> ExportBindCustomerConsumptionServiceListAsync(CustomerCunsumptionSearchParamDto customerSearchParam)
        {
            decimal MinPrice = 0.00M;
            decimal MaxPrice = 0.00M;
            if (!string.IsNullOrEmpty(customerSearchParam.ConsumptionLevelId))
            {
                var consumptionInfo = await _consumptionLevelService.GetByIdAsync(customerSearchParam.ConsumptionLevelId);
                MinPrice = consumptionInfo.MinPrice;
                MaxPrice = consumptionInfo.MaxPrice;
            }
            if (!string.IsNullOrEmpty(customerSearchParam.OrderId))
            {
                var orderInfoResult = await dalOrderInfo.GetAll().Where(e => e.Id == customerSearchParam.OrderId).FirstOrDefaultAsync();
                if (orderInfoResult != null)
                {
                    customerSearchParam.Keyword = orderInfoResult.Phone;
                }
                else
                {
                    var contentPlatOrderInfoResult = await _contentPlateFormOrderService.GetByOrderIdAsync(customerSearchParam.OrderId);
                    if (contentPlatOrderInfoResult != null)
                    { customerSearchParam.Keyword = contentPlatOrderInfoResult.Phone; }
                    else
                    {
                        var customerHospitalConsumeInfo = await _customerHospitalConsumeService.GetByConsumeIdAsync(customerSearchParam.OrderId);
                        if (customerHospitalConsumeInfo != null)
                        {
                            customerSearchParam.Keyword = customerHospitalConsumeInfo.Phone;
                        }
                        else
                        {
                            throw new Exception("订单号输入有误，请重新确认订单号后查询！");
                        }
                    }
                }
            }
            DateTime startrq = ((DateTime)customerSearchParam.StartDate).Date;
            DateTime endrq = ((DateTime)customerSearchParam.EndDate).AddDays(1).Date;
            var config = await GetCallCenterConfig();
            var bindCustomers = from d in dalBindCustomerService.GetAll()
                                where (customerSearchParam.EmployeeId == -1 || d.CustomerServiceId == customerSearchParam.EmployeeId)
                                && (string.IsNullOrWhiteSpace(customerSearchParam.Keyword) || d.BuyerPhone.Contains(customerSearchParam.Keyword))
                                && (customerSearchParam.Channel == 0 || d.NewConsumptionContentPlatform == customerSearchParam.Channel)
                                && (string.IsNullOrEmpty(customerSearchParam.ConsumptionLevelId) || d.AllPrice >= MinPrice && d.AllPrice <= MaxPrice)
                                && (customerSearchParam.StartDate == null && customerSearchParam.EndDate == null || d.CreateDate >= startrq && d.CreateDate < endrq)
                                select new BindCustomerConsumptionInfoDto
                                {
                                    CreateDate = d.CreateDate,
                                    // Phone = config.EnablePhoneEncrypt == true ? ServiceClass.GetIncompletePhone(d.BuyerPhone) : d.BuyerPhone,
                                    Phone = d.BuyerPhone,
                                    EncryptPhone = ServiceClass.Encrypt(d.BuyerPhone, config.PhoneEncryptKey),
                                    NewConsumptionPlatFormId = d.NewConsumptionContentPlatform.Value,
                                    CustomerServiceId = d.CustomerServiceId,
                                    CustomerServiceName = d.CustomerServiceAmiyaEmployee.Name,
                                    FirstOrderCreateDate = d.FirstConsumptionDate.Value,
                                    FirstOrderInfo = d.FirstProjectDemand,
                                    NewConsumptionTime = d.NewConsumptionDate,
                                    NewConsumptionPlatForm = d.NewConsumptionContentPlatform.HasValue ? ServiceClass.GetOrderFromText(d.NewConsumptionContentPlatform.Value) : "未知",
                                    NewConsumptionPlatFormAppTypeText = d.NewContentPlatForm,
                                    AllConsumptionPrice = d.AllPrice.HasValue ? d.AllPrice.Value : 0.00M,
                                    CreatedOrderNum = d.AllOrderCount.HasValue ? d.AllOrderCount.Value : 0,
                                    NewLiveAnchorName=d.NewLiveAnchor,
                                    NewWechatNo=d.NewWechatNo
                                };
            int pageNum = customerSearchParam.PageNum;
            int pageSize = customerSearchParam.PageSize;
            List<BindCustomerConsumptionInfoDto> customerPageInfo = new List<BindCustomerConsumptionInfoDto>();
            var bindCustomerInfos = await bindCustomers.OrderByDescending(x => x.CreateDate).ToListAsync();
            customerPageInfo = bindCustomerInfos.ToList();
            return customerPageInfo;
        }

        public async Task<List<BindCustomerConsumptionInfoDto>> GetTopBindCustomerConsumptionServiceListAsync(DateTime startDate, DateTime endDate)
        {
            DateTime startrq = startDate.Date;
            DateTime endrq = endDate.AddDays(1).Date;
            var config = await GetCallCenterConfig();
            var bindCustomers = from d in dalBindCustomerService.GetAll()
                                where (d.CreateDate >= startrq && d.CreateDate < endrq)
                                select new BindCustomerConsumptionInfoDto
                                {
                                    Phone = config.EnablePhoneEncrypt == true ? ServiceClass.GetIncompletePhone(d.BuyerPhone) : d.BuyerPhone,
                                    AllConsumptionPrice = d.AllPrice.HasValue ? d.AllPrice.Value : 0.00M,
                                    CreatedOrderNum = d.AllOrderCount.HasValue ? d.AllOrderCount.Value : 0,
                                };
            List<BindCustomerConsumptionInfoDto> customerPageInfo = new List<BindCustomerConsumptionInfoDto>();
            var bindCustomerInfos = await bindCustomers.OrderByDescending(x => x.AllConsumptionPrice).ToListAsync();
            customerPageInfo = bindCustomerInfos.Take(10).ToList();
            return customerPageInfo;
        }


        /// <summary>
        /// 获取客户回访情况列表
        /// </summary>
        /// <returns></returns>
        public async Task<FxPageInfo<BindTrackCustomerInfoDto>> GetCustomerTrackServiceListAsync(CustomerTrackInfoSearchDto customerTrackInfoSearchParam)
        {
            var bindCustomerSerices = from d in dalBindCustomerService.GetAll()
                                      where customerTrackInfoSearchParam.EmployeeId == -1 || d.CustomerServiceId == customerTrackInfoSearchParam.EmployeeId
                                      select d;

            if (customerTrackInfoSearchParam.CustomerType == 1) //客户已注册小程序
            {
                bindCustomerSerices = bindCustomerSerices.Where(e => e.UserId != null);
            }
            if (customerTrackInfoSearchParam.CustomerType == 2) //客户未注册小程序
            {
                bindCustomerSerices = bindCustomerSerices.Where(e => e.UserId == null);
            }

            var config = await GetCallCenterConfig();
            try
            {
                var bindCustomers = from d in bindCustomerSerices
                                    join c in dalCustomerInfo.GetAll() on d.BuyerPhone equals c.Phone into cd
                                    from c in cd.DefaultIfEmpty()
                                    where (string.IsNullOrWhiteSpace(customerTrackInfoSearchParam.Keyword) || c.UserInfo.NickName.Contains(customerTrackInfoSearchParam.Keyword)
                                    || c.Phone.Contains(customerTrackInfoSearchParam.Keyword) || d.BuyerPhone.Contains(customerTrackInfoSearchParam.Keyword))
                                    select new BindTrackCustomerInfoDto
                                    {
                                        Id = c.Id,
                                        CreateDate = d.CreateDate,
                                        UserId = c.UserId,
                                        BasePhone = d.BuyerPhone,
                                        Phone = config.EnablePhoneEncrypt == true ? ServiceClass.GetIncompletePhone(d.BuyerPhone) : d.BuyerPhone,
                                        EncryptPhone = ServiceClass.Encrypt(d.BuyerPhone, config.PhoneEncryptKey),
                                        Province = c.UserInfo.Province,
                                        City = c.UserInfo.City,
                                        NickName = c.UserInfo.NickName,
                                        Avatar = c.UserInfo.Avatar,
                                        CustomerServiceId = d.CustomerServiceId,
                                        CustomerServiceName = d.CustomerServiceAmiyaEmployee.Name,
                                    };
                int pageNum = customerTrackInfoSearchParam.PageNum;
                int pageSize = customerTrackInfoSearchParam.PageSize;
                var result = await bindCustomers.ToListAsync();
                foreach (var x in result)
                {
                    var trackInfo = await dalTrackRecord.GetAll().Where(z => z.Phone == x.BasePhone).OrderByDescending(k => k.TrackDate).FirstOrDefaultAsync();
                    if (trackInfo != null)
                    {
                        x.IsTrackId = 1;
                        x.IsTrack = "已回访过";
                        x.LatestTrackTime = trackInfo.TrackDate;
                    }
                    else
                    {
                        x.IsTrackId = 2;
                        x.IsTrack = "未回访过";
                    }
                }
                FxPageInfo<BindTrackCustomerInfoDto> customerPageInfo = new FxPageInfo<BindTrackCustomerInfoDto>();
                result = result.Where(x => x.IsTrackId == customerTrackInfoSearchParam.IsUnTrack).ToList();
                if (customerTrackInfoSearchParam.IsUnTrack == 1)
                {
                    DateTime startrq = ((DateTime)customerTrackInfoSearchParam.StartDate).Date;
                    DateTime endrq = ((DateTime)customerTrackInfoSearchParam.EndDate).AddDays(1).Date;
                    result = result.Where(e => e.LatestTrackTime >= startrq && e.LatestTrackTime < endrq).ToList();
                    customerPageInfo.TotalCount = result.Count();
                    customerPageInfo.List = result.OrderByDescending(e => e.LatestTrackTime).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
                }
                else
                {
                    customerPageInfo.TotalCount = result.Count();
                    customerPageInfo.List = result.OrderByDescending(e => e.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
                }
                return customerPageInfo;
            }
            catch (Exception er)
            {
                string xx = er.Message.ToString();
                return new FxPageInfo<BindTrackCustomerInfoDto>();

            }

        }


        /// <summary>
        /// 获取电话配置信息
        /// </summary>
        /// <returns></returns>
        private async Task<CallCenterConfigDto> GetCallCenterConfig()
        {
            var config = await dalConfig.GetAll().SingleOrDefaultAsync();
            return JsonConvert.DeserializeObject<WxAppConfigDto>(config.ConfigJson).CallCenterConfig;
        }




        /// <summary>
        /// 根据加密电话查询简单的客户和订单信息
        /// </summary>
        /// <param name="encryptPhone"></param>
        /// <returns></returns>
        public async Task<CustomerSimpleInfoDto> GetCustomerSimpleByPhoneAsync(string encryptPhone)
        {
            var config = await GetCallCenterConfig();
            string phone = ServiceClass.Decrypto(encryptPhone, config.PhoneEncryptKey);
            var customer = await dalCustomerInfo.GetAll().Include(e => e.UserInfo).SingleOrDefaultAsync(e => e.Phone == phone);
            CustomerSimpleInfoDto customerSimpleInfoDto = new CustomerSimpleInfoDto();

            if (customer != null)
            {
                customerSimpleInfoDto.Id = customer.Id;
                customerSimpleInfoDto.Name = customer.UserInfo.NickName;
            }
            customerSimpleInfoDto.Phone = config.EnablePhoneEncrypt == true ? ServiceClass.GetIncompletePhone(phone) : phone;
            customerSimpleInfoDto.EncryptPhone = ServiceClass.Encrypt(phone, config.PhoneEncryptKey);
            customerSimpleInfoDto.TradeFinishedOrderQuantity = await dalOrderInfo.GetAll().CountAsync(e => e.Phone == phone && e.StatusCode == OrderStatusCode.TRADE_FINISHED);
            customerSimpleInfoDto.PaymentOrderQuantity = await dalOrderInfo.GetAll().CountAsync(e => e.Phone == phone && (e.StatusCode == OrderStatusCode.WAIT_BUYER_CONFIRM_GOODS || e.StatusCode == OrderStatusCode.WAIT_SELLER_SEND_GOODS));

            return customerSimpleInfoDto;

        }




        /// <summary>
        /// 根据医院编号获取派单的客户列表
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<CustomerInfoDto>> GetCustomerListByHospitalIdAsync(int hospitalId, string keyword, int pageNum, int pageSize)
        {

            var orders = from d in dalOrderInfo.GetAll()
                         where d.SendOrderInfoList.Count(e => e.HospitalId == hospitalId) > 0
                         group d by new { d.Phone } into g
                         select new
                         {
                             Phone = g.Key.Phone,
                         };



            var config = await GetCallCenterConfig();


            var customers = from o in orders
                            join c in dalCustomerInfo.GetAll() on o.Phone equals c.Phone into oc
                            from c in oc.DefaultIfEmpty()
                            join cb in dalCustomerBaseInfo.GetAll() on o.Phone equals cb.Phone into cbOrder
                            from cb in cbOrder.DefaultIfEmpty()
                            where (string.IsNullOrWhiteSpace(keyword) || o.Phone == keyword || cb.Name.Contains(keyword))
                            select new CustomerInfoDto
                            {
                                Id = c.Id,
                                UserId = c.UserId,
                                Phone = o.Phone,
                                EncryptPhone = ServiceClass.Encrypt(o.Phone, config.PhoneEncryptKey),
                                Province = c.UserInfo.Province,
                                City = c.UserInfo.City,
                                NickName = c.UserInfo.NickName,
                                Avatar = c.UserInfo.Avatar,
                                Name = cb.Name,
                                Sex = cb.Sex
                            };





            FxPageInfo<CustomerInfoDto> customerPageInfo = new FxPageInfo<CustomerInfoDto>();
            customerPageInfo.TotalCount = await customers.CountAsync();
            customerPageInfo.List = await customers
                .Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();

            foreach (var item in customerPageInfo.List)
            {
                var sendOrder = await dalSendOrderInfo.GetAll().Where(e => e.OrderInfo.Phone == item.Phone).OrderBy(e => e.SendDate).FirstOrDefaultAsync();
                item.CreateDate = sendOrder.SendDate;
                item.Phone = config.EnablePhoneEncrypt == true ? ServiceClass.GetIncompletePhone(item.Phone) : item.Phone;
            }
            return customerPageInfo;
        }



        /// <summary>
        /// 编辑客户基础信息
        /// </summary>
        /// <param name="editDto"></param>
        /// <returns></returns>
        public async Task EditAsync(EditCustomerDto editDto)
        {
            unitOfWork.BeginTransaction();
            try
            {
                var config = await GetCallCenterConfig();
                string phone = ServiceClass.Decrypto(editDto.EncryptPhone, config.PhoneEncryptKey);
                var customerBaseInfo = await dalCustomerBaseInfo.GetAll().SingleOrDefaultAsync(e => e.Phone == phone);
                if (customerBaseInfo == null)
                {
                    CustomerBaseInfo customerInfo = new CustomerBaseInfo();
                    customerInfo.Name = editDto.Name;
                    customerInfo.Sex = editDto.Sex;
                    customerInfo.Phone = phone;
                    customerInfo.Birthday = editDto.Birthday;
                    customerInfo.Occupation = editDto.Occupation;
                    customerInfo.WechatNumber = editDto.WechatNumber;
                    customerInfo.City = editDto.City;
                    await dalCustomerBaseInfo.AddAsync(customerInfo, true);
                }
                else
                {
                    customerBaseInfo.Name = editDto.Name;
                    customerBaseInfo.Sex = editDto.Sex;
                    customerBaseInfo.Birthday = editDto.Birthday;
                    customerBaseInfo.Occupation = editDto.Occupation;
                    customerBaseInfo.WechatNumber = editDto.WechatNumber;
                    customerBaseInfo.City = editDto.City;
                    await dalCustomerBaseInfo.UpdateAsync(customerBaseInfo, true);
                }
                unitOfWork.Commit();
            }
            catch (Exception err)
            {
                unitOfWork.RollBack();
                throw err;
            }
        }


        public async Task<CustomerBaseInfoDto> GetCustomerBaseInfoByEncryptPhoneAsync(string encryptPhone)
        {
            var config = await GetCallCenterConfig();
            string phone = ServiceClass.Decrypto(encryptPhone, config.PhoneEncryptKey);
            var customerBaseInfo = await dalCustomerBaseInfo.GetAll().Where(e => e.Phone == phone).SingleOrDefaultAsync();
            CustomerBaseInfoDto customerBaseInfoDto = new CustomerBaseInfoDto();
            if (customerBaseInfo == null)
                return customerBaseInfoDto;
            customerBaseInfoDto.Id = customerBaseInfo.Id;
            customerBaseInfoDto.Name = customerBaseInfo.Name;
            customerBaseInfoDto.Sex = customerBaseInfo.Sex;
            customerBaseInfoDto.Birthday = customerBaseInfo.Birthday;
            customerBaseInfoDto.Occupation = customerBaseInfo.Occupation;
            customerBaseInfoDto.WechatNumber = customerBaseInfo.WechatNumber;
            customerBaseInfoDto.City = customerBaseInfo.City;
            customerBaseInfoDto.EncryptPhone = ServiceClass.Encrypt(customerBaseInfo.Phone, config.PhoneEncryptKey);

            int? age = null;
            if (customerBaseInfo.Birthday != null)
            {
                DateTime date = DateTime.Now;
                DateTime birthday = (DateTime)customerBaseInfo.Birthday;
                age = date.Year - birthday.Year;
                if (date.Month < birthday.Month || (date.Month == birthday.Month && date.Day < birthday.Day))
                    age--;
            }
            customerBaseInfoDto.Age = age;
            return customerBaseInfoDto;
        }



        public async Task<string> GetCustomerIdByPhoneAsync(string phone)
        {
            var customerInfo = await dalCustomerInfo.GetAll().SingleOrDefaultAsync(e => e.Phone == phone);
            return customerInfo?.Id;
        }

        public async Task<string> GetCustomerIdByEncryptPhoneAsync(string encryptPhone)
        {
            var config = await GetCallCenterConfig();
            string phone = ServiceClass.Decrypto(encryptPhone, config.PhoneEncryptKey);
            var customerInfo = await dalCustomerInfo.GetAll().SingleOrDefaultAsync(e => e.Phone == phone);
            return customerInfo?.Id;
        }



        public async Task<string> DecryptoPhone(string encryptPhone)
        {
            var config = await GetCallCenterConfig();
            return ServiceClass.Decrypto(encryptPhone, config.PhoneEncryptKey);
        }

        public async Task<CustomerDto> GetCustomerByUserIdAsync(string userId)
        {
            var customer = await dalCustomerInfo.GetAll().Where(e => e.UserId == userId).Select(e => new CustomerDto
            {
                Id = e.Id,
                Phone = e.Phone
            }).FirstOrDefaultAsync();
            return customer;

        }
        /// <summary>
        /// 添加用户标签
        /// </summary>
        /// <param name="addCustomerTagDto"></param>
        /// <returns></returns>
        public async Task AddCustomerTag(AddCustomerTagDto addCustomerTagDto)
        {
            var tags = dalTagDetailInfo.GetAll().Where(e => e.CustomerGoodsId == addCustomerTagDto.CustomerId).Select(e => e.TagId).ToList();
            if (tags.Count() > 0)
            {
                //删除原有标签
                foreach (var item in tags)
                {
                    await tagDetailInfoService.DeleteAsync(addCustomerTagDto.CustomerId, item);
                }
                //添加新标签
                foreach (var item in addCustomerTagDto.TagIds)
                {
                    AddTagDetailInfoDto add = new AddTagDetailInfoDto();
                    add.Id = addCustomerTagDto.CustomerId;
                    add.TagId = item;
                    await tagDetailInfoService.AddTagDetailInfoAsync(add);
                }

            }
            else
            {
                foreach (var item in addCustomerTagDto.TagIds)
                {
                    AddTagDetailInfoDto add = new AddTagDetailInfoDto();
                    add.Id = addCustomerTagDto.CustomerId;
                    add.TagId = item;
                    await tagDetailInfoService.AddTagDetailInfoAsync(add);
                }
            }
        }
        /// <summary>
        /// 根据id获取用户标签列表
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<List<BaseIdAndNameDto>> GetCustomerTagListAsync(string customerId)
        {
            var tagList = from td in dalTagDetailInfo.GetAll()
                          join t in dalCustomerTagInfo.GetAll() on td.TagId equals t.Id
                          where td.CustomerGoodsId == customerId
                          select new BaseIdAndNameDto
                          {
                              Id = t.Id,
                              Name = t.TagName
                          };
            return tagList.ToList();
        }
    }
}
