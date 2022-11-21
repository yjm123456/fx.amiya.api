using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo.CustomerInfo;
using Fx.Amiya.Core.Dto.MemberCard;
using Fx.Amiya.Core.Interfaces.Integration;
using Fx.Amiya.Core.Interfaces.MemberCard;
using Fx.Amiya.Dto.CustomerBaseInfo;
using Fx.Amiya.Dto.CustomerInfo;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Infrastructure;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.Background.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class CustomerController : ControllerBase
    {
        private ICustomerService customerService;
        private IHttpContextAccessor httpContextAccessor;
        private ICustomerBaseInfoService customerBaseInfoService;
        private IMemberCard memberCardService;
        private IIntegrationAccount integrationAccountService;
        public CustomerController(ICustomerService customerService, IHttpContextAccessor httpContextAccessor,
            ICustomerBaseInfoService customerBaseInfoService,
            IMemberCard memberCardService, IIntegrationAccount integrationAccountService)
        {
            this.customerService = customerService;
            this.httpContextAccessor = httpContextAccessor;
            this.customerBaseInfoService = customerBaseInfoService;
            this.memberCardService = memberCardService;
            this.integrationAccountService = integrationAccountService;
        }


        /// <summary>
        /// 获取微信客户列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="employeeId">-1查全部</param>
        /// <param name="memberRankId">会员级别编号，null=全部</param>
        /// <param name="isUnTrack">是否未回访</param>
        /// <param name="BirthMonth">生日月份</param>
        /// <param name="unTrackStartDate">未回访开始时间</param>
        /// <param name="unTrackEndDate">未回访结束时间</param>
        /// <param name="amountType">订单总额类型，0=下单总额，1=核销总额</param>
        /// <returns></returns>
        [HttpGet("list")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<CustomerInfoVo>>> GetWxCustomerListAsync(string keyword, DateTime? startDate, DateTime? endDate, int? BirthMonth,
            int? employeeId, int? memberRankId, bool isUnTrack, DateTime? unTrackStartDate, DateTime? unTrackEndDate,
            int amountType, decimal? minAmount, decimal? maxAmount, int pageNum, int pageSize)
        {
            if (employeeId == null)
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                employeeId = Convert.ToInt32(employee.Id);
            }

            CustomerSearchParamDto customerSearchParamDto = new CustomerSearchParamDto();
            customerSearchParamDto.Keyword = keyword;
            customerSearchParamDto.StartDate = startDate;
            customerSearchParamDto.BirthMonth = BirthMonth;
            customerSearchParamDto.EndDate = endDate;
            customerSearchParamDto.EmployeeId = (int)employeeId;
            customerSearchParamDto.MemberRankId = memberRankId;
            customerSearchParamDto.IsUnTrack = isUnTrack;
            customerSearchParamDto.UnTrackStartDate = unTrackStartDate;
            customerSearchParamDto.UnTrackEndDate = unTrackEndDate;
            customerSearchParamDto.AmountType = amountType;
            customerSearchParamDto.MinAmount = minAmount;
            customerSearchParamDto.MaxAmount = maxAmount;
            customerSearchParamDto.PageNum = pageNum;
            customerSearchParamDto.PageSize = pageSize;

            List<MemberCardHandleDto> memberCardList;
            FxPageInfo<CustomerInfoDto> customerPage;
            List<string> customerIds = new List<string>();

            if (memberRankId == -1) //-1 = 普通客户
            {
                memberCardList = await memberCardService.GetMemberCardHandelListByMemberRankAsync(null);
                foreach (var item in memberCardList)
                {
                    customerIds.Add(item.CustomerId);
                }
                customerSearchParamDto.MemberCustomerIds = customerIds;
                customerPage = await customerService.GetWxCustomerListAsync(customerSearchParamDto);
            }


            else if (memberRankId == null) //全部
            {
                customerSearchParamDto.MemberCustomerIds = customerIds;
                customerPage = await customerService.GetWxCustomerListAsync(customerSearchParamDto);

                foreach (var item in customerPage.List)
                {
                    if (!customerIds.Exists(e => e == item.Id))
                        customerIds.Add(item.Id);
                }
                memberCardList = await memberCardService.GetMemberCardHandelListByCustomerIdsAsync(customerIds);
            }


            else //会员
            {
                memberCardList = await memberCardService.GetMemberCardHandelListByMemberRankAsync(memberRankId);
                foreach (var item in memberCardList)
                {
                    customerIds.Add(item.CustomerId);
                }
                customerSearchParamDto.MemberCustomerIds = customerIds;
                customerPage = await customerService.GetWxCustomerListAsync(customerSearchParamDto);
            }




            var customers = from d in customerPage.List
                            join m in memberCardList on d.Id equals m.CustomerId into md
                            from m in md.DefaultIfEmpty()
                            join i in await integrationAccountService.GetIntegrationAccountListByCustomerIdsAsync(customerIds) on d.Id equals i.CustomerId into di
                            from i in di.DefaultIfEmpty()
                            select new CustomerInfoVo
                            {
                                Id = d.Id,
                                CreateDate = d.CreateDate,
                                UserId = d.UserId,
                                Phone = d.Phone,
                                EncryptPhone = d.EncryptPhone,
                                Province = d.Province,
                                City = d.City,
                                NickName = d.NickName,
                                Avatar = d.Avatar,
                                CustomerServiceId = d.CustomerServiceId,
                                CustomerServiceName = d.CustomerServiceName,
                                Name = d.Name,
                                Sex = d.Sex,
                                MemberRank = m?.MemberRankName,
                                MemberCardNum = m?.MemberCardNum,
                                IntegrationBalance = i == null ? 0m : i.Balance
                            };
            FxPageInfo<CustomerInfoVo> customerPageInfo = new FxPageInfo<CustomerInfoVo>();
            customerPageInfo.TotalCount = customerPage.TotalCount;
            customerPageInfo.List = customers;
            return ResultData<FxPageInfo<CustomerInfoVo>>.Success().AddData("customer", customerPageInfo);
        }

        /// <summary>
        /// 获取绑定了客服的客户列表
        /// </summary>
        /// <param name="employeeId">-1查全部</param>
        /// <param name="keyword"></param>
        /// <param name="type">0=全部，1=已注册小程序，2=未注册小程序</param>
        /// <param name="isUnTrack">是否未回访</param>
        /// <param name="unTrackStartDate">未回访开始时间</param>
        /// <param name="unTrackEndDate">未回访结束时间</param>
        /// <param name="amountType">订单总额类型，0=下单总额，1=核销总额</param>
        /// <returns></returns>
        [HttpGet("bindCustomerServerList")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<CustomerInfoVo>>> GetBindCustomerServiceListAsync(string keyword, DateTime? startDate, DateTime? endDate,
              int? employeeId, int type, bool isUnTrack, DateTime? unTrackStartDate, DateTime? unTrackEndDate,
              int amountType, decimal? minAmount, decimal? maxAmount, int pageNum, int pageSize)
        {
            if (employeeId == null)
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                employeeId = Convert.ToInt32(employee.Id);
            }

            CustomerSearchParamDto customerSearchParamDto = new CustomerSearchParamDto();
            customerSearchParamDto.Keyword = keyword;
            customerSearchParamDto.StartDate = startDate;
            customerSearchParamDto.EndDate = endDate;
            customerSearchParamDto.EmployeeId = (int)employeeId;
            customerSearchParamDto.IsUnTrack = isUnTrack;
            customerSearchParamDto.UnTrackStartDate = unTrackStartDate;
            customerSearchParamDto.UnTrackEndDate = unTrackEndDate;
            customerSearchParamDto.AmountType = amountType;
            customerSearchParamDto.MinAmount = minAmount;
            customerSearchParamDto.MaxAmount = maxAmount;
            customerSearchParamDto.CustomerType = type;
            customerSearchParamDto.PageNum = pageNum;
            customerSearchParamDto.PageSize = pageSize;


            var q = await customerService.GetBindCustomerServiceListAsync(customerSearchParamDto);
            var customer = from d in q.List
                           select new CustomerInfoVo
                           {
                               Id = d.Id,
                               CreateDate = d.CreateDate,
                               UserId = d.UserId,
                               Phone = d.Phone,
                               EncryptPhone = d.EncryptPhone,
                               Province = d.Province,
                               City = d.City,
                               NickName = d.NickName,
                               Avatar = d.Avatar,
                               CustomerServiceId = d.CustomerServiceId,
                               CustomerServiceName = d.CustomerServiceName,
                               Name = d.Name,
                               Sex = d.Sex
                           };
            FxPageInfo<CustomerInfoVo> customerPageInfo = new FxPageInfo<CustomerInfoVo>();
            customerPageInfo.TotalCount = q.TotalCount;
            customerPageInfo.List = customer;
            return ResultData<FxPageInfo<CustomerInfoVo>>.Success().AddData("customer", customerPageInfo);

        }


        /// <summary>
        /// 获取绑定了客服的客户消费列表
        /// </summary>
        /// <param name="employeeId">-1查全部</param>
        /// <param name="keyword"></param>
        /// <param name="startDate">开始时间</param>
        /// <param name="channel">下单渠道（1：下单平台，2：内容平台,3：客户升单）</param>
        /// <param name="orderId">订单号</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="CconsumptionLevelId">消费等级id（空查询所有）</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("bindCustomerConsumptionServerList")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<CustomerConsumptionInfoVo>>> GetBindCustomerConsumptionServiceListAsync(string keyword, DateTime? startDate, DateTime? endDate, int? employeeId, string CconsumptionLevelId, int channel, string orderId, int pageNum, int pageSize)
        {
            //if (startDate.HasValue && endDate.HasValue)
            //{
            //    if ((endDate.Value - startDate.Value).TotalDays > 30)
            //    {
            //        throw new Exception("开始时间与结束时间不能超过一个月，请重新选择后再进行查询！");
            //    }
            //}
            if (employeeId == null)
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                employeeId = Convert.ToInt32(employee.Id);
            }

            CustomerCunsumptionSearchParamDto customerSearchParamDto = new CustomerCunsumptionSearchParamDto();
            customerSearchParamDto.Keyword = keyword;
            customerSearchParamDto.StartDate = startDate;
            customerSearchParamDto.EndDate = endDate;
            customerSearchParamDto.EmployeeId = (int)employeeId;
            customerSearchParamDto.ConsumptionLevelId = CconsumptionLevelId;
            customerSearchParamDto.PageNum = pageNum;
            customerSearchParamDto.Channel = channel;
            customerSearchParamDto.OrderId = orderId;
            customerSearchParamDto.PageSize = pageSize;


            var q = await customerService.GetBindCustomerConsumptionServiceListAsync(customerSearchParamDto);
            var customer = from d in q.List
                           select new CustomerConsumptionInfoVo
                           {
                               Id = d.Id,
                               CreateDate = d.CreateDate,
                               UserId = d.UserId,
                               Phone = d.Phone,
                               EncryptPhone = d.EncryptPhone,
                               Province = d.Province,
                               City = d.City,
                               Avatar = d.Avatar,
                               CustomerServiceId = d.CustomerServiceId,
                               CustomerServiceName = d.CustomerServiceName,
                               NewConsumptionPlatFormId = d.NewConsumptionPlatFormId,
                               NewConsumptionPlatForm = d.NewConsumptionPlatForm,
                               NewConsumptionTime = d.NewConsumptionTime,
                               AllConsumptionPrice = d.AllConsumptionPrice,
                               CreatedOrderNum = d.CreatedOrderNum,
                               FirstOrderInfo = d.FirstOrderInfo,
                               FirstOrderCreateDate = d.FirstOrderCreateDate,
                               NewConsumptionPlatFormAppTypeText = d.NewConsumptionPlatFormAppTypeText
                           };
            FxPageInfo<CustomerConsumptionInfoVo> customerPageInfo = new FxPageInfo<CustomerConsumptionInfoVo>();
            customerPageInfo.TotalCount = q.TotalCount;
            customerPageInfo.List = customer;
            return ResultData<FxPageInfo<CustomerConsumptionInfoVo>>.Success().AddData("customer", customerPageInfo);

        }


        /// <summary>
        /// 获取客户回访情况列表
        /// </summary>
        /// <param name="employeeId">-1查全部</param>
        /// <param name="startDate">客户创建开始时间</param>
        /// <param name="endDate">客户创建结束时间</param>
        /// <param name="isUnTrack">是否制定回访(0查询所有，1：已回访过，2：未回访过)</param>
        /// <param name="keyword">关键字</param>
        /// <param name="type">0=全部，1=已注册小程序，2=未注册小程序</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("CustomerTrackServerList")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<BindTrackCustomerInfoVo>>> GetCustomerTrackServiceListAsync(string keyword, DateTime? startDate, DateTime? endDate, int isUnTrack, int? employeeId, int type, int pageNum, int pageSize)
        {
            //if(startDate.HasValue&&endDate.HasValue)
            //{
            //    if ((endDate.Value - startDate.Value).TotalDays > 30)
            //    {
            //        throw new Exception("开始时间与结束时间不能超过一个月，请重新选择后再进行查询！");
            //    }
            //}
            if (employeeId == null)
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                employeeId = Convert.ToInt32(employee.Id);
            }

            CustomerTrackInfoSearchDto trackInfoDto = new CustomerTrackInfoSearchDto();
            trackInfoDto.Keyword = keyword;
            trackInfoDto.StartDate = startDate;
            trackInfoDto.EndDate = endDate;
            trackInfoDto.IsUnTrack = isUnTrack;
            trackInfoDto.EmployeeId = employeeId.Value;
            trackInfoDto.PageNum = pageNum;
            trackInfoDto.PageSize = pageSize;
            trackInfoDto.CustomerType = type;
            var q = await customerService.GetCustomerTrackServiceListAsync(trackInfoDto);
            var customer = from d in q.List
                           select new BindTrackCustomerInfoVo
                           {
                               Id = d.Id,
                               CreateDate = d.CreateDate,
                               UserId = d.UserId,
                               Phone = d.Phone,
                               EncryptPhone = d.EncryptPhone,
                               Province = d.Province,
                               City = d.City,
                               NickName = d.NickName,
                               Avatar = d.Avatar,
                               CustomerServiceId = d.CustomerServiceId,
                               CustomerServiceName = d.CustomerServiceName,
                               Name = d.Name,
                               Sex = d.Sex,
                               IsTrack = d.IsTrack,
                               IsTrackId = d.IsTrackId,
                               LatestTrackTime = d.LatestTrackTime,
                           };
            FxPageInfo<BindTrackCustomerInfoVo> customerPageInfo = new FxPageInfo<BindTrackCustomerInfoVo>();
            customerPageInfo.TotalCount = q.TotalCount;
            customerPageInfo.List = customer;
            return ResultData<FxPageInfo<BindTrackCustomerInfoVo>>.Success().AddData("customer", customerPageInfo);

        }


        /// <summary>
        /// 根据用户编号获取客户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("byUserId/{userId}")]
        [FxInternalAuthorize]
        public async Task<ResultData<CustomerInfoVo>> GetByUserIdAsync(string userId)
        {
            try
            {
                var customerDetail = await customerService.GetByUserIdAsync(userId);
                if (customerDetail == null)
                    return ResultData<CustomerInfoVo>.Success().AddData("customer", null);

                CustomerInfoVo customerInfoVo = new CustomerInfoVo();
                customerInfoVo.Id = customerDetail.Id;
                customerInfoVo.CreateDate = customerDetail.CreateDate;
                customerInfoVo.UserId = customerDetail.UserId;
                customerInfoVo.Phone = customerDetail.Phone;
                customerInfoVo.EncryptPhone = customerDetail.EncryptPhone;
                customerInfoVo.Province = customerDetail.Province;
                customerInfoVo.City = customerDetail.City;
                customerInfoVo.Avatar = customerDetail.Avatar;
                customerInfoVo.NickName = customerDetail.NickName;



                return ResultData<CustomerInfoVo>.Success().AddData("customer", customerInfoVo);

            }
            catch (Exception ex)
            {
                return ResultData<CustomerInfoVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 获取客户数量
        /// </summary>
        /// <returns></returns>
        [HttpGet("quantity")]
        [FxInternalAuthorize]
        public async Task<ResultData<CustomerQuantityVo>> GetCustomerQuantityAsync()
        {
            var q = await customerService.GetCustomerQuantityAsync();
            CustomerQuantityVo customerQuantityVo = new CustomerQuantityVo();
            customerQuantityVo.BindCustomerServiceTotalQuantity = q.BindCustomerServiceTotalQuantity;
            customerQuantityVo.TodayBindCustomerServiceQuantity = q.TodayBindCustomerServiceQuantity;
            customerQuantityVo.MiniProgramCustomerTotalQuantity = q.MiniProgramCustomerTotalQuantity;
            customerQuantityVo.UnMiniProgramCustomerTotalQuantity = q.UnMiniProgramCustomerTotalQuantity;
            return ResultData<CustomerQuantityVo>.Success().AddData("customerQuantity", customerQuantityVo);
        }






        /// <summary>
        /// 根据电话号查询客户信息
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        [HttpGet("byPhone/{phone}")]
        [FxInternalAuthorize]
        public async Task<ResultData<BindCustomerInfoVo>> GetByPhoneAsync(string phone)
        {
            var customer = await customerService.GetByPhoneAsync(phone);
            BindCustomerInfoVo bindCustomerInfoVo = new BindCustomerInfoVo();
            bindCustomerInfoVo.Id = customer.Id;
            bindCustomerInfoVo.CreateDate = customer.CreateDate;
            bindCustomerInfoVo.UserId = customer.UserId;
            bindCustomerInfoVo.Phone = customer.Phone;
            bindCustomerInfoVo.EncryptPhone = customer.EncryptPhone;
            bindCustomerInfoVo.Province = customer.Province;
            bindCustomerInfoVo.City = customer.City;
            bindCustomerInfoVo.NickName = customer.NickName;
            bindCustomerInfoVo.Avatar = customer.Avatar;
            bindCustomerInfoVo.CustomerServiceId = customer.CustomerServiceId;
            bindCustomerInfoVo.CustomerServiceName = customer.CustomerServiceName;
            return ResultData<BindCustomerInfoVo>.Success().AddData("custoemr", bindCustomerInfoVo);

        }

        /// <summary>
        /// 解密手机号
        /// </summary>
        /// <param name="encryptPhone"></param>
        /// <returns></returns>
        [HttpGet("decryptoPhone/{encryptPhone}")]
        [FxInternalAuthorize]
        public async Task<ResultData<string>> DecryptoPhone(string encryptPhone)
        {
            string phone = await customerService.DecryptoPhone(encryptPhone);
            return ResultData<string>.Success().AddData("phone", phone);
        }


        /// <summary>
        /// 根据加密电话查询简单的客户信息
        /// </summary>
        /// <param name="encryptPhone"></param>
        /// <returns></returns>
        [HttpGet("simpleInfoByEncryptPhone/{encryptPhone}")]
        [FxInternalAuthorize]
        public async Task<ResultData<CustomerSimpleInfoVo>> GetCustomerSimpleByPhoneAsync(string encryptPhone)
        {
            var customer = await customerService.GetCustomerSimpleByPhoneAsync(encryptPhone);
            CustomerSimpleInfoVo customerSimpleInfoVo = new CustomerSimpleInfoVo();
            customerSimpleInfoVo.Id = customer.Id;
            customerSimpleInfoVo.Name = customer.Name;
            customerSimpleInfoVo.Phone = customer.Phone;
            customerSimpleInfoVo.EncryptPhone = customer.EncryptPhone;
            customerSimpleInfoVo.TradeFinishedOrderQuantity = customer.TradeFinishedOrderQuantity;
            customerSimpleInfoVo.PaymentOrderQuantity = customer.PaymentOrderQuantity;
            return ResultData<CustomerSimpleInfoVo>.Success().AddData("customer", customerSimpleInfoVo);
        }


        /// <summary>
        /// 根据加密电话查询客户资料
        /// </summary>
        /// <param name="encryptPhone">加密电话</param>
        /// <returns></returns>
        [HttpGet("getBaseAndBindCustomerInfoByEncryptPhone")]
        [FxInternalAuthorize]
        public async Task<ResultData<CustomerBaseDetailInfoVo>> GetBaseAndBindCustomerInfoByPhoneAsync(string encryptPhone)
        {
            var customer = await customerBaseInfoService.GetByEncryptPhoneAsync(encryptPhone);
            CustomerBaseDetailInfoVo customerSimpleInfoVo = new CustomerBaseDetailInfoVo();
            customerSimpleInfoVo.Id = customer.Id;
            customerSimpleInfoVo.BindCustomerServiceId = customer.BindCustomerServiceId;
            customerSimpleInfoVo.Avatar = customer.Avatar;
            customerSimpleInfoVo.Name = customer.Name;
            customerSimpleInfoVo.MemberCardNo = customer.MemberCardNo;
            customerSimpleInfoVo.MemberRankName = customer.MemberRankName;
            customerSimpleInfoVo.CreateDate = customer.CreateDate;
            customerSimpleInfoVo.AllPrice = customer.AllPrice;
            customerSimpleInfoVo.RealName = customer.RealName;
            customerSimpleInfoVo.Sex = customer.Sex;
            customerSimpleInfoVo.Phone = customer.Phone;
            customerSimpleInfoVo.Birthday = customer.Birthday;
            customerSimpleInfoVo.Age = customer.Age;
            customerSimpleInfoVo.Occupation = customer.Occupation;
            customerSimpleInfoVo.FirstProjectDemand = customer.FirstProjectDemand;
            customerSimpleInfoVo.NewConsumptionContentPlatform = customer.NewConsumptionContentPlatform;
            customerSimpleInfoVo.PersonalWechat = customer.PersonalWechat;
            customerSimpleInfoVo.BusinessWeChat = customer.BusinessWeChat;
            customerSimpleInfoVo.WechatMiniProgram = customer.WechatMiniProgram;
            customerSimpleInfoVo.OfficialAccounts = customer.OfficialAccounts;
            customerSimpleInfoVo.BelongCustomerService = customer.BelongCustomerService;
            customerSimpleInfoVo.NewContentPlatForm = customer.NewContentPlatform;
            customerSimpleInfoVo.OtherPhone = customer.OtherPhone;
            customerSimpleInfoVo.DetailAddress = customer.DetailAddress;
            customerSimpleInfoVo.IsSendNote = customer.IsSendNote;
            customerSimpleInfoVo.IsCall = customer.IsCall;
            customerSimpleInfoVo.IsSendWeChat = customer.IsSendWeChat;
            customerSimpleInfoVo.UnTrackReason = customer.UnTrackReason;
            customerSimpleInfoVo.ConsumptionLevel = customer.ConsumptionLevel;
            customerSimpleInfoVo.CustomerState = customer.CustomerState;
            customerSimpleInfoVo.CustomerRequirement = customer.CustomerRequirement;
            customerSimpleInfoVo.WechatNumber = customer.WechatNumber;
            customerSimpleInfoVo.City = customer.City;
            customerSimpleInfoVo.Remark = customer.Remark;
            return ResultData<CustomerBaseDetailInfoVo>.Success().AddData("customer", customerSimpleInfoVo);
        }




        /// <summary>
        /// 获取医院客户列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listOfHospital")]
        [FxTenantAuthorize]
        public async Task<ResultData<FxPageInfo<CustomerInfoVo>>> GetListOfHospitalAsync(string keyword, int pageNum, int pageSize)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaHospitalEmployeeIdentity;

            int hospitalId = employee.HospitalId;
            var customerPageInfoDto = await customerService.GetCustomerListByHospitalIdAsync(hospitalId, keyword, pageNum, pageSize);
            var customers = from d in customerPageInfoDto.List
                            select new CustomerInfoVo
                            {
                                Id = d.Id,
                                CreateDate = d.CreateDate,
                                UserId = d.UserId,
                                Phone = d.Phone,
                                EncryptPhone = d.EncryptPhone,
                                Province = d.Province,
                                City = d.City,
                                NickName = d.NickName,
                                Avatar = d.Avatar,
                                Name = d.Name,
                                Sex = d.Sex
                            };
            FxPageInfo<CustomerInfoVo> customerPageInfo = new FxPageInfo<CustomerInfoVo>();
            customerPageInfo.TotalCount = customerPageInfoDto.TotalCount;
            customerPageInfo.List = customers;
            return ResultData<FxPageInfo<CustomerInfoVo>>.Success().AddData("customer", customerPageInfo);
        }


        /// <summary>
        /// 根据电话号码编辑客户基础信息
        /// </summary>
        /// <param name="editVo"></param>
        /// <returns></returns>
        [HttpPut("baseInfo")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> EditByPhoneAsync(EditCustomerBaseInfoVo editVo)
        {
            EditCustomerDto editDto = new EditCustomerDto();
            editDto.EncryptPhone = editVo.EncryptPhone;
            editDto.Name = editVo.Name;
            editDto.Sex = editVo.Sex;
            editDto.Birthday = editVo.Birthday;
            editDto.Occupation = editVo.Occupation;
            editDto.WechatNumber = editVo.WechatNumber;
            editDto.City = editVo.City;
            await customerService.EditAsync(editDto);
            return ResultData.Success();
        }

        /// <summary>
        /// 根据Id编辑客户基础信息
        /// </summary>
        /// <param name="editVo"></param>
        /// <returns></returns>
        [HttpPut("updateById")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> EditByIdAsync(UpdateCustomerBaseInfoVo editVo)
        {
            UpdateCustomerBaseInfoDto editDto = new UpdateCustomerBaseInfoDto();
            editDto.Id = editVo.Id;
            editDto.PersonalWechat = editVo.PersonalWechat;
            editDto.BusinessWeChat = editVo.BusinessWeChat;
            editDto.WechatMiniProgram = editVo.WechatMiniProgram;
            editDto.OfficialAccounts = editVo.OfficialAccounts;
            editDto.RealName = editVo.RealName;
            editDto.WechatNumber = editVo.WechatNumber;
            editDto.Sex = editVo.Sex;
            editDto.Birthday = editVo.Birthday;
            editDto.City = editVo.City;
            editDto.Occupation = editVo.Occupation;
            editDto.OtherPhone = editVo.OtherPhone;
            editDto.DetailAddress = editVo.DetailAddress;
            editDto.IsSendNote = editVo.IsSendNote;
            editDto.IsCall = editVo.IsCall;
            editDto.IsSendWeChat = editVo.IsSendWeChat;
            editDto.UnTrackReason = editVo.UnTrackReason;
            editDto.Remark = editVo.Remark;
            await customerBaseInfoService.UpdateAsync(editDto);
            return ResultData.Success();
        }


        /// <summary>
        /// 根据加密电话号获取客户基础信息
        /// </summary>
        /// <param name="encryptPhone"></param>
        /// <returns></returns>
        [HttpGet("baseInfoByEncryptPhone")]
        public async Task<ResultData<CustomerBaseInfoVo>> GetCustomerBaseInfoByEncryptPhoneAsync(string encryptPhone)
        {
            var customerBaseInfo = await customerService.GetCustomerBaseInfoByEncryptPhoneAsync(encryptPhone);
            CustomerBaseInfoVo customerBaseInfoVo = new CustomerBaseInfoVo();
            customerBaseInfoVo.Id = customerBaseInfo.Id;
            customerBaseInfoVo.Name = customerBaseInfo.Name;
            customerBaseInfoVo.Sex = customerBaseInfo.Sex;
            customerBaseInfoVo.Birthday = customerBaseInfo.Birthday;
            customerBaseInfoVo.Occupation = customerBaseInfo.Occupation;
            customerBaseInfoVo.WechatNumber = customerBaseInfo.WechatNumber;
            customerBaseInfoVo.City = customerBaseInfo.City;
            customerBaseInfoVo.EncryptPhone = customerBaseInfo.EncryptPhone;
            customerBaseInfoVo.Age = customerBaseInfo.Age;
            return ResultData<CustomerBaseInfoVo>.Success().AddData("customerBaseInfo", customerBaseInfoVo);
        }

        /// <summary>
        /// 根据加密电话获取详细信息
        /// </summary>
        /// <param name="encryptPhone"></param>
        /// <returns></returns>

        [HttpGet("detailInfoByEncryptPhone")]
        [FxInternalAuthorize]
        public async Task<ResultData<CustomerDetailInfoVo>> GetCustomerDetailInfoByEncryptPhoneAsync(string encryptPhone)
        {
            string customerId = await customerService.GetCustomerIdByEncryptPhoneAsync(encryptPhone);

            CustomerDetailInfoVo customerDetailInfo = new CustomerDetailInfoVo();
            if (string.IsNullOrWhiteSpace(customerId))
            {
                customerDetailInfo.IntegrationBalance = 0m;
                customerDetailInfo.MemberCardNum = null;
                customerDetailInfo.MemberRank = null;
            }
            else
            {
                customerDetailInfo.IntegrationBalance = await integrationAccountService.GetIntegrationBalanceByCustomerIDAsync(customerId);
                var memberCardInfo = await memberCardService.GetMemberCardHandelByCustomerIdAsync(customerId);
                customerDetailInfo.MemberCardNum = memberCardInfo?.MemberCardNum;
                customerDetailInfo.MemberRank = memberCardInfo?.MemberRankName;
            }
            var customerBaseInfo = await customerService.GetCustomerBaseInfoByEncryptPhoneAsync(encryptPhone);
            customerDetailInfo.Name = customerBaseInfo.Name;
            customerDetailInfo.Sex = customerBaseInfo.Sex;
            customerDetailInfo.Birthday = customerBaseInfo.Birthday;
            customerDetailInfo.Occupation = customerBaseInfo.Occupation;
            customerDetailInfo.WechatNumber = customerBaseInfo.WechatNumber;
            customerDetailInfo.City = customerBaseInfo.City;
            customerDetailInfo.Age = customerBaseInfo.Age;


            return ResultData<CustomerDetailInfoVo>.Success().AddData("customerDetailInfo", customerDetailInfo);
        }
    }
}