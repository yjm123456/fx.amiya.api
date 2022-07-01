using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class Paginator:JdObject{
      [JsonProperty("pageNum")]
public 				int

             pageNum
 { get; set; }
      [JsonProperty("items")]
public 				long

             items
 { get; set; }
      [JsonProperty("pageSize")]
public 				int

             pageSize
 { get; set; }
	}
}
