using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class RPCResult:JdObject{
      [JsonProperty("success")]
public 				bool

             success
 { get; set; }
      [JsonProperty("code")]
public 				string

             code
 { get; set; }
      [JsonProperty("errorMsg")]
public 				string

             errorMsg
 { get; set; }
      [JsonProperty("errorField")]
public 				string

             errorField
 { get; set; }
      [JsonProperty("errorId")]
public 				string

             errorId
 { get; set; }
      [JsonProperty("reqId")]
public 				string

             reqId
 { get; set; }
      [JsonProperty("extMessage")]
public 					Dictionary<string, object>

             extMessage
 { get; set; }
      [JsonProperty("result")]
public 				PaginationResp

             result
 { get; set; }
	}
}
