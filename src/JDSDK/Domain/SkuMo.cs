using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SkuMo:JdObject{
      [JsonProperty("detailId")]
public 				string

             detailId
 { get; set; }
      [JsonProperty("skuId")]
public 				long

             skuId
 { get; set; }
      [JsonProperty("skuName")]
public 				string

             skuName
 { get; set; }
      [JsonProperty("count")]
public 				long

             count
 { get; set; }
      [JsonProperty("money")]
public 					string

             money
 { get; set; }
      [JsonProperty("direction")]
public 				int

             direction
 { get; set; }
      [JsonProperty("businessUuid")]
public 				string

             businessUuid
 { get; set; }
      [JsonProperty("chargingRecordId")]
public 				long

             chargingRecordId
 { get; set; }
      [JsonProperty("settlementRecordId")]
public 				long

             settlementRecordId
 { get; set; }
      [JsonProperty("currency")]
public 				string

             currency
 { get; set; }
      [JsonProperty("feeType")]
public 				int

             feeType
 { get; set; }
      [JsonProperty("settlementStatus")]
public 				int

             settlementStatus
 { get; set; }
      [JsonProperty("settlementTime")]
public 				DateTime

             settlementTime
 { get; set; }
      [JsonProperty("billNo")]
public 				string

             billNo
 { get; set; }
	}
}
