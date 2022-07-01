using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ResponsePageDTO:JdObject{
      [JsonProperty("curPage")]
public 				int

             curPage
 { get; set; }
      [JsonProperty("pageSize")]
public 				int

             pageSize
 { get; set; }
      [JsonProperty("totalPage")]
public 				int

             totalPage
 { get; set; }
      [JsonProperty("totalRow")]
public 				int

             totalRow
 { get; set; }
      [JsonProperty("start")]
public 				int

             start
 { get; set; }
      [JsonProperty("end")]
public 				int

             end
 { get; set; }
      [JsonProperty("result")]
public 				List<string>

             result
 { get; set; }
	}
}
