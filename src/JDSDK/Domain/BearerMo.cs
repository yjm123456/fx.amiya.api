using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class BearerMo:JdObject{
      [JsonProperty("contributeParty")]
public 				string

             contributeParty
 { get; set; }
      [JsonProperty("money")]
public 					string

             money
 { get; set; }
	}
}
