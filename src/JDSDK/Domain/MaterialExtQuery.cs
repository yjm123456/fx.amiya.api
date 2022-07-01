using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class MaterialExtQuery:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("materialId")]
public 				long

             materialId
 { get; set; }
      [JsonProperty("pin")]
public 				string

             pin
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
      [JsonProperty("notes")]
public 				string

             notes
 { get; set; }
      [JsonProperty("dataRate")]
public 				string

             dataRate
 { get; set; }
	}
}
