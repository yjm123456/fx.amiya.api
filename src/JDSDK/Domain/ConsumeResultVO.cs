using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ConsumeResultVO:JdObject{
      [JsonProperty("swiftNumber")]
public 				string

             swiftNumber
 { get; set; }
      [JsonProperty("amount")]
public 					string

             amount
 { get; set; }
      [JsonProperty("createTime")]
public 				string

             createTime
 { get; set; }
      [JsonProperty("type")]
public 				string

             type
 { get; set; }
      [JsonProperty("spaceId")]
public 				string

             spaceId
 { get; set; }
      [JsonProperty("unitId")]
public 				string

             unitId
 { get; set; }
      [JsonProperty("mediaId")]
public 				string

             mediaId
 { get; set; }
      [JsonProperty("compaignId")]
public 				string

             compaignId
 { get; set; }
	}
}
