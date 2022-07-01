using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ChatSession:JdObject{
      [JsonProperty("customer")]
public 				string

             customer
 { get; set; }
      [JsonProperty("waiter")]
public 				string

             waiter
 { get; set; }
      [JsonProperty("beginTime")]
public 				DateTime

             beginTime
 { get; set; }
      [JsonProperty("replyTime")]
public 				DateTime

             replyTime
 { get; set; }
      [JsonProperty("endTime")]
public 				DateTime

             endTime
 { get; set; }
      [JsonProperty("sessionType")]
public 				int

             sessionType
 { get; set; }
      [JsonProperty("transfer")]
public 					bool

             transfer
 { get; set; }
      [JsonProperty("sid")]
public 				string

             sid
 { get; set; }
      [JsonProperty("skuId")]
public 				long

             skuId
 { get; set; }
	}
}
