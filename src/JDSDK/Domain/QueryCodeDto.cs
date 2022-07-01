using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class QueryCodeDto:JdObject{
      [JsonProperty("content")]
public 				string

             content
 { get; set; }
	}
}
