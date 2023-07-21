
using Fx.Amiya.Background.Api.Vo.CustomerHospitalConsume;
using Fx.Amiya.Background.Api.Vo.OrderCheck;
using Fx.Amiya.Dto.CustomerHospitalConsume;
using Fx.Amiya.Dto.TmallOrder;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Infrastructure;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class CustomerHospitalConsumeController : ControllerBase
    {
        private ICustomerHospitalConsumeService customerHospitalConsumeService;
        private IHttpContextAccessor httpContextAccessor;
        private IHospitalInfoService _hospitalInfoService;
        public CustomerHospitalConsumeController(ICustomerHospitalConsumeService customerHospitalConsumeService,
            IHttpContextAccessor httpContextAccessor,
            IHospitalInfoService hospitalInfoService)
        {
            this.customerHospitalConsumeService = customerHospitalConsumeService;
            this.httpContextAccessor = httpContextAccessor;
            _hospitalInfoService = hospitalInfoService;
        }


        /// <summary>
        /// 医院添加客户在医院消费信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        [FxTenantAuthorize]
        public async Task<ResultData> AddAsync(AddCustomerHospitalConsumeVo addVo)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaHospitalEmployeeIdentity;
            int hospitalId = employee.HospitalId;

            AddCustomerHospitalConsumeDto addDto = new AddCustomerHospitalConsumeDto();
            addDto.Phone = addVo.EncryptPhone;
            addDto.ItemName = addVo.ItemName;
            addDto.Price = addVo.Price;
            addDto.ConsumeType = addVo.ConsumeType;
            addDto.NickName = addVo.NickName;
            addDto.IsAddedOrder = addVo.IsAddedOrder;
            addDto.OrderId = addVo.OrderId;
            addDto.WriteOffDate = addVo.WriteOffDate;
            addDto.BuyAgainType = addVo.BuyAgainType;
            addDto.BuyAgainTime = addVo.BuyAgainTime;
            addDto.HasBuyagainEvidence = addVo.HasBuyagainEvidence;
            addDto.BuyagainEvidencePic = addVo.BuyagainEvidencePic;
            addDto.CheckToHospitalPic = addVo.CheckToHospitalPic;
            addDto.PersonTime = addVo.PersonTime;
            addDto.Remark = addVo.Remark;
            addDto.Channel = addVo.Channel;
            await customerHospitalConsumeService.AddAsync(addDto, hospitalId);
            return ResultData.Success();
        }

        /// <summary>
        /// 获取升单类型
        /// </summary>
        /// <returns></returns>
        [HttpGet("appTypeList")]
        public ResultData<List<BuyAgainTypeVo>> GeBuyAgainTypeList()
        {
            var orderAppTypes = from d in customerHospitalConsumeService.GetBuyAgainTypeList()
                                select new BuyAgainTypeVo
                                {
                                    Type = d.Type,
                                    TypeText = d.TypeText
                                };
            return ResultData<List<BuyAgainTypeVo>>.Success().AddData("buyAgainType", orderAppTypes.ToList());
        }


        /// <summary>
        /// 获取升单渠道
        /// </summary>
        /// <returns></returns>
        [HttpGet("appChannelList")]
        public ResultData<List<ChannelTypeVo>> GeChannelTypeList()
        {
            var orderAppTypes = from d in customerHospitalConsumeService.GetChannelTypeList()
                                select new ChannelTypeVo
                                {
                                    Type = d.Type,
                                    TypeText = d.TypeText
                                };
            return ResultData<List<ChannelTypeVo>>.Success().AddData("channelType", orderAppTypes.ToList());
        }
        /// <summary>
        /// 客服添加客户在医院消费信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("customerManageAdd")]
        [FxInternalAuthorize]
        public async Task<ResultData> CustomerManageAddAsync(CustomerManageAddconsumeVo addVo)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int empId = Convert.ToInt32(employee.Id);
            AddCustomerHospitalConsumeDto addDto = new AddCustomerHospitalConsumeDto();
            addDto.Phone = addVo.Phone;
            addDto.ItemName = addVo.ItemName;
            addDto.Price = addVo.Price;
            addDto.LiveAnchorId = addVo.LiveAnchorId;
            addDto.ConsumeType = addVo.ConsumeType;
            addDto.EmployeeId = empId;
            addDto.NickName = addVo.NickName;
            addDto.IsAddedOrder = addVo.IsAddedOrder;
            addDto.OrderId = addVo.OrderId;
            addDto.OtherContentPlatFormOrderId = addVo.OtherContentPlatFormOrderId;
            addDto.WriteOffDate = addVo.WriteOffDate;
            addDto.IsCconsultationCard = addVo.IsCconsultationCard;
            addDto.BuyAgainType = addVo.BuyAgainType;
            addDto.IsSelfLiving = addVo.IsSelfLiving;
            addDto.BuyAgainTime = addVo.BuyAgainTime;
            addDto.HasBuyagainEvidence = addVo.HasBuyagainEvidence;
            addDto.BuyagainEvidencePic = addVo.BuyagainEvidencePic;
            addDto.IsCheckToHospital = addVo.IsCheckToHospital;
            addDto.Channel = addVo.Channel;
            addDto.CheckToHospitalPic = addVo.CheckToHospitalPic;
            addDto.PersonTime = addVo.PersonTime;
            addDto.Remark = addVo.Remark;
            addDto.IsReceiveAdditionalPurchase = addVo.IsReceiveAdditionalPurchase;
            await customerHospitalConsumeService.CustomerManageAddAsync(addDto, addVo.HospitalId);
            return ResultData.Success();
        }


        /// <summary>
        /// 客服修改客户在医院消费信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("customerManageUpdate")]
        [FxInternalAuthorize]
        public async Task<ResultData> CustomerManageUpdateAsync(CustomerManageUpdateconsumeVo updateVo)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int empId = Convert.ToInt32(employee.Id);

            CustomerManageUpdateconsumeDto updateDto = new CustomerManageUpdateconsumeDto();
            updateDto.Id = updateVo.Id;
            updateDto.HospitalId = updateVo.HospitalId;
            updateDto.Phone = updateVo.Phone;
            updateDto.LiveAnchorId = updateVo.LiveAnchorId;
            updateDto.ItemName = updateVo.ItemName;
            updateDto.Price = updateVo.Price;
            updateDto.ConsumeType = updateVo.ConsumeType;
            updateDto.EmployeeId = empId;
            updateDto.Channel = updateVo.Channel;
            updateDto.NickName = updateVo.NickName;
            updateDto.IsAddedOrder = updateVo.IsAddedOrder;
            updateDto.OrderId = updateVo.OrderId;
            updateDto.OtherContentPlatFormOrderId = updateVo.OtherContentPlatFormOrderId;
            updateDto.WriteOffDate = updateVo.WriteOffDate;
            updateDto.IsCconsultationCard = updateVo.IsCconsultationCard;
            updateDto.BuyAgainType = updateVo.BuyAgainType;
            updateDto.IsSelfLiving = updateVo.IsSelfLiving;
            updateDto.BuyAgainTime = updateVo.BuyAgainTime;
            updateDto.HasBuyagainEvidence = updateVo.HasBuyagainEvidence;
            updateDto.BuyagainEvidencePic = updateVo.BuyagainEvidencePic;
            updateDto.IsCheckToHospital = updateVo.IsCheckToHospital;
            updateDto.CheckToHospitalPic = updateVo.CheckToHospitalPic;
            updateDto.PersonTime = updateVo.PersonTime;
            updateDto.IsReceiveAdditionalPurchase = updateVo.IsReceiveAdditionalPurchase;
            updateDto.Remark = updateVo.Remark;
            await customerHospitalConsumeService.CustomerManageUpdateAsync(updateDto);
            return ResultData.Success();
        }

        /// <summary>
        /// 客服确认客户在医院消费信息
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        [HttpGet("customerServiceCheck")]
        [FxInternalAuthorize]
        public async Task<ResultData> CustomerServiceCheckAsync(int id)
        {
            await customerHospitalConsumeService.CustomerServiceCheckAsync(id);
            return ResultData.Success();
        }

        /// <summary>
        /// 审核客户在医院消费信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("customerManageCheck")]
        [FxInternalAuthorize]
        public async Task<ResultData> CustomerManageCheckAsync(CustomerManageCheckconsumeVo updateVo)
        {
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int empId = Convert.ToInt32(employee.Id);
                if (employee.PositionId != "1")
                {
                    if (employee.PositionId != "13")
                    {
                        throw new Exception("只有管理员与财务才可进行升单审核！");
                    }
                }
                CustomerManageCheckconsumeDto checkDto = new CustomerManageCheckconsumeDto();
                checkDto.Id = updateVo.Id;
                checkDto.CheckState = updateVo.CheckState;
                checkDto.CheckBuyAgainPrice = updateVo.CheckBuyAgainPrice;
                checkDto.CheckSettlePrice = updateVo.CheckSettlePrice;
                checkDto.CheckEmpId = empId;
                checkDto.CheckRemark = updateVo.CheckRemark;
                checkDto.CheckPicture = updateVo.CheckPicture;
                checkDto.ReconciliationDocumentsId = updateVo.ReconciliationDocumentsId;
                checkDto.CustomerServiceSettlePrice = updateVo.CustomerServiceSettlePrice;
                await customerHospitalConsumeService.CustomerManageCheckAsync(checkDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 订单审核后回款
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("returnBackOrder")]
        [FxInternalAuthorize]
        public async Task<ResultData> ReturnBackOrderAsync(ReturnBackOrderVo updateVo)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            if (employee.PositionId != "1")
            {
                if (employee.PositionId != "13")
                {
                    throw new Exception("只有管理员与财务才可进行订单回款！");
                }
            }
            //修改订单
            ReturnBackOrderDto updateDto = new ReturnBackOrderDto();
            updateDto.OrderId = updateVo.OrderId;
            updateDto.ReturnBackPrice = updateVo.ReturnBackPrice;
            updateDto.ReturnBackDate = updateVo.ReturnBackDate;
            await customerHospitalConsumeService.ReturnBackOrderAsync(updateDto);
            return ResultData.Success();
        }

        /// <summary>
        /// 导入消费追踪信息
        /// </summary>
        /// <returns></returns>
        [HttpPut("customerManageInPort")]
        [FxInternalAuthorize]
        public async Task<ResultData> CustomerManageImportAsync(IFormFile file)
        {
            try
            {
                if (file == null || file.Length <= 0)
                    throw new Exception("请检查文件是否存在");

                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int empId = Convert.ToInt32(employee.Id);

                List<ImportCustomerHospitalConsumeDto> importList = new List<ImportCustomerHospitalConsumeDto>();
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);//取到文件流                    
                    using (ExcelPackage package = new ExcelPackage(stream))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets["sheet1"];
                        //获取表格的列数和行数
                        int rowCount = worksheet.Dimension.Rows;
                        for (int x = 2; x <= rowCount; x++)
                        {
                            ImportCustomerHospitalConsumeDto addDto = new ImportCustomerHospitalConsumeDto();
                            addDto.CreateDate = DateTime.Now;
                            if (!string.IsNullOrEmpty(worksheet.Cells[x, 1].Value.ToString()))
                            {
                                var hospitalInfo = await _hospitalInfoService.GetBaseByNameAsync(worksheet.Cells[x, 1].Value.ToString());
                                if (hospitalInfo == null)
                                {
                                    addDto.HospitalId = 0;
                                }
                                else
                                {
                                    addDto.HospitalId = hospitalInfo.Id;
                                }
                            }
                            addDto.Price = Convert.ToDecimal(worksheet.Cells[x, 2].Value.ToString());
                            if (worksheet.Cells[x, 3].Value != null)
                            {
                                addDto.Phone = worksheet.Cells[x, 3].Value.ToString();
                            }
                            else
                            {
                                addDto.Phone = "未知客户手机号";
                            }
                            if (worksheet.Cells[x, 4].Value != null)
                            {
                                addDto.NickName = worksheet.Cells[x, 4].Value.ToString();
                            }
                            else
                            {
                                addDto.NickName = "未知客户昵称";
                            }
                            addDto.PersonTime = Convert.ToInt16(worksheet.Cells[x, 5].Value.ToString());
                            if (worksheet.Cells[x, 6].Value != null)
                            {
                                addDto.IsAddedOrder = true;
                                addDto.OrderId = worksheet.Cells[x, 6].Value.ToString();
                            }
                            if (worksheet.Cells[x, 7].Value != null)
                            {
                                string writeDate = worksheet.Cells[x, 7].Value.ToString();
                                string WriteOffDate = writeDate.Substring(0, 4);
                                WriteOffDate += "-";
                                WriteOffDate += writeDate.Substring(4, 2);
                                WriteOffDate += "-";
                                WriteOffDate += writeDate.Substring(6, 2);
                                addDto.WriteOffDate = Convert.ToDateTime(WriteOffDate);
                            }
                            if (worksheet.Cells[x, 8].Value != null)
                            {
                                addDto.IsSelfLiving = worksheet.Cells[x, 8].Value.ToString() == "是" ? true : false;
                            }
                            string buyAgainTime = worksheet.Cells[x, 9].Value.ToString();
                            if (!string.IsNullOrEmpty(buyAgainTime))
                            {
                                string buyAgainDate = buyAgainTime.Substring(0, 4);
                                buyAgainDate += "-";
                                buyAgainDate += buyAgainTime.Substring(4, 2);
                                buyAgainDate += "-";
                                buyAgainDate += buyAgainTime.Substring(6, 2);
                                addDto.BuyAgainTime = Convert.ToDateTime(buyAgainDate);
                            }
                            if (worksheet.Cells[x, 10].Value.ToString() == "再消费")
                            {
                                addDto.ConsumeType = 1;
                            }

                            addDto.CheckBuyAgainPrice = Convert.ToDecimal(worksheet.Cells[x, 11].Value.ToString());
                            addDto.CheckSettlePrice = Convert.ToDecimal(worksheet.Cells[x, 12].Value.ToString());
                            string checkTime = worksheet.Cells[x, 13].Value.ToString();
                            if (!string.IsNullOrEmpty(checkTime))
                            {
                                string checkDate = checkTime.Substring(0, 4);
                                checkDate += "-";
                                checkDate += checkTime.Substring(4, 2);
                                checkDate += "-";
                                checkDate += checkTime.Substring(6, 2);
                                addDto.CheckDate = Convert.ToDateTime(checkDate);
                            }
                            if (worksheet.Cells[x, 14].Value != null)
                            {
                                addDto.Remark = worksheet.Cells[x, 14].Value.ToString();
                            }
                            else
                            {
                                addDto.Remark = "";
                            }
                            switch (worksheet.Cells[x, 15].Value.ToString())
                            {
                                case "0.05":
                                    addDto.BuyAgainType = 0;
                                    break;
                                case "0.3":
                                    addDto.BuyAgainType = 1;
                                    break;
                                case "0.35":
                                    addDto.BuyAgainType = 2;
                                    break;
                                case "0.1":
                                    addDto.BuyAgainType = 3;
                                    break;
                                case "0.15":
                                    addDto.BuyAgainType = 4;
                                    break;
                                case "0.2":
                                    addDto.BuyAgainType = 5;
                                    break;
                                case "0.5":
                                    addDto.BuyAgainType = 6;
                                    break;
                            }
                            addDto.EmployeeId = empId;
                            importList.Add(addDto);
                        }
                    }
                }
                await customerHospitalConsumeService.CustomerManageImportAsync(importList);
                return ResultData.Success();
            }
            catch (Exception err)
            {
                throw new Exception();
            }

        }

        /// <summary>
        /// 根据编号获取消费追踪信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData<CustomerManageUpdateconsumeVo>> GetByIdAsync(int id)
        {
            var result = await customerHospitalConsumeService.GetByIdAsync(id);
            CustomerManageUpdateconsumeVo customerManageUpdateConsume = new CustomerManageUpdateconsumeVo();
            customerManageUpdateConsume.Id = result.Id;
            customerManageUpdateConsume.ConsumeId = result.ConsumeId;
            customerManageUpdateConsume.HospitalName = result.HospitalName;
            customerManageUpdateConsume.HospitalId = result.HospitalId;
            customerManageUpdateConsume.Phone = result.Phone;
            customerManageUpdateConsume.Channel = result.Channel;
            customerManageUpdateConsume.LiveAnchorId = result.LiveAnchorId;
            customerManageUpdateConsume.CheckDate = result.CheckDate;
            customerManageUpdateConsume.CheckByEmpName = result.CheckByEmpName;
            customerManageUpdateConsume.CheckBuyAgainPrice = result.CheckBuyAgainPrice;
            customerManageUpdateConsume.CheckState = result.CheckState;
            customerManageUpdateConsume.IsReturnBackPrice = result.IsReturnBackPrice;
            customerManageUpdateConsume.ReturnBackDate = result.ReturnBackDate;
            customerManageUpdateConsume.ReturnBackPrice = result.ReturnBackPrice;
            customerManageUpdateConsume.BuyAgainTypeText = result.BuyAgainTypeText;
            customerManageUpdateConsume.ChannelText = result.ChannelText;
            customerManageUpdateConsume.CreateDate = result.CreateDate;
            customerManageUpdateConsume.LiveAnchorName = result.LiveAnchorName;
            customerManageUpdateConsume.ItemName = result.ItemName;
            customerManageUpdateConsume.Price = result.Price;
            customerManageUpdateConsume.ConsumeType = result.ConsumeType;
            customerManageUpdateConsume.CheckSettlePrice = result.CheckSettlePrice;
            customerManageUpdateConsume.NickName = result.NickName;
            customerManageUpdateConsume.IsAddedOrder = result.IsAddedOrder;
            customerManageUpdateConsume.OtherContentPlatFormOrderId = result.OtherContentPlatFormOrderId;
            customerManageUpdateConsume.OrderId = result.OrderId;
            customerManageUpdateConsume.WriteOffDate = result.WriteOffDate;
            customerManageUpdateConsume.IsCconsultationCard = result.IsCconsultationCard;
            customerManageUpdateConsume.BuyAgainType = result.BuyAgainType;
            customerManageUpdateConsume.IsSelfLiving = result.IsSelfLiving;
            customerManageUpdateConsume.BuyAgainTime = result.BuyAgainTime;
            customerManageUpdateConsume.HasBuyagainEvidence = result.HasBuyagainEvidence;
            customerManageUpdateConsume.BuyagainEvidencePic = result.BuyagainEvidencePic;
            customerManageUpdateConsume.IsCheckToHospital = result.IsCheckToHospital;
            customerManageUpdateConsume.CheckToHospitalPic = result.CheckToHospitalPic;
            customerManageUpdateConsume.PersonTime = result.PersonTime;
            customerManageUpdateConsume.Remark = result.Remark;
            customerManageUpdateConsume.IsReceiveAdditionalPurchase = result.IsReceiveAdditionalPurchase;
            customerManageUpdateConsume.IsConfirmOrder = result.IsConfirmOrder;
            customerManageUpdateConsume.IsCreateBill = result.IsCreateBill;
            customerManageUpdateConsume.CreateBillCompany = result.BelongCompanyName;

            return ResultData<CustomerManageUpdateconsumeVo>.Success().AddData("CustomerManageUpdateconsume", customerManageUpdateConsume);
        }
        /// <summary>
        /// 删除消费追踪
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        [FxInternalAuthorize]
        public async Task<ResultData> CustomerManageDeleteteAsync([Required] int Id)
        {
            int enployeeId = 0;
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            enployeeId = Convert.ToInt32(employee.Id);
            await customerHospitalConsumeService.CustomerManageDeleteAsync(Id, enployeeId);
            return ResultData.Success();
        }


        /// <summary>
        /// 根据加密电话获取客户消费追踪列表
        /// </summary>
        /// <param name="encryptPhone"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listByEncryptPhone")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<FxPageInfo<CustomerHospitalConsumeVo>>> GetListByEncryptPhoneAsync([Required(ErrorMessage = "加密电话不能为空")] string encryptPhone, int pageNum, int pageSize)
        {
            int? hospitalId = null;
            if (httpContextAccessor.HttpContext.User is FxAmiyaHospitalEmployeeIdentity employee)
            {
                hospitalId = employee.HospitalId;
            }

            var q = await customerHospitalConsumeService.GetListByEncryptPhoneAsync(encryptPhone, hospitalId, pageNum, pageSize);
            var consumes = from d in q.List
                           select new CustomerHospitalConsumeVo
                           {
                               Id = d.Id,
                               ConsumeId = d.ConsumeId,
                               HospitalId = d.HospitalId,
                               HospitalName = d.HospitalName,
                               Phone = d.Phone,
                               EncryptPhone = d.EncryptPhone,
                               ItemName = d.ItemName,
                               Channel = d.ChannelType,
                               Price = d.Price,
                               CreateDate = d.CreateDate,
                               ConsumeType = d.ConsumeType,
                               ConsumeTypeText = d.ConsumeTypeText,
                               NickName = d.NickName,
                               IsAddedOrder = d.IsAddedOrder == true ? "是" : "否",
                               OrderId = d.OrderId,
                               WriteOffDate = d.WriteOffDate,
                               IsCconsultationCard = d.IsCconsultationCard == true ? "是" : "否",
                               BuyAgainType = d.BuyAgainType,
                               BuyAgainTypeText = d.BuyAgainTypeText,
                               IsSelfLiving = d.IsSelfLiving == true ? "是" : "否",
                               BuyAgainTime = d.BuyAgainTime,
                               HasBuyagainEvidence = d.HasBuyagainEvidence == true ? "是" : "否",
                               BuyagainEvidencePic = d.BuyagainEvidencePic,
                               IsCheckToHospital = d.IsCheckToHospital == true ? "是" : "否",
                               CheckToHospitalPic = d.CheckToHospitalPic,
                               PersonTime = d.PersonTime,
                               IsReceiveAdditionalPurchase = d.IsReceiveAdditionalPurchase == true ? "是" : "否",
                               Remark = d.Remark
                           };

            FxPageInfo<CustomerHospitalConsumeVo> pageInfo = new FxPageInfo<CustomerHospitalConsumeVo>();
            pageInfo.TotalCount = q.TotalCount;
            pageInfo.List = consumes;
            return ResultData<FxPageInfo<CustomerHospitalConsumeVo>>.Success().AddData("customerHospitalConsume", pageInfo);
        }


        /// <summary>
        /// 获取审核情况（下拉框使用）
        /// </summary>
        /// <returns></returns>
        [HttpGet("getCheckStateList")]
        [FxInternalAuthorize]
        public ResultData<List<CheckStateTypeVo>> GetCheckStateList()
        {
            var orderNatures = from d in customerHospitalConsumeService.GetCheckStateType()
                               select new CheckStateTypeVo
                               {
                                   Id = d.Id,
                                   Name = d.Name
                               };
            return ResultData<List<CheckStateTypeVo>>.Success().AddData("checkStateList", orderNatures.ToList());
        }

        /// <summary>
        /// 获取客户消费追踪列表
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="channel">渠道（0：医院，1：天猫，2抖音，3抖音代运营）</param>
        /// <param name="liveAnchorId">主播IP编号</param>
        /// <param name="isConfirmOrder">客服是否确认</param>
        /// <param name="consumeStartDate">升单开始时间（可空）</param>
        /// <param name="consumeEndDate">升单结束时间（可空）</param>
        /// <param name="keyword"></param>
        /// <param name="consumeType">消费类型：0=当天其他消费，1=再消费</param>
        /// <param name="startDate"></param>
        /// <param name="buyAgainType">升单类型</param>
        /// <param name="addedBy">跟进人员，-1查询所有，0查询医院添加</param>
        /// <param name="endDate"></param>
        /// <param name="checkState">审核状态（-1查询全部）</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<CustomerHospitalConsumeVo>>> GetListAsync(int? hospitalId, int? channel, int? liveAnchorId, bool? isConfirmOrder, int? buyAgainType, DateTime? consumeStartDate, DateTime? consumeEndDate, string keyword, int? consumeType, DateTime? startDate, DateTime? endDate, int checkState, int? addedBy, int pageNum, int pageSize, bool? dataFrom)
        {
            int? employeeId = null;
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            employeeId = Convert.ToInt32(employee.Id);
            var q = await customerHospitalConsumeService.GetListAsync(hospitalId, channel, liveAnchorId, buyAgainType, employeeId, isConfirmOrder, consumeStartDate, consumeEndDate, keyword, consumeType, startDate, endDate, checkState, addedBy, pageNum, pageSize, dataFrom);
            var consumes = from d in q.List
                           select new CustomerHospitalConsumeVo
                           {
                               Id = d.Id,
                               HospitalId = d.HospitalId,
                               HospitalName = d.HospitalName,
                               Phone = d.Phone,
                               EncryptPhone = d.EncryptPhone,
                               Channel = d.ChannelType,
                               Name = d.Name,
                               ConsumeId = d.ConsumeId,
                               Age = d.Age,
                               IsConfirmOrder = d.IsConfirmOrder,
                               Sex = d.Sex,
                               IsReturnBackPrice = d.IsReturnBackPrice,
                               ReturnBackDate = d.ReturnBackDate,
                               ReturnBackPrice = d.ReturnBackPrice,
                               ItemName = d.ItemName,
                               Price = d.Price,
                               CreateDate = d.CreateDate,
                               ConsumeType = d.ConsumeType,
                               ConsumeTypeText = d.ConsumeTypeText,
                               EmployeeName = d.EmpolyeeName,
                               NickName = d.NickName,
                               IsAddedOrder = d.IsAddedOrder == true ? "是" : "否",
                               OrderId = d.OrderId,
                               WriteOffDate = d.WriteOffDate,
                               IsCconsultationCard = d.IsCconsultationCard == true ? "是" : "否",
                               BuyAgainType = d.BuyAgainType,
                               BuyAgainTypeText = d.BuyAgainTypeText,
                               IsSelfLiving = d.IsSelfLiving == true ? "是" : "否",
                               BuyAgainTime = d.BuyAgainTime,
                               HasBuyagainEvidence = d.HasBuyagainEvidence == true ? "是" : "否",
                               BuyagainEvidencePic = d.BuyagainEvidencePic,
                               IsCheckToHospital = d.IsCheckToHospital == true ? "是" : "否",
                               CheckToHospitalPic = d.CheckToHospitalPic,
                               PersonTime = d.PersonTime,
                               IsReceiveAdditionalPurchase = d.IsReceiveAdditionalPurchase == true ? "是" : "否",
                               CheckBuyAgainPrice = d.CheckBuyAgainPrice,
                               CheckSettlePrice = d.CheckSettlePrice,
                               CheckDate = d.CheckDate,
                               CheckByEmpName = d.CheckByEmpName,
                               CheckState = d.CheckState,
                               Remark = d.Remark,
                               CheckRemark = d.CheckRemark,
                               LiveAnchorName = d.LiveAnchorName,
                               OtherContentPlatFormOrderId = d.OtherContentPlatFormOrderId,
                               ReconciliationDocumentsId = d.ReconciliationDocumentsId,
                           };
            FxPageInfo<CustomerHospitalConsumeVo> pageInfo = new FxPageInfo<CustomerHospitalConsumeVo>();
            pageInfo.TotalCount = q.TotalCount;
            pageInfo.List = consumes;
            return ResultData<FxPageInfo<CustomerHospitalConsumeVo>>.Success().AddData("customerHospitalConsumes", pageInfo);
        }


        /// <summary>
        /// 根据对账单编号获取升单信息
        /// </summary>
        /// <param name="reconciliationDocumentsId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("getByReconciliationDocumentsIdList")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<CustomerHospitalConsumeVo>>> GetByReconciliationDocumentsIdListAsync(string reconciliationDocumentsId, int pageNum, int pageSize)
        {
            int? employeeId = null;
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            employeeId = Convert.ToInt32(employee.Id);
            var q = await customerHospitalConsumeService.GetByReconciliationDocumentsIdListAsync(reconciliationDocumentsId, pageNum, pageSize);
            var consumes = from d in q.List
                           select new CustomerHospitalConsumeVo
                           {
                               Id = d.Id,
                               HospitalId = d.HospitalId,
                               HospitalName = d.HospitalName,
                               Phone = d.Phone,
                               EncryptPhone = d.EncryptPhone,
                               Channel = d.ChannelType,
                               Name = d.Name,
                               ConsumeId = d.ConsumeId,
                               Age = d.Age,
                               IsConfirmOrder = d.IsConfirmOrder,
                               Sex = d.Sex,
                               IsReturnBackPrice = d.IsReturnBackPrice,
                               ReturnBackDate = d.ReturnBackDate,
                               ReturnBackPrice = d.ReturnBackPrice,
                               ItemName = d.ItemName,
                               Price = d.Price,
                               CreateDate = d.CreateDate,
                               ConsumeType = d.ConsumeType,
                               ConsumeTypeText = d.ConsumeTypeText,
                               EmployeeName = d.EmpolyeeName,
                               NickName = d.NickName,
                               IsAddedOrder = d.IsAddedOrder == true ? "是" : "否",
                               OrderId = d.OrderId,
                               WriteOffDate = d.WriteOffDate,
                               IsCconsultationCard = d.IsCconsultationCard == true ? "是" : "否",
                               BuyAgainType = d.BuyAgainType,
                               BuyAgainTypeText = d.BuyAgainTypeText,
                               IsSelfLiving = d.IsSelfLiving == true ? "是" : "否",
                               BuyAgainTime = d.BuyAgainTime,
                               HasBuyagainEvidence = d.HasBuyagainEvidence == true ? "是" : "否",
                               BuyagainEvidencePic = d.BuyagainEvidencePic,
                               IsCheckToHospital = d.IsCheckToHospital == true ? "是" : "否",
                               CheckToHospitalPic = d.CheckToHospitalPic,
                               PersonTime = d.PersonTime,
                               IsReceiveAdditionalPurchase = d.IsReceiveAdditionalPurchase == true ? "是" : "否",
                               CheckBuyAgainPrice = d.CheckBuyAgainPrice,
                               CheckSettlePrice = d.CheckSettlePrice,
                               CheckDate = d.CheckDate,
                               CheckByEmpName = d.CheckByEmpName,
                               CheckState = d.CheckState,
                               Remark = d.Remark,
                               CheckRemark = d.CheckRemark,
                               LiveAnchorName = d.LiveAnchorName,
                               OtherContentPlatFormOrderId = d.OtherContentPlatFormOrderId,
                               ReconciliationDocumentsId = d.ReconciliationDocumentsId,
                           };
            FxPageInfo<CustomerHospitalConsumeVo> pageInfo = new FxPageInfo<CustomerHospitalConsumeVo>();
            pageInfo.TotalCount = q.TotalCount;
            pageInfo.List = consumes;
            return ResultData<FxPageInfo<CustomerHospitalConsumeVo>>.Success().AddData("customerHospitalConsumes", pageInfo);
        }


        /// <summary>
        /// 根据客户手机号获取升单信息
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listByCustomerPhone")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<CustomerHospitalConsumeVo>>> GetListByPhoneAsync(string phone, int pageNum, int pageSize)
        {
            var q = await customerHospitalConsumeService.GetListByPhoneAsync(phone, pageNum, pageSize);
            var consumes = from d in q.List
                           select new CustomerHospitalConsumeVo
                           {
                               Id = d.Id,
                               HospitalId = d.HospitalId,
                               HospitalName = d.HospitalName,
                               Phone = d.Phone,
                               EncryptPhone = d.EncryptPhone,
                               Channel = d.ChannelType,
                               Name = d.Name,
                               ConsumeId = d.ConsumeId,
                               Age = d.Age,
                               IsConfirmOrder = d.IsConfirmOrder,
                               Sex = d.Sex,
                               IsReturnBackPrice = d.IsReturnBackPrice,
                               ReturnBackDate = d.ReturnBackDate,
                               ReturnBackPrice = d.ReturnBackPrice,
                               ItemName = d.ItemName,
                               Price = d.Price,
                               CreateDate = d.CreateDate,
                               ConsumeType = d.ConsumeType,
                               ConsumeTypeText = d.ConsumeTypeText,
                               EmployeeName = d.EmpolyeeName,
                               NickName = d.NickName,
                               IsAddedOrder = d.IsAddedOrder == true ? "是" : "否",
                               OrderId = d.OrderId,
                               WriteOffDate = d.WriteOffDate,
                               IsCconsultationCard = d.IsCconsultationCard == true ? "是" : "否",
                               BuyAgainType = d.BuyAgainType,
                               BuyAgainTypeText = d.BuyAgainTypeText,
                               IsSelfLiving = d.IsSelfLiving == true ? "是" : "否",
                               BuyAgainTime = d.BuyAgainTime,
                               HasBuyagainEvidence = d.HasBuyagainEvidence == true ? "是" : "否",
                               BuyagainEvidencePic = d.BuyagainEvidencePic,
                               IsCheckToHospital = d.IsCheckToHospital == true ? "是" : "否",
                               CheckToHospitalPic = d.CheckToHospitalPic,
                               PersonTime = d.PersonTime,
                               IsReceiveAdditionalPurchase = d.IsReceiveAdditionalPurchase == true ? "是" : "否",
                               CheckBuyAgainPrice = d.CheckBuyAgainPrice,
                               CheckSettlePrice = d.CheckSettlePrice,
                               CheckDate = d.CheckDate,
                               CheckByEmpName = d.CheckByEmpName,
                               CheckState = d.CheckState,
                               Remark = d.Remark,
                               CheckRemark = d.CheckRemark,
                               LiveAnchorName = d.LiveAnchorName,
                               OtherContentPlatFormOrderId = d.OtherContentPlatFormOrderId,
                               ReconciliationDocumentsId = d.ReconciliationDocumentsId,
                           };
            FxPageInfo<CustomerHospitalConsumeVo> pageInfo = new FxPageInfo<CustomerHospitalConsumeVo>();
            pageInfo.TotalCount = q.TotalCount;
            pageInfo.List = consumes;
            return ResultData<FxPageInfo<CustomerHospitalConsumeVo>>.Success().AddData("customerHospitalConsumes", pageInfo);
        }
    }
}
