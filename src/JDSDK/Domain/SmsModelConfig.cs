using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SmsModelConfig:JdObject{
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("detail")]
public 				string

             detail
 { get; set; }
      [JsonProperty("modelServeType")]
public 				ModelServeType

             modelServeType
 { get; set; }
	}
}
