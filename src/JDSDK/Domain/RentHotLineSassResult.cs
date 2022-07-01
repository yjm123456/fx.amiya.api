using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class RentHotLineSassResult:JdObject{
      [JsonProperty("code")]
public 				string

             code
 { get; set; }
      [JsonProperty("message")]
public 				string

             message
 { get; set; }
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("venderId")]
public 				long

             venderId
 { get; set; }
      [JsonProperty("venderName")]
public 				string

             venderName
 { get; set; }
      [JsonProperty("phoneName")]
public 				string

             phoneName
 { get; set; }
      [JsonProperty("workHourStart")]
public 				int

             workHourStart
 { get; set; }
      [JsonProperty("workHourEnd")]
public 				int

             workHourEnd
 { get; set; }
      [JsonProperty("phoneMain")]
public 				string

             phoneMain
 { get; set; }
      [JsonProperty("phoneExtension")]
public 				string

             phoneExtension
 { get; set; }
      [JsonProperty("created")]
public 				DateTime

             created
 { get; set; }
      [JsonProperty("modified")]
public 				DateTime

             modified
 { get; set; }
      [JsonProperty("phoneLandingList")]
public 				List<string>

             phoneLandingList
 { get; set; }
	}
}
