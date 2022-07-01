using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class Feature:JdObject{
      [JsonProperty("key")]
public 				string

             key
 { get; set; }
      [JsonProperty("fvalue")]
public 				string

             fvalue
 { get; set; }
      [JsonProperty("cn")]
public 				string

             cn
 { get; set; }
	}
}
