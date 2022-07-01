using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WaitAuditApply:JdObject{
      [JsonProperty("applyId")]
public 				int

             applyId
 { get; set; }
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
      [JsonProperty("serviceStatusName")]
public 				string

             serviceStatusName
 { get; set; }
      [JsonProperty("serviceStatus")]
public 				int

             serviceStatus
 { get; set; }
      [JsonProperty("applyTime")]
public 				DateTime

             applyTime
 { get; set; }
      [JsonProperty("auditOvertime")]
public 				DateTime

             auditOvertime
 { get; set; }
      [JsonProperty("timeoutFlag")]
public 				bool

             timeoutFlag
 { get; set; }
      [JsonProperty("customerPin")]
public 				string

             customerPin
 { get; set; }
      [JsonProperty("customerName")]
public 				string

             customerName
 { get; set; }
      [JsonProperty("customerMobile")]
public 				string

             customerMobile
 { get; set; }
      [JsonProperty("customerGrade")]
public 				int

             customerGrade
 { get; set; }
      [JsonProperty("pickwareAddress")]
public 				string

             pickwareAddress
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
      [JsonProperty("skuId")]
public 				long

             skuId
 { get; set; }
      [JsonProperty("wareName")]
public 				string

             wareName
 { get; set; }
      [JsonProperty("skuType")]
public 				int

             skuType
 { get; set; }
      [JsonProperty("skuTypeName")]
public 				string

             skuTypeName
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
