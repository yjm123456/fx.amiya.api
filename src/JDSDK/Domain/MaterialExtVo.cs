using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class MaterialExtVo:JdObject{
      [JsonProperty("modifiedTime")]
public 				DateTime

             modifiedTime
 { get; set; }
      [JsonProperty("notes")]
public 				string

             notes
 { get; set; }
      [JsonProperty("orderId")]
public 				int

             orderId
 { get; set; }
      [JsonProperty("videoSrc")]
public 				string

             videoSrc
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
      [JsonProperty("type")]
public 				int

             type
 { get; set; }
      [JsonProperty("createdTime")]
public 				DateTime

             createdTime
 { get; set; }
      [JsonProperty("height")]
public 				int

             height
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
      [JsonProperty("size")]
public 				int

             size
 { get; set; }
      [JsonProperty("width")]
public 				int

             width
 { get; set; }
      [JsonProperty("subType")]
public 				int

             subType
 { get; set; }
      [JsonProperty("imgSrc")]
public 				string

             imgSrc
 { get; set; }
	}
}
