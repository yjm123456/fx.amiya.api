using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class BusinessInfo:JdObject{
      [JsonProperty("bId")]
public 				long

             bId
 { get; set; }
      [JsonProperty("pId")]
public 				long

             pId
 { get; set; }
      [JsonProperty("businessName")]
public 				string

             businessName
 { get; set; }
      [JsonProperty("companyId")]
public 				long

             companyId
 { get; set; }
      [JsonProperty("lastOpertor")]
public 				string

             lastOpertor
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("mark")]
public 				string

             mark
 { get; set; }
	}
}
