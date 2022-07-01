using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class Image:JdObject{
      [JsonProperty("colorId")]
public 				string

             colorId
 { get; set; }
      [JsonProperty("imgId")]
public 				long

             imgId
 { get; set; }
      [JsonProperty("imgIndex")]
public 				int

             imgIndex
 { get; set; }
      [JsonProperty("imgUrl")]
public 				string

             imgUrl
 { get; set; }
      [JsonProperty("imgZoneId")]
public 				string

             imgZoneId
 { get; set; }
      [JsonProperty("imgRectangleUrl")]
public 				string

             imgRectangleUrl
 { get; set; }
	}
}
