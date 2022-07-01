using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ObjA_Price:JdObject{
      [JsonProperty("max")]
public 				string

             max
 { get; set; }
      [JsonProperty("min")]
public 				string

             min
 { get; set; }
	}
}
