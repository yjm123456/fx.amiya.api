using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CollectionSmart:JdObject{
      [JsonProperty("receivableId")]
public 				int

             receivableId
 { get; set; }
      [JsonProperty("amount")]
public 					string

             amount
 { get; set; }
      [JsonProperty("receivableState")]
public 				int

             receivableState
 { get; set; }
      [JsonProperty("receivableStateName")]
public 				string

             receivableStateName
 { get; set; }
      [JsonProperty("applyTime")]
public 				DateTime

             applyTime
 { get; set; }
      [JsonProperty("reconciliationTime")]
public 				DateTime

             reconciliationTime
 { get; set; }
      [JsonProperty("companyId")]
public 				int

             companyId
 { get; set; }
      [JsonProperty("companyName")]
public 				string

             companyName
 { get; set; }
      [JsonProperty("updateDate")]
public 				DateTime

             updateDate
 { get; set; }
      [JsonProperty("paymentChannel")]
public 				string

             paymentChannel
 { get; set; }
      [JsonProperty("balanceFlag")]
public 				int

             balanceFlag
 { get; set; }
      [JsonProperty("receivableType")]
public 				int

             receivableType
 { get; set; }
      [JsonProperty("receivableTypeName")]
public 				string

             receivableTypeName
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
      [JsonProperty("serviceStatus")]
public 				int

             serviceStatus
 { get; set; }
      [JsonProperty("serviceStatusName")]
public 				string

             serviceStatusName
 { get; set; }
      [JsonProperty("serviceApplyTime")]
public 				DateTime

             serviceApplyTime
 { get; set; }
      [JsonProperty("expirationDate")]
public 				DateTime

             expirationDate
 { get; set; }
      [JsonProperty("serviceId")]
public 				int

             serviceId
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
