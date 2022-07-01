using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SkuFareTemplateResult:JdObject{
      [JsonProperty("resultStr")]
public 				string

             resultStr
 { get; set; }
      [JsonProperty("template_list")]
public 				List<string>

                                                                                     templateList
 { get; set; }
	}
}
