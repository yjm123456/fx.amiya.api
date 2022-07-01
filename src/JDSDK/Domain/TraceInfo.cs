using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class TraceInfo:JdObject{
      [JsonProperty("opeRemark")]
public 				string

             opeRemark
 { get; set; }
      [JsonProperty("extend")]
public 					Dictionary<string, object>

             extend
 { get; set; }
      [JsonProperty("opeTitle")]
public 				string

             opeTitle
 { get; set; }
      [JsonProperty("courier")]
public 				string

             courier
 { get; set; }
      [JsonProperty("opeTime")]
public 				string

             opeTime
 { get; set; }
      [JsonProperty("opeName")]
public 				string

             opeName
 { get; set; }
      [JsonProperty("waybillCode")]
public 				string

             waybillCode
 { get; set; }
      [JsonProperty("state")]
public 				string

             state
 { get; set; }
      [JsonProperty("courierTel")]
public 				string

             courierTel
 { get; set; }
	}
}
