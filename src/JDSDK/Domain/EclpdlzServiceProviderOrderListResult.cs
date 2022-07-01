using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class EclpdlzServiceProviderOrderListResult:JdObject{
      [JsonProperty("header")]
public 				EclpdlzServiceProviderResultHead

             header
 { get; set; }
      [JsonProperty("body")]
public 				List<string>

             body
 { get; set; }
      [JsonProperty("page")]
public 				int

             page
 { get; set; }
      [JsonProperty("pageSize")]
public 				int

             pageSize
 { get; set; }
      [JsonProperty("totalCount")]
public 				long

             totalCount
 { get; set; }
	}
}
