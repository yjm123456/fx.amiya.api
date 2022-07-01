using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class FeeAccountResult:JdObject{
      [JsonProperty("deptNo")]
public 				string

             deptNo
 { get; set; }
      [JsonProperty("accountNo")]
public 				string

             accountNo
 { get; set; }
      [JsonProperty("incomePayoutFlag")]
public 				int[]

             incomePayoutFlag
 { get; set; }
      [JsonProperty("settlementTarget")]
public 				int[]

             settlementTarget
 { get; set; }
      [JsonProperty("settlementPerson")]
public 				string

             settlementPerson
 { get; set; }
      [JsonProperty("settlementPersonName")]
public 				string

             settlementPersonName
 { get; set; }
      [JsonProperty("accountDay")]
public 				DateTime

             accountDay
 { get; set; }
      [JsonProperty("amount")]
public 					string

             amount
 { get; set; }
      [JsonProperty("status")]
public 				int[]

             status
 { get; set; }
      [JsonProperty("totalRecord")]
public 				int[]

             totalRecord
 { get; set; }
	}
}
