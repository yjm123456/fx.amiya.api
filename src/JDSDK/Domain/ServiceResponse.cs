using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ServiceResponse:JdObject{
      [JsonProperty("code")]
public 				string

             code
 { get; set; }
      [JsonProperty("data")]
public 				int

             data
 { get; set; }
      [JsonProperty("detail")]
public 				string

             detail
 { get; set; }
	}
}
