using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.IService;
using Fx.Amiya.MiniProgram.Api.Filters;
using Fx.Amiya.MiniProgram.Api.Vo.ItemInfo;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.MiniProgram.Api.Controllers
{
    /// <summary>
    /// 项目
    /// </summary>
    [Route("amiya/wxmini/[controller]")]
    [ApiController]
    public class ItemInfoController : ControllerBase
    {
        private IItemInfoService itemInfoService;
        private IMiniSessionStorage sessionStorage;
        private TokenReader tokenReader;
        public ItemInfoController(IItemInfoService itemInfoService, IMiniSessionStorage sessionStorage, TokenReader tokenReader)
        {
            this.itemInfoService = itemInfoService;
            this.sessionStorage = sessionStorage;
            this.tokenReader = tokenReader;
        }

        
        /// <summary>
        /// 获取简单字段项目列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("simpleList")]
        public async Task<ResultData<List<WxSimpleItemInfoVo>>> GetSimpleListAsync(string keyword)
        {
            try
            {
                var item = from d in await itemInfoService.GetSimpleListAsync(keyword)
                           select new WxSimpleItemInfoVo
                           {
                               Id = d.Id,
                               Name = d.Name,
                               ThumbPicUrl = d.ThumbPicUrl
                           };
                return ResultData<List<WxSimpleItemInfoVo>>.Success().AddData("itemInfoList", item.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<WxSimpleItemInfoVo>>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 客户获取已购买的项目列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("listByCustomer")]
        [FxAmiyaApiUserTypeAuthorization(UserType.Customer)]
        public async Task<ResultData<List<WxSimpleItemInfoVo>>> GetListByCustomerAsync()
        {
            try
            {
                var token = tokenReader.GetToken();
                var sesssionInfo = sessionStorage.GetSession(token);
                string customerId = sesssionInfo.FxCustomerId;


                var item = from d in await itemInfoService.GetListByCustomerAsync(customerId)
                           select new WxSimpleItemInfoVo
                           {
                               Id = d.Id,
                               Name = d.Name,
                               ThumbPicUrl = d.ThumbPicUrl
                           };
                return ResultData<List<WxSimpleItemInfoVo>>.Success().AddData("itemInfoList", item.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<WxSimpleItemInfoVo>>.Fail(ex.Message);
            }
        }
        /// <summary>
        /// 客户获取可核销项目数量
        /// </summary>
        /// <returns></returns>
        [HttpGet("canWriteOffOrders")]
        [FxAmiyaApiUserTypeAuthorization(UserType.Customer)]
        public async Task<ResultData<List<WxSimpleOrderInfoVo>>> GetCanWriteOffOrdersCount()
        {
            try
            {
                var token = tokenReader.GetToken();
                var sesssionInfo = sessionStorage.GetSession(token);
                string customerId = sesssionInfo.FxCustomerId;

                var item = from d in await itemInfoService.GetCanWriteOffOrdersCount(customerId)
                           select new WxSimpleOrderInfoVo
                           {
                               OrderId = d.OrderId,
                               Name = d.Name,
                               ThumbPicUrl = d.ThumbPicUrl
                           };
                return ResultData<List<WxSimpleOrderInfoVo>>.Success().AddData("itemInfoList", item.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<WxSimpleOrderInfoVo>>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 根据项目编号获取项目信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<WxItemInfoVo>> GetByIdAsync(int id)
        {
            try
            {
                var item = await itemInfoService.GetDetailByIdAsync(id);
                WxItemInfoVo wxItemInfoVo = new WxItemInfoVo();
                wxItemInfoVo.Id = item.Id;
                wxItemInfoVo.OtherAppItemId = item.OtherAppItemId;
                wxItemInfoVo.Name = item.Name;
                wxItemInfoVo.ThumbPicUrl = item.ThumbPicUrl;
                wxItemInfoVo.Description = item.Description;
                wxItemInfoVo.Standard = item.Standard;
                wxItemInfoVo.Parts = item.Parts;
                wxItemInfoVo.Commitment = item.Commitment;
                wxItemInfoVo.Guarantee = item.Guarantee;
                wxItemInfoVo.AppointmentNotice = item.AppointmentNotice;
                wxItemInfoVo.ItemDetailHtml = item.ItemDetailHtml;

                return ResultData<WxItemInfoVo>.Success().AddData("itemInfo",wxItemInfoVo);
            }
            catch (Exception ex)   
            {
                return ResultData<WxItemInfoVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 获取项目列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<List<WxItemInfoVo>>> GetListAsync()
        {
            try
            {
                var item = from d in await itemInfoService.GetDetailListAsync()
                           select new WxItemInfoVo
                           {
                               Id = d.Id,
                               OtherAppItemId = d.OtherAppItemId,
                               Name = d.Name,
                               ThumbPicUrl = d.ThumbPicUrl,
                               Description = d.Description,
                               Standard = d.Standard,
                               Parts = d.Parts,
                               Commitment = d.Commitment,
                               Guarantee = d.Guarantee,
                               AppointmentNotice = d.AppointmentNotice,
                               ItemDetailHtml = d.ItemDetailHtml,
                           };
                return ResultData<List<WxItemInfoVo>>.Success().AddData("itemInfo",item.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<WxItemInfoVo>>.Fail(ex.Message);
            }
        }
    }
}