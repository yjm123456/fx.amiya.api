using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PaginatedInfo:JdObject{
      [JsonProperty("pageSize")]
public 				int

             pageSize
 { get; set; }
      [JsonProperty("index")]
public 				int

             index
 { get; set; }
      [JsonProperty("totalItem")]
public 				int

             totalItem
 { get; set; }
      [JsonProperty("pageList")]
public 				List<string>

             pageList
 { get; set; }
      [JsonProperty("totalPage")]
public 				int

             totalPage
 { get; set; }
	}
}
