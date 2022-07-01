using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ServiceBillDetail:JdObject{
      [JsonProperty("serviceDetailId")]
public 				int

             serviceDetailId
 { get; set; }
      [JsonProperty("skuId")]
public 				long

             skuId
 { get; set; }
      [JsonProperty("wareName")]
public 				string

             wareName
 { get; set; }
      [JsonProperty("wareBrand")]
public 				string

             wareBrand
 { get; set; }
      [JsonProperty("wareType")]
public 				int

             wareType
 { get; set; }
      [JsonProperty("wareTypeName")]
public 				string

             wareTypeName
 { get; set; }
      [JsonProperty("wareDescribe")]
public 				string

             wareDescribe
 { get; set; }
      [JsonProperty("payPrice")]
public 					string

             payPrice
 { get; set; }
      [JsonProperty("actualPayPrice")]
public 					string

             actualPayPrice
 { get; set; }
      [JsonProperty("wareCid1")]
public 				int

             wareCid1
 { get; set; }
      [JsonProperty("wareCid2")]
public 				int

             wareCid2
 { get; set; }
      [JsonProperty("wareCid3")]
public 				int

             wareCid3
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
      [JsonProperty("extJsonStr")]
public 				string

             extJsonStr
 { get; set; }
      [JsonProperty("wareNum")]
public 				int

             wareNum
 { get; set; }
	}
}
