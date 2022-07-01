using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JosStatementDTO:JdObject{
      [JsonProperty("vendorCode")]
public 				string

             vendorCode
 { get; set; }
      [JsonProperty("vendorName")]
public 				string

             vendorName
 { get; set; }
      [JsonProperty("billNo")]
public 				string

             billNo
 { get; set; }
      [JsonProperty("billTime")]
public 				string

             billTime
 { get; set; }
      [JsonProperty("finalAmount")]
public 					string

             finalAmount
 { get; set; }
      [JsonProperty("auditStatus")]
public 				int

             auditStatus
 { get; set; }
      [JsonProperty("verifyStatus")]
public 				int

             verifyStatus
 { get; set; }
      [JsonProperty("payStatus")]
public 				int

             payStatus
 { get; set; }
	}
}
