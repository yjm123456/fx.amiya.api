using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderExtInfoResp:JdObject{
      [JsonProperty("extInfo")]
public 					Dictionary<string, object>

             extInfo
 { get; set; }
	}
}
