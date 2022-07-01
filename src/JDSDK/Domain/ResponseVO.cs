using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ResponseVO:JdObject{
      [JsonProperty("code")]
public 				long

             code
 { get; set; }
      [JsonProperty("message")]
public 				string

             message
 { get; set; }
      [JsonProperty("data")]
public 				bool

             data
 { get; set; }
	}
}
