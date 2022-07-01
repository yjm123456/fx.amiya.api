using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class InvoiceOwnQueryResult:JdObject{
      [JsonProperty("success")]
public 					bool

             success
 { get; set; }
      [JsonProperty("message")]
public 				string

             message
 { get; set; }
      [JsonProperty("total")]
public 				long

             total
 { get; set; }
      [JsonProperty("data")]
public 				List<string>

             data
 { get; set; }
	}
}
