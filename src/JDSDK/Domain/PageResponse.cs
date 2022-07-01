using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PageResponse:JdObject{
      [JsonProperty("pageNum")]
public 				int

             pageNum
 { get; set; }
      [JsonProperty("pageSize")]
public 				int

             pageSize
 { get; set; }
      [JsonProperty("pages")]
public 				int

             pages
 { get; set; }
      [JsonProperty("total")]
public 				int

             total
 { get; set; }
      [JsonProperty("entity")]
public 				List<string>

             entity
 { get; set; }
	}
}
