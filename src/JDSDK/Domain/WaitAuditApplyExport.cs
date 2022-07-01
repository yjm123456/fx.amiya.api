using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WaitAuditApplyExport:JdObject{
      [JsonProperty("serviceIdList")]
public 				List<string>

             serviceIdList
 { get; set; }
      [JsonProperty("afsApplyId")]
public 				int

             afsApplyId
 { get; set; }
      [JsonProperty("customerPin")]
public 				string

             customerPin
 { get; set; }
      [JsonProperty("customerName")]
public 				string

             customerName
 { get; set; }
      [JsonProperty("customerExpect")]
public 				int

             customerExpect
 { get; set; }
      [JsonProperty("customerExpectName")]
public 				string

             customerExpectName
 { get; set; }
      [JsonProperty("afsServiceStatusName")]
public 				string

             afsServiceStatusName
 { get; set; }
      [JsonProperty("afsServiceStatus")]
public 				int

             afsServiceStatus
 { get; set; }
      [JsonProperty("afsApplyTime")]
public 				DateTime

             afsApplyTime
 { get; set; }
      [JsonProperty("auditOvertime")]
public 				DateTime

             auditOvertime
 { get; set; }
      [JsonProperty("orderId")]
public 				long

             orderId
 { get; set; }
      [JsonProperty("wareId")]
public 				long

             wareId
 { get; set; }
      [JsonProperty("wareName")]
public 				string

             wareName
 { get; set; }
      [JsonProperty("ifTimeoutSoon")]
public 				bool

             ifTimeoutSoon
 { get; set; }
      [JsonProperty("actualPayPrice")]
public 					string

             actualPayPrice
 { get; set; }
      [JsonProperty("customerMobilePhone")]
public 				string

             customerMobilePhone
 { get; set; }
      [JsonProperty("customerGrade")]
public 				int

             customerGrade
 { get; set; }
      [JsonProperty("pickwareAddress")]
public 				string

             pickwareAddress
 { get; set; }
      [JsonProperty("orderType")]
public 				int

             orderType
 { get; set; }
	}
}
