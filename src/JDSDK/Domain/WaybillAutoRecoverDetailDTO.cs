using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WaybillAutoRecoverDetailDTO:JdObject{
      [JsonProperty("providerCode")]
public 				string

             providerCode
 { get; set; }
      [JsonProperty("waybillCode")]
public 				string

             waybillCode
 { get; set; }
      [JsonProperty("branchCode")]
public 				string

             branchCode
 { get; set; }
      [JsonProperty("vendorCode")]
public 				string

             vendorCode
 { get; set; }
      [JsonProperty("vendorName")]
public 				string

             vendorName
 { get; set; }
      [JsonProperty("recoverTime")]
public 				DateTime

             recoverTime
 { get; set; }
      [JsonProperty("recoverReason")]
public 				string

             recoverReason
 { get; set; }
      [JsonProperty("orderTime")]
public 				DateTime

             orderTime
 { get; set; }
	}
}
