using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class TrackShowVo:JdObject{
      [JsonProperty("orderId")]
public 				long

             orderId
 { get; set; }
      [JsonProperty("systemType")]
public 				int

             systemType
 { get; set; }
      [JsonProperty("messageType")]
public 				int

             messageType
 { get; set; }
      [JsonProperty("content")]
public 				string

             content
 { get; set; }
      [JsonProperty("msgTime")]
public 				DateTime

             msgTime
 { get; set; }
      [JsonProperty("operatorStr")]
public 				string

             operatorStr
 { get; set; }
      [JsonProperty("scanType")]
public 				string

             scanType
 { get; set; }
      [JsonProperty("groupType")]
public 				string

             groupType
 { get; set; }
	}
}
