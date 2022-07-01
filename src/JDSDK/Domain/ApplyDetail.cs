using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ApplyDetail:JdObject{
      [JsonProperty("applyDetailId")]
public 				int

             applyDetailId
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
      [JsonProperty("wareDescribe")]
public 				string

             wareDescribe
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
	}
}
