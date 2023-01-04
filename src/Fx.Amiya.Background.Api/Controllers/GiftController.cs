using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.Gift;
using Fx.Amiya.Background.Api.Vo.GIftCategory;
using Fx.Amiya.Dto.Gift;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Infrastructure;
using Fx.Open.Infrastructure.Web;
using Jd.Api.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.Background.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class GiftController : ControllerBase
    {
        private IGiftService giftService;
        private IExpressManageService _expressManageService;
        private IHttpContextAccessor httpContextAccessor;
        private ICustomerBaseInfoService customerBaseInfoService;
        public GiftController(IGiftService giftService, IHttpContextAccessor httpContextAccessor, IExpressManageService expressManageService, ICustomerBaseInfoService customerBaseInfoService)
        {
            this.giftService = giftService;
            this.httpContextAccessor = httpContextAccessor;
            _expressManageService = expressManageService;
            this.customerBaseInfoService = customerBaseInfoService;
        }
        /// <summary>
        /// 获取礼品列表（分页）
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="categoryId">类别id</param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<GiftInfoVo>>> GetListWithPageAsync(string name, int pageNum, int pageSize, string categoryId)
        {
            var q = await giftService.GetListWithPageAsync(name, pageNum, pageSize, categoryId);
            var giftInfo = from d in q.List
                           select new GiftInfoVo
                           {
                               Id = d.Id,
                               Name = d.Name,
                               ThumbPicUrl = d.ThumbPicUrl,
                               Quantity = d.Quantity,
                               Valid = d.Valid,
                               CreateBy = d.CreateBy,
                               CreateName = d.CreateName,
                               CreateDate = d.CreateDate,
                               UpdateBy = d.UpdateBy,
                               UpdateName = d.UpdateName,
                               UpdateDate = d.UpdateDate,
                               CategoryId = d.CategoryId,
                               CategoryName = d.CategoryName
                           };

            FxPageInfo<GiftInfoVo> giftPageInfo = new FxPageInfo<GiftInfoVo>();
            giftPageInfo.TotalCount = q.TotalCount;
            giftPageInfo.List = giftInfo;
            return ResultData<FxPageInfo<GiftInfoVo>>.Success().AddData("giftInfo", giftPageInfo);
        }



        /// <summary>
        /// 添加礼品
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddGiftInfoVo addVo)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);

            AddGiftInfoDto addDto = new AddGiftInfoDto();
            addDto.Name = addVo.Name;
            addDto.ThumbPicUrl = addVo.ThumbPicUrl;
            addDto.Quantity = addVo.Quantity;
            addDto.CategoryId = addVo.CategoryId;
            await giftService.AddAsync(addDto, employeeId);
            return ResultData.Success();
        }



        /// <summary>
        /// 根据礼品编号获取礼品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<GiftInfoVo>> GetByIdAsync(int id)
        {
            var gift = await giftService.GetByIdAsync(id);
            GiftInfoVo giftInfoVo = new GiftInfoVo();
            giftInfoVo.Id = gift.Id;
            giftInfoVo.Name = gift.Name;
            giftInfoVo.ThumbPicUrl = gift.ThumbPicUrl;
            giftInfoVo.Quantity = gift.Quantity;
            giftInfoVo.Valid = gift.Valid;
            giftInfoVo.CreateBy = gift.CreateBy;
            giftInfoVo.CreateName = gift.CreateName;
            giftInfoVo.CreateDate = gift.CreateDate;
            giftInfoVo.UpdateBy = gift.UpdateBy;
            giftInfoVo.UpdateName = gift.UpdateName;
            giftInfoVo.UpdateDate = gift.UpdateDate;
            giftInfoVo.CategoryId = gift.CategoryId;
            giftInfoVo.CategoryName = gift.CategoryName;
            return ResultData<GiftInfoVo>.Success().AddData("giftInfo", giftInfoVo);
        }



        /// <summary>
        /// 修改礼品信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateGiftInfoVo updateVo)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            UpdateGiftInfoDto updateDto = new UpdateGiftInfoDto();
            updateDto.Id = updateVo.Id;
            updateDto.Name = updateVo.Name;
            updateDto.ThumbPicUrl = updateVo.ThumbPicUrl;
            updateDto.Quantity = updateVo.Quantity;
            updateDto.Valid = updateVo.Valid;
            updateDto.CategoryId = updateVo.CategoryId;
            await giftService.UpdateAsync(updateDto, employeeId);
            return ResultData.Success();
        }



        /// <summary>
        /// 删除礼品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeletaAsync(int id)
        {
            await giftService.DeletaAsync(id);
            return ResultData.Success();
        }



        /// <summary>
        /// 获取领取礼品列表（分页）
        /// </summary>
        /// <param name="startDate">开始时间（必填）</param>
        /// <param name="endDate">结束时间（必填）</param>
        /// <param name="isSendGoods">是否已发货,null:全部</param>
        /// <param name="keyword">礼品名称、电话号</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("receiveGiftList")]
        public async Task<ResultData<FxPageInfo<ReceiveGiftVo>>> GetReceiveGiftListAsync(DateTime? startDate, DateTime? endDate, bool? isSendGoods, string keyword,string categoryId, int pageNum, int pageSize)
        {
            if (!startDate.HasValue)
            {
                throw new Exception("请选择开始时间进行查询!");
            }
            if (!endDate.HasValue)
            {
                throw new Exception("请选择结束时间进行查询!");
            }
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            var q = await giftService.GetReceiveGiftListAsync(startDate, endDate, employeeId, isSendGoods, keyword, pageNum, pageSize,categoryId);
            var receiveGift = from d in q.List
                              select new ReceiveGiftVo
                              {
                                  Id = d.Id,
                                  GiftId = d.GiftId,
                                  GiftName = d.GiftName,
                                  ThumbPicUrl = d.ThumbPicUrl,
                                  CustomerId = d.CustomerId,
                                  Phone = d.Phone,
                                  Address = d.Address,
                                  ReceiveName = d.ReceiveName,
                                  ReceivePhone = d.ReceivePhone,
                                  Date = d.Date,
                                  CourierNumber = d.CourierNumber,
                                  ExpressId = d.ExpressId,
                                  ExpressName = (!string.IsNullOrEmpty(d.ExpressId)) ? _expressManageService.GetByIdAsync(d.ExpressId).Result.ExpressName : "",
                                  Quantity = d.Quantity,
                                  IsSendGoods = d.IsSendGoods,
                                  SendGoodsBy = d.SendGoodsBy,
                                  SendGoodsName = d.SendGoodsName,
                                  SendGoodsDate = d.SendGoodsDate,
                                  OrderId = d.OrderId,
                                  GoodsThumbPicUrl = d.GoodsThumbPicUrl,
                                  GoodsName = d.GoodsName,
                                  ActualPayment = d.ActualPayment,
                                  TbBuyerNick = d.TbBuyerNick,
                                  CategoryName = d.CategoryName
                              };


            FxPageInfo<ReceiveGiftVo> receiveGiftPageInfo = new FxPageInfo<ReceiveGiftVo>();
            receiveGiftPageInfo.TotalCount = q.TotalCount;
            receiveGiftPageInfo.List = receiveGift;

            return ResultData<FxPageInfo<ReceiveGiftVo>>.Success().AddData("receiveGiftInfo", receiveGiftPageInfo);
        }

        /// <summary>
        /// 导出领取礼品列表
        /// </summary>
        /// <param name="startDate">开始时间（必填）</param>
        /// <param name="endDate">结束时间（必填）</param>
        /// <param name="isSendGoods">是否已发货,null:全部</param>
        /// <param name="keyword">礼品名称、电话号</param>
        /// <returns></returns>
        [HttpGet("exportReceiveGiftList")]
        public async Task<FileStreamResult> ExportReceiveGiftListAsync(DateTime? startDate, DateTime? endDate, bool? isSendGoods, string keyword,string categoryId)
        {
            if (!startDate.HasValue)
            {
                throw new Exception("请选择开始时间进行查询!");
            }
            if (!endDate.HasValue)
            {
                throw new Exception("请选择结束时间进行查询!");
            }
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            var q = await giftService.ExportReceiveGiftListAsync(startDate, endDate, isSendGoods, employeeId, keyword,categoryId);
            var receiveGift = from d in q
                              select new ExportReveiveGiftVo
                              {
                                  GiftName = d.GiftName,
                                  Phone = d.Phone,
                                  Address = d.Address,
                                  ReceiveName = d.ReceiveName,
                                  ReceivePhone = d.ReceivePhone,
                                  Date = d.Date,
                                  CourierNumber = d.CourierNumber,
                                  ExpressName = (!string.IsNullOrEmpty(d.ExpressId)) ? _expressManageService.GetByIdAsync(d.ExpressId).Result.ExpressName : "",
                                  SendGoodsName = d.SendGoodsName,
                                  SendGoodsDate = d.SendGoodsDate,
                                  OrderId = d.OrderId,
                                  ActualPayment = d.ActualPayment,
                                  CategoryName = d.CategoryName
                              };

            var exportOrder = receiveGift.ToList();
            var stream = ExportExcelHelper.ExportExcel(exportOrder);
            var result = File(stream, "application/vnd.ms-excel", $"" + startDate.Value.ToString("yyyy年MM月dd日") + "-" + endDate.Value.ToString("yyyy年MM月dd日") + "已领取礼品列表.xls");
            return result;
        }




        /// <summary>
        /// 根据手机号加密文本获取领取礼品列表
        /// </summary>
        /// <param name="encryptPhone"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("receiveGiftListByEncryptPhone")]
        public async Task<ResultData<FxPageInfo<ReceiveGiftSimpleVo>>> GetReceiveGiftListByEncryptPhoneAsync(string encryptPhone, int pageNum, int pageSize)
        {
            var q = await giftService.GetReceiveGiftListByEncryptPhoneAsync(encryptPhone, pageNum, pageSize);
            var receiveGift = from d in q.List
                              select new ReceiveGiftSimpleVo
                              {
                                  Id = d.Id,
                                  GiftId = d.GiftId,
                                  GiftName = d.GiftName,
                                  ThumbPicUrl = d.ThumbPicUrl,
                                  ReceivePhone = d.ReceivePhone,
                                  Date = d.Date,
                                  IsSendGoods = d.IsSendGoods,
                                  CourierNumber = d.CourierNumber,
                                  SendGoodsDate = d.SendGoodsDate,
                                  OrderId = d.OrderId,
                                  CategoryName = d.CategoryName
                              };
            FxPageInfo<ReceiveGiftSimpleVo> receiveGiftPageInfo = new FxPageInfo<ReceiveGiftSimpleVo>();
            receiveGiftPageInfo.TotalCount = q.TotalCount;
            receiveGiftPageInfo.List = receiveGift;
            return ResultData<FxPageInfo<ReceiveGiftSimpleVo>>.Success().AddData("receiveGift", receiveGiftPageInfo);
        }




        /// <summary>
        /// 礼品发货
        /// </summary>
        /// <returns></returns>
        [HttpPost("sendGoods")]
        public async Task<ResultData> SendGoodsAsync(SendGoodsVo sendGoodsVo)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            SendGoodsDto sendGoodsDto = new SendGoodsDto();
            sendGoodsDto.Id = sendGoodsVo.Id;
            sendGoodsDto.CourierNumber = sendGoodsVo.CourierNumber;
            sendGoodsDto.ExpressId = sendGoodsVo.ExpressId;
            await giftService.SendGoodsAsync(sendGoodsDto, employeeId);
            return ResultData.Success();
        }


        /// <summary>
        /// 修改收货地址
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("address")]
        public async Task<ResultData> UpdateAddressAsync(UpdateAddressVo updateVo)
        {
            UpdateAddressDto updateDto = new UpdateAddressDto();
            updateDto.Id = updateVo.Id;
            updateDto.Address = updateVo.Address;
            await giftService.UpdateAddressAsync(updateDto);
            return ResultData.Success();
        }
        /// <summary>
        /// 根据礼品类别获取礼品名称列表
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpGet("giftNameList")]
        public async Task<ResultData<List<BaseIdAndNameVo>>> GetGiftNameListByCategory(string categoryId)
        {
            var list = await giftService.GetGiftNameListByCategoryId(categoryId);
            var giftList = list.Select(e => new BaseIdAndNameVo
            {
                Id = e.Id,
                Name = e.Name
            }).ToList();
            return ResultData<List<BaseIdAndNameVo>>.Success().AddData("giftNameList", giftList);
        }
        /// <summary>
        /// 手动发放礼品
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpPost("SendGift")]
        public async Task<ResultData> SendGiftAsync(SendGiftVo sendGift)
        {            
            SendReceiveGiftDto addDto = new SendReceiveGiftDto();
            if (sendGift.AddressId == null)
            {
                addDto.CustomerId = sendGift.CustomerId;
                addDto.GiftId = sendGift.GiftId;
                addDto.Address = sendGift.Address;
                addDto.ReceiveName = sendGift.ReceiveName;
                addDto.ReceivePhone = sendGift.ReceivePhone;
                addDto.OrderId = sendGift.OrderId;
            }
            else {
                addDto.AddressId = sendGift.AddressId;
                addDto.CustomerId = sendGift.CustomerId;
                addDto.GiftId = sendGift.GiftId;
                addDto.Address = sendGift.Address;
                addDto.ReceiveName = sendGift.ReceiveName;
                addDto.ReceivePhone = sendGift.ReceivePhone;
                addDto.OrderId = sendGift.OrderId;
            }
            await giftService.SendReceiveGiftAsync(addDto, sendGift.CustomerId);
            return ResultData.Success();
        }
        /// <summary>
        /// 根据加密手机号获取发放礼品的初始数据
        /// </summary>
        /// <param name="encryptPhone">加密手机号</param>
        /// <returns></returns>
        [HttpPost("SendGiftBaseInfo")]
        public async Task<ResultData<SendGiftBaseInfoVo>> SendGiftBaseInfoAsync(string encryptPhone)
        {
            var customerBaseInfo = await customerBaseInfoService.GetByEncryptPhoneAsync(encryptPhone);
            SendGiftBaseInfoVo addDto = new SendGiftBaseInfoVo();
            addDto.ReceivePhone = customerBaseInfo.OtherPhone;
            addDto.ReceiveName = customerBaseInfo.RealName;
            addDto.Address = customerBaseInfo.DetailAddress;
            return ResultData<SendGiftBaseInfoVo>.Success().AddData("baseInfo", addDto);
        }
    }
}