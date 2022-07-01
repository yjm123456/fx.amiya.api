using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CustomerInfo:JdObject{
      [JsonProperty("jdPin")]
public 				string

             jdPin
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("grade")]
public 				int

             grade
 { get; set; }
      [JsonProperty("contactInfo")]
public 				ContactInfo

             contactInfo
 { get; set; }
      [JsonProperty("extJsonStr")]
public 				string

             extJsonStr
 { get; set; }
	}
}
