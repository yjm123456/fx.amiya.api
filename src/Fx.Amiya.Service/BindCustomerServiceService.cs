using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.BindCustomerService;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Fx.Infrastructure.Utils;
using Fx.Amiya.Dto.WxAppConfig;
using Newtonsoft.Json;

namespace Fx.Amiya.Service
{
    public class BindCustomerServiceService : IBindCustomerServiceService
    {
        private IDalBindCustomerService dalBindCustomerService;
        private IUnitOfWork unitOfWork;
        private IDalCustomerInfo dalCustomerInfo;
        private IDalAmiyaEmployee _dalAmiyaEmployee;
        private IAmiyaHospitalDepartmentService amiyaHospitalDepartmentService;
        private IDalOrderInfo dalOrderInfo;
        private IDalConfig dalConfig;
        private IItemInfoService itemInfoService;
        public BindCustomerServiceService(IDalBindCustomerService dalBindCustomerService,
            IUnitOfWork unitOfWork,
            IDalAmiyaEmployee dalAmiyaEmployee,
            IDalCustomerInfo dalCustomerInfo,
            IAmiyaHospitalDepartmentService amiyaHospitalDepartmentService,
            IDalOrderInfo dalOrderInfo,
            IItemInfoService itemInfoService,
            IDalConfig dalConfig)
        {
            this.dalBindCustomerService = dalBindCustomerService;
            this.unitOfWork = unitOfWork;
            _dalAmiyaEmployee = dalAmiyaEmployee;
            this.itemInfoService = itemInfoService;
            this.dalCustomerInfo = dalCustomerInfo;
            this.amiyaHospitalDepartmentService = amiyaHospitalDepartmentService;
            this.dalOrderInfo = dalOrderInfo;
            this.dalConfig = dalConfig;
        }

        public async Task AddAsync(AddBindCustomerServiceDto addDto, int employeeId)
        {
            try
            {
                DateTime date = DateTime.Now;
                List<BindCustomerService> bindCustomerServiceList = new List<BindCustomerService>();
                List<string> phoneList = new List<string>();

                foreach (var orderId in addDto.OrderIdList)
                {
                    var order = await dalOrderInfo.GetAll().SingleOrDefaultAsync(e => e.Id == orderId);
                    if (order != null)
                    {
                        int bindCount = await dalBindCustomerService.GetAll().CountAsync(e => e.BuyerPhone == order.Phone);
                        if (bindCount == 0 && !phoneList.Exists(e => e == order?.Phone))
                        {
                            phoneList.Add(order.Phone);

                            var user = await dalCustomerInfo.GetAll().SingleOrDefaultAsync(e => e.Phone == order.Phone);
                            BindCustomerService bindCustomerService = new BindCustomerService();
                            bindCustomerService.CustomerServiceId = addDto.CustomerServiceId;
                            bindCustomerService.BuyerPhone = order.Phone;
                            bindCustomerService.UserId = user?.UserId;
                            bindCustomerService.CreateBy = employeeId;
                            bindCustomerService.CreateDate = date;
                            string department = "";
                            var goodsInfo = await itemInfoService.GetByOtherAppItemIdAsync(order.GoodsId);
                            if (goodsInfo != null)
                            {
                                var departmentInfo = await amiyaHospitalDepartmentService.GetByIdAsync(goodsInfo.HospitalDepartmentId);
                                if (departmentInfo != null)
                                { department = "(" + departmentInfo.DepartmentName + ")"; }
                            }
                            bindCustomerService.FirstProjectDemand = department + order.GoodsName;
                            bindCustomerService.FirstConsumptionDate = order.CreateDate;
                            bindCustomerService.NewConsumptionDate = order.CreateDate;
                            bindCustomerService.NewConsumptionContentPlatform = (int)OrderFrom.ThirdPartyOrder;
                            bindCustomerService.NewContentPlatForm = ServiceClass.GetAppTypeText(order.AppType);
                            if (order.StatusCode == "TRADE_FINISHED")
                            {
                                bindCustomerService.AllPrice = order.ActualPayment;
                            }
                            else
                            {
                                bindCustomerService.AllPrice = 0.00M;
                            }
                            bindCustomerService.AllOrderCount = order.Quantity;
                            bindCustomerServiceList.Add(bindCustomerService);
                        }
                    }
                }
                await dalBindCustomerService.AddCollectionAsync(bindCustomerServiceList, true);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BindCustomerServiceDto> GetEmployeeDetailsByPhoneAsync(string phone)
        {
            try
            {
                var bindCustomerServiceInfo = await dalBindCustomerService.GetAll().Include(x => x.CustomerServiceAmiyaEmployee).FirstOrDefaultAsync(e => e.BuyerPhone == phone);
                BindCustomerServiceDto result = new BindCustomerServiceDto();
                if (bindCustomerServiceInfo == null)
                {
                    return result;
                }
                result.Id = bindCustomerServiceInfo.Id;
                result.CustomerServiceId = bindCustomerServiceInfo.CustomerServiceId;
                result.CustomerServiceName = bindCustomerServiceInfo.CustomerServiceAmiyaEmployee.Name;
                result.BuyerPhone = bindCustomerServiceInfo.BuyerPhone;
                result.UserId = bindCustomerServiceInfo.UserId;
                result.CreateBy = bindCustomerServiceInfo.CreateBy;
                result.CreateDate = bindCustomerServiceInfo.CreateDate;
                result.FirstProjectDemand = bindCustomerServiceInfo.FirstProjectDemand;
                result.FirstConsumptionDate = bindCustomerServiceInfo.FirstConsumptionDate;
                result.NewConsumptionDate = bindCustomerServiceInfo.NewConsumptionDate;
                result.NewConsumptionContentPlatform = bindCustomerServiceInfo.NewConsumptionContentPlatform;
                result.NewContentPlatForm = bindCustomerServiceInfo.NewContentPlatForm;
                result.AllPrice = bindCustomerServiceInfo.AllPrice;
                result.AllOrderCount = bindCustomerServiceInfo.AllOrderCount;
                return result;
            }
            catch (Exception err)
            { return new BindCustomerServiceDto(); }

        }

        public async Task<BindCustomerServiceDto> GetByIdAsync(int id)
        {
            try
            {
                var bindCustomerServiceInfo = await dalBindCustomerService.GetAll().Include(x => x.CustomerServiceAmiyaEmployee).FirstOrDefaultAsync(e => e.Id == id);
                BindCustomerServiceDto result = new BindCustomerServiceDto();
                result.Id = bindCustomerServiceInfo.Id;
                result.CustomerServiceId = bindCustomerServiceInfo.CustomerServiceId;
                result.CustomerServiceName = bindCustomerServiceInfo.CustomerServiceAmiyaEmployee.Name;
                result.BuyerPhone = bindCustomerServiceInfo.BuyerPhone;
                result.UserId = bindCustomerServiceInfo.UserId;
                result.CreateBy = bindCustomerServiceInfo.CreateBy;
                result.CreateDate = bindCustomerServiceInfo.CreateDate;
                result.FirstProjectDemand = bindCustomerServiceInfo.FirstProjectDemand;
                result.FirstConsumptionDate = bindCustomerServiceInfo.FirstConsumptionDate;
                result.NewConsumptionDate = bindCustomerServiceInfo.NewConsumptionDate;
                result.NewConsumptionContentPlatform = bindCustomerServiceInfo.NewConsumptionContentPlatform;
                result.NewContentPlatForm = bindCustomerServiceInfo.NewContentPlatForm;
                result.AllPrice = bindCustomerServiceInfo.AllPrice;
                result.AllOrderCount = bindCustomerServiceInfo.AllOrderCount;
                return result;
            }
            catch (Exception err)
            { return new BindCustomerServiceDto(); }

        }

        public async Task<MyCustomerInfoDto> GetCustomerCountByEmployeeIdAsync(int employeeId)
        {
            try
            {
                var bindCustomerServiceInfo = await dalBindCustomerService.GetAll().ToListAsync();
                var employee = await _dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).SingleOrDefaultAsync(e => e.Id == employeeId);
                bindCustomerServiceInfo = bindCustomerServiceInfo.Where(e => e.CustomerServiceId == employeeId).ToList();
                //if (employee.IsCustomerService && !employee.AmiyaPositionInfo.IsDirector)
                //{ }
                MyCustomerInfoDto result = new MyCustomerInfoDto();
                result.MyCustomerCount = bindCustomerServiceInfo.Count();
                result.SevenDaysInsertCount = bindCustomerServiceInfo.Where(x => x.CreateDate > DateTime.Now.Date.AddDays(-7)).Count();
                result.TodayInsertCount = bindCustomerServiceInfo.Where(x => x.CreateDate > DateTime.Now.Date && x.CreateDate <= DateTime.Now.Date.AddDays(1)).Count();
                return result;
            }
            catch (Exception err)
            { return new MyCustomerInfoDto(); }

        }

        public async Task<int> GetEmployeeIdByPhone(string phone)
        {
            try
            {
                var bindCustomerServiceInfo = await dalBindCustomerService.GetAll().SingleOrDefaultAsync(e => e.BuyerPhone == phone);
                if (bindCustomerServiceInfo != null && bindCustomerServiceInfo.CustomerServiceId != 0)
                {
                    return bindCustomerServiceInfo.CustomerServiceId;
                }
                else { return 0; }
            }
            catch (Exception err)
            { return 0; }

        }
        public async Task<List<string>> GetEmployeePhoneByPhone(string phone)
        {
            try
            {
                var bindCustomerServiceInfo = await dalBindCustomerService.GetAll().Where(e => e.BuyerPhone.Contains(phone)).ToListAsync();

                return bindCustomerServiceInfo.Select(x => x.BuyerPhone).ToList();

            }
            catch (Exception err)
            {
                return new List<string>();
            }

        }

        /// <summary>
        /// 根据手机号获取绑定客服
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public async Task<string> GetBindCustomerServiceNameByPhone(string phone)
        {
            var bindCustomerServiceInfo = await dalBindCustomerService.GetAll().Include(x => x.CustomerServiceAmiyaEmployee).OrderByDescending(x => x.CreateDate).Where(e => e.BuyerPhone.Contains(phone)).SingleOrDefaultAsync();
            if (bindCustomerServiceInfo != null)
            {
                return bindCustomerServiceInfo.CustomerServiceAmiyaEmployee.Name;
            }
            else
            {
                return "未绑定";
            }

        }

        /// <summary>
        /// 小程序绑定客户时修改绑定客服的userId
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task UpdateBindUserIdAsync(string customerId)
        {
            var customer = await dalCustomerInfo.GetAll().SingleOrDefaultAsync(e => e.Id == customerId);
            if (customer != null)
            {
                var bindCustomerService = await dalBindCustomerService.GetAll().SingleOrDefaultAsync(e => e.BuyerPhone == customer.Phone);
                if (bindCustomerService != null)
                {
                    bindCustomerService.UserId = customer.UserId;
                    await dalBindCustomerService.UpdateAsync(bindCustomerService, true);
                }

            }
        }
        /// <summary>
        /// 新增累计消费金额
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task UpdateConsumePriceAsync(string phone, decimal Price, int Channel, string newLiveAnchor, string newWeChatNo, string newContentPlatForm, int AllOrderCount)
        {
            var bindCustomerService = await dalBindCustomerService.GetAll().FirstOrDefaultAsync(e => e.BuyerPhone == phone);
            if (bindCustomerService != null)
            {
                if (bindCustomerService.AllPrice == null || bindCustomerService.AllPrice.Value == 0)
                {
                    bindCustomerService.AllPrice = Price;
                }
                else
                {
                    bindCustomerService.AllPrice += Price;
                }
                if (bindCustomerService.AllOrderCount.HasValue)
                {
                    bindCustomerService.AllOrderCount += AllOrderCount;
                }
                else
                {
                    bindCustomerService.AllOrderCount = AllOrderCount;
                }
                bindCustomerService.NewConsumptionContentPlatform = Channel;
                if (!string.IsNullOrEmpty(newLiveAnchor))
                {
                    bindCustomerService.NewLiveAnchor = newLiveAnchor;
                }
                if (!string.IsNullOrEmpty(newWeChatNo))
                {
                    bindCustomerService.NewWechatNo = newWeChatNo;
                }
                if (!string.IsNullOrEmpty(newContentPlatForm))
                {
                    bindCustomerService.NewContentPlatForm = newContentPlatForm;
                }
                bindCustomerService.NewConsumptionDate = DateTime.Now;

                await dalBindCustomerService.UpdateAsync(bindCustomerService, true);
            }

        }

        /// <summary>
        /// 减少累计消费金额
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task ReduceConsumePriceAsync(string phone, decimal Price, int Channel)
        {
            var bindCustomerService = await dalBindCustomerService.GetAll().FirstOrDefaultAsync(e => e.BuyerPhone == phone);
            if (bindCustomerService != null)
            {
                bindCustomerService.AllPrice -= Price;

                bindCustomerService.AllOrderCount -= 1;
                await dalBindCustomerService.UpdateAsync(bindCustomerService, true);
            }

        }


        private async Task<CallCenterConfigDto> GetCallCenterConfig()
        {
            var config = await dalConfig.GetAll().SingleOrDefaultAsync();
            return JsonConvert.DeserializeObject<WxAppConfigDto>(config.ConfigJson).CallCenterConfig;
        }





        /// <summary>
        /// 修改绑定客服
        /// </summary>
        /// <param name="updateDto"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateBindCustomerServiceDto updateDto, int employeeId)
        {
            DateTime date = DateTime.Now;
            List<string> encryptPhoneList = updateDto.EncryptPhoneList.Distinct().ToList();
            var config = await GetCallCenterConfig();
            foreach (var encryptPhone in encryptPhoneList)
            {
                string phone = ServiceClass.Decrypto(encryptPhone, config.PhoneEncryptKey);
                var customer = await dalCustomerInfo.GetAll().SingleOrDefaultAsync(e => e.Phone == phone);

                var bindCustomerServiceInfo = await dalBindCustomerService.GetAll().SingleOrDefaultAsync(e => e.BuyerPhone == phone);
                if (bindCustomerServiceInfo != null)
                {
                    bindCustomerServiceInfo.CustomerServiceId = updateDto.CustomerServiceId;
                    bindCustomerServiceInfo.UserId = customer?.UserId;
                    bindCustomerServiceInfo.CreateDate = date;
                    bindCustomerServiceInfo.CreateBy = employeeId;
                    await dalBindCustomerService.UpdateAsync(bindCustomerServiceInfo, true);
                }
                else
                {
                    BindCustomerService bindCustomerService = new BindCustomerService();
                    bindCustomerService.CustomerServiceId = updateDto.CustomerServiceId;
                    bindCustomerService.BuyerPhone = phone;
                    bindCustomerService.UserId = customer?.UserId;
                    bindCustomerService.CreateBy = employeeId;
                    bindCustomerService.CreateDate = date;
                    await dalBindCustomerService.AddAsync(bindCustomerService, true);
                }

            }

        }

        public async Task UpdateConsumePriceAndLiveAnchorAsync(string phone, decimal Price, int Channel, int AllOrderCount, string LiveAnchorName)
        {
            var bindCustomerService = await dalBindCustomerService.GetAll().FirstOrDefaultAsync(e => e.BuyerPhone == phone);
            if (bindCustomerService != null)
            {
                if (bindCustomerService.AllPrice == null || bindCustomerService.AllPrice.Value == 0)
                {
                    bindCustomerService.AllPrice = Price;
                }
                else
                {
                    bindCustomerService.AllPrice += Price;
                }
                if (bindCustomerService.AllOrderCount.HasValue)
                {
                    bindCustomerService.AllOrderCount += AllOrderCount;
                }
                else
                {
                    bindCustomerService.AllOrderCount = AllOrderCount;
                }
                bindCustomerService.NewConsumptionContentPlatform = Channel;
                bindCustomerService.NewConsumptionDate = DateTime.Now;
                bindCustomerService.NewLiveAnchor = LiveAnchorName;
                await dalBindCustomerService.UpdateAsync(bindCustomerService, true);
            }
        }
    }
}
