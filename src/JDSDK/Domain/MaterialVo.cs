using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class MaterialVo:JdObject{
      [JsonProperty("modifiedTime")]
public 				DateTime

             modifiedTime
 { get; set; }
      [JsonProperty("bindingCount")]
public 				string

             bindingCount
 { get; set; }
      [JsonProperty("notes")]
public 				string

             notes
 { get; set; }
      [JsonProperty("aspectRatio")]
public 				string

             aspectRatio
 { get; set; }
      [JsonProperty("mimeType")]
public 				string

             mimeType
 { get; set; }
      [JsonProperty("dataRate")]
public 				string

             dataRate
 { get; set; }
      [JsonProperty("source")]
public 				int

             source
 { get; set; }
      [JsonProperty("mediaId")]
public 				string

             mediaId
 { get; set; }
      [JsonProperty("type")]
public 				int

             type
 { get; set; }
      [JsonProperty("materialExtList")]
public 				List<string>

             materialExtList
 { get; set; }
      [JsonProperty("pin")]
public 				string

             pin
 { get; set; }
      [JsonProperty("yn")]
public 				int

             yn
 { get; set; }
      [JsonProperty("createdTime")]
public 				DateTime

             createdTime
 { get; set; }
      [JsonProperty("shopId")]
public 				string

             shopId
 { get; set; }
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("skuId")]
public 				string

             skuId
 { get; set; }
      [JsonProperty("height")]
public 				int

             height
 { get; set; }
      [JsonProperty("displayMode")]
public 				int

             displayMode
 { get; set; }
      [JsonProperty("materialName")]
public 				string

             materialName
 { get; set; }
      [JsonProperty("size")]
public 				int

             size
 { get; set; }
      [JsonProperty("auditTime")]
public 				DateTime

             auditTime
 { get; set; }
      [JsonProperty("imgSource")]
public 				int

             imgSource
 { get; set; }
      [JsonProperty("subType")]
public 				int

             subType
 { get; set; }
      [JsonProperty("device")]
public 				int

             device
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("videoSrc")]
public 				string

             videoSrc
 { get; set; }
      [JsonProperty("creativeId")]
public 				string

             creativeId
 { get; set; }
      [JsonProperty("auditInfo")]
public 				string

             auditInfo
 { get; set; }
      [JsonProperty("expirationDate")]
public 				DateTime

             expirationDate
 { get; set; }
      [JsonProperty("needAudit")]
public 					bool

             needAudit
 { get; set; }
      [JsonProperty("imgMd5")]
public 				string

             imgMd5
 { get; set; }
      [JsonProperty("length")]
public 				int

             length
 { get; set; }
      [JsonProperty("label")]
public 				string

             label
 { get; set; }
      [JsonProperty("url")]
public 				string

             url
 { get; set; }
      [JsonProperty("spreadType")]
public 				int

             spreadType
 { get; set; }
      [JsonProperty("width")]
public 				int

             width
 { get; set; }
      [JsonProperty("imgSrc")]
public 				string

             imgSrc
 { get; set; }
      [JsonProperty("effectiveDate")]
public 				DateTime

             effectiveDate
 { get; set; }
	}
}
