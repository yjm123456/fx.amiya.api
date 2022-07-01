using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SignSuccessQueryDTO:JdObject{
      [JsonProperty("providerCode")]
public 				string

             providerCode
 { get; set; }
      [JsonProperty("providerId")]
public 				int

             providerId
 { get; set; }
      [JsonProperty("providerName")]
public 				string

             providerName
 { get; set; }
      [JsonProperty("providerType")]
public 				byte

             providerType
 { get; set; }
      [JsonProperty("supportCod")]
public 				bool

             supportCod
 { get; set; }
      [JsonProperty("operationType")]
public 				byte

             operationType
 { get; set; }
      [JsonProperty("branchCode")]
public 				string

             branchCode
 { get; set; }
      [JsonProperty("branchName")]
public 				string

             branchName
 { get; set; }
      [JsonProperty("settlementCode")]
public 				string

             settlementCode
 { get; set; }
      [JsonProperty("amount")]
public 				long

             amount
 { get; set; }
      [JsonProperty("address")]
public 				WaybillAddress

             address
 { get; set; }
	}
}
