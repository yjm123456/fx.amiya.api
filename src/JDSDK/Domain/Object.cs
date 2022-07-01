using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class Object:JdObject{
      [JsonProperty("page")]
public 				int

             page
 { get; set; }
      [JsonProperty("pageSize")]
public 				int

             pageSize
 { get; set; }
      [JsonProperty("total")]
public 				int

             total
 { get; set; }
      [JsonProperty("rows")]
public 				List<string>

             rows
 { get; set; }
	}
}
