using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.RFMCustomerInfo.Input;
using Fx.Amiya.Background.Api.Vo.RFMCustomerInfo.Result;
using Fx.Amiya.Dto.RFMCustomerInfo;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
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
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class RFMCustomerInfoController : ControllerBase
    {
        private IRFMCustomerInfoService rFMCustomerInfoService;
        private IHttpContextAccessor _httpContextAccessor;
        private IAmiyaPositionInfoService amiyaPositionInfoService;
        public RFMCustomerInfoController(IRFMCustomerInfoService rFMCustomerInfoService, IHttpContextAccessor httpContextAccessor, IAmiyaPositionInfoService amiyaPositionInfoService)
        {
            this.rFMCustomerInfoService = rFMCustomerInfoService;
            _httpContextAccessor = httpContextAccessor;
            this.amiyaPositionInfoService = amiyaPositionInfoService;
        }
        /// <summary>
        /// 导入RFM客户信息
        /// </summary>
        /// <returns></returns>
        [HttpPut("importRFMCustomerInfo")]
        public async Task<ResultData> ReconciliationDocumentsInPortAsync(IFormFile file)
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
                    List<ImportRfmCustomerDto> addDtoList = new List<ImportRfmCustomerDto>();
                    for (int x = 2; x <= rowCount; x++)
                    {
                        ImportRfmCustomerDto addDto = new ImportRfmCustomerDto();
                        addDto.CustomerServiceName = worksheet.Cells[x, 1].Value.ToString();
                        addDto.Phone = worksheet.Cells[x, 2].Value.ToString();
                        addDto.LastDealDate = Convert.ToDateTime(worksheet.Cells[x, 3].Value);
                        addDto.HospitalName = worksheet.Cells[x, 4].Value.ToString();
                        addDto.DealPrice = Convert.ToDecimal(worksheet.Cells[x, 5].Value);
                        addDto.TotalDealPrice = Convert.ToDecimal(worksheet.Cells[x, 6].Value);
                        addDto.ConsumptionFrequency = Convert.ToInt32(worksheet.Cells[x, 7].Value);
                        addDto.RecencyDate = Convert.ToInt32(worksheet.Cells[x, 8].Value);
                        addDto.Recency = worksheet.Cells[x, 9].Value.ToString();
                        addDto.Frequency = worksheet.Cells[x, 10].Value.ToString();
                        addDto.Monetary = worksheet.Cells[x, 11].Value.ToString();
                        addDto.RFMTag = worksheet.Cells[x, 13].Value.ToString();
                        addDto.LiveAnchorWechatNo = Convert.ToString(worksheet.Cells[x, 14].Value);
                        addDtoList.Add(addDto);
                    }
                    await rFMCustomerInfoService.ImportRFMCustomerInfoAsync(addDtoList);
                }
            }
            return ResultData.Success();


        }
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="leave">级别</param>
        /// <returns></returns>
        [HttpGet("getListByPage")]
        public async Task<ResultData<FxPageInfo<RFMCustomerInfoVo>>> GetListByPageAsync(string keyword,int? leave, int pageNum, int pageSize)
        {
            var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int? employeeId = null;
            var position =await amiyaPositionInfoService.GetByIdAsync(Convert.ToInt32(employee.PositionId));
            if (employee.IsCustomerService && !position.IsDirector)
            {
                employeeId = Convert.ToInt32(employee.Id);
            }
            FxPageInfo<RFMCustomerInfoVo> fxPageInfo = new FxPageInfo<RFMCustomerInfoVo>();
            var list = await rFMCustomerInfoService.GetListByPageAsync(employeeId,leave,keyword, pageNum, pageSize);
            fxPageInfo.TotalCount = list.TotalCount;
            fxPageInfo.List = list.List.Select(e => new RFMCustomerInfoVo
            {
                Id = e.Id,
                Phone = e.Phone,
                EncryptPhone = e.EncryptPhone,
                CustomerServiceName = e.CustomerServiceName,
                LastDealDate = e.LastDealDate,
                HospitalName = e.HospitalName,
                DealPrice = e.DealPrice,
                TotalDealPrice = e.TotalDealPrice,
                ConsumptionFrequency = e.ConsumptionFrequency,
                RecencyDate = e.RecencyDate,
                Recency = e.Recency,
                Frequency = e.Frequency,
                Monetary = e.Monetary,
                RFMTag = e.RFMTag,
                RFMTagText = e.RFMTagText,
                LiveAnchorWechatNo = e.LiveAnchorWechatNo
            }).ToList();
            return ResultData<FxPageInfo<RFMCustomerInfoVo>>.Success().AddData("list", fxPageInfo);
        }

        /// <summary>
        /// 添加rfm客户
        /// </summary>
        /// <param name="addHealthValueVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddRFMCustomerInfoVo addVo)
        {
            AddRFMCustomerInfoDto addDto = new AddRFMCustomerInfoDto();
            addDto.Phone = addVo.Phone;
            addDto.CustomerServiceId = addVo.CustomerServiceId;
            addDto.LastDealDate = addVo.LastDealDate;
            addDto.HospitalId = addVo.HospitalId;
            addDto.DealPrice = addVo.DealPrice;
            addDto.TotalDealPrice = addVo.TotalDealPrice;
            addDto.ConsumptionFrequency = addVo.ConsumptionFrequency;
            addDto.RecencyDate = addVo.RecencyDate;
            addDto.Recency = addVo.Recency;
            addDto.Frequency = addVo.Frequency;
            addDto.Monetary = addVo.Monetary;
            addDto.RFMTag = addVo.RFMTag;
            addDto.LiveAnchorWechatNo = addVo.LiveAnchorWechatNoId;
            await rFMCustomerInfoService.AddAsync(addDto);
            return ResultData.Success();
        }

        /// <summary>
        /// 修改rfm客户信息
        /// </summary>
        /// <param name="updateHealthValueVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateRFMCustomerInfoVo updateVo)
        {
            UpdateRFMCustomerInfoDto updateDto = new UpdateRFMCustomerInfoDto();
            updateDto.Id = updateVo.Id;
            updateDto.Phone = updateVo.Phone;
            updateDto.CustomerServiceId = updateVo.CustomerServiceId;
            updateDto.LastDealDate = updateVo.LastDealDate;
            updateDto.HospitalId = updateVo.HospitalId;
            updateDto.DealPrice = updateVo.DealPrice;
            updateDto.TotalDealPrice = updateVo.TotalDealPrice;
            updateDto.ConsumptionFrequency = updateVo.ConsumptionFrequency;
            updateDto.RecencyDate = updateVo.RecencyDate;
            updateDto.Recency = updateVo.Recency;
            updateDto.Frequency = updateVo.Frequency;
            updateDto.Monetary = updateVo.Monetary;
            updateDto.RFMTag = updateVo.RFMTag;
            updateDto.LiveAnchorWechatNo = updateVo.LiveAnchorWechatNoId;
            await rFMCustomerInfoService.UpdateAsync(updateDto);
            return ResultData.Success();
        }
        /// <summary>
        /// 删除rfm客户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ResultData> DeleteAsync(string id)
        {
            await rFMCustomerInfoService.DeleteAsync(id);
            return ResultData.Success();
        }
        /// <summary>
        /// 根据id获取rfm客户详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getById/{id}")]
        public async Task<ResultData<RFMCustomerInfoVo>> GetByIdAsync(string id)
        {
            var result = await rFMCustomerInfoService.GetByIdAsync(id);
            RFMCustomerInfoVo info = new RFMCustomerInfoVo();
            info.Id = result.Id;
            info.Phone = result.Phone;
            info.CustomerServiceId = result.CustomerServiceId;
            info.CustomerServiceName = result.CustomerServiceName;
            info.LastDealDate = result.LastDealDate;
            info.HospitalId = result.HospitalId;
            info.HospitalName = result.HospitalName;
            info.DealPrice = result.DealPrice;
            info.TotalDealPrice = result.TotalDealPrice;
            info.ConsumptionFrequency = result.ConsumptionFrequency;
            info.RecencyDate = result.RecencyDate;
            info.RecencyLeave = result.RecencyLeave;
            info.Recency = result.Recency;
            info.FrequencyLeave = result.FrequencyLeave;
            info.Frequency = result.Frequency;
            info.MonetaryLeave = result.MonetaryLeave;
            info.Monetary = result.Monetary;
            info.RFMTagLeave = result.RFMTagLeave;
            info.RFMTag = result.RFMTag;
            info.RFMTagText = result.RFMTagText;
            info.LiveAnchorWechatNo = result.LiveAnchorWechatNo;
            info.LiveAnchorWechatNoId = result.LiveAnchorWechatNoId;
            return ResultData<RFMCustomerInfoVo>.Success().AddData("info", info);
        }
        /// <summary>
        /// rfm值名称列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("rfmvalueNameList")]
        public async Task<ResultData<List<BaseIdAndNameVo<int>>>> GetRFMValueNameListAsync()
        {
            var nameList = rFMCustomerInfoService.GetRFMValueText();
            var result = nameList.Select(e => new BaseIdAndNameVo<int>
            {
                Id = Convert.ToInt32(e.Key),
                Name = e.Value
            }).ToList();
            return ResultData<List<BaseIdAndNameVo<int>>>.Success().AddData("nameList", result);

        }
        /// <summary>
        /// rfm标签名称列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("rfmtagNameList")]
        public async Task<ResultData<List<BaseIdAndNameVo<int>>>> GetRFMTagNameListAsync()
        {
            var nameList = rFMCustomerInfoService.GetRFMTagText();
            var result = nameList.Select(e => new BaseIdAndNameVo<int>
            {
                Id = Convert.ToInt32(e.Key),
                Name = e.Value
            }).ToList();
            return ResultData<List<BaseIdAndNameVo<int>>>.Success().AddData("nameList", result);

        }
    }
}
