using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PauseBizDataYy:JdObject{
      [JsonProperty("codDT")]
public 				string

             codDT
 { get; set; }
      [JsonProperty("dbDT")]
public 				string

             dbDT
 { get; set; }
      [JsonProperty("ljDT")]
public 				string

             ljDT
 { get; set; }
	}
}
