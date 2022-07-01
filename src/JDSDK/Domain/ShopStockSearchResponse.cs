using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ShopStockSearchResponse:JdObject{
      [JsonProperty("responseCode")]
public 				int

             responseCode
 { get; set; }
      [JsonProperty("errMsg")]
public 				string

             errMsg
 { get; set; }
      [JsonProperty("pageSize")]
public 				int

             pageSize
 { get; set; }
      [JsonProperty("pageCount")]
public 				int

             pageCount
 { get; set; }
      [JsonProperty("data")]
public 				List<string>

             data
 { get; set; }
      [JsonProperty("pageNumber")]
public 				int

             pageNumber
 { get; set; }
      [JsonProperty("requestId")]
public 				string

             requestId
 { get; set; }
	}
}
