using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WaitAuditDetail:JdObject{
      [JsonProperty("serviceIdList")]
public 				List<string>

             serviceIdList
 { get; set; }
      [JsonProperty("customerExpect")]
public 				int

             customerExpect
 { get; set; }
      [JsonProperty("customerExpectName")]
public 				string

             customerExpectName
 { get; set; }
      [JsonProperty("applyTime")]
public 				DateTime

             applyTime
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
      [JsonProperty("orderType")]
public 				int

             orderType
 { get; set; }
      [JsonProperty("orderTypeName")]
public 				string

             orderTypeName
 { get; set; }
      [JsonProperty("expectPickwareType")]
public 				int

             expectPickwareType
 { get; set; }
      [JsonProperty("expectPickwareTypeName")]
public 				string

             expectPickwareTypeName
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
      [JsonProperty("sysVersion")]
public 				int

             sysVersion
 { get; set; }
      [JsonProperty("extJsonStr")]
public 				string

             extJsonStr
 { get; set; }
      [JsonProperty("customerInfo")]
public 				CustomerInfo

             customerInfo
 { get; set; }
      [JsonProperty("applyDetailList")]
public 				List<string>

             applyDetailList
 { get; set; }
      [JsonProperty("doorPickwareAddress")]
public 				AddressInfo

             doorPickwareAddress
 { get; set; }
      [JsonProperty("receiveWareAddress")]
public 				AddressInfo

             receiveWareAddress
 { get; set; }
      [JsonProperty("appointment")]
public 				Appointment

             appointment
 { get; set; }
	}
}
