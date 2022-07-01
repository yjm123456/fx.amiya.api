using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SearchResult:JdObject{
      [JsonProperty("code")]
public 				int

             code
 { get; set; }
      [JsonProperty("total")]
public 				long

             total
 { get; set; }
      [JsonProperty("skuList")]
public 				List<string>

             skuList
 { get; set; }
	}
}
