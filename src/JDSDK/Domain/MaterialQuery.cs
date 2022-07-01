using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class MaterialQuery:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("pin")]
public 				string

             pin
 { get; set; }
      [JsonProperty("materialName")]
public 				string

             materialName
 { get; set; }
      [JsonProperty("materialCode")]
public 				string

             materialCode
 { get; set; }
      [JsonProperty("level")]
public 				int

             level
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("effectiveDate")]
public 				DateTime

             effectiveDate
 { get; set; }
      [JsonProperty("expirationDate")]
public 				DateTime

             expirationDate
 { get; set; }
      [JsonProperty("shopId")]
public 				string

             shopId
 { get; set; }
      [JsonProperty("skuId")]
public 				string

             skuId
 { get; set; }
      [JsonProperty("mediaId")]
public 				string

             mediaId
 { get; set; }
      [JsonProperty("imgSource")]
public 				string

             imgSource
 { get; set; }
      [JsonProperty("creativeId")]
public 				string

             creativeId
 { get; set; }
      [JsonProperty("auditType")]
public 				int

             auditType
 { get; set; }
      [JsonProperty("auditPerson")]
public 				string

             auditPerson
 { get; set; }
      [JsonProperty("auditTime")]
public 				string

             auditTime
 { get; set; }
      [JsonProperty("displayMode")]
public 				int

             displayMode
 { get; set; }
      [JsonProperty("type")]
public 				int

             type
 { get; set; }
      [JsonProperty("subType")]
public 				int

             subType
 { get; set; }
      [JsonProperty("label")]
public 				string

             label
 { get; set; }
      [JsonProperty("imgSrc")]
public 				string

             imgSrc
 { get; set; }
      [JsonProperty("videoSrc")]
public 				string

             videoSrc
 { get; set; }
      [JsonProperty("url")]
public 				string

             url
 { get; set; }
      [JsonProperty("width")]
public 				int

             width
 { get; set; }
      [JsonProperty("height")]
public 				int

             height
 { get; set; }
      [JsonProperty("length")]
public 				int

             length
 { get; set; }
      [JsonProperty("size")]
public 				int

             size
 { get; set; }
      [JsonProperty("mimeType")]
public 				string

             mimeType
 { get; set; }
      [JsonProperty("device")]
public 				int

             device
 { get; set; }
      [JsonProperty("auditInfo")]
public 				string

             auditInfo
 { get; set; }
      [JsonProperty("dataRate")]
public 				string

             dataRate
 { get; set; }
      [JsonProperty("materialExtList")]
public 				List<string>

             materialExtList
 { get; set; }
	}
}
