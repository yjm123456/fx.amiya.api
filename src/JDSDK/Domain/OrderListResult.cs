using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderListResult:JdObject{
      [JsonProperty("apiResult")]
public 				ApiResult

             apiResult
 { get; set; }
      [JsonProperty("orderTotal")]
public 				int

             orderTotal
 { get; set; }
      [JsonProperty("orderInfoList")]
public 				List<string>

             orderInfoList
 { get; set; }
	}
}
