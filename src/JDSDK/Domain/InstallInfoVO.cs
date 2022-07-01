using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class InstallInfoVO:JdObject{
      [JsonProperty("installTime")]
public 				string

             installTime
 { get; set; }
      [JsonProperty("installContent")]
public 				string

             installContent
 { get; set; }
      [JsonProperty("installCodeName")]
public 				string

             installCodeName
 { get; set; }
      [JsonProperty("source")]
public 				string

             source
 { get; set; }
	}
}
