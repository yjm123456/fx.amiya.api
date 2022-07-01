using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class TransparentImage:JdObject{
      [JsonProperty("wareId")]
public 				long

             wareId
 { get; set; }
      [JsonProperty("colorId")]
public 				string

             colorId
 { get; set; }
      [JsonProperty("imageUrl")]
public 				string

             imageUrl
 { get; set; }
	}
}
