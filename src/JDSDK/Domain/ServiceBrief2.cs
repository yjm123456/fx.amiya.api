using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ServiceBrief2:JdObject{
      [JsonProperty("serviceId")]
public 				int

             serviceId
 { get; set; }
      [JsonProperty("customerExpect")]
public 				int

             customerExpect
 { get; set; }
      [JsonProperty("orderId")]
public 				long

             orderId
 { get; set; }
      [JsonProperty("serviceStatus")]
public 				int

             serviceStatus
 { get; set; }
      [JsonProperty("applyTime")]
public 				DateTime

             applyTime
 { get; set; }
      [JsonProperty("orderType")]
public 				int

             orderType
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
      [JsonProperty("skuId")]
public 				long

             skuId
 { get; set; }
      [JsonProperty("pickwareType")]
public 				int

             pickwareType
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
      [JsonProperty("platformSrc")]
public 				int

             platformSrc
 { get; set; }
      [JsonProperty("platformSrcName")]
public 				string

             platformSrcName
 { get; set; }
      [JsonProperty("updateTime")]
public 				DateTime

             updateTime
 { get; set; }
      [JsonProperty("sysVersion")]
public 				int

             sysVersion
 { get; set; }
      [JsonProperty("expressCode")]
public 				string

             expressCode
 { get; set; }
      [JsonProperty("freightUpdateDate")]
public 				DateTime

             freightUpdateDate
 { get; set; }
      [JsonProperty("serviceCount")]
public 				int

             serviceCount
 { get; set; }
      [JsonProperty("parentService")]
public 				long

             parentService
 { get; set; }
	}
}
