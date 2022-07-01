using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SkuFareTemplateRuleResult:JdObject{
      [JsonProperty("resultStr")]
public 				string

             resultStr
 { get; set; }
      [JsonProperty("types")]
public 				List<string>

             types
 { get; set; }
	}
}
