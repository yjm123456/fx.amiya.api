using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AuthMethodVo:JdObject{
      [JsonProperty("validateName")]
public 				string

             validateName
 { get; set; }
      [JsonProperty("riskRule")]
public 				string

             riskRule
 { get; set; }
      [JsonProperty("validateType")]
public 				int

             validateType
 { get; set; }
	}
}
