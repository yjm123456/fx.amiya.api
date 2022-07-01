using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class TraceDetailDto:JdObject{
      [JsonProperty("thirdId")]
public 				int

             thirdId
 { get; set; }
      [JsonProperty("shipId")]
public 				string

             shipId
 { get; set; }
      [JsonProperty("traceDate")]
public 				DateTime

             traceDate
 { get; set; }
      [JsonProperty("processDate")]
public 				DateTime

             processDate
 { get; set; }
      [JsonProperty("createDate")]
public 				DateTime

             createDate
 { get; set; }
      [JsonProperty("updateDate")]
public 				DateTime

             updateDate
 { get; set; }
      [JsonProperty("batid")]
public 				string

             batid
 { get; set; }
      [JsonProperty("processInfo")]
public 				string

             processInfo
 { get; set; }
      [JsonProperty("scanType")]
public 				string

             scanType
 { get; set; }
      [JsonProperty("courier")]
public 				string

             courier
 { get; set; }
      [JsonProperty("courierTel")]
public 				string

             courierTel
 { get; set; }
	}
}
