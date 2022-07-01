using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderDefaultResultStatus:JdObject{
      [JsonProperty("eclpSoNo")]
public 				string

             eclpSoNo
 { get; set; }
      [JsonProperty("isvUUID")]
public 				string

             isvUUID
 { get; set; }
      [JsonProperty("orderStatusList")]
public 				List<string>

             orderStatusList
 { get; set; }
	}
}
