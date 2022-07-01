using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class MessageInfo:JdObject{
      [JsonProperty("messageId")]
public 				int

             messageId
 { get; set; }
      [JsonProperty("serviceId")]
public 				int

             serviceId
 { get; set; }
      [JsonProperty("msgType")]
public 				int

             msgType
 { get; set; }
      [JsonProperty("msgTypeName")]
public 				string

             msgTypeName
 { get; set; }
      [JsonProperty("title")]
public 				string

             title
 { get; set; }
      [JsonProperty("context")]
public 				string

             context
 { get; set; }
      [JsonProperty("operateType")]
public 				int

             operateType
 { get; set; }
      [JsonProperty("operateTypeName")]
public 				string

             operateTypeName
 { get; set; }
      [JsonProperty("operatePin")]
public 				string

             operatePin
 { get; set; }
      [JsonProperty("operateName")]
public 				string

             operateName
 { get; set; }
      [JsonProperty("operateDate")]
public 				DateTime

             operateDate
 { get; set; }
      [JsonProperty("extJsonStr")]
public 				string

             extJsonStr
 { get; set; }
	}
}
