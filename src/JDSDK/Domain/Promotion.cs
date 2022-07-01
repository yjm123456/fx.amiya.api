using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class Promotion:JdObject{
      [JsonProperty("promoId")]
public 				long

             promoId
 { get; set; }
      [JsonProperty("venderId")]
public 				long

             venderId
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("beginTime")]
public 				string

             beginTime
 { get; set; }
      [JsonProperty("endTime")]
public 				string

             endTime
 { get; set; }
      [JsonProperty("promoStatus")]
public 				int

             promoStatus
 { get; set; }
      [JsonProperty("created")]
public 				DateTime

             created
 { get; set; }
	}
}
