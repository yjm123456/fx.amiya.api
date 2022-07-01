using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class RefundBillChargeMO:JdObject{
      [JsonProperty("skuName")]
public 				string

             skuName
 { get; set; }
      [JsonProperty("orderId")]
public 				long

             orderId
 { get; set; }
      [JsonProperty("createTime")]
public 				DateTime

             createTime
 { get; set; }
      [JsonProperty("docCreateTime")]
public 				DateTime

             docCreateTime
 { get; set; }
      [JsonProperty("venderId")]
public 				long

             venderId
 { get; set; }
      [JsonProperty("count")]
public 				long

             count
 { get; set; }
      [JsonProperty("docUpdateTime")]
public 				DateTime

             docUpdateTime
 { get; set; }
      [JsonProperty("feeList")]
public 				List<string>

             feeList
 { get; set; }
      [JsonProperty("skuId")]
public 				string

             skuId
 { get; set; }
      [JsonProperty("returnTime")]
public 				DateTime

             returnTime
 { get; set; }
      [JsonProperty("serviceOrderId")]
public 				long

             serviceOrderId
 { get; set; }
	}
}
