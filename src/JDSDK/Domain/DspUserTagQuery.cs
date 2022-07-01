using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class DspUserTagQuery:JdObject{
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("type")]
public 				int[]

             type
 { get; set; }
      [JsonProperty("pid")]
public 				long

             pid
 { get; set; }
      [JsonProperty("wid")]
public 				long

             wid
 { get; set; }
      [JsonProperty("status")]
public 				long

             status
 { get; set; }
	}
}
