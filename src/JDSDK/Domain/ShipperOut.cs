using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ShipperOut:JdObject{
      [JsonProperty("shipperNo")]
public 				string

             shipperNo
 { get; set; }
      [JsonProperty("shipperName")]
public 				string

             shipperName
 { get; set; }
      [JsonProperty("contacts")]
public 				string

             contacts
 { get; set; }
      [JsonProperty("phone")]
public 				string

             phone
 { get; set; }
      [JsonProperty("reserve1")]
public 				string

             reserve1
 { get; set; }
      [JsonProperty("reserve2")]
public 				string

             reserve2
 { get; set; }
      [JsonProperty("reserve3")]
public 				string

             reserve3
 { get; set; }
      [JsonProperty("reserve4")]
public 				string

             reserve4
 { get; set; }
      [JsonProperty("reserve5")]
public 				string

             reserve5
 { get; set; }
      [JsonProperty("status")]
public 				string

             status
 { get; set; }
      [JsonProperty("type")]
public 				string

             type
 { get; set; }
      [JsonProperty("isCod")]
public 				string

             isCod
 { get; set; }
      [JsonProperty("isTemplate")]
public 				string

             isTemplate
 { get; set; }
	}
}
