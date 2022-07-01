using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PickwareInfo:JdObject{
      [JsonProperty("pickwareCode")]
public 				string

             pickwareCode
 { get; set; }
      [JsonProperty("pickwareType")]
public 				int

             pickwareType
 { get; set; }
      [JsonProperty("pickwareState")]
public 				int

             pickwareState
 { get; set; }
      [JsonProperty("pickwareMethod")]
public 				int

             pickwareMethod
 { get; set; }
	}
}
