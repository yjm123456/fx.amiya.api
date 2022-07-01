using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WareAreaLimit:JdObject{
      [JsonProperty("areaId")]
public 				long

             areaId
 { get; set; }
      [JsonProperty("limitType")]
public 				int

             limitType
 { get; set; }
      [JsonProperty("wareId")]
public 				long

             wareId
 { get; set; }
	}
}
