using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class Pagination:JdObject{
      [JsonProperty("pageNo")]
public 				int

             pageNo
 { get; set; }
      [JsonProperty("pageSize")]
public 				int

             pageSize
 { get; set; }
      [JsonProperty("totalCount")]
public 				int

             totalCount
 { get; set; }
      [JsonProperty("totalPage")]
public 				int

             totalPage
 { get; set; }
      [JsonProperty("data")]
public 				List<string>

             data
 { get; set; }
	}
}
