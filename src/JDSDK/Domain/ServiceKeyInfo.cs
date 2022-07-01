using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ServiceKeyInfo:JdObject{
      [JsonProperty("service")]
public 				string

             service
 { get; set; }
      [JsonProperty("current_key_version")]
public 				int

                                                                                                                     currentKeyVersion
 { get; set; }
      [JsonProperty("grant_usage")]
public 				string

                                                                                     grantUsage
 { get; set; }
      [JsonProperty("keys")]
public 				List<string>

             keys
 { get; set; }
	}
}
