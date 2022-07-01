using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderHistoryResponse:JdObject{
      [JsonProperty("totalCount")]
public 				int

             totalCount
 { get; set; }
      [JsonProperty("pageSize")]
public 				int

             pageSize
 { get; set; }
      [JsonProperty("pageNo")]
public 				int

             pageNo
 { get; set; }
      [JsonProperty("orders")]
public 				List<string>

             orders
 { get; set; }
      [JsonProperty("resultCode")]
public 				int

             resultCode
 { get; set; }
      [JsonProperty("message")]
public 				string

             message
 { get; set; }
	}
}
