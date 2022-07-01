using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class DspTraceDTO:JdObject{
      [JsonProperty("traceRange")]
public 				int

             traceRange
 { get; set; }
      [JsonProperty("traceType")]
public 				int

             traceType
 { get; set; }
      [JsonProperty("traceInfos")]
public 				List<string>

             traceInfos
 { get; set; }
	}
}
