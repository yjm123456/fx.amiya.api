using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class RoResultDto:JdObject{
      [JsonProperty("pageIndex")]
public 				int

             pageIndex
 { get; set; }
      [JsonProperty("pageSize")]
public 				int

             pageSize
 { get; set; }
      [JsonProperty("recordCount")]
public 				int

             recordCount
 { get; set; }
      [JsonProperty("roDtoList")]
public 				List<string>

             roDtoList
 { get; set; }
	}
}
