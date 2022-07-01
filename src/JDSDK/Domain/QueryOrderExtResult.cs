using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class QueryOrderExtResult:JdObject{
      [JsonProperty("isvUUID")]
public 				string

             isvUUID
 { get; set; }
      [JsonProperty("spSoNo")]
public 				string

             spSoNo
 { get; set; }
      [JsonProperty("eclpSoNo")]
public 				string

             eclpSoNo
 { get; set; }
      [JsonProperty("wayBill")]
public 				string

             wayBill
 { get; set; }
      [JsonProperty("mainStatus")]
public 				int

             mainStatus
 { get; set; }
      [JsonProperty("resultMessage")]
public 				string

             resultMessage
 { get; set; }
      [JsonProperty("resultCode")]
public 				int

             resultCode
 { get; set; }
      [JsonProperty("operTime")]
public 				string

             operTime
 { get; set; }
      [JsonProperty("scanTime")]
public 				string

             scanTime
 { get; set; }
	}
}
