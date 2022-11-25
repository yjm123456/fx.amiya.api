using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.ExpressInfo;
using Fx.Amiya.Background.Api.Vo.HospitalDealGoodsOperation;
using Fx.Amiya.Background.Api.Vo.HospitalDoctorOperation;
using Fx.Amiya.Background.Api.Vo.HospitalNetWorkConsulationOperationData;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Jd.Api.Util;
using jos_sdk_net.Util;
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
    /// 机构成交品项分析板块数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class HospitalDealItemOperationController : ControllerBase
    {
        //private IHospitalNetWorkConsulationOperationDataService hospitalOperationDataService;
        private IHospitalDealItemService hospitalDealItemService;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hospitalOperationDataService"></param>
        public HospitalDealItemOperationController(IHospitalDealItemService hospitalDealItemService)
        {
            this.hospitalDealItemService = hospitalDealItemService;
        }


        /// <summary>
        /// 获取机构成交品项分析信息列表
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <param name="indicatorsId">归属指标id</param>
        /// <returns></returns>
        [HttpGet("list")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<List<HospitalDealItemOperationVo>>> GetListAsync(string keyword, string indicatorsId, int hospitalId)
        {
            try
            {
                var list = await hospitalDealItemService.GetListAsync(keyword, indicatorsId, hospitalId);

                List<HospitalDealItemOperationVo> hospitalOperationDataPageInfo = list.Select(e => new HospitalDealItemOperationVo
                {
                    Id = e.Id,
                    HospitalId = e.HospitalId,
                    IndicatorId = e.IndicatorId,
                    DealItemName = e.DealItemName,
                    DealCount = e.DealCount,
                    DealPrice = e.DealPrice,
                    PerformanceRatio = e.PerformanceRatio,
                    DealUnitPrice=e.DealUnitPrice
                }).ToList();



                return ResultData<List<HospitalDealItemOperationVo>>.Success().AddData("hospitalDealItemData", hospitalOperationDataPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<List<HospitalDealItemOperationVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 添加机构成交品项分析信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [FxTenantAuthorize]
        [HttpPost]
        public async Task<ResultData> AddAsync(AddHospitalDealItemOperationVo addVo)
        {
            try
            {
                AddHospitalDealItemOperationDto addDto = new AddHospitalDealItemOperationDto
                {
                    HospitalId = addVo.HospitalId,
                    IndicatorId = addVo.IndicatorId,
                    DealItemName = addVo.DealItemName,
                    DealCount = addVo.DealCount,
                    DealPrice = addVo.DealPrice,
                    PerformanceRatio = addVo.PerformanceRatio,
                    DealUnitPrice=addVo.DealUnitPrice
                };
                await hospitalDealItemService.AddAsync(addDto);


                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据机构成交品项分析编号获取机构成交品项分析信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        [FxTenantAuthorize]
        public async Task<ResultData<HospitalDealItemOperationVo>> GetByIdAsync(string id)
        {
            try
            {

                HospitalDealItemOperationVo hospitalOperationDataVo = new HospitalDealItemOperationVo();
                var item = await hospitalDealItemService.GetByIdAsync(id);
                hospitalOperationDataVo.Id = item.Id;
                hospitalOperationDataVo.HospitalId = item.HospitalId;
                hospitalOperationDataVo.IndicatorId = item.IndicatorId;
                hospitalOperationDataVo.DealItemName = item.DealItemName;
                hospitalOperationDataVo.DealCount = item.DealCount;
                hospitalOperationDataVo.DealPrice = item.DealPrice;
                hospitalOperationDataVo.PerformanceRatio = item.PerformanceRatio;
                hospitalOperationDataVo.DealUnitPrice = item.DealUnitPrice;
                return ResultData<HospitalDealItemOperationVo>.Success().AddData("hospitalDealItemOperationInfo", hospitalOperationDataVo);
            }
            catch (Exception ex)
            {
                return ResultData<HospitalDealItemOperationVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改机构成交品项分析信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        [FxTenantAuthorize]
        public async Task<ResultData> UpdateAsync(HospitalDealItemOperationVo updateVo)
        {
            try
            {
                UpdateHospitalDealItemOperationDto updateDto = new UpdateHospitalDealItemOperationDto();
                updateDto.Id = updateVo.Id;
                updateDto.HospitalId = updateVo.HospitalId;
                updateDto.IndicatorId = updateVo.IndicatorId;
                updateDto.DealItemName = updateVo.DealItemName;
                updateDto.DealCount = updateVo.DealCount.HasValue? updateVo.DealCount.Value:0;
                updateDto.DealPrice = updateVo.DealPrice.HasValue ? updateVo.DealPrice.Value : 0;
                updateDto.PerformanceRatio = updateVo.PerformanceRatio.HasValue ? updateVo.PerformanceRatio.Value : 0;
                updateDto.DealUnitPrice = updateVo.DealUnitPrice.HasValue ? updateVo.DealUnitPrice : 0;
                await hospitalDealItemService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除机构成交品项分析信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [FxTenantAuthorize]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await hospitalDealItemService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// 机构成交品项运营数据分析模板导出
        /// </summary>
        /// <returns></returns>
        [HttpGet("exportHospitalDealItemOperationData")]
        [FxTenantAuthorize]
        public async Task<FileStreamResult> exportHospitaDealItemOperationData()
        {
            var res = new List<AddHospitalDealItemOperationVo>();
            var exportOrderWriteOff = res.ToList();
            var stream = ExportExcelHelper.ExportExcel(exportOrderWriteOff);
            var result = File(stream, "application/vnd.ms-excel", $"机构成交品项运营数据分析模板.xls");
            return result;
        }

        /// <summary>
        /// 导入机构成交品项运营数据分析
        /// </summary>
        /// <returns></returns>
        [HttpPut("hospitalDealItemOperationDataInPort")]
        [FxTenantAuthorize]
        public async Task<ResultData> HospitalDealItemOperationDataInPortAsync(IFormFile file)
        {
            try
            {
                if (file == null || file.Length <= 0)
                    throw new Exception("请检查文件是否存在");

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
                            AddHospitalDealItemOperationDto addDto = new AddHospitalDealItemOperationDto();
                            if (!string.IsNullOrEmpty(worksheet.Cells[x, 1].Value.ToString()))
                            {
                                addDto.IndicatorId = worksheet.Cells[x, 1].Value.ToString();
                            }
                            else
                            {
                                throw new Exception("归属指标编号有参数列为空，请检查表格数据！");
                            }
                            if (worksheet.Cells[x, 2].Value != null)
                            {
                                addDto.HospitalId = Convert.ToInt32(worksheet.Cells[x, 2].Value.ToString());
                            }
                            else
                            {
                                throw new Exception("医院编号有参数列为空，请检查表格数据！");
                            }
                            if (worksheet.Cells[x, 3].Value != null)
                            {
                                addDto.DealItemName = worksheet.Cells[x, 3].Value.ToString();
                            }
                            else
                            {
                                throw new Exception("执行品项名称有参数列为空，请检查表格数据！");
                            }
                            if (worksheet.Cells[x, 4].Value != null)
                            {
                                addDto.DealCount = Convert.ToInt32(worksheet.Cells[x, 4].Value.ToString());
                            }
                            else
                            {
                                throw new Exception("执行数量有参数列为空，请检查表格数据！");
                            }
                            if (worksheet.Cells[x, 5].Value != null)
                            {
                                addDto.DealUnitPrice = Convert.ToDecimal(worksheet.Cells[x, 5].Value.ToString());
                            }
                            else
                            {
                                throw new Exception("执行单价有参数列为空，请检查表格数据！");
                            }
                            if (worksheet.Cells[x, 6].Value != null)
                            {
                                addDto.DealPrice = Convert.ToDecimal(worksheet.Cells[x, 6].Value.ToString());
                            }
                            else
                            {
                                throw new Exception("执行金额有参数列为空，请检查表格数据！");
                            }
                            if (worksheet.Cells[x, 7].Value != null)
                            {
                                addDto.PerformanceRatio = Convert.ToDecimal(worksheet.Cells[x, 7].Value.ToString());
                            }
                            else
                            {
                                throw new Exception("执行占比有参数列为空，请检查表格数据！");
                            }
                            await hospitalDealItemService.AddAsync(addDto);
                        }
                    }
                }
                return ResultData.Success();
            }
            catch (Exception err)
            {
                return null;
            }

        }
    }
}
