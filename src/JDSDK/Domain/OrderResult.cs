using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderResult:JdObject{
      [JsonProperty("apiResult")]
public 				ApiResult

             apiResult
 { get; set; }
      [JsonProperty("orderInfo")]
public 				OrderSearchInfo

             orderInfo
 { get; set; }
	}
}
