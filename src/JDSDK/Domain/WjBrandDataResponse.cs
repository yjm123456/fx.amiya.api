using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WjBrandDataResponse:JdObject{
      [JsonProperty("success")]
public 				string

             success
 { get; set; }
      [JsonProperty("msg")]
public 				string

             msg
 { get; set; }
      [JsonProperty("invalidskuid")]
public 				string

             invalidskuid
 { get; set; }
      [JsonProperty("rstlist")]
public 				List<string>

             rstlist
 { get; set; }
      [JsonProperty("rstlist2")]
public 				List<string>

             rstlist2
 { get; set; }
	}
}
