using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JOSVideoSkuRelative:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("videoId")]
public 				long

             videoId
 { get; set; }
      [JsonProperty("venderId")]
public 				long

             venderId
 { get; set; }
      [JsonProperty("productId")]
public 				long

             productId
 { get; set; }
      [JsonProperty("skuId")]
public 				long

             skuId
 { get; set; }
      [JsonProperty("categoryId")]
public 				long

             categoryId
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("verifier")]
public 				string

             verifier
 { get; set; }
      [JsonProperty("verifyDesc")]
public 				string

             verifyDesc
 { get; set; }
      [JsonProperty("applyReason")]
public 				string

             applyReason
 { get; set; }
      [JsonProperty("createdDate")]
public 				DateTime

             createdDate
 { get; set; }
      [JsonProperty("modifiedDate")]
public 				DateTime

             modifiedDate
 { get; set; }
      [JsonProperty("videoType")]
public 				int

             videoType
 { get; set; }
	}
}
