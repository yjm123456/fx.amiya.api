using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class Summary:JdObject{
      [JsonProperty("ResultCount")]
public 				string

             ResultCount
 { get; set; }
	}
}
