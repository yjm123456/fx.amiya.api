using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class StrategyComputeResponseDTO:JdObject{
      [JsonProperty("total")]
public 				long

             total
 { get; set; }
      [JsonProperty("member")]
public 				long

             member
 { get; set; }
	}
}
