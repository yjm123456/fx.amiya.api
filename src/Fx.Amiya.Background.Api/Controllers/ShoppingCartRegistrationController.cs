using Fx.Amiya.Background.Api.Vo.ShoppingCartRegistration;
using Fx.Amiya.Dto.ShoppingCartRegistration;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using jos_sdk_net.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="shoppingCartRegistrationService"></param>
        public ShoppingCartRegistrationController(IShoppingCartRegistrationService shoppingCartRegistrationService,
            IHttpContextAccessor httpContextAccessor)
        {
            this.shoppingCartRegistrationService = shoppingCartRegistrationService;
            this.httpContextAccessor = httpContextAccessor;
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
        /// <param name="admissionId">接诊人员</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<ShoppingCartRegistrationVo>>> GetListWithPageAsync(DateTime? startDate, DateTime? endDate, int? LiveAnchorId, bool? isCreateOrder, bool? isSendOrder, bool? isAddWechat, bool? isWriteOff, bool? isConsultation, bool? isReturnBackPrice, string keyword, string contentPlatFormId, int pageNum, int pageSize, decimal? minPrice, decimal? maxPrice, int? admissionId)
        {
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                var q = await shoppingCartRegistrationService.GetListWithPageAsync(startDate, endDate, LiveAnchorId, isCreateOrder,  isSendOrder, employeeId, isAddWechat, isWriteOff, isConsultation, isReturnBackPrice, keyword, contentPlatFormId, pageNum, pageSize, minPrice, maxPrice, admissionId);

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
                                                   Price = d.Price,
                                                   IsCreateOrder=d.IsCreateOrder,
                                                   IsSendOrder=d.IsSendOrder,
                                                   ConsultationType = d.ConsultationType,
                                                   IsWriteOff = d.IsWriteOff,
                                                   IsConsultation = d.IsConsultation,
                                                   IsAddWeChat = d.IsAddWeChat,
                                                   IsReturnBackPrice = d.IsReturnBackPrice,
                                                   Remark = d.Remark,
                                                   CreateBy = d.CreateByName,
                                                   CreateDate = d.CreateDate,
                                                   IsReContent = d.IsReContent,
                                                   ReContent = d.ReContent,
                                                   RefundReason = d.RefundReason,
                                                   BadReviewContent = d.BadReviewContent,
                                                   BadReviewReason = d.BadReviewReason,
                                                   BadReviewDate = d.BadReviewDate == null ? null : d.BadReviewDate,
                                                   RefundDate = d.RefundDate,
                                                   IsBadReview = d.IsBadReview
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
                var isExistPhone = await shoppingCartRegistrationService.GetByPhoneAsync(addVo.Phone);
                if (!string.IsNullOrEmpty(isExistPhone.Id))
                {
                    throw new Exception("已存在该客户手机号，无法录入，请重新填写！");
                }
                AddShoppingCartRegistrationDto addDto = new AddShoppingCartRegistrationDto();
                addDto.RecordDate = addVo.RecordDate;
                addDto.ContentPlatFormId = addVo.ContentPlatFormId;
                addDto.LiveAnchorId = addVo.LiveAnchorId;
                addDto.LiveAnchorWechatNo = addVo.LiveAnchorWechatNo;
                addDto.CustomerNickName = addVo.CustomerNickName;
                addDto.Phone = addVo.Phone;
                addDto.Price = addVo.Price;
                addDto.ConsultationType = addVo.ConsultationType;
                addDto.IsWriteOff = addVo.IsWriteOff;
                addDto.IsAddWeChat = addVo.IsAddWeChat;
                addDto.IsConsultation = addVo.IsConsultation;
                addDto.IsReturnBackPrice = addVo.IsReturnBackPrice;
                addDto.Remark = addVo.Remark;
                addDto.CreateBy = addVo.AdmissionId;
                addDto.ReContent = addVo.ReContent;
                addDto.IsReContent = addVo.IsReContent;
                addDto.RefundDate = addVo.RefundDate;
                addDto.RefundReason = addVo.RefundReason;
                addDto.BadReviewContent = addVo.BadReviewContent;
                addDto.BadReviewDate = addVo.BadReviewDate;
                addDto.BadReviewReason = addVo.BadReviewReason;
                addDto.IsBadReview = addVo.IsBadReview;
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
                shoppingCartRegistrationVo.IsAddWeChat = shoppingCartRegistration.IsAddWeChat;
                shoppingCartRegistrationVo.Price = shoppingCartRegistration.Price;
                shoppingCartRegistrationVo.ConsultationType = shoppingCartRegistration.ConsultationType;
                shoppingCartRegistrationVo.IsWriteOff = shoppingCartRegistration.IsWriteOff;
                shoppingCartRegistrationVo.IsConsultation = shoppingCartRegistration.IsConsultation;
                shoppingCartRegistrationVo.IsReturnBackPrice = shoppingCartRegistration.IsReturnBackPrice;
                shoppingCartRegistrationVo.Remark = shoppingCartRegistration.Remark;
                shoppingCartRegistrationVo.CreateByEmpId = shoppingCartRegistration.CreateBy;
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
            try
            {
                var isExistPhone = await shoppingCartRegistrationService.GetByPhoneAsync(updateVo.Phone);
                if (!string.IsNullOrEmpty(isExistPhone.Id) && isExistPhone.Id != updateVo.Id)
                {
                    throw new Exception("已存在该客户手机号，无法录入，请重新填写！");
                }
                UpdateShoppingCartRegistrationDto updateDto = new UpdateShoppingCartRegistrationDto();
                updateDto.Id = updateVo.Id;
                updateDto.RecordDate = updateVo.RecordDate;
                updateDto.ContentPlatFormId = updateVo.ContentPlatFormId;
                updateDto.LiveAnchorId = updateVo.LiveAnchorId;
                updateDto.LiveAnchorWechatNo = updateVo.LiveAnchorWechatNo;
                updateDto.CustomerNickName = updateVo.CustomerNickName;
                updateDto.IsAddWeChat = updateVo.IsAddWeChat;
                updateDto.Phone = updateVo.Phone;
                updateDto.Price = updateVo.Price;
                updateDto.ConsultationType = updateVo.ConsultationType;
                updateDto.IsWriteOff = updateVo.IsWriteOff;
                updateDto.IsConsultation = updateVo.IsConsultation;
                updateDto.IsReturnBackPrice = updateVo.IsReturnBackPrice;
                updateDto.Remark = updateVo.Remark;
                updateDto.BadReviewContent = updateVo.BadReviewContent;
                updateDto.IsReContent = updateVo.IsReContent;
                updateDto.ReContent = updateVo.ReContent;
                updateDto.RefundDate = updateVo.RefundDate;
                updateDto.RefundReason = updateVo.RefundReason;
                updateDto.BadReviewDate = updateVo.BadReviewDate;
                updateDto.BadReviewReason = updateVo.BadReviewReason;
                updateDto.IsBadReview = updateVo.IsBadReview;
                updateDto.CreateBy = updateVo.AdmissionId;
                await shoppingCartRegistrationService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
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

                throw ex;
            }
        }

    }
}
