using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ChatLog:JdObject{
      [JsonProperty("customer")]
public 				string

             customer
 { get; set; }
      [JsonProperty("waiter")]
public 				string

             waiter
 { get; set; }
      [JsonProperty("content")]
public 				string

             content
 { get; set; }
      [JsonProperty("sid")]
public 				string

             sid
 { get; set; }
      [JsonProperty("skuId")]
public 				long

             skuId
 { get; set; }
      [JsonProperty("time")]
public 				DateTime

             time
 { get; set; }
      [JsonProperty("channel")]
public 				int

             channel
 { get; set; }
      [JsonProperty("waiterSend")]
public 					bool

             waiterSend
 { get; set; }
	}
}
