using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class HouseJos400ClueVO:JdObject{
      [JsonProperty("clueId")]
public 				long

             clueId
 { get; set; }
      [JsonProperty("spuId")]
public 				long

             spuId
 { get; set; }
      [JsonProperty("spuTitle")]
public 				string

             spuTitle
 { get; set; }
      [JsonProperty("brokerName")]
public 				string

             brokerName
 { get; set; }
      [JsonProperty("brokerPhone")]
public 				string

             brokerPhone
 { get; set; }
      [JsonProperty("extensionNum")]
public 				string

             extensionNum
 { get; set; }
      [JsonProperty("callStartTime")]
public 				DateTime

             callStartTime
 { get; set; }
      [JsonProperty("callEndTime")]
public 				DateTime

             callEndTime
 { get; set; }
      [JsonProperty("callInLong")]
public 				long

             callInLong
 { get; set; }
      [JsonProperty("callingNumber")]
public 				string

             callingNumber
 { get; set; }
      [JsonProperty("landingNumer")]
public 				string

             landingNumer
 { get; set; }
	}
}
