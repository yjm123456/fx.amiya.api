using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WaybillGisDto:JdObject{
      [JsonProperty("lat")]
public 				double

             lat
 { get; set; }
      [JsonProperty("lng")]
public 				double

             lng
 { get; set; }
      [JsonProperty("gpsTime")]
public 				DateTime

             gpsTime
 { get; set; }
	}
}
