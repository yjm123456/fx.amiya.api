using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.ExpressInfo;
using Fx.Amiya.Background.Api.Vo.HospitalConsulationOperationData;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.HospitalConsulationOperationData;
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
    /// 机构咨询师运营数据分析板块数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class HospitalConsulationOperationDataController : ControllerBase
    {
        private IHospitalConsulationOperationDataService hospitalConsulationOperationDataService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hospitalConsulationOperationDataService"></param>
        public HospitalConsulationOperationDataController(
            IHospitalConsulationOperationDataService hospitalConsulationOperationDataService
            )
        {
            this.hospitalConsulationOperationDataService = hospitalConsulationOperationDataService;
        }


        /// <summary>
        /// 获取机构咨询师运营数据分析信息列表
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <param name="indicatorsId">归属指标id</param>
        /// <param name="hospitalId">医院id</param>
        /// <returns></returns>
        [HttpGet("list")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<List<HospitalConsulationOperationDataVo>>> GetListAsync(string keyword, string indicatorsId, int hospitalId)
        {
            try
            {
                var q = await hospitalConsulationOperationDataService.GetListAsync(keyword, indicatorsId, hospitalId);

                var hospitalOperationData = from d in q
                                            select new HospitalConsulationOperationDataVo
                                            {
                                                Id = d.Id,
                                                HospitalId = d.HospitalId,
                                                IndicatorId = d.IndicatorId,
                                                ConsulationName = d.ConsulationName,
                                                SendOrderNum = d.SendOrderNum,
                                                NewCustomerVisitNum = d.NewCustomerVisitNum,
                                                NewCustomerVisitRate = d.NewCustomerVisitRate,
                                                NewCustomerDealNum = d.NewCustomerDealNum,
                                                NewCustomerDealRate = d.NewCustomerDealRate,
                                                NewCustomerDealPrice = d.NewCustomerDealPrice,
                                                NewCustomerUnitPrice = d.NewCustomerUnitPrice,

                                                OldCustomerVisitNum = d.OldCustomerVisitNum,
                                                OldCustomerDealNum = d.OldCustomerDealNum,
                                                OldCustomerDealRate = d.OldCustomerDealRate,
                                                OldCustomerDealPrice = d.OldCustomerDealPrice,
                                                OldCustomerUnitPrice = d.OldCustomerUnitPrice,

                                                OldCustomerAchievementRate = d.OldCustomerAchievementRate,
                                                LasttMonthTotalAchievement = d.LasttMonthTotalAchievement,
                                            };

                List<HospitalConsulationOperationDataVo> hospitalOperationDataResult = new List<HospitalConsulationOperationDataVo>();
                hospitalOperationDataResult = hospitalOperationData.ToList();
                return ResultData<List<HospitalConsulationOperationDataVo>>.Success().AddData("hospitalOperationDataInfo", hospitalOperationDataResult);
            }
            catch (Exception ex)
            {
                return ResultData<List<HospitalConsulationOperationDataVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 添加机构咨询师运营数据分析信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [FxTenantAuthorize]
        [HttpPost]
        public async Task<ResultData> AddAsync(AddHospitalConsulationOperationDataVo addVo)
        {
            try
            {
                AddHospitalConsulationOperationDataDto addDto = new AddHospitalConsulationOperationDataDto();
                addDto.HospitalId = addVo.HospitalId;
                addDto.IndicatorId = addVo.IndicatorId;
                addDto.ConsulationName = addVo.ConsulationName;
                addDto.SendOrderNum = addVo.SendOrderNum;
                addDto.NewCustomerVisitNum = addVo.NewCustomerVisitNum;
                addDto.NewCustomerVisitRate = addVo.NewCustomerVisitRate;
                addDto.NewCustomerDealNum = addVo.NewCustomerDealNum;
                addDto.NewCustomerDealRate = addVo.NewCustomerDealRate;
                addDto.NewCustomerDealPrice = addVo.NewCustomerDealPrice;
                addDto.NewCustomerUnitPrice = addVo.NewCustomerUnitPrice;

                addDto.OldCustomerVisitNum = addVo.OldCustomerVisitNum;
                addDto.OldCustomerDealNum = addVo.OldCustomerDealNum;
                addDto.OldCustomerDealRate = addVo.OldCustomerDealRate;
                addDto.OldCustomerDealPrice = addVo.OldCustomerDealPrice;
                addDto.OldCustomerUnitPrice = addVo.OldCustomerUnitPrice;

                addDto.OldCustomerAchievementRate = addVo.OldCustomerAchievementRate;
                addDto.LasttMonthTotalAchievement = addVo.LasttMonthTotalAchievement;

                await hospitalConsulationOperationDataService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据机构咨询师运营数据分析编号获取机构咨询师运营数据分析信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        [FxTenantAuthorize]
        public async Task<ResultData<HospitalConsulationOperationDataVo>> GetByIdAsync(string id)
        {
            try
            {
                var hospitalOperationData = await hospitalConsulationOperationDataService.GetByIdAsync(id);
                HospitalConsulationOperationDataVo hospitalOperationDataVo = new HospitalConsulationOperationDataVo();
                hospitalOperationDataVo.Id = hospitalOperationData.Id;
                hospitalOperationDataVo.CreateDate = hospitalOperationData.CreateDate;
                hospitalOperationDataVo.UpdateDate = hospitalOperationData.UpdateDate;
                hospitalOperationDataVo.DeleteDate = hospitalOperationData.DeleteDate;
                hospitalOperationDataVo.Valid = hospitalOperationData.Valid;
                hospitalOperationDataVo.HospitalId = hospitalOperationData.HospitalId;
                hospitalOperationDataVo.IndicatorId = hospitalOperationData.IndicatorId;
                hospitalOperationDataVo.HospitalId = hospitalOperationData.HospitalId;
                hospitalOperationDataVo.IndicatorId = hospitalOperationData.IndicatorId;
                hospitalOperationDataVo.ConsulationName = hospitalOperationData.ConsulationName;
                hospitalOperationDataVo.SendOrderNum = hospitalOperationData.SendOrderNum;
                hospitalOperationDataVo.NewCustomerVisitNum = hospitalOperationData.NewCustomerVisitNum;
                hospitalOperationDataVo.NewCustomerVisitRate = hospitalOperationData.NewCustomerVisitRate;
                hospitalOperationDataVo.NewCustomerDealNum = hospitalOperationData.NewCustomerDealNum;
                hospitalOperationDataVo.NewCustomerDealRate = hospitalOperationData.NewCustomerDealRate;
                hospitalOperationDataVo.NewCustomerDealPrice = hospitalOperationData.NewCustomerDealPrice;
                hospitalOperationDataVo.NewCustomerUnitPrice = hospitalOperationData.NewCustomerUnitPrice;

                hospitalOperationDataVo.OldCustomerVisitNum = hospitalOperationData.OldCustomerVisitNum;
                hospitalOperationDataVo.OldCustomerDealNum = hospitalOperationData.OldCustomerDealNum;
                hospitalOperationDataVo.OldCustomerDealRate = hospitalOperationData.OldCustomerDealRate;
                hospitalOperationDataVo.OldCustomerDealPrice = hospitalOperationData.OldCustomerDealPrice;
                hospitalOperationDataVo.OldCustomerUnitPrice = hospitalOperationData.OldCustomerUnitPrice;

                hospitalOperationDataVo.OldCustomerAchievementRate = hospitalOperationData.OldCustomerAchievementRate;
                hospitalOperationDataVo.LasttMonthTotalAchievement = hospitalOperationData.LasttMonthTotalAchievement;

                return ResultData<HospitalConsulationOperationDataVo>.Success().AddData("hospitalOperationDataInfo", hospitalOperationDataVo);
            }
            catch (Exception ex)
            {
                return ResultData<HospitalConsulationOperationDataVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改机构咨询师运营数据分析信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        [FxTenantAuthorize]
        public async Task<ResultData> UpdateAsync(UpdateHospitalConsulationOperationDataVo updateVo)
        {
            try
            {
                UpdateHospitalConsulationOperationDataDto updateDto = new UpdateHospitalConsulationOperationDataDto();

                updateDto.Id = updateVo.Id;
                updateDto.HospitalId = updateVo.HospitalId;
                updateDto.IndicatorId = updateVo.IndicatorId;
                updateDto.HospitalId = updateVo.HospitalId;
                updateDto.IndicatorId = updateVo.IndicatorId;
                updateDto.ConsulationName = updateVo.ConsulationName;
                updateDto.SendOrderNum = updateVo.SendOrderNum;
                updateDto.NewCustomerVisitNum = updateVo.NewCustomerVisitNum;
                updateDto.NewCustomerVisitRate = updateVo.NewCustomerVisitRate;
                updateDto.NewCustomerDealNum = updateVo.NewCustomerDealNum;
                updateDto.NewCustomerDealRate = updateVo.NewCustomerDealRate;
                updateDto.NewCustomerDealPrice = updateVo.NewCustomerDealPrice;
                updateDto.NewCustomerUnitPrice = updateVo.NewCustomerUnitPrice;

                updateDto.OldCustomerVisitNum = updateVo.OldCustomerVisitNum;
                updateDto.OldCustomerDealNum = updateVo.OldCustomerDealNum;
                updateDto.OldCustomerDealRate = updateVo.OldCustomerDealRate;
                updateDto.OldCustomerDealPrice = updateVo.OldCustomerDealPrice;
                updateDto.OldCustomerUnitPrice = updateVo.OldCustomerUnitPrice;

                updateDto.OldCustomerAchievementRate = updateVo.OldCustomerAchievementRate;
                updateDto.LasttMonthTotalAchievement = updateVo.LasttMonthTotalAchievement;

                await hospitalConsulationOperationDataService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除机构咨询师运营数据分析信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [FxTenantAuthorize]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await hospitalConsulationOperationDataService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// 机构咨询师运营数据分析模板导出
        /// </summary>
        /// <returns></returns>
        [HttpGet("exportHospitalConsulationOperationData")]
        [FxTenantAuthorize]
        public async Task<FileStreamResult> exportHospitaConsulationOperationData()
        {
            var res = new List<AddHospitalConsulationOperationDataVo>();
            var exportOrderWriteOff = res.ToList();
            var stream = ExportExcelHelper.ExportExcel(exportOrderWriteOff);

            var result = File(stream, "application/vnd.ms-excel", $"机构咨询师运营数据分析模板.xls");
            return result;
        }

        /// <summary>
        /// 导入机构成交品项运营数据分析
        /// </summary>
        /// <returns></returns>
        [HttpPut("hospitalConsulationOperationDataInPort")]
        [FxTenantAuthorize]
        public async Task<ResultData> HospitalConsulationOperationDataInPortAsync(IFormFile file)
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
                            AddHospitalConsulationOperationDataDto addDto = new AddHospitalConsulationOperationDataDto();
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
                                addDto.ConsulationName = worksheet.Cells[x, 3].Value.ToString();
                            }
                            else
                            {
                                throw new Exception("咨询师名字有参数列为空，请检查表格数据！");
                            }
                            if (worksheet.Cells[x, 4].Value != null)
                            {
                                addDto.SendOrderNum = Convert.ToInt32(worksheet.Cells[x, 4].Value.ToString());
                            }
                            else
                            {
                                throw new Exception("派单数有参数列为空，请检查表格数据！");
                            }

                            if (worksheet.Cells[x, 5].Value != null)
                            {
                                addDto.NewCustomerVisitNum = Convert.ToInt32(worksheet.Cells[x, 5].Value.ToString());
                            }
                            else
                            {
                                throw new Exception("新客上门数有参数列为空，请检查表格数据！");
                            }
                            if (worksheet.Cells[x, 6].Value != null)
                            {
                                addDto.NewCustomerVisitRate = Convert.ToDecimal(worksheet.Cells[x, 6].Value.ToString());
                            }
                            else
                            {
                                throw new Exception("新客上门率有参数列为空，请检查表格数据！");
                            }
                            if (worksheet.Cells[x, 7].Value != null)
                            {
                                addDto.NewCustomerDealNum = Convert.ToInt32(worksheet.Cells[x, 7].Value.ToString());
                            }
                            else
                            {
                                throw new Exception("新客成交数有参数列为空，请检查表格数据！");
                            }
                            if (worksheet.Cells[x, 8].Value != null)
                            {
                                addDto.NewCustomerDealRate = Convert.ToDecimal(worksheet.Cells[x, 8].Value.ToString());
                            }
                            else
                            {
                                throw new Exception("新客成交率有参数列为空，请检查表格数据！");
                            }
                            if (worksheet.Cells[x, 9].Value != null)
                            {
                                addDto.NewCustomerDealPrice = Convert.ToInt32(worksheet.Cells[x, 9].Value.ToString());
                            }
                            else
                            {
                                throw new Exception("新客业绩有参数列为空，请检查表格数据！");
                            }
                            if (worksheet.Cells[x, 10].Value != null)
                            {
                                addDto.NewCustomerUnitPrice = Convert.ToDecimal(worksheet.Cells[x, 10].Value.ToString());
                            }
                            else
                            {
                                throw new Exception("新客客单价有参数列为空，请检查表格数据！");
                            }
                            if (worksheet.Cells[x, 11].Value != null)
                            {
                                addDto.OldCustomerVisitNum = Convert.ToInt32(worksheet.Cells[x, 11].Value.ToString());
                            }
                            else
                            {
                                throw new Exception("老客上门数有参数列为空，请检查表格数据！");
                            }
                            if (worksheet.Cells[x, 12].Value != null)
                            {
                                addDto.OldCustomerDealNum = Convert.ToInt32(worksheet.Cells[x, 12].Value.ToString());
                            }
                            else
                            {
                                throw new Exception("老客成交数有参数列为空，请检查表格数据！");
                            }
                            if (worksheet.Cells[x, 13].Value != null)
                            {
                                addDto.OldCustomerDealRate = Convert.ToDecimal(worksheet.Cells[x, 13].Value.ToString());
                            }
                            else
                            {
                                throw new Exception("老客成交率有参数列为空，请检查表格数据！");
                            }
                            if (worksheet.Cells[x, 14].Value != null)
                            {
                                addDto.OldCustomerDealPrice = Convert.ToInt32(worksheet.Cells[x, 14].Value.ToString());
                            }
                            else
                            {
                                throw new Exception("老客业绩有参数列为空，请检查表格数据！");
                            }
                            if (worksheet.Cells[x, 15].Value != null)
                            {
                                addDto.OldCustomerUnitPrice = Convert.ToDecimal(worksheet.Cells[x, 15].Value.ToString());
                            }
                            else
                            {
                                throw new Exception("老客客单价有参数列为空，请检查表格数据！");
                            }

                            if (worksheet.Cells[x, 16].Value != null)
                            {
                                addDto.OldCustomerAchievementRate = Convert.ToDecimal(worksheet.Cells[x, 16].Value.ToString());
                            }
                            else
                            {
                                throw new Exception("老客业绩占比有参数列为空，请检查表格数据！");
                            }
                            if (worksheet.Cells[x, 17].Value != null)
                            {
                                addDto.LasttMonthTotalAchievement = Convert.ToDecimal(worksheet.Cells[x, 17].Value.ToString());
                            }
                            else
                            {
                                throw new Exception("总业绩有参数列为空，请检查表格数据！");
                            }
                            await hospitalConsulationOperationDataService.AddAsync(addDto);
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
