using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class GxOrderListResponse:JdObject{
      [JsonProperty("code")]
public 				int

             code
 { get; set; }
      [JsonProperty("msg")]
public 				string

             msg
 { get; set; }
      [JsonProperty("data")]
public 				List<string>

             data
 { get; set; }
	}
}
