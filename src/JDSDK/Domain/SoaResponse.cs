using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SoaResponse:JdObject{
      [JsonProperty("reason")]
public 				string

             reason
 { get; set; }
      [JsonProperty("code")]
public 				int

             code
 { get; set; }
      [JsonProperty("success")]
public 					bool

             success
 { get; set; }
	}
}
