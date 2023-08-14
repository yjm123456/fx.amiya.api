using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.ItemInfo;
using Fx.Amiya.Background.Api.Vo.LivingDailyTakeGoods.Input;
using Fx.Amiya.Background.Api.Vo.LivingDailyTakeGoods.Output;
using Fx.Amiya.Dto.LivingDailyTakeGoods.Input;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Jd.Api.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 直播间带货数据数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class LivingDailyTakeGoodsController : ControllerBase
    {
        private ILivingDailyTakeGoodsService _LivingDailyTakeGoodsService;
        private IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="LivingDailyTakeGoodsService"></param>
        public LivingDailyTakeGoodsController(ILivingDailyTakeGoodsService LivingDailyTakeGoodsService, IHttpContextAccessor httpContextAccessor)
        {
            _LivingDailyTakeGoodsService = LivingDailyTakeGoodsService;
            this.httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// 获取直播间带货数据信息列表（分页）
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]

        public async Task<ResultData<FxPageInfo<LivingDailyTakeGoodsVo>>> GetListWithPageAsync([FromQuery] QueryLivingDailyTakeGoodsVo query)
        {
            try
            {
                QueryLivingDailyTakeGoodsDto queryLivingDailyTakeGoodsDto = new QueryLivingDailyTakeGoodsDto();
                queryLivingDailyTakeGoodsDto.PageNum = query.PageNum;
                queryLivingDailyTakeGoodsDto.PageSize = query.PageSize;
                queryLivingDailyTakeGoodsDto.StartDate = query.StartDate;
                queryLivingDailyTakeGoodsDto.EndDate = query.EndDate;
                queryLivingDailyTakeGoodsDto.KeyWord = query.KeyWord;
                queryLivingDailyTakeGoodsDto.BrandId = query.BrandId;
                queryLivingDailyTakeGoodsDto.CategoryId = query.CategoryId;
                queryLivingDailyTakeGoodsDto.ItemDetailsId = query.ItemDetailsId;
                queryLivingDailyTakeGoodsDto.CreateBy = query.CreateBy;
                queryLivingDailyTakeGoodsDto.Valid = query.Valid;
                var q = await _LivingDailyTakeGoodsService.GetListWithPageAsync(queryLivingDailyTakeGoodsDto);

                var LivingDailyTakeGoods = from d in q.List
                                           select new LivingDailyTakeGoodsVo
                                           {
                                               Id = d.Id,
                                               CreateDate = d.CreateDate,
                                               CreatBy = d.CreatBy,
                                               CreateByEmpName = d.CreateByEmpName,
                                               UpdateDate = d.UpdateDate,
                                               Valid = d.Valid,
                                               DeleteDate = d.DeleteDate,
                                               TakeGoodsDate = d.TakeGoodsDate,
                                               BrandName = d.BrandName,
                                               CategoryName = d.CategoryName,
                                               ItemDetailsName = d.ItemDetailsName,
                                               OrderNum = d.OrderNum,
                                               ContentPlatFormName = d.ContentPlatFormName,
                                               LiveAnchorName = d.LiveAnchorName,
                                               ItemName = d.ItemName,
                                               SinglePrice = d.SinglePrice,
                                               TakeGoodsQuantity = d.TakeGoodsQuantity,
                                               TotalPrice = d.TotalPrice,
                                               TakeGoodsTypeText = d.TakeGoodsTypeText,
                                               Remark = d.Remark,
                                           };

                FxPageInfo<LivingDailyTakeGoodsVo> LivingDailyTakeGoodsPageInfo = new FxPageInfo<LivingDailyTakeGoodsVo>();
                LivingDailyTakeGoodsPageInfo.TotalCount = q.TotalCount;
                LivingDailyTakeGoodsPageInfo.List = LivingDailyTakeGoods;

                return ResultData<FxPageInfo<LivingDailyTakeGoodsVo>>.Success().AddData("LivingDailyTakeGoodsInfo", LivingDailyTakeGoodsPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<LivingDailyTakeGoodsVo>>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 添加直播间带货数据信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]

        public async Task<ResultData> AddAsync(LivingDailyTakeGoodsAddVo addVo)
        {
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                LivingDailyTakeGoodsAddDto addDto = new LivingDailyTakeGoodsAddDto();

                addDto.CreatBy = employeeId;
                addDto.BrandId = addVo.BrandId;
                addDto.CategoryId = addVo.CategoryId;
                addDto.ItemDetailsId = addVo.ItemDetailsId;
                addDto.TakeGoodsDate = addVo.TakeGoodsDate;
                addDto.ContentPlatFormId = addVo.ContentPlatFormId;
                addDto.LiveAnchorId = addVo.LiveAnchorId;
                addDto.ItemId = addVo.ItemId;
                addDto.OrderNum = addVo.OrderNum;
                addDto.SinglePrice = addVo.SinglePrice;
                addDto.TakeGoodsQuantity = addVo.TakeGoodsQuantity;
                addDto.TotalPrice = addVo.TotalPrice;
                addDto.TakeGoodsType = addVo.TakeGoodsType;
                addDto.Remark = addVo.Remark;
                await _LivingDailyTakeGoodsService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据直播间带货数据编号获取直播间带货数据信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]

        public async Task<ResultData<LivingDailyTakeGoodsVo>> GetByIdAsync(string id)
        {
            try
            {
                var LivingDailyTakeGoods = await _LivingDailyTakeGoodsService.GetByIdAsync(id);
                LivingDailyTakeGoodsVo LivingDailyTakeGoodsVo = new LivingDailyTakeGoodsVo();
                LivingDailyTakeGoodsVo.Id = LivingDailyTakeGoods.Id;
                LivingDailyTakeGoodsVo.CreatBy = LivingDailyTakeGoods.CreatBy;
                LivingDailyTakeGoodsVo.OrderNum = LivingDailyTakeGoods.OrderNum;
                LivingDailyTakeGoodsVo.TakeGoodsDate = LivingDailyTakeGoods.TakeGoodsDate;
                LivingDailyTakeGoodsVo.BrandId = LivingDailyTakeGoods.BrandId;
                LivingDailyTakeGoodsVo.CategoryId = LivingDailyTakeGoods.CategoryId;
                LivingDailyTakeGoodsVo.ItemDetailsId = LivingDailyTakeGoods.ItemDetailsId;
                LivingDailyTakeGoodsVo.ContentPlatFormId = LivingDailyTakeGoods.ContentPlatFormId;
                LivingDailyTakeGoodsVo.LiveAnchorId = LivingDailyTakeGoods.LiveAnchorId;
                LivingDailyTakeGoodsVo.ItemId = LivingDailyTakeGoods.ItemId;
                LivingDailyTakeGoodsVo.SinglePrice = LivingDailyTakeGoods.SinglePrice;
                LivingDailyTakeGoodsVo.TakeGoodsQuantity = LivingDailyTakeGoods.TakeGoodsQuantity;
                LivingDailyTakeGoodsVo.TotalPrice = LivingDailyTakeGoods.TotalPrice;
                LivingDailyTakeGoodsVo.TakeGoodsType = LivingDailyTakeGoods.TakeGoodsType;
                LivingDailyTakeGoodsVo.Remark = LivingDailyTakeGoods.Remark;

                LivingDailyTakeGoodsVo.CreateDate = LivingDailyTakeGoods.CreateDate;
                LivingDailyTakeGoodsVo.Valid = LivingDailyTakeGoods.Valid;
                return ResultData<LivingDailyTakeGoodsVo>.Success().AddData("LivingDailyTakeGoodsInfo", LivingDailyTakeGoodsVo);
            }
            catch (Exception ex)
            {
                return ResultData<LivingDailyTakeGoodsVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改直播间带货数据信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("update")]

        public async Task<ResultData> UpdateAsync(LivingDailyTakeGoodsUpdateVo updateVo)
        {
            try
            {
                LivingDailyTakeGoodsUpdateDto updateDto = new LivingDailyTakeGoodsUpdateDto();
                updateDto.Id = updateVo.Id;
                updateDto.BrandId = updateVo.BrandId;
                updateDto.TakeGoodsDate = updateVo.TakeGoodsDate;
                updateDto.CategoryId = updateVo.CategoryId;
                updateDto.ItemDetailsId = updateVo.ItemDetailsId;
                updateDto.ContentPlatFormId = updateVo.ContentPlatFormId;
                updateDto.LiveAnchorId = updateVo.LiveAnchorId;
                updateDto.ItemId = updateVo.ItemId;
                updateDto.SinglePrice = updateVo.SinglePrice;
                updateDto.TakeGoodsQuantity = updateVo.TakeGoodsQuantity;
                updateDto.TotalPrice = updateVo.TotalPrice;
                updateDto.OrderNum = updateVo.OrderNum;
                updateDto.TakeGoodsType = updateVo.TakeGoodsType;
                updateDto.Remark = updateVo.Remark;
                await _LivingDailyTakeGoodsService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
        /// <summary>
        /// 删除直播间带货数据信息(软删除)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]

        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await _LivingDailyTakeGoodsService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 获取带货商品类型
        /// </summary>
        /// <returns></returns>
        [HttpGet("getTakeGoodsTypeText")]
        public async Task<ResultData<List<BaseIdAndNameVo>>> GetTakeGoodsTypeTextAsync()
        {
            var result = from d in await _LivingDailyTakeGoodsService.GetTakeGoodsTypeAsync()
                         select new BaseIdAndNameVo
                         {
                             Id = d.Key,
                             Name = d.Value
                         };
            return ResultData<List<BaseIdAndNameVo>>.Success().AddData("takeGoodsTypeText", result.ToList());
        }
        /// <summary>
        /// 自动填写带货数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("autoCompleteGMVData")]
        public async Task<ResultData<AutoCompleteTakeGoodsGmvVo>> AutoCompleteTakeGoodsGmvAsync([FromQuery] AutoCompleteGmvDataVo query)
        {
            AutoCompleteTakeGoodsGmvVo result = new AutoCompleteTakeGoodsGmvVo();
            var data = await _LivingDailyTakeGoodsService.AutoCompleteTakeGoodsGmvDataAsync(query.RecordDate, query.monthTargetId);
            result.TodayGMV = data.TodayGMV;
            result.RefundGMV = data.RefundGMV;
            result.EliminateCardGMV = data.EliminateCardGMV;
            return ResultData<AutoCompleteTakeGoodsGmvVo>.Success().AddData("data", result);
        }
        /// <summary>
        /// 导入带货数据
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("importTakeGoodsData")]
        public async Task<ResultData> ImportTakeGoodsDataAsync(IFormFile file)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            var employeeId = Convert.ToInt32(employee.Id);
            if (file == null || file.Length <= 0)
                throw new Exception("请检查文件是否存在");
            List<LivingDailyTakeGoodsImportDto> addDtoList = new List<LivingDailyTakeGoodsImportDto>();
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

                    for (int x = 2; x <= rowCount; x++)
                    {
                        LivingDailyTakeGoodsImportDto addDto = new LivingDailyTakeGoodsImportDto();
                        var ContentPlatForm = worksheet.Cells[x, 1].Value?.ToString() ?? "";
                        var LiveAnchor = worksheet.Cells[x, 2].Value?.ToString() ?? "";
                        var Category = worksheet.Cells[x, 3].Value?.ToString() ?? "";
                        var Brand = worksheet.Cells[x, 4].Value?.ToString() ?? "";
                        var ItemDetails = worksheet.Cells[x, 5].Value?.ToString() ?? "";
                        var Item = worksheet.Cells[x, 6].Value?.ToString() ?? "";
                        var TakeGoodsDate = worksheet.Cells[x, 7].Value?.ToString() ?? "";
                        var isDate = DateTime.TryParse(TakeGoodsDate, out DateTime time);
                        if (!isDate) throw new Exception("带货时间格式错误");
                        var TakeGoodsType = worksheet.Cells[x, 8].Value?.ToString() ?? "";
                        var TakeGoodsQuantity = worksheet.Cells[x, 9].Value?.ToString() ?? "";
                        var TotalPrice = worksheet.Cells[x, 10].Value?.ToString() ?? "";
                        var OrderNum = worksheet.Cells[x, 11].Value?.ToString() ?? "";
                        var Remark = worksheet.Cells[x, 12].Value?.ToString() ?? "";
                        if (string.IsNullOrEmpty(ContentPlatForm)) throw new Exception("主播平台不能为空!");
                        if (string.IsNullOrEmpty(LiveAnchor)) throw new Exception("主播ip不能为空!");
                        if (string.IsNullOrEmpty(Category)) throw new Exception("品类名称不能为空!");
                        if (string.IsNullOrEmpty(Brand)) throw new Exception("品牌名称不能为空!");
                        if (string.IsNullOrEmpty(ItemDetails)) throw new Exception("品相名称不能为空!");
                        if (string.IsNullOrEmpty(Item)) throw new Exception("商品名称不能为空!");
                        if (string.IsNullOrEmpty(TakeGoodsDate)) throw new Exception("带货时间不能为空!");
                        if (string.IsNullOrEmpty(TakeGoodsType) && (TakeGoodsType != "下单" || TakeGoodsType != "退款")) throw new Exception("带货类型必须是'下单'或'退款'");
                        if (string.IsNullOrEmpty(TakeGoodsQuantity)) throw new Exception("数量不能为空!");
                        if (string.IsNullOrEmpty(TotalPrice)) throw new Exception("总价不能为空!");
                        if (string.IsNullOrEmpty(OrderNum)) throw new Exception("订单量不能为空!");
                        addDto.ContentPlatForm = ContentPlatForm;
                        addDto.LiveAnchor = LiveAnchor;
                        addDto.Category = Category;
                        addDto.Brand = Brand;
                        addDto.ItemDetails = ItemDetails;
                        addDto.Item = Item;
                        addDto.TakeGoodsDate = Convert.ToDateTime(TakeGoodsDate);
                        addDto.TakeGoodsType = TakeGoodsType;
                        addDto.TakeGoodsQuantity = Convert.ToInt32(TakeGoodsQuantity);
                        addDto.TotalPrice = Convert.ToDecimal(TotalPrice);
                        addDto.OrderNum = Convert.ToInt32(OrderNum);
                        addDto.Remark = Remark;
                        addDto.ContentPlatForm = ContentPlatForm;
                        addDto.CreateBy = employeeId;
                        addDtoList.Add(addDto);
                    }
                }
            }
            await _LivingDailyTakeGoodsService.ImportTakeGoodsDataAsync(addDtoList);
            return ResultData.Success();
        }
        /// <summary>
        /// 下载模板
        /// </summary>
        /// <returns></returns>
        [HttpGet("template")]
        public async Task<FileStreamResult> ExportTemplateAsync()
        {
            List<ImportTemplate> res = new List<ImportTemplate>();
            var stream = ExportExcelHelper.ExportExcel(res);
            var result = File(stream, "application/vnd.ms-excel", "带货数据导入模板.xls");
            //application/vnd.openxmlformats-officedocument.spreadsheetml.sheet
            return result;
        }
    }
}
