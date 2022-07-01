using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SoPackMaterial:JdObject{
      [JsonProperty("goodsMaterialName")]
public 				string

             goodsMaterialName
 { get; set; }
      [JsonProperty("model")]
public 				string

             model
 { get; set; }
	}
}
