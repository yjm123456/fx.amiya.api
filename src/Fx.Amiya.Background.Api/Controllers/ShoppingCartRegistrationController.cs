using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.ShoppingCartRegistration;
using Fx.Amiya.Dto.OperationLog;
using Fx.Amiya.Dto.ShoppingCartRegistration;
using Fx.Amiya.IService;
using Fx.Amiya.Service;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using jos_sdk_net.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 小黄车登记板块数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class ShoppingCartRegistrationController : ControllerBase
    {
        private IShoppingCartRegistrationService shoppingCartRegistrationService;
        private IHttpContextAccessor httpContextAccessor;
        private IContentPlateFormOrderService contentPlateFormOrderService;
        private IOperationLogService operationLogService;
        private readonly ILiveAnchorService liveAnchorService;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="shoppingCartRegistrationService"></param>
        public ShoppingCartRegistrationController(IShoppingCartRegistrationService shoppingCartRegistrationService,
            IContentPlateFormOrderService contentPlateFormOrderService,
            IHttpContextAccessor httpContextAccessor,
            IOperationLogService operationLogService,
            ILiveAnchorService liveAnchorService)
        {
            this.shoppingCartRegistrationService = shoppingCartRegistrationService;
            this.httpContextAccessor = httpContextAccessor;
            this.contentPlateFormOrderService = contentPlateFormOrderService;
            this.operationLogService = operationLogService;
            this.liveAnchorService = liveAnchorService;
        }


        /// <summary>
        /// 获取小黄车登记信息列表（分页）
        /// </summary>
        /// <param name="startDate">登记开始时间</param>
        /// <param name="endDate">登记结束时间</param>
        /// <param name="LiveAnchorId">主播id</param>
        /// <param name="keyword">关键词</param>
        /// <param name="contentPlatFormId">内容平台id</param>
        /// <param name="isCreateOrder">录单触达</param>
        /// <param name="isSendOrder">派单触达</param>
        /// <param name="isAddWechat">是否加v</param>
        /// <param name="isWriteOff">是否核销</param>
        /// <param name="isConsultation">是否面诊</param>
        /// <param name="isReturnBackPrice">是否回款</param>
        /// <param name="minPrice">最小金额</param>
        /// <param name="maxPrice">最大金额</param>
        /// <param name="assignEmpId">接诊人员</param>
        /// <param name="createBy">创建人</param>
        /// <param name="startBadReviewTime">差评开始时间</param>
        /// <param name="endBadReviewTime">差评结束时间</param>
        /// <param name="startRefundTime">退款开始时间</param>
        /// <param name="endRefundTime">退款结束时间</param>
        /// <param name="emergencyLevel">紧急程度</param>
        /// <param name="isBadReview">是否差评</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="baseLiveAnchorId">主播基础id</param>
        /// <param name="source">客户来源</param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<ShoppingCartRegistrationVo>>> GetListWithPageAsync(DateTime? startDate, DateTime? endDate, int? LiveAnchorId, bool? isCreateOrder, int? createBy, bool? isSendOrder, bool? isAddWechat, bool? isWriteOff, bool? isConsultation, bool? isReturnBackPrice, string keyword, string contentPlatFormId, int pageNum, int pageSize, decimal? minPrice, decimal? maxPrice, int? assignEmpId, DateTime? startRefundTime, DateTime? endRefundTime, DateTime? startBadReviewTime, DateTime? endBadReviewTime, int? ShoppingCartRegistrationCustomerType, int? emergencyLevel, bool? isBadReview, string baseLiveAnchorId, int? source)
        {
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                var q = await shoppingCartRegistrationService.GetListWithPageAsync(startDate, endDate, LiveAnchorId, isCreateOrder, createBy, isSendOrder, employeeId, isAddWechat, isWriteOff, isConsultation, isReturnBackPrice, keyword, contentPlatFormId, pageNum, pageSize, minPrice, maxPrice, assignEmpId, startRefundTime, endRefundTime, startBadReviewTime, endBadReviewTime, ShoppingCartRegistrationCustomerType, emergencyLevel, isBadReview, baseLiveAnchorId, source);

                var shoppingCartRegistration = from d in q.List
                                               select new ShoppingCartRegistrationVo
                                               {
                                                   Id = d.Id,
                                                   RecordDate = d.RecordDate,
                                                   ContentPlatFormName = d.ContentPlatFormName,
                                                   LiveAnchorName = d.LiveAnchorName,
                                                   LiveAnchorWechatNo = d.LiveAnchorWechatNo,
                                                   CustomerNickName = d.CustomerNickName,
                                                   Phone = d.Phone,
                                                   HiddenPhone = d.HiddenPhone,
                                                   EncryptPhone = d.EncryptPhone,
                                                   SubPhone = d.SubPhone,
                                                   HiddenSubPhone = d.HiddenSubPhone,
                                                   EncryptSubPhone = d.EncryptSubPhone,
                                                   Price = d.Price,
                                                   IsCreateOrder = d.IsCreateOrder,
                                                   IsSendOrder = d.IsSendOrder,
                                                   ConsultationType = d.ConsultationType,
                                                   IsWriteOff = d.IsWriteOff,
                                                   IsConsultation = d.IsConsultation,
                                                   ConsultationTypeText = d.ConsultationTypeText,
                                                   ConsultationDate = d.ConsultationDate,
                                                   IsAddWeChat = d.IsAddWeChat,
                                                   IsReturnBackPrice = d.IsReturnBackPrice,
                                                   Remark = d.Remark,
                                                   CreateBy = d.CreateByName,
                                                   AssignEmpName = d.AssignEmpName,
                                                   CreateDate = d.CreateDate,
                                                   IsReContent = d.IsReContent,
                                                   ReContent = d.ReContent,
                                                   RefundReason = d.RefundReason,
                                                   BadReviewContent = d.BadReviewContent,
                                                   BadReviewReason = d.BadReviewReason,
                                                   BadReviewDate = d.BadReviewDate == null ? null : d.BadReviewDate,
                                                   RefundDate = d.RefundDate,
                                                   IsBadReview = d.IsBadReview,
                                                   EmergencyLevel = d.EmergencyLevel,
                                                   EmergencyLevelText = ServiceClass.GetShopCartRegisterEmergencyLevelText(d.EmergencyLevel),
                                                   Source = d.Source,
                                                   ShoppingCartRegistrationCustomerType = d.ShoppingCartRegistrationCustomerType,
                                                   ShoppingCartRegistrationCustomerTypeText = d.ShoppingCartRegistrationCustomerTypeText,
                                                   SourceText = d.SourceText,
                                                   ProductType = d.ProductType,
                                                   ProductTypeText = d.ProductTypeText,
                                                   BaseLiveAnchorId = d.BaseLiveAnchorId,
                                                   BaseLiveAnchorName = d.BaseLiveAnchorName,
                                                   GetCustomerType = d.GetCustomerType,
                                                   GetCustomerTypeText = d.GetCustomerTypeText
                                               };

                FxPageInfo<ShoppingCartRegistrationVo> shoppingCartRegistrationPageInfo = new FxPageInfo<ShoppingCartRegistrationVo>();
                shoppingCartRegistrationPageInfo.TotalCount = q.TotalCount;
                shoppingCartRegistrationPageInfo.List = shoppingCartRegistration;

                return ResultData<FxPageInfo<ShoppingCartRegistrationVo>>.Success().AddData("shoppingCartRegistrationInfo", shoppingCartRegistrationPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<ShoppingCartRegistrationVo>>.Fail(ex.Message);
            }
        }




        /// <summary>
        /// 添加小黄车登记信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddShoppingCartRegistrationVo addVo)
        {
            try
            {
                //var isExistPhone = await shoppingCartRegistrationService.GetByPhoneAsync(addVo.Phone);
                //if (!string.IsNullOrEmpty(isExistPhone.Id))
                //{
                //    throw new Exception("已存在该客户手机号，无法录入，请重新填写！");
                //}

                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                AddShoppingCartRegistrationDto addDto = new AddShoppingCartRegistrationDto();
                addDto.RecordDate = addVo.RecordDate;
                addDto.ContentPlatFormId = addVo.ContentPlatFormId;
                addDto.LiveAnchorId = addVo.LiveAnchorId;
                addDto.GetCustomerType = addVo.GetCustomerType;
                addDto.LiveAnchorWechatNo = addVo.LiveAnchorWechatNo;
                addDto.CustomerNickName = addVo.CustomerNickName;
                addDto.Phone = addVo.Phone;
                addDto.SubPhone = addVo.SubPhone;
                addDto.Price = addVo.Price;
                addDto.ConsultationType = addVo.ConsultationType;
                addDto.ShoppingCartRegistrationCustomerType = addVo.ShoppingCartRegistrationCustomerType;
                addDto.IsWriteOff = addVo.IsWriteOff;
                addDto.IsAddWeChat = addVo.IsAddWeChat;
                addDto.ConsultationDate = addVo.ConsultationDate;
                addDto.IsReturnBackPrice = addVo.IsReturnBackPrice;
                addDto.Remark = addVo.Remark;
                addDto.CreateBy = employeeId;
                addDto.AssignEmpId = addVo.AssignEmpId;
                addDto.ReContent = addVo.ReContent;
                addDto.IsReContent = addVo.IsReContent;
                addDto.RefundDate = addVo.RefundDate;
                addDto.RefundReason = addVo.RefundReason;
                addDto.BadReviewContent = addVo.BadReviewContent;
                addDto.BadReviewDate = addVo.BadReviewDate;
                addDto.BadReviewReason = addVo.BadReviewReason;
                addDto.IsBadReview = addVo.IsBadReview;
                addDto.EmergencyLevel = addVo.EmergencyLevel;
                addDto.Source = addVo.Source;
                addDto.ProductType = addVo.ProductType;
                addDto.IsConsultation = addVo.IsConsultation;
                var contentPlatFormOrder = await contentPlateFormOrderService.GetOrderListByPhoneAsync(addVo.Phone);
                var isSendOrder = contentPlatFormOrder.Where(x => x.OrderStatus != (int)ContentPlateFormOrderStatus.HaveOrder).Count();
                if (contentPlatFormOrder.Count > 0)
                {
                    addDto.IsCreateOrder = true;
                }
                if (isSendOrder > 0)
                {
                    addDto.IsSendOrder = true;
                }

                await shoppingCartRegistrationService.AddAsync(addDto);

                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据小黄车登记编号获取小黄车登记信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<ShoppingCartRegistrationVo>> GetByIdAsync(string id)
        {
            try
            {
                var shoppingCartRegistration = await shoppingCartRegistrationService.GetByIdAsync(id);
                ShoppingCartRegistrationVo shoppingCartRegistrationVo = new ShoppingCartRegistrationVo();
                shoppingCartRegistrationVo.Id = shoppingCartRegistration.Id;
                shoppingCartRegistrationVo.RecordDate = shoppingCartRegistration.RecordDate;
                shoppingCartRegistrationVo.ContentPlatFormId = shoppingCartRegistration.ContentPlatFormId;
                shoppingCartRegistrationVo.LiveAnchorId = shoppingCartRegistration.LiveAnchorId;
                shoppingCartRegistrationVo.LiveAnchorWechatNo = shoppingCartRegistration.LiveAnchorWechatNo;
                shoppingCartRegistrationVo.LiveAnchorWeChatId = shoppingCartRegistration.LiveAnchorWeChatId;
                shoppingCartRegistrationVo.CustomerNickName = shoppingCartRegistration.CustomerNickName;
                shoppingCartRegistrationVo.Phone = shoppingCartRegistration.Phone;
                shoppingCartRegistrationVo.SubPhone = shoppingCartRegistration.SubPhone;
                shoppingCartRegistrationVo.IsAddWeChat = shoppingCartRegistration.IsAddWeChat;
                shoppingCartRegistrationVo.Price = shoppingCartRegistration.Price;
                shoppingCartRegistrationVo.ConsultationType = shoppingCartRegistration.ConsultationType;
                shoppingCartRegistrationVo.IsWriteOff = shoppingCartRegistration.IsWriteOff;
                shoppingCartRegistrationVo.ShoppingCartRegistrationCustomerType = shoppingCartRegistration.ShoppingCartRegistrationCustomerType;
                shoppingCartRegistrationVo.GetCustomerType = shoppingCartRegistration.GetCustomerType;
                shoppingCartRegistrationVo.IsConsultation = shoppingCartRegistration.IsConsultation;
                shoppingCartRegistrationVo.ConsultationDate = shoppingCartRegistration.ConsultationDate;
                shoppingCartRegistrationVo.IsReturnBackPrice = shoppingCartRegistration.IsReturnBackPrice;
                shoppingCartRegistrationVo.Remark = shoppingCartRegistration.Remark;
                shoppingCartRegistrationVo.CreateByEmpId = shoppingCartRegistration.CreateBy;
                shoppingCartRegistrationVo.AssignEmpId = shoppingCartRegistration.AssignEmpId;
                shoppingCartRegistrationVo.CreateDate = shoppingCartRegistration.CreateDate;
                shoppingCartRegistrationVo.ReContent = shoppingCartRegistration.ReContent;
                shoppingCartRegistrationVo.IsSendOrder = shoppingCartRegistration.IsSendOrder;
                shoppingCartRegistrationVo.IsCreateOrder = shoppingCartRegistration.IsCreateOrder;
                shoppingCartRegistrationVo.RefundDate = shoppingCartRegistration.RefundDate;
                shoppingCartRegistrationVo.RefundReason = shoppingCartRegistration.RefundReason;
                shoppingCartRegistrationVo.BadReviewContent = shoppingCartRegistration.BadReviewContent;
                shoppingCartRegistrationVo.BadReviewDate = shoppingCartRegistration.BadReviewDate;
                shoppingCartRegistrationVo.BadReviewReason = shoppingCartRegistration.BadReviewReason;
                shoppingCartRegistrationVo.IsReContent = shoppingCartRegistration.IsReContent;
                shoppingCartRegistrationVo.IsBadReview = shoppingCartRegistration.IsBadReview;
                shoppingCartRegistrationVo.EmergencyLevel = shoppingCartRegistration.EmergencyLevel;
                shoppingCartRegistrationVo.EmergencyLevelText = ServiceClass.GetShopCartRegisterEmergencyLevelText(shoppingCartRegistration.EmergencyLevel);
                shoppingCartRegistrationVo.Source = shoppingCartRegistration.Source;
                shoppingCartRegistrationVo.ProductType = shoppingCartRegistration.ProductType;
                shoppingCartRegistrationVo.BaseLiveAnchorId = shoppingCartRegistration.BaseLiveAnchorId;

                return ResultData<ShoppingCartRegistrationVo>.Success().AddData("shoppingCartRegistrationInfo", shoppingCartRegistrationVo);
            }
            catch (Exception ex)
            {
                return ResultData<ShoppingCartRegistrationVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 根据小黄车登记手机号获取小黄车登记信息
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        [HttpGet("byPhone/{phone}")]
        public async Task<ResultData<ShoppingCartRegistrationVo>> GetByPhoneAsync(string phone)
        {
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                var shoppingCartRegistration = await shoppingCartRegistrationService.GetByPhoneAsync(phone, employeeId);
                ShoppingCartRegistrationVo shoppingCartRegistrationVo = new ShoppingCartRegistrationVo();
                shoppingCartRegistrationVo.Id = shoppingCartRegistration.Id;
                shoppingCartRegistrationVo.RecordDate = shoppingCartRegistration.RecordDate;
                shoppingCartRegistrationVo.GetCustomerType = shoppingCartRegistration.GetCustomerType;
                shoppingCartRegistrationVo.GetCustomerTypeText = shoppingCartRegistration.GetCustomerTypeText;
                shoppingCartRegistrationVo.ContentPlatFormId = shoppingCartRegistration.ContentPlatFormId;
                shoppingCartRegistrationVo.ContentPlatFormName = shoppingCartRegistration.ContentPlatFormName;
                shoppingCartRegistrationVo.LiveAnchorId = shoppingCartRegistration.LiveAnchorId;
                shoppingCartRegistrationVo.LiveAnchorName = shoppingCartRegistration.LiveAnchorName;
                shoppingCartRegistrationVo.LiveAnchorWechatNo = shoppingCartRegistration.LiveAnchorWechatNo;
                shoppingCartRegistrationVo.LiveAnchorWeChatId = shoppingCartRegistration.LiveAnchorWeChatId;
                shoppingCartRegistrationVo.CustomerNickName = shoppingCartRegistration.CustomerNickName;
                shoppingCartRegistrationVo.Phone = shoppingCartRegistration.Phone;
                shoppingCartRegistrationVo.SubPhone = shoppingCartRegistration.SubPhone;
                shoppingCartRegistrationVo.IsAddWeChat = shoppingCartRegistration.IsAddWeChat;
                shoppingCartRegistrationVo.ShoppingCartRegistrationCustomerType = shoppingCartRegistrationVo.ShoppingCartRegistrationCustomerType;
                shoppingCartRegistrationVo.Price = shoppingCartRegistration.Price;
                shoppingCartRegistrationVo.ConsultationType = shoppingCartRegistration.ConsultationType;
                shoppingCartRegistrationVo.ConsultationTypeText = shoppingCartRegistration.ConsultationTypeText;
                shoppingCartRegistrationVo.IsWriteOff = shoppingCartRegistration.IsWriteOff;
                shoppingCartRegistrationVo.IsConsultation = shoppingCartRegistration.IsConsultation;
                shoppingCartRegistrationVo.ConsultationDate = shoppingCartRegistration.ConsultationDate;
                shoppingCartRegistrationVo.IsReturnBackPrice = shoppingCartRegistration.IsReturnBackPrice;
                shoppingCartRegistrationVo.Remark = shoppingCartRegistration.Remark;
                shoppingCartRegistrationVo.CreateByEmpId = shoppingCartRegistration.CreateBy;
                shoppingCartRegistrationVo.AssignEmpId = shoppingCartRegistration.AssignEmpId;
                shoppingCartRegistrationVo.CreateDate = shoppingCartRegistration.CreateDate;
                shoppingCartRegistrationVo.ReContent = shoppingCartRegistration.ReContent;
                shoppingCartRegistrationVo.IsSendOrder = shoppingCartRegistration.IsSendOrder;
                shoppingCartRegistrationVo.IsCreateOrder = shoppingCartRegistration.IsCreateOrder;
                shoppingCartRegistrationVo.RefundDate = shoppingCartRegistration.RefundDate;
                shoppingCartRegistrationVo.RefundReason = shoppingCartRegistration.RefundReason;
                shoppingCartRegistrationVo.BadReviewContent = shoppingCartRegistration.BadReviewContent;
                shoppingCartRegistrationVo.BadReviewDate = shoppingCartRegistration.BadReviewDate;
                shoppingCartRegistrationVo.BadReviewReason = shoppingCartRegistration.BadReviewReason;
                shoppingCartRegistrationVo.IsReContent = shoppingCartRegistration.IsReContent;
                shoppingCartRegistrationVo.IsBadReview = shoppingCartRegistration.IsBadReview;
                shoppingCartRegistrationVo.EmergencyLevel = shoppingCartRegistration.EmergencyLevel;
                shoppingCartRegistrationVo.EmergencyLevelText = ServiceClass.GetShopCartRegisterEmergencyLevelText(shoppingCartRegistration.EmergencyLevel);
                shoppingCartRegistrationVo.Source = shoppingCartRegistration.Source;
                shoppingCartRegistrationVo.SourceText = shoppingCartRegistration.SourceText;
                shoppingCartRegistrationVo.ShoppingCartRegistrationCustomerType = shoppingCartRegistration.ShoppingCartRegistrationCustomerType;
                shoppingCartRegistrationVo.ShoppingCartRegistrationCustomerTypeText = shoppingCartRegistration.ShoppingCartRegistrationCustomerTypeText;
                shoppingCartRegistrationVo.ProductType = shoppingCartRegistration.ProductType;
                return ResultData<ShoppingCartRegistrationVo>.Success().AddData("shoppingCartRegistrationInfo", shoppingCartRegistrationVo);
            }
            catch (Exception ex)
            {
                return ResultData<ShoppingCartRegistrationVo>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 修改小黄车登记信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateShoppingCartRegistrationVo updateVo)
        {
            OperationAddDto operationLog = new OperationAddDto();
            try
            {
                //var isExistPhone = await shoppingCartRegistrationService.GetByPhoneAsync(updateVo.Phone);
                //if (!string.IsNullOrEmpty(isExistPhone.Id) && isExistPhone.Id != updateVo.Id)
                //{
                //    throw new Exception("已存在该客户手机号，无法录入，请重新填写！");
                //}
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                operationLog.OperationBy = employeeId;

                UpdateShoppingCartRegistrationDto updateDto = new UpdateShoppingCartRegistrationDto();
                updateDto.Id = updateVo.Id;
                updateDto.RecordDate = updateVo.RecordDate;
                updateDto.ContentPlatFormId = updateVo.ContentPlatFormId;
                updateDto.LiveAnchorId = updateVo.LiveAnchorId;
                updateDto.LiveAnchorWechatNo = updateVo.LiveAnchorWechatNo;
                updateDto.CustomerNickName = updateVo.CustomerNickName;
                updateDto.IsAddWeChat = updateVo.IsAddWeChat;
                updateDto.Phone = updateVo.Phone;
                updateDto.SubPhone = updateVo.SubPhone;
                updateDto.Price = updateVo.Price;
                updateDto.ConsultationType = updateVo.ConsultationType;
                updateDto.IsWriteOff = updateVo.IsWriteOff;
                updateDto.ConsultationDate = updateVo.ConsultationDate;
                updateDto.IsConsultation = updateVo.IsConsultation;
                updateDto.IsReturnBackPrice = updateVo.IsReturnBackPrice;
                updateDto.Remark = updateVo.Remark;
                updateDto.BadReviewContent = updateVo.BadReviewContent;
                updateDto.IsReContent = updateVo.IsReContent;
                updateDto.ReContent = updateVo.ReContent;
                updateDto.RefundDate = updateVo.RefundDate;
                updateDto.GetCustomerType = updateVo.GetCustomerType;
                updateDto.RefundReason = updateVo.RefundReason;
                updateDto.BadReviewDate = updateVo.BadReviewDate;
                updateDto.BadReviewReason = updateVo.BadReviewReason;
                updateDto.IsBadReview = updateVo.IsBadReview;
                updateDto.AssignEmpId = updateVo.AssignEmpId;
                updateDto.EmergencyLevel = updateVo.EmergencyLevel;
                updateDto.Source = updateVo.Source;
                updateDto.ProductType = updateVo.ProductType;
                updateDto.ShoppingCartRegistrationCustomerType = updateVo.ShoppingCartRegistrationCustomerType;
                updateDto.OperationBy = employeeId;
                updateDto.CreateBy = updateVo.CreateBy;
                var contentPlatFormOrder = await contentPlateFormOrderService.GetOrderListByPhoneAsync(updateVo.Phone);
                var isSendOrder = contentPlatFormOrder.Where(x => x.OrderStatus != (int)ContentPlateFormOrderStatus.HaveOrder).Count();
                if (contentPlatFormOrder.Count > 0)
                {
                    updateDto.IsCreateOrder = true;
                }
                if (isSendOrder > 0)
                {
                    updateDto.IsSendOrder = true;
                }

                await shoppingCartRegistrationService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                operationLog.Message = ex.Message;
                operationLog.Code = -1;
                return ResultData.Fail(ex.Message);
            }
            finally
            {
                operationLog.Source = (int)RequestSource.AmiyaBackground;
                operationLog.Parameters = JsonConvert.SerializeObject(updateVo);
                operationLog.RequestType = (int)RequestType.Update;
                operationLog.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
                await operationLogService.AddOperationLogAsync(operationLog);
            }
        }

        /// <summary>
        /// 指派小黄车登记信息
        /// </summary>
        /// <param name="assignVo"></param>
        /// <returns></returns>
        [HttpPut("assign")]
        public async Task<ResultData> AssignAsync(AssignVo assignVo)
        {
            try
            {
                await shoppingCartRegistrationService.AssignAsync(assignVo.Id, assignVo.AssignBy);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 批量指派小黄车登记信息
        /// </summary>
        /// <param name="assignVo"></param>
        /// <returns></returns>
        [HttpPut("assignList")]
        public async Task<ResultData> AssignListAsync(AssignListVo assignVo)
        {
            try
            {
                foreach (var x in assignVo.IdList)
                {
                    await shoppingCartRegistrationService.AssignAsync(x, assignVo.AssignBy);
                }
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 输出紧急程度列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("emergencyLevels")]
        public ResultData<List<EmergencyLevelVo>> GetEmergencyLevel()
        {
            var emergencyLevel = from d in shoppingCartRegistrationService.GetEmergencyLevelList()
                                 select new EmergencyLevelVo
                                 {
                                     EmergencyLevel = d.EmergencyLevel,
                                     EmergencyLevelText = d.EmergencyText
                                 };
            return ResultData<List<EmergencyLevelVo>>.Success().AddData("emergencyLevels", emergencyLevel.ToList());
        }

        /// <summary>
        /// 客户来源列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("customerSourceList")]
        public async Task<ResultData<List<BaseIdAndNameVo<int>>>> GetCustomerSourceListAsync()
        {
            var nameList = shoppingCartRegistrationService.GetCustomerSourceList();
            var result = nameList.Select(e => new BaseIdAndNameVo<int>
            {
                Id = e.Key,
                Name = e.Value
            }).ToList();
            return ResultData<List<BaseIdAndNameVo<int>>>.Success().AddData("sourceList", result);

        }
        /// <summary>
        /// 客户类型列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("customerTypeList")]
        public async Task<ResultData<List<BaseIdAndNameVo<int>>>> GetCustomerTypeListAsync()
        {
            var nameList = shoppingCartRegistrationService.GetCustomerTypeList();
            var result = nameList.Select(e => new BaseIdAndNameVo<int>
            {
                Id = e.Key,
                Name = e.Value
            }).ToList();
            return ResultData<List<BaseIdAndNameVo<int>>>.Success().AddData("sourceList", result);

        }


        /// <summary>
        /// 获取带货产品类型列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("shoppingCartTakeGoodsProductTypeList")]
        public async Task<ResultData<List<BaseIdAndNameVo<int>>>> GetShoppingCartTakeGoodsProductTypeListAsync()
        {
            var nameList = shoppingCartRegistrationService.GetShoppingCartTakeGoodsProductTypeList();
            var result = nameList.Select(e => new BaseIdAndNameVo<int>
            {
                Id = e.Key,
                Name = e.Value
            }).ToList();
            return ResultData<List<BaseIdAndNameVo<int>>>.Success().AddData("sourceList", result);

        }
        /// <summary>
        /// 面诊方式列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("consultationTypeList")]
        public async Task<ResultData<List<BaseIdAndNameVo<int>>>> GetConsultationTypeListAsync()
        {
            var nameList = shoppingCartRegistrationService.GetShoppingCartConsultationTypeText();
            var result = nameList.Select(e => new BaseIdAndNameVo<int>
            {
                Id = e.Key,
                Name = e.Value
            }).ToList();
            return ResultData<List<BaseIdAndNameVo<int>>>.Success().AddData("typeList", result);
        }


        /// <summary>
        /// 获客方式列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("shoppingCartGetCustomerTypeList")]
        public async Task<ResultData<List<BaseIdAndNameVo<int>>>> GetShoppingCartGetCustomerTypeListAsync()
        {
            var nameList = shoppingCartRegistrationService.GetShoppingCartGetCustomerTypeText();
            var result = nameList.Select(e => new BaseIdAndNameVo<int>
            {
                Id = e.Key,
                Name = e.Value
            }).ToList();
            return ResultData<List<BaseIdAndNameVo<int>>>.Success().AddData("typeList", result);
        }

        /// <summary>
        /// 删除小黄车登记信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await shoppingCartRegistrationService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }


        /// <summary>
        /// 导入小黄车登记列表
        /// </summary>
        /// <returns></returns>
        [HttpPut("importShoppingCartRegistionData")]
        public async Task<ResultData> ReconciliationDocumentsInPortAsync(IFormFile file)
        {
            if (file == null || file.Length <= 0)
                throw new Exception("请检查文件是否存在");
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);//取到文件流

                using (ExcelPackage package = new ExcelPackage(stream))
                {

                    ExcelWorksheet worksheet = package.Workbook.Worksheets["sheet1"];
                    if (worksheet == null)
                    {
                        throw new Exception("请另外新建一个excel文件'.xlsx'后将填写好的数据复制到新文件中上传，勿采用当前导出文件进行上传！");
                    }
                    //获取表格的列数和行数
                    int rowCount = worksheet.Dimension.Rows;

                    List<AddShoppingCartRegistrationDto> addDtoList = new List<AddShoppingCartRegistrationDto>();
                    for (int x = 2; x <= rowCount; x++)
                    {
                        AddShoppingCartRegistrationDto addDto = new AddShoppingCartRegistrationDto();
                        if (worksheet.Cells[x, 1].Value != null)
                        {
                            string liveanchorName = worksheet.Cells[x, 1].Value.ToString();
                            if (liveanchorName == "刀刀")
                            {
                                addDto.LiveAnchorId = 84;
                            }
                            else if (liveanchorName == "吉娜")
                            {
                                addDto.LiveAnchorId = 12;
                            }
                            else
                            {
                                throw new Exception("主播栏目有数据输入非“刀刀”或者“吉娜”，请检查表格数据！");
                            }
                        }
                        else
                        {
                            throw new Exception("主播有参数列为空，请检查表格数据！");
                        }
                        if (worksheet.Cells[x, 2].Value != null)
                        {
                            addDto.CustomerNickName = worksheet.Cells[x, 2].Value.ToString();
                        }
                        else
                        {
                            throw new Exception("客户昵称有参数列为空，请检查表格数据！");
                        }
                        if (worksheet.Cells[x, 3].Value != null)
                        {
                            addDto.Phone = worksheet.Cells[x, 3].Value.ToString();
                        }
                        else
                        {
                            throw new Exception("客户电话有参数列为空，请检查表格数据！");
                        }
                        if (worksheet.Cells[x, 4].Value != null)
                        {
                            double tempValue;
                            if (double.TryParse(worksheet.Cells[x, 4].Value.ToString(), out tempValue))
                            {
                                var dealDate = DateTime.FromOADate(double.Parse(worksheet.Cells[x, 4].Value.ToString()));
                                addDto.RecordDate = dealDate;
                            }
                            else
                            {
                                addDto.RecordDate = Convert.ToDateTime(worksheet.Cells[x, 4].Value.ToString());
                            }
                        }
                        else
                        {
                            throw new Exception("登记时间有参数列为空，请检查表格数据！");
                        }
                        if (worksheet.Cells[x, 5].Value != null)
                        {
                            addDto.Price = Convert.ToDecimal(worksheet.Cells[x, 5].Value.ToString());
                        }
                        else
                        {
                            throw new Exception("消费金额有参数列为空，请检查表格数据！");
                        }
                        if (worksheet.Cells[x, 6].Value != null)
                        {
                            addDto.Remark = worksheet.Cells[x, 6].Value.ToString();
                        }
                        addDto.ContentPlatFormId = "9196b247-1ab9-4d0c-a11e-a1ef09019878";
                        addDto.SubPhone = "";
                        addDto.IsConsultation = false;
                        addDto.ConsultationType = 4;
                        addDto.IsWriteOff = false;
                        addDto.IsAddWeChat = false;
                        addDto.IsReturnBackPrice = false;
                        addDto.IsReContent = false;
                        addDto.CreateBy = employeeId;
                        addDto.IsBadReview = false;
                        addDto.EmergencyLevel = 2;
                        addDto.Source = 7;
                        addDtoList.Add(addDto);
                    }
                    await shoppingCartRegistrationService.AddListAsync(addDtoList);
                }
            }
            return ResultData.Success();


        }

        /// <summary>
        /// 导入小黄车登记列表（抖音小风车与视频号福袋）
        /// </summary>
        /// <returns></returns>
        [HttpPut("importTikTokAndVideoToShoppingCartRegistionData")]
        public async Task<ResultData> InPortTikTokAndVideoToShoppingCartRegistionDataAsync(IFormFile file)
        {
            if (file == null || file.Length <= 0)
                throw new Exception("请检查文件是否存在");
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);//取到文件流

                using (ExcelPackage package = new ExcelPackage(stream))
                {

                    ExcelWorksheet worksheet = package.Workbook.Worksheets["sheet1"];
                    if (worksheet == null)
                    {
                        throw new Exception("请另外新建一个excel文件'.xlsx'后将填写好的数据复制到新文件中上传，勿采用当前导出文件进行上传！");
                    }
                    //获取表格的列数和行数
                    int rowCount = worksheet.Dimension.Rows;

                    List<AddShoppingCartRegistrationDto> addDtoList = new List<AddShoppingCartRegistrationDto>();
                    for (int x = 2; x <= rowCount; x++)
                    {
                        AddShoppingCartRegistrationDto addDto = new AddShoppingCartRegistrationDto();

                        if (worksheet.Cells[x, 1].Value != null)
                        {
                            addDto.CustomerNickName = worksheet.Cells[x, 1].Value.ToString();
                        }
                        else
                        {
                            addDto.CustomerNickName = "-";
                        }
                        if (worksheet.Cells[x, 2].Value != null)
                        {
                            addDto.Phone = worksheet.Cells[x, 2].Value.ToString();
                        }
                        else
                        {
                            throw new Exception("客户电话有参数列为空，请检查表格数据！");
                        }
                        if (worksheet.Cells[x, 3].Value != null)
                        {
                            double tempValue;
                            if (double.TryParse(worksheet.Cells[x, 3].Value.ToString(), out tempValue))
                            {
                                var dealDate = DateTime.FromOADate(double.Parse(worksheet.Cells[x, 3].Value.ToString()));
                                addDto.RecordDate = dealDate;
                            }
                            else
                            {
                                addDto.RecordDate = Convert.ToDateTime(worksheet.Cells[x, 3].Value.ToString());
                            }
                        }
                        else
                        {
                            addDto.RecordDate = DateTime.Now;
                        }
                        if (worksheet.Cells[x, 4].Value != null)
                        {
                            if (worksheet.Cells[x, 4].Value.ToString().Contains("抖音"))
                            {
                                addDto.ContentPlatFormId = "4e4e9564-f6c3-47b6-a7da-e4518bab66a1";
                            }

                            else if (worksheet.Cells[x, 4].Value.ToString().Contains("视频号"))
                            {
                                addDto.ContentPlatFormId = "9196b247-1ab9-4d0c-a11e-a1ef09019878";
                            }
                            else
                            {
                                throw new Exception("平台列表存在非法参数，请检查表格数据！");
                            }
                        }
                        else
                        {
                            throw new Exception("平台有参数列为空，请检查表格数据！");
                        }

                        if (worksheet.Cells[x, 5].Value != null)
                        {
                            var liveAnchor = await liveAnchorService.GetValidListByContentPlatFormIdAndNameAsync(addDto.ContentPlatFormId, worksheet.Cells[x, 5].Value.ToString());
                            if (liveAnchor.Count() == 0)
                            {
                                throw new Exception("主播IP'" + worksheet.Cells[x, 5].Value.ToString() + "'数据未查询到，请检查表格数据！");
                            }
                            addDto.LiveAnchorId = liveAnchor.First().Id;
                        }
                        else
                        {
                            throw new Exception("主播IP有参数列为空，请检查表格数据！");
                        }
                        if (worksheet.Cells[x, 6].Value != null)
                        {
                            addDto.Remark = worksheet.Cells[x, 6].Value.ToString();
                        }
                        if (worksheet.Cells[x, 7].Value != null)
                        {
                            int lastSource = 0;
                            string source = worksheet.Cells[x, 7].Value.ToString();
                            switch (source)
                            {
                                case "短视频":
                                    lastSource = 0;
                                    break;
                                case "直播前":
                                    lastSource = 1;
                                    break;
                                case "粉丝群":
                                    lastSource = 2;
                                    break;
                                case "私信":
                                    lastSource = 3;
                                    break;
                                case "智能AI":
                                    lastSource = 4;
                                    break;
                                case "其他":
                                    lastSource = 5;
                                    break;
                                case "产品转化":
                                    lastSource = 6;
                                    break;
                                case "小风车":
                                    lastSource = 7;
                                    break;
                                case "福袋":
                                    lastSource = 8;
                                    break;
                            }
                            addDto.Source = lastSource;

                        }
                        else
                        {
                            throw new Exception("客户来源有参数列为空，请检查表格数据！");
                        }
                        if (worksheet.Cells[x, 8].Value != null)
                        {
                            addDto.Remark += "--" + worksheet.Cells[x, 8].Value.ToString();
                        }
                        addDto.SubPhone = "";
                        addDto.IsConsultation = false;
                        addDto.ConsultationType = 4;
                        addDto.IsWriteOff = false;
                        addDto.IsAddWeChat = false;
                        addDto.IsReturnBackPrice = false;
                        addDto.IsReContent = false;
                        addDto.CreateBy = employeeId;
                        addDto.IsBadReview = false;
                        addDto.EmergencyLevel = 2;

                        addDtoList.Add(addDto);
                    }
                    await shoppingCartRegistrationService.AddListAsync(addDtoList);
                }
            }
            return ResultData.Success();


        }

        /// <summary>
        /// 根据创建人与登记时间线获取医美/带货客资加v量
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("getAddWechatNumByCreateEmpInfoAndDate")]
        public async Task<ResultData<GetShoppingCartRegistionAddWechatNumVo>> GetAddWechatNumByCreateEmpInfoAndDateAsync([FromQuery] QueryAddWechatNumVo query)
        {
            try
            {
                QueryAddWeChatDto queryDto = new QueryAddWeChatDto();
                queryDto.EmployeeId = query.EmployeeId;
                queryDto.StartDate = query.SartDate;
                queryDto.EndDate = query.EndDate;
                var shoppingCartRegistration = await shoppingCartRegistrationService.GetShoppingCartRegistionAddWechatNumAsync(queryDto);
                GetShoppingCartRegistionAddWechatNumVo result = new GetShoppingCartRegistionAddWechatNumVo();
                result.BeautyCustomerAddWechatNum = shoppingCartRegistration.BeautyCustomerAddWechatNum;
                result.TakeGoodsCustomerAddWechatNum = shoppingCartRegistration.TakeGoodsCustomerAddWechatNum;
                return ResultData<GetShoppingCartRegistionAddWechatNumVo>.Success().AddData("AddWechatNumByCreateEmpInfoAndDate", result);
            }
            catch (Exception ex)
            {
                return ResultData<GetShoppingCartRegistionAddWechatNumVo>.Fail(ex.Message);
            }
        }
    }
}
