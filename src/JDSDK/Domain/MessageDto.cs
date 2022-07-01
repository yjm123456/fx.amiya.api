using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class MessageDto:JdObject{
      [JsonProperty("creator")]
public 				string

             creator
 { get; set; }
      [JsonProperty("clientId")]
public 				string

             clientId
 { get; set; }
      [JsonProperty("dataVersion")]
public 				int

             dataVersion
 { get; set; }
      [JsonProperty("created")]
public 				DateTime

             created
 { get; set; }
      [JsonProperty("concurrentVersion")]
public 				int

             concurrentVersion
 { get; set; }
      [JsonProperty("type")]
public 				int

             type
 { get; set; }
      [JsonProperty("content")]
public 				string

             content
 { get; set; }
      [JsonProperty("expiryDate")]
public 				DateTime

             expiryDate
 { get; set; }
      [JsonProperty("modified")]
public 				DateTime

             modified
 { get; set; }
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("keyword")]
public 				string

             keyword
 { get; set; }
      [JsonProperty("ext2")]
public 				string

             ext2
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
	}
}
