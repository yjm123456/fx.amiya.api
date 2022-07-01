using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SkuFareTemplate:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("index")]
public 				int

             index
 { get; set; }
      [JsonProperty("template_name")]
public 				string

                                                                                     templateName
 { get; set; }
      [JsonProperty("rule_type")]
public 				int

                                                                                     ruleType
 { get; set; }
      [JsonProperty("is_free")]
public 				int

                                                                                     isFree
 { get; set; }
	}
}
