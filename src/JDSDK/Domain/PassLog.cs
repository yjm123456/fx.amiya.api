using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PassLog:JdObject{
      [JsonProperty("waiter")]
public 				string

             waiter
 { get; set; }
      [JsonProperty("loginTime")]
public 				DateTime

             loginTime
 { get; set; }
      [JsonProperty("logoutTime")]
public 				DateTime

             logoutTime
 { get; set; }
      [JsonProperty("ip")]
public 				string

             ip
 { get; set; }
      [JsonProperty("loginSid")]
public 				string

             loginSid
 { get; set; }
	}
}
