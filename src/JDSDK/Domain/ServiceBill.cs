using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ServiceBill:JdObject{
      [JsonProperty("serviceId")]
public 				int

             serviceId
 { get; set; }
      [JsonProperty("applyId")]
public 				int

             applyId
 { get; set; }
      [JsonProperty("applyTime")]
public 				DateTime

             applyTime
 { get; set; }
      [JsonProperty("serviceStatus")]
public 				int

             serviceStatus
 { get; set; }
      [JsonProperty("serviceStatusName")]
public 				string

             serviceStatusName
 { get; set; }
      [JsonProperty("questionTypeCid1")]
public 				int

             questionTypeCid1
 { get; set; }
      [JsonProperty("questionTypeCid1Name")]
public 				string

             questionTypeCid1Name
 { get; set; }
      [JsonProperty("questionTypeCid2")]
public 				int

             questionTypeCid2
 { get; set; }
      [JsonProperty("questionTypeCid2Name")]
public 				string

             questionTypeCid2Name
 { get; set; }
      [JsonProperty("questionDesc")]
public 				string

             questionDesc
 { get; set; }
      [JsonProperty("questionPic")]
public 				string

             questionPic
 { get; set; }
      [JsonProperty("orderId")]
public 				long

             orderId
 { get; set; }
      [JsonProperty("orderType")]
public 				int

             orderType
 { get; set; }
      [JsonProperty("orderTypeName")]
public 				string

             orderTypeName
 { get; set; }
      [JsonProperty("updateName")]
public 				string

             updateName
 { get; set; }
      [JsonProperty("updateDate")]
public 				DateTime

             updateDate
 { get; set; }
      [JsonProperty("sysVersion")]
public 				int

             sysVersion
 { get; set; }
      [JsonProperty("hasInvoice")]
public 				bool

             hasInvoice
 { get; set; }
      [JsonProperty("needDetectionReport")]
public 				bool

             needDetectionReport
 { get; set; }
      [JsonProperty("hasPackage")]
public 				bool

             hasPackage
 { get; set; }
      [JsonProperty("customerExpect")]
public 				int

             customerExpect
 { get; set; }
      [JsonProperty("customerExpectName")]
public 				string

             customerExpectName
 { get; set; }
      [JsonProperty("refundType")]
public 				int

             refundType
 { get; set; }
      [JsonProperty("refundTypeName")]
public 				string

             refundTypeName
 { get; set; }
      [JsonProperty("pickwareType")]
public 				int

             pickwareType
 { get; set; }
      [JsonProperty("pickwareTypeName")]
public 				string

             pickwareTypeName
 { get; set; }
      [JsonProperty("expectPickwareType")]
public 				int

             expectPickwareType
 { get; set; }
      [JsonProperty("expectPickwareTypeName")]
public 				string

             expectPickwareTypeName
 { get; set; }
      [JsonProperty("returnWareType")]
public 				int

             returnWareType
 { get; set; }
      [JsonProperty("returnWareTypeName")]
public 				string

             returnWareTypeName
 { get; set; }
      [JsonProperty("companyId")]
public 				int

             companyId
 { get; set; }
      [JsonProperty("approvePin")]
public 				string

             approvePin
 { get; set; }
      [JsonProperty("approveName")]
public 				string

             approveName
 { get; set; }
      [JsonProperty("approveResult")]
public 				int

             approveResult
 { get; set; }
      [JsonProperty("approveResultName")]
public 				string

             approveResultName
 { get; set; }
      [JsonProperty("approveNotes")]
public 				string

             approveNotes
 { get; set; }
      [JsonProperty("approveDate")]
public 				DateTime

             approveDate
 { get; set; }
      [JsonProperty("approveReasonCid1")]
public 				int

             approveReasonCid1
 { get; set; }
      [JsonProperty("approveReasonCid1Name")]
public 				string

             approveReasonCid1Name
 { get; set; }
      [JsonProperty("approveReasonCid2")]
public 				int

             approveReasonCid2
 { get; set; }
      [JsonProperty("approveReasonCid2Name")]
public 				string

             approveReasonCid2Name
 { get; set; }
      [JsonProperty("processPin")]
public 				string

             processPin
 { get; set; }
      [JsonProperty("processName")]
public 				string

             processName
 { get; set; }
      [JsonProperty("processResult")]
public 				int

             processResult
 { get; set; }
      [JsonProperty("processResultName")]
public 				string

             processResultName
 { get; set; }
      [JsonProperty("processNotes")]
public 				string

             processNotes
 { get; set; }
      [JsonProperty("processDate")]
public 				DateTime

             processDate
 { get; set; }
      [JsonProperty("receiveDate")]
public 				DateTime

             receiveDate
 { get; set; }
      [JsonProperty("newOrderId")]
public 				long

             newOrderId
 { get; set; }
      [JsonProperty("invoiceCode")]
public 				string

             invoiceCode
 { get; set; }
      [JsonProperty("jdUpgradeSuggestion")]
public 				string

             jdUpgradeSuggestion
 { get; set; }
      [JsonProperty("skuType")]
public 				int

             skuType
 { get; set; }
      [JsonProperty("skuTypeName")]
public 				string

             skuTypeName
 { get; set; }
      [JsonProperty("serviceIdList")]
public 				List<string>

             serviceIdList
 { get; set; }
      [JsonProperty("customerInfo")]
public 				CustomerInfo

             customerInfo
 { get; set; }
      [JsonProperty("pickwareAddress")]
public 				AddressInfo

             pickwareAddress
 { get; set; }
      [JsonProperty("returnWareAddress")]
public 				AddressInfo

             returnWareAddress
 { get; set; }
      [JsonProperty("serviceBillDetailList")]
public 				List<string>

             serviceBillDetailList
 { get; set; }
      [JsonProperty("afsContactInfo")]
public 				ContactInfo

             afsContactInfo
 { get; set; }
      [JsonProperty("applyDetailList")]
public 				List<string>

             applyDetailList
 { get; set; }
      [JsonProperty("appointment")]
public 				Appointment

             appointment
 { get; set; }
      [JsonProperty("orderShopId")]
public 				string

             orderShopId
 { get; set; }
      [JsonProperty("returnShopId")]
public 				string

             returnShopId
 { get; set; }
      [JsonProperty("wareChangeWithApplyDTO")]
public 				WareChangeWithApplyDTO

             wareChangeWithApplyDTO
 { get; set; }
      [JsonProperty("extJsonStr")]
public 				string

             extJsonStr
 { get; set; }
      [JsonProperty("serviceCount")]
public 				int

             serviceCount
 { get; set; }
	}
}
