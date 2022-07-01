using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ResultForLwbMain:JdObject{
      [JsonProperty("wb")]
public 				string

             wb
 { get; set; }
      [JsonProperty("lwb")]
public 				string

             lwb
 { get; set; }
	}
}
