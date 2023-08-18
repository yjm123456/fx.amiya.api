using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.ExpressInfo;
using Fx.Amiya.Background.Api.Vo.HospitalDoctorOperation;
using Fx.Amiya.Background.Api.Vo.HospitalNetWorkConsulationOperationData;
using Fx.Amiya.Dto.HospitalDoctorOperationData;
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
    /// 机构医生运营数据分析板块数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class HospitalDoctorOperationController : ControllerBase
    {
        private IHospitalDoctorOperationDataService hospitalDoctorOperationDataService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hospitalDoctorOperationDataService"></param>
        public HospitalDoctorOperationController(
             IHospitalDoctorOperationDataService hospitalDoctorOperationDataService
            )
        {
            this.hospitalDoctorOperationDataService = hospitalDoctorOperationDataService;
        }


        /// <summary>
        /// 获取医生运营数据分析板块信息列表
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <param name="indicatorsId">归属指标id</param>
        /// <returns></returns>
        [HttpGet("list")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<List<HospitalDoctorOperationVo>>> GetListAsync(string keyword, string indicatorsId, int hospitalId)
        {
            try
            {
                var q = await hospitalDoctorOperationDataService.GetListAsync(keyword, indicatorsId, hospitalId);

                var hospitalDoctorOperationData = from d in q orderby d.SectionOffice
                                                  select new HospitalDoctorOperationVo
                                                  {
                                                      Id = d.Id,
                                                      HospitalId = d.HospitalId,
                                                      IndicatorId = d.IndicatorId,
                                                      DoctorName = d.DoctorName,
                                                      NewCustomerAcceptNum = d.NewCustomerAcceptNum,
                                                      NewCustomerDealNum = d.NewCustomerDealNum,
                                                      NewCustomerDealRate = d.NewCustomerDealRate,
                                                      NewCustomerAchievement = d.NewCustomerAchievement,
                                                      NewCustomerUnitPrice = d.NewCustomerUnitPrice,
                                                      NewCustomerAchievementRate = d.NewCustomerAchievementRate,
                                                      OldCustomerAcceptNum = d.OldCustomerAcceptNum,
                                                      OldCustomerDealNum = d.OldCustomerDealNum,
                                                      OldCustomerDealRate = d.OldCustomerDealRate,
                                                      OldCustomerAchievement = d.OldCustomerAchievement,
                                                      OldCustomerUnitPrice = d.OldCustomerUnitPrice,
                                                      OldCustomerAchievementRate = d.OldCustomerAchievementRate,
                                                      SectionOffice=d.SectionOffice,
                                                      TotalPerformance=d.TotalPerformance
                                                  };

                List<HospitalDoctorOperationVo> hospitalDoctorOperationDataPageInfo = new List<HospitalDoctorOperationVo>();

                hospitalDoctorOperationDataPageInfo = hospitalDoctorOperationData.ToList();
                return ResultData<List<HospitalDoctorOperationVo>>.Success().AddData("hospitalDoctorOperationData", hospitalDoctorOperationDataPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<List<HospitalDoctorOperationVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 添加医生运营数据分析信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [FxTenantAuthorize]
        [HttpPost]
        public async Task<ResultData> AddAsync(AddHospitalDoctorOperationVo addVo)
        {
            try
            {
                AddHospitalDoctorOperationDataDto addDto = new AddHospitalDoctorOperationDataDto();
                addDto.HospitalId = addVo.HospitalId;
                addDto.IndicatorId = addVo.IndicatorId;
                addDto.DoctorName = addVo.DoctorName;
                addDto.SectionOffice = addVo.SectionOffice;
                addDto.NewCustomerAcceptNum = addVo.NewCustomerAcceptNum;
                addDto.NewCustomerDealNum = addVo.NewCustomerDealNum;
                addDto.NewCustomerDealRate = addVo.NewCustomerDealRate;
                addDto.NewCustomerAchievement = addVo.NewCustomerAchievement;
                addDto.NewCustomerUnitPrice = addVo.NewCustomerUnitPrice;
                addDto.NewCustomerAchievementRate = addVo.NewCustomerAchievementRate;
                addDto.OldCustomerAcceptNum = addVo.OldCustomerAcceptNum;
                addDto.OldCustomerDealNum = addVo.OldCustomerDealNum;
                addDto.OldCustomerDealRate = addVo.OldCustomerDealRate;
                addDto.OldCustomerAchievement = addVo.OldCustomerAchievement;
                addDto.OldCustomerUnitPrice = addVo.OldCustomerUnitPrice;
                addDto.OldCustomerAchievementRate = addVo.OldCustomerAchievementRate;
                addDto.TotalPerformance = addVo.TotalPerformance;
                await hospitalDoctorOperationDataService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据医生运营数据板块分析编号获取机构医生运营数据分析信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        [FxTenantAuthorize]
        public async Task<ResultData<HospitalDoctorOperationVo>> GetByIdAsync(string id)
        {
            try
            {
                var hospitalDoctorOperationData = await hospitalDoctorOperationDataService.GetByIdAsync(id);
                HospitalDoctorOperationVo hospitalDoctorOperationDataVo = new HospitalDoctorOperationVo();
                hospitalDoctorOperationDataVo.Id = hospitalDoctorOperationData.Id;
                hospitalDoctorOperationDataVo.CreateDate = hospitalDoctorOperationData.CreateDate;
                hospitalDoctorOperationDataVo.UpdateDate = hospitalDoctorOperationData.UpdateDate;
                hospitalDoctorOperationDataVo.DeleteDate = hospitalDoctorOperationData.DeleteDate;
                hospitalDoctorOperationDataVo.Valid = hospitalDoctorOperationData.Valid;
                hospitalDoctorOperationDataVo.HospitalId = hospitalDoctorOperationData.HospitalId;
                hospitalDoctorOperationDataVo.IndicatorId = hospitalDoctorOperationData.IndicatorId;
                hospitalDoctorOperationDataVo.DoctorName = hospitalDoctorOperationData.DoctorName;
                hospitalDoctorOperationDataVo.NewCustomerAcceptNum = hospitalDoctorOperationData.NewCustomerAcceptNum;
                hospitalDoctorOperationDataVo.NewCustomerDealNum = hospitalDoctorOperationData.NewCustomerDealNum;
                hospitalDoctorOperationDataVo.NewCustomerDealRate = hospitalDoctorOperationData.NewCustomerDealRate;
                hospitalDoctorOperationDataVo.NewCustomerAchievement = hospitalDoctorOperationData.NewCustomerAchievement;
                hospitalDoctorOperationDataVo.NewCustomerUnitPrice = hospitalDoctorOperationData.NewCustomerUnitPrice;
                hospitalDoctorOperationDataVo.NewCustomerAchievementRate = hospitalDoctorOperationData.NewCustomerAchievementRate;
                hospitalDoctorOperationDataVo.OldCustomerAcceptNum = hospitalDoctorOperationData.OldCustomerAcceptNum;
                hospitalDoctorOperationDataVo.OldCustomerDealNum = hospitalDoctorOperationData.OldCustomerDealNum;
                hospitalDoctorOperationDataVo.OldCustomerDealRate = hospitalDoctorOperationData.OldCustomerDealRate;
                hospitalDoctorOperationDataVo.OldCustomerAchievement = hospitalDoctorOperationData.OldCustomerAchievement;
                hospitalDoctorOperationDataVo.OldCustomerUnitPrice = hospitalDoctorOperationData.OldCustomerUnitPrice;
                hospitalDoctorOperationDataVo.OldCustomerAchievementRate = hospitalDoctorOperationData.OldCustomerAchievementRate;
                hospitalDoctorOperationDataVo.SectionOffice = hospitalDoctorOperationData.SectionOffice;
                hospitalDoctorOperationDataVo.TotalPerformance = hospitalDoctorOperationData.TotalPerformance;
                return ResultData<HospitalDoctorOperationVo>.Success().AddData("hospitalDoctorOperationInfo", hospitalDoctorOperationDataVo);
            }
            catch (Exception ex)
            {
                return ResultData<HospitalDoctorOperationVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改机构医生运营数据分析信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        [FxTenantAuthorize]
        public async Task<ResultData> UpdateAsync(UpdateHospitalDoctorOperationVo updateVo)
        {
            try
            {

                UpdateHospitalDoctorOperationDataDto updateDto = new UpdateHospitalDoctorOperationDataDto();
                updateDto.Id = updateVo.Id;
                updateDto.HospitalId = updateVo.HospitalId;
                updateDto.IndicatorId = updateVo.IndicatorId;
                updateDto.DoctorName = updateVo.DoctorName;
                updateDto.NewCustomerAcceptNum = updateVo.NewCustomerAcceptNum;
                updateDto.NewCustomerDealNum = updateVo.NewCustomerDealNum;
                updateDto.NewCustomerDealRate = updateVo.NewCustomerDealRate;
                updateDto.NewCustomerAchievement = updateVo.NewCustomerAchievement;
                updateDto.NewCustomerUnitPrice = updateVo.NewCustomerUnitPrice;
                updateDto.NewCustomerAchievementRate = updateVo.NewCustomerAchievementRate;
                updateDto.OldCustomerAcceptNum = updateVo.OldCustomerAcceptNum;
                updateDto.OldCustomerDealNum = updateVo.OldCustomerDealNum;
                updateDto.OldCustomerDealRate = updateVo.OldCustomerDealRate;
                updateDto.OldCustomerAchievement = updateVo.OldCustomerAchievement;
                updateDto.OldCustomerUnitPrice = updateVo.OldCustomerUnitPrice;
                updateDto.OldCustomerAchievementRate = updateVo.OldCustomerAchievementRate;
                updateDto.SectionOffice = updateVo.SectionOffice;
                updateDto.TotalPerformance = updateVo.TotalPerformance;
                await hospitalDoctorOperationDataService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除机构医生运营数据分析信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [FxTenantAuthorize]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await hospitalDoctorOperationDataService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// 机构医生运营数据分析模板导出
        /// </summary>
        /// <returns></returns>
        [HttpGet("exportHospitaDoctorOperationOperationData")]
        [FxTenantAuthorize]
        public async Task<FileStreamResult> exportHospitalDoctorOperationOperationData()
        {
            var res = new List<AddHospitalDoctorOperationVo>();
            var exportOrderWriteOff = res.ToList();
            var stream = ExportExcelHelper.ExportExcel(exportOrderWriteOff);
            var result = File(stream, "application/vnd.ms-excel", $"机构科室数据分析模板.xls");
            return result;
        }


        /// <summary>
        /// 导入机构成交品项运营数据分析
        /// </summary>
        /// <returns></returns>
        [HttpPut("hospitalDoctorOperationDataInPort")]
        [FxTenantAuthorize]
        public async Task<ResultData> HospitalDoctorOperationDataInPortAsync(IFormFile file)
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
                            AddHospitalDoctorOperationDataDto addDto = new AddHospitalDoctorOperationDataDto();
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
                                addDto.SectionOffice = Convert.ToString(worksheet.Cells[x, 3].Value.ToString());
                            }
                            else
                            {
                                throw new Exception("科室有参数列为空，请检查表格数据！");
                            }
                            if (worksheet.Cells[x, 4].Value != null)
                            {
                                addDto.DoctorName = worksheet.Cells[x, 4].Value.ToString();
                            }
                            else
                            {
                                throw new Exception("医生名称有参数列为空，请检查表格数据！");
                            }
                            if (worksheet.Cells[x, 5].Value != null)
                            {
                                addDto.NewCustomerAcceptNum = Convert.ToInt32(worksheet.Cells[x, 5].Value.ToString());
                            }
                            else
                            {
                                throw new Exception("新客接诊人数有参数列为空，请检查表格数据！");
                            }
                            if (worksheet.Cells[x, 6].Value != null)
                            {
                                addDto.NewCustomerDealNum = Convert.ToInt32(worksheet.Cells[x, 6].Value.ToString());
                            }
                            else
                            {
                                throw new Exception("新客成交人数有参数列为空，请检查表格数据！");
                            }
                            if (worksheet.Cells[x, 7].Value != null)
                            {
                                addDto.NewCustomerDealRate = Convert.ToDecimal(worksheet.Cells[x, 7].Value.ToString());
                            }
                            else
                            {
                                throw new Exception("新客成交率有参数列为空，请检查表格数据！");
                            }
                            if (worksheet.Cells[x, 8].Value != null)
                            {
                                addDto.NewCustomerAchievement = Convert.ToDecimal(worksheet.Cells[x, 8].Value.ToString());
                            }
                            else
                            {
                                throw new Exception("新客业绩有参数列为空，请检查表格数据！");
                            }
                            if (worksheet.Cells[x, 9].Value != null)
                            {
                                addDto.NewCustomerUnitPrice = Convert.ToDecimal(worksheet.Cells[x, 9].Value.ToString());
                            }
                            else
                            {
                                throw new Exception("新客客单价有参数列为空，请检查表格数据！");
                            }
                            if (worksheet.Cells[x, 10].Value != null)
                            {
                                addDto.NewCustomerAchievementRate = Convert.ToDecimal(worksheet.Cells[x, 10].Value.ToString());
                            }
                            else
                            {
                                throw new Exception("新客业绩占比有参数列为空，请检查表格数据！");
                            }
                            if (worksheet.Cells[x, 11].Value != null)
                            {
                                addDto.OldCustomerAcceptNum = Convert.ToInt32(worksheet.Cells[x, 11].Value.ToString());
                            }
                            else
                            {
                                throw new Exception("老客接诊人数有参数列为空，请检查表格数据！");
                            }
                            if (worksheet.Cells[x, 12].Value != null)
                            {
                                addDto.OldCustomerDealNum = Convert.ToInt32(worksheet.Cells[x, 12].Value.ToString());
                            }
                            else
                            {
                                throw new Exception("老客成交人数有参数列为空，请检查表格数据！");
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
                                addDto.OldCustomerAchievement = Convert.ToDecimal(worksheet.Cells[x, 14].Value.ToString());
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
                                addDto.TotalPerformance = Convert.ToDecimal(worksheet.Cells[x, 17].Value.ToString());
                            }
                            else
                            {
                                throw new Exception("总业绩有参数列为空，请检查表格数据！");
                            }
                            await hospitalDoctorOperationDataService.AddAsync(addDto);
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
