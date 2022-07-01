using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ApplyBrief:JdObject{
      [JsonProperty("applyId")]
public 				int

             applyId
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
      [JsonProperty("pickwareType")]
public 				int

             pickwareType
 { get; set; }
      [JsonProperty("pickwareTypeName")]
public 				string

             pickwareTypeName
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
      [JsonProperty("questionDesc")]
public 				string

             questionDesc
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
      [JsonProperty("skuUuid")]
public 				string

             skuUuid
 { get; set; }
      [JsonProperty("wareNum")]
public 				int

             wareNum
 { get; set; }
	}
}
