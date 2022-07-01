using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ADReportVO:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("sumDisplay")]
public 				long

             sumDisplay
 { get; set; }
      [JsonProperty("sumClick")]
public 				long

             sumClick
 { get; set; }
      [JsonProperty("sumCost")]
public 				double

             sumCost
 { get; set; }
	}
}
