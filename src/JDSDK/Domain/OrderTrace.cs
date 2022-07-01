using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderTrace:JdObject{
      [JsonProperty("traceDetails")]
public 				List<string>

             traceDetails
 { get; set; }
	}
}
