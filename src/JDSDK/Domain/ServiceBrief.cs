using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ServiceBrief:JdObject{
      [JsonProperty("applyId")]
public 				int

             applyId
 { get; set; }
      [JsonProperty("serviceId")]
public 				int

             serviceId
 { get; set; }
      [JsonProperty("applyTime")]
public 				DateTime

             applyTime
 { get; set; }
      [JsonProperty("customerExpect")]
public 				int

             customerExpect
 { get; set; }
      [JsonProperty("customerExpectName")]
public 				string

             customerExpectName
 { get; set; }
      [JsonProperty("serviceStatus")]
public 				int

             serviceStatus
 { get; set; }
      [JsonProperty("serviceStatusName")]
public 				string

             serviceStatusName
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
      [JsonProperty("customerTel")]
public 				string

             customerTel
 { get; set; }
      [JsonProperty("pickwareAddress")]
public 				string

             pickwareAddress
 { get; set; }
      [JsonProperty("orderId")]
public 				long

             orderId
 { get; set; }
      [JsonProperty("pickwareType")]
public 				int

             pickwareType
 { get; set; }
      [JsonProperty("orderType")]
public 				int

             orderType
 { get; set; }
      [JsonProperty("orderTypeName")]
public 				string

             orderTypeName
 { get; set; }
      [JsonProperty("actualPayPrice")]
public 					string

             actualPayPrice
 { get; set; }
      [JsonProperty("skuId")]
public 				long

             skuId
 { get; set; }
      [JsonProperty("wareType")]
public 				int

             wareType
 { get; set; }
      [JsonProperty("wareTypeName")]
public 				string

             wareTypeName
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
      [JsonProperty("skuUuid")]
public 				string

             skuUuid
 { get; set; }
      [JsonProperty("approvePin")]
public 				string

             approvePin
 { get; set; }
      [JsonProperty("approveName")]
public 				string

             approveName
 { get; set; }
      [JsonProperty("approveTime")]
public 				DateTime

             approveTime
 { get; set; }
      [JsonProperty("approveResult")]
public 				int

             approveResult
 { get; set; }
      [JsonProperty("approveResultName")]
public 				string

             approveResultName
 { get; set; }
      [JsonProperty("processPin")]
public 				string

             processPin
 { get; set; }
      [JsonProperty("processName")]
public 				string

             processName
 { get; set; }
      [JsonProperty("processTime")]
public 				DateTime

             processTime
 { get; set; }
      [JsonProperty("processResult")]
public 				int

             processResult
 { get; set; }
      [JsonProperty("processResultName")]
public 				string

             processResultName
 { get; set; }
      [JsonProperty("extJsonStr")]
public 				string

             extJsonStr
 { get; set; }
      [JsonProperty("platformSrc")]
public 				int

             platformSrc
 { get; set; }
      [JsonProperty("platformSrcName")]
public 				string

             platformSrcName
 { get; set; }
      [JsonProperty("serviceCount")]
public 				int

             serviceCount
 { get; set; }
      [JsonProperty("desen_customerTel")]
public 				string

                                                                                     desenCustomerTel
 { get; set; }
	}
}
