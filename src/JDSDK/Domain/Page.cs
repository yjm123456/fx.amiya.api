using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class Page:JdObject{
      [JsonProperty("success")]
public 				bool

             success
 { get; set; }
      [JsonProperty("reason")]
public 				string

             reason
 { get; set; }
      [JsonProperty("page")]
public 				int

             page
 { get; set; }
      [JsonProperty("pageSize")]
public 				int

             pageSize
 { get; set; }
      [JsonProperty("totalPage")]
public 				int

             totalPage
 { get; set; }
      [JsonProperty("totalItem")]
public 				int

             totalItem
 { get; set; }
      [JsonProperty("itemList")]
public 				List<string>

             itemList
 { get; set; }
	}
}
