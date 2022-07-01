using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class DspPriceForeCast:JdObject{
      [JsonProperty("hourHigh")]
public 				List<string>

             hourHigh
 { get; set; }
      [JsonProperty("hourMiddle")]
public 				List<string>

             hourMiddle
 { get; set; }
      [JsonProperty("hourLow")]
public 				List<string>

             hourLow
 { get; set; }
      [JsonProperty("dayHigh")]
public 				List<string>

             dayHigh
 { get; set; }
      [JsonProperty("dayMiddle")]
public 				List<string>

             dayMiddle
 { get; set; }
      [JsonProperty("dayLow")]
public 				List<string>

             dayLow
 { get; set; }
	}
}
