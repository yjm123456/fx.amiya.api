using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class VideoUgcVo:JdObject{
      [JsonProperty("id")]
public 				string

             id
 { get; set; }
      [JsonProperty("mainUrl")]
public 				string

             mainUrl
 { get; set; }
      [JsonProperty("videoHeight")]
public 				int

             videoHeight
 { get; set; }
      [JsonProperty("videoWidth")]
public 				int

             videoWidth
 { get; set; }
      [JsonProperty("videoLength")]
public 				int

             videoLength
 { get; set; }
      [JsonProperty("videoTitle")]
public 				string

             videoTitle
 { get; set; }
      [JsonProperty("videoUrl")]
public 				string

             videoUrl
 { get; set; }
      [JsonProperty("videoId")]
public 				string

             videoId
 { get; set; }
	}
}
