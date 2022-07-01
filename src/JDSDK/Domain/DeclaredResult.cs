using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class DeclaredResult:JdObject{
      [JsonProperty("logisticsCode")]
public 				string

             logisticsCode
 { get; set; }
      [JsonProperty("logisticsNo")]
public 				string

             logisticsNo
 { get; set; }
      [JsonProperty("customId")]
public 				string

             customId
 { get; set; }
      [JsonProperty("pattern")]
public 				string

             pattern
 { get; set; }
      [JsonProperty("deptNo")]
public 				string

             deptNo
 { get; set; }
      [JsonProperty("spSoNo")]
public 				string

             spSoNo
 { get; set; }
      [JsonProperty("venderId")]
public 				string

             venderId
 { get; set; }
      [JsonProperty("result")]
public 				int

             result
 { get; set; }
      [JsonProperty("time")]
public 				DateTime

             time
 { get; set; }
      [JsonProperty("processStatus")]
public 				string

             processStatus
 { get; set; }
      [JsonProperty("statusMsg")]
public 				string

             statusMsg
 { get; set; }
      [JsonProperty("goodsCheck")]
public 				string

             goodsCheck
 { get; set; }
      [JsonProperty("actualTax")]
public 				double

             actualTax
 { get; set; }
      [JsonProperty("message")]
public 				string

             message
 { get; set; }
      [JsonProperty("storeId")]
public 				string

             storeId
 { get; set; }
      [JsonProperty("isvUUID")]
public 				string

             isvUUID
 { get; set; }
      [JsonProperty("errorCode")]
public 				string

             errorCode
 { get; set; }
	}
}
