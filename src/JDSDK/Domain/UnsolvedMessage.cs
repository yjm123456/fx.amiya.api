using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class UnsolvedMessage:JdObject{
      [JsonProperty("createPin")]
public 				string

             createPin
 { get; set; }
      [JsonProperty("createName")]
public 				string

             createName
 { get; set; }
      [JsonProperty("createDate")]
public 				DateTime

             createDate
 { get; set; }
      [JsonProperty("context")]
public 				string

             context
 { get; set; }
      [JsonProperty("messageType")]
public 				int

             messageType
 { get; set; }
      [JsonProperty("messageTypeName")]
public 				string

             messageTypeName
 { get; set; }
      [JsonProperty("extJsonStr")]
public 				string

             extJsonStr
 { get; set; }
	}
}
