using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PageList:JdObject{
      [JsonProperty("datas")]
public 				List<string>

             datas
 { get; set; }
      [JsonProperty("ext")]
public 					Dictionary<string, object>

             ext
 { get; set; }
      [JsonProperty("paginator")]
public 				Paginator

             paginator
 { get; set; }
	}
}
