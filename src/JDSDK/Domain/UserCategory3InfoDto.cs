using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class UserCategory3InfoDto:JdObject{
      [JsonProperty("providerCode")]
public 				string

             providerCode
 { get; set; }
      [JsonProperty("userCategory3Dtos")]
public 				List<string>

             userCategory3Dtos
 { get; set; }
	}
}
