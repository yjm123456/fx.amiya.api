using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class RechargeRecordDTO:JdObject{
      [JsonProperty("providerCode")]
public 				string

             providerCode
 { get; set; }
      [JsonProperty("providerName")]
public 				string

             providerName
 { get; set; }
      [JsonProperty("branchCode")]
public 				string

             branchCode
 { get; set; }
      [JsonProperty("branchName")]
public 				string

             branchName
 { get; set; }
      [JsonProperty("state")]
public 				int

             state
 { get; set; }
      [JsonProperty("operatorTime")]
public 				DateTime

             operatorTime
 { get; set; }
      [JsonProperty("operatorName")]
public 				DateTime

             operatorName
 { get; set; }
      [JsonProperty("amount")]
public 				int

             amount
 { get; set; }
	}
}
