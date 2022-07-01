using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ServiceDetaiExport:JdObject{
      [JsonProperty("afsApplyId")]
public 				int

             afsApplyId
 { get; set; }
      [JsonProperty("afsServiceId")]
public 				int

             afsServiceId
 { get; set; }
      [JsonProperty("afsApplyTime")]
public 				DateTime

             afsApplyTime
 { get; set; }
      [JsonProperty("orderId")]
public 				long

             orderId
 { get; set; }
      [JsonProperty("isHasInvoice")]
public 				int

             isHasInvoice
 { get; set; }
      [JsonProperty("isNeedDetectionReport")]
public 				int

             isNeedDetectionReport
 { get; set; }
      [JsonProperty("isHasPackage")]
public 				int

             isHasPackage
 { get; set; }
      [JsonProperty("customerExpect")]
public 				int

             customerExpect
 { get; set; }
      [JsonProperty("questionPic")]
public 				string

             questionPic
 { get; set; }
      [JsonProperty("afsServiceStep")]
public 				int

             afsServiceStep
 { get; set; }
      [JsonProperty("afsServiceStepName")]
public 				string

             afsServiceStepName
 { get; set; }
      [JsonProperty("approveNotes")]
public 				string

             approveNotes
 { get; set; }
      [JsonProperty("questionDesc")]
public 				string

             questionDesc
 { get; set; }
      [JsonProperty("approvedResult")]
public 				int

             approvedResult
 { get; set; }
      [JsonProperty("approvedResultName")]
public 				string

             approvedResultName
 { get; set; }
      [JsonProperty("processResult")]
public 				int

             processResult
 { get; set; }
      [JsonProperty("processResultName")]
public 				string

             processResultName
 { get; set; }
      [JsonProperty("afsServiceStatus")]
public 				int

             afsServiceStatus
 { get; set; }
      [JsonProperty("afsServiceStatusName")]
public 				string

             afsServiceStatusName
 { get; set; }
      [JsonProperty("serviceCustomerInfoExport")]
public 				ServiceCustomerInfoExport

             serviceCustomerInfoExport
 { get; set; }
      [JsonProperty("doorPickwareAddressInfoExport")]
public 				AddressInfoExport

             doorPickwareAddressInfoExport
 { get; set; }
      [JsonProperty("receiveWareAddressInfoExport")]
public 				AddressInfoExport

             receiveWareAddressInfoExport
 { get; set; }
      [JsonProperty("afterserviceContactsInfoExport")]
public 				ContactsInfoExport

             afterserviceContactsInfoExport
 { get; set; }
      [JsonProperty("serviceExpressInfoExport")]
public 				ServiceExpressInfoExport

             serviceExpressInfoExport
 { get; set; }
      [JsonProperty("serviceFinanceDetailInfoExports")]
public 				List<string>

             serviceFinanceDetailInfoExports
 { get; set; }
      [JsonProperty("serviceTrackInfoExports")]
public 				List<string>

             serviceTrackInfoExports
 { get; set; }
      [JsonProperty("serviceDetailInfoExports")]
public 				List<string>

             serviceDetailInfoExports
 { get; set; }
      [JsonProperty("allowOperations")]
public 				List<string>

             allowOperations
 { get; set; }
      [JsonProperty("orderType")]
public 				int

             orderType
 { get; set; }
      [JsonProperty("appointmentInfoExport")]
public 				AppointmentInfoExport

             appointmentInfoExport
 { get; set; }
      [JsonProperty("buId")]
public 				string

             buId
 { get; set; }
      [JsonProperty("approvePin")]
public 				string

             approvePin
 { get; set; }
      [JsonProperty("approveName")]
public 				string

             approveName
 { get; set; }
      [JsonProperty("approvedDate")]
public 				DateTime

             approvedDate
 { get; set; }
      [JsonProperty("processedDate")]
public 				DateTime

             processedDate
 { get; set; }
      [JsonProperty("receiveDate")]
public 				DateTime

             receiveDate
 { get; set; }
      [JsonProperty("afsCategoryId")]
public 				int

             afsCategoryId
 { get; set; }
      [JsonProperty("serviceApplyInfoExport")]
public 				ServiceApplyInfoExport

             serviceApplyInfoExport
 { get; set; }
      [JsonProperty("companyId")]
public 				int

             companyId
 { get; set; }
      [JsonProperty("pickwareType")]
public 				int

             pickwareType
 { get; set; }
      [JsonProperty("questionTypeCid1")]
public 				int

             questionTypeCid1
 { get; set; }
      [JsonProperty("questionTypeCid2")]
public 				int

             questionTypeCid2
 { get; set; }
      [JsonProperty("newOrderId")]
public 				long

             newOrderId
 { get; set; }
      [JsonProperty("updateName")]
public 				string

             updateName
 { get; set; }
      [JsonProperty("updateDate")]
public 				DateTime

             updateDate
 { get; set; }
      [JsonProperty("afsServiceState")]
public 				int

             afsServiceState
 { get; set; }
      [JsonProperty("jdUpgradeSuggestion")]
public 				string

             jdUpgradeSuggestion
 { get; set; }
	}
}
