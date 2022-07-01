using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PageModel:JdObject{
      [JsonProperty("totalElements")]
public 				long

             totalElements
 { get; set; }
      [JsonProperty("pageIndex")]
public 				int

             pageIndex
 { get; set; }
      [JsonProperty("pageSize")]
public 				int

             pageSize
 { get; set; }
      [JsonProperty("content")]
public 				List<string>

             content
 { get; set; }
	}
}
