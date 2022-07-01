using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PageQuery:JdObject{
      [JsonProperty("pageSize")]
public 				int

             pageSize
 { get; set; }
      [JsonProperty("pageIndex")]
public 				int

             pageIndex
 { get; set; }
      [JsonProperty("total")]
public 				long

             total
 { get; set; }
	}
}
