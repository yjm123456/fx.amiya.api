using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class FeeDetailResult:JdObject{
      [JsonProperty("deptNo")]
public 				string

             deptNo
 { get; set; }
      [JsonProperty("feeDay")]
public 				DateTime

             feeDay
 { get; set; }
      [JsonProperty("jobNo")]
public 				string

             jobNo
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
      [JsonProperty("businessType")]
public 				int

             businessType
 { get; set; }
      [JsonProperty("billType")]
public 				string

             billType
 { get; set; }
      [JsonProperty("billTypeName")]
public 				string

             billTypeName
 { get; set; }
      [JsonProperty("accountNo")]
public 				string

             accountNo
 { get; set; }
      [JsonProperty("status")]
public 				int[]

             status
 { get; set; }
      [JsonProperty("feeType")]
public 				int[]

             feeType
 { get; set; }
      [JsonProperty("subjectNo")]
public 				string

             subjectNo
 { get; set; }
      [JsonProperty("subjectName")]
public 				string

             subjectName
 { get; set; }
      [JsonProperty("feeMode")]
public 				int[]

             feeMode
 { get; set; }
      [JsonProperty("amount")]
public 					string

             amount
 { get; set; }
      [JsonProperty("feeQty")]
public 					string

             feeQty
 { get; set; }
      [JsonProperty("createUser")]
public 				string

             createUser
 { get; set; }
      [JsonProperty("createTime")]
public 				DateTime

             createTime
 { get; set; }
      [JsonProperty("totalRecord")]
public 				int[]

             totalRecord
 { get; set; }
	}
}
