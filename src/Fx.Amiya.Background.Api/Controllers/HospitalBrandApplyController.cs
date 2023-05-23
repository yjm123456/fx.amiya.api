using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.GoodsInfo;
using Fx.Amiya.Background.Api.Vo.HospitalInfo;
using Fx.Amiya.Dto.GoodsDemand;
using Fx.Amiya.Dto.HospitalInfo;
using Fx.Amiya.Dto.OperationLog;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Jd.Api.Util;
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
    /// 医院品牌报名板块数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class HospitalBrandApplyController : ControllerBase
    {
        private IHospitalBrandApplyService hospitalBrandApplyService;
        private IOrderService _orderService;
        private ITmallGoodsSkuService tmallGoodsSkuService;
        private IHttpContextAccessor httpContextAccessor;
        private IOperationLogService operationLogService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hospitalBrandApplyService"></param>
        public HospitalBrandApplyController(IHospitalBrandApplyService hospitalBrandApplyService, IOrderService orderService,
            ITmallGoodsSkuService tmallGoodsSkuService, IHttpContextAccessor httpContextAccessor, IOperationLogService operationLogService)
        {
            this.hospitalBrandApplyService = hospitalBrandApplyService;
            _orderService = orderService;
            this.tmallGoodsSkuService = tmallGoodsSkuService;
            this.httpContextAccessor = httpContextAccessor;
            this.operationLogService = operationLogService;
        }



        /// <summary>
        /// 获取医院品牌报名信息列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="hospitalLinkMan">机构联系人</param>
        /// <param name="hospitalLinkManPhone">机构联系电话</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<HospitalBrandApplyVo>>> GetListWithPageAsync(string keyword, string hospitalLinkMan, string hospitalLinkManPhone, int pageNum, int pageSize)
        {
            try
            {
                var q = await hospitalBrandApplyService.GetListWithPageAsync(keyword, hospitalLinkMan, hospitalLinkManPhone, pageNum, pageSize);

                var hospitalBrandApply = from d in q.List
                                         select new HospitalBrandApplyVo
                                         {
                                             Id = d.Id,
                                             HospitalName = d.HospitalName,
                                             GoodsUrl = d.GoodsUrl,
                                             GoodsId = d.GoodsId,
                                             GoodsType = d.GoodsType,
                                             AllSaleNum = d.AllSaleNum,
                                             ExceededReason = d.ExceededReason,
                                             BusinessLicenseName = d.BusinessLicenseName,
                                             HospitalLinkMan = d.HospitalLinkMan,
                                             HospitalLinkManPhone = d.HospitalLinkManPhone
                                         };

                FxPageInfo<HospitalBrandApplyVo> hospitalBrandApplyPageInfo = new FxPageInfo<HospitalBrandApplyVo>();
                hospitalBrandApplyPageInfo.TotalCount = q.TotalCount;
                hospitalBrandApplyPageInfo.List = hospitalBrandApply;

                return ResultData<FxPageInfo<HospitalBrandApplyVo>>.Success().AddData("hospitalBrandApplyInfo", hospitalBrandApplyPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<HospitalBrandApplyVo>>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 添加医院品牌报名信息
        /// </summary>
        /// <param name="hospitalName"></param>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddHospitalBrandApplyInHospitalVo addVo)
        {
            try
            {
                foreach (var z in addVo.AddHospitalBrandApplyVo)
                {
                    AddHospitalBrandApplyDto addDto = new AddHospitalBrandApplyDto();
                    addDto.HospitalName = addVo.HospitalName;
                    addDto.HospitalLinkMan = addVo.HospitalLinkMan;
                    addDto.HospitalLinkManPhone = addVo.HospitalLinkManPhone;
                    addDto.BusinessLicenseName = addVo.BusinessLicenseName;
                    addDto.GoodsUrl = z.GoodsUrl;
                    addDto.GoodsId = z.GoodsId;
                    addDto.GoodsType = z.GoodsType;
                    addDto.AllSaleNum = z.AllSaleNum;
                    addDto.ExceededReason = z.ExceededReason;
                    List<AddTmallGoodsSkuDto> TmallGoodsSku = new List<AddTmallGoodsSkuDto>();
                    foreach (var x in z.TmallGoodsSkuVo)
                    {
                        AddTmallGoodsSkuDto skuDto = new AddTmallGoodsSkuDto();
                        skuDto.SkuName = x.SkuName;
                        skuDto.GoodsId = z.GoodsId;
                        skuDto.Price = x.Price;
                        skuDto.AllCount = x.AllCount;
                        TmallGoodsSku.Add(skuDto);
                    }
                    addDto.TmallGoodsSkuDto = TmallGoodsSku;
                    await hospitalBrandApplyService.AddAsync(addDto);
                }
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据医院品牌报名编号获取医院品牌报名信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<HospitalBrandApplyVo>> GetByIdAsync(string id)
        {
            try
            {
                var hospitalBrandApply = await hospitalBrandApplyService.GetByIdAsync(id);
                HospitalBrandApplyVo hospitalBrandApplyVo = new HospitalBrandApplyVo();
                hospitalBrandApplyVo.Id = hospitalBrandApply.Id;
                hospitalBrandApplyVo.HospitalName = hospitalBrandApply.HospitalName;
                hospitalBrandApplyVo.BusinessLicenseName = hospitalBrandApply.BusinessLicenseName;
                hospitalBrandApplyVo.HospitalLinkMan = hospitalBrandApply.HospitalLinkMan;
                hospitalBrandApplyVo.HospitalLinkManPhone = hospitalBrandApply.HospitalLinkManPhone;
                hospitalBrandApplyVo.GoodsUrl = hospitalBrandApply.GoodsUrl;
                hospitalBrandApplyVo.GoodsId = hospitalBrandApply.GoodsId;
                hospitalBrandApplyVo.GoodsType = hospitalBrandApply.GoodsType;
                hospitalBrandApplyVo.AllSaleNum = hospitalBrandApply.AllSaleNum;
                hospitalBrandApplyVo.ExceededReason = hospitalBrandApply.ExceededReason;
                var goodsInfo = await tmallGoodsSkuService.GetListWithPageAsync(hospitalBrandApplyVo.GoodsId, hospitalBrandApplyVo.HospitalName, 1, 9999);
                var goodsInfoList = from d in goodsInfo.List
                                    select new TmallGoodsSkuVo
                                    {
                                        Id = d.Id,
                                        Price = d.Price,
                                        SkuName = d.SkuName,
                                        GoodsId = d.GoodsId,
                                        AllCount = d.AllCount,
                                    };
                hospitalBrandApplyVo.TmallGoodsSkuVo = goodsInfoList.ToList(); ;
                return ResultData<HospitalBrandApplyVo>.Success().AddData("hospitalBrandApplyInfo", hospitalBrandApplyVo);
            }
            catch (Exception ex)
            {
                return ResultData<HospitalBrandApplyVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改医院品牌报名信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateHospitalBrandApplyVo updateVo)
        {
            try
            {
                UpdateHospitalBrandApplyDto updateDto = new UpdateHospitalBrandApplyDto();
                updateDto.Id = updateVo.Id;
                updateDto.HospitalName = updateVo.HospitalName;
                updateDto.BusinessLicenseName = updateVo.BusinessLicenseName;
                updateDto.HospitalLinkMan = updateVo.HospitalLinkMan;
                updateDto.HospitalLinkManPhone = updateVo.HospitalLinkManPhone;
                updateDto.GoodsId = updateVo.GoodsId;
                updateDto.GoodsType = updateVo.GoodsType;
                updateDto.GoodsUrl = updateVo.GoodsUrl;
                updateDto.AllSaleNum = updateVo.AllSaleNum;
                List<AddTmallGoodsSkuDto> TmallGoodsSku = new List<AddTmallGoodsSkuDto>();
                foreach (var x in updateVo.TmallGoodsSkuDto)
                {
                    AddTmallGoodsSkuDto skuDto = new AddTmallGoodsSkuDto();
                    skuDto.SkuName = x.SkuName;
                    skuDto.GoodsId = updateVo.GoodsId;
                    skuDto.AllCount = x.AllCount;
                    skuDto.Price = x.Price;
                    TmallGoodsSku.Add(skuDto);
                }
                updateDto.TmallGoodsSkuDto = TmallGoodsSku;
                updateDto.ExceededReason = updateVo.ExceededReason;
                await hospitalBrandApplyService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除医院品牌报名信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await hospitalBrandApplyService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// 导出医院品牌报名信息
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        [HttpGet("Export")]
        public async Task<FileStreamResult> GetOrderBuyExportAsync(string keyWord)
        {
            OperationAddDto operationAddDto = new OperationAddDto();
            operationAddDto.Code = 0;
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                operationAddDto.OperationBy = employeeId;
                var q = await hospitalBrandApplyService.GetDetailAsync(keyWord);
                var res = from d in q
                          select new ExportHospitalBrandApplyAndTmallGoodsVo()
                          {
                              HospitalName = d.HospitalName,
                              BusinessLicenseName = d.BusinessLicenseName,
                              HospitalLinkMan = d.HospitalLinkMan,
                              HospitalLinkManPhone = d.HospitalLinkManPhone,
                              GooodsUrl = d.GooodsUrl,
                              GoodsId = d.GoodsId,
                              SkuName = d.SkuName,
                              Price = d.Price,
                              AllSaleNum = d.AllSaleNum,
                              GoodsType = d.GoodsType,
                              AllCount = d.AllCount,
                              ExceededReason = d.ExceededReason
                          };
                var exportOrderWriteOff = res.ToList();
                var stream = ExportExcelHelper.ExportExcel(exportOrderWriteOff);
                var result = File(stream, "application/vnd.ms-excel", $"各医院品牌专区报名报表.xls");
                return result;
            }
            catch (Exception err)
            {
                operationAddDto.Code = -1;
                operationAddDto.Message = err.Message.ToString();
                throw new Exception(err.Message.ToString());
            }
            finally
            {
                
                
                operationAddDto.Parameters = keyWord;
                operationAddDto.RequestType = (int)RequestType.Export;
                operationAddDto.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
                await operationLogService.AddOperationLogAsync(operationAddDto);
            }
        }


    }
}
