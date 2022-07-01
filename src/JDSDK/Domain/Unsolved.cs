using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class Unsolved:JdObject{
      [JsonProperty("serviceId")]
public 				int

             serviceId
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
      [JsonProperty("orderId")]
public 				long

             orderId
 { get; set; }
      [JsonProperty("skuId")]
public 				long

             skuId
 { get; set; }
      [JsonProperty("wareName")]
public 				string

             wareName
 { get; set; }
      [JsonProperty("wareType")]
public 				int

             wareType
 { get; set; }
      [JsonProperty("wareTypeName")]
public 				string

             wareTypeName
 { get; set; }
      [JsonProperty("skuType")]
public 				int

             skuType
 { get; set; }
      [JsonProperty("skuTypeName")]
public 				string

             skuTypeName
 { get; set; }
      [JsonProperty("customerPin")]
public 				string

             customerPin
 { get; set; }
      [JsonProperty("customerName")]
public 				string

             customerName
 { get; set; }
      [JsonProperty("customerGrade")]
public 				int

             customerGrade
 { get; set; }
      [JsonProperty("customerMobile")]
public 				string

             customerMobile
 { get; set; }
      [JsonProperty("pickwareAddress")]
public 				string

             pickwareAddress
 { get; set; }
      [JsonProperty("processResult")]
public 				int

             processResult
 { get; set; }
      [JsonProperty("processResultName")]
public 				string

             processResultName
 { get; set; }
      [JsonProperty("processDate")]
public 				DateTime

             processDate
 { get; set; }
      [JsonProperty("processPin")]
public 				string

             processPin
 { get; set; }
      [JsonProperty("approveDate")]
public 				DateTime

             approveDate
 { get; set; }
      [JsonProperty("approvePin")]
public 				string

             approvePin
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
