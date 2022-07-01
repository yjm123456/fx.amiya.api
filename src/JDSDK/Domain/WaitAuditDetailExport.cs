using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WaitAuditDetailExport:JdObject{
      [JsonProperty("serviceIdList")]
public 				List<string>

             serviceIdList
 { get; set; }
      [JsonProperty("customerExpect")]
public 				int

             customerExpect
 { get; set; }
      [JsonProperty("afsApplyTime")]
public 				DateTime

             afsApplyTime
 { get; set; }
      [JsonProperty("orderId")]
public 				long

             orderId
 { get; set; }
      [JsonProperty("questionPic")]
public 				string

             questionPic
 { get; set; }
      [JsonProperty("questionDesc")]
public 				string

             questionDesc
 { get; set; }
      [JsonProperty("questionTypeCid1")]
public 				int

             questionTypeCid1
 { get; set; }
      [JsonProperty("questionTypeCid2")]
public 				int

             questionTypeCid2
 { get; set; }
      [JsonProperty("orderType")]
public 				int

             orderType
 { get; set; }
      [JsonProperty("serviceCustomerInfoExport")]
public 				ServiceCustomerInfoExport

             serviceCustomerInfoExport
 { get; set; }
      [JsonProperty("applyDetailInfoExport")]
public 				List<string>

             applyDetailInfoExport
 { get; set; }
      [JsonProperty("doorPickwareAddressInfoExport")]
public 				AddressInfoExport

             doorPickwareAddressInfoExport
 { get; set; }
      [JsonProperty("receiveWareAddressInfoExport")]
public 				AddressInfoExport

             receiveWareAddressInfoExport
 { get; set; }
      [JsonProperty("appointmentInfoExport")]
public 				AppointmentInfoExport

             appointmentInfoExport
 { get; set; }
      [JsonProperty("afsCategoryId")]
public 				int

             afsCategoryId
 { get; set; }
      [JsonProperty("expectPickwareType")]
public 				int

             expectPickwareType
 { get; set; }
      [JsonProperty("invoiceCode")]
public 				string

             invoiceCode
 { get; set; }
      [JsonProperty("jdUpgradeSuggestion")]
public 				string

             jdUpgradeSuggestion
 { get; set; }
	}
}
