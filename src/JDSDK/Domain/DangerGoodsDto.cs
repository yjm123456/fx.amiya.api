using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class DangerGoodsDto:JdObject{
      [JsonProperty("key")]
public 				string

             key
 { get; set; }
      [JsonProperty("val")]
public 				int

             val
 { get; set; }
	}
}
