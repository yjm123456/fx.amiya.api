using Fx.Amiya.Dto.Gift;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Fx.Amiya.DbModels.Model;
using Fx.Infrastructure.DataAccess;
using Fx.Infrastructure.Utils;
using Fx.Amiya.Dto.WxAppConfig;
using Newtonsoft.Json;
using Fx.Common;
using Fx.Sms.Core;
using jos_sdk_net.Util;
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.MiniProgramSendMessage;

namespace Fx.Amiya.Service
{
    public class GiftService : IGiftService
    {
        private IDalGiftInfo dalGiftInfo;
        private IDalReceiveGift dalReceiveGift;
        private IDalOrderInfo dalOrderInfo;
        private IDalAddress dalAddress;
        private IDalCustomerInfo dalCustomerInfo;
        private IUnitOfWork unitOfWork;
        private IDalConfig dalConfig;
        private IDalBindCustomerService dalBindCustomerService;
        private IDalAmiyaEmployee dalAmiyaEmployee;
        private IFxSmsBasedTemplateSender _smsSender;
        private IDalGiftCategory dalGiftCategory;
        private IMiniProgramTemplateMessageSendService miniProgramTemplateMessageSendService;
        private IBindCustomerServiceService bindCustomerServiceService;
       
        public GiftService(IDalGiftInfo dalGiftInfo,
            IDalReceiveGift dalReceiveGift,
            IDalOrderInfo dalOrderInfo,
            IDalCustomerInfo dalCustomerInfo,
            IDalAddress dalAddress,
            IUnitOfWork unitOfWork,
            IDalBindCustomerService dalBindCustomerService,
            IDalConfig dalConfig,
            IDalAmiyaEmployee dalAmiyaEmployee,
            IFxSmsBasedTemplateSender smsSender, IDalGiftCategory dalGiftCategory, IMiniProgramTemplateMessageSendService miniProgramTemplateMessageSendService, IBindCustomerServiceService bindCustomerServiceService)
        {
            this.dalGiftInfo = dalGiftInfo;
            this.dalReceiveGift = dalReceiveGift;
            this.dalOrderInfo = dalOrderInfo;
            this.dalBindCustomerService = dalBindCustomerService;
            this.dalCustomerInfo = dalCustomerInfo;
            this.unitOfWork = unitOfWork;
            this.dalConfig = dalConfig;
            this.dalAddress = dalAddress;
            this.dalAmiyaEmployee = dalAmiyaEmployee;
            _smsSender = smsSender;
            this.dalGiftCategory = dalGiftCategory;
            this.miniProgramTemplateMessageSendService = miniProgramTemplateMessageSendService;
            this.bindCustomerServiceService = bindCustomerServiceService;
        }




        /// <summary>
        /// 获取礼品列表
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<GiftInfoDto>> GetListWithPageAsync(string name, int pageNum, int pageSize, string categoryId)
        {
            var giftInfo = from d in dalGiftInfo.GetAll()
                           where (name == null || d.Name.Contains(name)) && (string.IsNullOrEmpty(categoryId) || d.CategoryId == categoryId)
                           select new GiftInfoDto
                           {
                               Id = d.Id,
                               Name = d.Name,
                               ThumbPicUrl = d.ThumbPicUrl,
                               Quantity = d.Quantity,
                               Valid = d.Valid,
                               CreateBy = d.CreateBy,
                               CreateName = d.CreateByAmiyaEmplooyee.Name,
                               CreateDate = d.CreateDate,
                               UpdateBy = d.UpdateBy,
                               UpdateName = d.UpdateByAmiyaEmplooyee.Name,
                               UpdateDate = d.UpdateDate,
                               CategoryId = d.CategoryId,
                               CategoryName = (dalGiftCategory.GetAll().Where(e => e.Id == d.CategoryId).SingleOrDefault()).Name
                           };
            FxPageInfo<GiftInfoDto> giftPageInfo = new FxPageInfo<GiftInfoDto>();
            giftPageInfo.TotalCount = await giftInfo.CountAsync();
            giftPageInfo.List = await giftInfo.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return giftPageInfo;
        }




        public async Task AddAsync(AddGiftInfoDto addDto, int employeeId)
        {
            GiftInfo giftInfo = new GiftInfo();
            giftInfo.Name = addDto.Name;
            giftInfo.ThumbPicUrl = addDto.ThumbPicUrl;
            giftInfo.Quantity = addDto.Quantity;
            giftInfo.CreateBy = employeeId;
            giftInfo.CreateDate = DateTime.Now;
            giftInfo.Valid = true;
            giftInfo.Version = 0;
            giftInfo.CategoryId = addDto.CategoryId;
            await dalGiftInfo.AddAsync(giftInfo, true);
        }





        public async Task<GiftInfoDto> GetByIdAsync(int id)
        {
            var giftInfo = await dalGiftInfo.GetAll()
                .Include(e => e.CreateByAmiyaEmplooyee)
                .Include(e => e.UpdateByAmiyaEmplooyee)
                .SingleOrDefaultAsync(e => e.Id == id);

            if (giftInfo == null)
                throw new Exception("礼品编号错误");
            GiftInfoDto giftInfoDto = new GiftInfoDto();
            giftInfoDto.Id = giftInfo.Id;
            giftInfoDto.Name = giftInfo.Name;
            giftInfoDto.ThumbPicUrl = giftInfo.ThumbPicUrl;
            giftInfoDto.Quantity = giftInfo.Quantity;
            giftInfoDto.Valid = giftInfo.Valid;
            giftInfoDto.CreateBy = giftInfo.CreateBy;
            giftInfoDto.CreateName = giftInfo.CreateByAmiyaEmplooyee.Name;
            giftInfoDto.CreateDate = giftInfo.CreateDate;
            giftInfoDto.UpdateBy = giftInfo.UpdateBy;
            giftInfoDto.UpdateName = giftInfo.UpdateByAmiyaEmplooyee?.Name;
            giftInfoDto.UpdateDate = giftInfo.UpdateDate;
            giftInfoDto.CategoryId = giftInfo.CategoryId;
            giftInfoDto.CategoryName = string.IsNullOrEmpty(giftInfo.CategoryId) ? "" : (dalGiftCategory.GetAll().Where(e => e.Id == giftInfo.CategoryId).SingleOrDefault()).Name;
            return giftInfoDto;
        }




        public async Task UpdateAsync(UpdateGiftInfoDto updateDto, int employeeId)
        {
            var giftInfo = await dalGiftInfo.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
            if (giftInfo == null)
                throw new Exception("礼品编号错误");
            giftInfo.Name = updateDto.Name;
            giftInfo.ThumbPicUrl = updateDto.ThumbPicUrl;
            giftInfo.Quantity = updateDto.Quantity;
            giftInfo.Valid = updateDto.Valid;
            giftInfo.UpdateBy = employeeId;
            giftInfo.UpdateDate = DateTime.Now;
            giftInfo.CategoryId = updateDto.CategoryId;
            await dalGiftInfo.UpdateAsync(giftInfo, true);
        }


        public async Task DeletaAsync(int id)
        {
            var giftInfo = await dalGiftInfo.GetAll()
                .Include(e => e.ReceiveGiftList)
                .SingleOrDefaultAsync(e => e.Id == id);

            if (giftInfo.ReceiveGiftList.Count > 0)
                throw new Exception("删除失败，该礼品已有人领取");
            await dalGiftInfo.DeleteAsync(giftInfo, true);
        }





        /// <summary>
        /// 小程序获取礼品列表
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<GiftInfoSimpleDto>> GetSimpleListOfWxAsync(string name, int pageNum, int pageSize, string categoryId)
        {
            var gift = from d in dalGiftInfo.GetAll()
                       where (string.IsNullOrWhiteSpace(name) || d.Name.Contains(name)) && (string.IsNullOrEmpty(categoryId) || d.CategoryId == categoryId)
                       && d.Valid
                       && d.Quantity > 0
                       select new GiftInfoSimpleDto
                       {
                           Id = d.Id,
                           Name = d.Name,
                           ThumbPicUrl = d.ThumbPicUrl,
                           CategoryId = d.CategoryId
                       };

            FxPageInfo<GiftInfoSimpleDto> giftPageInfo = new FxPageInfo<GiftInfoSimpleDto>();
            giftPageInfo.TotalCount = await gift.CountAsync();
            giftPageInfo.List = await gift.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return giftPageInfo;
        }






        /// <summary>
        /// 获取可领取礼品数量
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<int> GetCanReceiveQuantityOfWxAsync(string customerId)
        {
            var customer = await dalCustomerInfo.GetAll().SingleOrDefaultAsync(e => e.Id == customerId);
            int OrderFinishQuantity = await dalOrderInfo.GetAll().CountAsync(e => e.Phone == customer.Phone && e.StatusCode == OrderStatusCode.TRADE_FINISHED && e.ActualPayment > 1);
            int receiveGiftQuantity = await dalReceiveGift.GetAll().CountAsync(e => e.CustomerId == customerId);
            int quantity = OrderFinishQuantity - receiveGiftQuantity;
            return quantity < 0 ? 0 : quantity;
        }





        /// <summary>
        /// 领取礼品
        /// </summary>
        /// <param name="addDto"></param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task AddReceiveGiftAsync(AddReceiveGiftDto addDto, string customerId)
        {
            try
            {
                //订单号集合
                string phone = "";
                var address = await dalAddress.GetAll().SingleOrDefaultAsync(e => e.Id == addDto.AddressId);
                phone = address.Phone;
                string goodsName = "";
                unitOfWork.BeginTransaction();

                var gift = await dalGiftInfo.GetAll().SingleOrDefaultAsync(e => e.Id == addDto.GiftId);
                if (gift == null)
                    throw new Exception("礼品编号错误");
                if (gift.Quantity <= 0)
                    throw new Exception(gift.Name + " 已被领取完了");

                gift.Quantity = gift.Quantity - 1;
                gift.Version = gift.Version + 1;
                await dalGiftInfo.UpdateAsync(gift, true);

                ReceiveGift receiveGift = new ReceiveGift();
                receiveGift.OrderId = addDto.OrderId;
                receiveGift.GiftId = addDto.GiftId;
                receiveGift.CustomerId = customerId;
                receiveGift.Date = DateTime.Now;
                receiveGift.IsSendGoods = false;
                receiveGift.Quantity = 1;
                receiveGift.AddressId = addDto.AddressId;
                receiveGift.ReceivePhone = address.Phone;
                await dalReceiveGift.AddAsync(receiveGift, true);
                var x = await GetByIdAsync(receiveGift.GiftId);
                goodsName = x.Name.ToString();
                //发送短信通知(todo;)
                if (!string.IsNullOrEmpty(goodsName))
                {
                    string templateName = "order_gift_commit";
                    await _smsSender.SendSingleAsync(phone, templateName, JsonConvert.SerializeObject(new { goodsName = goodsName.ToString() }));
                }

                //组织邮件信息
                var giftInfo = dalGiftInfo.GetAll().FirstOrDefault(x => x.Id == addDto.GiftId);
                SendMails sendMails = new SendMails();
                var sub = "有新的顾客在“核销好礼”中领取了礼品“" + giftInfo.Name + "”，请及时跟进哦！";

                //向管理员发送邮箱通知
                var bindCustmerInfo = await dalBindCustomerService.GetAll().SingleOrDefaultAsync(e => e.BuyerPhone == phone);
                if (bindCustmerInfo != null)
                {
                    var empId = bindCustmerInfo.CustomerServiceId;
                    var empInfo = await dalAmiyaEmployee.GetAll().SingleOrDefaultAsync(e => e.Id == empId);
                    if (empInfo != null)
                    {
                        var email = empInfo.Email;
                        if (email != "0")
                            sendMails.sendMail("smtp.qq.com", "3023330386@qq.com", "kivbmbikthsmdejf", "啊美雅", "3023330386@qq.com", email, "客户下单提示", sub);
                    }
                }
                else
                {
                    var employee = await dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).Where(e => e.AmiyaPositionInfo.Name == "客服主管" && e.Valid == true).ToListAsync();
                    foreach (var k in employee)
                    {
                        var email = k.Email;
                        if (email == "0")
                            continue;
                        sendMails.sendMail("smtp.qq.com", "3023330386@qq.com", "kivbmbikthsmdejf", "啊美雅", "3023330386@qq.com", email, "客户下单提示", sub);
                    }
                }
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message.ToString());
            }
        }





        /// <summary>
        /// 获取领取礼品列表
        /// </summary>
        /// <param name="isSendGoods"></param>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="categoryId">分类id</param>
        /// <returns></returns>
        public async Task<FxPageInfo<ReceiveGiftDto>> GetReceiveGiftListAsync(DateTime? startDaste, DateTime? endDate, int employeeId, bool? isSendGoods, string keyword, int pageNum, int pageSize, string categoryId)
        {
            bool hidePhone = true;
            //var config = await GetCallCenterConfig();
            //if (config.HidePhoneNumber)
            //{
            //    var employee = await dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).SingleOrDefaultAsync(e => e.Id == employeeId);
            //    if (employee.IsCustomerService && employee.AmiyaPositionInfo.IsDirector == false)
            //    {
            //        hidePhone = true;
            //    }
            //}


            var receiveGift = from d in dalReceiveGift.GetAll()
                              where (isSendGoods == null || d.IsSendGoods == isSendGoods)
                              && (string.IsNullOrWhiteSpace(keyword) || d.GiftInfo.Name.Contains(keyword) || d.ReceivePhone == keyword)
                              && (!startDaste.HasValue || d.Date >= startDaste.Value)
                              && (!endDate.HasValue || d.Date <= endDate.Value.AddDays(1))
                              && (string.IsNullOrEmpty(categoryId) || d.GiftInfo.CategoryId == categoryId)
                              select new ReceiveGiftDto
                              {
                                  Id = d.Id,
                                  GiftId = d.GiftId,
                                  GiftName = d.GiftInfo.Name,
                                  ThumbPicUrl = d.GiftInfo.ThumbPicUrl,
                                  CustomerId = d.CustomerId,
                                  Phone = hidePhone == true ? ServiceClass.GetIncompletePhone(d.CustomerInfo == null ? d.ReceivePhone : d.CustomerInfo.Phone) : d.CustomerInfo == null ? d.ReceivePhone : d.CustomerInfo.Phone,
                                  Date = d.Date,
                                  CourierNumber = d.CourierNumber,
                                  ExpressId = d.ExpressId,
                                  Quantity = d.Quantity,
                                  IsSendGoods = d.IsSendGoods,
                                  SendGoodsBy = d.SendGoodsBy,
                                  SendGoodsName = d.AmiyaEmployee.Name,
                                  SendGoodsDate = d.SendGoodsDate,
                                  OrderId = d.OrderId,
                                  GoodsName = d.ReceiveName,
                                  GoodsThumbPicUrl = d.OrderInfo.ThumbPicUrl,
                                  ActualPayment = d.OrderInfo.ActualPayment,
                                  TbBuyerNick = d.OrderInfo.BuyerNick,
                                  Address = d.AddressInfo == null ? d.Address : d.AddressInfo.Province + d.AddressInfo.City + d.AddressInfo.District + d.AddressInfo.Other,
                                  ReceiveName = d.AddressInfo == null ? d.ReceiveName : d.AddressInfo.Contact,
                                  ReceivePhone = d.AddressInfo == null ? (hidePhone == true ? ServiceClass.GetIncompletePhone(d.CustomerInfo == null ? d.ReceivePhone : d.CustomerInfo.Phone) : d.ReceivePhone)
                                  : (hidePhone == true ? ServiceClass.GetIncompletePhone(d.AddressInfo.Phone) : d.AddressInfo.Phone),
                                  CategoryName = !string.IsNullOrEmpty(d.GiftInfo.CategoryId) ? (dalGiftCategory.GetAll().Where(e => e.Id == d.GiftInfo.CategoryId).SingleOrDefault()).Name : "",
                                  CreateBy = dalAmiyaEmployee.GetAll().Where(e => e.Id == d.CreateBy).FirstOrDefault() == null ? "" : dalAmiyaEmployee.GetAll().Where(e => e.Id == d.CreateBy).FirstOrDefault().Name,
                                  SendType = ServiceClass.GiftSendTypeText(d.SendType)
                                  //  Address = d.Address,
                                  //ReceiveName = d.ReceiveName,
                                  //ReceivePhone = hidePhone == true ? GetPortionPhone(d.ReceivePhone) : d.ReceivePhone,
        };
            FxPageInfo<ReceiveGiftDto> receiveGiftPageInfo = new FxPageInfo<ReceiveGiftDto>();
            receiveGiftPageInfo.TotalCount = await receiveGift.CountAsync();
            receiveGiftPageInfo.List = await receiveGift.OrderByDescending(e => e.Date).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();

            return receiveGiftPageInfo;
        }

        /// <summary>
        /// 导出领取礼品列表
        /// </summary>
        /// <param name="isSendGoods"></param>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="categoryId">分类id</param>
        /// <returns></returns>
        public async Task<List<ReceiveGiftDto>> ExportReceiveGiftListAsync(DateTime? startDaste, DateTime? endDate, bool? isSendGoods, int employeeId, string keyword, string categoryId)
        {
            bool hidePhone = false;
            var config = await GetCallCenterConfig();
            if (config.HidePhoneNumber)
            {
                var employee = await dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).SingleOrDefaultAsync(e => e.Id == employeeId);
                if (employee.IsCustomerService && employee.AmiyaPositionInfo.IsDirector == false)
                {
                    hidePhone = true;
                }
            }


            var receiveGift = from d in dalReceiveGift.GetAll()
                              where (isSendGoods == null || d.IsSendGoods == isSendGoods)
                              && (string.IsNullOrWhiteSpace(keyword) || d.GiftInfo.Name.Contains(keyword) || d.ReceivePhone == keyword)
                              && (!startDaste.HasValue || d.Date >= startDaste.Value)
                              && (!endDate.HasValue || d.Date <= endDate.Value.AddDays(1))
                              && (string.IsNullOrEmpty(categoryId) || d.GiftInfo.CategoryId == categoryId)
                              select new ReceiveGiftDto
                              {
                                  Id = d.Id,
                                  GiftId = d.GiftId,
                                  GiftName = d.GiftInfo.Name,
                                  ThumbPicUrl = d.GiftInfo.ThumbPicUrl,
                                  CustomerId = d.CustomerId,
                                  Phone = hidePhone == true ? ServiceClass.GetIncompletePhone(d.CustomerInfo == null ? d.ReceivePhone : d.CustomerInfo.Phone) : d.CustomerInfo == null ? d.ReceivePhone : d.CustomerInfo.Phone,
                                  Date = d.Date,
                                  CourierNumber = d.CourierNumber,
                                  ExpressId = d.ExpressId,
                                  Quantity = d.Quantity,
                                  IsSendGoods = d.IsSendGoods,
                                  SendGoodsBy = d.SendGoodsBy,
                                  SendGoodsName = d.AmiyaEmployee.Name,
                                  SendGoodsDate = d.SendGoodsDate,
                                  OrderId = d.OrderId,
                                  GoodsName = d.ReceiveName,
                                  GoodsThumbPicUrl = d.OrderInfo.ThumbPicUrl,
                                  ActualPayment = d.OrderInfo.ActualPayment,
                                  TbBuyerNick = d.OrderInfo.BuyerNick,
                                  Address = d.AddressInfo == null ? d.Address : d.AddressInfo.Province + d.AddressInfo.City + d.AddressInfo.District + d.AddressInfo.Other,
                                  ReceiveName = d.AddressInfo == null ? d.ReceiveName : d.AddressInfo.Contact,
                                  ReceivePhone = d.AddressInfo == null ? (hidePhone == true ? ServiceClass.GetIncompletePhone(d.CustomerInfo == null ? d.ReceivePhone : d.CustomerInfo.Phone) : d.CustomerInfo == null ? d.ReceivePhone : d.CustomerInfo.Phone)
                                  : (hidePhone == true ? ServiceClass.GetIncompletePhone(d.AddressInfo.Phone) : d.AddressInfo.Phone),
                                  CategoryName = !string.IsNullOrEmpty(d.GiftInfo.CategoryId) ? (dalGiftCategory.GetAll().Where(e => e.Id == d.GiftInfo.CategoryId).SingleOrDefault()).Name : "",
                                  CreateBy = dalAmiyaEmployee.GetAll().Where(e => e.Id == d.CreateBy).FirstOrDefault() == null ? "" : dalAmiyaEmployee.GetAll().Where(e => e.Id == d.CreateBy).FirstOrDefault().Name,
                                  SendType = ServiceClass.GiftSendTypeText(d.SendType)
                                  //  Address = d.Address,
                                  //ReceiveName = d.ReceiveName,
                                  //ReceivePhone = hidePhone == true ? GetPortionPhone(d.ReceivePhone) : d.ReceivePhone,
                              };
            List<ReceiveGiftDto> receiveGiftPageInfo = new List<ReceiveGiftDto>();
            receiveGiftPageInfo = await receiveGift.OrderByDescending(e => e.Date).ToListAsync();

            return receiveGiftPageInfo;
        }




        /// <summary>
        /// 根据手机号加密文本获取领取礼品列表
        /// </summary>
        /// <param name="encryptPhone"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<ReceiveGiftSimpleDto>> GetReceiveGiftListByEncryptPhoneAsync(string encryptPhone, int pageNum, int pageSize)
        {
            var config = await GetCallCenterConfig();
            string phone = ServiceClass.Decrypto(encryptPhone, config.PhoneEncryptKey);

            var receiveGift = from d in dalReceiveGift.GetAll()
                              where d.ReceivePhone == phone
                              select new ReceiveGiftSimpleDto
                              {
                                  Id = d.Id,
                                  GiftId = d.GiftId,
                                  GiftName = d.GiftInfo.Name,
                                  ThumbPicUrl = d.GiftInfo.ThumbPicUrl,
                                  ReceivePhone = config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(d.CustomerInfo == null ? d.ReceivePhone : d.CustomerInfo.Phone) : d.CustomerInfo == null ? d.ReceivePhone : d.CustomerInfo.Phone,
                                  Date = d.Date,
                                  IsSendGoods = d.IsSendGoods,
                                  CourierNumber = d.CourierNumber,
                                  SendGoodsDate = d.SendGoodsDate,
                                  OrderId = d.OrderId,
                                  CategoryName = !string.IsNullOrEmpty(d.GiftInfo.CategoryId) ? (dalGiftCategory.GetAll().Where(e => e.Id == d.GiftInfo.CategoryId).SingleOrDefault()).Name : ""
                              };
            FxPageInfo<ReceiveGiftSimpleDto> receiveGiftPageInfo = new FxPageInfo<ReceiveGiftSimpleDto>();
            receiveGiftPageInfo.TotalCount = await receiveGift.CountAsync();
            receiveGiftPageInfo.List = await receiveGift.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return receiveGiftPageInfo;

        }




        private async Task<CallCenterConfigDto> GetCallCenterConfig()
        {
            var config = await dalConfig.GetAll().SingleOrDefaultAsync();
            return JsonConvert.DeserializeObject<WxAppConfigDto>(config.ConfigJson).CallCenterConfig;
        }



        /// <summary>
        /// 发货礼品
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task SendGoodsAsync(SendGoodsDto sendGoodsDto, int employeeId)
        {
            var receiveGift = await dalReceiveGift.GetAll().SingleOrDefaultAsync(e => e.Id == sendGoodsDto.Id);
            if (receiveGift == null)
                throw new Exception("编号错误");

            receiveGift.SendGoodsBy = employeeId;
            receiveGift.IsSendGoods = true;
            receiveGift.SendGoodsDate = DateTime.Now;
            receiveGift.CourierNumber = sendGoodsDto.CourierNumber;
            receiveGift.ExpressId = sendGoodsDto.ExpressId;
            await dalReceiveGift.UpdateAsync(receiveGift, true);
        }






        /// <summary>
        /// 修改收货地址
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateAddressAsync(UpdateAddressDto updateDto)
        {
            var receiveGift = await dalReceiveGift.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
            if (receiveGift == null)
                throw new Exception("编号错误");
            if (receiveGift.IsSendGoods)
                throw new Exception("礼品已发货，不可修改收货地址");
            receiveGift.Address = updateDto.Address;
            await dalReceiveGift.UpdateAsync(receiveGift, true);
        }





        /// <summary>
        /// 根据客户编号获取已领取礼品
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<ReceiveGiftWrapperOfWxDto>> GetReceiveGiftListByCustomerIdAsync(string customerId, string phone, int pageNum, int pageSize, string categoryId)
        {
            var receiveGift = from d in dalReceiveGift.GetAll()
                              .Include(e => e.GiftInfo)
                              where (d.CustomerId==customerId||d.ReceivePhone==phone) &&(d.GiftInfo.CategoryId==categoryId)
                              select new ReceiveGiftDto
                              {
                                  Id = d.Id,
                                  GiftId = d.GiftId,
                                  GiftName = d.GiftInfo.Name,
                                  ThumbPicUrl = d.GiftInfo.ThumbPicUrl,
                                  CourierNumber = d.CourierNumber,
                                  IsSendGoods = d.IsSendGoods,
                                  ReceivePhone = d.ReceivePhone,
                                  Date = d.Date,
                                  ExpressId = d.ExpressId
                              };
            


            var list = await receiveGift.OrderByDescending(e => e.Date).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();

            List<ReceiveGiftWrapperOfWxDto> receiveGiftOfWxDtoList = new List<ReceiveGiftWrapperOfWxDto>();

            foreach (var item in receiveGift)
            {
                if (item.IsSendGoods)
                {
                    //当前快递单号是否已存在
                    if (receiveGiftOfWxDtoList.Exists(e => e.CourierNumber == item.CourierNumber))
                    {
                        var r = receiveGiftOfWxDtoList.SingleOrDefault(e => e.CourierNumber == item.CourierNumber);
                        ReceiveGiftSimpleOfWxDto receiveGiftInfoSimpleDto = new ReceiveGiftSimpleOfWxDto();
                        receiveGiftInfoSimpleDto.Id = item.Id;
                        receiveGiftInfoSimpleDto.GiftId = item.GiftId;
                        receiveGiftInfoSimpleDto.GiftName = item.GiftName;
                        receiveGiftInfoSimpleDto.ThumbPicUrl = item.ThumbPicUrl;
                        r.GiftInfos.Add(receiveGiftInfoSimpleDto);
                    }
                    else
                    {
                        ReceiveGiftWrapperOfWxDto receiveGiftOfWxDto = new ReceiveGiftWrapperOfWxDto();
                        receiveGiftOfWxDto.CourierNumber = item.CourierNumber;
                        receiveGiftOfWxDto.ReceiverPhone = item.ReceivePhone;
                        receiveGiftOfWxDto.ExpressId = item.ExpressId;
                        receiveGiftOfWxDto.DeliveryStatus = string.IsNullOrWhiteSpace(item.CourierNumber) ? "待发货" : "已发货";
                        receiveGiftOfWxDto.GiftInfos = new List<ReceiveGiftSimpleOfWxDto>(){
                            new ReceiveGiftSimpleOfWxDto()
                            {
                                Id = item.Id,
                                GiftId = item.GiftId,
                                GiftName = item.GiftName,
                                ThumbPicUrl = item.ThumbPicUrl
                            }
                        };
                        receiveGiftOfWxDtoList.Add(receiveGiftOfWxDto);
                    }
                }
                else
                {
                    receiveGiftOfWxDtoList.Add(new ReceiveGiftWrapperOfWxDto()
                    {
                        CourierNumber = "",
                        ReceiverPhone = "",
                        ExpressId = "",
                        DeliveryStatus = "待发货",
                        GiftInfos = new List<ReceiveGiftSimpleOfWxDto>() {
                            new ReceiveGiftSimpleOfWxDto(){
                                Id=item.Id,
                                GiftId=item.GiftId,
                                GiftName=item.GiftName,
                                ThumbPicUrl=item.ThumbPicUrl
                            }
                        }
                    });
                }
            }


            FxPageInfo<ReceiveGiftWrapperOfWxDto> receivePageInfo = new FxPageInfo<ReceiveGiftWrapperOfWxDto>();
            receivePageInfo.TotalCount = receiveGiftOfWxDtoList.Count();
            receivePageInfo.List = receiveGiftOfWxDtoList;
            return receivePageInfo;
        }
        /// <summary>
        /// 根据礼品类别获取礼品名称列表
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<List<BaseIdAndNameDto>> GetGiftNameListByCategoryId(string categoryId)
        {
            var list = dalGiftInfo.GetAll().Where(e => e.CategoryId == categoryId && e.Valid == true).Select(e => new BaseIdAndNameDto
            {
                Id = e.Id.ToString(),
                Name = e.Name
            }).ToList();
            return list;
        }
        /// <summary>
        /// 手动发放礼品
        /// </summary>
        /// <param name="addDto"></param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task SendReceiveGiftAsync(SendReceiveGiftDto addDto, string customerId)
        {
            try
            {
                //订单号集合

                string goodsName = "";
                unitOfWork.BeginTransaction();
                var gift = await dalGiftInfo.GetAll().SingleOrDefaultAsync(e => e.Id == addDto.GiftId);
                if (gift == null)
                    throw new Exception("礼品编号错误");
                if (gift.Quantity <= 0)
                    throw new Exception(gift.Name + " 已被领取完了");

                gift.Quantity = gift.Quantity - 1;
                gift.Version = gift.Version + 1;
                await dalGiftInfo.UpdateAsync(gift, true);

                ReceiveGift receiveGift = new ReceiveGift();
                receiveGift.GiftId = addDto.GiftId;
                receiveGift.CustomerId = customerId;
                receiveGift.Date = DateTime.Now;
                receiveGift.IsSendGoods = false;
                receiveGift.Quantity = 1;
                receiveGift.Address = addDto.Address;
                receiveGift.SendType = (int)GiftSendType.CustomerServiceSend;
                if (addDto.AddressId.HasValue)
                {
                    string phone = "";
                    var address = await dalAddress.GetAll().SingleOrDefaultAsync(e => e.Id == addDto.AddressId);
                    phone = address.Phone;
                    receiveGift.ReceivePhone = phone;
                    receiveGift.AddressId = addDto.AddressId;
                }
                else
                {
                    receiveGift.ReceivePhone = addDto.ReceivePhone;
                    receiveGift.ReceiveName = addDto.ReceiveName;
                    receiveGift.Address = addDto.Address;
                }
                receiveGift.OrderId = addDto.OrderId;
                if (!string.IsNullOrEmpty(receiveGift.OrderId))
                {
                    var receivedGift = dalReceiveGift.GetAll().Where(e => e.OrderId == receiveGift.OrderId).FirstOrDefault();
                    if (receivedGift != null) throw new Exception("该订单已赠送过礼品");
                }
                await dalReceiveGift.AddAsync(receiveGift, true);
                unitOfWork.Commit();
                SendGiftPresentMessageDto sendGiftPresentMessageDto = new SendGiftPresentMessageDto();
                sendGiftPresentMessageDto.CustomerId = customerId;
                sendGiftPresentMessageDto.OrderId = addDto.OrderId;
                sendGiftPresentMessageDto.GiftName = gift.Name;
                sendGiftPresentMessageDto.Remark = "您的礼品已发放!";
                await miniProgramTemplateMessageSendService.SendGiftPresentMessageAsync(sendGiftPresentMessageDto);
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task CustomerServiceSendGiftAsync(CustomerServiceSendGiftDto sendDto)
        {
            try
            {
                //订单号集合

                string goodsName = "";
                unitOfWork.BeginTransaction();
                var gift = await dalGiftInfo.GetAll().SingleOrDefaultAsync(e => e.Id == sendDto.GiftId);
                if (gift == null)
                    throw new Exception("礼品编号错误");
                if (gift.Quantity <= 0)
                    throw new Exception(gift.Name + " 已被领取完了");

                gift.Quantity = gift.Quantity - 1;
                gift.Version = gift.Version + 1;
                await dalGiftInfo.UpdateAsync(gift, true);

                ReceiveGift receiveGift = new ReceiveGift();
                receiveGift.GiftId = sendDto.GiftId;
                receiveGift.Date = DateTime.Now;
                receiveGift.IsSendGoods = false;
                receiveGift.Quantity = sendDto.Quantity;
                receiveGift.Address = sendDto.Address;
                receiveGift.ReceivePhone = sendDto.ReceivePhone;
                receiveGift.ReceiveName = sendDto.ReceiveName;
                receiveGift.CreateBy = sendDto.CreateBy;
                receiveGift.SendType = (int)GiftSendType.CustomerServiceSend;
                await dalReceiveGift.AddAsync(receiveGift, true);
                //发送礼品数加1
                await bindCustomerServiceService.UpdateCustomerRFMLevelAsync(sendDto.Id);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();

                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
