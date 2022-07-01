using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OneOrderItemVO:JdObject{
      [JsonProperty("oneOrderId")]
public 				long

             oneOrderId
 { get; set; }
      [JsonProperty("skuId")]
public 				long

             skuId
 { get; set; }
      [JsonProperty("skuName")]
public 				string

             skuName
 { get; set; }
      [JsonProperty("skuTotal")]
public 				int

             skuTotal
 { get; set; }
      [JsonProperty("jysSkuLength")]
public 				int

             jysSkuLength
 { get; set; }
      [JsonProperty("jysSkuWidth")]
public 				int

             jysSkuWidth
 { get; set; }
      [JsonProperty("jysSkuHeight")]
public 				int

             jysSkuHeight
 { get; set; }
      [JsonProperty("actualWeight")]
public 				long

             actualWeight
 { get; set; }
      [JsonProperty("billingWeight")]
public 				long

             billingWeight
 { get; set; }
      [JsonProperty("jysStatus")]
public 				int

             jysStatus
 { get; set; }
      [JsonProperty("jysRefuseType")]
public 				int

             jysRefuseType
 { get; set; }
      [JsonProperty("skuPrice")]
public 				long

             skuPrice
 { get; set; }
      [JsonProperty("jysRefuseReason")]
public 				string

             jysRefuseReason
 { get; set; }
      [JsonProperty("extStr")]
public 				string

             extStr
 { get; set; }
	}
}
