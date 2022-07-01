using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class BSpuQualifyDto:JdObject{
      [JsonProperty("wareId")]
public 				long

             wareId
 { get; set; }
      [JsonProperty("gmtModify")]
public 				DateTime

             gmtModify
 { get; set; }
      [JsonProperty("yn")]
public 				int

             yn
 { get; set; }
      [JsonProperty("imagePath")]
public 				string

             imagePath
 { get; set; }
      [JsonProperty("bizCode")]
public 				string

             bizCode
 { get; set; }
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("gmtCreate")]
public 				DateTime

             gmtCreate
 { get; set; }
      [JsonProperty("imageIndex")]
public 				int

             imageIndex
 { get; set; }
	}
}
