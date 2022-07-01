using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ErpPageResult:JdObject{
      [JsonProperty("code")]
public 				int

             code
 { get; set; }
      [JsonProperty("msg")]
public 				string

             msg
 { get; set; }
      [JsonProperty("success")]
public 				bool

             success
 { get; set; }
      [JsonProperty("pageSize")]
public 				int

             pageSize
 { get; set; }
      [JsonProperty("pageIndex")]
public 				int

             pageIndex
 { get; set; }
      [JsonProperty("data")]
public 				List<string>

             data
 { get; set; }
	}
}
