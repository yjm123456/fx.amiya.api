using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class DataVO:JdObject{
      [JsonProperty("totalRows")]
public 				int

             totalRows
 { get; set; }
      [JsonProperty("pageSize")]
public 				int

             pageSize
 { get; set; }
      [JsonProperty("currentPage")]
public 				int

             currentPage
 { get; set; }
      [JsonProperty("list")]
public 				OneOrderVO[]

             list
 { get; set; }
	}
}
